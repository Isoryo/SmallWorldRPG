using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] int maxHp = 20000;//最大HP
    float currentHp;//現在のHP
    public Slider slider;//Sliderを入れる(前)
    public Slider sliderlate;//Sliderを入れる(後)
    public TextMeshProUGUI textmeshpro;
    public Image sliderImage;//SliderのFillのなかのImageを入れる
    public Image panelImage;//Panelの色の濃さを変える
    public TextMeshProUGUI gameOverImage;//GameOverの文字の濃さを変える
    public GameObject restartButton;//リスタートする

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1; //Sliderを満タンにする(前)
        sliderlate.value = 1; //Sliderを満タンにする(後)
        sliderImage.color = new Color32(86, 236, 70, 255);
        currentHp = maxHp; //現在のHPを最大HPと同じにする
        panelImage.color = new Color32(0, 0, 0, 0);
        gameOverImage.color = new Color(gameOverImage.color.r,gameOverImage.color.g,gameOverImage.color.b,0);
        StartCoroutine(GameOver());
        restartButton.SetActive(false);
    }

    public void Damage(float receivedDamage)
    {
        currentHp -= receivedDamage;//今のHPからDamage分を引く
        if (currentHp <= 0)
        {
            currentHp = 0;
        }
        slider.value = currentHp / maxHp;
    }
    // Update is called once per frame
    void Update()
    {
        textmeshpro.text = currentHp + " / " + maxHp;
        if (slider.value - sliderlate.value < 0)
        {
            sliderlate.value -= 0.001f;
        }
        if (slider.value < 0.3f)
        {
            sliderImage.color = new Color32(255, 35, 23, 255);
        }
        else
        {
            sliderImage.color = new Color32(86, 236, 70, 255);
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitUntil(() => currentHp <= 0);
        while(panelImage.color.a < 240f / 255f && gameOverImage.color.a < 1)
        {
            panelImage.color += new Color32(0, 0, 0, 1);
            gameOverImage.color += new Color32(0, 0, 0, 1);
            yield return null;//結構大事！
        }
        yield return new WaitForSeconds(1);
        restartButton.SetActive(true);
    }
}
