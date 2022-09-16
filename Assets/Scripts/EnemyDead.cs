using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : State
{
    [SerializeField] GameObject enemyParentGameObject;
    [SerializeField] List<GameObject> drops = new();
    [SerializeField]
    [Range(0, 1)]
    float dropChance = .5f;
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        if (enemyParentGameObject != null)
        {
            DropItems();
            Destroy(enemyParentGameObject);
        }
    }

    private void DropItems()
    {
        while (Random.value < dropChance)
        {
            GameObject collectible = Instantiate(drops[Random.Range(0, drops.Count)], transform.position, Quaternion.identity);
            collectible.transform.SetParent(GameObject.FindGameObjectWithTag("CollectiblesParent").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
