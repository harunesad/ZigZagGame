using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 direction = Vector3.left;
    [SerializeField] float speed;
    public float speedMultiplier;
    float score;
    [SerializeField] Text scoreText, bestScoreText;
    string bestScoreKey = "BestScore";
    public GameObject restartPanel, playGamePanel;
    private void Start()
    {
        if (RestartGame.isRestart)
        {
            playGamePanel.SetActive(false);
        }
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetFloat(bestScoreKey);
    }
    private void Update()
    {
        if (RestartGame.isDead)
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
            RestartGame.isDead = true;
            Destroy(gameObject, 1);
            restartPanel.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (RestartGame.isDead)
        {
            return;
        }
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.position += movement;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GroundSpawner.groundSpawner.GroundSpawn();
            StartCoroutine(DestroyObject(collision.gameObject));
        }
    }
    #region Destroy
    IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(.2f);
        obj.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 5;
            if (PlayerPrefs.GetFloat(bestScoreKey) < score)
            {
                PlayerPrefs.SetFloat(bestScoreKey, score);
                scoreText.color = Color.blue;
            }
            scoreText.text = "Score: " + score;
            //bestScoreText.text = "Best Score: " + PlayerPrefs.GetFloat(bestScoreKey);
            Destroy(other.gameObject);
            if (score %30 == 0)
            {
                speed += .1f;
            }
        }
        if (other.CompareTag("Powerup"))
        {
            float speedReduce = speed / 100;
            speed -= speedReduce;
            Destroy(other.gameObject);
        }
    }
    public void Play()
    {
        RestartGame.isDead = false;
        playGamePanel.SetActive(false);
    }
}
