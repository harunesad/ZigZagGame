using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab, lastGround;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GroundSpawn();
        }
    }

    void GroundSpawn()
    {
        lastGround = Instantiate(groundPrefab, lastGround.transform.position + Vector3.back, lastGround.transform.rotation);
    }
}