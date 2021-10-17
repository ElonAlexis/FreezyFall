using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    
    void OnMouseDown()
    {
        MusicManager.instance.OnButtonPress();        
    }
}
