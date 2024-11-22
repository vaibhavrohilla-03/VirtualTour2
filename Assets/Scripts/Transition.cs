using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    private float FieldOfView;
    [SerializeField] private float FinalFieldOfView = 20.0f;

    private Vector3 hotspotdirection;


    private void Start()
    {
         

        
    }




    private IEnumerator Maketransition()
    {
        

        yield return null;

    }

    private void Starttranstion()
    {
        StartCoroutine(Maketransition());
    }

}
