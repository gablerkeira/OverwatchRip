using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate_Riptire : MonoBehaviour
{
    public int chargeRequired = 1720;
    public float duration = 10.0f;

    public Text chargeText;
    public Image chargeCircle;

    public Player_Status playerStatus;

    private void Awake()
    {
        playerStatus = GetComponent<Player_Status>();
        playerStatus.OnUlt += CallRiptire;
    }

    private void Update()
    {
        
    }

    public void CallRiptire()
    {
        if(playerStatus.ultCharge >= chargeRequired)
        {
            //Create riptire

        }
    }
}
