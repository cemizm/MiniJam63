using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircleController : MonoBehaviour
{
    public float Radius;

    public float Speed;

    public float Angle;

    private Vector2 center;

    public float MoveSpeed
    {
        get
        {
            return Speed * MainController.TimeController.WorldSpeed;
        }
    }

    void Start()
    {
        center = transform.position;
    }

    void FixedUpdate()
    {
        Angle += MoveSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(Angle), Mathf.Cos(Angle)) * Radius;
        transform.position = center + offset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.2f);

        var offset = new Vector2(Mathf.Sin(Angle), Mathf.Cos(Angle)) * Radius;

        Gizmos.DrawWireSphere((Vector2)transform.position + offset, 0.2f);
    }
}
