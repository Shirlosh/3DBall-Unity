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
}
