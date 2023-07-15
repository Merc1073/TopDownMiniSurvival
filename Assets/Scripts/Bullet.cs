using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;

    public float bulletSpeed;

    GameObject gunBarrel;

    public float lifeTime;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        lifeTime -= Time.deltaTime;

        gunBarrel = GameObject.FindGameObjectWithTag("GunBarrel");

        rb.velocity = transform.up * bulletSpeed;

        if(lifeTime <= 0f)
        {
            Destroy(this.gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }


}
