using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageGeneratorPopUp : MonoBehaviour
{
    public static DamageGeneratorPopUp current;
    public GameObject prefab;

    private void Awake()
    {
        current = this; 
    }
    void Update()
    {
        
    }

    public void CreatePopUp(Vector3 position, string text)
    {
        var popup = Instantiate(prefab, position, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;

        //Destroy
        Destroy(popup, 1f);
    }
}
