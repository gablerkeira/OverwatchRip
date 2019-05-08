using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public int forceFired = 1000;
    public GameObject projectile;
    public int currClip = 5;
    public float reloadTime = 1.55f;

    private int fireInterval = 2;
    private float nextTimetoFire = 0;

    public Transform weaponPoint;
    Player_Status ultimate;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_InputManager>().OnFire += Fire;
        ultimate = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Status>();
    }

    void Fire()
    {
        if (Time.time >= nextTimetoFire)
        {
            ultimate.ultCharge += 1;
            currClip -= 1;
            nextTimetoFire = Time.time + .65f / fireInterval;
            //Vector3 cam = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            GameObject go = Instantiate(projectile, weaponPoint.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * forceFired);
            if (currClip <= 0)
            {
                Reload();
            }
        }
    }
    public void Reload()
    {
        currClip = 0;
        StartCoroutine(ReloadingTime());
    }

    IEnumerator ReloadingTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currClip = 5;
    }
}
