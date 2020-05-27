using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{


    public float turnSpeed = 4.0f, lerpSpeed;
    public Transform cam, spherePos;
    public Vector3 offset = new Vector3(0, 10, -26);


    void Start()
    {
        //offset = new Vector3(0, 10, -26);
       // origPos = offset;
      //  wheels = player.GetComponentsInChildren<WheelCollider>();
    }

    Vector2 rightStick;


    private void OnRightStick(InputValue value)
    {

        rightStick = value.Get<Vector2>();
        
    }


    /* private void Update()
     {
         if (fo.timer < timeAllowance)
         {
             if (Input.GetButtonDown("PadLB" + playerNum.ToString()) && !death)
             {
                 Rigidbody rb = player.GetComponent<Rigidbody>();
                 rb.AddForce(Vector3.up * 22500);
                 rb.drag = setDrag;
                 rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                 player.transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);
                 if(aud != null)
                 aud.Stop();
                 player.GetComponent<RearWheelDrive>().enabled = false;
                 player.GetComponent<BuildModeProtoMovement>().enabled = true;
                 player.GetComponent<BuildModeFire>().enabled = true;
                 foreach (WheelCollider w in wheels)
                 {
                     w.gameObject.SetActive(false);
                 }
                 player.GetComponent<LineRenderer>().enabled = true;
                 player.GetComponent<FireDisk>().enabled = false;
                 hoverBox.GetComponent<BoxCollider>().enabled = true;
                 GetComponent<BuildModeCamera>().changeToThis(wheels);
                 GetComponent<BuildModeCamera>().enabled = true;
                 GetComponent<BuildModeCamera>().ToggleUIElements();
                 GetComponent<Orbit>().enabled = false;
             } 
         } 
     } */



    void FixedUpdate()
    {

       

        offset = Quaternion.AngleAxis(turnSpeed * rightStick.x, Vector3.up) * offset;
       

            
            

        cam.transform.position = Vector3.Lerp(cam.transform.position, spherePos.transform.TransformPoint(offset), lerpSpeed * Time.deltaTime);


        Vector3 dir = spherePos.transform.position - cam.transform.position;
        dir.Normalize();

        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.LookRotation(dir), lerpSpeed * Time.deltaTime);    
                    
    }


    }

