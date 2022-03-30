using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseFocus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool condition = true;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(condition == true){
            Vector3 newRotation = new Vector3(0, 0, 5);

            GetComponentInChildren<Text>().fontSize = 85;
            GetComponentInChildren<Text>().color = Color.grey;
            GetComponentInChildren<Text>().transform.eulerAngles = newRotation;
            condition = false;
        }
        else
            condition = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if(condition == false){
            Vector3 newRotation = new Vector3(0, 0, 0);

            GetComponentInChildren<Text>().fontSize = 70;
            GetComponentInChildren<Text>().color = Color.white;
            GetComponentInChildren<Text>().transform.eulerAngles = newRotation;
            condition = true;
        }
        else
            condition = false;
    }

    public void OnPointerDown(PointerEventData pointerEventData){
        GetComponentInChildren<Text>().color = Color.black;
    }

    public void OnPointerUp(PointerEventData eventData){
        condition = true;
        GetComponentInChildren<Text>().color = Color.grey;
    }
}
