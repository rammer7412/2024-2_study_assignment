using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        int limit = (Utils.FieldWidth > Utils.FieldHeight) ? Utils.FieldHeight : Utils.FieldWidth;
        MoveInfo[] ret = new MoveInfo[8*(limit-1)];
        for (int i = 0; i < 8; i++) {
            int a = 0, b = 0;
            switch (i%4) {
                case 0:
                    (a,b) = (-1,-1);
                    break;
                case 1:
                    (a,b) = (-1,0);
                    break;
                case 2:
                    (a,b) = (-1,1);
                    break;
                case 3:
                    (a,b) = (0,1);
                    break;
            }
            if (i/4 == 0) {
                a = -a;
                b = -b;
            }
            for (int j = 1; j < limit; j++) {
                ret[i*(limit-1)+j-1] = new MoveInfo(a,b,j);
            }
        }
        return ret;
        // ------
    }
}