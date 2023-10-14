using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDealDamage
{
    int GetPower();
    public void DealDamage(IDealDamage target);
    public void TakeDamage(int damage);
    
}
