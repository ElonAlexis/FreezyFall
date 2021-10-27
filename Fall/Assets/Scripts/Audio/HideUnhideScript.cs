using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhideScript : MonoBehaviour
{
    public void Hide()
    {
        MusicManager.instance.hide = true;
    }
    public void DontHide()
    {
        MusicManager.instance.hide = false;
    }
}
