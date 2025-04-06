using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : PortalBase
{
    protected override void virMethod(Transform obj)
    {
        SceneManager.LoadScene(2);
    }
}