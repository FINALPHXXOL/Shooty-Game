using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;

    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject pawnPrefab;
    public GameObject AIControllerPrefab;
    public Transform playerSpawnTransform;
    public Transform enemyAISpawnTransform;

    //Lists
    public List<PlayerController> players;
    public List<AIController> enemyAIs;
    public List<PlayerSpawnPoint> playerSpawns;
    public List<AISpawnPoint> AISpawns;

    #endregion Variables

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        players = new List<PlayerController>();
        enemyAIs = new List<AIController>();
        playerSpawns = new List<PlayerSpawnPoint>();
        AISpawns = new List<AISpawnPoint>();
    }

    private void Start()
    {

    }

    public void QuitTheGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void SpawnPlayer()
    {
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        GameObject newPawnObj = Instantiate(pawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;
        newPawn.controller = newController;

        Camera spawnedCamera = newPawnObj.GetComponentInChildren<Camera>();
    }

    public void SpawnAI()
    {
        GameObject newAIObj = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity);
        GameObject newPawnObj = Instantiate(pawnPrefab, enemyAISpawnTransform.position, enemyAISpawnTransform.rotation);

        AIController newController = newAIObj.GetComponent<AIController>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;
        newPawn.controller = newController;
    }
}
