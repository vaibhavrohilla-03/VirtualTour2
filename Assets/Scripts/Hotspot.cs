using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using IndretsVRVirtualTour;
using TMPro;
using UnityEngine.SceneManagement;


public class Hotspot : MonoBehaviour
{


    [SerializeField] private XRSimpleInteractable InteractableComp;
    [SerializeField] private Zoom ZoomComp;
    [SerializeField] private ChangeScene SceneComp;

    [SerializeField] private Material HoverMaterial;

    [SerializeField] private Material SelectMaterial;




    private Material Initialmaterial;

    private materiallerp MLinstance;

    MeshRenderer _renderer;

   

    private void Awake()
    {
        OnValidate();

    }
    private void Start()
    {
       
        InteractableComp.selectEntered.AddListener(OnSelectEnter);
        InteractableComp.selectExited.AddListener(OnSelectExit);
        InteractableComp.hoverEntered.AddListener(OnHover);
        InteractableComp.hoverExited.AddListener(OffHover);
        Debug.Log("start initiated");
        MLinstance = GetComponent<materiallerp>();
        _renderer = GetComponent<MeshRenderer>();
        Initialmaterial = _renderer.material;
    }

    private void OnValidate()
    {
        if (!InteractableComp)
        {
            if (TryGetComponent(out InteractableComp))
            {
                Debug.Log("got component");
            }
        }
        if (!ZoomComp)
        {
            if (TryGetComponent(out ZoomComp))
            {
                Debug.Log("got zoom comp");
            }

        }
        if (!SceneComp)
        {
            if (TryGetComponent(out SceneComp))
            {
                Debug.Log("got SceneComp");
            }
        }
    }

 

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        changematerial(SelectMaterial);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        changematerial(Initialmaterial);
        StartCoroutine(Transition());
    }

    private void OnHover(HoverEnterEventArgs arg0)
    {
        changematerial(HoverMaterial);

    }

    private void OffHover(HoverExitEventArgs arg0) 
    {
        changematerial(Initialmaterial);
    }

    private void changematerial(Material material)
    {
        _renderer.material = material;
    }

    IEnumerator Transition()
    {   
        ZoomComp.MakeZoom();

        yield return new WaitForSeconds(ZoomComp.duration + 0.5f);

        SceneComp.Change();

    }



}
