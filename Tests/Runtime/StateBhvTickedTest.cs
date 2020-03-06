using UnityEngine;

namespace GX.StateMachineSystem
{
    [System.Serializable]
    public class StateBhvTickedTest : StateBehaviourTicked
    {
        public string test;

        public GenericYieldInstructionGetter yield;
        protected override object YieldInstruction { get => yield.GetYieldInstruction(); }

        protected override void OnState(SMClient client)
        {
            Debug.Log("Tick: " + test);
        }
    }
}