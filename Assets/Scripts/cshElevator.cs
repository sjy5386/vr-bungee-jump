using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshElevator : MonoBehaviour
{
    public bool sw = false;
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sw && (transform.position.y < 102.5f))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
    }
}
