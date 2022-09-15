using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : State
{
    [SerializeField] GameObject enemyParentTransform;
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        EnemyBrain.rb.bodyType = RigidbodyType2D.Static;
        if (enemyParentTransform != null)
        {
            Destroy(enemyParentTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
