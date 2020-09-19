using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform pos1, pos2;

    public float Speed;

    public TimeController timeController;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = pos1.position;
    }

    public float MoveSpeed
    {
        get
        {
            return Speed * timeController.WorldSpeed;
        }
    }

    public bool Forward
    {
        get { return nextPos == pos2.position; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos1.position, pos2.position);
        Gizmos.DrawWireSphere(pos1.position, 0.2f);
        Gizmos.DrawWireSphere(pos2.position, 0.2f);
    }
}
