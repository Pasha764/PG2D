using UnityEngine;
 
public class Entitas
{
    protected string nama;
    protected int nyawa;

    public Entitas(string nama, int nyawa)
    {
        this.nama = nama;
        this.nyawa = nyawa;
    }

    public virtual void Beraksi()
    {
        Debug.Log(nama + " (" + nyawa + " nyawa) berdiri diam.");
    }
}
