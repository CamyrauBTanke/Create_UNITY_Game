using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InteractableObject : MonoBehaviour {
	[Header("Interactable Object")]
	[SerializeField] public float interractRadius = 1.5f;
	[SerializeField] public bool isFocused = false;
	[SerializeField] public bool isActivated = false;

	private CircleCollider2D trigger;

	private void Start() {
		trigger = GetComponent<CircleCollider2D>();
		trigger.isTrigger = true;
		trigger.radius = interractRadius;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.F) && isFocused) {
			isActivated = true;
			Interact();
		}
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag != "Player") return;

		isFocused = true;

		OnFocusEnter();
	}

	private void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag != "Player") return;

		isFocused = false;
		isActivated = false;

		OnFocusExit();
	}

	public virtual void Interact() {
		Debug.Log("Interacting with " + transform.name);
	}

	public virtual void OnFocusEnter() { }

	public virtual void OnFocusExit() { }
}
