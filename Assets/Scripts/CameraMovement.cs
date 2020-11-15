using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
    [SerializeField]
    private float camSpeed = 3f;
    [SerializeField]
    private float moveLeftAreaSize = 30f;
    [SerializeField]
    private float moveRightAreaSize = 30f;
    [SerializeField]
    private float moveUpAreaSize = 25f;
    [SerializeField]
    private float moveDownAreaSize = 25F;
    [SerializeField]
    private float maxYInitial = 2f;
    [SerializeField]
    private float minYInitial = -2f;
    [SerializeField]
    private float maxXInitial = 2f;
    [SerializeField]
    private float minXInitial = -2F;

    private float _initialSize;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _initialSize = _camera.orthographicSize;
    }

    private void Update()
    {
        var currentSizeDiff = _initialSize - _camera.orthographicSize;
        if (
            Input.mousePosition.x >= Screen.width - moveRightAreaSize
            && transform.position.x < maxXInitial + currentSizeDiff
        ) {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.right, Space.World);
        }
        if (
            Input.mousePosition.x <= moveLeftAreaSize
            && transform.position.x > minXInitial - currentSizeDiff
        ) {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.left, Space.World);
        } 
        if (
            Input.mousePosition.y >= Screen.height - moveUpAreaSize
            && transform.position.y < maxYInitial + currentSizeDiff
        ) {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.up, Space.World);
        }
        if (
            Input.mousePosition.y <= moveDownAreaSize
            && transform.position.y > minYInitial - currentSizeDiff
        ) {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.down, Space.World);
        }
    }
}
