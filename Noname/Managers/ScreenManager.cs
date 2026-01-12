using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

public class ScreenManager
{
    // 맵 출력과 관련된 필드와 메서드
    public MapManager nowmap = new MapManager();
    public int[,] _presentmap = new int[30, 49]; //보여질 맵 배열




    public void PresentMapUpdate()
    {
        _presentmap = nowmap._mapinfo.path;
        //미로 타일 배치에 따른 수정
        for (int i = 1; i <= 19; i++)
        {
            nowmap._mazepoint[i].Writeinfo(nowmap._mazepoint[i], i, _presentmap);
        }//키 정보를 이용하여 보여지는 맵 수정

        //골타일 흑색 처리

        nowmap._mazepoint[nowmap._goaltile].Blank(nowmap._goaltile, _presentmap);
    }

    public void Rend()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 49; j++)
            {
                switch (_presentmap[i, j]) // 길 출력
                {
                    case 1:
                        RendWall();
                        break;
                    case 2:
                        RendBlank();
                        break;
                    case 3:
                        RendPlayer();
                        break;
                    case 4:
                        RendGoal();
                        break;

                    default:
                        RendRoad();
                        break;
                }
                if (j == 48) Console.WriteLine();

            }
        }

    }

    public void RendRoad()
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

    public void RendBlank()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        "  ".Print();
        Console.ResetColor();
    }

    public void RendPlayer()
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        "  ".Print();
        Console.ResetColor();
    }

    public void RendGoal()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        "  ".Print();
        Console.ResetColor();
    }
}
