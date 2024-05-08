using Client.TUI.Components;
using Client.TUI.Components.Interfaces;

namespace Client.TUI.Core;
public class TUIRenderer
{
    public Thread? RenderThread { get; set; }

    public void UpdateComponents(List<BaseComponent> components)
    {
    }

    public void Render(IBaseComponentRender component)
    {
        component.Render();
    }

    public void RenderList(List<BaseComponent> components)
    {
        for (int i = 0; i < components.Count; i++)
        {
            Render(components[i]);
        }
    }

    public void RenderQueue(Queue<IBaseComponentRender> components)
    {
        while (components.Count > 0)
            Render(components.Dequeue());
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
