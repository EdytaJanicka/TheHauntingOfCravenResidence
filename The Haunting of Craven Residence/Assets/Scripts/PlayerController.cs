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
    private bool rotating;
    private bool moving = true;

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");

        if (moving == true)
        {

            if (horizontal == true)
            {
                controller.Move(transform.right * hInput * speed * Time.deltaTime);

            }

            if (vertical == true)
            {
                controller.Move(transform.right * hInput * speed * Time.deltaTime);
            }

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
    }
    public void StartMoving()
    {
        moving = true;
    }
}
