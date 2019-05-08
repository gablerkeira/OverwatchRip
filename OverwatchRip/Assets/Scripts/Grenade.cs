using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float grenadeTime = 3;
    public float explosionForce = 3;
    public float explosionRadius = 2;
    public float upwardForce = 3;

    //[SerializeField] int bounces = 0;
    //[SerializeField] int maxBounces = 0;
    [SerializeField] int damage = 130;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Explode());
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    bounces += 1;
    //    if (bounces >= maxBounces)
    //    {
    //        this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius, upwardForce);
    //        Destroy(this.gameObject);
    //    }
    //}
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(grenadeTime);
        this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius, upwardForce);
        Destroy(this.gameObject);
    }
}
