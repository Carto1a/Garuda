using Client.TUI.Components;
using Client.TUI.Components.Interfaces;

namespace Client.TUI.Core;
public class TUIRenderer
{
    public Thread? RenderThread { get; set; }
    public List<IBaseComponentRender> Components { get; set; } = [];

    public void UpdateComponents(List<BaseComponent> components)
    {
    }

    public void Render(IBaseComponentRender component)
    {
        component.Render();
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
