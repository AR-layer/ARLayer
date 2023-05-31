using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapUserWay : MonoBehaviour
{
    public Material newMaterial;

    public void ShowTargetRoom()
    {
        string btnName = EventSystem.current.currentSelectedGameObject.name.TrimEnd('B');
        GameObject changeAreaComponent = GameObject.Find(btnName);
        MeshRenderer meshRenderer = changeAreaComponent.GetComponent<MeshRenderer>();
        Material oldMaterial = meshRenderer.material;
        Debug.Log("Applied Material: " + oldMaterial.name);
        meshRenderer.material = newMaterial;
    }
}
