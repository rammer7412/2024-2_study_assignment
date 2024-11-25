using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public const int TileSize = 1;
    public const int FieldWidth = 8;
    public const int FieldHeight = 8;

    public static Vector2 ToRealPos((int, int) targetPos)
    {
        return TileSize * (new Vector2(
            targetPos.Item1 - (FieldWidth - 1) / 2f, 
            targetPos.Item2 - (FieldHeight - 1) / 2f
        ));
    }

    public static bool IsInBoard((int, int) targetPos)
    {
        (int x, int y) = targetPos;
        return x >= 0 && x < FieldWidth && y >= 0 && y < FieldHeight;
    }
}
