using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScenaryWhenExits : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
            Destroy(other.gameObject);
    }
}
