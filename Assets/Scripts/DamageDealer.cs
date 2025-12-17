using Unity.VisualScripting;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int collideDamage = 2;
    int laserDamage = 1;


    public int GetCollideDamage()
    {
        return collideDamage;
    }

    public int GetLaserDamage()
    {
        return laserDamage;
    }
}
