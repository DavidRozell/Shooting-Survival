using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject enemyPrefab;
    public GameObject Player;
    private float spawnRangeX = 30f;
    private float spawnRangeZ = 30f;
    private float startDelay = 1f;
    private float offset = 5f;
    public float amount = 0f;
    public float score = 0f;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, UnityEngine.Random.Range(1f, 1.6f));
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Kills: " + score;
    }

    void SpawnEnemy()
    {
        if (gameOver == false & amount < 5)
        {
            amount = amount + 1;
            Vector3 spawnPosEnemy = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), offset, Random.Range(-spawnRangeZ, spawnRangeZ));
            var enemy = Instantiate(enemyPrefab, spawnPosEnemy, enemyPrefab.transform.rotation);
            enemy.transform.LookAt(Player.transform);
        }
    }
}
