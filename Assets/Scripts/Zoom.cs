using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    //[SerializeField] private Camera TransitionCamera;
    [SerializeField] private Camera XRCamera;
    [SerializeField] private float FinalFieldOfView = 30.0f;
    [SerializeField] private LeanTweenType CurveType = LeanTweenType.easeOutExpo;
    public float duration = 3.0f;


    private void Awake()
    {
        OnValidate();
    }
    private void OnValidate()
    {
        XRCamera = Camera.main;
    }

    public void  MakeZoom()
    {
       // SwitchCamera();

        LeanTween.value(XRCamera.gameObject, XRCamera.fieldOfView, FinalFieldOfView, duration)
            .setEase(CurveType)
            .setOnUpdate((float value) =>
            {
                XRCamera.fieldOfView = value;  // Update the field of view


            })
            .setOnComplete(() =>
            {
            Debug.Log("Zoom executed");
            });
    }
}
