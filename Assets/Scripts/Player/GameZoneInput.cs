using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameZoneInput : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _targetCursorPrefab; 
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ClickZOne");
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int targetPos = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));

        StartCoroutine(SetTargetCursor(new Vector3(targetPos.x, targetPos.y, 0)));


        _player.Actions.MoveByPath(targetPos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    private IEnumerator SetTargetCursor(Vector3 targetPos)
    {
        var cursor = Instantiate(_targetCursorPrefab, targetPos, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        Destroy(cursor.gameObject);
    }
}
