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
                    x.PlayerSkillsType == playerSkillCurrentData.SkillsTypes);
            var skillToCreate = skillsList.PlayerSkillDescriptions.Find(x =>
                x.SkillLevel == playerSkillCurrentData.SkillCurrentLevel);
            switch (skillsList.PlayerSkillsType)
            {
                case PlayerSkillsTypes.Heal:
                    return CreateUnitHealPlayerSkill(skillToCreate);
                case PlayerSkillsTypes.Hit:
                    return CreateUnitHitPlayerSkill(skillToCreate);
            }
            return null;
        }

        private static IPlayerSkill CreateUnitHealPlayerSkill(PlayerSkillDescription skillToCreate)
        {
            HealUnitPlayerSkill healUnitPlayerSkill = new HealUnitPlayerSkill();
            healUnitPlayerSkill.SetSkillDescription(skillToCreate);
            return healUnitPlayerSkill;
        }

        private static IPlayerSkill CreateUnitHitPlayerSkill(PlayerSkillDescription skillToCreate)
        {
            HitUnitPlayerSkill hitUnitPlayerSkill = new HitUnitPlayerSkill();
            hitUnitPlayerSkill.SetSkillDescription(skillToCreate);
            return hitUnitPlayerSkill;
        }
    }
}