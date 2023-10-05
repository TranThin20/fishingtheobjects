using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CloudRend : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Transform spawnPoint;
    private float spawnInterval = 5.0f;
    private float cloudSpeed;
    private int numberOfClouds = 5;

    private ObjectPool cloudPool;
    private float nextSpawnTime;

    private void Start()
    {
        cloudPool = new ObjectPool(cloudPrefab, numberOfClouds);
        nextSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            GameObject cloudObject = cloudPool.GetObject();
            if (cloudObject != null)
            {
                Move cloudMove = cloudObject.GetComponent<Move>();
                int spawn = Random.Range(0, 2);
                if(spawn == 0)
                {
                    cloudObject.transform.position = spawnPoint.position + new Vector3(0f, 0f, 0f);
                    cloudObject.transform.localScale = new Vector3(1.1f, 1.1f, 0f);
                }
                else
                {
                    cloudObject.transform.position = spawnPoint.position + new Vector3(0f,0.5f,0f);
                    cloudObject.transform.localScale = new Vector3(0.9f, 0.9f, 0f);
                }
            }

                //cloudMove.moveSpeed = cloudSpeed;
                cloudSpeed = CloudMove.instance.moveSpeed;
                cloudObject.SetActive(true);
                nextSpawnTime = Time.time + spawnInterval;
            }
        }
}
