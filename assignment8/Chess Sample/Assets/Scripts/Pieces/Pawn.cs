using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // 기본 이동
        if (MyPos.Item2 == (PlayerDirection == 1 ? 1 : 6))
        {
            // 시작 위치에서는 1칸 또는 2칸 전진 가능
            return new MoveInfo[]
            {
                new MoveInfo(0, PlayerDirection, 1),   // 1칸 전진
                new MoveInfo(0, PlayerDirection, 2),   // 2칸 전진
                new MoveInfo(1, PlayerDirection, 1),   // 대각선 공격
                new MoveInfo(-1, PlayerDirection, 1)   // 대각선 공격
            };
        }
        else
        {
            // 일반 위치에서는 1칸 전진과 대각선 공격만 가능
            return new MoveInfo[]
            {
                new MoveInfo(0, PlayerDirection, 1),   // 1칸 전진
                new MoveInfo(1, PlayerDirection, 1),   // 대각선 공격
                new MoveInfo(-1, PlayerDirection, 1)   // 대각선 공격
            };
        }
    }
}