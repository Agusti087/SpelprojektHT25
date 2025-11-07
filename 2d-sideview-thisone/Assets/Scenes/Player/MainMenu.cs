using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Måste matcha EXAKT scenens namn
        SceneManager.LoadScene("Gabou Samplescene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
