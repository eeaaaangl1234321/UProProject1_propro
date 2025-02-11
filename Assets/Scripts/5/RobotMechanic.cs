using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMechanic : MonoBehaviour, IRobots
{
    public void Bring()
    {
        throw new System.NotImplementedException();
    }

    void IRobots.Greating()
    {
        Debug.Log("hello ////////");
    }

    void IRobots.Use()
    {
        Debug.Log("xnj ds [jnnbnt cnxj,s z gjxbkby");
    }
}
