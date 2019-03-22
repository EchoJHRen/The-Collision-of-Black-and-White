using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Mouse : MonoBehaviour
{
    public GameObject obj;
    private int clickCount = 0;

    private void OnMouseDown()
    {
        clickCount++;
        if (clickCount % 2 == 1)
            obj.GetComponent<CanvasGroup>().alpha = 1;
        else if (clickCount % 2 == 0)
            obj.GetComponent<CanvasGroup>().alpha = 0;
    }


}
