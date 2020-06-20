using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] float controlAffect = 0f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0) { DeathSorter(); }
    }

    private void DeathSorter()
    {
        if (GetComponent<Attacker>()) { EnemyDeath(GetComponent<Attacker>()); }
        if (GetComponent<Defender>()) { DefenderDeath(GetComponent<Defender>()); }
    }

    private void EnemyDeath(Attacker attacker)
    {
        if (attacker.GiveDeathVFX()) { Instantiate(attacker.GiveDeathVFX(), transform.position, Quaternion.identity); }
        FindObjectOfType<Control>().ChangeControl(controlAffect);
        Destroy(gameObject);
    }

    private void DefenderDeath(Defender defender)
    {
        FindObjectOfType<Control>().ChangeControl(controlAffect);
        Destroy(gameObject);
    }

    
}
