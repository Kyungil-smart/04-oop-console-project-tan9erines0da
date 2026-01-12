using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "슬라이드 퍼즐과 미로 탐색";
    // private PlayerCharacter _player;

    public void Run()
    {
        Init();

        while (!IsGameOver)
        {
            // 렌더링
            Console.Clear();
            SceneManager.Render();
            // 키입력 받고
            InputManager.GetUserInput();

            if (InputManager.GetKey(ConsoleKey.L))
            {
                SceneManager.Change("Log");
            }

            // 데이터 처리
            SceneManager.Update();
        }
    }

    private void Init()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        // _player = new PlayerCharacter();

        SceneManager.AddScene("Title", new TitleScene());

        SceneManager.Change("Title");

    }
}