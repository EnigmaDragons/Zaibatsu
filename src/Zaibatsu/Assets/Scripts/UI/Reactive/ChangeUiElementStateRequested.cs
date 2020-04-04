
public class ChangeUiElementStateRequested
{
    public GameUiElement Element { get; }
    public UiCommand Command { get; }

    public ChangeUiElementStateRequested(GameUiElement element, UiCommand command)
    {
        Element = element;
        Command = command;
    }
}