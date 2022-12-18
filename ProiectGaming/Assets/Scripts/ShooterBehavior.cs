using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePos;
    public PlayerManager _player;
    public float speed = 15f;
    private bool gunFacingRight = true;
    public GameObject firePoint;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _spriteRenderer = firePoint.GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = gunFacingRight;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = _mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle %= 360;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        
        _spriteRenderer.flipY = angle.InInterval(90, 270) || angle.InInterval(-270,-90);

        if (_player.hasFlipped)
        {
            Flip();
        }
    }

    private void Flip()
    {
        gunFacingRight = !gunFacingRight;
        _player.hasFlipped = false;
    }
}