using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaiter : MonoBehaviour, IRobots, IWAITer
{
    [SerializeField] protected GameObject _coffe;
    public virtual void Bring()
    {
        Debug.Log("Jn dfi rjat");
        Instantiate(_coffe, transform.position+ new Vector3(0f, 1f, -1f), Quaternion.identity);
    }

    public void Greating()
    {
        Debug.Log("hello /////");
    }

    public virtual void Use()
    {
        Debug.Log("[jxbnt djls???????? kflyj e; rjat");
    }
}
