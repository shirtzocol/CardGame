using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OppHp : MonoBehaviour
{
    public static float maxHp;
    public static float staticOpHp;
    public float hp;
    public Image Health;
    public Text hpText;    

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 250000;
        staticOpHp = 50000;
    }

    // Update is called once per frame
    void Update()
    {
        hp = staticOpHp;
        Health.fillAmount = hp / maxHp;
        if(hp >= maxHp)
        {
            hp = maxHp;
        }   
        hpText.text = hp + " HP";
    }
}
