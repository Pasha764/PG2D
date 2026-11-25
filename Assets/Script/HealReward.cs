using UnityEngine;

[CreateAssetMenu(fileName = "Reward_Heal", menuName = "Eco-Sorter/Reward/Heal")]
public class HealReward : LevelReward
{
    [SerializeField] private int jumlah = 1;
    public override string Deskripsi => "Nyawa +" + jumlah;
    public override void Terapkan(PlayerController pemain)
    {
        if (pemain.TryGetComponent(out Health hp))
        {
            hp.Heal(jumlah);
        }

    }

}
