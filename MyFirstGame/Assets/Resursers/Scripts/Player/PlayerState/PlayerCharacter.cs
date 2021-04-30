using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;
    private int physicResist=2;
    private int magicResist=5;


    //public PlayerCharacter()
    //{
    //    physicResist = 2;
    //    magicResist = 5;
    //}

    void Start()
    {
        //PlayerCharacter values;
        //values.PlayerCharacter();
        _health = 10000;
    }
    
    public int gethealth()
    {
        return _health;
    }

    public int getPhysicResistanse()
    {
        return physicResist;
    }

    public int getMagicResistanse()
    {
        return magicResist;
    }
}
