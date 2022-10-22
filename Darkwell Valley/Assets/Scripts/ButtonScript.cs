using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool _useZoom = true;
    public float _zoomSpeed = 5;
    [Space]
    public GameObject _audioHover;
    public GameObject _audioClick;
    [Space]
    public Vector3 _endPos;
    public Vector3 _savePos;

    bool zoomEffect;

    void Start()
    {
        if (_savePos == Vector3.zero) { _savePos = transform.localScale; }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        zoomEffect = true;
        GameObject objSound =Instantiate(_audioHover, transform.position, Quaternion.identity);
        Destroy(objSound, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        zoomEffect = false;
    }

    public void Update()
    {
        if (!_useZoom)
            return;

        if(zoomEffect)
        transform.localScale = Vector3.Lerp(transform.localScale, _endPos, _zoomSpeed * Time.deltaTime);
        else
        transform.localScale = Vector3.Lerp(transform.localScale, _savePos, _zoomSpeed * Time.deltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject objSound = Instantiate(_audioClick, transform.position, Quaternion.identity);
        Destroy(objSound, 0.5f);
    }
}
