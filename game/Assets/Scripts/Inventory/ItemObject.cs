/*
 *	File: Trap.cs
 *	Author: foldybox
 *	Description: The script constrols item object.
 */

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemObject : InteractableObject {
	// Serialized public fields
	[Header("Item Object")]
	[SerializeField] public Item item;

	private SpriteRenderer _spriteRenderer;

	private void Start() {
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.sprite = item.sprite;
	}

	public override void Interact() {
		PickUp();
	}

	public override void OnFocusEnter() {
		_spriteRenderer.sprite = item.focusedSprite;
	}

	public override void OnFocusExit() {
		_spriteRenderer.sprite = item.sprite;
	}

	private void PickUp() {
		Inventory.instance.AddItem(item);
		Destroy(gameObject);
	}
}
