using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player_InputManager))]
public class Player_Movement : MonoBehaviour
{
    [Tooltip("How fast the player moves normally.")]
    [SerializeField] float walkSpeed = 2f;
    [Tooltip("How fast the player moves when running.")]
    [SerializeField] float runSpeed = 4f;
    [Tooltip("How fast the player moves when crouching.")]
    [SerializeField] float crouchSpeed = 1f;
    [Tooltip("How much force the player jumps with.")]
    [SerializeField] float jumpForce = 4f;

	private float distToGround;

    public bool isRunning;
    public bool isCrouching;
	public bool isGrounded;

    private Vector3 totalForce;

    private Player_InputManager inputManager;
    private Rigidbody rb;

    private void Awake()
    {
        inputManager = GetComponent<Player_InputManager>();
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        if(!isRunning && !isCrouching) //Walking
        {
            totalForce = Vector3.zero;

            totalForce += transform.right * inputManager.horizontal * walkSpeed;
            totalForce += transform.forward * inputManager.vertical * walkSpeed;

			transform.position += totalForce * Time.deltaTime;
        }
        else if (isRunning) //Running
        {
            totalForce = Vector3.zero;

            totalForce += transform.right * inputManager.horizontal * runSpeed;
            totalForce += transform.forward * inputManager.vertical * runSpeed;

			transform.position += totalForce * Time.deltaTime;
		}
        else if (isCrouching)
        {
            //TODO: CROUCHING
        }
        #endregion

        //Check if grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround + .1f); //+.1f to account for irregularities in terrain
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
