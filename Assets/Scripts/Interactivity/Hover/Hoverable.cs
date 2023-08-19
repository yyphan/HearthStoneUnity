using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float SecondsBeforeShowing = 0.5f;
    private float _timer = 0f;
    private bool _isHovering = false;
    private bool _isShowing = false;

    private void Update()
    {
        if (!_isShowing && _isHovering)
        {
            _timer += Time.deltaTime;
            if (_timer > SecondsBeforeShowing) ShowView();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHovering = true;
        _timer = 0f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isHovering = false;
        _timer = 0f;
        HideView();
    }

    protected virtual void ShowView()
    {
        _isShowing = true;
    }

    protected virtual void HideView()
    {
        _isShowing = false;
    }
}
