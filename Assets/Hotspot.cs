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
    [SerializeField] private Color Initialcolor;
    [SerializeField] private Color HoveredColor;

    private void Start()
    {
        OnValidate();
        InteractableComp.selectEntered.AddListener(change);
       // InteractableComp.hoverEntered.AddListener(Materialchange);
        Debug.Log("start initiated");

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

    private void change(SelectEnterEventArgs arg0)
    {
        Debug.Log("ENTERED");

        IndretsVRSceneManager sceneManager = arg0.interactableObject.transform.GetComponent<IndretsVRSceneManager>();
        if (sceneManager)
            sceneManager.Teleport();
        else
            Debug.Log("manager not found");
    }

    private void changematerial(Color color)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer == null)
        {
            return;
        }
        Material mat = renderer.material;
        mat.SetColor("_BaseColor", color);
    } 



}
