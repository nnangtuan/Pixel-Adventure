using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : EntityManager
{
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damgage();
        }
    }
    protected virtual void Damgage()
    {

    }
}
