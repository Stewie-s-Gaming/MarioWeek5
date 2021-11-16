using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMover : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Step size")]
    float step_size=5f;
    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse = 5f;

    private TouchDetector td;
    private Rigidbody rb;
    private ForceMode jumpForceMode = ForceMode.Impulse;
    private bool playerWantsToJump = false;


    void Start()
    {
        td = GetComponent<TouchDetector>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(KeyCode.Space) && td.IsTouching())
            playerWantsToJump = true;
    }
    void FixedUpdate()
    {

            if (!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(step_size * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(-step_size * Time.deltaTime, 0, 0);
            }
            if (td.IsTouching() && playerWantsToJump)
            {
                rb.AddForce(new Vector3(0, jumpImpulse, 0), jumpForceMode);
                playerWantsToJump = false;
            }
    }
}
