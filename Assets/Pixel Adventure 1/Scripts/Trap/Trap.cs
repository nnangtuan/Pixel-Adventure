using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : EntityManager
{
    protected virtual void Start()
    {
        
    }
    protected override void Update()
    {
        base.Update();  
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            TakeDamage();
        }
    }
    protected virtual void TakeDamage()
    {
        
    }
   
}
