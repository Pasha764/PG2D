using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    [SerializeField] WasteItem[] wastePrefabs;
    [SerializeField] float interval = 1f;
    [SerializeField] float spawnY = 6f;
    [SerializeField] float xRange = 7f;
    [SerializeField] ProgressionSystem progression;
    [SerializeField] float intervalMin = 0.4f;
    [SerializeField] float percepatPerLevel = 0.08f;

    int level = 1;
    float intervalSekarang;
    float timer = 0f;
    
    void Start()
    {
        intervalSekarang = interval;
        if (progression != null)
        {
            progression.LevelUp += SaatLevelUp; // subscribe
        }
    }

 // Dipanggil lewat event tiap kali pemain naik level
     void SaatLevelUp(int levelBaru)
    {
        level = levelBaru;
        intervalSekarang = Mathf.Max(intervalMin, interval - percepatPerLevel * (level - 1));
        Debug.Log("Kesulitan naik: sampah muncul tiap " + intervalSekarang.ToString("0.00") + " detik");
    }
    void Update()
    {
        if (wastePrefabs == null || wastePrefabs.Length == 0) return;
        timer += Time.deltaTime;
        if (timer >= intervalSekarang)
        {
            timer = 0f;
            int i = Random.Range(0, wastePrefabs.Length);
            Vector3 pos = new Vector3(Random.Range(-xRange, xRange), spawnY, 0f);

        // tipe variabelnya WasteItem, objeknya bisa
        // organik, plastik, atau limbah B3
            WasteItem w = Instantiate(wastePrefabs[i], pos, Quaternion.identity);
            w.TerapkanLevel(level); // polymorphism
        }
    }
    void OnDestroy()
    {
        if (progression != null)
        {
            progression.LevelUp -= SaatLevelUp;
        }
    }
}
