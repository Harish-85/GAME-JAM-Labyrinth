using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellOutOfWorldPrevention : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerLocationBroadcaster.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < -100)
            PlayerDeathManager.DeathManager.OnDie();
    }
}
