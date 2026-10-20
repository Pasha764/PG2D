using UnityEngine;

public class LatihanEntitas : MonoBehaviour
{
    void Start()
    {
        Entitas penduduk = new Entitas("Penduduk", 100);
        penduduk.Beraksi();

        Entitas naga = new Boss("Naga", 150, 50);
        naga.Beraksi();
    }   
}
