using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
   // private Animator _animator;
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
       // _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.CrossFade("BW_Talk");
    }
}
