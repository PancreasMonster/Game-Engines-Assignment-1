using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float leftBumper;

   /* private void OnRightStickClick(InputValue value)
    {

        lockedBehind = !lockedBehind;
        offset = origPos;
        offset = Quaternion.AngleAxis(player.transform.localEulerAngles.y - 180, Vector3.up) * offset;
        
        origPos = new Vector3(origPos.x, origPos.y, -origPos.z);
        jumpOffset = new Vector3(jumpOffset.x, jumpOffset.y, -jumpOffset.z);
    }

    private void OnRightStickRelease(InputValue value)
    {

        lockedBehind = !lockedBehind;
        offset = origPos;
        offset = Quaternion.AngleAxis(player.transform.localEulerAngles.y - 180, Vector3.up) * offset;
        
        origPos = new Vector3(origPos.x, origPos.y, -origPos.z);
        jumpOffset = new Vector3(jumpOffset.x, jumpOffset.y, -jumpOffset.z);
    }

    private void OnRightStick(InputValue value)
    {

        rightStick = value.Get<Vector2>();

    }

    private void OnLeftBumper(InputValue value)
    {

        leftBumper = 1;

    }

    private void OnLeftBumperRelease(InputValue value)
    {

        leftBumper = 0;

    }*/

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
       
            
            //tempOffset = Quaternion.AngleAxis(player.transform.localEulerAngles.y - 180, Vector3.up) * tempOffset;
            // Vector3 wallOffset = fo.hit.normal;
            /* Vector3 wallOffsetY = fo.hit.normal;

            if (Vector3.Dot(Vector3.forward, fo.hit.normal.normalized) > .8f || Vector3.Dot(Vector3.forward, fo.hit.normal.normalized) < -.8f)
            {
                wallOffset = Quaternion.AngleAxis(-90, Vector3.up) * wallOffset;

            }

            if (Vector3.Dot(Vector3.up, fo.hit.normal) < -.8f || Vector3.Dot(Vector3.up, fo.hit.normal) > .8f)
            {
                wallOffsetY = Quaternion.AngleAxis(90, Vector3.forward) * wallOffsetY;
            }

            if (Vector3.Dot(Vector3.up, fo.hit.normal) < -.8f)
            {

                wallTransition = Mathf.Lerp(wallTransition, -180, lerpSpeed * .3f * Time.deltaTime);
                tempOffset = new Vector3(tempOffset.x, -tempOffset.y, tempOffset.z);
            }
            else
            {
                wallTransition = Mathf.Lerp(wallTransition, 0, lerpSpeed * .3f * Time.deltaTime);
            }
            tempOffset = Quaternion.AngleAxis(-rotateAmount, wallOffset) * tempOffset;
            tempOffset = Quaternion.AngleAxis(-yRotateAmount, wallOffsetY) * tempOffset;*/

            
            

            cam.transform.position = Vector3.Lerp(cam.transform.position, spherePos.position + offset, lerpSpeed * Time.deltaTime);

            cam.transform.LookAt(spherePos.position);    
                    
        }


    }

