using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    int laserDamage;
    public void SetLaserDamage(int damage)
    {
        laserDamage = damage;
    }

    public int GetLaserDamage()
    {
        return laserDamage;
    }
}
