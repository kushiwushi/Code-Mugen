using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private BuffUIController buffUIController;
    [SerializeField] private TMP_Text playerLevelText;

    public ExperienceBar expBar;
    private PlayerStats playerStats;

    public int Experience { get; private set; }

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();

        Experience = 0;
        expBar.SetMaxExp(ExperienceRequired());
    }

    private void Start()
    {
        playerLevelText.text = $"Level {playerStats.Level}";
    }

    public void GainExperience(int exp)
    {
        Experience += exp;

        int requiredExp = ExperienceRequired();

        while (Experience >= requiredExp)
        {
            Experience -= ExperienceRequired();
            playerStats.SetLevel();

            requiredExp = ExperienceRequired();
            expBar.SetMaxExp(requiredExp);
            buffUIController.ShowBuffSelection();
        }

        expBar.SetExp(Experience);
        playerLevelText.text = $"Level {playerStats.Level}";
    }

    private int ExperienceRequired()
    {
        return playerStats.Level * 150;
    }
}
