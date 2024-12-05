using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        
        // (int x, int y) = MyPos;
        
        int limit = (Utils.FieldWidth > Utils.FieldHeight) ? Utils.FieldHeight : Utils.FieldWidth;
        MoveInfo[] ret = new MoveInfo[4*(limit-1)];
        for (int i = 0; i < 4; i++) {
            int a = i/2 * 2 - 1;
            int b = i%2 * 2 - 1;
            for (int j = 1; j < limit; j++) {
                ret[i*(limit-1)+j-1] = new MoveInfo(a,b,j);
            }
        }
        return ret;
        // ------
    }
}