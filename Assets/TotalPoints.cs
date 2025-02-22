using TMPro;
using UnityEngine;

public class TotalPoints : MonoBehaviour
{
    [SerializeField] TMP_Text tpUI;

    public int totalPoints;

    public void setPoints(int amount) {
        totalPoints += amount;
        tpUI.text = $"Total Points: {totalPoints}";
    }
}
