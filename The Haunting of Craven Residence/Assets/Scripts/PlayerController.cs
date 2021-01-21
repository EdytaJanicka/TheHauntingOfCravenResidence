using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8.0f;
    public bool horizontal = true;
    public bool vertical = false;
    public GameObject objectToRotate;
    public GameObject objectCharacter;
    private bool rotating;
    public Animator animator;
    private bool moving = true;
    private bool movingAnimation = true;
    public float hInput;
    float smooth = 200.0f;
    float tiltAngle = 90.0f;
    float tiltAngle1 = -90.0f;
    float tiltAroundY;
    void Update()
    {
        
        if(horizontal == true)
        {
             tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;
        }
        else
        {
             tiltAroundY = Input.GetAxis("objectCharacter") * tiltAngle1;
            
        }
        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

        hInput = Input.GetAxis("Horizontal");
        if(hInput < 0)
        {
            objectCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        if (hInput > 0)
        {
            objectCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        

        if (moving == true)
        {
            if( hInput != 0)
            {
                animator.SetBool("isWalking", true);

            }
            else
            {
                animator.SetBool("isWalking", false);
            }
            controller.Move(transform.right * hInput * speed * Time.deltaTime);

        }

    }

    
    private IEnumerator RotateRight(Vector3 angles, float duration)
    {
        rotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        objectToRotate.transform.rotation = endRotation;
        StartMoving();
        rotating = false;
    }

    private IEnumerator RotateLeft(Vector3 angles, float duration)
    {
        rotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        objectToRotate.transform.rotation = endRotation;
        StartMoving();
        rotating = false;
    }

    public void StartRotation()
    {
        StopMoving();
        if (!rotating)
            StartCoroutine(RotateRight(new Vector3(0, -90, 0), 1));
    }

    public void StartRotation2()
    {
        StopMoving();
        if (!rotating)
            StartCoroutine(RotateLeft(new Vector3(0, 90, 0), 1));
    }

    public void StopMoving()
    {
        moving = false;
        animator.SetBool("isWalking", false);
    }
    public void StartMoving()
    {
        moving = true;
    }
}
