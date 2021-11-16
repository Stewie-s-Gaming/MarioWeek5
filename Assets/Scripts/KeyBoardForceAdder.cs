using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardForceAdder : MonoBehaviour
{
    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] float walkForce = 5f;
    [SerializeField] float jumpForce = 5f;

    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse = 5f;

    [Range(0, 1f)]
    [SerializeField] float slowDownAtJump = 0.5f;

    private Rigidbody rb;
    private TouchDetector td;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        td = GetComponent<TouchDetector>();
    }

    private ForceMode walkForceMode = ForceMode.Force;
    private ForceMode jumpForceMode = ForceMode.Impulse;
    private bool playerWantsToJump = false;

    private void Update()
    {
        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(KeyCode.Space) && td.IsTouching())
            playerWantsToJump = true;
    }

    /*
     * Note that updates related to the physics engine should be done in FixedUpdate and not in Update!
     */
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (!td.IsTouching())
        {
            rb.AddForce(new Vector3(horizontal * jumpForce, 0, 0), walkForceMode);
        }
        else
        {
            rb.AddForce(new Vector3(horizontal * walkForce, 0, 0), walkForceMode);
        }
        if (td.IsTouching() && playerWantsToJump)
        {            // Since it is active only once per frame, and FixedUpdate may not run in that frame!
            rb.velocity = new Vector3(rb.velocity.x * slowDownAtJump, rb.velocity.y, rb.velocity.z);
            rb.AddForce(new Vector3(0, jumpImpulse, 0), jumpForceMode);
            playerWantsToJump = false;
        }
    }
}
