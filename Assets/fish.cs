using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public Rigidbody carRigidBody;

    public GameObject leftSmokeEffect, rightSmokeEffect;

    public float speed = 8;

    public float turnSpeed = 2;


    private float moveDistance;
     
     
    private void FixedUpdate()
    {
        var verticalInput = Input.GetAxisRaw("Vertical");
        moveDistance = verticalInput * speed;

        //xl xoay
        var horizontalInput = Input.GetAxisRaw("Horizontal");

        var horizontalInputAbs = Mathf.Abs(horizontalInput);

        if(horizontalInputAbs > 0.3f)
        {
            leftSmokeEffect.SetActive(true);
            rightSmokeEffect.SetActive(true);
        }
        else
        {
            leftSmokeEffect.SetActive(false);
            rightSmokeEffect.SetActive(false);
        }
        //xoay theo truc y -> nhan vector up
        var angle = horizontalInput * Vector3.up;
        //tuy chinh toc do goc xoay
        var lastAngle = angle * turnSpeed;

        //transform.Rotate(lastAngle);
        carRigidBody.AddTorque(lastAngle);

        carRigidBody.AddForce(transform.forward * moveDistance);
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    //Debug.Log("co va cham" + collision.gameObject.name);// lay ra ten vat va cham phai

    //    if (collision.gameObject.tag.Equals("Box"))
    //    {
    //        Debug.Log("co va cham");
    //    }

    //}

    //public void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("DANG va cham");

    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("KTHUC va cham");

    //}

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Box"))
        {
            Debug.Log("da di xuyen");
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Box"))
        {
            Debug.Log("ket thuc di xuyen");
            collider.gameObject.SetActive(false);
        }
    }
}

//void Wake()
//{
//    Debug.Log($"Hello{playName}");
//}

//bai3 : 
//transform.Translate(0,0,speed);
//transform.Translate(Vector3.forward*speed);
//transform.Translate(new Vector3(0,0,1)*Time.deltaTime);
//s_codinh=v*t  : di chuyen sai -> giat lag -> dung Time... de lam muot 

//bai4 :
//GetAxis khi len thi chay dan tu 0->1, bo nhan phim thi chay tu 1->0, tuong tu voi di lui
//var vertical = Input.GetAxis("Vertical"); 
//Debug.Log(vertical);//test 0 1 -1, GetAxis khi ket thuc se giam tu tu toc do
//var distance = vertical * Vector3.forward;// * voi vector forward de biet dc khoang cach di chuyen sau moi frame cua ca 
//var d = distance * Time.deltaTime * speed;//Lam toc do moi frame bang nhau
//speed tang giam toc do chay


//GetAxisRaw : k co buoc lam muot va chi co 3 gtr : 0,1,-1;
//luc chay cu bang bang, 0 la dung luon

//GetButton : 
//if(Input.GetButtonDown("Vertical"))
//{
//    Debug.Log("press");
//}

//if (Input.GetButton("Vertical"))
//{
//    Debug.Log("hold");
//}

//if (Input.GetButtonUp("Vertical"))
//{
//    Debug.Log("release");
//}


//transform.Translate(d);

//var horizontal = Input.GetAxis("Horizontal") * Vector3.up * Time.deltaTime * turnSpeed;
//transform.Rotate(horizontal);