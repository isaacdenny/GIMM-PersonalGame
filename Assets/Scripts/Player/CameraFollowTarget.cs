using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed;
    //[SerializeField] private float radius = 1f;
    [SerializeField] private bool verticalFollow = false;

    public static CameraFollowTarget Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (target == null) return;

        /*
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
        */

        if (verticalFollow)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(target.position.x, 0, -10f);
        }
    }
}
