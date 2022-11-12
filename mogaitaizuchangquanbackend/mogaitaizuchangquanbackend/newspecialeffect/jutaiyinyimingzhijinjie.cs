using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;
using GameData.Domains.SpecialEffect;
using Config;


namespace mogaitaizuchangquanbackend.newspecialeffect
{
    public class jutaiyinyimingzhijinjie : CombatSkillEffectBase
    {
        public jutaiyinyimingzhijinjie()
        {

        }
        public jutaiyinyimingzhijinjie(CombatSkillKey skillKey) : base(skillKey, 4091, -1)
        {
        }
        public override void OnEnable(DataContext context)
        {
            AffectDatas = new Dictionary<AffectedDataKey, sbyte>();
            AffectDatas.Add(new AffectedDataKey(this.CharacterId, 95, base.SkillTemplateId, -1, -1, -1), 3);
            Events.RegisterHandler_CastSkillEnd(new Events.OnCastSkillEnd(OnCastSkillEnd));
        }

        public override void OnDisable(DataContext context)
        {
            Events.UnRegisterHandler_CastSkillEnd(new Events.OnCastSkillEnd(OnCastSkillEnd));
        }
        private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
        {
            bool flag = charId != this.CharacterId || skillId != base.SkillTemplateId;
            if (!flag)
            {
                bool flag2 = power >= 100;
                if (flag2)
                {
                    NeiliAllocation neiliAllocation = CurrEnemyChar.GetNeiliAllocation();

                    CurrEnemyChar.ChangeNeiliAllocation(context, 0, addValue: -(int)(neiliAllocation.Items[0]), false);
                    CurrEnemyChar.ChangeNeiliAllocation(context, 1, addValue: -(int)(neiliAllocation.Items[1]), false);
                    CurrEnemyChar.ChangeNeiliAllocation(context, 2, addValue: -(int)(neiliAllocation.Items[2]), false);
                    CurrEnemyChar.ChangeNeiliAllocation(context, 3, addValue: -(int)(neiliAllocation.Items[3]), false);

                    DomainManager.Combat.AddCombatState(context, CurrEnemyChar, 0, 41, 200, false, true, true, -1);
                    DomainManager.Combat.ChangeDisorderOfQi(context, CurrEnemyChar, (int)(80 * power), true);
                    DomainManager.Combat.ShowSpecialEffectTips(context, this.CharacterId, base.EffectId, 0);
                }
                RemoveSelf(context);
            }
        }
        public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
        {
            bool flag = dataKey.CharId != this.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId;
            bool result;
            if (flag)
            {
                result = dataValue;
            }
            else
            {
                bool flag2 = dataKey.FieldId == 95;
                result = !flag2 && dataValue;
            }
            return result;
        }

    }
}
