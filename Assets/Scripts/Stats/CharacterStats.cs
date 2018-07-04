
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    public int maxTP = 30;
    public int CurrentTP { get; private set; }

    

    public Stat damage;
    public Stat damageResist;
    public Stat powerDamage;
   


    public void TakeDamage(int damage)
    {

        damage -= damageResist.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHealth -= damage;

        if(CurrentHealth<= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }


}
