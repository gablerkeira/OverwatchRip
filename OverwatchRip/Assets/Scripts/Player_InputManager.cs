using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Player_Movement))]
public class Player_InputManager : MonoBehaviour
{
    public event Action OnFire;
    public event Action OnFire2;
    public event Action OnSpecial;
    public event Action OnUlt;

    public float horizontal;
    public float vertical;

    public float mouseX;
    public float mouseY;

    #region Axis Names
    //Movement Axes
    [Tooltip("The name of the axis in the Input Manager for moving Left/Right")]
    public string horizontalAxis = "Horizontal";
    [Tooltip("The name of the axis in the Input Manager for moving Forward/Back")]
    public string verticalAxis = "Vertical";

    //Mouselook Axes
    [Tooltip("The name of the axis in the Input Manager for tracking Horizontal Mouse movement.")]
    public string horizontalMouseAxis = "Mouse X";
    [Tooltip("The name of the axis in the Input Manager for tracking Vertical Mouse movement.")]
    public string verticalMouseAxis = "Mouse Y";

    //Action Input Buttons
    [Tooltip("The name of the axis in the Input Manager for the Primary Fire button.")]
    public string fireButton = "Fire1";
    [Tooltip("The name of the axis in the Input Manager for the Secondary Fire button.")]
    public string fire2Button = "Fire2";
    [Tooltip("The name of the axis in the Input Manager for the Special button")]
    public string specialButton = "Special";
    [Tooltip("The name of the axis in the Input Manager for the Ultimate button")]
    public string ultButton = "Ultimate";
    [Tooltip("The name of the axis in the Input Manager for the Run button")]
    public string runButton = "Run";
    [Tooltip("The name of the axis in the Input Manager for the Jump button.")]
    public string jumpButton = "Jump";
    #endregion
    

    //Player Components
    Player_Movement playerMove;

    private void Awake()
    {
        playerMove = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis(horizontalAxis);
        vertical = Input.GetAxis(verticalAxis);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        if (Input.GetButtonDown(fireButton))
        {
            OnFire();
        }

        if (Input.GetButtonDown(fire2Button))
        {
            OnFire2();
        }

        if (Input.GetButtonDown(specialButton))
        {
            OnSpecial();
        }

        if (Input.GetButtonDown(ultButton))
        {
            OnUlt();
        }

        playerMove.isRunning = Input.GetButton(runButton);

        if (Input.GetButtonDown(jumpButton))
        {
            playerMove.Jump();
        }
    }
}
