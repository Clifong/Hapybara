using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BestiaryManager : MonoBehaviour
{
    [Header("D1")]
    public List<EnemySO> d1Enemies;
    public Transform d1Content;
    public GameObject d1Platform;
    [Header("D2")]
    public List<EnemySO> d2Enemies;
    public Transform d2Content;
    public GameObject d2Platform;
    [Header("D3")]
    public List<EnemySO> d3Enemies;
    public Transform d3Content;
    public GameObject d3Platform;
    [Header("D4")]
    public List<EnemySO> d4Enemies;
    public Transform d4Content;
    public GameObject d4Platform;
    [Header("D5")]
    public List<EnemySO> d5Enemies;
    public Transform d5Content;
    public GameObject d5Platform;
    [Header("Enemy info")]
    public Image enemyImage;
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyDescriptionText;

    private List<GameObject> allSpawnedPlatforms = new List<GameObject>();
    private List<List<EnemySO>> allEnemiesList;
    private List<Transform> allTransformList;
    private List<GameObject> allPlatformsList;

    void OnEnable() {
        allEnemiesList = new List<List<EnemySO>>() {d1Enemies, d2Enemies, d3Enemies, d4Enemies, d5Enemies};
        allTransformList = new List<Transform>() {d1Content, d2Content, d3Content, d4Content, d5Content};
        allPlatformsList = new List<GameObject>() {d1Platform, d2Platform, d3Platform, d4Platform, d5Platform};
        SpawnIcon();
    }

    public void SpawnIcon() {
        foreach (GameObject platform in allSpawnedPlatforms)
        {
            Destroy(platform);
        }
        allSpawnedPlatforms.Clear();
        for (int i = 0; i < allTransformList.Count; i++) {
            List<EnemySO> enemyList = allEnemiesList[i];
            Transform content = allTransformList[i];
            GameObject platform = allPlatformsList[i];
            foreach (EnemySO enemySO in enemyList)
            {
                GameObject spawnedPlatform = Instantiate(platform, content);
                spawnedPlatform.GetComponent<BestiaryIcon>().SetInfo(enemySO);
                allSpawnedPlatforms.Add(spawnedPlatform);
            }
        }
    }

    public void FillInfo(Component component, object obj) {
        object[] temp = (object[]) obj;
        EnemySO enemySO = (EnemySO) temp[0];
        enemySO.FillBestiaryInfo(enemyImage, enemyNameText, enemyDescriptionText);
    }
}
