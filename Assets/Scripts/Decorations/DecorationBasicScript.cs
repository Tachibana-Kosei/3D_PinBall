using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class DecorationBasicScript : ControllerBasicScript
{

    protected virtual void Update()
    {
        if (mainSystem.gameState == MainSystemScript.GameState.Playing)
        {
            AfterLaunch();
        }
        else
        {
            BeforeLaunch();
        }
    }

    protected abstract void BeforeLaunch();
    protected abstract void AfterLaunch();
}
