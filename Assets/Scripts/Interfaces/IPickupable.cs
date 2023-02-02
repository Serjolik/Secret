using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    public void Pickup();
    public (string, int, Sprite) GetValues();
}
