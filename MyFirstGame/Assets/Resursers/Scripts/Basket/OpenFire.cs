using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OpenFire : MonoBehaviour
{

    void Start()
    {

    }
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;



    public float obstacleRange = 30.0f;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 0.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
        }
    }
    
}


