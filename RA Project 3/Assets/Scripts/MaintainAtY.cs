using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaintainAtY : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
