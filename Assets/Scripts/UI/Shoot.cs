using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPf;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.Q)) {
            shoot();
        }
    }

    void shoot() {
        GameObject bullet = Instantiate(bulletPf, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * 20.0f, ForceMode2D.Impulse);
    }
}
