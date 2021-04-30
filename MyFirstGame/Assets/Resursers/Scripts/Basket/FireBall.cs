using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


public class FireBall : MonoBehaviour
{
    public int speed=40;
    public int damage=1000;
    public int magicStrike=2;

    //public FireBall()
    //{
    //    speed = 40;
    //    damage = 1000;
    //    magicStrike = 2;
    //}

    void Start()
    {
        //FireBall values;
        //values.FireBall();
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerHurt player = other.GetComponent<PlayerHurt>();
        if (player != null)
        {
            player.Hurt(damage,magicStrike);
        }

        ReactiveTarget Enemy = other.GetComponent<ReactiveTarget>();

        if(Enemy!= null)
        {
            Enemy.ReactToHit(damage); // Пока-что можно опустить сопротивляемость для противника
        }
        
        Destroy(this.gameObject,1.5f);
        
    }
}
