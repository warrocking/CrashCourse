using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] Button btn_GameStart;
    [SerializeField] Button btn_SoundPannelExit;
    [SerializeField] Button btn_SoundPannelOn;
    [SerializeField] GameObject pannel_Setting;
    private void Awake()
    {
        pannel_Setting.SetActive(false);
    }
    private void Start()
    {
        btn_GameStart.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySE("click");
            SceneManager.LoadSceneAsync(1);
        });
        btn_SoundPannelOn.onClick.AddListener(() => {
            AudioManager.instance.PlaySE("click");
            PannelOnOff_Setting(true);
        });
        btn_SoundPannelExit.onClick.AddListener(() => {
            AudioManager.instance.SaveSoundSettings();
            AudioManager.instance.PlaySE("click");
            PannelOnOff_Setting(false);
        });

    }

    void PannelOnOff_Setting(bool a)
    {
        pannel_Setting.SetActive(a);
    }
}
