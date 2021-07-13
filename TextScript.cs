using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for Text

public class TextScript : MonoBehaviour
{
    private Text txt = null;

    private void Start()
    {
        txt = this.GetComponent<Text>();
        txt.text = "Spawning...";
    }
    private void OnEnable()
    {
        //add listener
        EventManager.OnSpawnPrefabDone += DisplayMessage;
    }
    private void OnDisable()
    {
        //remove listener
        EventManager.OnSpawnPrefabDone -= DisplayMessage;
    }
    private void DisplayMessage(int Count)
    {
        txt.text = "Spawned " + Count.ToString() + " Balls";
    }
}
