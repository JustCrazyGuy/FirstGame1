using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private int hp = 10000;
    private Animation anim;
    private bool canBlock = false;
    private bool winOrLose = false;
    private bool unlockCursor = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject winOrLoseMenu;
    [SerializeField] private GameObject playerWinText;
   

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (player.GetComponent<PlayerCharacter>() != null)
            {
                canBlock = true;
            }
            else
            {
                canBlock = false;
            }
        }
    }

    public bool Block()
    {
        System.Random rnd = new System.Random();
        int key = rnd.Next(0, 100);
        if (key <=25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReactToHit(int damage)
    {
        if (Block() == true && canBlock == true)
        {
            //StartCoroutine(Wait(0.5f));
            anim.Play("BW_Block");
            StartCoroutine(WaitMove(1.0f));
        }
        else
        {
            hp -= damage;
            anim.Play("BW_Damage");
            StartCoroutine(WaitMove(1.0f));
        }
        UnityEngine.Debug.Log(hp);
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null && hp <= 0)
        {
                StartCoroutine(Die()); 
        }

    }
    private IEnumerator Die()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        anim.Play("BW_Death");
        behavior.CanMove(false);
        winOrLoseMenu.GetComponent<OpenMenu>().Open();
        playerWinText.GetComponent<OpenMenu>().Open();
        unlockCursor = true;
        yield return new WaitForSeconds(1.5f);

       
    }
    private IEnumerator WaitMove(float waitTime)
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        behavior.CanMove(false);
        yield return new WaitForSeconds(waitTime);
        behavior.CanMove(true);
    }
  public int GetHp()
    {
        return hp;
    }
    public bool Unlock()
    {
        return unlockCursor;
    }
}
