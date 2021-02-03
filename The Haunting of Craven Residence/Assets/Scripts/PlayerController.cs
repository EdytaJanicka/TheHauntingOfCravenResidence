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
    public float hInput;
    void Update()
    {
        
        hInput = Input.GetAxis("Horizontal");
        Vector3 characterScale = objectCharacter.transform.localScale;

        if (hInput < 0)
        {
            characterScale.z = -1;
            // objectCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        if (hInput > 0)
        {
            characterScale.z = 1;
            // objectCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        objectCharacter.transform.localScale = characterScale;

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
