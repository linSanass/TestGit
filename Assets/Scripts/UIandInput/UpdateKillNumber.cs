using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateKillNumber : MonoBehaviour
{
    public Text killNumberText;

    // Update is called once per frame
    void Update()
    {
        killNumberText.text = "»÷°ÜµÐÈËÊýÁ¿£º" + AttackPlayer.KillNumber;
    }
}
