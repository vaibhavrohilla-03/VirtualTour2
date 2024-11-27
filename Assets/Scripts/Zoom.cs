using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    [SerializeField] private Camera TransitionCamera;
    [SerializeField] private Camera XRCamera;
    [SerializeField] private float FinalFieldOfView;
    [SerializeField] private float duration;
    private float TimeElapsed;

    void Start()
    {
        TransitionCamera.enabled = false;
        XRCamera.enabled = true;
    }
    public void SwitchCamera()
    {
        TransitionCamera.enabled = !TransitionCamera.enabled;
        XRCamera.enabled = !XRCamera.enabled;
        TransitionCamera.transform.LookAt(gameObject.transform.position);
    }

    public void StartTransition()
    {

        StartCoroutine(MakeZoom());
    }

    IEnumerator MakeZoom()
    {   
        yield return new WaitForSeconds(0.2f);
        SwitchCamera();
        yield return new WaitForSeconds(0.6f);

        while(TimeElapsed < duration)
        {
            float t = TimeElapsed / duration;
            float lerpedValue = Mathf.Lerp(TransitionCamera.fieldOfView, FinalFieldOfView, t);
            TimeElapsed += Time.deltaTime;
            TransitionCamera.fieldOfView = lerpedValue; 
        }

        yield return new WaitForSeconds(0.5f);

    }
}
