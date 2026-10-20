using UnityEngine;

public class WasteItem : GameEntity
{
    [SerializeField] protected int pointValue = 10;
    [SerializeField] protected float fallSpeed = 2f;
    [SerializeField] protected int xpValue = 5; // P6
    protected string info = "Sampah terkumpul";
    protected ScoreKeeper scoreKeeper;
    protected ProgressionSystem progression;

    protected override void Start()
    {
        base.Start();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        progression = FindAnyObjectByType<ProgressionSystem>();
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
        Collect();
    }
    protected virtual void Collect()
    {
        Debug.Log(info);
        scoreKeeper.AddPoints(pointValue, info);
        BeriXP();
        Remove();
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

    
}