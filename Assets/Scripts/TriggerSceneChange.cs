using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSceneChange : MonoBehaviour
{
    //Strings for loading a specific scene and setting the spawnpoint.
    public string sceneToLoad;
    public string spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Loads scene if the object has the player tag.
        if (other.tag == "Player")
        {
            GameManager.Instance.levelManager.LoadSceneWithSpawnPoint(sceneToLoad, spawnPoint);
        }
    }
}
