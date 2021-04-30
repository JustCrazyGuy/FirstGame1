using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFire : MonoBehaviour
{

    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject FireAnimPlayer;

    private GameObject _fireball;
  
 

    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openfire()
    {
        FireAnimPlayer.GetComponent<PlayerAnimations>().FireAnim();

        _fireball = Instantiate(fireballPrefab) as GameObject;
        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 0.5f);
        _fireball.transform.rotation = transform.rotation;
    }
}
