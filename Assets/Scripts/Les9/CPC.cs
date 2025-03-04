using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPC : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Coin>())
        {
            ManagerCoin.Instance.Coin = 1;
            Destroy(collision.gameObject.gameObject);
        }
    }
}
