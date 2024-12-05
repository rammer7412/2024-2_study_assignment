using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 프리팹들
    public GameObject TilePrefab;
    public GameObject[] PiecePrefabs;   // King, Queen, Bishop, Knight, Rook, Pawn 순
    public GameObject EffectPrefab;

    // 오브젝트의 parent들
    private Transform TileParent;
    private Transform PieceParent;
    private Transform EffectParent;
    
    private MovementManager movementManager;
    private UIManager uiManager;
    
    public int CurrentTurn = 1; // 현재 턴 1 - 백, 2 - 흑
    public Tile[,] Tiles = new Tile[Utils.FieldWidth, Utils.FieldHeight];   // Tile들
    public Piece[,] Pieces = new Piece[Utils.FieldWidth, Utils.FieldHeight];    // Piece들

    void Awake()
    {
        TileParent = GameObject.Find("TileParent").transform;
        PieceParent = GameObject.Find("PieceParent").transform;
        EffectParent = GameObject.Find("EffectParent").transform;
        
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        movementManager = gameObject.AddComponent<MovementManager>();
        movementManager.Initialize(this, EffectPrefab, EffectParent);
        
        InitializeBoard();
    }

    void InitializeBoard()
    {
        // 8x8로 타일들을 배치
        // TilePrefab을 TileParent의 자식으로 생성하고, 배치함
        // Tiles를 채움
        // --- TODO ---
        uiManager.UpdateTurn(CurrentTurn);
        // TilePrefab.transform.parent = TileParent;
        for (int i = 0; i < Utils.FieldWidth; i++) {
            for (int j = 0; j < Utils.FieldHeight; j++) {
                Tile tile = Instantiate(TilePrefab,TileParent).GetComponent<Tile>();
                tile.Set((i,j));
                Tiles[i,j] = tile;
            }
        }
        // ------

        PlacePieces(1);
        PlacePieces(-1);
    }

    void PlacePieces(int direction)
    {
        // PlacePiece를 사용하여 Piece들을 적절한 모양으로 배치
        // --- TODO ---
        int[] placement1 = {4,3,2,1,0,2,3,4};
        int j;
        j = (direction == 1) ? 0 : 7;
        for (int i = 0; i < Utils.FieldWidth; i++) {
            PlacePiece(placement1[i], (i,j), direction); //
        }

        j = (direction == 1) ? 1 : 6;
        for (int i = 0; i < Utils.FieldWidth; i++) {
            PlacePiece(5, (i,j), direction); //
        }
        // ------
    }

    Piece PlacePiece(int pieceType, (int, int) pos, int direction)
    {
        // Piece를 배치 후, initialize
        // PiecePrefabs의 원소를 사용하여 배치, PieceParent의 자식으로 생성
        // Pieces를 채움
        // 배치한 Piece를 리턴
        // --- TODO ---
        GameObject PiecePrefab = PiecePrefabs[pieceType];
        Piece piece = Instantiate(PiecePrefab,PieceParent).GetComponent<Piece>();
        piece.initialize(pos, direction);
        return piece;
        // ------
    }

    public bool IsValidMove(Piece piece, (int, int) targetPos)
    {
        return movementManager.IsValidMove(piece, targetPos);
    }

    public void ShowPossibleMoves(Piece piece)
    {
        movementManager.ShowPossibleMoves(piece);
    }

    public void ClearEffects()
    {
        movementManager.ClearEffects();
    }


    public void Move(Piece piece, (int, int) targetPos)
    {
        if (!IsValidMove(piece, targetPos)) return;
        
        // 해당 위치에 다른 Piece가 있다면 삭제
        // Piece를 이동시킴
        // --- TODO ---
        // var test = piece.MyPos;
        Piece originalPiece = Pieces[targetPos.Item1, targetPos.Item2];
        if (originalPiece) {
            // Debug.Log(originalPiece);
            Destroy(originalPiece.gameObject);
            // Debug.Log("destroy");
            // Debug.Log(originalPiece);
        }
        (int x, int y) = piece.MyPos; // 원래 있던 위치에 있는 Piece를 Pieces에서만 삭제
        Pieces[x, y] = null;
        piece.MoveTo(targetPos);
        // Debug.Log(targetPos);
        ChangeTurn();
        if (movementManager.IsInMate(CurrentTurn)) {
            if (movementManager.IsInCheck(CurrentTurn)) {
                uiManager.ShowCheckmate(-CurrentTurn);
            }
            else {
                uiManager.ShowStalemate();
            }
        }
        else {
            if (movementManager.IsInCheck(CurrentTurn)) {
                uiManager.ShowCheck();
            }
        }
        // ------
    }

    void ChangeTurn()
    {
        // 턴을 변경하고, UI에 표시
        // --- TODO ---
        if (CurrentTurn == 1) {
            CurrentTurn = -1;
        } else {
            CurrentTurn = 1;
        }
        uiManager.UpdateTurn(CurrentTurn);
        // ------
    }
}
