using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCollider : MonoBehaviour
{

    [SerializeField] private Collider2D _pauseCollider;
    public void EnableCollider()
    {
        _pauseCollider.enabled = true;
    }
    public void DisableCollider()
    {
        _pauseCollider.enabled = false;
    }
/*    private void OnMouseDown()
    {
    }


    private void OnMouseUp()
    {
    }*/
}
