using Client.TUI.Components.Containers.Interfaces;
using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components.Containers;
public class HorizontalContainer
: BaseContainer,
IConteinerComponent
{
    public List<BaseComponent> Children { get; private set; } = [];

    public HorizontalContainer(int left = 0, int top = 0)
    {
        Left = left;
        Top = top;
    }

    public void Add(BaseComponent component)
    {
        var left = Children.Count;
        component.Left = left;
        component.Top = Top;
        Children.Add(component);
    }

    public void Remove(BaseComponent component)
    {
        throw new NotImplementedException();
    }

    public override void Render()
    {
        var count = Children.Count;
        for (int i = 0; i < count; i++)
        {
            Children[i].Render();
        }
    }

    public void WatchModified(Queue<IBaseComponentRender> queue)
    {
        throw new NotImplementedException();
    }

    public Task WatchModifiedAsync(Queue<IBaseComponentRender> queue)
    {
        throw new NotImplementedException();
    }
}
