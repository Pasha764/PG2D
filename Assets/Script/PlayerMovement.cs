using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int moveSpeed = 5;
    private int rotationSpeed = 200;
    private float minScale = 0.5f;
    private float maxScale = 2f;
    public Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        RotatePlayer();
        ScalePlayer();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
    void ScalePlayer()
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            transform.localScale = new Vector3(
                Mathf.Clamp(transform.localScale.x, minScale, maxScale),
                Mathf.Clamp(transform.localScale.y, minScale, maxScale),
                1f
            );
        }
        else if (Input.GetKey(KeyCode.V))
        {
            transform.localScale -= Vector3.one * Time.deltaTime;
            transform.localScale = new Vector3(
                Mathf.Clamp(transform.localScale.x, minScale, maxScale),
                Mathf.Clamp(transform.localScale.y, minScale, maxScale),
                1f
            );
        }
    }

}