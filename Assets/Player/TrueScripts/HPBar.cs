using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] int maxHp = 20000;//最大HP
    public float currentHp;//現在のHP
    public Slider slider;//Sliderを入れる(前)
    public Slider sliderlate;//Sliderを入れる(後)
    public TextMeshProUGUI textmeshpro;
    public Image sliderImage;//SliderのFillのなかのImageを入れる

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1; //Sliderを満タンにする(前)
        sliderlate.value = 1; //Sliderを満タンにする(後)
        sliderImage.color = new Color32(86, 236, 70, 255);
        currentHp = maxHp; //現在のHPを最大HPと同じにする
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
}
