using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBarTimer : MonoBehaviour
{
    public GameObject fullProgressBar;
    public Slider progressBar;
    public Text percentageText;
    public float fillDuration = 120f; // 2 minutes in seconds

    private float elapsedTime = 0f;
    private bool hasCompleted = false;
    private bool isPaused = false;

    public bool startEvent = false;

    void Start()
    {
        progressBar.minValue = 0f;
        progressBar.maxValue = 1f;
        progressBar.value = 0f;

        fullProgressBar.SetActive(false);

        // StartCoroutine(RandomPauseRoutine()); // starts a network pause...
    }

    void Update()
    {
        if (startEvent)
        {
            fullProgressBar.SetActive(true);
        }

        if (!hasCompleted && !isPaused && startEvent)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / fillDuration);
            progressBar.value = progress;

            if (percentageText != null)
                percentageText.text = Mathf.RoundToInt(progress * 100f) + "%";

            if (progress >= 1f)
            {
                DoSomething();
                hasCompleted = true;
            }
        }
    }

    void DoSomething()
    {
        Debug.Log("Progress bar full! Do something here...");
        // Your logic here
    }

    IEnumerator RandomPauseRoutine()
    {
        while (!hasCompleted)
        {
            // Wait a random time before pausing
            yield return new WaitForSeconds(Random.Range(5f, 15f));

            // Pause
            isPaused = true;
            Debug.Log("Network interruption...");
            percentageText.text = "NETWORK ERROR...";

            // Pause duration: 1–5 seconds
            float pauseDuration = Random.Range(1f, 5f);
            yield return new WaitForSeconds(pauseDuration);

            // Resume
            isPaused = false;
            Debug.Log("Network resumed.");
        }
    }
}
