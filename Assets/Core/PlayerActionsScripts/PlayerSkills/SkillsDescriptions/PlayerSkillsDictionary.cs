using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions
{
    [CreateAssetMenu(menuName = "Create PlayerSkillsDictionary", fileName = "PlayerSkillsDictionary", order = 0)]
    public class PlayerSkillsDictionary : ScriptableObject
    {
        public List<PlayerScriptTypeHolder> SkillDescriptions;
    }
}