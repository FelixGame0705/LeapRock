using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ListViewControler : MonoBehaviour
{

    public GameObject[] items;
    public GameObject lists;
    private ScrollRect scroll;
    // Start is called before the first frame update
    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
    }
    public void Clear()
    {
        foreach(Transform child in lists.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public GameObject GetModelItem(int index)
    {
        if (index < 0 || index >= items.Length) return null;
        else return items[index];
    }

    public void Add(GameObject item)
    {
        item.transform.localScale = new Vector3(1f, 1f, 1f);
        var input = GameObject.Instantiate(item);
        item.transform.parent = lists.transform;
    }

    public void UpdateItem()
    {

    }

    public void UpdateList(List<GameObject> listData)
    {
        Clear();
        foreach (GameObject item in listData)
        {
            item.transform.localScale = new Vector3(1f, 1f, 1f);
            item.transform.parent = lists.transform;
        }
    }
}
