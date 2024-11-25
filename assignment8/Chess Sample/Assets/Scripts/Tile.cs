using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public (int, int) MyPos;
    Color tileColor = new Color(255 / 255f, 193 / 255f, 204 / 255f);
    SpriteRenderer MySpriteRenderer;

    private void Awake()
    {
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Set((int, int) targetPos)
    {
        // targetPos로 이동시키고, 색깔을 지정
        // --- TODO ---
        
        // ------
    }
}
