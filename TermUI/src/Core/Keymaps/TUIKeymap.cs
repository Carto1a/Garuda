namespace TermUI.Core.Keymaps;
public class TUIKeymap
{
    // <C-w>lrl
    private string Keys { get; set; }
    private Action Action { get; set; }
    private string Description { get; set; }
    private bool CanCount { get; set; } = false;
    private bool CanObject { get; set; } = false;

    public TUIKeymap(string keys, Action action)
    {
        Keys = keys;
        Action = action;
    }

    public TUIKeymap() { }

    /// <summary>
    /// Define a ação a ser executada.
    /// </summary>
    /// <param name="action">Ação a ser executada.</param>
    /// <returns>Retorna a instância atual.</returns>
    public TUIKeymap SetAction(Action action)
    {
        Action = action;
        return this;
    }

    public TUIKeymap SetKeys(string keys)
    {
        Keys = keys;
        return this;
    }

    public TUIKeymap SetDescription(string description)
    {
        Description = description;
        return this;
    }

    public TUIKeymap SetModifiers(bool canCount, bool canObject)
    {
        CanCount = canCount;
        CanObject = canObject;
        return this;
    }

    public void Build()
    { }
}
