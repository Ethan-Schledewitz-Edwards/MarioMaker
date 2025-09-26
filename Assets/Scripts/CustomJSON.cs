using System.Collections.Generic;
using UnityEngine;

// This is a custom wrapper to serialize data from  lists and arrays
public class CustomJSON
{
	public static List<T> FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.items;
	}

	public static string ToJson<T>(List<T> list)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.items = list;
		return JsonUtility.ToJson(wrapper);
	}

	[System.Serializable]
	public class Wrapper<T>
	{
		public List<T> items;
	}
}
