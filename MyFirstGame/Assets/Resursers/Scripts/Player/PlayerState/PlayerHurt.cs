using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] private GameObject PLAYER;
    [SerializeField] private GameObject winOrLoseMenu;
    [SerializeField] private GameObject playerLoseText;

    private int health;
    private int physicResistense;
    private int magicalResistense;
    private short count = 0;

    private bool unlockCursor = false;
    private Animation anim;

    //  public PlayerHurt()
    //{
    //    physicResistense =
    //                PLAYER.GetComponent<PlayerCharacter>().getPhysicResistanse();

    //    magicalResistense =
    //       PLAYER.GetComponent<PlayerCharacter>().getMagicResistanse();

    //    health =
    //       PLAYER.GetComponent<PlayerCharacter>().gethealth();
    //}

    void Start()
    {
        anim = GetComponent<Animation>();
        //PlayerHurt getValues;
        // getValues.PlayerHurt();
        physicResistense =
                    PLAYER.GetComponent<PlayerCharacter>().getPhysicResistanse();

        magicalResistense =
           PLAYER.GetComponent<PlayerCharacter>().getMagicResistanse();

        health =
           PLAYER.GetComponent<PlayerCharacter>().gethealth();
    }


    void Update()
    {
        if (anim.IsPlaying("BW_Death") || anim.IsPlaying("BW_Death2"))
        {
            anim.CrossFadeQueued("BW_Death2");
            return;
        }
        if (health <= 0)
        {
            Death();
        }

        // Далее идёт код,попытки сделать активным курсор,чтобы нажать кнопку настройки,однако при нажатии кнопки Готово
        // снова вылетает ошибка,которая мне всё рушит
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    unlockCursor = true;
        //}
    }

    //indexDamage 0-PhsysicResist; 1-MagicResist;
    public void Hurt(int damage, int indexDamage)
    {
        if (indexDamage == 1)
        {
            anim.Play("BW_Damage");
            health -= damage / physicResistense;
        }
        else if (indexDamage == 2)
        {
            health -= damage / magicalResistense;
            anim.Play("BW_Damage");
        }
        else
        {
            health -= damage;
            anim.Play("BW_Damage");
        }
    }
    public int gethealth()
    {
        return health;
    }
    private void Death()
    {
        anim.Play("BW_Death");
        unlockCursor = true;
        winOrLoseMenu.GetComponent<OpenMenu>().Open();
        playerLoseText.GetComponent<OpenMenu>().Open();
    }

    public bool ReturnCursor()
    {
        return unlockCursor;
    }

}
