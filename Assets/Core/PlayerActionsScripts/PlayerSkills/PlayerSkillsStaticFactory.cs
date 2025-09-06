using Core.PlayerActionsScripts.PlayerSkills.SkillsDescriptions;

namespace Core.PlayerActionsScripts.PlayerSkills
{
    public static class PlayerSkillsStaticFactory
    {
        public static PlayerSkillsDictionary PlayerSkillsDictionary;
        
        public static IPlayerSkill CreatePlayerSkills(PlayerSkillCurrentData playerSkillCurrentData)
        {
            var skillsList =
                PlayerSkillsDictionary.SkillDescriptions.Find(x =>
                    x.PlayerSkillsType == playerSkillCurrentData.SkillsType);
            var skillToCreate = skillsList.PlayerSkillDescriptions.Find(x =>
                x.SkillLevel == playerSkillCurrentData.SkillCurrentLevel);
            switch (skillsList.PlayerSkillsType)
            {
                case PlayerSkillsType.Heal:
                    return CreateUnitHealPlayerSkill(skillToCreate);
            }
            return null;
        }

        private static IPlayerSkill CreateUnitHealPlayerSkill(PlayerSkillDescription skillToCreate)
        {
            HealUnitPlayerSkill healUnitPlayerSkill = new HealUnitPlayerSkill();
            healUnitPlayerSkill.SetSkillDescription(skillToCreate);
            return healUnitPlayerSkill;
        }
    }
}