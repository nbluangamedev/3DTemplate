using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRaycast : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Ignore Raycast")))
        {
            other.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
