using System;
using System.Collections.Generic;
using System.Text;

public class MazeTile
{
    public int _tilenumber;//타일 넘버
    public int[] _tileinfo = new int[48];  //출력에 필요한 정보


    public MazeTile(int order, int[,] map)
    {
        _tilenumber = order;
        // 생성시 타일 넘버 부여
        Readinfo(order, map);
    }

    public void Readinfo(int order, int[,] map)  // 순서에 따른 맵 출력 형태 배열 할당
    {

        int x = IgniteX(order);  // 타일 번호에 따른 출력 시작점
        int y = IgniteY(order);  //
        
        _tileinfo[0] = map[y, x];
        for (int i = 1; i <= 5; i++)
        {
            _tileinfo[i] = map[y+1, x-3 + i];
        }
        for (int i = 6; i <= 41; )
        {
            for (int j = y+2; j <= y+5; j++)
            {
                for (int k = x - 4; k <= x + 4; k++)
                {
                    _tileinfo[i] = map[j, k];
                    i++;
                }
            }
        }
        for (int i = 42; i <= 46; i++)
        {
            _tileinfo[i] = map[y+6, x-44+i];
        }
        _tileinfo[47] = map[y+7, x];
    }

    public void Writeinfo(MazeTile now, int key, int[,] map) 
    { //키에 해당하는 위치에 현재 미로타일 정보를 보여지는 맵에 덮어 쓰는 메서드
        int x = IgniteX(key);
        int y = IgniteY(key);

        map[y, x] = now._tileinfo[0];
        for (int i = 1; i <= 5; i++)
        {
            map[y + 1, x - 3 + i] = now._tileinfo[i];
        }
        for (int i = 6; i <= 41; )
        {
            for (int j = y + 2; j <= y + 5; j++)
            {
                for (int k = x - 4; k <= x + 4; k++)
                {
                    map[j, k] = _tileinfo[i];
                    i++;
                }
            }
        }
        for (int i = 42; i <= 46; i++)
        {
            map[y + 6, x - 44 +i] = _tileinfo[i];
        }
        map[y + 7, x] = _tileinfo[47];
    }
    public int IgniteX(int x)  //x좌표 점화식
    {
        if (x < 4)
            return 10 * x + 4;
        else if (x < 8)
            return 10 * (x - 4) + 9;
        else if (x < 13)
            return 10 * (x - 8) + 4;
        else if (x < 17)
            return 10 * (x - 13) + 9;
        else
            return 10 * (x - 16) + 4;

    }

    public int IgniteY(int y)  //y좌표 점화식
    {
        if (y < 4)
            return 1;
        else if (y < 8)
            return 6;
        else if (y < 13)
            return 11;
        else if (y < 17)
            return 16;
        else
            return 21;
    }
}


