using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DungeonThreeGameManager : MonoBehaviour
{
    public TextMeshProUGUI timerValue;
    private int filled = 0;
    private int killedEnemy = 0;
    private int corretAnswer = 0;
    public float timerForFirstGame;
    public float timerForSecondGame;
    public float timerForThirdGame;
    private float internalTimer;
    public CrossObjectEventWithData broadcastGameMessage;
    [Header("Second game")]
    public GameObject flamingHandObject;
    public List<Transform> spawnFlamingHandPosition;
    public CrossObjectEvent moveToGame2;
    public CrossObjectEvent startSecondGame;

    [Header("Third game")]
    public CrossObjectEvent moveToGame3;
    public CrossObjectEvent moveBack;
    public CrossObjectEvent startGameThree;
    public List<Transform> flameSpawnPoint;
    private List<GameObject> spawnedFlame = new List<GameObject>();
    public GameObject falseFlame;
    public GameObject trueFlame;
    public CrossObjectEvent firstGameFail;
    public CrossObjectEvent secondGameFail;
    public CrossObjectEvent thirdGameFail;
    private int currentGame;

    private bool isGame = false;
    

    void Start() {
        currentGame = 1;
        filled = 0;
        killedEnemy = 0;
        isGame = false;
    }

    public void StartGameOne() {
        isGame = true;
        internalTimer = timerForFirstGame;
        StartCoroutine(Delay("Activate all lava cube before timer ends!"));
    }

    public void StartGameTwo() {
        currentGame = 2;
        isGame = true;
        internalTimer = timerForSecondGame;
        foreach (Transform spawn in spawnFlamingHandPosition)
        {
            Instantiate(flamingHandObject, spawn);
        }
        StartCoroutine(Delay("Slaughter all enemies before the timer ends!"));
    }

    public void StartGameThree() {
        currentGame = 3;
        isGame = true;
        internalTimer = timerForThirdGame;
        SpawnFlames();
        StartCoroutine(Delay("Find the false flame (Odd one out) before the timer ends!"));
    }

    public void FirstGameIncrement() {
        filled++;
        Debug.Log(filled);
        if (filled == 4) {
            isGame = false;
            internalTimer = 0;
            moveToGame2.TriggerEvent();
            broadcastGameMessage.TriggerEvent(this, "Pernicious flame is getting riled up...", startSecondGame);
        }
    }

    public void SecondGameIncrement() {
        killedEnemy++;
        if (killedEnemy == 2) {
            isGame = false;
            internalTimer = 0;
            moveToGame3.TriggerEvent();
            broadcastGameMessage.TriggerEvent(this, "Excitement fills the air...", startGameThree);
        }
    }

    public void ThirdGameIncrement() {
        corretAnswer++;
        if (corretAnswer == 3) {
            isGame = false;
            moveBack.TriggerEvent();
            broadcastGameMessage.TriggerEvent(this, "Time for revenge!");
        }
    }

    public void CorrectChoice() {
        ThirdGameIncrement();
        SpawnFlames();
    }
    
    public void WrongChoice() {
        SpawnFlames();
    }

    public void SpawnFlames() {
        foreach (GameObject flame in spawnedFlame)
        {
            Destroy(flame);
        }
        spawnedFlame.Clear();
        int timeToSpawn = Random.Range(flameSpawnPoint.Count - 4, flameSpawnPoint.Count);
        bool falseFlameSpanwed = false;
        List<int> position = new List<int>();
        for (int i = 0; i < timeToSpawn - 1; i++) {
            int value = Random.Range(0, 1);
            if (value == 0) {
                int randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
                while (position.Contains(randomPos)) {
                    randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
                }
                position.Add(randomPos);
                GameObject sflame = Instantiate(trueFlame, flameSpawnPoint[randomPos]);
                spawnedFlame.Add(sflame);
            } else {
                if (falseFlameSpanwed) {
                    int randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
                    while (position.Contains(randomPos)) {
                        randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
                    }
                    position.Add(randomPos);
                    GameObject sflame = Instantiate(trueFlame, flameSpawnPoint[randomPos]);
                    spawnedFlame.Add(sflame);
                } else {
                    int randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
                    while (position.Contains(randomPos)) {
                        randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
                    }
                    position.Add(randomPos);
                    GameObject sflame = Instantiate(falseFlame, flameSpawnPoint[randomPos]);
                    spawnedFlame.Add(sflame);
                    falseFlameSpanwed = true;
                }
            }
        }
        if (!falseFlameSpanwed) {
            int randomPos = Random.Range(0, flameSpawnPoint.Count - 1);
            if (flameSpawnPoint[randomPos].childCount > 0) {
                GameObject ChildGameObject = flameSpawnPoint[randomPos].transform.GetChild(0).gameObject; 
                spawnedFlame.Remove(ChildGameObject);
                Destroy(ChildGameObject);
            }
            GameObject sflame = Instantiate(falseFlame, flameSpawnPoint[randomPos]);
            spawnedFlame.Add(sflame);
        }
    }

    void Update() {
        if (internalTimer <= 0) {
            if (isGame) {
                switch (currentGame) {
                    case 1:
                        firstGameFail.TriggerEvent();
                        break;
                    case 2:
                        secondGameFail.TriggerEvent();
                        break;
                    case 3:
                        thirdGameFail.TriggerEvent();
                        break;
                }
                isGame = false;
            }
        }
        timerValue.text = internalTimer.ToString();
        internalTimer -= Time.deltaTime;
        internalTimer = Mathf.Max(internalTimer, 0);
    }

    IEnumerator Delay(string text) {
        yield return new WaitForSeconds(0.5f);
        broadcastGameMessage.TriggerEvent(this, text);
    }
}
