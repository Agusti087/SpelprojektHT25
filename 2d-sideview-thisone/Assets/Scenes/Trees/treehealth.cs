using UnityEngine;

public class treehealth : MonoBehaviour
{
    public int health = 10;
    public bool Collided;
    MainPlayer player;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            player.Logs += 5;
            
        }

        if (Collided && Input.GetKeyDown(KeyCode.F))
        {
            health -= player.AxeDamage;
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
