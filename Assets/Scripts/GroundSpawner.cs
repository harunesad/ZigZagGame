using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner groundSpawner;
    [SerializeField] GameObject groundPrefab, lastGround;
    private void Awake()
    {
        groundSpawner = this;
    }
    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GroundSpawn();
        }
    }

    public void GroundSpawn()
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