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
    }
    public override void Update()
    {
        
    }
    public override void Exit() { }

    public override void Render()
    {
        ScreenManager Alleyscreen = new ScreenManager();
        Alleyscreen.Rend();  //스크린 매니저에서 편집된 렌더
    }

    public void Return() { }
}
