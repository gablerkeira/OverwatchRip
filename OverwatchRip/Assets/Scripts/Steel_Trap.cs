using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel_Trap : MonoBehaviour
{
    public float trapCooldown;
    public GameObject trap;
    float trapTime;

    // Update is called once per frame
    private void Awake()
    {
        GetComponent<Player_InputManager>().OnSpecial += PlaceTrap;
    }

    void Update()
    {
        trapTime += Time.deltaTime;
    }

    void PlaceTrap()
    {
        if(trapTime >= trapCooldown)
        {
            Instantiate(trap, transform.position, transform.rotation);
            trapTime = 0;
        }
    }
}
