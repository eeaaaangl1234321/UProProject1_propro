using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats 
{
    public int HP = 0;
    public int Damage = 0;
    public int Level = 0;

    public CharacterStats(int hP, int damage, int level)
    {
        HP = hP;
        Damage = damage;
        Level = level;
    }
}
