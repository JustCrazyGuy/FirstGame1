using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text hpPlayerBar;
    [SerializeField] private OpenMenu _OpenMenu;
    //[SerializeField] private PlayerCharacter HP;

    [SerializeField] private GameObject Health;

    private int key = 0;
    void Start()
    {
        //_OpenMenu.Close();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Трансляция ХП игрока на интерфейс внизу
      key = Health.GetComponent<PlayerHurt>().gethealth();
        hpPlayerBar.text = key.ToString() + "/10000"; //Time.realtimeSinceStartup.ToString();
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    public void OnOpenSettings()
    {
        _OpenMenu.Open();
    }
    public void CloseSettings()
    {
        _OpenMenu.Close();
    }
}
