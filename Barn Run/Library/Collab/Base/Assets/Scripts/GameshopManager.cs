using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameshopManager : MonoBehaviour {

    public Text coinsText;

    private int coins;

    // Use this for initialization
    void Start ()
    {
        coins = PlayerPrefs.GetInt("Total Coins");
        coinsText.text = "Coins: " + coins.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
