using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//Nyctophobia go brrrrrrrrrrrrrrrr
[RequireComponent(typeof(CustomTrigger))]
public class DarkRoomEnterance : MonoBehaviour
{
    private CustomTrigger trigger;

    [SerializeField] private Light2D playerLight;

    [SerializeField] private float maxLightRadius = 7f;

    [SerializeField] private float darkRoomLightRadius = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<CustomTrigger>();
        trigger.OnPlayerEnter += OnRoomEnter;
        trigger.OnPlayerExit += OnRoomExit;
    }

    // Update is called once per frame
    void Update()
    {
        DebugDarkRoom();
    }
    
    private void DebugDarkRoom()
    {
        //draw a box around the trigger
        var size = trigger.GetComponent<BoxCollider2D>().size;
        var pos = trigger.transform.position;
        var offset = trigger.GetComponent<BoxCollider2D>().offset;
        var box = new Rect(pos.x + offset.x - size.x / 2, pos.y + offset.y - size.y / 2, size.x, size.y);
        Debug.DrawLine(new Vector3(box.xMin, box.yMin), new Vector3(box.xMax, box.yMin),Color.black);
        Debug.DrawLine(new Vector3(box.xMin, box.yMin), new Vector3(box.xMin, box.yMax),Color.black);
        Debug.DrawLine(new Vector3(box.xMax, box.yMax), new Vector3(box.xMax, box.yMin),Color.black);
        Debug.DrawLine(new Vector3(box.xMax, box.yMax), new Vector3(box.xMin, box.yMax),Color.black);
    }

    void OnRoomEnter()
    {
        Debug.Log("Dark room entered");

        LeanTween.value( gameObject, playerLight.pointLightOuterRadius, darkRoomLightRadius, 1f).setOnUpdate( (float val)=>{  Debug.Log(playerLight.pointLightOuterRadius = val); } );

    }

    void OnRoomExit()
    {
        Debug.Log("Room Exit");
        
        LeanTween.value( gameObject, playerLight.pointLightOuterRadius, maxLightRadius, 1f).setOnUpdate( (float val)=>{  Debug.Log(playerLight.pointLightOuterRadius = val); } );
    }
}
