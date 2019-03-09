﻿using UnityEngine;
using UnityEditor;

namespace Game.StateMachineSystem
{
    //a condition of a transition
    public abstract class TransitionCondition : ScriptableObject
    {
        //is condition met
        public abstract bool ConditionMet(ISMClient client);

        //start evaluating?


        //stop evaluating?

    }
}