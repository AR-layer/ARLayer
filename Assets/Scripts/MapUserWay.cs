using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapUserWay : MonoBehaviour
{
    public Material selectedMaterial;
    public Material unselectedMaterial;
    
    private string prevRoomName = "";

    public void ShowTargetRoom()
    {
        GameObject changeAreaComponent;

        if(prevRoomName!="")
        {
            changeAreaComponent = GameObject.Find(prevRoomName);
            changeAreaComponent.GetComponent<MeshRenderer>().material = unselectedMaterial;
        }


        string roomName = EventSystem.current.currentSelectedGameObject.name.TrimEnd('B');
        prevRoomName = roomName;
        changeAreaComponent = GameObject.Find(roomName);
        

        MeshRenderer meshRenderer = changeAreaComponent.GetComponent<MeshRenderer>();
        Material oldMaterial = meshRenderer.material;
        meshRenderer.material = selectedMaterial;
    }
}
