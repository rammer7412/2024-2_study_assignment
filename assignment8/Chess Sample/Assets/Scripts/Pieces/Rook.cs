using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rook.cs
public class Rook : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        int limit = (Utils.FieldWidth > Utils.FieldHeight) ? Utils.FieldHeight : Utils.FieldWidth;
        MoveInfo[] ret = new MoveInfo[4 * (limit-1)];
        for (int i = 0; i < 4; i++) {
            int a = 0, b = 0;
            switch (i) {
                case 0:
                    (a,b) = (1,0);
                    break;
                case 1:
                    (a,b) = (-1,0);
                    break;
                case 2:
                    (a,b) = (0,1);
                    break;
                case 3:
                    (a,b) = (0,-1);
                    break;
            }
            // Debug.Log((a,b));
            for (int j = 1; j < limit; j++) {
                ret[i*(limit-1)+j-1] = new MoveInfo(a,b,j);
            }
        }
        return ret;
        // ------
    }
}
