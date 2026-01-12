using System;
using System.Collections.Generic;
using System.Text;

public class TitleScene : Scene
{
    private MenuList _titleMenu;


    public TitleScene() 
    { 
        _titleMenu = new MenuList();
        _titleMenu.Add("게임 시작", GameStart);
        _titleMenu.Add("게임 정보", GameInfo);
        _titleMenu.Add("게임 종료", GameQuit);
    }
    public override void Enter()
    {
        _titleMenu.Reset();
        SceneManager.AddScene("StageSelect", new StageSelectScene());

    }
    public override void Update() 
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _titleMenu.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _titleMenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _titleMenu.Select();
        }
    }
    public override void Exit() 
    {
        
    }
    

    public override void Render()
    {

        Console.SetCursorPosition(5, 1);
        GameManager.GameName.Print(ConsoleColor.Yellow);

        _titleMenu.Render(8, 5); 
    }

    public void GameQuit()
    {
        GameManager.IsGameOver = true;
    }

    public void GameStart()
    {
        SceneManager.Change("StageSelect");
    }

    public void GameInfo()
    {
    }
}
