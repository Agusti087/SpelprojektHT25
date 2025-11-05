using UnityEngine;
using UnityEngine.UI;

public class MainUIscript : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private RectTransform menu;          // Din huvudmeny
    [SerializeField] private Button settingsButton;       // Din befintliga settings-knapp

    [Header("Settings Screen")]
    [SerializeField] private GameObject settingsScreen;   // Den nya settings-skärmen
    [SerializeField] private Button backButton;           // Back-knapp på settings

    private bool menuVisible = false;

    void Start()
    {
        // Koppla knappar
        settingsButton.onClick.AddListener(OpenSettingsScreen);
        backButton.onClick.AddListener(CloseSettingsScreen);

        // Dölj settings-skärmen i början
        settingsScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuVisible = !menuVisible;
            Vector2 newPos = menu.anchoredPosition;

            if (menuVisible)
                newPos.y = 0f;
            else
                newPos.y = 321f;

            menu.anchoredPosition = newPos;
        }
    }

    private void OpenSettingsScreen()
    {
        menu.gameObject.SetActive(false);        // Dölj huvudmenyn
        settingsScreen.SetActive(true);          // Visa settings-skärmen
    }

    private void CloseSettingsScreen()
    {
        settingsScreen.SetActive(false);         // Dölj settings
        menu.gameObject.SetActive(true);         // Visa huvudmenyn igen
    }
}
