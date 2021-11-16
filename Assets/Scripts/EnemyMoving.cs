using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 1f;
    float EPS = 0.1f;
    private bool moveFromStartToEnd = true;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(endPoint.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime));
        }
        else
        {  // move from end to start
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(startPoint.position.x,transform.position.y, transform.position.z), speed * Time.deltaTime));
        }

        if (System.Math.Abs(transform.position.x-startPoint.position.x) < EPS)
        {
            moveFromStartToEnd = true;
        }
        else if (System.Math.Abs(transform.position.x - endPoint.position.x) < EPS)
        {
            moveFromStartToEnd = false;
        }
    }
}
