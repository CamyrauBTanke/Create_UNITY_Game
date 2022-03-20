using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonController : MonoBehaviour {
	[Header("Animation")]
	[SerializeField]
	[Range(0.0f, 1.0f)]
	public float lookAroundChance = 0.0f;

	[SerializeField]
	public string text;

	[SerializeField]
	private Transform header;

	private Animator animator;
	private CircleCollider2D triger;
	private TextMeshPro headerText;

	private Coroutine showCoroutine;
	private Coroutine hideCoroutine;

	private void Start() {
		animator = GetComponent<Animator>();

		header.GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
		header.GetComponent<MeshRenderer>().sortingOrder = 3;
		headerText = header.GetComponent<TextMeshPro>();
	}

	public void startLookAround() {
		if(Random.Range(0.0f, 1.0f) <= lookAroundChance)
			animator.Play("LookAround");
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if(hideCoroutine != null) {
				StopCoroutine(hideCoroutine);
			}
			showCoroutine = StartCoroutine(ShowHeader());
		}
	}

	private void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Player") {
			if (showCoroutine != null) {
				StopCoroutine(showCoroutine);
			}
			hideCoroutine = StartCoroutine(HideHeader());
		}
	}

	public IEnumerator ShowHeader() {
		headerText.text = "";
		headerText.color = new Color(0, 0, 0, 1);

		for (int i = 0; i < text.Length; i++) {
			headerText.text += text[i];
			yield return new WaitForSeconds(0.05f);
		}
	}

	public IEnumerator HideHeader() {
		while (headerText.text.Length > 0) {
			headerText.text = headerText.text.Remove(headerText.text.Length - 1);
			yield return new WaitForSeconds(0.05f);
		}
	}
}
