using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPanel : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public Transform rewardContent;
    public GameObject rewardIcon;
    [SerializeField]
    private QuestSO questSO;
    public CrossObjectEventWithData broadcastAcceptedQuest;
    private List<GameObject> rewardIconList = new List<GameObject>();
    private Animator anime;

    void Start() {
        anime = GetComponent<Animator>();
    }

    public void SetInfo(QuestSO questSO) {
        foreach (GameObject icon in rewardIconList)
        {
            Destroy(icon);
        }
        rewardIconList.Clear();
        this.questSO = questSO;
        questSO.SetInfo(name, description, rewardContent, rewardIcon, rewardIconList);
    }

    public void BroadcastAcceptedQuest() {
        broadcastAcceptedQuest.TriggerEvent(this, questSO);
    }

    public void SetRemove() {
        this.transform.SetParent(null);
        anime.SetTrigger("Remove");
    }

    public void DestroyPaper() {
        Destroy(gameObject);
    }
}
