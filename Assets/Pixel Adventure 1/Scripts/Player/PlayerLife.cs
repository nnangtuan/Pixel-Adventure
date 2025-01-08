using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [Header ("HP infor")]
    public int maxHP;
    public int currentHP;
    private void Start()
    {
        currentHP = 5;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Gay damge");
        currentHP -= damage;
    }
    public void Heal(int heal)
    {
        if (currentHP+heal <= maxHP)
            currentHP += heal;
        else 
            currentHP = maxHP;
    }

}
