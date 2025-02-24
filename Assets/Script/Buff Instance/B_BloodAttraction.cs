using UnityEngine;

public class B_BloodAttraction : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Blood Attraction";
        buffDescription = "Increase pick up range by 30%";
        sprite = buffSprite;
        isPassive = true;
    }

    public override void ApplyBuff(GameObject player)
    {
        if (player.TryGetComponent(out PlayerStats playerStats))
        {
          playerStats.SetPickupRange(0.3f);
        }
    }
}
