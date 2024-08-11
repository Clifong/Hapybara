using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    private string currScene;

    public void Die() {
        if (currScene.Contains("Dungeon 1")) {
            LevelChanger.LoadLevel(this, "Town 1");
        } else if (currScene.Contains("Dungeon 2")) {
            LevelChanger.LoadLevel(this, "Town 2");
        } else if (currScene.Contains("Dungeon 3")) {
            LevelChanger.LoadLevel(this, "Town 3");
        } else if (currScene.Contains("Dungeon 4")) {
            LevelChanger.LoadLevel(this, "Town 4");
        } else if (currScene.Contains("Dungeon 5")) {
            LevelChanger.LoadLevel(this, "Town 5");
        }
    }

    void Update() {
        string tempScene = LevelChanger.GetCurrentLevel();
        if (tempScene.Contains("Dungeon")) {
            currScene = tempScene;
        }
    } 
}
