using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float RayDistance = 10;
    [SerializeField] TextMeshProUGUI infoText;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray ray = camera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, RayDistance))
        {
            infoText.text = "OPEN " + hit.collider.name;
        }
    }
}
