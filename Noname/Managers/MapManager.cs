using System;
using System.Collections.Generic;
using System.Text;


public class MapManager
{
    // 맵 상태를 변경하는 것과 관련된 필드와 메서드

    public Mapdata1 _mapinfo = new Mapdata1(); //원래 맵정보
    public Dictionary<int, MazeTile> _mazepoint= new Dictionary<int, MazeTile>();
    // 좌표를 딕셔너리의 키로 좌표에 있는 미로 타일의 정보 관리
    

    public int _playerY;
    public int _playerX;

    public int _goalX;
    public int _goalY;

    public MapManager()
    {
        //초기 맵 생성, 무작위 셔플
        int[] start = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
        Random.Shared.Shuffle(start);
        
        //19개 타일 인스턴스 생성
        for(int i =0; i<19; i++) _mazepoint.Add(i+1, new MazeTile(start[i], _mapinfo.path));

    }

    
}
