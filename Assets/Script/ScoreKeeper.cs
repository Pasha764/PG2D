using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [Header("Referensi pemain (P5)")]
    [SerializeField] private Health playerHealth;
    [Header("UI Canvas (P12)")]
    [SerializeField] private TMP_Text teksSkor;
    [SerializeField] private TMP_Text teksPesan;
    [SerializeField] private TMP_Text teksNyawa;
    [SerializeField] private GameObject panelGameOver;
    [Header("Audio (P12)")]
    [SerializeField] private TMP_Text teksSkorAkhir;
    [SerializeField] private AudioClip suaraGameOver;
    private int score = 0;
    private int missed = 0;
    private int hpTerakhir = -1;
    private bool gameOver = false;
    private AudioManager audioManager;

    [Header("Progression")]
    [SerializeField] private ProgressionSystem progression;

    void Start()
    {
        Time.timeScale = 1f;
        audioManager = FindAnyObjectByType<AudioManager>();
        
        if (panelGameOver != null) panelGameOver.SetActive(false);
        PerbaruiSkor();
        TampilkanPesan("Klik sampah sebelum jatuh!");
    }

    void Update()
    {
        int hp = playerHealth != null ? playerHealth.CurrentHealth : 0;
        if (hp != hpTerakhir)
        {
            // teks ditulis ulang hanya saat nilainya berubah
            hpTerakhir = hp;
            if (teksNyawa != null) teksNyawa.text = "Nyawa: " + hp;
            if (hp <= 0 && !gameOver) GameOver();
        }

}

    public void AddPoints(int points, string info)
    {
        if (gameOver) return;
        score += points;
        PerbaruiSkor();
        TampilkanPesan(info);

    }
    public void AddMissed()
    {
        if (gameOver) return;
        missed++;   
        PerbaruiSkor();
        TampilkanPesan("Sampah terlewat dan mencemari lingkungan!");

    }
    private void PerbaruiSkor()
    {
        if (teksSkor != null) teksSkor.text = "Skor: " + score + " Terlewat: " + missed;
    }
    private void TampilkanPesan(string isi)
    {
        if (teksPesan != null) teksPesan.text = isi;
    }

    private void GameOver()
    {
        gameOver = true;
        if (teksSkorAkhir != null)
        teksSkorAkhir.text = "Skor akhir: " + score;
        if (panelGameOver != null) panelGameOver.SetActive(true);
        if (audioManager != null) audioManager.Putar(suaraGameOver);
        Time.timeScale = 0f;   // permainan berhenti, UI tetap aktif
    }


    public void MainLagi()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
