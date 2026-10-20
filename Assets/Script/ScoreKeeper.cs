using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    int missed = 0;
    string message = "Klik sampah sebelum jatuh!";
    public void AddPoints(int points, string info)
    {
        score += points;
        message = info;
    }
    public void AddMissed()
    {
        missed++;
        message = "Sampah terlewat dan mencemari lingkungan!";
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = 24;
        GUI.Label(new Rect(20, 20, 700, 40), "Skor: " + score + "   Terlewat: " + missed);
        GUI.Label(new Rect(20, 60, 1000, 40), message);
    }
}
