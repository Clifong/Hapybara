using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public PlayerPartySO playerPartySO;


    void Start()
    {
        playerPartySO.TownRecovery();
    }

   
}
