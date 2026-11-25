using System;
using UnityEngine;

public class ProgressionSystem : MonoBehaviour
{
    [SerializeField] private ProgressionConfig config;   // P7 
    [SerializeField] private PlayerController player;
    public int Level { get; private set; } = 1;
    public int CurrentXP { get; private set; }
    public event Action<int> LevelUp;
    private string pesan = "Kumpulkan XP untuk naik level!";
    private int LevelMaks => config != null ? config.levelMaks : 10;

    void Awake()
    {
        if (config == null)
        Debug.LogWarning(name + ": kolom Config masih kosong.");
    }

    public int XpUntukNaik(int level)
    {
        if (config == null) return int.MaxValue;
        return config.XpUntukNaik(level);

    }

    public void AddXP(int jumlah)
    {
        if (jumlah <= 0 || Level >= LevelMaks) return;

        CurrentXP += jumlah;

        while (Level < LevelMaks && CurrentXP >= XpUntukNaik(Level))
        {
            CurrentXP -= XpUntukNaik(Level); 
            Level++;
            NaikLevel();
            if (Level >= LevelMaks) CurrentXP = 0;
        }

        
    }

    private void NaikLevel()
    {
        pesan = "LEVEL UP! Sekarang level " + Level;
        Debug.Log(pesan);
        BeriReward();
        LevelUp?.Invoke(Level); 
    }

    private void BeriReward()
    {
        if (player == null) return; 
        if (config == null || config.rewards == null || config.rewards.Length == 0) return;

        int indeks = (Level - 2) % config.rewards.Length;
        LevelReward reward = config.rewards[indeks];
        if (reward == null) return;

        reward.Terapkan(player); 
        pesan = pesan + " Reward: " + reward.Deskripsi;
        Debug.Log("Reward: " + reward.Deskripsi);
    }

    void OnGUI()
    {
        if (config == null) return;

        GUI.skin.label.fontSize = 20;

        bool maks = Level >= LevelMaks;
        int butuh = XpUntukNaik(Level);
        string teksXP = maks ? "MAKS" : CurrentXP + " / " + butuh;
        
        GUI.Label(new Rect(20, 180, 700, 40), "Level " + Level + " XP " + teksXP);
        

        float rasio = maks ? 1f : (float)CurrentXP / butuh;
        GUI.color = Color.gray;
        GUI.DrawTexture(new Rect(20, 222, 300, 14), Texture2D.whiteTexture);
        
        GUI.color = Color.green;
        GUI.DrawTexture(new Rect(20, 222, 300 * rasio, 14), Texture2D.whiteTexture);
        GUI.color = Color.white;
        
        GUI.Label(new Rect(20, 244, 1000, 40), pesan);
    }
}
