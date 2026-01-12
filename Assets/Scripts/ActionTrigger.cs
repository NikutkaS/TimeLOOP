using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    private bool activated;

    public void Activate()
    {
        if (activated) return;
        activated = true;

        if (TimeManager.Instance != null)
            TimeManager.Instance.ActionCompleted(transform.position);
        else
            Debug.LogError("TimeManager.Instance is null! Добавь TimeManager на сцену.");

        gameObject.SetActive(false);
    }
}
