using System.Diagnostics;
using Client.TUI.Components;
using Client.TUI.Components.Containers;
using Client.TUI.Components.Containers.Interfaces;
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
    public TextComponent? ExecuteTimeRender { get; set; }
    public TextComponent? ExecuteTimeWatch { get; set; }
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
        try
        {
            // NOTE: desativar o out e in do console
            Console.SetOut(new WriteInterceptorBuffer());

            /* Console.CursorVisible = false; */

            // NOTE: não funciona no debug console
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
            CursorLeft = Console.CursorLeft;
            CursorTop = Console.CursorTop;
        }
        catch (Exception ex)
        {
            Console.SetOut(OriginalOut);
            Console.WriteLine("Não foi possível inicializar o TUIManager: " + ex.Message);
        }
    }

    public void SetRenderCursor()
    {
        Console.SetOut(OriginalOut);
        Console.CursorVisible = false;
    }

    public void UnsetRenderCursor()
    {
        Console.SetOut(new WriteInterceptorBuffer());
        Console.CursorVisible = true;
        Console.SetCursorPosition(CursorLeft, CursorTop);
    }

    public void InitializeRender()
    {
        Console.Clear();

        SetRenderCursor();
        Renderer.RenderList(Components);
        UnsetRenderCursor();

        WatchModifiedThread = new Thread(WatchModifiedComponents);
        WatchModifiedThread.Name = "WatchModifiedThread";
        WatchModifiedThread.Start();
    }

    public void InitializeDebug(
        TextComponent? executeTimeRender = null,
        TextComponent? executeTimeWatch = null)
    {
        ExecuteTimeRender = executeTimeRender;
        ExecuteTimeWatch = executeTimeWatch;
    }

    public void WatchModifiedComponents()
    {
        while (true)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < Components.Count; i++)
            {
                var component = (BaseComponent)Components[i];
                if (typeof(IConteinerComponent)
                    .IsInstanceOfType(component))
                {
                    var container = (IConteinerComponent)component;
                    container.WatchModified(ModifiedComponents);
                }
                else if (component.Modified)
                {
                    ModifiedComponents.Enqueue(component);
                    component.Unmodified();
                }
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            if (ExecuteTimeRender != null)
            {
                ExecuteTimeRender.Text = $"Tempo de execução do WatchModified: {elapsedMs}ms";
            }

            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            if (ModifiedComponents.Count > 0)
            {
                SetRenderCursor();
                Renderer.RenderQueue(ModifiedComponents);
                UnsetRenderCursor();
            }

            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedTicks;
            if (ExecuteTimeWatch != null)
            {
                ExecuteTimeWatch.Text =
                    $"Tempo de execução do RenderQueue: {elapsedMs1}ns";
            }

            // NOTE: sleep to smooth the cursor blinking
            Thread.Sleep(1);
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
