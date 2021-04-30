using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//анимация бега находятся в FPSInput

public class PlayerAnimations : MonoBehaviour
{
    public Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireAnim()
    {
        anim.Play("BW_Combo1_1");
    }
    public void runAttack()
    {
        anim.Play("BW_RunAttack");
    }
    public void StandAtack()
    {
        anim.Play("BW_Combo1_1");
    }
    public void StandAtack2()
    {
        anim.Play("BW_Combo1_2");
    }
    public void Block()
    {
        anim.Play("BW_Block");
    }
    public void Block2()
    {
        anim.Play("BW_Block2");
    }
}
