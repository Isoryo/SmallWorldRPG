using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Retire : MonoBehaviour
{
    public Image panelImage;//Panelの色の濃さを変える
    public TextMeshProUGUI gameOverImage;//GameOverの文字の濃さを変える
    public GameObject restartButton;//リスタートする
    HPBar hpBar;//HPBarから持ってくる
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponent<HPBar>();
        panelImage.color = new Color32(0, 0, 0, 0);
        gameOverImage.color = new Color(gameOverImage.color.r, gameOverImage.color.g, gameOverImage.color.b, 0);
        StartCoroutine(GameOver());
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GameOver()
    {
        yield return null;
        yield return new WaitUntil(() => hpBar.currentHp <= 0);
        while (panelImage.color.a < 240f / 255f && gameOverImage.color.a < 1)
        {
            panelImage.color += new Color32(0, 0, 0, 1);
            gameOverImage.color += new Color32(0, 0, 0, 1);
            yield return null;//結構大事！
        }
        yield return new WaitForSeconds(1);
        restartButton.SetActive(true);
    }
}
