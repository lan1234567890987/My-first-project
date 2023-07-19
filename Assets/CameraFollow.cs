using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //private Transform car;

    //private Vector3 carCameraVector3;

    //void Start()
    //{
    //    car = GameObject.Find("default").transform;
    //    //cach 2 : public car + xoa dong 14 
    //    //         keo default vao o nhap
    //    carCameraVector3 = car.transform.position - transform.position;
    //}//                    vi tri xe                vi tri cam

    //void LateUpdate()// late update xu ly sau update
    //{
    //    transform.position = car.transform.position - carCameraVector3;
    //}


    public Transform car;

    private Vector3 carCameraVector3;

    void Start()
    { 
        carCameraVector3 = car.transform.position - transform.position;
    } 
    
    void LateUpdate() 
    {
        transform.position = car.transform.position - car.transform.rotation * carCameraVector3;
        transform.LookAt(car);
    }
}
