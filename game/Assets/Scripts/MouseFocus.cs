using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseFocus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Vector3 newRotation = new Vector3(0, 0, 5);

        GetComponentInChildren<Text>().fontSize = 85;
        GetComponentInChildren<Text>().color = Color.grey;
        GetComponentInChildren<Text>().transform.eulerAngles = newRotation;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Vector3 newRotation = new Vector3(0, 0, 0);

        GetComponentInChildren<Text>().fontSize = 70;
        GetComponentInChildren<Text>().color = Color.white;
        GetComponentInChildren<Text>().transform.eulerAngles = newRotation;
    }
}
