using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HPBar enemyHPBar;
    public int minDamage;
    public int maxDamage;
    public MeshRenderer enemyColor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameOver());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerSword")
        {
            enemyHPBar.Damage(Random.Range(minDamage, maxDamage));
        }
    }
    IEnumerator GameOver()
    {
        yield return null;
        yield return new WaitUntil(() => enemyHPBar.currentHp <= 0);
        while (enemyColor.material.color.a > 0)
        {
            enemyColor.material.color -= new Color32(0, 0, 0, 1);
            yield return null;
        }
        Destroy(this.gameObject);
    }
        
}
