using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStart : MonoBehaviour, IButton
{
    public void ClickButton()
    {
        FindObjectOfType<Portal2>()?.transform.GetChild(1).gameObject.SetActive(true);
    }
}
