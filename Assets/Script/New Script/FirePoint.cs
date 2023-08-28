using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public void Point (Vector2 inputPointerPosition)
    {
        var platerDirection = (Vector3)inputPointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(platerDirection.y, platerDirection.x) * Mathf.Rad2Deg;
        var rotationStep = platerDirection *
    }
}
