using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using IndretsVRVirtualTour;
using TMPro;


public class Hotspot : MonoBehaviour
{


    [SerializeField] private XRSimpleInteractable InteractableComp;
    private Material Initialmaterial;

    [SerializeField] private Material HoverMaterial;

    private materiallerp MLinstance;

    MeshRenderer renderer;
    private void Start()
    {
        OnValidate();
        InteractableComp.selectEntered.AddListener(ChangeScene);
        InteractableComp.hoverEntered.AddListener(OnHover);
        InteractableComp.hoverExited.AddListener(OffHover);
        Debug.Log("start initiated");
        MLinstance = GetComponent<materiallerp>();
        renderer = GetComponent<MeshRenderer>();
        Initialmaterial = renderer.material;
    }

    private void OnValidate()
    {
        if (InteractableComp != null)
        {
            if(TryGetComponent(out InteractableComp))
            {
                Debug.Log("got component");
            }

        }
    }

    private void ChangeScene(SelectEnterEventArgs arg0)
    {
        Debug.Log("ENTERED");

        IndretsVRSceneManager sceneManager = arg0.interactableObject.transform.GetComponent<IndretsVRSceneManager>();
        if (sceneManager)
            sceneManager.Teleport();
        else
            Debug.Log("manager not found");
    }

    private void changematerial(Material material)
    {
        renderer.material = material;
    } 


    private void OnHover(HoverEnterEventArgs arg0)
    {
        MLinstance.enabled = false;
        changematerial(HoverMaterial);

    }

    private void OffHover(HoverExitEventArgs arg0) 
    {
        changematerial(Initialmaterial);
        MLinstance.enabled = true;
    }
}
