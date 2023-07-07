using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraVingnette : MonoBehaviour
{
    public static CameraVingnette Instance;
    
[SerializeField] private Volume volume;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void startVignette()
    {
        StartCoroutine(DeathVignette(1));
    }
    
    private IEnumerator DeathVignette(int time)
    {
        Vignette vig;
         volume.profile.TryGet(typeof(Vignette), out vig);
        LeanTween.value( volume.gameObject,vig.intensity.value , 0.5f, .5f).setOnUpdate( (float val)=>{  Debug.Log(vig.intensity.value = val); } );
        yield return new WaitForSeconds(1);
        LeanTween.value( volume.gameObject,vig.intensity.value , 0f, .5f).setOnUpdate( (float val)=>{  Debug.Log(vig.intensity.value = val); } );
        yield return null;
    }

}
