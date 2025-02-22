using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> buffList;
    [SerializeField] private GameObject player;

    public List<GameObject> runtimeBuffs;

    private void Start()
    {
        runtimeBuffs = new List<GameObject>(buffList); //copy from serialized list
    }

    public void ApplyBuff(string buffName)
    {
        GameObject buffPrefab = runtimeBuffs.Find(buff => buff.GetComponent<BuffBase>()?.buffName == buffName);

        if (buffPrefab == null)
        {
            Debug.Log($"{buffName} not found in availableBuffs!");
            return;
        }

        BuffBase buff = buffPrefab.GetComponent<BuffBase>();

        if (buff == null)
        {
            Debug.Log($"{buffName} don't inherit BuffBase component");
            return;
        }

        if (buff.isPassive) {
            buff.ApplyBuff(player);
        }
        else
        {
            Instantiate(buffPrefab, player.transform);
        }

        runtimeBuffs.Remove(buffPrefab); //remove from the list of taken already
    }
}
