using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public const int TileSize = 1;  // 타일의 실제 크기
    // 체스판의 크기
    public const int FieldWidth = 8;
    public const int FieldHeight = 8;

    // (int, int)의 좌표를 실제 좌표(Vector2)로 변환
    public static Vector2 ToRealPos((int, int) targetPos)
    {
        return TileSize * (new Vector2(
            targetPos.Item1 - (FieldWidth - 1) / 2f, 
            targetPos.Item2 - (FieldHeight - 1) / 2f
        ));
    }

    // 좌표를 받아 Board 안에 있는지를 리턴
    public static bool IsInBoard((int, int) targetPos)
    {
        (int x, int y) = targetPos;
        return x >= 0 && x < FieldWidth && y >= 0 && y < FieldHeight;
    }
}
