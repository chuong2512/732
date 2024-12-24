using UnityEngine;
using System.Collections;



public class Leaderboard : MonoBehaviour
{

	public static Leaderboard instance;

	public string googlePlayLeaderboardID;
	public string gameCenterLeaderboardID;

	string leaderboardIdToUse;
	protected bool isLogged;

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		instance = this;

		initialize ();
		signIn ();
	}

	// Use this for initialization
	void Start ()
	{
     
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void signIn ()
	{
		// authenticate user:
		Social.localUser.Authenticate ((bool success) => {
			if (success) {
				isLogged = true;
			} else {
				isLogged = false;
			}
		});
	}

	public void reportScore (long score)
	{
		/*try {
			Social.ReportScore (score, leaderboardIdToUse, (bool success) => {

			});
		} catch {

		}*/
	}

	public void showLeaderboard ()
	{

#if UNITY_IOS
#endif
	}

	void initialize ()
	{
#if UNITY_IOS
 leaderboardIdToUse = gameCenterLeaderboardID ;
#endif
	}

}

