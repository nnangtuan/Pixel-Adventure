using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance; }
    public Player player;

    public void Start()
    {
        if(instance == null)
            instance = this;
        else 
            Destroy(this);
    }
}
