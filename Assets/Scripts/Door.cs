using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D col;
    private SpriteRenderer sr;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        IsOpen = true;
        if (col != null) col.enabled = false;
        if (sr != null) sr.enabled = false;
    }

    public void Close()
    {
        IsOpen = false;
        if (col != null) col.enabled = true;
        if (sr != null) sr.enabled = true;
    }
}
