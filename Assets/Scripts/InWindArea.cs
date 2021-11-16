using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWindArea : MonoBehaviour
{
    private bool isWindArea;
    GameObject windZone;
    Rigidbody rb;
    [SerializeField] string triggerTag;
    // Start is called before the first frame update
    void Start()
    {
        isWindArea = false;
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WindArea")
        {
            windZone = collision.gameObject;
            isWindArea = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "WindArea")
        {
            isWindArea = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWindArea)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().strength * windZone.GetComponent<WindArea>().direction);
        }
    }
}
