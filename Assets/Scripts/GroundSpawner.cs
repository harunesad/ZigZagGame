using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner groundSpawner;
    [SerializeField] GameObject groundPrefab, lastGround, coin, powerup;
    private void Awake()
    {
        groundSpawner = this;
    }
    private void Start()
    {
        for (int i = 0; i < 10; i++)
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
        float random = Random.Range(0, 20);
        if (random == 1 || random == 10)
        {
            lastGround.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (random == 12)
        {
            lastGround.transform.GetChild(1).gameObject.SetActive(true);
        }
        lastGround = Instantiate(groundPrefab, lastGround.transform.position + direction, lastGround.transform.rotation);
    }
}