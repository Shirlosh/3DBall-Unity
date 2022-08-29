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
    private bool _playSound = true;

    // Update is called once per frame
    void Update()
    {
        if (Ball.position.y < threshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CameraMovement.beginGame = false;
        }
    }

    public void Play()
    {
        Menu.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
        CameraMovement.beginGame = true;
    }

    public void MusicOnOffButton()
    {
        _playSound = !_playSound;
        if (_playSound)
        {
            music.Play();
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
    }


    public void NextHowToPlay1()
    {
        howToPlay1.gameObject.SetActive(false);
        howToPlay2.gameObject.SetActive(true);
    }

    public void NextHowToPlay2()
    {
        howToPlay2.gameObject.SetActive(false);
        howToPlay1.gameObject.SetActive(true);
        HowToPlay.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
    }
}