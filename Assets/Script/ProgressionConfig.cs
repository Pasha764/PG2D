using UnityEngine;

[CreateAssetMenu(fileName = "ProgressionConfig", menuName = "Eco-Sorter/Progression Config")]
public class ProgressionConfig : ScriptableObject
{
    [Header("Kurva XP")]
    public int xpDasar = 20;
    public float pangkat = 1.5f;
    public int levelMaks = 10;
    [Header("Reward, berulang mulai dari level 2")]
    public LevelReward[] rewards;
 
    public int XpUntukNaik(int level)
    {
        return Mathf.RoundToInt(xpDasar * Mathf.Pow(level, pangkat));
    }

}
