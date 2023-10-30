using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDealDamage
{
    int GetPower();
    public void TakeDamage();
    public void PowerUp(int powerQuantity);

}
