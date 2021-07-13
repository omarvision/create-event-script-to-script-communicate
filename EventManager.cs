using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Note: define listener interface - void SpawnPrefabsDone(int)   ...a void function that takes an int
    //      define event - OnSpawnPrefabDone
    public delegate void SpawnPrefabsDone(int NumPrefabs);
    public static event SpawnPrefabsDone OnSpawnPrefabDone;

    public GameObject Prefab = null;
    public int Count = 100;

    private void Awake()
    {
        StartCoroutine(SpawnPrefabs());
    }
    private IEnumerator SpawnPrefabs()
    {
        //work
        for (int i = 0; i < Count; i++)
        {
            GameObject ball = Instantiate(Prefab, this.transform);
            float sz = 1.0f;
            float space = Random.Range(5.0f, 10.0f);
            ball.transform.localScale = new Vector3(sz, sz, sz);
            ball.transform.position = new Vector3(Random.Range(-space, space), Random.Range(10.0f, 15.0f), Random.Range(-space, space));
            ball.GetComponent<Rigidbody>().mass = Random.Range(1.0f, 20.0f);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }

        //fire event (check subscribers 1st so no runtime error)
        if (OnSpawnPrefabDone != null)
        {
            OnSpawnPrefabDone(Count);
        }
    }
}
