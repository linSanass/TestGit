using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource BGM;

    private bool Pause;

    public AudioSource[] soundEffects;

    public List<GameObject> BagItems = new List<GameObject>();

    public List<GameObject> Wuqi = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Pause = false;
    }
    public void SetAudio()
    {
        if(!Pause)
        {
            BGM.Pause();
            Pause = true;
        }
        else
        {
            BGM.Play();
            Pause = false;
        }
    }

    private void Update()
    {
        if(AttackPlayer.KillNumber%10==0)
        {
            int num=(AttackPlayer.KillNumber/10)+1;
            for(int i=0; i<num; i++)
            {
                BagItems[i].SetActive(true);
            }
        }
    }

    public void PlaySFX(int sfxToplay)
    {
        if (!Pause)
        {
            soundEffects[sfxToplay].Play();
        }
    }
    public void PlaySFXpitched(int sfxToplay)
    {
        soundEffects[sfxToplay].pitch = Random.Range(.8f, 1.2f);

        PlaySFX(sfxToplay);
    }
    public void SetWuqi(GameObject gameObject)
    {
        foreach(GameObject wuqi in Wuqi)
        {
            wuqi.SetActive(false);
        }

        gameObject.SetActive(true);
    }
}
