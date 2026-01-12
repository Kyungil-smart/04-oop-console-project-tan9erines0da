using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

public class ScreenManager
{
    // 맵 출력과 관련된 필드와 메서드
    MapManager nowmap = new MapManager();
    public int[,] _presentmap = new int[30, 49]; //보여질 맵 배열




    public void PresentMapUpdate()
    {
        _presentmap = nowmap._mapinfo.path;
        //미로 타일 배치에 따른 수정
        for (int i = 1; i <= 19; i++)
        {
            nowmap._mazepoint[i].Writeinfo(nowmap._mazepoint[i],i, _presentmap);
        }//키 정보를 이용하여 보여지는 맵 수정

    }

    public void Rend() 
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < 30; i++)
        { 
            for(int j = 0; j < 49; j++)
            {
                if(_presentmap[i,j]==0) // 길 출력
                {
                    RendRoad();
                }
                else 
                { 
                    RendWall();
                }
                if(j==48) Console.WriteLine();

            }
        }
        
    }

    public void RendRoad ()
    {
        Console.BackgroundColor = ConsoleColor.White;
        "  ".Print();
        Console.ResetColor();
    }

    public void RendWall()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        "  ".Print();
        Console.ResetColor();
    }
}
