using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
	[SerializeField] private GameObject GameObject;
	[SerializeField] private Canvas Canvas;


	private GridCell[] gridCells;

	private Vector2Int GridSize = new Vector2Int(64, 64);

	public void Awake()
	{
		gridCells = new GridCell[256];

		for (int x = 0; x < GridSize.x; x++)
		{
			for (int y = 0; y < GridSize.y; y++)
			{
				Vector3Int position = new Vector3Int(x, y, 0);
				Instantiate(GameObject, position, Quaternion.identity, Canvas.transform);
			}
		}
	}
}
