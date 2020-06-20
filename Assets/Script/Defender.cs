using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] BulletConfig bullet = null;
    [SerializeField] GameObject spawnBulletLoc = null;
    [SerializeField] int cost = 20;
    DollarDisplayer dollarDisplayer;
  [SerializeField]  EnemySpawner myEnemySpawner;
    


    public DefenderType defenderType = new DefenderType();
   
      Shoot shooter;
      Animator animator;
    
    void Awake()
   {
       shooter = new Shoot();
      animator = GetComponent<Animator>();
   }

    // Start is called before the first frame update
    void Start()
    {
        dollarDisplayer = FindObjectOfType<DollarDisplayer>();
        SetLaneSpawner();
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane() == true && (defenderType == DefenderType.Shooter)){shooter.ShootNow(animator, true);}
       else if (defenderType == DefenderType.Shooter) {shooter.ShootNow(animator, false);}
    }

    public void Shoot()
    {
        Instantiate(bullet, spawnBulletLoc.transform.position , Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>()) { GetComponent<Health>().TakeDamage(collision.GetComponent<Attacker>().Owwy()); }
    }

    public int GiveCost() { return cost; }

    public void MakeMoney(int moneyMade)
    {
        dollarDisplayer.SetDollars(dollarDisplayer.GetDollars() + moneyMade);
        dollarDisplayer.UpdateDisplay();
    }

    private bool IsAttackerInLane()
    {
        if (myEnemySpawner.transform.childCount > 0) {return true;}
         else { return false; }
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] enemySpawners;
        enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            bool theirCloseEnough = (Math.Abs (enemySpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (theirCloseEnough) {myEnemySpawner = enemySpawner;}
        }
    }

   public enum DefenderType
    {
        Shooter,
        Accountant,
        Blocker,
        AccountantHybrid,
    }


}
