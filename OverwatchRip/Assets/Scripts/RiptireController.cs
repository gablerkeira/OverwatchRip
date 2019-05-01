using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RiptireController : MonoBehaviour
{
    public int damage = 600;
    public float moveSpeed = 12f;
    public float rotateSpeed = 45f;
    public float explosionRadius = 10f;
    public float duration = 10f;

    public event Action OnExplode = delegate { };

    private void Awake()
    {
        StartCoroutine(Countdown());
    }

    private void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            Detonate();
        }

        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
        Quaternion newRotation = transform.rotation;
        Vector3 newEulerAngles = newRotation.eulerAngles;
        newEulerAngles.x += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(duration);

        Detonate();
    }

    private void Detonate()
    {
        StopAllCoroutines();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance <= explosionRadius) //Is the enemy in range of the explosion
            {
                //Calculate damage dealt
                int damageDealt = (int)Mathf.Lerp(600, 60, enemyDistance / explosionRadius);
                enemy.GetComponent<Enemy_HP>().TakeDamage(damageDealt);
            }
        }
    }
}
