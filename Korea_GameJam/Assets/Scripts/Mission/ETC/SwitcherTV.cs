using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherTV : MonoBehaviour
{
    [SerializeField] private Material changeMaterial;
    [SerializeField] private MeshRenderer[] materials;

    public void TvTextureChange()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].material = changeMaterial;
        }
    }
}
