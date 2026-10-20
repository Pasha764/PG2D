using UnityEngine;

public class Musuh : Entitas
{
    protected int kekuatan;
    public Musuh(string nama, int nyawa, int kekuatan) 
        : base(nama, nyawa)
    {
        this.kekuatan = kekuatan;
    }
    public override void Beraksi()
    {
        Debug.Log(nama + " menyerang dengann kekuatan " + kekuatan + "!");
    }
}

public class Boss : Musuh
{
    public Boss(string nama, int nyawa, int kekuatan) 
        : base(nama, nyawa, kekuatan)
    {
    }
    public override void Beraksi()
    {
        Debug.Log(nama + " meraung dan memanggil bala bantuan");
    }
}
