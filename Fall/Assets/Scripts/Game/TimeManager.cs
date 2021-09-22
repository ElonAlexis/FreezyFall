
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float slowTime = 0.5f; 
    float slowDownLength = 50f;

    void Update()
    {
        if(Time.timeScale != 0)
        {
           Time.timeScale += (1f/slowDownLength) * Time.unscaledDeltaTime;
           Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        
    }    

    public void SlowMotion()
    {        
        Time.timeScale = slowTime; 
        Time.fixedDeltaTime = Time.timeScale * 0.02f;          
    }

}
