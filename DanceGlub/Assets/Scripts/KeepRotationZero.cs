using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotationZero : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
