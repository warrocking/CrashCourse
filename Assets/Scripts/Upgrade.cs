using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] Button btn_BulletSpeed;
    [SerializeField] Button btn_BulletPower;
    [SerializeField] Button btn_PlayerSpeed;
    [SerializeField] Button btn_PlayerHp;

    public Weapon bullet;
    public Player player;

    public float baseBulletSpeed; // 초기 무기 이동 속도
    public float baseBulletPower; // 초기 무기 데미지
    public float basePlayerSpeed; // 초기 플레이어 이동 속도
    public int basePlayerHp; // 초기 플레이어 체력

    private void Start()
    {
        
        if (bullet == null)
        {
            Debug.LogError("bullet 컴포넌트를 찾을 수 없습니다.");
            return;
        }
        
        Player player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player 컴포넌트를 찾을 수 없습니다.");
            return;
        }
        //---------------------------------------------------------------------------------
        baseBulletSpeed = bullet.moveSpeed;
        baseBulletPower = bullet.damage;
        basePlayerSpeed = player.moveSpeed;
        basePlayerHp = player.hp;
        //---------------------------------------------------------------------------------
        btn_BulletSpeed.onClick.AddListener(IncreaseBulletSpeed);
        btn_BulletPower.onClick.AddListener(IncreaseBulletPower);
        btn_PlayerSpeed.onClick.AddListener(IncreasePlayerSpeed);
        btn_PlayerHp.onClick.AddListener(IncreasePlayerHp);
    }

    private void IncreaseBulletSpeed()
    {
        AudioManager.instance.PlaySE("click");
        bullet.moveSpeed += 1f; // 무기의 이동 속도를 1 증가시킴
        gameObject.SetActive(false); // 업그레이드 패널 비활성화
        GameManager.instance.isPause = false; // 게임 일시 정지 해제
    }

    private void IncreaseBulletPower()
    {
        AudioManager.instance.PlaySE("click");
        bullet.damage += 1f; // 무기의 데미지를 1 증가시킴
        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
    }

    private void IncreasePlayerSpeed()
    {
        AudioManager.instance.PlaySE("click");
        player.moveSpeed += 0.5f; // 플레이어의 이동 속도를 0.5 증가시킴
        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
    }

    private void IncreasePlayerHp()
    {
        AudioManager.instance.PlaySE("click");
        player.hp += 1; // 플레이어의 체력을 1 증가시킴
        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
    }

    public void ResetUpgrade()
    {
        // 초기 수치로 복원
        bullet.moveSpeed = baseBulletSpeed;
        bullet.damage = baseBulletPower;
        player.moveSpeed = basePlayerSpeed;
        player.hp = basePlayerHp;
    }
}
