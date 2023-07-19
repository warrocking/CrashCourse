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

    public float baseBulletSpeed; // �ʱ� ���� �̵� �ӵ�
    public float baseBulletPower; // �ʱ� ���� ������
    public float basePlayerSpeed; // �ʱ� �÷��̾� �̵� �ӵ�
    public int basePlayerHp; // �ʱ� �÷��̾� ü��

    private void Start()
    {
        
        if (bullet == null)
        {
            Debug.LogError("bullet ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }
        
        Player player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player ������Ʈ�� ã�� �� �����ϴ�.");
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
        bullet.moveSpeed += 1f; // ������ �̵� �ӵ��� 1 ������Ŵ
        gameObject.SetActive(false); // ���׷��̵� �г� ��Ȱ��ȭ
        GameManager.instance.isPause = false; // ���� �Ͻ� ���� ����
    }

    private void IncreaseBulletPower()
    {
        AudioManager.instance.PlaySE("click");
        bullet.damage += 1f; // ������ �������� 1 ������Ŵ
        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
    }

    private void IncreasePlayerSpeed()
    {
        AudioManager.instance.PlaySE("click");
        player.moveSpeed += 0.5f; // �÷��̾��� �̵� �ӵ��� 0.5 ������Ŵ
        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
    }

    private void IncreasePlayerHp()
    {
        AudioManager.instance.PlaySE("click");
        player.hp += 1; // �÷��̾��� ü���� 1 ������Ŵ
        gameObject.SetActive(false);
        GameManager.instance.isPause = false;
    }

    public void ResetUpgrade()
    {
        // �ʱ� ��ġ�� ����
        bullet.moveSpeed = baseBulletSpeed;
        bullet.damage = baseBulletPower;
        player.moveSpeed = basePlayerSpeed;
        player.hp = basePlayerHp;
    }
}
