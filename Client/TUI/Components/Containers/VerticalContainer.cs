using Client.TUI.Components.Containers.Interfaces;
using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components.Containers;
public class VerticalContainer
: BaseComponent,
IConteinerComponent,
IVerticalContainer
{
    public List<BaseComponent> Children { get; private set; } = [];

    public VerticalContainer(int left = 0, int top = 0)
    {
        Left = left;
        Top = top;
    }

    public void Add(BaseComponent component)
    {
        var top = Children.Count + Top;
        component.Top = top;
        component.Left = Left;
        Children.Add(component);
    }

    public void Remove(BaseComponent component)
    {
        Children.Remove(component);
    }

    public override void Render()
    {
        var count = Children.Count;
        for (int i = 0; i < count; i++)
        {
            Children[i].Render();
        }
    }

    public Task WatchModifiedAsync(Queue<IBaseComponent> queue)
    {
        return Task.Run(() =>
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].Modified)
                {
                    queue.Enqueue(Children[i]);
                    Children[i].Unmodified();
                }
            }
        });
    }

    public void WatchModified(Queue<IBaseComponent> queue)
    {
        for (int i = 0; i < Children.Count; i++)
        {
            if (Children[i].Modified)
            {
                queue.Enqueue(Children[i]);
                Children[i].Unmodified();
            }
        }
    }

    public void MoveComponentLeft(IBaseComponent component, int steps)
    {
        throw new NotImplementedException();
    }

    public void MoveComponentRight(IBaseComponent component, int steps)
    {
        throw new NotImplementedException();
    }
}
