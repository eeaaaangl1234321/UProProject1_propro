using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenBox : MonoBehaviour, IButtonn
{
    public GameObject Box; 
    

    public void OnClick()
    {
        foreach(iDoor door in Box.GetComponentsInChildren<iDoor>())
        {
            door.OpenDoor();
        }
    }

    
}


