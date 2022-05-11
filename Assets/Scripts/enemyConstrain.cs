using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class enemyConstrain: SteeringBehaviour
{
    private GameObject enemy_spawnership;
    public float radius = 50.0f;
    public Vector3 center;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled)
        {
            Gizmos.color = Color.blue; 
            Gizmos.DrawWireSphere(center, radius);
        }
    }

    public void Start()
    {
        enemy_spawnership = GameObject.FindWithTag("enemy_spawner");
        center = enemy_spawnership.transform.position;
    }

    public override Vector3 Calculate()
    {
        Vector3 toTarget = transform.position - center;
        Vector3 steeringForce = Vector3.zero;
        if (toTarget.magnitude > radius)
        {
            steeringForce = Vector3.Normalize(toTarget) * (radius - toTarget.magnitude);
        }
        return steeringForce;
    }
}