using UnityEngine;

public class MainUIscript : MonoBehaviour
{
    [SerializeField] private RectTransform menu;

    private bool menuVisible = false; // håller koll på om menyn är nere eller uppe

    void Update()
    {
        // När man trycker på E
        if (Input.GetKeyDown(KeyCode.E))
        {
            menuVisible = !menuVisible; // växla mellan true/false

            Vector2 newPos = menu.anchoredPosition;

            if (menuVisible)
                newPos.y = 0f; // visa menyn
            else
                newPos.y = 321f; // göm menyn offscreen

            menu.anchoredPosition = newPos;
        }
    }
}
