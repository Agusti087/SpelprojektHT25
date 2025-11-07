using UnityEngine;

public class FireBarBehaviour : MonoBehaviour
{
    [SerializeField] private RectTransform FillBar;

    private float maxWidth;

    private float burnTime;
    private float maxBurnTime;

    public void SetMaxBurnTime(float maxTime)
    {
        maxBurnTime = maxTime;
        burnTime = maxTime;

        if (FillBar != null)
        {
            // Store the original width as full bar
            maxWidth = FillBar.rect.width;
            FillBar.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void SetBurnTime(float time)
    {
        burnTime = Mathf.Clamp(time, 0, maxBurnTime);

        if (FillBar != null)
        {
            // Set fill scale based on ratio
            float ratio = maxBurnTime > 0 ? (burnTime / maxBurnTime) : 0f;
            FillBar.localScale = new Vector3(ratio, 1f, 1f);
        }
    }
}