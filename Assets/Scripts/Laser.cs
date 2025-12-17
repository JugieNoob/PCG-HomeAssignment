using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    void Start()
    {
    }

    public float GetDamage()
    {
        return damage;
    }
}
