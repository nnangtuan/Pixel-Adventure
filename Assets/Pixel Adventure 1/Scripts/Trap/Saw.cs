using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    [SerializeField] private List<GameObject>targetPosition = new List<GameObject>();
    [SerializeField] private int currentTarget;
    [SerializeField] private GameObject obj; 
    

    [SerializeField] private float moveSpeed;
    private void Start()
    {
        currentTarget = 0;
    }

    private void Update()
    {
        MoveToTargetPosition();
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
}
