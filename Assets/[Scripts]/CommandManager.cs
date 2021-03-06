using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICommand
{
    void Execute();
    void Undo();
}


public class CommandManager : MonoBehaviour
{
    public static CommandManager Instance { get; private set; }

    private Stack<ICommand> _commands = new Stack<ICommand>();

    private void Awake()
    {
        Instance = this;
    }


    public void Execute(ICommand command)
    {
        command.Execute();
        _commands.Push(command);
    }

    public void ExecuteWithoutSave(ICommand command)
    {
        command.Execute();
    }

    public void Undo()
    {
        if (_commands.Count > 0)
        { 
            _commands.Pop().Undo();
        }
    }
}
