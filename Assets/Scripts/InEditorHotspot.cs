using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class InEditorHotspot : MonoBehaviour
{
    private void Awake()
    {
        OnValidate();
    }
    private void OnValidate()
    {
        gameObject.AddComponent<XRSimpleInteractable>();
        gameObject.AddComponent<Hotspot>();
        gameObject.AddComponent<Zoom>();
        gameObject.AddComponent<ChangeScene>();
    }

}
