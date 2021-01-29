using UnityEngine;
using System.Collections;

public class TimeScaleIndependentUpdate : MonoBehaviour {

    public IPauseHandler PauseHandler;
	public bool pausedWhenGameIsPaused = true;

	//float previousTimeSinceStartup;
    //
	//protected virtual void Awake()
	//{
    //    previousTimeSinceStartup = Time.realtimeSinceStartup;
    //}
    //
    //private void OnEnable()
    //{
	//	previousTimeSinceStartup = Time.realtimeSinceStartup;
    //}

    //protected virtual void Update () 
	//{
    //    deltaTime = Time.unscaledDeltaTime;
	//	//float realTimeSinceStartup = Time.realtimeSinceStartup;
	//	//deltaTime = realTimeSinceStartup - previousTimeSinceStartup;
	//	//previousTimeSinceStartup = realTimeSinceStartup;
    //
    //    deltaTime *= scale;
    //    
    //    if (deltaTime < 0)
	//	{
	//		deltaTime = 0;
	//	}
    //    
	//	if(pausedWhenGameIsPaused && IsGamePaused())
	//	{
	//		deltaTime = 0;
	//	}
    //
    //    if (scale != prevScale)
    //    {
    //        OnScaleChanged(scale);
    //        prevScale = scale;
    //    }
	//}

	public IEnumerator TimeScaleIndependentWaitForSeconds(float seconds)
	{
		float elapsedTime = 0;
		while(elapsedTime < seconds)
		{
			yield return null;
			elapsedTime += deltaTime;
		}
	}

	private bool IsGamePaused()
	{
		if(PauseHandler != null)
		{
		    return PauseHandler.IsGamePaused() || Time.timeScale == 0;
		}
    
		return false;
	}

	public IEnumerator WaitForRealSeconds(float time)
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}

    protected virtual void OnScaleChanged(float scale)
    {

    }

    private float _scale;
    public float scale
    {
        get { return _scale; }
        set
        {
            if (_scale != value)
            {
                OnScaleChanged(value);
                _scale = value;
            }
        }
    }

    public float deltaTime
    {
        get
        {
            if (pausedWhenGameIsPaused && IsGamePaused())
            {
                return 0;
            }
            return Time.unscaledDeltaTime * scale;
        }
    }
}
