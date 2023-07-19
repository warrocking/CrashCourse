using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance=null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    [SerializeField] TextMeshProUGUI txt_Coin;
    [SerializeField] TextMeshProUGUI txt_Hp;
    [SerializeField] GameObject gameOverPannel;
    [SerializeField] Button gameOverButton;
    [SerializeField] GameObject soundPannel;
    [SerializeField] Button soundSaveBtn;
    [SerializeField] int upgradePoint;
    [SerializeField] GameObject upgradePannel;
    //[SerializeField] Button onSettingBtn;
    public EnemySpawner enemySpawner;
    public bool isGameOver;
    public bool isGameClear;
    public bool isPause;

    public Upgrade upgrade;

    public Player player;

    int coin = 0;
    
    //------------------------------------------------------------------------------------------------

    private void Start()
    {
       
        upgrade.ResetUpgrade();


        gameOverPannel.SetActive(false);
        soundPannel.SetActive(false);
        upgradePannel.SetActive(false);
        gameOverButton.onClick.AddListener(() => PlayAgain());
        soundSaveBtn.onClick.AddListener(() => AudioManager.instance.SaveSoundSettings());
        //onSettingBtn.onClick.AddListener(() => OnclickSettingBtn());
    }
    private void Update()
    {
        IsPause();
        txt_Coin.SetText(coin.ToString());
        txt_Hp.SetText(player.hp.ToString());
    }
    public void IncreaseCoin()
    {
        coin += 1;
        
        if (coin % upgradePoint == 0)
        {
            isPause = true;
            upgradePannel.SetActive(true);
            //Player player = FindObjectOfType<Player>();
            //if(player!=null)
            //{
            //    player.Upgrade();
            //}
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if(spawner != null)
        {
            spawner.StopEnemyRoutine();
        }
        Invoke("ShowGameOverPannel", 1.5f);
    }
    public void SetGameClear()
    {
        isGameClear = true;
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.StopEnemyRoutine();
        }
        Invoke("ShowGameOverPannel", 1.5f);
    }
    void ShowGameOverPannel()
    {
        gameOverPannel.SetActive(true);
    }

    void PlayAgain()
    {
        if(isGameClear==true)
        {
            enemySpawner.routineNum += 1;
            isGameClear = false;
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    void OnclickSettingBtn()
    {

    }
    void IsPause()
    {
        if (isPause == true)
        {
            Time.timeScale = 0;
        }
        if (isPause == false)
        {
            Time.timeScale = 1;
        }
    }
}