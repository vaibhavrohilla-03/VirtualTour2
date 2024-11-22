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


    [SerializeField] private Material HoverMaterial;

    [SerializeField] private Material SelectMaterial;

    private Material Initialmaterial;

    private materiallerp MLinstance;

    MeshRenderer renderer;

   

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
        renderer = GetComponent<MeshRenderer>();
        Initialmaterial = renderer.material;
    }

    private void OnValidate()
    {
        if (!InteractableComp)
        {
            if(TryGetComponent(out InteractableComp))
            {
                Debug.Log("got component");
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
        //ChangeScene();
    }

    private void OnHover(HoverEnterEventArgs arg0)
    {
        changematerial(HoverMaterial);

    }

    private void OffHover(HoverExitEventArgs arg0) 
    {
        changematerial(Initialmaterial);
    }


    private void ChangeScene()
    {

        IndretsVRSceneManager sceneManager = GetComponent<IndretsVRSceneManager>();
        if (sceneManager)
            sceneManager.Teleport();
        else
            Debug.Log("manager not found");
    }

    private void changematerial(Material material)
    {
        renderer.material = material;
    }


}
