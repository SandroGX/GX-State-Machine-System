using UnityEngine;
using UnityEditor;
using GX.VarSystem;

namespace GX.StateMachineSystem
{
    //how to show state in inspector
    [CustomEditor(typeof(StateEditor))]
    public class StateEditorInspector : Editor
    {
        //rect of button "Add", to spawn popup window in the right place
        Rect buttonRect;

        public override void OnInspectorGUI()
        {
            StateEditor stateE = (StateEditor)target;
            State state = stateE.state;
            
            GUILayout.BeginVertical();
            state.name = EditorGUILayout.DelayedTextField("Name", state.name); //name field
            stateE.name = state.name + " Editor";

            int toRemove = -1;
            //show behaviours settings (if not hidden)
            for (int i = 0; i < state.behaviours.Count; ++i)
            {
                if (stateE.fold[i] = EditorGUILayout.Foldout(stateE.fold[i], state.behaviours[i].GetType().Name))
                {
                    CreateEditor(state.behaviours[i]).OnInspectorGUI();
                    VarHandleTemplateInspector.ShowVars(state.behaviours[i], stateE.sm.stateMachine.variables);
                    if (GUILayout.Button("Remove"))
                        toRemove = i;
                }
            }

            if(toRemove >= 0)
                stateE.RemoveBehaviour(toRemove);

            GUILayout.FlexibleSpace();
            //show add behaviour popup
            if (GUILayout.Button("Add"))
                PopupWindow.Show(buttonRect, new AddBehaviourPopup(stateE));
            if (Event.current.type == EventType.Repaint)
                buttonRect = GUILayoutUtility.GetLastRect();
            GUILayout.EndVertical();
        }
    }
}