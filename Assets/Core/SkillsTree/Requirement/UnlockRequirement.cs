using Core.DummyScripts;
using UnityEngine;

namespace Core.SkillsTree.Requirement
{
    public abstract class UnlockRequirement : ScriptableObject
    {
        public abstract bool IsMet(UnitData unitData);
        public abstract string GetDescription();
    }
}