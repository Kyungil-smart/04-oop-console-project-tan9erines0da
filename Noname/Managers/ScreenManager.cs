using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

public class ScreenManager
{
    // 맵 출력과 관련된 필드와 메서드
    public MapManager nowmap = new MapManager();
    public int[,] _presentmap = new int[30, 49]; //보여질 맵 배열



    public ScreenManager()
    {
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 49; j++)
            {
                _presentmap[i, j] = nowmap._mapinfo.path[i, j];
            }
        }
    }
    
    public void PresentMapUpdate()
    {

        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 49; j++)
            {
                _presentmap[i, j] = nowmap._mapinfo.path[i, j];
            }
        }
        //미로 타일 배치에 따른 수정
        for (int i = 1; i <= 19; i++)
        {

            TileUpdate(i, nowmap._mazepoint[i], _presentmap, nowmap._mapinfo.path);
        }//키 정보를 이용하여 보여지는 맵 수정
                
    }

    public void TileUpdate(int key, int tilenumber, int[,] viewmap, int[,] map)
    {
        

        int x = IgniteX(key);  // 타일 순서에 따른 출력 시작점
        int y = IgniteY(key);
        int vx = IgniteX(tilenumber);  // 타일 넘버에 따른 출력 시작점
        int vy = IgniteY(tilenumber);


        if (tilenumber == 19 && !Allcomplete())
        {
            viewmap[y, x] = 2;
            for (int i = 1; i <= 5; i++)
            {
                viewmap[y + 1, x - 3 + i] = 2;
            }
            for (int i = 6; i <= 41;)
            {
                for (int j = y + 2; j <= y + 5; j++)
                {
                    for (int k = x - 4; k <= x + 4; k++)
                    {
                        viewmap[j, k] = 2;
                        i++;
                    }
                }
            }
            for (int i = 42; i <= 46; i++)
            {
                viewmap[y + 6, x - 44 + i] = 2;
            }
            viewmap[y + 7, x] = 2;
        }
        else
        {
            viewmap[y, x] = map[vy, vx];
            for (int i = 1; i <= 5; i++)

            {
                viewmap[y + 1, x - 3 + i] = map[vy + 1, vx - 3 + i];
            }

            for (int i = 6; i <= 14; i++)
            {
                viewmap[y + 2, x - 10 + i] = map[vy + 2, vx - 10 + i];
            }

            for (int i = 15; i <= 23; i++)
            {
                viewmap[y + 3, x - 19 + i] = map[vy + 3, vx - 19 + i];
            }

            for (int i = 24; i <= 32; i++)
            {
                viewmap[y + 4, x - 28 + i] = map[vy + 4, vx - 28 + i];
            }

            for (int i = 33; i <= 41; i++)
            {
                viewmap[y + 5, x - 37 + i] = map[vy + 5, vx - 37 + i];
            }

            for (int i = 42; i <= 46; i++)
            {
                viewmap[y + 6, x - 44 + i] = map[vy + 6, vx - 44 + i];
            }
            viewmap[y + 7, x] = map[vy + 7, vx];
        }
        
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
    public void Rend()
    {
        
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

    public bool Allcomplete()
    { 
        if(nowmap._mazepoint[1]==1&&
            nowmap._mazepoint[2]==2&&
            nowmap._mazepoint[3]==3&&
            nowmap._mazepoint[4] == 4 &&
            nowmap._mazepoint[5] == 5 &&
            nowmap._mazepoint[6] == 6 &&
            nowmap._mazepoint[7] == 7 &&
            nowmap._mazepoint[8] == 8 &&
            nowmap._mazepoint[9] == 9 &&
            nowmap._mazepoint[10] == 10 &&
            nowmap._mazepoint[11] == 11 &&
            nowmap._mazepoint[12] == 12 &&
            nowmap._mazepoint[13] == 13 &&
            nowmap._mazepoint[14] == 14 &&
            nowmap._mazepoint[15] == 15 &&
            nowmap._mazepoint[16] == 16 &&
            nowmap._mazepoint[17] == 17 &&
            nowmap._mazepoint[18] == 18 &&
            nowmap._mazepoint[19] == 19 )
        return true; 
        return false;
    }
}
