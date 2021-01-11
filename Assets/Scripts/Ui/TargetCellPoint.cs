using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCellPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _liveTime = 1f;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void SetCellUiPoint(Vector2Int position)
    {
        StartCoroutine(CreateTargetSprite(position));
    }

    private IEnumerator CreateTargetSprite(Vector2Int position)
    {
        var uiPoint = Instantiate(_prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(_liveTime);
        Destroy(uiPoint.gameObject);
    }

}
