using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public (int, int) MyPos;
    public int PlayerDirection = 1;
    
    public Sprite WhiteSprite;
    public Sprite BlackSprite;
    
    protected GameManager MyGameManager;
    protected SpriteRenderer MySpriteRenderer;

    void Awake()
    {
        MyGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void initialize((int, int) targetPos, int direction)
    {
        PlayerDirection = direction;
        initSprite(PlayerDirection);
        MoveTo(targetPos);
    }

    void initSprite(int direction)
    {
        // direction에 따라 sprite를 설정하고 회전함
        // --- TODO ---
        
        // ------
    }

    public void MoveTo((int, int) targetPos)
    {
        // 말을 이동시킴
        // --- TODO ---
        
        // ------
    }

    public abstract MoveInfo[] GetMoves();
}
