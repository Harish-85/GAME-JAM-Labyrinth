using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CustomTrigger))]
public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CustomTrigger>().OnPlayerEnter += OnPlayerEnter;
        GetComponent<CustomTrigger>().OnPlayerExit += OnPlayerEnter;
    }

    private void OnPlayerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
