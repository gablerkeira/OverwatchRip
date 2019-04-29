using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float grenadeTime = 3;
    public float explosionForce = 3;
    public float explosionRadius = 3;
    public float upwardForce = 3;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(grenadeTime);
        this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius, upwardForce);
        Destroy(this.gameObject);
    }
}
