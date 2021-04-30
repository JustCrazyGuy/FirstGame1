using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
//using System.Media;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//надо бы сделать к каждому скрипту namespace,Но в данном проекте я думаю это возможно опустить

//Здесь есть наличие так называемого легаси кода(Мне он очень не нравится в этом виде)
//Делал уже перед дедлайном,так что пришлось немного забить на красоту и правильную структуру

public class WanderingAI : MonoBehaviour
{
    public float speed = 10.0f;
    public float obstacleRange = 30.0f;
    private int stateKey;
    private int count = 0;

    public bool _move;
    public bool _move2;
    float waitLook = 1.0f;
    private float waitState;
    private float waitDie = 1.0f;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject playerHit;


    bool nextState = true;

    private Animation anim;

    //System.Random rnd = new System.Random();
    //Transform player;
    //Vector3 point = new Vector3();

    void Start()
    {
        _move = true;
        _move2 = true;
        waitState = 4.0f;
        anim = GetComponent<Animation>();
        // MoveAI();
        // _animator = GetComponent<Animator>();
        // player = GameObject.Find("Player_Blade").transform;
        //player = player.transform;
        // stateKey = rnd.Next(0, 2);
    }

    void Update()
    {
        // point =player;

        if (anim.IsPlaying("BW_Death") || anim.IsPlaying("BW_Death2"))
        {
            anim.CrossFadeQueued("BW_Death2");
            return;
        }
        if (!anim.IsPlaying("BW_Damage"))
        {
           
            if (nextState == true)
            {
                MoveAI();
            }

            else
            {
                if (_move2)
                {
                    attackPlayer();
                }
            }
        }
       

        //Кривое исправление бага(ИИ решил улететь или уйти под землю)
        if (this.transform.position.y>0 || this.transform.position.y < 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        }

    }


    private IEnumerator WaitLookP(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    private void MoveAI()
    {


        waitState -= Time.deltaTime;
        
       
        if (_move)
        {
             anim.CrossFade("BW_Run01");
            transform.Translate(0, 0, speed * Time.deltaTime);
            //_animator.SetFloat("speed", speed);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)//&& playerHit.GetComponent<PlayerCharacter>() == null)
                {
                    float angle = UnityEngine.Random.Range(-30, 30);
                    transform.Rotate(0, angle, 0);
                }

            }
        }
        if (waitState <= 0)
        {
            nextState = false;
            waitState = 5.0f;
        }
    }
    private void attackPlayer()
    {
        waitState -= Time.deltaTime;
        waitLook -= Time.deltaTime;
       // if (_move2)
       // {
            transform.Translate(0, 0, speed * Time.deltaTime);

            //  UnityEngine.Debug.Log("Attack Player Move " + _move);
      //  }
        if (waitLook <= 0)
        {
            UnityEngine.Debug.Log("Rotate?");
            transform.LookAt(player);
            waitLook = 1.0f;
        }
        this.GetComponent<CanPunch>().EnemyAttack();
        if (waitState <= 0)
        {
            nextState = true;
            waitState = 4.0f;
        }

        //  this.GetComponent<CanPunch>().EnemyHit = false;

        //this.GetComponent<CanPunch>().EnemyHit = false;
    }
    // stateKey = rnd.Next(0, 3);

    public void CanMove(bool move)
    {
        _move = move;
    }
    public void CanMove2(bool move)
    {
        _move2 = move;
    }
}
    




