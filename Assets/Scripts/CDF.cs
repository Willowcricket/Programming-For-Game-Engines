using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemToDrop
{
    public GameObject item;
    public int weight;
}

public class CDF : MonoBehaviour
{
    public List<ItemToDrop> dropables;
    private List<int> CDFList;

    public void DropARandoItem()
    {
        int randomnumber = Random.Range(0, CDFList[CDFList.Count - 1]);

        /*for (int i = 0; i < CDFList.Count; i++)
        {
            if (randomnumber < CDFList[i])
            {
                Instantiate(dropables[i].item, transform.position, transform.rotation);
                return;
            }
        }*/

        int selectedIndex = System.Array.BinarySearch(CDFList.ToArray(), randomnumber);
        if (selectedIndex < 0)
        {
            selectedIndex = ~selectedIndex;
        }
        Instantiate(dropables[selectedIndex].item, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        CDFList = new List<int>();
        for (int i = 0; i < dropables.Count; i++)
        {
            if (i == 0)
            {
                CDFList.Add(dropables[i].weight);
            }
            else
            {
                CDFList.Add(dropables[i].weight + CDFList[i - 1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
