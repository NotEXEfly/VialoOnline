using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScaler : MonoBehaviour
{
    [SerializeField] private Canvas _gameCanvas;

    private RectTransform _canvasRectTransform;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _canvasRectTransform = _gameCanvas.GetComponent<RectTransform>();
        _rectTransform = GetComponent<RectTransform>();

        Vector2 newSize = new Vector2(_rectTransform.sizeDelta.x, _canvasRectTransform.sizeDelta.y);
        _rectTransform.sizeDelta = newSize;
    }

}
