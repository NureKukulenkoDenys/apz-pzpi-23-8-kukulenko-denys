using System;

public interface ICommand
{
    void Execute();
}

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Світло увімкнено");
    }
}


public class TurnOnLightCommand : ICommand
{
    private Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}


class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    // Виклик команди 
    public void PressButton()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Light light = new Light();

        ICommand command = new TurnOnLightCommand(light);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(command);

        remote.PressButton();
    }
}
