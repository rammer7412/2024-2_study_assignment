using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text TurnText;
    public Text MessageText;
    public float MessageDuration = 1f;
    private float MessageTimer = 0f;
    private Coroutine CurrentMessage;

    void Update()
    {
        if (MessageTimer > 0)
        {
            MessageTimer -= Time.deltaTime;
            if (MessageTimer <= 0)
            {
                MessageText.text = "";
            }
        }
    }

    public void UpdateTurn(int currentTurn)
    {
        TurnText.text = currentTurn == 1 ? "White's Turn" : "Black's Turn";
    }

    public void ShowMessage(string message, float duration = 1f)
    {
        if (CurrentMessage != null)
        {
            StopCoroutine(CurrentMessage);
        }
        CurrentMessage = StartCoroutine(ShowMessageCoroutine(message, duration));
    }

    private IEnumerator ShowMessageCoroutine(string message, float duration)
    {
        MessageText.text = message;
        yield return new WaitForSeconds(duration);
        if (MessageText.text == message)
        {
            MessageText.text = "";
        }
    }

    public void ShowCheck()
    {
        ShowMessage("Check!", MessageDuration);
    }

    public void ShowCheckmate(int winner)
    {
        ShowMessage($"{(winner == 1 ? "White" : "Black")} wins by checkmate!", float.MaxValue);
    }
}