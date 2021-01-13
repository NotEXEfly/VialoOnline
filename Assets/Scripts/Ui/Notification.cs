using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Player _player;
    private void Start()
    {
        _text = GetComponent<Text>();
    }


}
