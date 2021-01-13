using UnityEngine;
public class UiScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _gameCanvas;
    [SerializeField] private RectTransform _mainCanvas;
    private RectTransform _current;


    private void Start()
    {
        _current = GetComponent<RectTransform>();

        UpdateDownUiHeigth();
    }

    public void UpdateDownUiHeigth()
    {
        float newHeight = _mainCanvas.rect.height / 2;
        Vector2 newSize = new Vector2(_current.sizeDelta.x, newHeight);
        _current.sizeDelta = newSize;
    }
}
