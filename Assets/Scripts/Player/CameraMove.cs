using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject _player;
    private Camera _camera;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        var pos = _camera.transform.position;
        pos.x = _player.transform.position.x;
        _camera.transform.position = pos;
    }
}
