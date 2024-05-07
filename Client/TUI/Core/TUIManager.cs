using Client.TUI.Components;
using Client.TUI.Components.Interfaces;
using Client.TUI.Core.Interceptors;

namespace Client.TUI.Core;
public class TUIManager
{
    public TUIRenderer Renderer { get; set; }
    public Thread? RenderThread { get; set; }
    public Thread? WatchModifiedThread { get; set; }
    public TextWriter OriginalOut { get; set; } = Console.Out;
    public TextReader OriginalIn { get; set; } = Console.In;
    public List<BaseComponent> Components { get; set; } = [];
    public Queue<IBaseComponentRender> ModifiedComponents { get; set; } = [];
    public int Width { get; set; }
    public int Height { get; set; }
    public int CursorLeft { get; set; }
    public int CursorTop { get; set; }

    public TUIManager(TUIRenderer renderer)
    {
        Renderer = renderer;
    }

    public void Initialize()
    {
        /* try */
        /* { */
            Console.SetOut(new WriteInterceptorBuffer());
            // NOTE: desativar o out e in do console
            /* Console.CursorVisible = false; */
            /* Console.Clear(); */
            // NOTE: não funciona no debug console
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
            CursorLeft = Console.CursorLeft;
            CursorTop = Console.CursorTop;
        /* } */
        /* catch (Exception ex) */
        /* { */
        /*     Console.SetOut(OriginalOut); */
        /*     Console.WriteLine("Não foi possível inicializar o TUIManager: " + ex.Message); */
        /* } */
    }

    public void InitializeRender()
    {
        Console.Clear();
        Console.SetOut(OriginalOut);
        for (int i = 0; i < Components.Count; i++)
        {
            Renderer.Render(Components[i]);
        }
        Console.SetOut(new WriteInterceptorBuffer());

        WatchModifiedThread = new Thread(WatchModifiedComponents);
        WatchModifiedThread.Name = "WatchModifiedThread";
        WatchModifiedThread.Start();
    }

    public void WatchModifiedComponents()
    {
        while (true)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i].Modified)
                {
                    ModifiedComponents.Enqueue(Components[i]);
                    Components[i].Unmodified();
                }
            }
            if (ModifiedComponents.Count > 0)
            {
                Console.SetOut(OriginalOut);
                while (ModifiedComponents.Count > 0)
                    Renderer.Render(ModifiedComponents.Dequeue());

                Console.SetOut(new WriteInterceptorBuffer());
            }
            /* else */
            /* { */
            /*     Thread.Sleep(16); */
            /* } */
        }
    }

    public void AddComponent(BaseComponent component)
    {
        // TODO: criar uma função para posicionar os componentes
        // NOTE: ou perguntar para o container onde ele quer que o componente seja renderizado
        if (component.Top == null)
            component.Top = 0;

        if (component.Left == null)
            component.Left = 0;

        Components.Add(component);
    }
}
