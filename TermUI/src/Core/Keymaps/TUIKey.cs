namespace TermUI.Core.Keymaps;
/// <summary>
/// Classe que representa uma tecla para configuração dos kemaps.
/// </summary>
public class TUIKey
{
    public char Key { get; set; }
    public ConsoleModifiers Modifiers { get; set; }
    public ETUIKeyStates State { get; set; }
    public Action? KeyAction { get; set; }
    public char[]? Childrens { get; set; }

    public TUIKey(
        char key,
        ConsoleModifiers modifiers,
        ETUIKeyStates state,
        Action? keyAction = null,
        char[]? childrens = null)
    {
        Key = key;
        Modifiers = modifiers;
        State = state;
        KeyAction = keyAction;
        Childrens = childrens;
    }
}
