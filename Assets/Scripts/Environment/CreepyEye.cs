using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyEye : MonoBehaviour
{


    [SerializeField] private Transform pupil;
    [SerializeField] private Vector2 ellipseAB;
    [SerializeField] private Transform playerT;

    [SerializeField] private float angleOffset;
    // Start is called before the first frame update
    void Start()
    {
        playerT = PlayerLocationBroadcaster.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //calulage angle between player and eye
        Vector3 playerPos = playerT.position;
        Vector3 eyePos = transform.position;
        Vector3 playerToEye = eyePos - playerPos;   
        float angle = Vector3.SignedAngle(playerToEye.normalized, Vector3.right,Vector3.forward) + angleOffset;
        Debug.Log(angle);
        angle *= Mathf.Deg2Rad;
        //put the angle in the parametric equation of an ellipse
        float x = ellipseAB.x * Mathf.Cos(angle);
        float y = ellipseAB.y * Mathf.Sin(angle);

        pupil.localPosition = new Vector2(x, y);

    }
}
