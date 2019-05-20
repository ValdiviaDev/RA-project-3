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

            Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y) / 2;

            float scaleX = Mathf.Abs(startPos.x - endPos.x);
            float scaleY = Mathf.Abs(startPos.y - endPos.y);

            centerPos.x -= 0.5f;
            centerPos.y += 0.5f;
            gameObject.transform.position = centerPos;
            //gameObject.transform.localScale = new Vector3(scaleX, scaleY, 1);

            if (position) position.text = gameObject.transform.position.ToString();
            if (scale) scale.text = gameObject.transform.localScale.ToString();
        }
    }
}
