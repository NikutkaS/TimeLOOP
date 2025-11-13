using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [Header("Настройки петли")]
    public float loopDuration = 10f; 
    private float timer;

    [Header("UI таймер (TMP)")]
    public TMP_Text timerText;

    private bool isLoopActive = true;

    public float CurrentTime { get { return timer; } }

    void Start()
    {
        timer = loopDuration;
        UpdateTimerUI();
    }

    void Update()
    {
        if (!isLoopActive) return;

        timer -= Time.deltaTime;

        UpdateTimerUI();

        if (timer <= 0f)
        {
            StartCoroutine(RestartLoop());
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.Max(0, timer).ToString("F1") + "s";
        }
    }

    private IEnumerator RestartLoop()
    {
        isLoopActive = false;

        Debug.Log("⏳ Петля завершена!");

        yield return new WaitForSeconds(0.5f);

        timer = loopDuration;
        isLoopActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
