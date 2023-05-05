using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
