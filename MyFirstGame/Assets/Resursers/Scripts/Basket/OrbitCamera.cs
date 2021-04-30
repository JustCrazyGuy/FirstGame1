//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OrbitCamera : MonoBehaviour
//{
//    [SerializeField] private Transform target;

//    public enum RotationAxes
//    {
//        MouseXAndY = 0,
//        MouseX = 1,
//        MouseY = 2
//    }

//    public RotationAxes axes = RotationAxes.MouseXAndY;
//    public float sensitivityHor = 0.8f;
//    public float sensitivityVert = 9.0f;

//    public float minimumVert = -45.0f;
//    public float maximumVert = 45.0f;

//    public float rotSpeed = 1.5f;
//    private float _rotationX = 0;
//    private float _rotY;
//    private Vector3 _offset;

//    void Start()
//    {
//        _rotY = transform.eulerAngles.y;
//        _offset = target.position - transform.position;
//    }
//    void Update()
//    {
//        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
//        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
//        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
//        float rotationY = transform.localEulerAngles.y + delta;
//        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
//    }
//    void LateUpdate()
//    {
//        float horInput = Input.GetAxis("Horizontal");
//        float VertInput = Input.GetAxis("Vertical");
//        _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
//        _rotationX += Input.GetAxis("Mouse Y") * rotSpeed * 3;
//        Quaternion rotation = Quaternion.Euler(_rotationX, _rotY, 0);
//        transform.position = target.position - (rotation * _offset);
//        transform.LookAt(target);
//    }
//}

