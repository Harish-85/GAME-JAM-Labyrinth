using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGuppy : MonoBehaviour
{

    [SerializeField] private List<Transform> Guppys;
    [SerializeField] private Vector2 bounds;
    [SerializeField] private float speed = 1;
    [SerializeField] private float timeBetMove = 1;
    [SerializeField] private List<LTDescr> tweenDescrs;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.init(1000);
        tweenDescrs = new List<LTDescr>();
    }

    private float timePassed = 0;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(LeanTween.tweensRunning);
       // only run this code once every 5 seconds
        timePassed += Time.deltaTime;
        if (timePassed > timeBetMove)
        {
            timePassed = 0;

            foreach (var descr in tweenDescrs)
            {
                LeanTween.cancel(descr.id);
            }
            tweenDescrs.Clear();

            foreach (var g in Guppys)
            {
                
                Vector3 randomPos = new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));
                tweenDescrs.Add(LeanTween.moveLocal(g.gameObject, randomPos, speed));
            }
            
        }

    }
}
