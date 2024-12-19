using UnityEngine;
using System.Collections;
using Oblius.Assets.AllInOneAdnetworks;

public class ObliusGameManager : MonoBehaviour
{
    public GameObject gameWheelControl;
    public static ObliusGameManager instance;
    public int minCoinsToAddOnReward = 1;
    public int maxCointsToAddOnReward = 10;
    public enum GameState
    {
        menu,
        game,
        gameover,
        shop

    }
    public Timer timer;

    public GameState gameState;
    public bool oneMoreChanceUsed = false;

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void ResetGame(bool resetScore = true, bool resetOneMoreChance = true)
    {

        if (Plane.instance == null)
        {
            PlayerManager.instance.SpawnNewPlane();
            gameWheelControl.SetActive(true);
        }

        ItemDestroyer.instance.ClearAllItems();

        if (resetOneMoreChance)
        {
            oneMoreChanceUsed = false;
        }

        if (resetScore)
        {
            ScoreHandler.instance.reset();
            timer.ResetTimer();
        }
    }

    public IEnumerator GameOverCoroutine(float delay)
    {
        gameState = GameState.gameover;
        gameWheelControl.SetActive(false);
        yield return new WaitForSeconds(delay);
        SoundsManager.instance.PlayGameOverSound();
        AdNetworksManager.instance.HideBanner();

        Leaderboard.instance.reportScore(ScoreHandler.instance.score);
        GUIManager.instance.ShowGameOverGUI();
        InGameGUI.instance.gameObject.SetActive(false);
        AdNetworksManager.instance.ShowInterstitial(() => Debug.Log("Interstitial Closed"));
    }


    public void GameOver(float delay)
    {
        BackgroundMusic.instance.FadeMusic();
        StartCoroutine(GameOverCoroutine(delay));
    }

    public void StartGame()
    {
        BackgroundMusic.instance.PlayMusic();

        BackgroundMusic.instance.FadeMusic(true);

        ResetGame();
        ScoreHandler.instance.incrementNumberOfGames();
        GUIManager.instance.ShowInGameGUI();
        //GUIManager.instance.tutorialGUI.ShowIfNeverAppeared();
        AdNetworksManager.instance.ShowBanner();
        gameState = GameState.game;
        gameWheelControl.SetActive(true);

        ResetGame(true, true);
        SpawnerManager.instance.coinspawner.CallSpawnItem(0);



    }



}
