using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RiptireController : MonoBehaviour
{
    public int damage = 600;
    public float moveSpeed = 12f;
    public float rotateSpeed = 90f;
    public float explosionRadius = 10f;
    public float duration = 10f;

    public event Action OnExplode = delegate { };

    private void Awake()
    {
        StartCoroutine(Countdown());
        OnExplode += GameObject.FindWithTag("Player").GetComponent<Ultimate_Riptire>().Exploded;
    }

    private void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            Detonate();
        }
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, .5f))
        {
            if (hit.collider.CompareTag("Climbable"))
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
        }
        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
        Quaternion newRotation = transform.rotation;
        Vector3 newEulerAngles = newRotation.eulerAngles;
        newEulerAngles.y += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        newRotation.eulerAngles = newEulerAngles;
        transform.rotation = newRotation;
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
        Destroy(this.gameObject);
        OnExplode();
    }

    private void OnDestroy()
    {
        OnExplode -= GameObject.FindWithTag("Player").GetComponent<Ultimate_Riptire>().Exploded;
    }
}
