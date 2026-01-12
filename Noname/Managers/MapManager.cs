using System;
using System.Collections.Generic;
using System.Text;

public class MapManager
{
    // 맵 상태를 변경하는 것과 관련된 필드와 메서드

    public Mapdata1 _mapinfo = new Mapdata1();
    public int[,] MazeTileGrid = new int[5, 5];


    public int _playerY;
    public int _playerX;

    public int _goalX;
    public int _goalY;

    
}
