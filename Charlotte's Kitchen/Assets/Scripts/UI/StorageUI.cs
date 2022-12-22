using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageUI : MonoBehaviour
{
    [SerializeField] Transform buttonParent;
    [SerializeField] RectTransform buttonPrefab;
    [SerializeField] Pickupable pickupable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddButton(string itemName)
    {
        Debug.Log(itemName);
        RectTransform newButton = Instantiate(buttonPrefab, buttonParent);
        newButton.name = itemName + " Button";
        newButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = itemName;

        newButton.GetComponentInChildren<TextMeshProUGUI>().SetText(itemName);


    }
}
