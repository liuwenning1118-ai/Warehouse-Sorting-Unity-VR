using UnityEngine;
using TMPro;
using System.Collections;

public class VRNotificationManager : MonoBehaviour
{
    [Header("UI Components")]
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI notificationText;

    [Header("Configuration Parameters")]
    public float displayDuration = 3.0f; 
    public float fadeSpeed = 2.0f;   

    private Coroutine currentCoroutine;

    [ContextMenu("Test Notification")]
    public void TestNotification()
    {
        ShowNotification("QC Validation: Sorting Successful!\nTarget SKU matches.");
    }

    public void ShowNotification(string message)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(FadeInOutRoutine(message));
    }

    private IEnumerator FadeInOutRoutine(string message)
    {
        // 1. Update text content
        notificationText.text = message;

        // 2. Fade In
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        // 3. Hold
        yield return new WaitForSeconds(displayDuration);

        // 4. Fade Out
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}