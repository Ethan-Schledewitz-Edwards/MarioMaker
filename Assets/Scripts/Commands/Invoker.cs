using System;
using System.Collections.Generic;

public class Invoker
{
	public Stack<CommandBase> RecordedComands { get; private set; } = new Stack<CommandBase>();

	public Action OnCommandExecuted;
	public Action OnCommandUndo;

	// Performs a command then records it
	public void ExecuteCommand(CommandBase command)
	{
		// Execute & record command
		command.Execute();
		RecordedComands.Push(command);

		OnCommandExecuted?.Invoke();
	}

	// Attempts to undo the fist command in the stack
	public void UndoPrevCommand() 
	{
		// Undo prev command
		CommandBase undo = RecordedComands.Pop();
		undo?.Undo();

		OnCommandUndo?.Invoke();
	}
}
