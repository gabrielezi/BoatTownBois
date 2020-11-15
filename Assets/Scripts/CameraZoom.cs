using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float minZoom = 2f;
    [SerializeField]
    private float maxZoom = 8f;
    [SerializeField]
    private float zoomSpeed = 8f;
    [SerializeField]
    private float zoomSensitivity = 5f;
    
    private Camera _camera;
    private float _zoom;

    private void Start()
    {
        _camera = Camera.main;
        _zoom = _camera.orthographicSize;
    }
    
    private void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");

        _zoom -= scroll * zoomSensitivity;
        _zoom = Mathf.Clamp(_zoom, minZoom, maxZoom);
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _zoom, Time.deltaTime * zoomSpeed);
    }
}
