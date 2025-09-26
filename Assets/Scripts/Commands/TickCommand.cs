using UnityEngine;

public class TickCommand : CommandBase
{
	GridCell gridCell;

	bool flippedValue;

	// Constructor
	public TickCommand(GridCell gridCell)
	{
		this.gridCell = gridCell;
	}

	public override void Execute()
	{
		// Flip and set value
		flippedValue = !gridCell.IsTicked;
		gridCell.SetTicked(flippedValue);

		Debug.Log($"New value = {flippedValue} \n Prev value = {!flippedValue}");
	}

	public override void Undo()
	{
		// Unflip value on Undo
		gridCell.SetTicked(!flippedValue);

		Debug.Log("Undo Flip");
	}
}
