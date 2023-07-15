using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireCooldown;
    public float fireRate;

    bool isFireCooldownOn = false;

    public GameObject bullet;
    public GameObject gunBarrel;



    private void Update()
    {

        gunBarrel = GameObject.FindGameObjectWithTag("GunBarrel");


        if(isFireCooldownOn == true)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (fireCooldown < 0f)
        {
            fireCooldown = fireRate;
            isFireCooldownOn = false;
        }



        if (Input.GetKey(KeyCode.Mouse0) && fireCooldown == fireRate && gameObject.GetComponent<Player>().isGunEquipped == true)
        {

            isFireCooldownOn = true;

            GameObject clone;
            Vector3 position = gunBarrel.transform.position;


            clone = Instantiate(bullet, position, gunBarrel.transform.rotation);

        }
    }




}
