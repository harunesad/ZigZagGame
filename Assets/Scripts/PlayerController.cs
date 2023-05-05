using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 direction = Vector3.left;
    [SerializeField] float speed;
    public static bool isDead = false;
    private void Update()
    {
        if (isDead)
        {
            return;
        }
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
        if (transform.position.y < .1f)
        {
            isDead = true;
            Destroy(gameObject, 1);
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
            StartCoroutine(Destroy(collision.gameObject));
        }
    }
    #region Destroy
    IEnumerator Destroy(GameObject obj)
    {
        yield return new WaitForSeconds(.5f);
        obj.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(.5f);
        Destroy(obj);
    }
    #endregion
}
