using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 3f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefab = null;
   

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    { 
        while (spawn)
        {

            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {if (attackerPrefab.Length > 0)
        {

            Attacker newAttacker = Instantiate(attackerPrefab[UnityEngine.Random.Range(0, attackerPrefab.Length)],
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity) as Attacker;
            newAttacker.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KilSpawning()
    {
        spawn = false;
    }
}
