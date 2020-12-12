using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshPointerEvent : MonoBehaviour
{
    public Image LoadingBar;
    private bool gazedAt;
    private float barTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gazedAt = false;
        LoadingBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            if (barTime <= 5.0f)
            {
                barTime += Time.deltaTime;
            }
            LoadingBar.fillAmount = barTime / 5.0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
        barTime = 0.0f;
        if (gazedAt)
        {
            Debug.Log("In");
        }
        else
        {
            Debug.Log("Out");
            LoadingBar.fillAmount = 0;
        }
    }
}
