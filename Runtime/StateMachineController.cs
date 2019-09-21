using UnityEngine;
using GX.VarSystem;

namespace GX.StateMachineSystem
{
    public class StateMachineController : MonoBehaviour
    {
        public StateMachine stateMachine;

        public SMClient Client { get; private set; }

        private void Awake()
        {
            Client = stateMachine.CreateClient(this);
        }

        private void OnEnable()
        {
            Client.StartSM();
        }

        private void OnDisable()
        {
            Client.StopSM();
        }

        private void OnDestroy()
        {
            Client.StopSM();
        }
    }
}