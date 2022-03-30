/*
 *	File: PlayerController.cs
 *	Author: foldybox
 *	Description: The script constrols player movement, animation and states.
 */

using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Get global access to one instange of Player Controller
	#region Singleton

	public static PlayerController instance = null;

	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Debug.LogWarning("More than one instance of PlayerController found!");
	}

	#endregion

	// Serialized public fields
	[SerializeField] public Transform spawn;
	[SerializeField] public float movementSpeed = 12;
	[SerializeField] public float respawnDelay = 3;
	[SerializeField] public bool isAlive = true;

	private Vector2 moveInput;
	private Vector2 moveVelocity;
	private int horizontalDirection;

	private Rigidbody2D _rigidbody;
	private Animator _animator;

	private void Start() {
		// Get own components
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	private void FixedUpdate() {
		MovementHandler();
		AnimationHandler();
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		TrapTrigger(collider);
	}

	// Control player movement
	public void MovementHandler() {
		moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		moveVelocity = moveInput.normalized * movementSpeed;

		if (isAlive) _rigidbody.MovePosition(_rigidbody.position + moveVelocity * Time.fixedDeltaTime);
	}

	// Control player animation
	public void AnimationHandler() {
		// Get horizontal direction for animations
		if ((int)Input.GetAxis("Horizontal") != 0) {
			horizontalDirection = (int)Input.GetAxis("Horizontal");
		}

		// Set animator parameters
		_animator.SetFloat("Speed", moveInput.sqrMagnitude);
		_animator.SetFloat("Direction", horizontalDirection);
	}

	// Handle player falling into a trap
	public void TrapTrigger(Collider2D collider) {
		// Check whether player contact with active trap
		if (collider.tag != "Trap" || !isAlive) return;
		if (!collider.GetComponent<Trap>().isActive) return;

		_animator.Play("Death");
		isAlive = false;
		StartCoroutine(Respawn());
	}

	// Player respawn after delay
	public IEnumerator Respawn() {
		yield return new WaitForSeconds(respawnDelay);

		isAlive = true;
		transform.position = spawn.position;
		_animator.Play("Tree");
	}
}
