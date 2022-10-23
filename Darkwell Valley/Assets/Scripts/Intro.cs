using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField] bool DisableInEditor;
    [Space]
    [SerializeField] string _stringTopText;
    [SerializeField] string _stringBottomText;
    [Space]
    [SerializeField] TextMeshProUGUI _textTop;
    [SerializeField] TextMeshProUGUI _textBottom;
    [Space]
    [SerializeField] GameObject[] _gameObjects;

    void Start() {

        foreach (var item in _gameObjects) {
            /** 
            Uzima sve objekte od intra te ih ne aktivira ako si u editoru.
            Intro je vidljiv samo ako se exporta igrica.
            Kako developerima ne bi išla za živce prilikom svakog testiranja igrice.
            */
            if (DisableInEditor)
                return;

            item.SetActive(true);
        }

        /** Postavlja string kao tekst.*/
        _textTop.text = _stringTopText;
        _textBottom.text = _stringBottomText;
    }

    void Update() {
        /** Ukoliko se postavi da se intro uvijek aktivira moguće
         ga je deaktivirati bilo kojim pritiskom tipke.*/
        if(Input.anyKeyDown)
            DisableIntro();
    }

    void DisableIntro() => gameObject.SetActive(false);
}
