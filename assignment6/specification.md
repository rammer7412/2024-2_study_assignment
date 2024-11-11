# Assignment 6

기초 스터디 6차시 Unity 2차시에 대한 과제입니다.

<br/>

**유니티 2022.3.26f1 버전을 사용하였습니다.**

<br/>

Unity Hub를 실행하시고

Projects > Add > Add project from disk를 누르시고,

Run Sample 2 폴더를 선택하시면 목록에 추가됩니다.

<br/>

명세를 잘 읽어보시고 Assets/Scripts 안에 파일들을 완성해주세요.

<br/>

제출 시에는 스터디장의 안내에 따라 정해진 branch에 push해주세요.

## 1. Scene

Assets/Scenes 폴더에 assignment5에서 만들었던 Scene을 복사해주세요.

만들었던 Scene이 없으실 경우 SampleScene을 사용해주세요.

## 2. Character

Character는 좌클릭시 RemainJump를 소모하여 점프할 수 있습니다.

Platform에 닿으면 RemainJump가 초기화됩니다.

Obstacle과 닿으면 게임 오버됩니다.

Point와 닿으면 점수가 늘어남을 GameManager에 알립니다.

## 3. GameManager

Character는 CharacterSpeed의 속도로 우측으로 이동합니다.

CamObj는 Character를 따라 움직입니다.

GameOver 시에는 Character가 삭제되고, "Game Over!" 메시지와 함께 Restart 버튼이 표시됩니다.

점수가 늘어나면 이를 반영하여 화면에 표시합니다.