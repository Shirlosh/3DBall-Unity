using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private float threshold;
    [SerializeField] public Transform Menu;
    [SerializeField] public Transform Ball;
    [SerializeField] public Transform Game;
    [SerializeField] public Transform HowToPlay;
    [SerializeField] public Transform howToPlay1;
    [SerializeField] public Transform howToPlay2;
    
    public AudioSource music;
    private bool PlaySound = true;
    
    // Update is called once per frame
    void Update()
    {
        if (Ball.position.y < threshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void Play()
    {
        Menu.gameObject.SetActive(false); 
        Game.gameObject.SetActive(true);
    }
    
    public void MusicOnOffButton(){
        PlaySound = !PlaySound;
        if (PlaySound)
        {
            music.Play ();
        } 
        else 
        {
            music.Stop();
        }
    }
    public void HowToPlayButton()
    {
        Menu.gameObject.SetActive(false);
        HowToPlay.gameObject.SetActive(true);
        Debug.Log("actived");
    }


    public void NextHowToPlay1()
    {
        howToPlay1.gameObject.SetActive(false);
        howToPlay2.gameObject.SetActive(true);
    }

    public void NextHowToPlay2()
    {
        howToPlay2.gameObject.SetActive(false);
        HowToPlay.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
    }
}
