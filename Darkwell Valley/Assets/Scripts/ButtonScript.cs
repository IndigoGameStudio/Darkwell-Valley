using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] float _zoomSpeed = 5;
    [HideInInspector] bool zoomEffect;
    [Space]

    [SerializeField] GameObject _audioHover;
    [SerializeField] GameObject _audioClick;
    [SerializeField] GameObject _AudioParent;
    [Space]

    [SerializeField] Vector3 _endPos;
    [SerializeField] Vector3 _savePos;

    

    void Start() {

        // Sprema startnu poziciju "Scale" od tipke ukoliko nije predhodno navedena.
        // To služi kako bi tipka prilikom uvečavanja znala na koju poziciju se vratiti kad se miš makne s tipke.
        if (_savePos == Vector3.zero) { _savePos = transform.localScale; }
    }

    // =====================================================================================================

    public void OnPointerExit(PointerEventData eventData) => zoomEffect = false; // Za deaktivaciju zoom effecta.

    // =====================================================================================================

    public void Update() {

        if(zoomEffect)
            // Ukoliko je cursor postavljen na tipku onda se zoom radi od trenutne lokalne pozicije do kranje _endPos.
            transform.localScale = Vector3.Lerp(transform.localScale, _endPos, _zoomSpeed * Time.deltaTime);
        else
            // Ukoliko je cursor maknut s tipke onda se s pozicija vraća na početnu spremljenu veličinu.
            transform.localScale = Vector3.Lerp(transform.localScale, _savePos, _zoomSpeed * Time.deltaTime);
    }

    // =====================================================================================================
    public void OnPointerEnter(PointerEventData eventData) {

        // Za aktivaciju zoom effecta
        zoomEffect = true;
        // Kreira instancu od Prefeb-a za zvuk i postavlja je kao child od "Audio" gameObjecta i uništava tu instancu nakon 0.3 sec.
        GameObject objSound = Instantiate(_audioHover, transform.position, Quaternion.identity);
        objSound.transform.parent = _AudioParent.transform;
        Destroy(objSound, 0.3f);
    }

    // =====================================================================================================

    public void OnPointerClick(PointerEventData eventData) {

        // Prilikom klika kreira instancu od Prefeb-a za zvuk i postavlja je kao child od "Audio" gameObjecta
        // i uništava tu instancu nakon 0.5 sec.
        GameObject objSound = Instantiate(_audioClick, transform.position, Quaternion.identity);
        objSound.transform.parent = _AudioParent.transform;
        Destroy(objSound, 0.5f);
    }
}
