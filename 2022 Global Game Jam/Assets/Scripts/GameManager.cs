using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }
    public int cagesFreedCount = 0;
    public int cagesToBeFreed;
    public Text cagesCountText;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefabs();
        UpdateCagesCountUI();
    }
    private void SpawnPrefabs()
    {
        SpawnPoint[] findSpawnPoints = FindObjectsOfType<SpawnPoint>();
        for(int i = 0; i < findSpawnPoints.Length; i++)
        {
            int canSpawn = Random.Range(0, 2);
            switch(findSpawnPoints[i].typeToSpawn)
            {
                case SpawnPoint.SpawnType.Player:
                    SpawnPlayer(findSpawnPoints[i].transform.position);
                    break;
                case SpawnPoint.SpawnType.Tree:
                    if(canSpawn == 1)
                    {
                        SpawnTree(findSpawnPoints[i].transform.position);
                    }
                    break;
                case SpawnPoint.SpawnType.Cage:
                    if (canSpawn == 1)
                    {
                        SpawnCage(findSpawnPoints[i].transform.position);
                        //SpawnPrisoner(findSpawnPoints[i].transform.position);
                        cagesToBeFreed++;
                    }
                    break;
                case SpawnPoint.SpawnType.Enemy:
                    if(canSpawn == 1)
                    {
                        SpawnEnemy(findSpawnPoints[i].transform.position);
                    }
                    break;
            }
        }
    }
    private void SpawnPlayer(Vector3 spawnPosition)
    {
        GameObject go = Instantiate((GameObject)Resources.Load("Prefabs/Player"));
        go.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
        FindObjectOfType<CameraMovement>().target = go.transform;
    }
    private void SpawnTree(Vector3 spawnPosition)
    {
        GameObject go = Instantiate((GameObject)Resources.Load("Prefabs/Tree"));
        go.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }
    private void SpawnCage(Vector3 spawnPosition)
    {
        GameObject go = Instantiate((GameObject)Resources.Load("Prefabs/Cage"));
        go.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
        GameObject spawnPrisoner = SpawnPrisoner(spawnPosition);
        go.GetComponent<Cage>().trappedPrisoner = spawnPrisoner;
    }
    private GameObject SpawnPrisoner(Vector3 spawnPosition)
    {
        GameObject go = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Prisoners/Prisoner{0}", Random.Range(1, 11).ToString())));
        go.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
        return go;
    }
    private void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject go = Instantiate((GameObject)Resources.Load("Prefabs/Enemy"));
        go.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }
    public void UpdateCagesCountUI()
    {
        if(cagesCountText != null)
        {
            cagesCountText.text = string.Format("Prisoners freed: {0}/{1}", cagesFreedCount.ToString(), cagesToBeFreed.ToString());
        }
    }
}
