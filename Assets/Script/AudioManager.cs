using UnityEngine;


// P12 - Satu sumber suara untuk semua efek (SFX).
// Pasang pada objek yang tetap ada selama scene berjalan,
// bukan pada sampah yang segera dihancurkan.
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float volumeSfx = 0.8f;
    private AudioSource sumber;
    void Awake()
        {
            sumber = GetComponent<AudioSource>();
            sumber.playOnAwake = false;
        }


public void Putar(AudioClip klip)
    {
        if (klip == null) return;   
        sumber.PlayOneShot(klip, volumeSfx);
    }


}
