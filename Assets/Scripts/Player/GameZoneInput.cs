using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameZoneInput : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ClickZOne");
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int targetPos = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));

        _player.Actions.MoveByPath(targetPos);
    }
}
