using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text currAmmo;
    FireWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<FireWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        currAmmo.text = weapon.currClip.ToString();
    }
}
