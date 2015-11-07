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
        text = GetComponent<Text>();
        text.text = "";
        text.color = new Color(1f, 1f, 1f, 0f);
    }

    public void PopPrompt(string message, float displayTime = 2f, float transitionTime = 1f)
    {
        StartCoroutine(PPC(message, displayTime, transitionTime));
    }

    IEnumerator PPC(string message, float displayTime = 2f, float transitionTime = 1f)
    {
        print("Prompt Init");
        text.text = message;
        StartCoroutine(FadeToColor(transitionTime));
        yield return new WaitForSeconds(transitionTime);
        StartCoroutine(FadeToInvis(transitionTime));
        print("Prompt Ended");
        yield return null;
    }

    IEnumerator FadeToColor(float time)
    {
        print("Fade to Color " + time);
        for (float i = 0f; i < 1.0f; i += (1.0f / time * Time.deltaTime)) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            print(i);
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        yield return null;
    }

    IEnumerator FadeToInvis(float time)
    {
        print("fade to Invisi " + time);
        for (float i = 1f; i > 0f; i -= (1.0f / time * Time.deltaTime)) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        yield return null;
    }
}
