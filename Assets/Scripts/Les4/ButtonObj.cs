using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObj : MonoBehaviour
{
    [SerializeField]
    public Button button;
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            Debug.Log("Lvlup");
        });
    }

   
}
