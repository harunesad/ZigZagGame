using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 distance;
    private void Start()
    {
        distance = transform.position - target.transform.position;
    }
    private void LateUpdate()
    {
        if (PlayerController.isDead)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, target.transform.position + distance, Time.deltaTime * 5);
    }
}
