using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameZoneInput : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _targetCursorPrefab;
    [SerializeField] private RightTabs _rightTabs;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (RightTabs.WindowIsOpen)
        {
            _rightTabs.CloseAllWindows();
            return;
        }
        

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int targetPos = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));

        StartCoroutine(SetTargetCursor(new Vector3(targetPos.x, targetPos.y, 0)));


        _player.Actions.MoveByPath(targetPos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
    }

    private IEnumerator SetTargetCursor(Vector3 targetPos)
    {
        var cursor = Instantiate(_targetCursorPrefab, targetPos, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        Destroy(cursor.gameObject);
    }
}
