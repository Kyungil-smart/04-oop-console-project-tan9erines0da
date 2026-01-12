using System;
using System.Collections.Generic;
using System.Text;

public class MapManager
{
    // 맵 상태를 변경하는 것과 관련된 필드와 메서드

    public Mapdata1 _mapinfo = new Mapdata1();
    public Dictionary<int[,], MazeTile> _mazepoint= new Dictionary<int[,], MazeTile>();
    // 좌표를 딕셔너리의 키로 좌표에 있는 미로 타일의 정보 관리
    

    public int _playerY;
    public int _playerX;

    public int _goalX;
    public int _goalY;

    public MapManager()
    {
        //초기 맵 생성, 무작위 셔플

    }

    
}
