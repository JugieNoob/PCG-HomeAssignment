using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float damage = 1f;

    public float GetDamage()
    {
        return damage;
    }
}
