using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 4.8f, -18);
    public GameObject spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.GetComponent<SpawnManager>().gameOver == false)
        {
            transform.position = player.transform.position + player.transform.TransformDirection(offset);
            transform.LookAt(player.transform);
        }
    }
}
