using UnityEngine;

public class B_SanguineAegis : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Sanguine Aegis";
        buffDescription = "Increase defense by 10";
        sprite = buffSprite;
        isPassive = true;
    }

    public override void ApplyBuff(GameObject player)
    {
        if (player.TryGetComponent(out PlayerStats playerStats))
        {
          playerStats.SetDefense(10);
        }
    }
}
