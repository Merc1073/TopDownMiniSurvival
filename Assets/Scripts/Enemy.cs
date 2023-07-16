using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    public float health;
    public float moveSpeed;
    public float damage;

    public float healthDecrease;

    public Vector3 directionToPlayer;

    Rigidbody rb;

    GameObject player;

    public Slider slider;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player");


        directionToPlayer = player.gameObject.transform.position - transform.position;
        directionToPlayer.Normalize();

        directionToPlayer.y = -10;

        transform.forward = directionToPlayer;

        rb.velocity = directionToPlayer * moveSpeed;


        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            slider.value -= healthDecrease;
            health -= healthDecrease;
        }
    }

}
