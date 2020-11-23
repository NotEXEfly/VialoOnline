using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _traget;

    void LateUpdate()
    {
        transform.position = new Vector3(_traget.position.x, _traget.position.y, transform.position.z);
    }
}
