using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
        [Header("TimeControllerSettings")]
   public float TimeScale;

   private float StartTimeScale;
   private float StartFixedDeltaTime;


    void Start()
    {
      StartTimeScale = Time.timeScale;
      StartFixedDeltaTime = Time.fixedDeltaTime;
    }

    
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.C))
      {
         StartSlowMotion();
      }

      if(Input.GetKeyUp(KeyCode.C))
      {
         StopSlowMotion();
      }
    }

   public void StartSlowMotion()
   {
      Time.timeScale = TimeScale;
      Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;
   }

   public void StopSlowMotion()
   {
      Time.timeScale = StartTimeScale;
      Time.fixedDeltaTime = StartFixedDeltaTime;
   }
}
