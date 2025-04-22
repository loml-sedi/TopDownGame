using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    int count = 0;
    public GameObject gameOverScreen;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        count = count + 1;

        if (life < 1)
        {
            Destroy(hearts[0].gameObject);

            // Should be a script to handle death of the player.
            gameOver();




        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }

    public void TakeDamage(int d)
    {
        life -= d;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            TakeDamage(1);
            if (life < 1)
            {
                restartGame();
            }
        }

       


    }
    
 
}