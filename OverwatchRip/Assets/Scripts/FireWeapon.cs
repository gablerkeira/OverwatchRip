using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public int forceFired = 1000;
    public GameObject projectile;
    public int currClip = 6;
    public int reloadTime = 3;

    private int fireInterval = 2;
    private float nextTimetoFire = 0;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_InputManager>().OnFire += Fire;
    }

    void Fire()
    {
        if (Time.time >= nextTimetoFire)
        {
            currClip -= 1;
            nextTimetoFire = Time.time + 1 / fireInterval;
            GameObject go = Instantiate(projectile, this.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceFired);
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
        currClip = 6;
    }
}
