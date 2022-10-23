using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerBody;
    [SerializeField] float Sensitivity = 10;
    float xRotation;

    private void Start()
    {
        /** 
        Prilikom starta igre zaključavamo miš na sredini ekrana
        i gasimo njegovu vidljivost.
         */
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        /** 
         Uzimamo poziciju X i Y miša te to množimo s jačinom senzitivnosti
         ali pošto je sistem u Update funkciji a ona se bazira na frame. Morali smo
         dodati Time.Deltatime kako ne bi se razlikovala brzina miša prema jačini računala. 
        */
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        /** 
         Uzimamo vrijednosti visine miša (Y) i stavljamo limit. 
         Da se ne može ići u zrak više od 90 i spustiti kameru ispod -90
         I ako je visina miša Y na kameri je rotacija za gore i dole X
        */
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        /** Visinu stavljamo u transfrom što je kamera i samo da se uređuje rotacija kemre (gore, dole) */
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        /** Rotiranje ljevo i desno se odnosi na tjelo igrača i rotira se igrač a ne kamera. */
        playerBody.Rotate(Vector3.up, mouseX);
    }
}
