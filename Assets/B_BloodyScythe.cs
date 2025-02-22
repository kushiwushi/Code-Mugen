using UnityEngine;

public class B_BloodyScythe : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Bloody Scythe";
        buffDescription = "Increase damage by 2x";
        sprite = buffSprite;
        isPassive = true;
    }

    public override void ApplyBuff(GameObject player)
    {
        if (player.TryGetComponent(out PlayerStats playerStats))
        {
          playerStats.SetDamge(2f);
        }
    }
}
