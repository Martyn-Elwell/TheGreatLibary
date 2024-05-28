using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    public void Pickup();

    public void Outline(bool active);
}
