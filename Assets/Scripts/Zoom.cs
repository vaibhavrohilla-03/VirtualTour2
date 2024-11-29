using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    [SerializeField] private Camera TransitionCamera;
    [SerializeField] private Camera XRCamera;
    [SerializeField] private float FinalFieldOfView;
    [SerializeField] private LeanTweenType CurveType = LeanTweenType.easeOutExpo;
    public float duration = 3.0f;

    private float height;

    void Start()
    {
        TransitionCamera.enabled = false;
        XRCamera.enabled = true;
        height = TransitionCamera.gameObject.transform.position.y;
    }
    private void SwitchCamera()
    {
        TransitionCamera.enabled = !TransitionCamera.enabled;
        XRCamera.enabled = !XRCamera.enabled;
        TransitionCamera.transform.LookAt(new Vector3(gameObject.transform.position.x,height,0));
    }

    public void  MakeZoom()
    {
        SwitchCamera();

        LeanTween.value(TransitionCamera.gameObject, TransitionCamera.fieldOfView, FinalFieldOfView, duration)
            .setEase(CurveType)
            .setOnUpdate((float value) =>
            {
                TransitionCamera.fieldOfView = value; // Update the field of view
            })
            .setOnComplete(() =>
            {
            Debug.Log("Zoom executed");
            });
    }
}
