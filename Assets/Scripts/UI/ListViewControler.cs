using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ListViewControler : MonoBehaviour
{

    public GameObject items;
    public GameObject lists;
    private ScrollRect scroll;
    // Start is called before the first frame update
    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
    }

    public void SetItem(GameObject items)
    {
        this.items = items;
    }

    public void Clear()
    {
        foreach(Transform child in lists.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Add()
    {
        
    }

    public void UpdateItem()
    {

    }

    public void UpdateList()
    {
        Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
