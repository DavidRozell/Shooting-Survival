using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xRangeLeft = 57f;
    private float xRangeRight = 63f;
    private float zRangeBottom = 49f;
    private float zRangeTop = 80f;
    private float speed = 20.0f;
    private float turnSpeed = 175.0f;
    private float bulletSpeed = 60f;
    private float horizontalInput;
    private float forwardInput;
    public GameObject projectilePrefab;
    public GameObject spawnManager;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (transform.position.x < -xRangeLeft)
         {
             transform.position = new Vector3(-xRangeLeft, transform.position.y, transform.position.z);
         }

         if (transform.position.x > xRangeRight)
         {
             transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);
         }

        if (transform.position.z < -zRangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRangeBottom);
        }

        if (transform.position.z > zRangeTop)
         {
             transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
         }

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = gun.transform.position;
            var projectile = Instantiate(projectilePrefab, spawnPos, projectilePrefab.transform.rotation);
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<Rigidbody>().velocity = (gameObject.transform.forward * bulletSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Game Over!");
            spawnManager.GetComponent<SpawnManager>().gameOver = true;
        }
    }
}
