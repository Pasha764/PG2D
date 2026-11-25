using UnityEngine;

[CreateAssetMenu(fileName = "WasteData", menuName = "Eco-Sorter/Waste Data")]
public class WasteData : ScriptableObject
{
    [Header("Identitas")]
    public string namaJenis = "Sampah";
    
    [Header("Angka permainan")]
    public int pointValue = 10;
    public int xpValue = 5;
    public float fallSpeed = 2f;
}
