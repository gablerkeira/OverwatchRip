using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussion_Mine : MonoBehaviour
{
    public bool OnGround;
    public GameObject mine;
    private GameObject mineActive;
    public float explosionForce = 3f;
    public float explosionRadius = 6f;
    public GameObject player;
    public Vector3 playerPos;
    private float cooldownTime = 0f;
    private float timestamp;
    public int mineCharges = 2;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        GetComponent<Player_InputManager>().OnFire2 += PlaceMine;
        GetComponent<Player_InputManager>().OnExplodeMine += Explode;
        OnGround = false;
    }

    public void PlaceMine()
    {
        if (timestamp <= Time.time)
        {
            if (OnGround == false)
            {
                mineActive = Instantiate(mine, transform.position, transform.rotation);
                OnGround = true;
                cooldownTime = 8f;
                timestamp = Time.time + cooldownTime;
            }
        }
    }

    public void Explode()
    {
        if (OnGround == true)
        {
            mineActive.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            Destroy(mineActive);
            OnGround = false;

            if (playerPos.x == transform.position.x && playerPos.y == transform.position.y)
            {
                player.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
