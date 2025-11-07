using UnityEngine;

public class treehealth : MonoBehaviour
{
    public int health = 10;
    public bool Collided;
    public int logsGiven = 5; 
    private MainPlayer player;

    void Start()
    {
        player = FindAnyObjectByType<MainPlayer>();
    }

    void Update()
    {
        if (health <= 0)
        {
            GiveLogsToPlayer();
            Destroy(gameObject);
        }

        if (Collided && Input.GetKeyDown(KeyCode.F))
        {
            health -= 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("axe"))
        {
            Collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("axe"))
        {
            Collided = false;
        }
    }

    private void GiveLogsToPlayer()
    {
        if (player != null)
        {
            player.Logs += logsGiven;
        }
        else
        {
        }
    }
}
