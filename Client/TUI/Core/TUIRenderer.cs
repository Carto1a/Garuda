using Client.TUI.Components;
using Client.TUI.Components.Interfaces;

namespace Client.TUI.Core;
public class TUIRenderer
{
    public int Width { get; set; }
    public int Height { get; set; }

    public void UpdateComponents(List<BaseComponent> components)
    {
    }

    private void BaseRender(IBaseComponentRender component)
    {
        /* if (component. ) */
        component.Render();
    }

    public void Render(List<BaseComponent> components)
    {
        UpdateSize();
        for (int i = 0; i < components.Count; i++)
        {
            BaseRender(components[i]);
        }
    }

    public void Render(Queue<IBaseComponentRender> components)
    {
        UpdateSize();
        while (components.Count > 0)
            BaseRender(components.Dequeue());
    }

    public void UpdateSize()
    {
        Width = Console.WindowWidth;
        Height = Console.WindowHeight;
    }

    /* private void MainRender() */
    /* { */
    /*     /1* Console.Write("Renderizando\r"); *1/ */
    /*     while (true) */
    /*     { */
    /*         Console.Write("Renderizando\r"); */
    /*         Thread.Sleep(1000); */
    /*     } */
    /* } */
}
