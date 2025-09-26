using System.Collections.Generic;

public class Invoker
{
	private Stack<CommandBase> recordedComands = new Stack<CommandBase>();

	// Performs a command then records it
	public void ExecuteCommand(CommandBase command)
	{
		command.Execute();

		recordedComands.Push(command);
	}

	// Attempts to undo the fist command in the stack
	public void UndoPrevCommand() 
	{
		CommandBase undo = recordedComands.Pop();
		undo?.Undo();
	}
}
