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

    private void Start()
    {
        OnValidate();
        InteractableComp.selectEntered.AddListener(change);
        InteractableComp.hoverEntered.AddListener(Materialchange);
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
        if (!arg0.interactorObject.transform.TryGetComponent(out IndretsVRSceneManager sceneManager))
            return;

        sceneManager.Teleport();
    }

    private void Materialchange(HoverEnterEventArgs arg0)
    {
        Debug.Log("hovering");
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer == null)
        {
            Debug.LogError("MeshRenderer not found!");
            return;
        }

        // Check if material is correctly accessed
        Material mat = renderer.material;
        Debug.Log(mat.color);
        if (mat == null)
        {
            Debug.LogError("Material not found!");
            return;
        }

        // Set the color
        mat.SetColor("_BaseColor",Color.green);
        Debug.Log("Color set to green.");
    }


}
