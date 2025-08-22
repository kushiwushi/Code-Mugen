using UnityEngine;

public class B_Neelu : BuffBase
{
    [Header("EDIT THIS FIELD ONLY - ABOVE IS INHERITED")]
    [SerializeField] private Sprite buffSprite;

    public override void Initialize()
    {
        buffName = "Neelu";
        buffDescription = "Bloom bloom bloom bloom~";
        sprite = buffSprite;
        isPassive = false;
    }

    void Update()
    {
        
    }
}
