using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 10f)] float currentSpeed = 1f;
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float attackDMG = 100f;
    Animator animator;
    GameObject currentTarget;
  [Tooltip ("must not cause a recur when /3")]  public int penaltyDMG = 0;
    [SerializeField] EnemyType enemyType = new EnemyType();

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed( float currentSpeed)
    {
        this.currentSpeed = currentSpeed;
    }

  
   public GameObject GiveDeathVFX()
    {
        return deathVFX;
    }

  
   

    public float Owwy()
    {
        return attackDMG;
    }

 

    public void Attack(GameObject target, bool startOrStop)
    {
        animator.SetBool("IsAttacking", startOrStop);
        currentTarget = target;
        if (startOrStop) { }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        DifficultyCurve();

    }

    private void DifficultyCurve()
    {
        float nPD = (penaltyDMG) / 3.0f;
        nPD = nPD * PlayerPrefController.GetDifficulty();
        penaltyDMG = Mathf.RoundToInt(nPD);

        if(enemyType == EnemyType.Looter)
        {
            float heath = GetComponent<Health>().health;
            heath /= 3.0f;
            heath *= PlayerPrefController.GetDifficulty();
            GetComponent<Health>().health = heath;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyType == EnemyType.Zombie || enemyType == EnemyType.Looter || enemyType == EnemyType.Protester) { ZombieATK(collision); }
        if (enemyType == EnemyType.Rogue) { RogueATK(collision); }
    }

    private void RogueATK(Collider2D col)
    {
        Defender.DefenderType type = new Defender.DefenderType();
        BoxCollider2D collisioncollider = new BoxCollider2D();
        foreach (BoxCollider2D boxCollider2D in col.gameObject.GetComponents<BoxCollider2D>())
        {
            if (boxCollider2D.isTrigger == true) { collisioncollider = boxCollider2D; }
        }
        Collider2D thisGameObject = gameObject.GetComponent<Collider2D>();
        if (col.gameObject.GetComponent<Defender>() && collisioncollider.IsTouching(thisGameObject)) { type = col.gameObject.GetComponent<Defender>().defenderType; }
       else { return; }
       
        if (type == Defender.DefenderType.Blocker)
        {
            bool readyYet = true;
            IEnumerator enumerator() { readyYet = false; animator.SetTrigger("Obstacle"); Debug.Log(":P"); yield return !animator.GetCurrentAnimatorStateInfo(0).IsName("Rogue Jump"); yield return new WaitForSeconds(2f); ; readyYet = true; }
            if (readyYet) { StartCoroutine(enumerator()); }



            
        }
        else
        {
            Attack(col.gameObject, true);
        }


    }

    private void ZombieATK(Collider2D col)
    {
        BoxCollider2D collisioncollider = new BoxCollider2D();
        foreach (BoxCollider2D boxCollider2D in col.gameObject.GetComponents<BoxCollider2D>())
        {
            if (boxCollider2D.isTrigger == true) { collisioncollider = boxCollider2D; }
        }

        if (collisioncollider == null) { return; }

        Collider2D thisGameObject = gameObject.GetComponent<Collider2D>();

       if (col.gameObject.GetComponent<Defender>() == true  && collisioncollider.IsTouching(thisGameObject)) { Attack(col.gameObject, true); }
    }

    enum EnemyType
    {
        Zombie,
        Rogue,
        Looter,
        Protester
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Defender>() == true) { Attack(collision.gameObject, false); }
     
    }


}
