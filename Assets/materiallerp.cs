using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class materiallerp : MonoBehaviour
{
    private Material material;
    public float fadeDuration = 1.0f;
    private bool isFadingIn = true;
    private float timeElapsed = 0f;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (isFadingIn)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            SetAlpha(alpha);

            if (timeElapsed >= fadeDuration)
            {
                timeElapsed = 0f;
                isFadingIn = false;
            }
        }
        else
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration);
            SetAlpha(alpha);

            if (timeElapsed >= fadeDuration)
            {
                timeElapsed = 0f;
                isFadingIn = true;
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }
}
