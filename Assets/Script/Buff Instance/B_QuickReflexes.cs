using UnityEngine;

public class B_QuickReflexes : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Quick Reflexes";
        buffDescription = "Increase attack speed by 30%";
        sprite = buffSprite;
        isPassive = true;
    }

    public override void ApplyBuff(GameObject player)
    {
        if (player.TryGetComponent(out PlayerStats playerStats))
        {
          playerStats.SetHaste(0.3f);
        }
    }
}
