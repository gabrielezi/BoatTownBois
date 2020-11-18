using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    
    private Vector3 _targetPosition;
    private bool _moving;
    private Camera _camera;
    private SoundManager _soundManager;

    private void Start()
    {
        _camera = Camera.main;
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.z = transform.position.z;

            _moving = true;
        }
        
        if (_moving)
        {
            Move();
        }
    }
   
    private void Move()
    {
        _soundManager.PlaySound("Bleep");
        transform.position = Vector3.MoveTowards(
            transform.position,
            _targetPosition,
            speed * Time.deltaTime
        );
        if (transform.position == _targetPosition)
        {
            _moving = false;
        }
    }
}