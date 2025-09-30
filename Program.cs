using System;

public interface IUIElement
{
    string Render();
}

public interface IButton : IUIElement { }
public interface ICheckbox : IUIElement { }
public interface ITextBox : IUIElement { }

public enum Theme
{
    Light, 
    Dark  
}

public abstract class ThemedElement : IUIElement
{
    protected Theme Theme { get; }
    protected string Name { get; }

    protected ThemedElement(string name, Theme theme)
    {
        Name = name;
        Theme = theme;
    }

    public abstract string Render();
}

public class AndroidButton : ThemedElement, IButton
{
    public AndroidButton(Theme theme) : base("Кнопка Android", theme) { }
    public override string Render() => $"[Android][{Theme}] {Name}";
}

public class AndroidCheckbox : ThemedElement, ICheckbox
{
    public AndroidCheckbox(Theme theme) : base("Чекбокс Android", theme) { }
    public override string Render() => $"[Android][{Theme}] {Name}";
}

public class AndroidTextBox : ThemedElement, ITextBox
{
    public AndroidTextBox(Theme theme) : base("Текстовое поле Android", theme) { }
    public override string Render() => $"[Android][{Theme}] {Name}";
}

public class IosButton : ThemedElement, IButton
{
    public IosButton(Theme theme) : base("Кнопка iOS", theme) { }
    public override string Render() => $"[iOS][{Theme}] {Name}";
}

public class IosCheckbox : ThemedElement, ICheckbox
{
    public IosCheckbox(Theme theme) : base("Чекбокс iOS", theme) { }
    public override string Render() => $"[iOS][{Theme}] {Name}";
}

public class IosTextBox : ThemedElement, ITextBox
{
    public IosTextBox(Theme theme) : base("Текстовое поле iOS", theme) { }
    public override string Render() => $"[iOS][{Theme}] {Name}";
}

public abstract class UIComponentFactory
{
    protected Theme Theme { get; }

    protected UIComponentFactory(Theme theme)
    {
        Theme = theme;
    }


    public abstract IButton CreateButton();
    public abstract ICheckbox CreateCheckbox();
    public abstract ITextBox CreateTextBox();
}
public class AndroidUIFactory : UIComponentFactory
{
    public AndroidUIFactory(Theme theme) : base(theme) { }

    public override IButton CreateButton() => new AndroidButton(Theme);
    public override ICheckbox CreateCheckbox() => new AndroidCheckbox(Theme);
    public override ITextBox CreateTextBox() => new AndroidTextBox(Theme);
}

public class IosUIFactory : UIComponentFactory
{
    public IosUIFactory(Theme theme) : base(theme) { }

    public override IButton CreateButton() => new IosButton(Theme);
    public override ICheckbox CreateCheckbox() => new IosCheckbox(Theme);
    public override ITextBox CreateTextBox() => new IosTextBox(Theme);
}

public class CrossPlatformApp
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;
    private readonly ITextBox _textBox;

    public CrossPlatformApp(UIComponentFactory factory)
    {
        _button = factory.CreateButton();     
        _checkbox = factory.CreateCheckbox(); 
        _textBox = factory.CreateTextBox(); 
    }

    public void ShowUI()
    {
        Console.WriteLine("Отображение интерфейса:");
        Console.WriteLine(_button.Render());
        Console.WriteLine(_checkbox.Render());
        Console.WriteLine(_textBox.Render());
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Android-приложение (Светлая тема):");
        var androidLightFactory = new AndroidUIFactory(Theme.Light);
        var androidApp = new CrossPlatformApp(androidLightFactory);
        androidApp.ShowUI();

        Console.WriteLine("2. iOS-приложение (Тёмная тема):");
        var iosDarkFactory = new IosUIFactory(Theme.Dark);
        var iosApp = new CrossPlatformApp(iosDarkFactory);
        iosApp.ShowUI();
    }
}