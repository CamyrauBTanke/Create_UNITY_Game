/*
 *	File: Trap.cs
 *	Author: foldybox
 *	Description: The script constrols trap state.
 */

using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour {
	// Serialized public fields
	[SerializeField] public bool isActive = true;
	[SerializeField, Min(0)] private int switchTime = 0;
	[Header("Sprites")]
	[SerializeField] public Sprite activeSprite;
	[SerializeField] public Sprite inactiveSprite;

	private SpriteRenderer _spriteRenderer;
	private BoxCollider2D _boxCollider;

	private void Start() {
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_boxCollider = GetComponent<BoxCollider2D>();

		StartCoroutine(Switcher());
	}

	// Switch trap state
	public IEnumerator Switcher() {
		while (true) {
			if (switchTime > 0) {
				yield return new WaitForSeconds(switchTime);
				isActive = !isActive;

				if (isActive) {
					_spriteRenderer.sprite = activeSprite;
					_boxCollider.enabled = true;
				}
				else {
					_spriteRenderer.sprite = inactiveSprite;
					_boxCollider.enabled = false;
				}
			}
			else {
				yield return null;
			}
		}
	}
}
