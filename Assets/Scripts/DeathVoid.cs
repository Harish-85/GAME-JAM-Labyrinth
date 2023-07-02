using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVoid : MonoBehaviour
{

    [SerializeField] private int rayCount;

    [SerializeField]private float width;
    [SerializeField] private float rayLength;
    [SerializeField] private float startOffset;

    [SerializeField] private LayerMask l;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        CastRays();
    }

    bool CastRays()
    {
        //cast a ray from the left to right pointing to the top
        //if any of the rays hit the player, return true
        //else return false
        
        //get the direction of the ray
        var direction = Vector2.up;
        //get the start position of the ray
        for( int i = 0; i < rayCount; i++)
        {
            var startPos = transform.position + Vector3.left * width / 2 + Vector3.right * width / (rayCount - 1) * i + (Vector3.up * startOffset);
            var hit = Physics2D.Raycast(startPos, direction, rayLength,l);
            if (hit.collider != null)
            {
                
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player hit");
                    return true;
                }
                else
                {
                    Debug.Log("Hit something eldses");
                }
            }
            
            Debug.DrawLine(startPos ,  Vector3.up * startOffset+startPos + new Vector3((direction*rayLength).x,(direction*rayLength).y,0), Color.red);
        }

        return false;
    }
}
