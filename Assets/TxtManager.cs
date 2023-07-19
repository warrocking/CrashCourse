using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TxtManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_shootSpeed;
    [SerializeField] TextMeshProUGUI txt_shootPower;
    [SerializeField] TextMeshProUGUI txt_PlayerSpeed;

    public Player player;
    public Weapon weapon;
    public Upgrade upgrade;
    private void Update()
    {
        //txt_shootPower.SetText("damage : "+weapon.damage.ToString());
        //txt_shootSpeed.SetText("shootspeed : "+weapon.moveSpeed.ToString());
        //txt_PlayerSpeed.SetText("movespeed : "+player.moveSpeed.ToString());


        txt_shootPower.SetText("damage : " + upgrade.baseBulletPower.ToString());
        txt_shootSpeed.SetText("shootspeed : " + upgrade.baseBulletSpeed.ToString());
        txt_PlayerSpeed.SetText("movespeed : " + upgrade.basePlayerSpeed.ToString());
    }
}
