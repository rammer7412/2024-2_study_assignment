using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Knight.cs
public class Knight : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        return new MoveInfo[]
        {
            new MoveInfo(1,2,1),
            new MoveInfo(1,-2,1),
            new MoveInfo(-1,2,1),
            new MoveInfo(-1,-2,1),
            new MoveInfo(2,1,1),
            new MoveInfo(2,-1,1),
            new MoveInfo(-2,1,1),
            new MoveInfo(-2,-1,1)
        };
        // ------
    }
}