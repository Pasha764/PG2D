using UnityEngine;

 
[CreateAssetMenu(fileName = "HazardousWasteData", menuName = "Eco-Sorter/Hazardous Waste Data")]
public class HazardousWasteData : WasteData
{
    [Header("Khusus limbah B3")]
    public int damageAwal = 1;
    public int damageSetelahNaik = 2;
    public int levelDamageNaik = 4;
    public int pengaliXP = 2;
}
