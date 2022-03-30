using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour {

    void Start() {
		GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
		GetComponent<MeshRenderer>().sortingOrder = 3;
		GetComponent<TextMeshPro>().text = "zhopa";
    }
}
