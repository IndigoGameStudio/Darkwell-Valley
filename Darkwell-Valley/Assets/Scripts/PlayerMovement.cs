using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float speed = 6.5f;
    [SerializeField] float gravity = -10;
    [SerializeField] float jumpHeight = 10;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRange = 0.5f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGround;

    void Update()
    {
        /**
        Postavlja zamišljeni krug ispod igrača na poziciji groundCheck
        postavlja veličinu s groundRange
        i uzima što će sve detektirati s groundMask u našem slučaju ground.
        Ukoliko su sve te stvari ispravne dobiti ćemo vrijednost true.
        */
        isGround = Physics.CheckSphere(groundCheck.position, groundRange, groundMask);

        /** 
        Ukoliko smo na podu i velocity je ispod 0 resetirat
        će nam guranje igrača ka zemlji koja simulira gravitaciju.
        */
        if(isGround == true && velocity.y < 0)
        {
            velocity.y = -2;
        }

        /** 
         ukoliko se pritisne space i igrač je na podu
         dodajemo velocity s jačinom jumpHeight * -2 i puta gravitacija
         koja je također minus a minus i minus daju plus i u tom slučaju
         igrać će ići ka gore.
        */
        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        /** 
         Uzima vrijednost od 1 do -1
         Ako smo stisli W onda ćemo dobiti vertikalnu vrijednot 1
         ako smo pritisnuli S dobit ćemo vertikalnu vrijednost -1 
        */
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        /** 
         Izračunavamo -1 1 vrijednosti s transform pozicjama i dodajmo
         ih u controller move kako bi znao igrač gdje se kretati
         i to možimo s brzinom kretanja 
        */
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        /** 
        Dodajmo konstatno zamišljen broj u velocity.y a "Y" je visina
        koji se puni sve dok ne dodaknemo pod. 
        Što smo duže u zraku to je broj veći i to nas "gravitacija"
        više vuče ka dole.
        */
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
