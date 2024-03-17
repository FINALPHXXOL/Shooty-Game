using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnPoint : MonoBehaviour
{
    public void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AISpawns.Add(this);
        }
    }

    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AISpawns.Remove(this);
        }
    }
}
