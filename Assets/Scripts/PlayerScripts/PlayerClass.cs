using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public string name { get; private set; }
    public float health { get; private set; }

    public PlayerClass(string name, float health)
    {
        this.name = name; this.health = health;
    }

    public void DamageDealt(float damage)
    {
        this.health -= damage;
    }

}
