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

namespace mogaitaizuchangquanbackend.newspecialeffect
{
    public class jutaiyinyimingzhi:CombatSkillEffectBase
    {
        public jutaiyinyimingzhi()
        {

        }
        public jutaiyinyimingzhi(CombatSkillKey skillKey): base(skillKey, 4090, -1)
        {
        }
        public override void OnEnable(DataContext context)
        {
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
                   
                    CurrEnemyChar.ChangeNeiliAllocation(context, 0, addValue: -(int)(neiliAllocation.Items[0]) , false);
                    CurrEnemyChar.ChangeNeiliAllocation(context, 1, addValue: -(int)(neiliAllocation.Items[1]), false);
                    CurrEnemyChar.ChangeNeiliAllocation(context, 2, addValue: -(int)(neiliAllocation.Items[2]), false);
                    CurrEnemyChar.ChangeNeiliAllocation(context, 3, addValue: -(int)(neiliAllocation.Items[3]), false);
                    DomainManager.Combat.AddCombatState(context, CurrEnemyChar, 0, 41, 200, false, true, true, -1);
                    DomainManager.Combat.ShowSpecialEffectTips(context, this.CharacterId, base.EffectId, 0);
                }
                RemoveSelf(context);
            }
        }
    }
}
