using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {

    static bool audioBegin = false;

    // Use this for initialization
	void Awake()
    {
		if(!audioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            audioBegin = true;
        }
	}
	
	// Update is called once per frame
	void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GetComponent<AudioSource>().Play();
            audioBegin = false;
        }
	}
}
