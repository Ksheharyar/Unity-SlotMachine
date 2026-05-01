using UnityEngine;

public class ReelSpin : MonoBehaviour
{
    public Transform symbolContainer;

    public float speed = 5f;
    public float spinTime = 2f;
    public Transform slotWindowCenter;

    bool spinning = false;

    Sprite forcedSprite = null;

    float spacing = 1.5f;

    void Update()
    {
        if (!spinning) return;

        symbolContainer.localPosition += Vector3.down * speed * Time.deltaTime;

        if (symbolContainer.localPosition.y <= -3f)
        {
            symbolContainer.localPosition =
                new Vector3(0, 3f, 0);
        }
    }

    public void StartSpin()
    {
        spinning = true;

        Invoke(nameof(StopSpin), spinTime);
    }

    public void SetForcedSprite(Sprite sprite)
    {
        forcedSprite = sprite;
    }

    void StopSpin()
    {
        spinning = false;

        Vector3 pos = symbolContainer.localPosition;

        pos.y = Mathf.Round(pos.y / spacing) * spacing;

        pos.y = Mathf.Clamp(pos.y, -1.5f, 1.5f);

        symbolContainer.localPosition = pos;

        ApplyForcedMiddleSymbol();
    }
    void ApplyForcedMiddleSymbol()
    {
        if (forcedSprite == null) return;

        Transform closest = null;

        float smallestDistance = Mathf.Infinity;

        float centerY = transform.position.y;

        foreach (Transform child in symbolContainer)
        {
            float distance = Mathf.Abs(child.position.y - centerY);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closest = child;
            }
        }

        closest.GetComponent<SpriteRenderer>().sprite = forcedSprite;
    }

    public string GetMiddleSymbol()
    {
        Transform closest = null;

        float smallestDistance = Mathf.Infinity;

        float centerY = transform.position.y;

        foreach (Transform child in symbolContainer)
        {
            float distance = Mathf.Abs(child.position.y - centerY);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closest = child;
            }
        }

        return closest.GetComponent<SpriteRenderer>().sprite.name;
    }
}