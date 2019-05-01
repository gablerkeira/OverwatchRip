using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concussion_Mine : MonoBehaviour
{
    public bool OnGround;
    public GameObject mine;
    public GameObject newMine;
    public float explosionForce = 3f;
    public float explosionRadius = 6f;
    public GameObject player;
    public Vector3 playerPos;

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
        if(OnGround == false)
        {
            newMine = Instantiate(mine, transform.position, transform.rotation);
            OnGround = true;
        }
    }

    public void Explode()
    {
        if(OnGround == true)
        {
            newMine.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius);
            if(playerPos.x == transform.position.x && playerPos.y == transform.position.y)
            {
                player.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
