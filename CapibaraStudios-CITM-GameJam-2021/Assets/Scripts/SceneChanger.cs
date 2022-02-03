using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public int nextSceneIndex;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
