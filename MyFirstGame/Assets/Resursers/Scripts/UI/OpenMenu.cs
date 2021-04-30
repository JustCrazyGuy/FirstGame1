using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        //if (gameObject.activeSelf == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        Close();
        //    }
        //}
        //else if (gameObject.activeSelf == false)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        Open();
        //    }
        //}

}
    public void Open()
    {
        gameObject.SetActive(true);
  

    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    
}