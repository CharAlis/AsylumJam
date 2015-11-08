using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PromptSystem : MonoBehaviour
{
    public static PromptSystem Instance;
    private Text text;

    void Awake()
    {
        Instance = this;
		text = GameObject.Find("PromptText").GetComponent<Text>();
        text.text = "";
        text.color = new Color(1f, 1f, 1f, 0f);
    }

    public void PopPrompt(string message, float displayTime = 2f, float transitionTime = 1f)
    {
        StartCoroutine(PPC(message, displayTime, transitionTime));
    }

    IEnumerator PPC(string message, float displayTime = 2f, float transitionTime = 1f)
    {
        text.text = message;
        StartCoroutine(FadeToColor(transitionTime));
        yield return new WaitForSeconds(displayTime);
        StartCoroutine(FadeToInvis(transitionTime));
        yield return null;
    }

    IEnumerator FadeToColor(float time)
    {
        for (float i = 0f; i < 1.0f; i += (1.0f / time * Time.deltaTime)) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        yield return null;
    }

    IEnumerator FadeToInvis(float time)
    {
        for (float i = 1f; i > 0f; i -= (1.0f / time * Time.deltaTime)) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        yield return null;
    }
}
