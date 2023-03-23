using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del objeto Bullet
    public Transform spawnPoint;
    public float bulletSpeed = 1000f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("limit") || collision.gameObject.layer == LayerMask.NameToLayer("barrier") || collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(collision.gameObject); // Destruir objeto de limit o barrier original
            Destroy(gameObject); // Destruir la bala
        }
    }

}
