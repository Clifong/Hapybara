using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStatusAlinmentIcon : MonoBehaviour
{
    public Transform content;
    public GameObject allinmentIcons;
    private Dictionary<Sprite, GameObject> spawnedIcons = new Dictionary<Sprite, GameObject>();

    [Header("All icons")]
    public Sprite poisonedIcon;
    public Sprite burntIcon;

    public void SpawnSomeIcon(SkillsSO skillsSO) {
        if (skillsSO is PoisonSkillsSO) {
            if (!spawnedIcons.ContainsKey(poisonedIcon) || spawnedIcons[poisonedIcon] == null) {
                GameObject spawnedPoisonIcon = Instantiate(allinmentIcons, content);
                spawnedIcons[poisonedIcon] = spawnedPoisonIcon;
                spawnedPoisonIcon.GetComponent<AlinmentIcon>().SetInfo(poisonedIcon);
            }
        } else if (skillsSO is BurningSkillsSO) {
            if (!spawnedIcons.ContainsKey(burntIcon) || spawnedIcons[burntIcon] == null) {
                GameObject spawnedBurntnIcon = Instantiate(allinmentIcons, content);
                spawnedIcons[burntIcon] = spawnedBurntnIcon;
                spawnedBurntnIcon.GetComponent<AlinmentIcon>().SetInfo(burntIcon);
            }
        }
    }

    public void NoMorePoison() {
        DestroyIcon(poisonedIcon);
    }

    public void NoMoreBurn() {
        DestroyIcon(burntIcon);
    }
    
    public void DestroyIcon(Sprite icon) {
        GameObject spawnedIcon = spawnedIcons[icon];
        Destroy(spawnedIcon);
        spawnedIcons[icon] = null;
    }

    public void Reset() {
        List<Sprite> spawnedSprites = new List<Sprite>(spawnedIcons.Keys);
        foreach (Sprite sprite in spawnedSprites) {
            Destroy(spawnedIcons[sprite]);
            spawnedIcons[sprite] = null;
        }
    }
}
