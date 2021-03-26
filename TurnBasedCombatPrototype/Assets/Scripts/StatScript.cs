using UnityEngine;

public class StatScript : MonoBehaviour
{
    public string entityName;
    public int damage;
    public int hpMax;
    public int hpCurrent;

    public bool AttackDamage(int dmg)
    {
        hpCurrent -= dmg;

        if (hpCurrent <= 0)
            return true;
        else
            return false;
    }
}
