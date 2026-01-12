using System;
using System.Collections.Generic;
using System.Text;

public class StageSelectScene : Scene
{
    private MenuList _stageselectmenu;

    public StageSelectScene()
    {
        _stageselectmenu = new MenuList();
        _stageselectmenu.Add("골목길", AlleyStage);
        _stageselectmenu.Add("숲", ForestStage);
        _stageselectmenu.Add("화산", CalderaStage);
    }

    public override void Enter()
    {
        _stageselectmenu.Reset();
        SceneManager.AddScene("AlleyStage", new AlleyScene());

    }
    public override void Exit() { }
    public override void Update() 
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _stageselectmenu.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _stageselectmenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _stageselectmenu.Select();
        }
    }

    public override void Render()
    {
        Console.SetCursorPosition(5, 1);
        GameManager.GameName.Print(ConsoleColor.Yellow);

        _stageselectmenu.Render(8, 5);
    }

    public void AlleyStage() 
    {
        SceneManager.Change("AlleyStage");
    }
    public void ForestStage() { }
    public void CalderaStage() { }
}
