using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGuppy : MonoBehaviour
{

    [SerializeField] private List<Transform> Guppys;
    [SerializeField] private Vector2 bounds;
    [SerializeField] private float speed = 1;
    [SerializeField] private float timeBetMove = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float timePassed = 0;
    // Update is called once per frame
    void Update()
    {
       // only run this code once every 5 seconds
        timePassed += Time.deltaTime;
        if (timePassed > timeBetMove)
        {
            timePassed = 0;
            foreach (var g in Guppys)
            {
                //pick a random position within the bounds and move the guppy to that position using LeanTween ONLY CHANGE LOCAL POSITION
                Vector3 randomPos = new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));
                LeanTween.moveLocal(g.gameObject, randomPos, speed);


            }
            
        }

    }
}
