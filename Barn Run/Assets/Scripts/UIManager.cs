using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject Instructions;		// Creates Instructions Part 1 Object
	public GameObject Instructions2;	// Creates Instructions Part 2 Object
	public GameObject Instructions3;	// Creates Instructions Part 3 Object
	public GameObject Instructions4;	// Creates Instructions Part 4 Object
	public GameObject Instructions5;	// Creates Instructions Part 5 Object
	public GameObject Instructions6;	// Creates Instructions Part 6 Object
	public GameObject Instructions7;	// Creates Instructions Part 7 Object

	public GameObject Hiscores;			// Creates Hiscore object
    public GameObject Credits;			// Creates Credit Object
    public GameObject Settings;			// Creates Setting Object
	public GameObject GameShop;			// Creates GameShop Object
	public GameObject ChickenCoop;		// Creates The Coop Object
    public GameObject AreYouSure;		// Creates a AreYouSure check object for players
    public bool mute = false;			// Mute Audio Boolean
    public AudioClip click;				// A Click Sound

    private int coins;					// Monies Initialization

	/* START APP
     * PLAYS BACKGROUD MUSIC
     */
    void Start()
    {
		GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = click;
    }

    /* LOADS INPUT LEVEL */
    public void LoadLevel(string level)     //loads scene specified in the editor
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    /* EXITS BARN RUN GAME */
    public void ExitGame()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }

	/* OPENS UP THE BARN SHOP */
	public void OpenShop(string TheBarn)
	{
		GetComponent<AudioSource>().Play();
		SceneManager.LoadScene (TheBarn);
	}

	/* CLOSES THE BARN SHOP */
	public void CloseShop(string level)
	{
		GetComponent<AudioSource>().Play();
		SceneManager.LoadScene (level);
	}

	/* OPENS UP THE COOP SHOP */
	public void OpenCoop(string TheCoop)
	{
		GetComponent<AudioSource>().Play();
		SceneManager.LoadScene (TheCoop);
	}

	/* CLOSES THE COOP SHOP */
	public void CloseCoop(string level)
	{
		GetComponent<AudioSource>().Play();
		SceneManager.LoadScene (level);
	}

	/* DISPLAY TOP 3 HISCORES */
	public void OpenHiscores()
	{
		GetComponent<AudioSource>().Play();
		Hiscores.SetActive(true);
    }

	/* CLOSES THE DISPLAY OF HISCORES */
	public void CloseHiscores()
	{
		GetComponent<AudioSource>().Play();
		Hiscores.SetActive(false);
	}

    /* DISPLAY INSTRUCTIONS ON HOW TO PLAY THE GAME */
    public void OpenInstructions()
    {
        GetComponent<AudioSource>().Play();
        Instructions.SetActive(true);
    }

	public void OpenInstructions2()
	{
		GetComponent<AudioSource>().Play();
		Instructions2.SetActive(true);
	}

	public void OpenInstructions3()
	{
		GetComponent<AudioSource> ().Play ();
		Instructions3.SetActive (true);
	}

	public void OpenInstructions4()
	{
		GetComponent<AudioSource> ().Play ();
		Instructions4.SetActive (true);
	}

	public void OpenInstructions5()
	{
		GetComponent<AudioSource> ().Play ();
		Instructions5.SetActive (true);
	}

	public void OpenInstructions6()
	{
		GetComponent<AudioSource> ().Play ();
		Instructions6.SetActive (true);
	}

	public void OpenInstructions7()
	{
		GetComponent<AudioSource> ().Play ();
		Instructions7.SetActive (true);
	}

	/* CLOSES ALL THE DISPLAY OF INSTRUCTIONS */
    public void CloseAllInstructions()
	{
        GetComponent<AudioSource>().Play();
        Instructions.SetActive(false);
		Instructions2.SetActive(false);
		Instructions3.SetActive(false);
		Instructions4.SetActive(false);
		Instructions5.SetActive(false);
		Instructions6.SetActive(false);
		Instructions7.SetActive(false);
    }

	/* DISPLAYS ALL CREDITS - GIVES CREDITS TO ANY CONTRIBUTORS OR DEVELOPERS */
    public void OpenCredits()
    {
        GetComponent<AudioSource>().Play();
        Credits.SetActive(true);
    }

	/* CLOSES THE DISPLAY OF CREDITS ON BARN RUN */
    public void CloseCredits()
    {
        GetComponent<AudioSource>().Play();
        Credits.SetActive(false);
    }

	/* OPENS UP BARN RUN SETTINGS */
    public void OpenSettings()
    {
        GetComponent<AudioSource>().Play();
        Settings.SetActive(true);
    }

	/* CLOSES BARN RUN SETTINGS */
    public void CloseSettings()
    {
        GetComponent<AudioSource>().Play();
        Settings.SetActive(false);
    }

	/* THIS POPS UP A SCREEN FOR VARIOUS MENU OPTIONS */
    public void OpenPopup()
    {
        GetComponent<AudioSource>().Play();
        AreYouSure.SetActive(true);
        Time.timeScale = 0;
    }

	/* THIS CLOSES THOSE SAID POP UPS */
    public void ClosePopup()
    {
        GetComponent<AudioSource>().Play();
        AreYouSure.SetActive(false);
        Time.timeScale = 1;
    }

	/* MUTES IN GAME AUDIO */
    public void Mute()
    {
        GetComponent<AudioSource>().Play();
        if (mute == false)
        {
            AudioListener.pause = true;
            mute = true;
        }
        else
        {
            AudioListener.pause = false;
            mute = false;
        }
    }

	/* RESETS IN GAME HISCORES */
	public void ResetHighscore()
	{
		GetComponent<AudioSource> ().Play ();
		PlayerPrefs.DeleteKey("High Score");
		PlayerPrefs.DeleteKey ("High Score 2");
		PlayerPrefs.DeleteKey ("High Score 3");
	}
}
