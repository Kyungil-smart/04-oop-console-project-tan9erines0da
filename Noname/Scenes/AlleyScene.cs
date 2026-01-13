using System;
using System.Collections.Generic;
using System.Text;

public class AlleyScene : Scene
{
    private MenuList _pausemenu;
    private ScreenManager Alleyscreen = new ScreenManager();

    public AlleyScene()
    {
        _pausemenu = new MenuList();
        _pausemenu.Add("계속하기", Return);
        _pausemenu.Add("메뉴로 돌아가기", Exit);
        Mapdata1 alleyMap = new Mapdata1();

    }
    public override void Enter() 
    {
        
        Alleyscreen.PresentMapUpdate();
        //타일 생성
    }
    public override void Update()
    {
        
        //키입력 반응
        if (InputManager.GetKey(ConsoleKey.W))
        {
            Alleyscreen.nowmap.MoveW();
        }
        if (InputManager.GetKey(ConsoleKey.E))
        {
            Alleyscreen.nowmap.MoveE();
        }
        if (InputManager.GetKey(ConsoleKey.A))
        {
            Alleyscreen.nowmap.MoveA();
        }
        if (InputManager.GetKey(ConsoleKey.D))
        {
            Alleyscreen.nowmap.MoveD();
        }
        if (InputManager.GetKey(ConsoleKey.Z))
        {
            Alleyscreen.nowmap.MoveZ();
        }
        if (InputManager.GetKey(ConsoleKey.X))
        {
            Alleyscreen.nowmap.MoveX();
        }
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            Alleyscreen.nowmap.PlayerMoveUp();
        }
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            Alleyscreen.nowmap.PlayerMoveDown();
        }
        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Alleyscreen.nowmap.PlayerMoveLeft();
        }
        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Alleyscreen.nowmap.PlayerMoveRight();
        }

    }
    public override void Exit() { }

    public override void Render()
    {
        Alleyscreen.PresentMapUpdate();
        Alleyscreen.Rend();  //스크린 매니저에서 편집된 렌더
    }

    public void Return() { }
}
