using UnityEngine;

public abstract class BuffBase : MonoBehaviour
{
    public string buffName;
    public string buffDescription;
    public Sprite sprite;
    public bool isPassive;
    public virtual void ApplyBuff(GameObject player){}
    public abstract void Initialize();
}
