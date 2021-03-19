using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spawnManager;
    public GameObject Player;
    private float bulletSpeed = 30f;
    private Vector3 offset = new Vector3(0, -2, 0);

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager");
        InvokeRepeating("SpawnBullet", UnityEngine.Random.Range(1f, 1.6f), UnityEngine.Random.Range(1f, 1.6f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBullet()
    {
        if (spawnManager.GetComponent<SpawnManager>().gameOver == false)
        {
            Vector3 spawnPos = transform.position + offset;
            var projectile = Instantiate(bulletPrefab, spawnPos, bulletPrefab.transform.rotation);
            transform.LookAt(Player.transform.position);
            projectile.transform.LookAt(Player.transform.position);
            projectile.GetComponent<Rigidbody>().velocity = (Player.transform.position - projectile.transform.position).normalized * bulletSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            if (spawnManager.GetComponent<SpawnManager>().amount != 0)
            {
                spawnManager.GetComponent<SpawnManager>().amount = spawnManager.GetComponent<SpawnManager>().amount - 1;
            }
            spawnManager.GetComponent<SpawnManager>().score = spawnManager.GetComponent<SpawnManager>().score + 1;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
