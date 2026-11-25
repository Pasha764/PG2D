using UnityEngine;

public abstract class LevelReward : ScriptableObject
{
    public abstract string Deskripsi { get; }

    public abstract void Terapkan(PlayerController pemain);
}
