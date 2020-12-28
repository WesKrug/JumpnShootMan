using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorLook : MonoBehaviour
{
    public Transform PlayerBody;
    public float Speed = 5f;

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {  
            var script = PlayerBody.GetComponent<PlayerMovementScript>();
            script.TargetAnchor = this;
        }
    }
}
