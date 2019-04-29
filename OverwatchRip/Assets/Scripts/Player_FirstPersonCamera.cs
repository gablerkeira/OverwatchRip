using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FirstPersonCamera : MonoBehaviour
{
	[Tooltip("How fast the player can look left/right")]
	[SerializeField] float xSensitivity = 4f;
	[Tooltip("How fast the player can look up/down")]
	[SerializeField] float ySensitivity = 3f;

	private float vertRot;

	[Tooltip("How far down the player can look.")]
	[SerializeField] float minimumX = -90f;
	[Tooltip("How far up the player can look.")]
	[SerializeField] float maximumX = 90f;

	[Tooltip("The player's main camera. This will be set automatically if not filled in.")]
	[SerializeField] GameObject playerCamera;
	private Player_InputManager inputManager;

	private void Awake()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		inputManager = GetComponent<Player_InputManager>();
		if (playerCamera == null)
			playerCamera = Camera.main.gameObject;
	}

	// Update is called once per frame
	void Update()
    {
		vertRot += inputManager.mouseY * ySensitivity;
		vertRot = Mathf.Clamp(vertRot, minimumX, maximumX);
		
		playerCamera.transform.localRotation = Quaternion.Euler(vertRot, 0, 0);
		transform.Rotate(0, inputManager.mouseX * xSensitivity, 0);
	}
}
