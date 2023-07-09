using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class PlayerControllerEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(EnableController),1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void EnableController()
    {
        GetComponent<PlayerController>().enabled = true;
    }
}
