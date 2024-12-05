using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public (int, int) MyPos;    // 자신의 좌표
    public int PlayerDirection = 1; // 자신의 방향 1 - 백, -1 - 흑
    
    public Sprite WhiteSprite;  // 백일 때의 sprite
    public Sprite BlackSprite;  // 흑일 때의 sprite
    
    protected GameManager MyGameManager;
    protected SpriteRenderer MySpriteRenderer;

    void Awake()
    {
        MyGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Piece의 초기 설정 함수
    public void initialize((int, int) targetPos, int direction)
    {
        initSprite(direction);
        MoveTo(targetPos);
    }

    // sprite 초기 설정 함수
    void initSprite(int direction)
    {
        // direction에 따라 sprite를 결정하고, 방향을 결정함
        // --- TODO ---
        if (direction == 1) {
            if (WhiteSprite) {
                MySpriteRenderer.sprite = WhiteSprite;
            }
        }
        else {
            if (BlackSprite) {
                MySpriteRenderer.sprite = BlackSprite;
            }
        }
        PlayerDirection = direction;
        // Debug.Log(WhiteSprite);
        // ------
    }

    // piece의 실제 이동 함수
    public void MoveTo((int, int) targetPos)
    {
        // MyPos를 업데이트하고, targetPos로 이동
        // MyGameManager.Pieces를 업데이트
        // --- TODO ---
        MyGameManager.Pieces[targetPos.Item1, targetPos.Item2] = this; // targetPos에 자기자신 추가
        transform.localPosition = Utils.ToRealPos(targetPos); // 외부적으로 보이는 기물 object도 이동함
        MyPos = targetPos; // MyPos 업데이트
        // 나머지 작업 : MyPos에 있는 자기자신 삭제, 유효한 이동인지 확인 등 -> 상위 클래스에서 해결
        // ------
    }
    
    public abstract MoveInfo[] GetMoves();
}
