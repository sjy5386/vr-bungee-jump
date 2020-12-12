using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshElevator : MonoBehaviour
{
    private cshPointerEvent cshPointerEvent;
    public bool sw = false;
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        cshPointerEvent = GameObject.Find("Room").GetComponent<cshPointerEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cshPointerEvent.sw)
        {
            sw = true;
        }
        if (sw && (transform.position.y < 102.5f))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
    }
}
