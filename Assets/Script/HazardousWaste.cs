using UnityEngine;

public class HazardousWaste : WasteItem
{
    [SerializeField] private int damageToPlayer = 1;
    [SerializeField] private float swayAmount = 0.5f;
    [SerializeField] private int pengaliXP = 2; // P6
    
    private Health health;

    protected override void Start()
    {
        base.Start();
        health = GetComponent<Health>();
        health.Died += SaatDinetralkan;
        health.Died += BeriXP;
    }

    protected override void OnTouchPIayer(GameObject player)
    {
        if (player.TryGetComponent(out Health hpPemain))
        {
            hpPemain.TakeDamage(damageToPlayer);
            Debug.Log("Player terkena limbah berbahaya, mengurangi " + damageToPlayer + " health.");
        }
        Remove();
    }

    protected override void Update()
    {
        base.Update();
        float sway = Mathf.Sin(Time.time * 4f) * swayAmount;
        transform.Translate(sway * Time.deltaTime, 0f, 0f, Space.World);
    }
    
    protected override void Collect()
    {
        info = "BERBAHAYA! Serahkan ke pengelola B3 (+" + pointValue + " poin)";
        base.Collect();
    }

    private void SaatDinetralkan()
    {
        if (scoreKeeper == null) return;
        scoreKeeper.AddPoints(pointValue, "Limbah B3 dinetralkan (+" + pointValue + " poin)");
    }

    protected override int HitungXP()
    {
        return base.HitungXP() * pengaliXP;
    }

    // P6: makin cepat DAN makin berbahaya
    public override void TerapkanLevel(int level)
    {
        base.TerapkanLevel(level);
        if (level >= 4) damageToPlayer = 2;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (health != null)
        {
            health.Died -= SaatDinetralkan;
            health.Died -= BeriXP;
        }
    }
}
