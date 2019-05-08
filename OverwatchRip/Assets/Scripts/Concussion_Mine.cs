using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussion_Mine : MonoBehaviour
{
    public float onGround;
    public GameObject mine;
    private GameObject mineActive1;
    private GameObject mineActive2;
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
        onGround = 0;
    }

    public void PlaceMine()
    {
        if (mineCharges == 2)
        {
            if (timestamp <= Time.time)
            {
                if (onGround < 2)
                {
                    mineActive1 = Instantiate(mine, transform.position, transform.rotation);
                    onGround = 1;
                    cooldownTime = 8f;
                    timestamp = Time.time + cooldownTime;
                    mineCharges--;
                }
            }
        }

        if (mineCharges == 1)
        {
            if (timestamp <= Time.time)
            {
                if (onGround < 2)
                {
                    mineActive2 = Instantiate(mine, transform.position, transform.rotation);
                    onGround = 2;
                    cooldownTime = 16f;
                    timestamp = Time.time + cooldownTime;
                    mineCharges--;
                }
            }
        }
    }

    public void Explode()
    {
        if (onGround > 0)
        {
            if (mineActive1 != null)
            {
                mineActive1.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
                Destroy(mineActive1);
                onGround--;
                mineCharges++;
            }

            if (mineActive2 != null)
            {
                mineActive2.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
                Destroy(mineActive2);
                onGround--;
                mineCharges++;
            }


            if (playerPos.x == transform.position.x && playerPos.y == transform.position.y)
            {
                player.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
