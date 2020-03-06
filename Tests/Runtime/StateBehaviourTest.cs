using UnityEngine;
using GX.VarSystem;

namespace GX.StateMachineSystem
{
    [System.Serializable]
    public class StateBehaviourTest : StateBehaviour
    {
        public string test;

        [HideInInspector] public VarAccesser<Animator> testVariable = new VarAccesser<Animator>();
        [HideInInspector] public VarAccesser<string> testVariable2 = new VarAccesser<string>();
        [HideInInspector] public VarAccesser<Rigidbody> testVariable3 = new VarAccesser<Rigidbody>();
        [HideInInspector] [VarIdx(typeof(Animator))] public int testVariable4 = 0;

        public override void OnStateEnter(SMClient c)
        {
            Debug.Log($"Hi, entered. {test} {testVariable[c].deltaPosition} {testVariable3[c].velocity} {c.Variables.Get<Animator>(testVariable4).gameObject}");
        } 

        public override void OnStateExit(SMClient client)
        {
            Debug.Log("Bye, left. " + test);
        }
    }
}