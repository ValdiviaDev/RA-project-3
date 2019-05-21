using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScale : MonoBehaviour
{

    public GameObject point1 = null;
    public GameObject point2 = null;
    public Text position = null;
    public Text scale = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (point1 && point2 && gameObject.activeInHierarchy)
        {
            Vector3 startPos = point1.transform.position;
            Vector3 endPos = point2.transform.position;

            Vector3 centerPos = new Vector3(endPos.x, 0f, endPos.z) / 2f;

            gameObject.transform.position = centerPos;
            //gameObject.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);

            if (position) position.text = "Scenary position " + gameObject.transform.position.ToString();
            if (scale) scale.text = "Scenary scale " + gameObject.transform.localScale.ToString();
        }
    }
}
