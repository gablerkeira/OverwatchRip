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
    [SerializeField] int damage = 20;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ExplodeTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Explode();
        }

        //bounces += 1;
        //if (bounces >= maxBounces)
        //{
        //    this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius, upwardForce);
        //    Destroy(this.gameObject);
        //}
    }
    IEnumerator ExplodeTimer()
    {
        yield return new WaitForSeconds(grenadeTime);
        Explode();
    }

    void Explode()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance <= explosionRadius) //Is the enemy in range of the explosion
            {
                enemy.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius, upwardForce);
                //Calculate damage dealt
                int damageDealt = (int)Mathf.Lerp(80, 10, enemyDistance / explosionRadius);
                Debug.Log("Dist/Rad - " + enemyDistance/explosionRadius);
                Debug.Log("Damage - " + damageDealt);
                enemy.GetComponent<Enemy_HP>().TakeDamage(damageDealt);
            }
        }
        Destroy(this.gameObject);
    }
}
