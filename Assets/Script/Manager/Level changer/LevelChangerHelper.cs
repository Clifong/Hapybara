using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangerHelper : MonoBehaviour
{
    public string sceneName;
    public void ChangeLevel() {
        LevelChanger.LoadLevel(this, sceneName);
    }
}
