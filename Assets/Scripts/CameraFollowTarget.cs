using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed;
    //[SerializeField] private float radius = 1f;
    [SerializeField] private bool verticalFollow = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (target == null) return;

        if (Vector2.Distance(transform.position, target.position) > 0f)
        {
            transform.position = Vector2.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
            
            if (verticalFollow)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 0, -10f);
            }
        }
    }
}
