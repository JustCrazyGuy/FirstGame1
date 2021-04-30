using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//using MyFirstGame.Assets.Resursers.UI;
//using namespace MyFirstGame.Assets.Resursers.Player.Controls;

//Класс движения(прыжка) игрока.Также использует анимации,хотя по хорошему надо было их реализовать через класс 
//PlaerAnimations,но так как время поджимало пришлось делать напрямую
public class FPSInput : MonoBehaviour
{

   // private ControllerColliderHit _contact; // Нужно для сохранения данных о столкновении между функциями.
    private CharacterController _charController;

    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    public float jumpSpeed = 15.0f;

    public float speed = 10.0f;
    private float ussualySpeed = 10.0f;
    private float _vertSpeed;
    private Animation anim;

    private bool RunAtack = false;
    private bool StandAttack = false;

    // private Animator _animator;

    private float currentTime = 0;
    private float lastKeyTime = 0;
    private float KeyTime = 0.3F;

    void Start()
    {
        _vertSpeed = minFall;
        _charController = GetComponent<CharacterController>();
        // _animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        anim.Play("BW_AttackStandy");
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    //Пока что недороботано(Пока не могу всё понять,почему не работает)
        //    GameObject.FindGameObjectWithTag("menu").GetComponent<OpenOption>().Open();
        //}

        if (anim.IsPlaying("BW_Damage") || anim.IsPlaying("BW_Death") || anim.IsPlaying("BW_Combo1_1") || anim.IsPlaying("BW_Combo1_2") || anim.IsPlaying("BW_Block"))
        {
            return;
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !anim.IsPlaying("BW_Jump01"))
        {
            //   _animator.SetFloat("speed", movement.sqrMagnitude);
            if (anim.IsPlaying("BW_RunAttack") && !anim.IsPlaying("BW_Jump01"))
            {
            //Проигрование анимации атаки на ходу(Потом можно добавить чтобы игрок обязательно дальше двигался вперёд)
            }
            else
            {
                anim.CrossFade("BW_Run01", 0.1f);
                RunAtack = true;
                StandAttack = false;
            }
            
        }else if (Input.GetKey(KeyCode.S) && !anim.IsPlaying("BW_Jump01"))
        {
            anim.CrossFade("BW_B_Run01",0.1f);
            RunAtack = false;

        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) && !anim.IsPlaying("BW_Jump01"))
        {
            anim.CrossFade("BW_L_Run01");
            RunAtack = false;
            StandAttack = false;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D) && !anim.IsPlaying("BW_Jump01"))
        {
            anim.CrossFade("BW_R_Run01");
            RunAtack = false;
            StandAttack = false;
        }
        else if (!anim.IsPlaying("BW_Damage"))
        {
            anim.CrossFadeQueued(anim.clip.name);

            if (anim.IsPlaying("BW_Combo1_1") && !anim.IsPlaying("BW_Jump01"))
            {
                //Проигрование анимации атаки
            }
            else
            {
                //anim.CrossFade("BW_Run01", 0.1f);
                RunAtack = false;
                StandAttack = true;
            }
        }



      
        //Движение
        movement = transform.TransformDirection(movement);
            movement *= Time.deltaTime;
            movement = Vector3.ClampMagnitude(movement, speed);
        _charController.Move(movement);

        //Незавершённый механизм укланения

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    currentTime = Time.time;
        //    if ((currentTime - lastKeyTime) < KeyTime)
        //    {
        //        UnityEngine.Debug.Log("ok");
        //        speed *= 50;
        //    }
        //    lastKeyTime = currentTime;
        //}
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    currentTime = Time.time;
        //    if ((currentTime - lastKeyTime) < KeyTime)
        //    {
        //        UnityEngine.Debug.Log("ok");
        //        //
        //        speed *= 55;
        //    }
        //    lastKeyTime = currentTime;
        //}
        //else
        //{
        //    speed = ussualySpeed;
        //}

        //Прыжок
        if (_charController.isGrounded)
            {
                //  _animator.SetBool("Jumping", false);
                if (Input.GetKey(KeyCode.Space) && !anim.IsPlaying("BW_Jump01"))
                {
                anim.Play("BW_Jump01");
                    _vertSpeed = jumpSpeed;
                    // _animator.SetBool("Jumping", true);
                }
                else
                {
                    _vertSpeed = minFall;
                }
            }
            else
            {
                _vertSpeed += gravity * 5 * Time.deltaTime;
                if (_vertSpeed < terminalVelocity)
                {
                    _vertSpeed = terminalVelocity;
                }
            }
            movement.y = _vertSpeed;
            movement *= Time.deltaTime;
            _charController.Move(movement);
        }
    public bool RunAttack()
    {
        return RunAtack;
    }
    public bool StandAtacker()
    {
        return StandAttack;
    }
}

