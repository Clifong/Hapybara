using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBuffManager : MonoBehaviour
{
    [SerializeField]
    private DungeonBuffContainerSO buffs;

    void Start() {
        buffs.ResetAllSkills();
    }

    public void AddBuff(Component component, object obj) {
        object[] temp = (object[])obj;
        foreach (DungeonBuffSO buffSO in (List<DungeonBuffSO>)temp[0])
        {
            if (buffSO is InstaKillSO) {
                buffs.instaKillSO = (InstaKillSO) buffSO;
            }
        }
    }

    public void CheckInstaKill(Component component, object obj) {
        object[] temp = (object[])obj;
        List<Npc> allPlayer = (List<Npc>)temp[0];
        List<Npc> allEnemy = (List<Npc>)temp[1];
        buffs.CheckIfCanInstaKillEnemy(allPlayer, allEnemy);
    }
}
