using UnityEngine;

public abstract class WasteItem : GameEntity
{
    protected WasteData data;
    protected int pointValue = 10;
    protected float fallSpeed = 2f;
    [SerializeField] private int xpValue = 5; // P6
    protected string info = "Sampah terkumpul";
    protected ScoreKeeper scoreKeeper;
    protected ProgressionSystem progression;
    [Header("Audio")]
    [SerializeField] private AudioClip suaraTangkap;
    private AudioManager audioManager;

    protected override void Start()
    {
        base.Start();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        progression = FindAnyObjectByType<ProgressionSystem>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    protected virtual void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f, Space.World);
        
        if (transform.position.y < -6f)
        {
            scoreKeeper.AddMissed();
            Remove();
        }
    }

    void OnMouseDown()
    {
        if (Time.timeScale == 0f) return; 
        Collect();
    }
    protected virtual void Collect()
    {
        Debug.Log(info);
        scoreKeeper.AddPoints(pointValue, info);
        if (audioManager != null)                       
        audioManager.Putar(suaraTangkap);
        Remove();
        BeriXP();
    }
  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnTouchPIayer(other.gameObject);
        }
    }

    protected virtual void OnTouchPIayer(GameObject player)
    {
        Collect();
    }

    protected virtual int HitungXP()
    {
        return xpValue;
    }

    public virtual void TerapkanLevel(int level)
    {
        fallSpeed = fallSpeed * (1f + 0.1f * (level - 1));
    }

    protected void BeriXP()
    {
        if (progression == null) return;
        progression.AddXP(HitungXP());
    }

    protected virtual void SalinData()
    {
        if (data == null)
        {
            Debug.LogWarning(name + ": kolom Data masih kosong.");
            return;
        }

        pointValue = data.pointValue;
        xpValue    = data.xpValue;
        fallSpeed  = data.fallSpeed;
        info       = data.namaJenis + " terkumpul";    
    }
}