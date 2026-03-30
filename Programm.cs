public interface IButton
{
    public void render();
    public void onClick(); 
}

public class WindowsButton : IButton
{
    public void render()
    {
        Console.WriteLine("Render WindowsButton");
    }

    public void onClick()
    {
        Console.WriteLine("onClick WindowsButton");
    }
} 

public class HTMLButton : IButton
{
    public void render()
    {
        Console.WriteLine("Render HTMLButton");
    }

    public void onClick()
    {
        Console.WriteLine("onClick HTMLButton");
    }
}

public abstract class Dialog
{
    public abstract IButton createButton(); 

    public void render()
    {
        var button = createButton();
        button.render();
    }
}

public class  WindowsDialog : Dialog
{
    public override IButton createButton() => new WindowsButton(); 
}

public class WebDialog : Dialog
{
    public override IButton createButton() => new HTMLButton();
} 

class UnitTests
{
    public UnitTests()
    {
        IButton htmlButton = new HTMLButton();
        IButton windowsButton = new WindowsButton();

        Dialog dialogWin = new WindowsDialog();
        Dialog dialogWeb = new WebDialog();

        dialogWin.createButton().render();
        dialogWin.createButton().onClick();
        dialogWeb.createButton().render();
        dialogWeb.createButton().onClick();


        htmlButton.render();
        htmlButton.onClick();
        windowsButton.render();
        windowsButton.onClick(); 
    }
}

public class Application
{
    public static void Main(string[] args)
    {
        UnitTests unitTests = new UnitTests(); 
    }
}
