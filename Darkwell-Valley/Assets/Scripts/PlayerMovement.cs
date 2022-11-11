using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float walkingSpeed = 5.5f;
    [SerializeField] float gravity = -10;
    [SerializeField] float jumpHeight = 10;
    [SerializeField] float SpeedMultiplier = 2;
    [SerializeField] float SpeedDivisor = 2;
    [SerializeField] float crouchSpeed = 5;


    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRange = 0.5f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform playerCamera;

    Vector3 velocity;
    bool isGround;
    float Speed;
    bool isCrouching = false;

    void Update()
    {
        PlayerJump();
        PlayerMove();
        Crouching();
        Gravity();
    }

    // ==================================================================================================================

    private void PlayerMove()
    {
        /** 
         Uzima poziciju lokacije X i onemogućuje da poziicja X bude manja od 0 ili veće od 300 što je i dimenzija mape.
        Također radi na isti princip za Y */
        float xPos = Mathf.Clamp(transform.localPosition.x, 0, 300);
        float zPos = Mathf.Clamp(transform.localPosition.z, 0, 300);
        /** Vrijednosti pozicija X i Y se postavlja u poziciju igrača. */
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, zPos);
        /** 
        Uzima vrijednost od 1 do -1
       Ako smo stisli W onda ćemo dobiti vertikalnu vrijednot 1
       ako smo pritisnuli S dobit ćemo vertikalnu vrijednost -1 
      */
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        /**
         Ako je pritistnut leftshift, odnosno isSprinting = true,
        treba povecati brzinu za zadani multiplier
         */

        /**
         Ako je pitisnut Left Shift, za brzinu uzimamo brzinu trcanja, ako
        je pritisnut C, uzima se brzina cucnja,
        inace se uzima brzina hodanja
         Ta brzina se sprema pod Speed i ubacuje u controller.move
         */
        if (!isCrouching)
        {
            Speed = Input.GetKey(KeyCode.LeftShift) ? walkingSpeed * SpeedMultiplier : walkingSpeed;
        }

        /** 
         Izračunavamo -1 1 vrijednosti s transform pozicjama i dodajmo
        ih u controller move kako bi znao igrač gdje se kretati
        i to množimo s brzinom kretanja 
        */
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Speed * Time.deltaTime);
    }

    // ==================================================================================================================

    private void Crouching()
    {

        if (Input.GetKey(KeyCode.C))
        {
            controller.height = Mathf.Lerp(controller.height, 1, crouchSpeed * Time.deltaTime);
            controller.center = Vector3.Lerp(controller.center, new Vector3(0f, -0.5f, 0f), crouchSpeed * Time.deltaTime);
            playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, new Vector3(0f, 0, 0f), crouchSpeed * Time.deltaTime);
            isCrouching = true;
        }

        if (!Input.GetKey(KeyCode.C))
        {
            controller.height = Mathf.Lerp(controller.height, 2, crouchSpeed * Time.deltaTime);
            controller.center = Vector3.Lerp(controller.center, new Vector3(0f, 0, 0f), crouchSpeed * Time.deltaTime);
            playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, new Vector3(0f, 0.682f, 0f), crouchSpeed * Time.deltaTime);
            isCrouching = false;
        }

    }

    // ==================================================================================================================

    private void PlayerJump()
    {
        /** 
          Ukoliko se pritisne space i igrač je na podu
         dodajemo velocity s jačinom jumpHeight * -2 i puta gravitacija
         koja je također minus a minus i minus daju plus i u tom slučaju
         igrać će ići ka gore.
        */
        if (Input.GetButtonDown("Jump") && isGround && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    // ==================================================================================================================

    private void Gravity()
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
        if (isGround == true && velocity.y < 0)
        {
            velocity.y = -2;
        }
        /** 
         Dodajmo konstatno zamišljen broj u velocity.y a "Y" je visina
        koji se puni sve dok ne dodaknemo pod. 
        Što smo duže u zraku to je broj veći i to nas "gravitacija"
        više vuče ka dolje.
        */
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // ==================================================================================================================
}
