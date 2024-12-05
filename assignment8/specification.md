# Assignment 8

기초 스터디 8차시 Unity 4차시에 대한 과제입니다.

<br/>

**유니티 2022.3.26f1 버전을 사용하였습니다.**

<br/>

Unity Hub를 실행하시고

Projects > Add > Add project from disk를 누르시고,

Chess Sample 폴더를 선택하시면 목록에 추가됩니다.

<br/>

명세를 잘 읽어보시고 Assets/Scripts 안에 파일들을 완성해주세요.

<br/>

제출 시에는 스터디장의 안내에 따라 정해진 branch에 push해주세요.

체스 규칙을 모르시면 아래 링크에서 확인해주세요.

[체스 규칙](https://www.chess.com/ko/tiesuwosuru)

## 1. 각 Class의 기능

### GameManager
- 전반적인 게임의 흐름을 제어합니다.
- ClickHandler, MovementManager 등 여러 코드의 기능을 사용합니다.
- Piece들을 배치하고, 턴을 제어합니다.

### MovementManager
- Piece의 움직임을 제어하고, 이동 가능한 경로를 표시합니다.
- Piece가 가지고 있는 MoveInfo를 해석하여 경로를 만듭니다.
- Piece간의 위치 관계, 체크 상황 등을 고려하여 이동 가능한 경로를 계산합니다.

### ClickHandler
- 사용자의 입력을 제어합니다.
- 이벤트 함수를 통해 입력 상황에 따른 피드백을 주고, Piece를 이동시킵니다.

### Piece
- 체스에서 사용되는 Piece의 부모 class입니다.
- PlayerDirection에 따라 방향과 sprite를 결정합니다.
- (int, int)를 받아 이동하는 Move를 지원합니다.

### Tile
- 체스 판을 구성하는 Tile입니다.
- 위치에 따라 색깔을 결정합니다.

### UIManager
- UI를 표시합니다.

### Utils
- static class로 여러 class에서 공용으로 사용하는 기능들이 들어있습니다.


## 1. Scene 구성

Sample Scene을 사용하셔도 되고, 따로 만드셔도 좋습니다.

1. GameManager
- 빈 오브젝트를 생성하고 이름을 "GameManager"로 변경합니다.
- GameManager와 MovementManager 컴포넌트를 붙입니다.
- Tile Prefab에 Objects/Tile을 붙입니다.
- Piece Prefabs에 + 버튼을 누르고, Objects/Pieces의 내용물들을 다음 순서로 붙입니다. (King, Queen, Bishop, Knight, Rook, Pawn)
- Effect Prefab에 Objects/Effect를 붙입니다.

2. ClickHandler
- ClickHandler라는 이름의 빈 오브젝트를 생성합니다.
- ClickHandler 컴포넌트를 붙입니다.

3. Parents
- PieceParent라는 이름의 빈 오브젝트를 생성합니다.
- TileParent라는 이름의 빈 오브젝트를 생성하고, (0, 0, 1)의 위치로 이동시킵니다.
- EffectParent라는 이름의 빈 오브젝트를 생성하고, (0, 0, 1)의 위치로 이동시킵니다.

4. Canvas
- 캔버스를 생성합니다.
- UIManger 컴포넌트를 붙입니다.
- TurnText라는 이름의 빈 오브젝트를 자식으로 붙이고, Text 컴포넌트를 붙입니다.
- MessageText라는 이름의 빈 오브젝트를 자식으로 붙이고, Text 컴포넌트를 붙입니다.
- TurnText는 우측 상단에, MessageText는 중앙에 위치시킵니다.


## 2. 주요 기능 구현

### GameManager
- 8x8 체스판 초기화
- 양측 말 배치 (흰색: 1, 검은색: -1)
- 턴 관리
- 말 이동 검증 및 처리

### MovementManager
- 말의 이동 가능 여부 검증
- 체크/체크메이트 상태 확인
- 가능한 이동 위치 표시
- 폰의 특수 이동 규칙 처리

### ClickHandler
- 마우스 입력 처리
- 말 선택 및 드래그 앤 드롭
- 이동 가능 위치 표시
- 이동 실행

### Piece
- 말의 기본 동작 정의
- 이동 규칙 (GetMoves) 구현
- 스프라이트 및 방향 설정

### Tile
- 타일 색깔 설정
- 타일 배치 설정
