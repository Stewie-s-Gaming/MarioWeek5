using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothParameter = 0.125f;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        /*        Vector3 dest = target.position + offset;
                Vector3 smoothPosition = Vector3.Lerp(target.position, dest, smoothParameter);
                transform.position = smoothPosition;
                transform.LookAt(target);*/
        transform.position = new Vector3(target.position.x, target.transform.position.y, transform.position.z)+offset;
    }
}
