using System;
using System.Collections.Generic;
using System.Text;

public class MazeTile
{
    public int _tilenumber;//타일 넘버

    public bool complete = false;



    public MazeTile(int order, int[,] map)
    {
        _tilenumber = order;
        // 생성시 타일 넘버 부여
    }
}