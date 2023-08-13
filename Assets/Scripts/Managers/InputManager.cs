using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static bool InputActivated = false;

    public static void ActivateInput()
    {
        InputActivated = true;
    }

    public static void DeactivateInput()
    {
        InputActivated = false;
    }
}
