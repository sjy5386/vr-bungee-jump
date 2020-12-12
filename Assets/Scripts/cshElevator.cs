using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshElevator : MonoBehaviour
{
    private cshPlayerStatus cshPlayerStatus;
    private cshPointerEvent cshPointerEvent;

    public GameObject Player;
    public bool sw;
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        cshPlayerStatus = GameObject.Find("Player").GetComponent<cshPlayerStatus>();
        cshPointerEvent = GameObject.Find("Room").GetComponent<cshPointerEvent>();
        sw = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cshPlayerStatus.equipment && cshPointerEvent.sw)
        {
            sw = true;
            cshPointerEvent.enab = false;
        }
        if (sw)
        {
            if (Player.transform.position.z < transform.position.z)
            {
                Player.transform.Translate(transform.forward * 2.0f * Time.deltaTime);
            }
            if ((Player.transform.position.z >= transform.position.z) && (transform.position.y < 102.5f))
            {
                transform.Translate(transform.up * speed * Time.deltaTime);
                Player.transform.Translate(transform.up * speed * Time.deltaTime);
            }
        }
    }
}
