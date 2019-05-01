using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    public int health = 200;
    public int ultCharge = 0;

    private void Awake()
    {
        StartCoroutine(UltimateCharge());
    }

    IEnumerator UltimateCharge()
    {
        while(health > 0)
        {
            yield return new WaitForSeconds(1.0f);

            ultCharge += 5;
        }
    }
}
