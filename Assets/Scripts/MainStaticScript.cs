using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class MainStaticScript
{
    public static Text messageText;

    public static void SetMessage(string message)
    {
        if (message.Equals("")) return;
        messageText.text = message;
    }
}
