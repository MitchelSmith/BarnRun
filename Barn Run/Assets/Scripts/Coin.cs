using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private int totalCoins;

    public AudioClip coin;

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("Total Coins");

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = coin;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coin, new Vector2(transform.position.x, transform.position.y));   //plays audioclip at point of coin
            GameControl.coins++;
            totalCoins++;
            PlayerPrefs.SetInt("Total Coins", totalCoins);
            PlayerPrefs.Save();
            gameObject.SetActive(false);
        }
    }
}
