using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class materiallerp : MonoBehaviour
{
    private Material material;
    public float fadeDuration = 1.0f;
    private bool isFadingIn = true;

    void Start()
    {
        material = GetComponent<Renderer>().material;

        // Start the fade effect with LeanTween
        FadeIn();
    }

    void Update()
    {

            if (isFadingIn)
            {
                FadeOut();
            }
            else
            {
                FadeIn();
            }
        
    }

    private void FadeIn()
    {
        isFadingIn = true;

        // Use LeanTween to animate the alpha value from 0 to 1 (fade in)
        LeanTween.value(gameObject, 0f, 1f, fadeDuration)
            .setOnUpdate((float alpha) => SetAlpha(alpha));
    }

    private void FadeOut()
    {
        isFadingIn = false;

        // Use LeanTween to animate the alpha value from 1 to 0 (fade out)
        LeanTween.value(gameObject, 1f, 0f, fadeDuration)
            .setOnUpdate((float alpha) => SetAlpha(alpha));
    }

    private void SetAlpha(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }
}
