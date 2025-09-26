using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
	// Singleton
	public static LevelBuilder Instance;

	// Save path
	private string filePath;

	// Prefab
	[SerializeField] private GridCell gridCellPrefab;

	// Canvas
	[SerializeField] private GameObject Holder;
	[SerializeField] private Vector2Int GridSize = new Vector2Int(8, 8);

	// System vars
	private GridCell[] gridCells;

	public void Awake()
	{
		Instance = this;

		// Build folder path 
		#if UNITY_EDITOR
			string buildFolderPath = Path.Combine(Application.dataPath, "../Build");
		#else
			string buildFolderPath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
		#endif

		filePath = Path.Combine(buildFolderPath, "TileData.txt");

		// Create cells that are auto sorted by grid layout component
		gridCells = new GridCell[GridSize.x * GridSize.y];
		for (int i = 0; i < gridCells.Length; i++) 
		{
			GridCell cell = Instantiate(gridCellPrefab, Vector3.zero, Quaternion.identity, Holder.transform);
			gridCells[i] = cell;
		}
	}

	private void Start()
	{
		Debug.Log(filePath);

		LoadData();
	}

	/// <summary>
	/// Saves all tile data to a txt file in the build folder
	/// </summary>
	public void SaveData()
	{
		List<ButtonData> itemProfilesToSave = new List<ButtonData>();

		for (int i = 0; i < gridCells.Length; i++)
		{
			GridCell cell = gridCells[i];
			itemProfilesToSave.Add(new ButtonData(cell.IsTicked));
		}

		string saveData = CustomJSON.ToJson(itemProfilesToSave);
		File.WriteAllText(filePath, saveData);

		Debug.Log("Data saved to " + filePath);
	}

	/// <summary>
	/// Saves all tile data to a txt file in the build folder
	/// </summary>
	public void LoadData()
	{
		if (File.Exists(filePath))
		{
			string json = File.ReadAllText(filePath);
			List<ButtonData> buttonData = CustomJSON.FromJson<ButtonData>(json);

			// Reconstruct data
			for (int i = 0; i < buttonData.Count && i < gridCells.Length; i++)
			{
				GridCell cell = gridCells[i];
				cell.SetTicked(buttonData[i].Value);
			}

			Debug.Log("Data loaded from " + filePath);
		}
		else
		{
			Debug.Log("No save file found at " + filePath);
		}
	}
}
