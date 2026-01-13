using System;
using System.Collections.Generic;
using System.Text;



public class MapManager
{
    // 맵 상태를 변경하는 것과 관련된 필드와 메서드

    public Mapdata1 _mapinfo = new Mapdata1(); //원래 맵정보
    public Dictionary<int, int> _mazepoint = new Dictionary<int, int>();
    // 좌표를 딕셔너리의 키로 좌표에 있는 미로 타일 넘버


    public int _playerY;
    public int _playerX;

    public int _goalX;
    public int _goalY;

    public int _goaltile = 19;


    public MapManager()
    {
        _playerY = _mapinfo.start[0];
        _playerX = _mapinfo.start[1];
        _mapinfo.path[_playerY, _playerX] = (int) Object.Player;
        _goalY = _mapinfo.end[0];
        _goalX = _mapinfo.end[1];
        _mapinfo.path[_goalY, _goalX] = (int) Object.Goal;

        //초기 맵 생성, 무작위 셔플
        int[] start = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
        Random random = new Random();
        random.Shuffle(start);

        //19개 타일 인스턴스 생성
        for (int i = 0; i < 18; i++) _mazepoint.Add(i + 1, start[i]);
        _mazepoint.Add(19, 19);

    }

    public bool moveable(int nexty, int nextx)
    {//이동 가능 여부 판단
        if (_mapinfo.path[nexty, nextx] == 1)
            return false;
        else
            return true;
    }
    public void PlayerMoveUp()
    {
        //-1/0 좌표 이동
        int next = _playerY - 1;
        if (!moveable(next, _playerX)) return;
        _mapinfo.path[_playerY, _playerX] = 0;
        _mapinfo.path[next, _playerX] = (int)Object.Player;
        _playerY = next;
    }
    public void PlayerMoveDown()
    {
        //+1/0 좌표 이동
        int next = _playerY + 1;
        if (!moveable(next, _playerX)) return;
        _mapinfo.path[_playerY, _playerX] = 0;
        _mapinfo.path[next, _playerX] = (int)Object.Player;
        _playerY = next;
    }

    public void PlayerMoveLeft()
    {
        //0/-1 좌표 이동
        int next = _playerX - 1;
        if (!moveable(_playerY, next)) return;
        _mapinfo.path[_playerY, _playerX] = 0;
        _mapinfo.path[_playerY, next] = (int)Object.Player;
        _playerX = next;
    }

    public void PlayerMoveRight()
    {
        //0/+1 좌표 이동
        int next = _playerX + 1;
        if (!moveable(_playerY, next)) return;
        _mapinfo.path[_playerY, _playerX] = 0;
        _mapinfo.path[_playerY, next] = (int)Object.Player;
        _playerX = next;
    }
    // 움직임에 관한 메서드 구현 딕셔너리 내에서 자료 수정하는 형식
    public void MoveW()
    {
        //좌표상 +1/0이동
        if (_goaltile == 12|| _goaltile == 16|| _goaltile == 17|| _goaltile == 18|| _goaltile == 19)
            return;
        else 
        { 
        int _next = XYtoKey(KeytoXY(_goaltile, false) + 1, KeytoXY(_goaltile, true));

            int a = _mazepoint[_next];
            _mazepoint[_goaltile] = a;
            _mazepoint[_next] = 19;

            _goaltile = _next;
        }
    }

    public void MoveE()
    {
        //좌표상 +1/-1이동
        if (_goaltile == 8 || _goaltile == 13 || _goaltile == 17 || _goaltile == 18 || _goaltile == 19)
            return;
        else
        {
            int _next = XYtoKey(KeytoXY(_goaltile, false) + 1, KeytoXY(_goaltile, true)-1);

            int a = _mazepoint[_next];
            _mazepoint[_goaltile] = a;
            _mazepoint[_next] = 19;

            _goaltile = _next;
        }
    }
    public void MoveA()
    {
        //좌표상 0/+1이동
        if (_goaltile == 3 || _goaltile == 7 || _goaltile == 12 || _goaltile == 16 || _goaltile == 19)
            return;
        else
        {
            int _next = XYtoKey(KeytoXY(_goaltile, false) , KeytoXY(_goaltile, true) + 1);

            int a = _mazepoint[_next];
            _mazepoint[_goaltile] = a;
            _mazepoint[_next] = 19;

            _goaltile = _next;
        }
    }
    public void MoveD()
    {
        //좌표상 0/-1이동
        if (_goaltile == 1 || _goaltile == 4 || _goaltile == 8 || _goaltile == 13 || _goaltile == 17)
            return;
        else
        {
            int _next = XYtoKey(KeytoXY(_goaltile, false), KeytoXY(_goaltile, true) - 1);

            int a = _mazepoint[_next];
            _mazepoint[_goaltile] = a;
            _mazepoint[_next] = 19;

            _goaltile = _next;
        }
    }

    public void MoveZ()
    {
        //좌표상 -1/+1이동
        if (_goaltile == 1 || _goaltile == 2 || _goaltile == 3 || _goaltile == 7 || _goaltile == 12)
            return;
        else
        {
            int _next = XYtoKey(KeytoXY(_goaltile, false)-1, KeytoXY(_goaltile, true) + 1);

            int a = _mazepoint[_next];
            _mazepoint[_goaltile] = a;
            _mazepoint[_next] = 19;

            _goaltile = _next;
        }
    }
    public void MoveX()
    {
        //좌표상 -1/0이동
        if (_goaltile == 1 || _goaltile == 2 || _goaltile == 3 || _goaltile == 4 || _goaltile == 8)
            return;
        else
        {
            int _next = XYtoKey(KeytoXY(_goaltile, false)-1, KeytoXY(_goaltile, true));

            int a = _mazepoint[_next];
            _mazepoint[_goaltile] = a;
            _mazepoint[_next] = 19;

            _goaltile = _next;
        }
    }


    
    public int XYtoKey(int y, int x)
    {//좌표를 받으면 키로 반환
        if (y == 0)
        {
            switch (x)
            {
                case 2: return 1;
                case 3: return 2;
                default: return 3;
            }
        }
        else if (y == 1)
        {
            switch (x)
            {
                case 1: return 4;
                case 2: return 5;
                case 3: return 6;
                default: return 7;
            }
        }
        else if (y == 2)
        {
            switch (x)
            {
                case 0: return 8;
                case 1: return 9;
                case 2: return 10;
                case 3: return 11;
                default: return 12;
            }
        }
        else if (y == 3)
        {
            switch (x)
            {
                case 0: return 13;
                case 1: return 14;
                case 2: return 15;
                default: return 16;
            }
        }
        else
        {
            switch (x)
            {
                case 0: return 17;
                case 1: return 18;
                default: return 19;
            }
        }

    }

    public int KeytoXY(int key, bool isx)
    { //키를 좌표로 변경
        if (key == 1)
        {
            if (!isx) return 0;
            return 2;
        }
        else if (key == 2)
        {
            if (!isx) return 0;
            return 3;
        }
        else if (key == 3)
        {
            if (!isx) return 0;
            return 4;
        }
        else if (key == 4)
        {
            if (!isx) return 1;
            return 1;
        }
        else if (key == 5)
        {
            if (!isx) return 1;
            return 2;
        }
        else if (key == 6)
        {
            if (!isx) return 1;
            return 3;
        }
        else if (key == 7)
        {
            if (!isx) return 1;
            return 4;
        }
        else if (key == 8)
        {
            if (!isx) return 2;
            return 0;
        }
        else if (key == 9)
        { if (!isx) return 2; else return 1; }
        else if (key == 10)
        { if (!isx) return 2; else return 2; }
        else if (key == 11)
        { if (!isx) return 2; else return 3; }
        else if (key == 12)
        { if (!isx) return 2; else return 4; }
        else if (key == 13)
        { if (!isx) return 3; else return 0; }
        else if (key == 14)
        { if (!isx) return 3; else return 1; }
        else if (key == 15)
        { if (!isx) return 3; return 2; }
        else if (key == 16)
        { if (!isx) return 3; return 3; }
        else if (key == 17)
        { if (!isx) return 4; else return 0; }
        else if (key == 18)
        { if (!isx) return 4; return 1; }
        else 
        { if (!isx) return 4; return 2; }
        
    }
    

}
public enum Object
{
    Wall =1,
    Blank,
    Player,
    Goal 
}
