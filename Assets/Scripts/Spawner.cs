using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    private float timeUntilObstacleSpawn;
    public float obstacleSpeed = 12f;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRb = spawnObstacle.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = Vector2.left * obstacleSpeed;
    }
}
