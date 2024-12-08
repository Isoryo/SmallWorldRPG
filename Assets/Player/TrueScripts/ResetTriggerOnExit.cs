using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTriggerOnExit : StateMachineBehaviour
{
    public string[] triggerName;
    // Start is called before the first frame update
    public override void OnStateExit(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach(string name in triggerName)
        {
            anim.ResetTrigger(name);
        }
    }
}
