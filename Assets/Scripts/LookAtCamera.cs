using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour 
{
    Transform target;

    void Start()
    {
        target = Camera.main.transform;
    }

    void Update()
    {
        float rotationZ = transform.eulerAngles.z;
        Vector3 rotation = target.rotation.eulerAngles;
        rotation.z = rotationZ;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
