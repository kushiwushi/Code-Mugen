using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Text currentLevel;

    public ExperienceBar expBar;

    public int Level { get; private set; }
    public int Experience { get; private set; }

    private void Awake()
    {
        Level = 1;
        Experience = 0;

        expBar.SetMaxExp(ExperienceRequired());
    }

    private void Start()
    {
        currentLevel.text = $"Level {Level}";
    }

    public void GainExperience(int exp)
    {
        Experience += exp;

        int requiredExp = ExperienceRequired();

        while (Experience >= requiredExp)
        {
            Experience -= ExperienceRequired();
            Level++;

            requiredExp = ExperienceRequired();
            expBar.SetMaxExp(requiredExp);
        }

        expBar.SetExp(Experience);
        currentLevel.text = $"Level {Level}";
    }

    private int ExperienceRequired()
    {
        return Level * 150;
    }
}
