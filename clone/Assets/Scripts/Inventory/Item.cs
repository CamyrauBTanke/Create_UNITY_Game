using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
	new public string name = "Sample name";
	public Sprite icon = null;
	public Sprite sprite = null;
	public Sprite focusedSprite = null;
}
