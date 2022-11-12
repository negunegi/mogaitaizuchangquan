using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect;
using GameData.Domains.Taiwu;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;
using System.Diagnostics;
using mogaitaizuchangquanbackend.newspecialeffect;






namespace mogaitaizuchangquanbackend

{
	[PluginConfig("mogaitaizuchangquanbackendPlugin", "Negu", "1.0")]
	public class mogaitaizuchangquanbackendPlugin : TaiwuRemakeHarmonyPlugin
	{
		public List<SpecialEffectItem> specialEffectslist;
		public static string directeffectname;
		public static string reverseeffectname;
		public static string directeffectreverse;
		public static string reverseeffectdirect;
		public static string name;
		public override void Dispose()
		{
			HarmonyInstance.UnpatchAll(null);
		}

		public override void Initialize()
		{
			HarmonyInstance.PatchAll(typeof(mogaitaizuchangquanbackendPlugin));
			specialEffectslist = SpecialEffect.Instance.GetFieldValue<List<SpecialEffectItem>>("_dataArray");
			if (SpecialEffect.Instance.Count <= 1800)
            {


			for (int j = specialEffectslist.Count; j < 1800; j++)
			{
				SpecialEffectItemWrapper padding2 = new SpecialEffectItemWrapper((short)j);
				specialEffectslist.Add(padding2.instance);
			}
/*                ReadGongFaEffectName(directeffectreverse, reverseeffectdirect);*/
                Addjutaiyinyimingzhi();
				Addjutaiyinyimingzhijinjie();

			}
			Debug.Log(string.Format("initial {0}", SpecialEffect.Instance.Count));
		}

		public override void OnModSettingUpdate()
		{
			DomainManager.Mod.GetSetting(ModIdStr, "DirectEffectName", ref directeffectname);
			DomainManager.Mod.GetSetting(ModIdStr, "ReverseEffectName", ref reverseeffectname);
			DomainManager.Mod.GetSetting(ModIdStr, "DirectEffectReverse", ref directeffectreverse);
			DomainManager.Mod.GetSetting(ModIdStr, "DirectEffectReverse", ref reverseeffectdirect);
			DomainManager.Mod.GetSetting(ModIdStr, "Name", ref name);
/*			ReadGongFaEffectName(directeffectname, reverseeffectname);
			Addjutaiyinyimingzhi();*/
			Debug.Log(string.Format("DomainManager {0}", SpecialEffect.Instance.Count));
		}

        private  void Addjutaiyinyimingzhi()
        {

            SpecialEffectItemWrapper specialEffectItemWrapper = new SpecialEffectItemWrapper(1800);
            specialEffectItemWrapper.SetName(name);
            specialEffectItemWrapper.SetDesc("此功法发挥十成威力时,使地方真气清零，并施加真气增加量减益的状态");
            specialEffectItemWrapper.SetShortDesc("真气清零");
            specialEffectItemWrapper.SetClassName("jutaiyinyimingzhi");
			specialEffectslist.Add(specialEffectItemWrapper.instance);
        }

		private void Addjutaiyinyimingzhijinjie()
		{

			SpecialEffectItemWrapper specialEffectItemWrapper = new SpecialEffectItemWrapper(1801);
			specialEffectItemWrapper.SetName(name);
			specialEffectItemWrapper.SetDesc("此功法无法反震，此功法发挥十成威力时,使敌方真气清零，内息断绝，并施加真气增加量减益的状态");
			specialEffectItemWrapper.SetShortDesc("真气清零、内息断绝");
			specialEffectItemWrapper.SetClassName("jutaiyinyimingzhijinjie");
			specialEffectslist.Add(specialEffectItemWrapper.instance);
		}

		/*
				public  (int, int) ReadGongFaEffectName(string directeffectname, string reverseeffectname)
				{
					int directid = -1;
					int reverseid = -1;
					foreach (var x in Config.CombatSkill.Instance)
					{
						var gongfaname = x.Name;
						if (directeffectname == gongfaname)
						{

							directid = x.DirectEffectID;
							SpecialEffectItem template = SpecialEffect.Instance.GetItem((short)directid);
							*//*SpecialEffectItem template = ReflectionExtensions.DeepCopy(specialEffectslist[directid]);*//*
							SpecialEffectItemWrapper specialEffectItemWrapper_direct = new SpecialEffectItemWrapper(1800, template);
							specialEffectItemWrapper_direct.SetName(name);
							specialEffectslist.Add(specialEffectItemWrapper_direct.instance);
							directid = 1800;
						}
						*//*                else if(directeffectname == gongfaname && directeffectreverse)
										{
											directid = x.ReverseEffectID;
											SpecialEffectItem template = SpecialEffect.Instance.GetItem((short)directid);
											SpecialEffectItemWrapper specialEffectItemWrapper_direct = new SpecialEffectItemWrapper(1800, template);
											specialEffectItemWrapper_direct.SetPrivateField("")
											specialEffectslist.Add(specialEffectItemWrapper_direct.instance);

										}*//*

					}
					foreach (var x in Config.CombatSkill.Instance)
					{
						var gongfaname = x.Name;
						if (reverseeffectname == gongfaname)
						{
							reverseid = x.ReverseEffectID;

							SpecialEffectItem template = SpecialEffect.Instance.GetItem((short)reverseid);
							SpecialEffectItemWrapper specialEffectItemWrapper_reverse = new SpecialEffectItemWrapper(1801, template);
							specialEffectItemWrapper_reverse.SetName(name);
							specialEffectslist.Add(specialEffectItemWrapper_reverse.instance);
							reverseid = 1801;
						}*/
		/*                else if(reverseeffectname == gongfaname)
						{
							reverseid = x.DirectEffectID;
						}
		*/
		/*			}
					if (directid == -1)
					{
						directid = 1800;
					}
					if (reverseid == -1)
					{
						reverseid = 1800;
					}
					return (directid, reverseid);
				}
		*/
		// Token: 0x06000007 RID: 7 RVA: 0x00002565 File Offset: 0x00000765
		[HarmonyPrefix]
		[HarmonyPatch(typeof(SpecialEffectType), "CreateEffectObj")]
			public static bool CreateEffectObj_Patch(int type, ref SpecialEffectBase __result)
			{
				if (type == 4090)
				{
					__result = new jutaiyinyimingzhi();
					return false;
				}
				return true;
			}



		[HarmonyPrefix]
		[HarmonyPatch(typeof(SpecialEffectDomain), "Add", new Type[]
	{
			typeof(DataContext),
			typeof(int),
			typeof(short),
			typeof(sbyte),
			typeof(sbyte)
	})]
		public static bool SpecialEffectDomainAdd_Patch(DataContext context, int charId, short skillTemplateId, sbyte effectActiveType, sbyte direction, SpecialEffectDomain __instance)
		{

			if (skillTemplateId == 723)
			{
				CombatSkillItem combatSkillItem = Config.CombatSkill.Instance[skillTemplateId];
				Debug.Log(string.Format("SUCCESSFUL PATCH SPECIALEFFECTDOMAIN_PATCH,{0}{1}", skillTemplateId, charId));
				CombatSkillKey combatSkillKey = new CombatSkillKey(charId, skillTemplateId);
				GameData.Domains.CombatSkill.CombatSkill element_CombatSkills = DomainManager.CombatSkill.GetElement_CombatSkills(combatSkillKey);
				if (direction < 0)
				{
					direction = element_CombatSkills.GetDirection();
				}
				int num;
				if (direction != 0)
				{
					if (direction == 1)
					{
						num = combatSkillItem.ReverseEffectID;
					}
					else
					{
						num = -1;
					}
				}
				else
				{
					num = combatSkillItem.DirectEffectID;
				}
				short num2 = (short)num;
				if (num2 < 0)
				{
					return false;
				}
				else if(num2 < 1800)
                {

					return true;
                }
				SpecialEffectItem specialEffectItem = SpecialEffect.Instance[num2];
				if (specialEffectItem.EffectActiveType == effectActiveType && !string.IsNullOrEmpty(specialEffectItem.ClassName))
				{
					string text = "mogaitaizuchangquanbackend.newspecialeffect." + specialEffectItem.ClassName;
					Type type = Type.GetType(text);
					if (type == null)
					{
						throw new Exception("Cannot find type '" + text + "'.");
					}
					SpecialEffectBase specialEffectBase = ((effectActiveType == 3) ? ((SpecialEffectBase)Activator.CreateInstance(type, new object[] { combatSkillKey, direction })) : ((SpecialEffectBase)Activator.CreateInstance(type, new object[] { combatSkillKey })));
					__instance.Add(context, specialEffectBase);
					if (effectActiveType == 3 || effectActiveType == 2 || effectActiveType == 1)
					{
						element_CombatSkills.SetSpecialEffectId(specialEffectBase.Id, context);
					}
				}
				return false;
			}
			return true;
		}
		[HarmonyPrefix]
		[HarmonyPatch(typeof(TaiwuDomain), "CallMethod")]
		public static bool CallMethodTaiwu_Patch(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
		{
			if (operation.MethodId == 54)
			{
				int num = operation.ArgsOffset;
				short num2 = 0;
				num += Serializer.Deserialize(argDataPool, num, ref num2);
				ushort num3 = 0;
				Serializer.Deserialize(argDataPool, num, ref num3);
				Debug.Log(string.Format("CallMethodTaiwu_Patch {0} {1}", num2, num3));
			}
			return true;
		}
	}
}
