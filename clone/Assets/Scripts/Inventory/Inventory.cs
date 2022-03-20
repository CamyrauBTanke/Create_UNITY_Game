using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance = null;

	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Debug.LogWarning("More than one instance of Inventory found!");
	}

	#endregion

	[SerializeField]
	public List<Item> items = new List<Item>();

	public void AddItem(Item item) {
		items.Add(item);
	}

	public void RemoveItem(Item item) {
		items.Remove(item);
	}
}
