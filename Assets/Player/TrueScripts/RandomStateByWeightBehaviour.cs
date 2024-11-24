using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomStateByWeightBehaviour : StateMachineBehaviour
{
    [SerializeField] string parameterName = "random";
    [SerializeField, Header("乱数の重み")]
    [Tooltip(@"各要素番号の出現重みを入力する。
例）[3,1,6]
0の出現確率3/10
1の出現確率1/10
2の出現確率6/10
")]
    int[] weights;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger(parameterName, GetRandomIndexByWeight(weights));
    }

    /// <summary>
    /// 重み付き乱数生成メソッド
    /// </summary>
    /// <param name="weights"> 重み配列 </param>
    /// <returns> 取得結果 </returns>
    private int GetRandomIndexByWeight(int[] weights)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int randomValue = Random.Range(0, weights.Sum());

        int currentWeightSum = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            currentWeightSum += weights[i];
            if (randomValue < currentWeightSum) return i;
        }
        return -1;
    }
}


