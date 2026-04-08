using System;

// Інтерфейс команди — визначає єдиний метод Execute()
public interface ICommand
{
    void Execute();
}

// Receiver — клас, який виконує реальну бізнес-логіку
public class Light
{
    // Метод увімкнення світла
    public void TurnOn()
    {
        Console.WriteLine("Світло увімкнено");
    }
}

// ConcreteCommand — конкретна команда
// Реалізує інтерфейс ICommand
public class TurnOnLightCommand : ICommand
{
    // Посилання на Receiver 
    private Light _light;

    // Конструктор приймає Receiver 
    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    // Метод Execute викликається Invoker'ом
    public void Execute()
    {
        _light.TurnOn();
    }
}

// Invoker — клас, який ініціює виконання команди
class RemoteControl
{
    // Посилання на команду через інтерфейс
    private ICommand _command;

    // Метод для встановлення команди
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

// Client — точка входу в програму
class Program
{
    static void Main()
    {
        // Створюємо Receiver
        Light light = new Light();

        // Створюємо команду і передаємо в неї Receiver
        ICommand command = new TurnOnLightCommand(light);

        // Створюємо Invoker
        RemoteControl remote = new RemoteControl();

        // Передаємо команду в Invoker
        remote.SetCommand(command);

        // Викликаємо команду 
        remote.PressButton();
    }
}
