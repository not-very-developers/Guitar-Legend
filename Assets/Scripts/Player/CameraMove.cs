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
        var transform1 = _camera.transform;
        var pos = transform1.position;
        pos.x = _player.transform.position.x;
        transform1.position = pos;
    }
}