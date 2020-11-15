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

    private void Update()
    {
        if (Input.mousePosition.x >= Screen.width - moveRightAreaSize)
        {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.right, Space.World);
        }
        if (Input.mousePosition.x <= moveLeftAreaSize)
        {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.left, Space.World);
        } 
        if (Input.mousePosition.y >= Screen.height - moveUpAreaSize)
        {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.up, Space.World);
        }
        if (Input.mousePosition.y <= moveDownAreaSize)
        {
            transform.Translate(Time.deltaTime * camSpeed * Vector2.down, Space.World);
        }
    }
}
