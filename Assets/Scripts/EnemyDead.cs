using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : State
{
    [SerializeField] GameObject enemyParentGameObject;
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        if (enemyParentGameObject != null)
        {
            Destroy(enemyParentGameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
