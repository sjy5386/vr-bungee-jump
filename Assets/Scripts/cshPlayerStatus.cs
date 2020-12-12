using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerStatus : MonoBehaviour
{
    public bool equipment;

    private cshPointerEvent equipmentPointerEvent;
    private cshPointerEvent elevatorPointEvent;

    // Start is called before the first frame update
    void Start()
    {
        equipment = false;
        equipmentPointerEvent = GameObject.Find("Building").GetComponent<cshPointerEvent>();
        elevatorPointEvent = GameObject.Find("Room").GetComponent<cshPointerEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (equipmentPointerEvent.sw)
        {
            equipment = true;
            equipmentPointerEvent.enab = false;
            elevatorPointEvent.enab = true;
        }
    }
}
