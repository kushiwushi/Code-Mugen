using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Text currentLevel;
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
        currentLevel.text = $"Level {playerStats.Level}";
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
        }

        expBar.SetExp(Experience);
        currentLevel.text = $"Level {playerStats.Level}";
    }

    private int ExperienceRequired()
    {
        return playerStats.Level * 150;
    }
}
