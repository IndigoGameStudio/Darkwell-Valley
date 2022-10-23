using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;

    void Update()
    {
        /** Služi za rotaciju kamere u menu.
        Postavljena je kamera kao child te se vrti paret kamere.*/
        transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }
}
