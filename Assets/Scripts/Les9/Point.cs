using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] CreatePlayer createPlayer;
    [SerializeField] FindCharacter[] findCharater;

    private void Awake()
    {
        createPlayer.Init();
        foreach (var enemy in findCharater) enemy.Init();
    }
}
