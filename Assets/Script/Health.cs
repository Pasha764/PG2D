using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float invincibilityTime = 0.5f;
    [SerializeField] private Color warnaKena = Color.blue;

    [Header("Audio")]
    [SerializeField] private AudioClip suaraKena;

    public int CurrentHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0;
    public event Action Died;

    private float invisibilityTimer;
    private SpriteRenderer sr;
    private Color warnaAsli;
    private AudioManager audioManager;

    void Awake()
    {
        CurrentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            warnaAsli = sr.color;
        }
    }
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Update()
    {
        if (invisibilityTimer <= 0) return;
        invisibilityTimer -= Time.deltaTime;
        if (invisibilityTimer <= 0 && sr != null)
        {
            sr.color = warnaAsli;
        }
    }

    public void TakeDamage(int jumlah)
    {
        if (IsDead || invisibilityTimer > 0f) return; // 1 validate
        // 2. apply + mulai i-frames
        CurrentHealth = Mathf.Max(CurrentHealth - jumlah, 0);
        invisibilityTimer = invincibilityTime;
        if (sr != null) sr.color = warnaKena;  // 3. feedback
        if (audioManager != null)              
        audioManager.Putar(suaraKena);
        Debug.Log(name + " kena " + jumlah + " damage, sisa HP " + CurrentHealth    );
        if (IsDead) Die(); 
    }

    public void Heal(int jumlah)
    {
        if (IsDead || jumlah <= 0) return;
        CurrentHealth = Mathf.Min(CurrentHealth + jumlah, maxHealth);
        Debug.Log(name + " dipulihkan, HP sekarang "+ CurrentHealth);
    }

    private void Die()
    {
        Died?.Invoke();
        GameEntity entity = GetComponent<GameEntity>();
        if (entity != null) entity.Remove();
        else Destroy(gameObject);
    }

    

 
}
