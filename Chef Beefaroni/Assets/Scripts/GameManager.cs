using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public static GameManager gameManager;
    public PlayerManager playerManager;

    [Header("Level Tile Prefabs")]
    public List<GameObject> TilesToChooseFrom;
    public GameObject TileParent;
    public int startingTiles;

    private List<GameObject> LevelTiles;
    private LevelTile LastTile;

    [Header("Object Prefabs")]
    public List<GameObject> ObjectPrefabs;
    public GameObject CoinPrefab;
    public GameObject SpecialCoinPrefab;

    [Header("UI")]
    public GameObject PurchaseUI;
    public GameObject UpgradePREFAB;
    public GameObject MoveUI;

    void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        if(GameObject.Find("UpgradeSystem(Clone)") == null)
        {
            Instantiate(UpgradePREFAB);
            PurchaseUI = GameObject.Find("Purchase UI");
            PurchaseUI.SetActive(false);
        }
        else
        {
            PurchaseUI = GameObject.Find("UpgradeSystem(Clone)").transform.GetChild(0).gameObject;
            PurchaseUI.SetActive(false);
        }

        LevelTiles = new List<GameObject>();
        
        for(int i = 0; i < TileParent.transform.childCount; i++)
        {
            LevelTiles.Add(TileParent.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        playerManager = PlayerManager.playerManager;
        StartGame();
    }

    void StartGame()
    {
        playerManager.RoundStart();
        for(int i = 0; i < startingTiles; i++)
        {
            SpawnSection();
        }
    }

    void SpawnSection()
    {
        GameObject newTile = Instantiate(TilesToChooseFrom[Random.Range(0, TilesToChooseFrom.Count)], TileParent.transform);

        if(LastTile != null) newTile.transform.position = LastTile.tileEnd.position;
        else newTile.transform.position = TileParent.transform.position - new Vector3(0,0,10);

        LevelTiles.Add(newTile);
        LastTile = newTile.GetComponent<LevelTile>();
    }

    public void TileChange()
    {
        Destroy(LevelTiles[0]);
        LevelTiles.RemoveAt(0);

        SpawnSection();
    }

    public void SceneReset()
    {
        MoveUI.SetActive(false);
        PurchaseUI.SetActive(true);
        playerManager.RoundActive = false;
        //SceneManager.LoadScene("Dylan Test");
    }

}
