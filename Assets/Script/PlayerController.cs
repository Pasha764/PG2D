using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : GameEntity
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float jedaTembak = 0.3f;
    private Rigidbody2D rb;
    private float inputX;
    private float timerTembak;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        timerTembak += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timerTembak >= jedaTembak)
        {
            Vector3 posisi = transform.position + Vector3.up * 0.8f;
            Instantiate(projectilePrefab, posisi, Quaternion.identity);
            timerTembak = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputX * moveSpeed, 0f);
    }

    // PlayerController.cs: sebelum } penutup class
    public void PercepatTembak(float faktor)
    {
        jedaTembak = Mathf.Max(0.1f, jedaTembak * faktor);
        Debug.Log("Jeda tembak sekarang "+ jedaTembak.ToString("0.00") + " detik");
    }
}
    