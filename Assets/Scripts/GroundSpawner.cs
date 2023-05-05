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
        Vector3 direction;

        if (Random.Range(0, 2) == 0)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.back;
        }
        lastGround = Instantiate(groundPrefab, lastGround.transform.position + direction, lastGround.transform.rotation);
    }
}