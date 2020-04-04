using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnPlay : MonoBehaviour
{
    public MeshRenderer MeshRenderer;
    private void OnEnable()
    {
        MeshRenderer.enabled = true;
    }
}
