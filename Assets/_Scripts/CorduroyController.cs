using UnityEngine;
using System.Collections;

public class CorduroyController : MonoBehaviour
{
    public float speed = 0.02f;
    private Vector2 initPosition;

    void Start()
    {
        initPosition = gameObject.transform.position;
        Physics2D.IgnoreLayerCollision(7, 8, false); // resets collisions each time the scene reloads
    }

    void Update()
    {
        if(GameManager.isScreenFrozen == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (gameObject.transform.position.y <= 0.5)
                {
                    Vector2 pos = new Vector2(
                        gameObject.transform.position.x,
                        gameObject.transform.position.y + speed);
                    gameObject.transform.position = pos;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (gameObject.transform.position.y >= -4)
                {
                    Vector2 pos = new Vector2(
                        gameObject.transform.position.x,
                        gameObject.transform.position.y - speed);
                    gameObject.transform.position = pos;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            HealthController.health--;
            AudioManager.instance.Play("TakeDamage");
            StartCoroutine(GetHurt());
            if (HealthController.health <= 0)
            {
                GameManager.isGameOver = true;
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
