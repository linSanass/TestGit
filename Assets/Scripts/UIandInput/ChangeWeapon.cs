using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject weaponObj;

    public GameObject weaponIcon;

    private Button thisButton;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        thisButton = GetComponent<Button>();

        thisButton.onClick.AddListener(SetOnClick);
    }

    public void SetOnClick()
    {
        if (!weaponIcon.activeSelf||weaponIcon==null)
        { 
            return;
        }
        gameManager.SetWuqi(weaponObj);
    }
}
