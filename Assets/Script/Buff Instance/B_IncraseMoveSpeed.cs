using UnityEngine;

public class B_IncraseMoveSpeed : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Speedy Sandals";
        buffDescription = "Increase movement speed by 50%";
        sprite = buffSprite;
        isPassive = true;
    }


    public override void ApplyBuff(GameObject player)
    {
        if (player.TryGetComponent(out PlayerStats playerStats))
        {
          playerStats.SetMoveSpeed(1.5f);
        }
    }
}
