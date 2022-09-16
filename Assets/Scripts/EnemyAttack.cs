using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : State
{
    [SerializeField] float attackDamage = 10f;
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        //animation trigger
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    public override void Do()
    {
        base.Do();
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("Attack");
        Crystal.Instance.TakeDamage(attackDamage);
        complete = true;
    }
}
