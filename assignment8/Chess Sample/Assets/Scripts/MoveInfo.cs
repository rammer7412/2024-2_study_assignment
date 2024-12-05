public struct MoveInfo
{
    public int dirX;
    public int dirY;
    public int distance;
    
    // (dirX, dirY) 의 방향으로 distance번 움직일 수 있다는 것을 나타냄
    public MoveInfo(int dirX, int dirY, int distance)
    {
        this.dirX = dirX;
        this.dirY = dirY;
        this.distance = distance;
    }
}
