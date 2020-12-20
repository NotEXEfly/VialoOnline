using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour
{
    [SerializeField]
    public Player player;
    private Transform _movePoint;
    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _movePoint = player.Components.NextCellPoint;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _movePoint.position.ToString();
    }
}
