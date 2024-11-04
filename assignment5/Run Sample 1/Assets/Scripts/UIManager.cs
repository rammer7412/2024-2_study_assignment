using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text MessageText;
    public GameObject RestartButton;

    void Awake()
    {
        RestartButton.SetActive(false);
    }

    // Display the Score
    public void DisplayScore(int score)
    {
        ScoreText.text = score.ToString();
    }
    
    // Display the message for duration sec.
    public void DisplayMessage(string message, float duration)
    {
        StartCoroutine(DisplayMessageCoroutine(message, duration));
    }
    IEnumerator DisplayMessageCoroutine(string message, float duration)
    {
        MessageText.text = message;
        yield return new WaitForSeconds(duration);
        MessageText.text = "";
    }

}
