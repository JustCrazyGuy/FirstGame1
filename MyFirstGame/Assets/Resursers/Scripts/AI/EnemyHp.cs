using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private GameObject healthEnemy;
    [SerializeField] private Text hpEnemyBar;
    [SerializeField] private GameObject Health;

    private int key = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //транслирование хп противника игроку на интерфейс
        key = Health.GetComponent<ReactiveTarget>().GetHp();
        hpEnemyBar.text = key.ToString() + "/10000"; //Time.realtimeSinceStartup.ToString();
    }
}
