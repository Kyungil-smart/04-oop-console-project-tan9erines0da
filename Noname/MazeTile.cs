using System;
using System.Collections.Generic;
using System.Text;

public class MazeTile
{
    public int _tilenumber;//타일 넘버
    public int _gridX;
    public int _gridY;//좌표
    //맵 정보는 타일 넘버에 종속되는거니까 굳이?

    public MazeTile(int order, int gridX, int gridY)
    {
        _tilenumber = order;
        _gridX = gridX;
        _gridY = gridY;

    }
}
