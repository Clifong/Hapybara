using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : InteractableNPC
{
    public BartenderSO bartenderSO;
    private TavernRecruitmentManager tavernRecruitmentManager;
    void Start() {
        tavernRecruitmentManager = GetComponentInChildren<TavernRecruitmentManager>();
    }

    public override void Interact() {
        tavernRecruitmentManager.PopulateUI(bartenderSO);
    }
    
    public void RemoveRecruittedPlayer(Component component, object obj) {
        object[] temp = (object[])obj;
        PlayerSO selectedPlayer = (PlayerSO) temp[0];
        bartenderSO.RemovePlayer(selectedPlayer);
    }

}
