using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    [Header (" Component ")]
    [SerializeField] private List<GameObject>targetPosition = new List<GameObject>();
    [SerializeField] private int currentTarget;
    [SerializeField] private GameObject obj;

    [Header(" damage ")]
    [SerializeField] private int dame = 2;
    

    [SerializeField] private float moveSpeed;
    protected override void Start()
    {
        currentTarget = 0;
        
    }

    protected override void Update()
    {
        base.Update();
        if (!canActive)
            return;
        MoveToTargetPosition();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        

    }

    private void Rotate(Vector2 a, Vector2 b)
    {
        if (Vector2.Distance(a, b) >= 0.5)
            obj.transform.Rotate(new Vector3(0, 0, 12));
        else
            obj.transform.Rotate(new Vector3(0, 0, Vector2.Distance(a, b)*30));
    }
    private void MoveToTargetPosition()
    {
        if (currentTarget >= targetPosition.Count) 
            currentTarget=0;
        float step = moveSpeed * Time.deltaTime;
        obj.transform.position = Vector2.MoveTowards(obj.transform.position, targetPosition[currentTarget].transform.position, step);
        Rotate(obj.transform.position, targetPosition[currentTarget].transform.position);
        if (obj.transform.position == targetPosition[currentTarget].transform.position)
            currentTarget++;
    }
    protected override void TakeDamage()
    {
        base.TakeDamage();
        PlayerManager.Instance.player.playerLife.TakeDamage(dame);
    }
    
}
