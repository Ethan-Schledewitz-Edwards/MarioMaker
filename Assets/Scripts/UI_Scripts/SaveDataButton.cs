using UnityEngine;

public class SaveDataButton : MonoBehaviour
{
   public void PressButton()
	{
		LevelBuilder.Instance.SaveData();
	}
}
