using System;
using System.Collections.Generic;
using System.Text;

public class ScreenManager
{
    // 맵 출력과 관련된 필드와 메서드
    MapManager nowmap = new MapManager();
    Mapdata1 Tempmap = new Mapdata1();



    public void Rend() 
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < 30; i++)
        { 
            for(int j = 0; j < 49; j++)
            {
                if(Tempmap.path[i,j]==0) // 길 출력
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    "  ".Print();
                    Console.ResetColor();
                }
                else 
                { 
                    Console.BackgroundColor = ConsoleColor.Gray;
                    "  ".Print();
                    Console.ResetColor();
                }
                if(j==48) Console.WriteLine();

            }
        }
    }
}
