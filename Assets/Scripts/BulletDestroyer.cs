using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private float BoundZ = 100;
    private float BoundX = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > BoundZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -BoundZ)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > BoundX)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -BoundX)
        {
            Destroy(gameObject);
        }
    }
}
