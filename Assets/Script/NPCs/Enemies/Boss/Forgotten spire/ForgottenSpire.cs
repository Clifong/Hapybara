using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgottenSpire : Boss
{
    private CircleCollider2D circleCollider2D;
    private Animator anime;
    public CrossObjectEventWithData broadcastMessage;
    public GameObject rainSpawn;
    public List<Transform> rainSpawnPosition;
    public GameObject corruptedGround;
    public int spawnTimer;
    private bool spawnEnemy = false;
    private List<GameObject> spawnedEnemies;
    public CrossObjectEvent forgottenSpielChangePhase;
    public CrossObjectEvent forgottenSpielResumeSecondPhase;

    void Awake() {
        spawnedEnemies = new List<GameObject>();
        updateHealthBar = healthBar;
        phase = 0;
        enemySO = bossPhaseSO[phase];
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);    
        circleCollider2D = GetComponent<CircleCollider2D>();
        anime = GetComponentInChildren<Animator>();
    }

    public override void Die() {
        phase += 1;
        if (phase == bossPhaseSO.Count) {
            foreach (GameObject enemy in spawnedEnemies)
            {
                Destroy(enemy);
            }
            characterDied.TriggerEvent(this, this);
            dropLoot.TriggerEvent(this, enemySO);
            broadcastAchievementGained.TriggerEvent(this, allAchievementObtainable);
            Destroy(this.gameObject);
        } else {
            circleCollider2D.enabled = false;
            forgottenSpielChangePhase.TriggerEvent();
            broadcastMessage.TriggerEvent(this, "Something's bubbling up from the ground", forgottenSpielResumeSecondPhase);
        }
    }

    public void BlastHurt(Component component, object obj) {
        object[] temp = (object[]) obj;
        GetAttacked((int) temp[0]);
    }

    public void Resume() {
        spawnEnemy = true;
        corruptedGround.SetActive(true);
        enemySO = bossPhaseSO[phase]; 
        SetStats(enemySO.health, enemySO.attack, enemySO.defence, enemySO.speed);
        AlertHealthChange();   
    }

    void Update() {
        if (spawnEnemy && spawnedEnemies.Count < 5) {
            StartCoroutine(Spawn());
            spawnEnemy = false;
        }
    }

    public void RemoveDeadEnemy(Component component, object obj) {
        spawnedEnemies.Remove(((Enemy) component).gameObject);
    }

    public void AddDropletFish(Component component, object obj) {
        object[] temp = (object[]) obj;
        spawnedEnemies.Add((GameObject) temp[0]);
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(spawnTimer); 
        GameObject spawnedEnemy = Instantiate(rainSpawn, rainSpawnPosition[Random.Range(0, rainSpawnPosition.Count - 1)]);
        spawnEnemy = true;
    }

}
