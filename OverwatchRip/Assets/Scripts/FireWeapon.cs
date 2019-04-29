using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public float grenadeTime = 3;
    public int forceFired = 1000;
    public GameObject projectile;

    private int fireInterval = 2;
    private float nextTimetoFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1 / fireInterval;
            Fire();
        }
    }

    void Fire()
    {
        GameObject go = Instantiate(projectile, this.transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceFired);
        Destroy(go, grenadeTime);
    }
}
