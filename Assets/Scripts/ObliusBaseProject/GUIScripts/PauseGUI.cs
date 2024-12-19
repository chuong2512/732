using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGUI : MonoBehaviour
{






	float timeScaleBeforePause;

	public void Update ()
	{

	}

	public void OnCloseButtonClick ()
	{
		Deactivate (timeScaleBeforePause);
	}

	public void Activate ()
	{
		timeScaleBeforePause = Time.timeScale;
		Time.timeScale = 0;
		gameObject.SetActive (true);
	}

	public void Deactivate (float newTimeScale)
	{
		Time.timeScale = newTimeScale;
		gameObject.SetActive (false);
	}

	public void onHomeButtonClick ()
	{
        BackgroundMusic.instance.FadeMusic(false);
		Deactivate (1);
		Application.LoadLevel (Application.loadedLevel);
	}






}
