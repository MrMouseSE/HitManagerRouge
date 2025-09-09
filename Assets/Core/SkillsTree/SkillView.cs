using UnityEngine;

namespace Core.SkillsTree
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private SkillData _skillData;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private SkillView _nextSkill;
        
        private SkillState _currentState;
        

        public void OnUnlock()
        {
          
        }

        public void UpdateVisuals()
        {
            
        }

        private void DrawConnectionLines()
        {
            
        }
    }
}