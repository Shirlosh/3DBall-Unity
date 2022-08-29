using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    
    [SerializeField] public Transform Victory;
    [SerializeField] public float TextTimer;

     void OnTriggerEnter(Collider other)
    {
        MoveBall component = other.gameObject.GetComponent<MoveBall>();
        if (component != null)
        {
            StartCoroutine(OnCollision()) ;
        }
    }

     IEnumerator OnCollision()
    {
        Time.timeScale = 0;
        Victory.gameObject.SetActive(true);
        float pauseEndTime = Time.realtimeSinceStartup + TextTimer;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
