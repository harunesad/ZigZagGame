using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 direction = Vector3.left;
    [SerializeField] float speed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.back;
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.position += movement;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GroundSpawner.groundSpawner.GroundSpawn();
            DestroyObject(collision.gameObject);
        }
    }
    void DestroyObject(GameObject obj)
    {
        Destroy(obj, 3);
    }
}
