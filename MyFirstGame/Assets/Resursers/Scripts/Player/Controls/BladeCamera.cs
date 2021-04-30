using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;


// Я долго гуглил как сделать перемещение колайдера вместе с мечём в анимации(так и не вышло)
// Так что было решено сделать упрощённый вариант реакции меча на противника
//UPD,Я ИДИОТ!,мог просто создать невидимый объект с колайдером,который был-бы перед объектом,и чтобы именно он засчитывал попадания
//UPD2,Я Дважды ИДИОТ...Мог сделать простую пошаговую боёвку,и не мучатся с балансом и геймлеем(игры выходит скучная и однообразная).
//И вообще вышло что-то больше похожее на кликер...Но времени не полную переработку уже нет,так что прийдётся оставить такую кастрированную игру
public class BladeCamera : MonoBehaviour
{

    [SerializeField] private GameObject Attack;
    [SerializeField] private GameObject cursorPlayerFromEnemy;
    [SerializeField] private GameObject cursorPlayer;
    [SerializeField] private GameObject punchAnimPlayer;

    private Camera _camera;

    private short count = 0;
    public float obstacleRange = 30.0f;
    private float waitAnimation = -2.0f;


    private bool blockPlayer = false;
    void Start()
    {
       GetComponent<AudioSource>().volume = VolumeFromMenu.GlobalVolume;
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //runAttack = GetComponent<FPSInput>();
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "°");
    }
    void Update()
    {
        //Включение курсора,отключение ИИ и управление персонажем по победы или поражения
        if (cursorPlayerFromEnemy.GetComponent<ReactiveTarget>().Unlock() == true || cursorPlayer.GetComponent<PlayerHurt>().ReturnCursor() == true)
        {
            CursorUnlocked();
            GetComponent<RotatePlayer>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInput>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<RotatePlayer>().enabled = false;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<WanderingAI>().enabled = false;
            return;
        }
      

        waitAnimation -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && waitAnimation <= 0)
        {

            if (Attack.GetComponent<FPSInput>().RunAttack() == true)
            {
                punchAnimPlayer.GetComponent<PlayerAnimations>().runAttack();
            }
            if (Attack.GetComponent<FPSInput>().StandAtacker() == true)
            {
                if (count == 0)
                {
                    punchAnimPlayer.GetComponent<PlayerAnimations>().StandAtack();
                    ++count;
                }
                else
                {
                    count = 0;
                    punchAnimPlayer.GetComponent<PlayerAnimations>().StandAtack2();
                }
            }
            waitAnimation = 1.0f;
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            blockPlayer = true;
            punchAnimPlayer.GetComponent<PlayerAnimations>().Block();
            //if (Input.GetMouseButtonDown(1))
            //{
            //    punchAnimPlayer.GetComponent<PlayerAnimations>().Block2();
            //}
        }
       
        if (!punchAnimPlayer.GetComponent<PlayerAnimations>().anim.IsPlaying("BW_Block"))
        {
            blockPlayer = false;
        }
    }
    public bool PlayerBlockReturn()
    {
        return blockPlayer;
    }
    private void CursorUnlocked()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

