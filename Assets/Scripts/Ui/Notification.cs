using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    
    [SerializeField] private Player _player;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        _player.Actions.GridMovement.OnWallCollision += SendNotification;
    }

    public void SendNotification(string str)
    {
        _text.text = str;
    }
}
