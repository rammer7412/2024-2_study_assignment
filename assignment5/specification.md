# Assignment 5

기초 스터디 5차시 Unity 1차시에 대한 과제입니다.

<br/>

**유니티 2022.3.26f1 버전을 사용하였습니다.**

<br/>

Unity Hub를 실행하시고

Projects > Add > Add project from disk를 누르시고,

Run Sample 1 폴더를 선택하시면 목록에 추가됩니다.

<br/>

명세를 잘 읽어보시고 Scene을 만들어주세요.

Scene 이외의 것들은 수정하시면 안됩니다.

<br/>

제출 시에는 스터디장의 안내에 따라 정해진 branch에 push해주세요.

## 1. Scene

Assets/Scenes 폴더에 Scene을 하나 만들어주세요.

<br/>

지금부터 

Assets/Objects 폴더 안에 있는 프리팹들과,

Assets/Scripts 폴더 안에 있는 스크립트들을 배치할 것입니다.

## 2. 기본 요소 배치

### Character

Circle Sprite를 생성해주세요.

<br/>

이름을 "Character"로 바꾸고, 3가지 컴포넌트를 붙여 주세요.

- Rigidbody2D
- PolygonCollider2D
- Scripts/Character

### UI Manager

Canvas를 생성해주세요.

<br/>

**Text를 만드실 때에는 TextMeshPro를 사용하지 말고, Objects/Text 프리팹을 사용해주세요.**

<br/>

Canvas에 3가지 오브젝트를 적절한 위치에 배치해주세요.
- "Score"라는 이름의 텍스트 (프리팹)
- "Message"라는 이름의 텍스트 (프리팹)
- "Button"이라는 이름의 버튼, 버튼 내부 텍스트는 "Restart"

"Button"에서 자동 생성된 텍스트를 삭제하시고, 프리팹 텍스트를 붙여주세요.
TextMeshPro 관련 오류 창은 무시하셔도 됩니다.

<br/>

Canvas에 Scripts/UIManager 컴포넌트를 붙인 후에,

Score Text, Message Text, Restart Button에 각각 적절한 것들을 붙여주세요.

### Game Manager

"GameManager"라는 이름의 빈 오브젝트를 생성해주세요.
(이름을 실수하시면 안됩니다)

Scripts/GameManager 컴포넌트를 붙인 후에,

My UI Manager, Character, Cam Obj에 각각 적절한 것들을 붙여주세요.

Restart Button에서 onclick 하단에 + 버튼을 누르신 후에,

Scene에 있는 GameManager를 붙여 주세요. *Asset에 있는 GameManager가 아닙니다.

### Test

Objects/Platform Character 아래에 배치하고, 크기를 충분히 늘려주세요.

게임을 실행했을 때에 Character가 우측으로 움직이고,

클릭을 했을 때 점프(2회)가 된다면 성공입니다.

## 3. 게임 요소 배치

Objects 내부의 요소들을 자유롭게 배치하여 맵을 만들어주세요.

- Platform: 말 그대로 발판입니다. 아래에서 위로는 통과할 수 있습니다.
- Point: 닿으면 사라지면서 Score를 올려줍니다.
- SquareObstacle, TriangleObstacle: 닿으면 게임 오버 됩니다.
