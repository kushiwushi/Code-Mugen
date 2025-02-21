using UnityEngine;

public class B_OrbSpin : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Orb Shield";
        buffDescription = "Summons orbs that will spin around the player to deal damage";
        sprite = buffSprite;
        isPassive = false;
    }

    public float rotationSpeed = 200f;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
