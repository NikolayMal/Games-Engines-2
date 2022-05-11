using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Constrain: SteeringBehaviour
{
    private GameObject ally_mothership;
    public float radius = 100.0f;

    public Vector3 center;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled)
        {
            Gizmos.color = Color.red; 
            Gizmos.DrawWireSphere(center, radius);
        }
    }

    public void Start()
    {
        ally_mothership = GameObject.FindWithTag("ally_mothership");
        center = ally_mothership.transform.position;
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