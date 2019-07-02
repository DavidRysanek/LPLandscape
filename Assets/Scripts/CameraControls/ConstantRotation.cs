using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float degreesPerSecond = 10;
	
    void Update ()
    {
        transform.Rotate(new Vector3 (0, Time.deltaTime * degreesPerSecond, 0));
	}
}
