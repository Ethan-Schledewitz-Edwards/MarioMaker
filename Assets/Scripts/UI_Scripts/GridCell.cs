using TMPro;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI binaryText;

	TickCommand tickCommand;

	public bool IsTicked { get ; private set; }

	private void Awake()
	{
		tickCommand = new TickCommand(this);
	}

	public void SetTicked(bool isTicked)
	{
		IsTicked = isTicked;
		SetText(IsTicked);
	}

	/// <summary>
	/// Updates the cells text to represent its state in binary
	/// </summary>
	public void SetText(bool isTicked)
	{
		int value = isTicked ? 1 : 0;
		string text = value.ToString();
		binaryText.text = text;
	}

	/// <summary>
	/// Executes the tick command on press
	/// </summary>
	public void PressButton()
	{
		LevelBuilder.Instance.Invoker.ExecuteCommand(tickCommand);
	}
}
