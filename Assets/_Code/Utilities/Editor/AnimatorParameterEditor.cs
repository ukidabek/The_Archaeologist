using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Utilities.General
{
    [CustomEditor(typeof(AnimatorParameterDefinition))]
    public class AnimatorParameterEditor : Editor
    {
        private FieldInfo _animatorFieldInfo = null;
        private FieldInfo _nameFieldInfo = null;
        private FieldInfo _hashFieldInfo = null;

        private int _selectedParameterIndex = -1;
        
        private void OnEnable()
        {
            var type = target.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            _animatorFieldInfo = type.GetField("_animator", bindingFlags);
            _nameFieldInfo = type.GetField("_name", bindingFlags);
            _hashFieldInfo = type.GetField("_hash", bindingFlags);
        }

        public override void OnInspectorGUI()
        {
            var animator = _animatorFieldInfo.GetValue(target) as AnimatorController;

            animator = EditorGUILayout.ObjectField("AnimatorController:", 
                animator, typeof(AnimatorController), 
                false) as AnimatorController;
            
            _animatorFieldInfo.SetValue(target, animator);
            if (animator != null)
            {
                var name = _nameFieldInfo.GetValue(target) as string;
                var parametersNames = animator.parameters
                    .Select(parameter => parameter.name)
                    .ToList();

                _selectedParameterIndex = parametersNames.IndexOf(name);
                if (_selectedParameterIndex < 0)
                    _selectedParameterIndex = 0;
                
                _selectedParameterIndex = EditorGUILayout.Popup(_selectedParameterIndex, parametersNames.ToArray());

                var selectedName = parametersNames[_selectedParameterIndex];
                var generatedHash = Animator.StringToHash(selectedName);
                _nameFieldInfo.SetValue(target, selectedName);
                _hashFieldInfo.SetValue(target, generatedHash);
                
                GUILayout.Label($"Name:     {selectedName}");
                GUILayout.Label($"Hash:     {generatedHash}");
            }
            else
            {
                var name = _nameFieldInfo.GetValue(target) as string;
                name = EditorGUILayout.TextField("Name:", name);
                var generatedHash = Animator.StringToHash(name);
                
                _nameFieldInfo.SetValue(target, name);
                _hashFieldInfo.SetValue(target, generatedHash);
                GUILayout.Label($"Hash:     {generatedHash}");
            }
        }
    }
}