using TMPro;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI binaryText;

	public bool IsTicked { get ; private set; }

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

	public void PressButton()
	{
		IsTicked = !IsTicked;
		SetText(IsTicked);
	}
}
