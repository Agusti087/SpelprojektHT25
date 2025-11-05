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

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            player.Logs += 5;
            
        }
        if (Collided == true && Input.GetKeyDown(KeyCode.F))
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
       /* else
        {
            TreeCollision();
        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("axe"))
        {
            Collided = false;
        }
    }
    void TreeCollision()
    {
        
            Collided = false;
        
    }
}

