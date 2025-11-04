using UnityEngine;
using UnityEngine.UI; // Needed if you're using a UI Slider

public class BarController : MonoBehaviour
{
    [Header("Bar Settings")]
    public Slider barSlider; // Reference to your UI Slider
    public float fillSpeed = 10f; // How fast the bar fills per second

    [Header("Player Settings")]
    public GameObject player; // Reference to the player GameObject

    private float barValue = 0f; // Current value of the bar

    void Update()
    {
        // Fill the bar over time
        barValue += fillSpeed * Time.deltaTime;

        // Update the UI
        if (barSlider != null)
            barSlider.value = barValue;

        // Check if bar is full
        if (barValue >= 100f)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        if (player != null)
        {
            // Destroy player object (or implement your death logic)
            Destroy(player);

            // Optional: reset bar so it doesn't keep trying to kill
            barValue = 0f;
        }
    }
}

