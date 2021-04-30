using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
//надо бы сделать к каждому скрипту namespace,Но в данном проекте я думаю это возможно опустить

//Здесь есть наличие так называемого легаси кода(Мне он очень не нравится в этом виде)
//Делал уже перед дедлайном,так что пришлось немного забить на красоту и правильную структуру

//Данный класс повествует нам о том,может ли персонаж(Данный класс весит на игроке и противнике) попасть друг в друга
//Реализация через луч и тайминги(Идиотская система,которую я бы с большим удовольствием бы переделал)

public class CanPunch : MonoBehaviour
{
    public float obstacleRange = 3.0f;
    public int damage = 500;
    public int PhysPunch = 1;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBladeCam;
    [SerializeField] private GameObject enemy;


    private bool canHit = false;
    public bool enemyHit = false;
    private bool nextEnemyHit = false;

    private Animation anim;


    private short count = 0;
    private bool Coroutine = true;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame 
    void Update()
    {
        if (anim.IsPlaying("BW_Damage"))
        {
            this.GetComponent<WanderingAI>()?.CanMove(false);
            return;
        } 
            this.GetComponent<WanderingAI>()?.CanMove(true);

        if (nextEnemyHit == true)
        {
            enemyHit = false;
            nextEnemyHit = false;
        }



        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (!Input.GetKey(KeyCode.Mouse0) || anim.IsPlaying("BW_RunAttack") || anim.IsPlaying("BW_Combo1_1"))
        {
            return;
        }
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance <= obstacleRange)
                {
                    canHit = true;
                }


                if (canHit == false)
                {
                    //Меч не достигает цели
                }
                else
                {
                    if (enemy.GetComponent<ReactiveTarget>() != null)
                    {
                        if (enemy.GetComponent<ReactiveTarget>().Block() == true)
                        {
                            canHit = false;
                        }
                        else
                        {
                            StartCoroutine(WaitE(0.5f));
                            canHit = false;
                        }
                        count = 0;
                    }

                }
            }
        

    }
    private IEnumerator WaitP(float waitTime)
    {
        Coroutine = false;
        this.GetComponent<WanderingAI>().CanMove2(false);
       // UnityEngine.Debug.Log("WaitP1 Attack Move " + this.GetComponent<WanderingAI>()._move2);
        anim.Play("BW_Combo1_1");
       // UnityEngine.Debug.Log("Combo1");
        yield return new WaitForSeconds(waitTime);
        if (playerBladeCam.GetComponent<BladeCamera>().PlayerBlockReturn() == false)
        {
            player.GetComponent<PlayerHurt>().Hurt(damage, PhysPunch);
        }
      //  UnityEngine.Debug.Log("Combo2");
        anim.PlayQueued("BW_Combo1_2");
        yield return new WaitForSeconds(waitTime);
        if (playerBladeCam.GetComponent<BladeCamera>().PlayerBlockReturn() == false)
        {
            player.GetComponent<PlayerHurt>().Hurt(damage, PhysPunch);
        }
        this.GetComponent<WanderingAI>().CanMove2(true);
      //  UnityEngine.Debug.Log("WaitP2 Attack Move " + this.GetComponent<WanderingAI>()._move2);
        Coroutine = true;

    }


    private IEnumerator WaitE(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (count < 1)
        {
            enemy.GetComponent<ReactiveTarget>().ReactToHit(damage); // Пока-что можно опустить сопротивляемость для противника
            count++;
        }
    }
    public void EnemyAttack()
    {
        anim.CrossFade("BW_Run01");
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance <= obstacleRange)
            {
                canHit = true;
            }
            if (canHit == false)
            {
                //Меч не достигает цели
            }
            else
            {
                if (player.GetComponent<PlayerCharacter>() != null)
                {
                    if (Coroutine)
                    {       
                        StartCoroutine(WaitP(0.5f));
                    }
                    canHit = false;
                }
            }
        }

    }
    public void NextEnemyHit()
    {
        enemyHit = false;
    }
}

