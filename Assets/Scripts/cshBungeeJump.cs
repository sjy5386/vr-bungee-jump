using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBungeeJump : MonoBehaviour
{
    private bool sw = false;
    private int remains = 2;
    private float minX = -10.0f;
    private float maxX = 10.0f;
    private float minZ = 40.0f;
    private float maxZ = 60.0f;
    private float speedXZ = 9.8f;
    private float nextSpeedXZ = 0.7f;
    private int directionXZ;
    private float[] minY = new float[] { 10.0f, 20.0f };
    private float[] maxY = new float[] { 90.0f, 80.0f };
    private float speedY = 98.0f;
    private float nextSpeedY = 0.5f;
    private bool directionY = false;

    public GameObject Boat;
    private cshPointerEvent cshPointerEvent;

    // Start is called before the first frame update
    void Start()
    {
        directionXZ = Random.Range(0, 3);
        cshPointerEvent = GameObject.Find("Switch").GetComponent<cshPointerEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cshPointerEvent.sw)
        {
            sw = true;
        }
        if (sw)
        {
            if (remains > 0)
            {
                if (directionY)
                {
                    if (transform.position.y < maxY[remains - 1])
                    {
                        transform.Translate(transform.up * speedY * Time.deltaTime);
                    }
                    else
                    {
                        directionY = false;
                        remains--;
                    }
                }
                else
                {
                    if (transform.position.y > minY[remains - 1])
                    {
                        transform.Translate(transform.up * -speedY * Time.deltaTime);
                    }
                    else
                    {
                        speedY *= nextSpeedY;
                        directionY = true;
                    }
                }
            }
            else if (transform.position.y > 20.0f)
            {
                if (checkValue(directionXZ, 1))
                {
                    if (transform.position.x < maxX)
                    {
                        transform.Translate(transform.right * speedXZ * Time.deltaTime);
                    }
                    else
                    {
                        directionXZ = directionXZ ^ 1;
                        speedXZ *= nextSpeedXZ;
                    }
                }
                else
                {
                    if (transform.position.x > minX)
                    {
                        transform.Translate(transform.right * -speedXZ * Time.deltaTime);
                    }
                    else
                    {
                        directionXZ = directionXZ | 1;
                        speedXZ *= nextSpeedXZ;
                    }
                }
                if (checkValue(directionXZ, 2))
                {
                    if (transform.position.z < maxZ)
                    {
                        transform.Translate(transform.forward * speedXZ * Time.deltaTime);
                    }
                    else
                    {
                        directionXZ = directionXZ ^ 2;
                        speedXZ *= nextSpeedXZ;
                    }
                }
                else
                {
                    if (transform.position.z > minZ)
                    {
                        transform.Translate(transform.forward * -speedXZ * Time.deltaTime);
                    }
                    else
                    {
                        directionXZ = directionXZ | 2;
                        speedXZ *= nextSpeedXZ;
                    }
                }
                transform.Translate(transform.up * -9.8f * Time.deltaTime);
            }
            else if (transform.position.y > 3)
            {
                transform.Translate(transform.up * -4.9f * Time.deltaTime);
                Boat.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            else
            {
                sw = false;
            }
        }
    }
    private bool checkValue(int values, int value)
    {
        return (values & value) == value;
    }
}
