using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    public PlayerUnlokedCollectiblesSO unlockedCollectibleSO;
    public PlayerPartySO playerPartySO;
    [Header("Books")]
    public Transform booksContent;
    public GameObject booksPanel;
    public Image bookIcon;
    public TextMeshProUGUI storyText;
    private List<GameObject> allInstantiatedBooksPanel = new List<GameObject>();
    [Header("Achievements")]
    public Transform achievementContent;
    public GameObject achievementPanel;
    private List<GameObject> allInstantiatedAchievementPanel = new List<GameObject>();
    [Header("Friendship")]
    public Transform friendshipContent;
    public GameObject friendshipFrame;
    private List<GameObject> allInstantiatedFriendshipPanel = new List<GameObject>();

    public void PopulateBooksUI() {
        foreach (GameObject instantiatedBookPanel in allInstantiatedBooksPanel)
        {
            Destroy(instantiatedBookPanel);
        }
        allInstantiatedBooksPanel.Clear();
        foreach (BookSO bookSO in unlockedCollectibleSO.allUnlockedBooks)
        {   
            GameObject instantiatedBookPanel = Instantiate(booksPanel, booksContent);
            instantiatedBookPanel.GetComponent<BookPanel>().SetInfo(bookSO);
            allInstantiatedBooksPanel.Add(instantiatedBookPanel);
        }
    }

    public void PopulateBookTextSection(Component component, object obj) {
        object[] temp = (object[]) obj;
        BookSO bookSO = (BookSO) temp[0];
        bookSO.SetIconAndStoryText(bookIcon, storyText);
    }

    public void PopulateAchievementUI() {
        foreach (GameObject instantiatedAchievementPanel in allInstantiatedAchievementPanel)
        {
            Destroy(instantiatedAchievementPanel);
        }
        allInstantiatedAchievementPanel.Clear();
        foreach (AchievementSO achievementSO in unlockedCollectibleSO.allAchievement)
        {   
            GameObject instantiatedAchievementPanel = Instantiate(achievementPanel, achievementContent);
            instantiatedAchievementPanel.GetComponent<AchievementPanel>().SetInfo(achievementSO);
            allInstantiatedAchievementPanel.Add(instantiatedAchievementPanel);
        }
    }

    public void PopulateFriendshipUI() {
        foreach (GameObject instantiatedFriendshipPanel in allInstantiatedFriendshipPanel)
        {
            Destroy(instantiatedFriendshipPanel);
        }
        allInstantiatedFriendshipPanel.Clear();
        foreach (PlayerSO playerSO in playerPartySO.allPartyMembers)
        {
            GameObject instantiatedFriendshipPanel = Instantiate(friendshipFrame, friendshipContent);
            instantiatedFriendshipPanel.GetComponent<FriendshipPanel>().SetInfo(playerSO);
            allInstantiatedFriendshipPanel.Add(instantiatedFriendshipPanel);
        }
    }

    public void UnlockedAchievement(Component component, object obj) {
        object[] temp = (Object[]) obj;
        AchievementSO achievementSO = (AchievementSO) temp[0];
        achievementSO.UnlockAchievement();
        // EditorUtility.SetDirty(achievementSO);
    }
}
