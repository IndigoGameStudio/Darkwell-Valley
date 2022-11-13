using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float RayDistance = 10;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] GameObject RayInfo;

    void Update()
    {
        /** UZIMA POZICIJU MISA */
        Vector3 mousePos = Input.mousePosition;

        /** TU POZICIJU POSTAVLJA U RAY KAO LOKACIJU ODAKLE DA
         * DETEKTIRA U STO GLEDAMO */
        Ray ray = cam.ScreenPointToRay(mousePos);

        /** OVDJE SPREMA STO GLEDAMO */
        RaycastHit hit;

        /** OVDJE IDE PROVJERA DA LI U TO STO GLEDAMO NAM JE BLIZU ILI DALEKO
            I PREMA TOME POSTAVLJA VRIJEDNOSTI U "HIT" */
        if (Physics.Raycast(ray, out hit, RayDistance))
        {
            /** AKO SMO BLIZU NEKOG OBJEKTA ONDA UZIMA LAYER 'USE' I UKOLIKO
                OBJEKT ZADRZI LAYER 'USE' IZBACITI CE TEKST 'USE' I IME OBJEKTA */
            if (hit.collider.gameObject.layer == 8)
            {
                infoText.text = "USE " + hit.collider.name.ToUpper();
                RayInfo.SetActive(true);
            }
            else
            {
                /** AKO OBJEKT KOJI GLEDAMO NE SADRZI LAYER 'USE' ONDA CE OBRISATI TEKST I SAKRITI UI ZA 'E' */
                infoText.text = string.Empty;
                RayInfo.SetActive(false);
            }
        }
        else
        {
            /** AKO SMO PREVISE DALEKO OD OBJEKTA U KOJEG GLEDAMO OBRISAT CE TEKST I SAKRITI UI ZA 'E' */
            infoText.text = string.Empty;
            RayInfo.SetActive(false);
        }
    }
}
