using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;


//Планировалось использовать для Мага вместо BladeCamera
public class RayShooter : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject ssilkaNaObject;
    [SerializeField] private GameObject cursorPlayer;

    private GameObject _fireball;
    private Camera _camera;
   

    public float obstacleRange = 30.0f;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        if (cursorPlayer.GetComponent<ReactiveTarget>().Unlock() == true)
        {
            CursorUnlocked();
            GetComponent<RotatePlayer>().enabled = false;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            EventSystem.current.IsPointerOverGameObject();
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
       
                if (_fireball == null)
                {
                    ssilkaNaObject.GetComponent<PlayerFire>().openfire();
                }         
        }
       
                   
    }

    private void CursorUnlocked()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    
}

