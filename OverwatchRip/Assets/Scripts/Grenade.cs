using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //public float grenadeTime = 3;
    public float explosionForce = 3;
    public float explosionRadius = 2;
    public float upwardForce = 3;

    [SerializeField] int bounces = 0;
    private int maxBounces = 3;
    private bool bounced = false;

    [SerializeField] int minDamage = 10;
    [SerializeField] int maxDamage = 80;

    Player_Status ultimate;

    void Start()
    {
        //StartCoroutine(ExplodeTimer());
        ultimate = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Status>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy_HP>().TakeDamage(50);
            ultimate.ultCharge += 50;
            Explode();
        }

        StartCoroutine(Bounced());
    }

    IEnumerator Bounced()
    {
        if (bounced == false)
        {
            bounced = true;
            bounces += 1;
            if (bounces > maxBounces)
            {
                Explode();
            }
        }
        yield return new WaitForSeconds(.2f);
        bounced = false;
    }
    //IEnumerator ExplodeTimer()
    //{
    //    yield return new WaitForSeconds(grenadeTime);
    //    Explode();
    //}

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
                int damageDealt = (int)Mathf.Lerp(maxDamage, minDamage, enemyDistance / explosionRadius);
                ultimate.ultCharge += damageDealt;
                enemy.GetComponent<Enemy_HP>().TakeDamage(damageDealt);
            }
        }
        Destroy(this.gameObject);
    }
}
