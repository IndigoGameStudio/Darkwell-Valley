using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    public bool DisableInEditor;
    [Space]
    public string _stringTopText;
    public string _stringBottomText;
    [Space]
    [SerializeField] TextMeshProUGUI _textTop;
    [SerializeField] TextMeshProUGUI _textBottom;
    [Space]
    [SerializeField] GameObject[] _gameObjects;

    void Start() {

        foreach (var item in _gameObjects) {

            if (DisableInEditor)
                return;

            item.SetActive(true);
        }

        _textTop.text = _stringTopText;
        _textBottom.text = _stringBottomText;
    }

    void Update() {
        if(Input.anyKeyDown)
            DisableIntro();
    }

    void DisableIntro() => gameObject.SetActive(false);
}
