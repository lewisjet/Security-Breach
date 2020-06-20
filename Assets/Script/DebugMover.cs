using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
   
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime) * -1, transform.position.y);
    }
}
