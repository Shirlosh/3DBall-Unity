using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    
    //[SerializeField] public Transform EndGame;

    private void OnTriggerEnter(Collider other)
    {
        MoveBall component = other.gameObject.GetComponent<MoveBall>();
        if (component != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //EndGame.gameObject.SetActive(true);
        }
    }
}
