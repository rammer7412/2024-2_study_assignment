using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject effectPrefab;
    private Transform effectParent;
    private List<GameObject> currentEffects = new List<GameObject>();   // 현재 effect들을 저장할 리스트
    
    public void Initialize(GameManager gameManager, GameObject effectPrefab, Transform effectParent)
    {
        this.gameManager = gameManager;
        this.effectPrefab = effectPrefab;
        this.effectParent = effectParent;
    }

    private bool TryMove(Piece piece, (int, int) targetPos, MoveInfo moveInfo)
    {
        // moveInfo의 distance만큼 direction을 이동시키며 이동이 가능한지를 체크
        // 보드에 있는지, 다른 piece에 의해 막히는지 등을 체크
        // 폰에 대한 예외 처리를 적용
        // --- TODO ---
        bool wasItPiece = false;
        (int posX, int posY) = piece.MyPos; // position
        (int incX, int incY) = (moveInfo.dirX,moveInfo.dirY); // increment

        if (piece is Pawn) {
            if (incX == 0) {
                for (int i = 0; i < moveInfo.distance; i++) {
                    posX += incX;
                    posY += incY;
                    if (!Utils.IsInBoard((posX, posY))) return false;
                    // Debug.Log((i,posX,posY,incY));
                    Piece targetPiece = gameManager.Pieces[posX,posY];
                    if (targetPiece) return false;
                }
            }
            else {
                posX += incX;
                posY += incY;
                if (!Utils.IsInBoard((posX,posY))) return false;
                Piece targetPiece = gameManager.Pieces[posX,posY];
                if (targetPiece == null || targetPiece.PlayerDirection == piece.PlayerDirection) return false;
            }
        }
        else {
            for (int i = 0; i < moveInfo.distance; i++) {
                posX += incX;
                posY += incY;

                // 상대방 기물을 만났던 경우, 상대방 기물이 있는 자리까지만 움직일 수 있고, 현재 자리까지는 못 옴
                if (!Utils.IsInBoard((posX, posY)) || wasItPiece) return false;
                

                Piece targetPiece = gameManager.Pieces[posX,posY];
                if (targetPiece) {
                    if (targetPiece.PlayerDirection == piece.PlayerDirection) { // 자신 기물인 경우, 자신 기물은 먹을 수 없으므로 return false
                        return false;
                    }
                    wasItPiece = true;
                }
            }
        }

        if (targetPos == (posX, posY)) {
            return true;
        }
        return false;
        // ------
    }

    // 체크를 제외한 상황에서 가능한 움직임인지를 검증
    private bool IsValidMoveWithoutCheck(Piece piece, (int, int) targetPos)
    {
        if (!Utils.IsInBoard(targetPos) || targetPos == piece.MyPos) return false;

        foreach (var moveInfo in piece.GetMoves())
        {
            if (TryMove(piece, targetPos, moveInfo))
                return true;
        }
        
        return false;
    }

    // 체크를 포함한 상황에서 가능한 움직임인지를 검증
    public bool IsValidMove(Piece piece, (int, int) targetPos)
    {
        if (!IsValidMoveWithoutCheck(piece, targetPos)) return false;

        // 체크 상태 검증을 위한 임시 이동
        var originalPiece = gameManager.Pieces[targetPos.Item1, targetPos.Item2];
        var originalPos = piece.MyPos;

        gameManager.Pieces[targetPos.Item1, targetPos.Item2] = piece;
        gameManager.Pieces[originalPos.Item1, originalPos.Item2] = null;
        piece.MyPos = targetPos;

        bool isValid = !IsInCheck(piece.PlayerDirection);

        // 원상 복구
        gameManager.Pieces[originalPos.Item1, originalPos.Item2] = piece;
        gameManager.Pieces[targetPos.Item1, targetPos.Item2] = originalPiece;
        piece.MyPos = originalPos;

        return isValid;
    }

    // 체크인지를 확인
    public bool IsInCheck(int playerDirection) //
    {
        (int, int) kingPos = (-1, -1); // 왕의 위치
        for (int x = 0; x < Utils.FieldWidth; x++)
        {
            for (int y = 0; y < Utils.FieldHeight; y++)
            {
                var piece = gameManager.Pieces[x, y];
                if (piece is King && piece.PlayerDirection == playerDirection)
                {
                    kingPos = (x, y);
                    break;
                }
            }
            if (kingPos.Item1 != -1 && kingPos.Item2 != -1) break;
        }

        // 왕이 지금 체크 상태인지를 리턴
        // gameManager.Pieces에서 Piece들을 참조하여 움직임을 확인
        // --- TODO ---
        foreach (Piece piece in gameManager.Pieces) {
            if (piece != null && piece.PlayerDirection != playerDirection) {
                if (IsValidMoveWithoutCheck(piece, kingPos)) { //
                    return true;
                }
            }
        }
        return false;
        // ------
    }

    public bool IsInMate(int playerDirection) { // 움직이면 check인 경우(stalemate, checkmate)
        foreach (Piece piece in gameManager.Pieces) {
            if (piece != null && piece.PlayerDirection == playerDirection) { //
                foreach (MoveInfo move in piece.GetMoves()) {
                    (int x, int y) = piece.MyPos;
                    (int, int) targetPos = (x + move.dirX * move.distance, y + move.dirY * move.distance);
                    if (IsValidMove(piece, targetPos)) {
                        return false;
                    }
                }
            }
        }
        return true;
    }



    public void ShowPossibleMoves(Piece piece)
    {
        ClearEffects();

        // 가능한 움직임을 표시
        // IsValidMove를 사용
        // effectPrefab을 effectParent의 자식으로 생성하고 위치를 적절히 설정
        // currentEffects에 effectPrefab을 추가
        // --- TODO ---
        (int x, int y) = piece.MyPos;
        foreach (MoveInfo move in piece.GetMoves()) {
            (int, int) targetPos = (x + move.dirX * move.distance, y + move.dirY * move.distance);
            if (IsValidMove(piece, targetPos)) {
                GameObject effect = Instantiate(effectPrefab, effectParent);
                effect.transform.localPosition = Utils.ToRealPos(targetPos);
                currentEffects.Add(effect);
            }
        }
        // ------
    }

    // 효과 비우기
    public void ClearEffects()
    {
        foreach (var effect in currentEffects)
        {
            if (effect != null) Destroy(effect);
        }
        currentEffects.Clear();
    }
}