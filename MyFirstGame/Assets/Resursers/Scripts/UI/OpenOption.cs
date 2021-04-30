using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOption : MonoBehaviour
{
    // Start is called before the first frame update
    public void Open()
    {
        Transform[] all = GetComponentsInChildren<Transform>();

        foreach (Transform one in all)
        {
            one.gameObject.SetActive(true);
        }
       

    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
