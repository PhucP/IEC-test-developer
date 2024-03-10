using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class Pool : MonoBehaviour
{
    public static Pool Instance;
    
    [SerializeField] private List<ItemObject> listItemObjects;
    [SerializeField] private int numOfItem;
    [SerializeField] Transform poolTransform;
    
    private Dictionary<NormalItem.eNormalType, List<Transform>> _pools;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        
        Instance = this;

        CreateItemObject();
    }

    private void CreateItemObject()
    {
        _pools = new Dictionary<NormalItem.eNormalType, List<Transform>>();
        foreach (var item in listItemObjects)
        {
            List<Transform> tempList = new List<Transform>();
            for (int i = 0; i < numOfItem; i++)
            {
                var view = Instantiate(item.prefab, poolTransform);
                view.SetActive(false);
                tempList.Add(view.transform);
            }
            if(!_pools.ContainsKey(item.type)) _pools.Add(item.type, tempList);
        }
    }

    public Transform GetItemFromPool(NormalItem.eNormalType type)
    {
        var tempItem =  _pools[type].FirstOrDefault(item => !item.gameObject.activeSelf);
        if (tempItem != null)
        {
            tempItem.localScale = Vector3.one;
            tempItem.gameObject.SetActive(true);
            return tempItem;
        }
        
        var newItem = Instantiate(GetPrefabByType(type), poolTransform);
        newItem.SetActive(false);
        newItem.transform.localScale = Vector3.one;
        _pools[type].Add(newItem.transform);
        newItem.SetActive(true);
        return newItem.transform;
    }

    private GameObject GetPrefabByType(NormalItem.eNormalType type)
    {
        return listItemObjects.FirstOrDefault(item => item.type == type)?.prefab;
    }
}

[Serializable]
public class ItemObject
{
    public NormalItem.eNormalType type;
    public GameObject prefab;
}
