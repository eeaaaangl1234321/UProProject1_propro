using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSetting : MonoBehaviour, IButton
{
    public void ClickButton()
    {
        FindObjectOfType<Portal2>()?.transform.GetChild(0).gameObject.SetActive(true);
    }
}
