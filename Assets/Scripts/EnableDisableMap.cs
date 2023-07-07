
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableMap : MonoBehaviour
{
    [SerializeField] private GameObject map;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
        
    }
}
