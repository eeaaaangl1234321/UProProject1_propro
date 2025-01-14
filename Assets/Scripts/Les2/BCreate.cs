using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCreate : MonoBehaviour, IButton
{
    [SerializeField] private GameObject portal;
    public void ClickButton()
    {
        Instantiate(portal);
    }
}
