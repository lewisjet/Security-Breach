using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot
{ 
    // Start is called before the first frame update
   

   
   public void ShootNow(Animator animator, bool oO)
    {
       

        if (!oO) { animator.SetBool("IsAttacking", false); }
        else { animator.SetBool("IsAttacking", true); }
    }
}
