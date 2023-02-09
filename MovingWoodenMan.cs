using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWoodenMan : MonoBehaviour
{
    private float direction;
    private float speed;
    private float speed2;
    private Vector3 targetPos;
    private bool isStopMoving;
    void Start()
    {
        isStopMoving = false;
        targetPos = transform.position;
        speed2 = 1.0f;
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            direction = -1.0f;
        }
        else
        {
            direction = 1.0f;
        }
        speed = Random.Range(1.0f, 2.0f);
        speed2 = Random.Range(1.0f, 2.0f);
        Shot.OnSomeChanged += StopMoving;
    }

    void Update()
    {
        if (!isStopMoving)
        {
            transform.position =
                new Vector3(Mathf.Sin(Time.time * speed) * 3.0f * direction * speed2 + targetPos.x, targetPos.y, targetPos.z);
        }
    }

    public void StopMoving()
    {
        isStopMoving = true;
    }
}
