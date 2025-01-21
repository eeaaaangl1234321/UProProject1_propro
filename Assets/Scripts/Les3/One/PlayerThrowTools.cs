using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowTools : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            GetComponentInChildren<ITools>()?.Thwr();
    }
}
