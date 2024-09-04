using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseController : MonoBehaviour
{
    private MouseDownEvent _mouseDownEvent;

    private void Awake()
    {
        //MouseDownEvent
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("tap");
        }
    }
    private void OnMouseButtonDown(MouseController controller)
    {
       // controller.MouseDownEvent -= OnMouseButtonDown;

    }
}
