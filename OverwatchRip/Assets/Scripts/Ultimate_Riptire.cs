using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate_Riptire : MonoBehaviour
{
    public int chargeRequired = 1720;

    public Text chargeText;
    public Image chargeCircle;

    public GameObject riptirePrefab;

    public Player_Status playerStatus;
    public Camera playerCamera;
    public Player_InputManager inputManager;

    private void Awake()
    {
        playerStatus = GetComponent<Player_Status>();
        inputManager = GetComponent<Player_InputManager>();
        inputManager.OnUlt += CallRiptire;
        playerCamera = Camera.main;
    }

    private void Update()
    {
        float percentCharged = (playerStatus.ultCharge / chargeRequired);
        if (percentCharged > 1)
            percentCharged = 1;
        chargeText.text = ((int)percentCharged * 100).ToString();
        chargeCircle.fillAmount = percentCharged;
    }

    public void CallRiptire()
    {
        if(playerStatus.ultCharge >= chargeRequired)
        {
            GameObject spawnedTire = Instantiate(riptirePrefab, transform.position + transform.forward, transform.rotation);

            playerStatus.ultCharge = 0;

            inputManager.enabled = false;
            playerCamera.enabled = false;

            spawnedTire.GetComponent<RiptireController>().OnExplode += Exploded;
        }
    }

    public void Exploded()
    {
        inputManager.enabled = true;
        playerCamera.enabled = true;
    }
}
