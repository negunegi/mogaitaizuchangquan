using System.Collections.Generic;
using TaiwuModdingLib.Core.Plugin;
using HarmonyLib;
using Config;
using Config.ConfigCells.Character;
using System;
using GameData.Domains.Item;
namespace taizuchangquanmogai
{
    [PluginConfig(pluginName: "mogaitaizuchangquan", creatorId: "Negu", pluginVersion: "1.0.0")]

    public class Run : TaiwuRemakePlugin
    {
        Harmony harmony;


        public static bool Loaded;
        public static int penetrate;
        public static int totalhit;
        public static string name;
        public static string desc;
        public static int level;
        public static int baseinnerratio;
        public static string tricks;
        public static List<NeedTrick> tricklist = new List<NeedTrick>();
        public static int sect;
        public static int fiveelement;
        public static int gtype;
        public static int breathstancetotalcost;
        public static string hits;
        public static sbyte[] hitslist = new sbyte[4];
        public static string injurypart;
        public static sbyte[] injurypartlist = new sbyte[7];
        public static string gongfaanimationname;
        public static string assetfilename;
        public static string prepareanimation;
        public static string castanimation;
        public static string castparticle;
        public static short[] distancewhenfourstepanimation;
        public static string castsoundeffect;
        public static string directeffectname;
        public static string reverseeffectname;
        public static bool directeffectreverse;
        public static bool reverseeffectdirect;
        public List<SpecialEffectItem> specialEffectslist;
        public static List<PropertyAndValue> requimentslist = new List<PropertyAndValue>();
        public static string requirements;
        public static string poisonnames;
        public static short[] poisionslist = new short[12];
        public static PoisonsAndLevels poisionslistinput = new PoisonsAndLevels(new short[12]);
        public static List<BreakGrid> skillbreaklist = new List<BreakGrid>();
        public static string yellowperknames;
        public static bool whetherusingdiyeffect;
        public static int diyeffect;
        public static int mobilitycost = 0;
        public static int distancebonus =15;
        /*        public static int directid;
                public static int reverseid;*/





        [PluginConfig(pluginName:"mogaitaizuchangquanbackend",creatorId:"negu",pluginVersion:"0.0.0")]

        public override void Dispose()
        {
            if (harmony != null)
            {
                harmony.UnpatchSelf();
                Loaded = false;
                harmony = null;  
            }
        }

        public override void Initialize()
        {
            harmony = Harmony.CreateAndPatchAll(type: typeof(Run), null);
            specialEffectslist = SpecialEffect.Instance.GetFieldValue<List<SpecialEffectItem>>("_dataArray");
            for (int j = specialEffectslist.Count; j < 1800; j++)
            {
                SpecialEffectItemWrapper padding2 = new SpecialEffectItemWrapper((short)j);
                specialEffectslist.Add(padding2.instance);
            }

        }
        public override void OnModSettingUpdate()
        {
            Run.Loaded = false;
            ModManager.GetSetting(ModIdStr, "penetrate", ref penetrate);
            ModManager.GetSetting(ModIdStr, "totalhit", ref totalhit);
            ModManager.GetSetting(ModIdStr, "Name", ref name);
            ModManager.GetSetting(ModIdStr, "Desc", ref desc);
            ModManager.GetSetting(ModIdStr, "Level", ref level);
            ModManager.GetSetting(ModIdStr, "BaseInnerRatio", ref baseinnerratio);
            ModManager.GetSetting(ModIdStr, "Tricks", ref tricks);
            ModManager.GetSetting(ModIdStr, "Sect", ref sect);
            ModManager.GetSetting(ModIdStr, "FiveElement", ref fiveelement);
            ModManager.GetSetting(ModIdStr, "Type", ref gtype);
            gtype += 3;
            ModManager.GetSetting(ModIdStr, "BreathStanceTotalCost", ref breathstancetotalcost);
            ModManager.GetSetting(ModIdStr, "Hits", ref hits);
            ModManager.GetSetting(ModIdStr, "InjuryPartAtkRateDistribution", ref injurypart);
            ModManager.GetSetting(ModIdStr, "GongFaAnimationName", ref gongfaanimationname);
            ModManager.GetSetting(ModIdStr, "DirectEffectName", ref directeffectname);
            ModManager.GetSetting(ModIdStr, "ReverseEffectName", ref reverseeffectname);
            ModManager.GetSetting(ModIdStr, "DirectEffectReverse", ref directeffectreverse);
            ModManager.GetSetting(ModIdStr, "ReverseEffectDirect", ref reverseeffectdirect);
            
            ModManager.GetSetting(ModIdStr, "UsingRequirement", ref requirements);
            /*Debug.Log(string.Format("XNAME {0}  PROPERTY{1}", requirements, reverseeffectdirect));*/
            ModManager.GetSetting(ModIdStr, "Poisons", ref poisonnames);
            ModManager.GetSetting(ModIdStr, "YellowPerk", ref yellowperknames);
            ModManager.GetSetting(ModIdStr, "WhetherUsingDIYEffect", ref whetherusingdiyeffect);
            ModManager.GetSetting(ModIdStr, "DIYEffect", ref diyeffect);
            diyeffect += 1800;
            ModManager.GetSetting(ModIdStr, "MobilityCost", ref mobilitycost);
            ModManager.GetSetting(ModIdStr, "DistanceAdditionWhenCast", ref distancebonus);

            Addjutaiyinyimingzhi();
            Addjutaiyinyimingzhijinjie();
            CombatSkill.Instance.GetAllKeys();

        }
        public static void ReadUsingRequirement(string requirements, List<PropertyAndValue> requimentslist)
        {
            requimentslist.Clear();
            foreach (string re in requirements.Split(new string[] { "," }, StringSplitOptions.None))
            {
                var tst = re.Split(new string[] { "x" }, StringSplitOptions.None);
                short value = (short)int.Parse(tst[1].Trim());
                var property = tst[0].Trim();
                short propertytype = -1;

                try
                {
                    foreach (var x in CharacterPropertyDisplay.Instance)
                    {
 /*                       Debug.Log(string.Format("XNAME {0}  PROPERTY{1}",x.Name, property));*/
                        if (x.Name == property)

                        {
                            propertytype = x.TemplateId;
                            break;
                        }
                    }
                    if (propertytype >= 0) requimentslist.Add(new PropertyAndValue((short)propertytype, (short)value));
                }

                catch (Exception e)
                {
                    throw new Exception("所需的使用需求字符串（" + requirements + "）值有误，请修改字符串格式，错误信息为：\n" + e.Message);
                }
            }
        }

        public static void ReadTricks(string tricks, List<NeedTrick> tricklists)
        {
            tricklists.Clear();
            foreach (string tr in tricks.Split(new string[] { "," }, StringSplitOptions.None))
            {
                var tst = tr.Split(new string[] { "x" }, StringSplitOptions.None);
                sbyte count = (sbyte)int.Parse(tst[1].Trim());
                var id = tst[0].Trim();
                short trickType = -1;

                try
                {
                    foreach (var x in TrickType.Instance)
                    {
                        if (x.Name == id)
                        {
                            trickType = x.TemplateId;
                            break;
                        }
                    }
                    if (trickType >= 0) tricklists.Add(new NeedTrick((sbyte)trickType, (byte)count));
                }

                catch (Exception e)
                {
                    throw new Exception("所需的式（" + tricks + "）值有误，请修改字符串格式，或者将字符串置空，错误信息为：\n" + e.Message);
                }
            }
        }
        
        public static void Readhits(string hits, sbyte[] hitslists)
        {
            int i = 0;
            foreach (string tr in hits.Split(new string[] { "," }, StringSplitOptions.None))
            {
                hitslists[i] = Convert.ToSByte(tr);
                i++;           
                }
            if (hitslists.Length != 4)
            {
                throw new Exception("所需的命中字符串（" + hits + "）值长度有误，若无命中则用0占位");
            }
            else if ((hitslists[0]+ hitslists[1]+ hitslists[2]+ hitslists[3]) != 100)
            {
                throw new Exception("所需命中字符串（" + hits + "）值加和不为100");
            }

        }

        public static void Readinjuryparts(string injuryparts, sbyte[] injurypartlist)
        {
            int i = 0;
            foreach (string tr in injuryparts.Split(new string[] { "," }, StringSplitOptions.None))
            {
                injurypartlist[i] = Convert.ToSByte(tr);
                i++;
            }
            if (injurypartlist.Length != 7)
            {
                throw new Exception("所需的命中字符串（" + injurypartlist + "）值长度有误，若无命中则用0占位");
            }

        }
        public static void ReadPoisons(string Poisonnames, short[] poisionslist)
        {
            int i = 0;
            foreach (string po in Poisonnames.Split(new string[] { "," }, StringSplitOptions.None))
            {
                poisionslist[i] = Convert.ToInt16 (po);
                i++;
            }
            if (poisionslist.Length != 12)
            {
                throw new Exception("所需的毒素字符串（" + Poisonnames + "）值长度有误，若无命中则用0占位,注意毒素严重程度不要超过3");
            }

        }

        public static (string, string, string, string,short[],string) ReadGongFaAnimationName(string gongfaanimationname,string assetfilename,string prepareanimation,string castanimation,string castparticle,short[] distancewhenfourstepanimation,string castsoundeffect)
        {

            foreach (var x in CombatSkill.Instance)
            {
                var gongfaname = x.Name;
                if (gongfaname == gongfaanimationname)
                {
                    assetfilename =  x.AssetFileName;
                    prepareanimation = x.PrepareAnimation;
                    castanimation =  x.CastAnimation;
                    castparticle = x.CastParticle ;
                    distancewhenfourstepanimation = x.DistanceWhenFourStepAnimation;
                    castsoundeffect = x.CastSoundEffect;
                    //throw new Exception("所需的字符串（" + assetfilename + "）" + prepareanimation + "）" + castanimation + "}"+castparticle+distancewhenfourstepanimation+castsoundeffect);
                    return (assetfilename, prepareanimation, castanimation, castparticle, distancewhenfourstepanimation, castsoundeffect);
                }
                
            }

            if (assetfilename == null)
            {
                throw new Exception("所需的字符串（" + gongfaanimationname + "）并未检索到功法名字，请检查功法名字是否错误，如果使用化龙掌动画请输入化龙掌。");
            }
            return (assetfilename, prepareanimation, castanimation, castparticle, distancewhenfourstepanimation, castsoundeffect);
        }
        public static (int,int) ReadGongFaEffectName(string directeffectname, string reverseeffectname)
        {
            int directid = -1;
            int reverseid = -1;
            foreach (var x in CombatSkill.Instance)
            {
                var gongfaname = x.Name;
                if (directeffectname == gongfaname)
                {

                    directid = x.DirectEffectID;
/*                    SpecialEffectItem template = SpecialEffect.Instance.GetItem((short)directid);
                    *//*SpecialEffectItem template = ReflectionExtensions.DeepCopy(specialEffectslist[directid]);*//*
                    SpecialEffectItemWrapper specialEffectItemWrapper_direct = new SpecialEffectItemWrapper(1800, template);
                    specialEffectItemWrapper_direct.SetName(name);
                    specialEffectslist.Add(specialEffectItemWrapper_direct.instance);
                    directid = 1800;*/
                }
/*                else if(directeffectname == gongfaname && directeffectreverse)
                {
                    directid = x.ReverseEffectID;
                    SpecialEffectItem template = SpecialEffect.Instance.GetItem((short)directid);
                    SpecialEffectItemWrapper specialEffectItemWrapper_direct = new SpecialEffectItemWrapper(1800, template);
                    specialEffectItemWrapper_direct.SetPrivateField("")
                    specialEffectslist.Add(specialEffectItemWrapper_direct.instance);

                }*/

            }
            foreach (var x in CombatSkill.Instance)
            {
                var gongfaname = x.Name;
                if (reverseeffectname == gongfaname )
                {
                    reverseid = x.ReverseEffectID;
/*
                    SpecialEffectItem template = SpecialEffect.Instance.GetItem((short)reverseid);
*//*                    SpecialEffectItem template = ReflectionExtensions.DeepCopy(specialEffectslist[reverseid]);*//*
                    SpecialEffectItemWrapper specialEffectItemWrapper_reverse = new SpecialEffectItemWrapper(1801, template);
                    specialEffectItemWrapper_reverse.SetName(name);
                    specialEffectslist.Add(specialEffectItemWrapper_reverse.instance);
                    reverseid = 1801;*/
                }
/*                else if(reverseeffectname == gongfaname)
                {
                    reverseid = x.DirectEffectID;
                }
*/
            }
            if (directid == -1)
            {
                directid = 1801;
            }
            if (reverseid == -1)
            {
                reverseid = 1801;
            }
            return (directid, reverseid);
        }

        public static void ReadAdditionals(string yellowperknames, List<BreakGrid> AdditionalGrids)
        {
           /* Debug.Log(string.Format("XNAME {0}  PROPERTY{1}", yellowperknames, AdditionalGrids));*/

            if (yellowperknames.Length > 0) try
                {
                    foreach (string gc in yellowperknames.Split(new string[] { "," }, StringSplitOptions.None))
                    {
                        var tst = gc.Split(new string[] { "x" }, StringSplitOptions.None);
                        sbyte count = (sbyte)int.Parse(tst[1].Trim());
                        short bonusType = -1;
                        var id = tst[0].Trim();
                        
                        foreach (var x in SkillBreakPlateGridBonusType.Instance)
                        {
                            if (x.Name == id)
                            {
                                bonusType = x.TemplateId;
                                break;
                            }
                        }

                        if (bonusType >= 0) AdditionalGrids.Add(new BreakGrid(bonusType, count));
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("额外黄点格子（" + yellowperknames + "）值有误，请修改字符串格式，或者将字符串置空，错误信息为：\n" + e.Message);
                }
        }

        private  void Addjutaiyinyimingzhi()
        {

            SpecialEffectItemWrapper specialEffectItemWrapper = new SpecialEffectItemWrapper(1800);
            specialEffectItemWrapper.SetName(name);
            specialEffectItemWrapper.SetDesc("此功法发挥十成威力时,敌人失去所有的真气，且向敌人施加一个降低所有真气增加量的特殊状态");
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

        [HarmonyPostfix]
    [HarmonyPatch(typeof(CombatSkill), "GetAllKeys")]
    public static void PatchSkill(ref List<CombatSkillItem> ____dataArray)
    {
            ReadAdditionals(yellowperknames,skillbreaklist);

            SkillBreakGridList.Instance.GetFieldValue<List<SkillBreakGridListItem>>("_dataArray")[723].SetPrivateField("BreakGridListJust", skillbreaklist);
            SkillBreakGridList.Instance.GetFieldValue<List<SkillBreakGridListItem>>("_dataArray")[723].SetPrivateField("BreakGridListKind", skillbreaklist);
            SkillBreakGridList.Instance.GetFieldValue<List<SkillBreakGridListItem>>("_dataArray")[723].SetPrivateField("BreakGridListEven", skillbreaklist);
            SkillBreakGridList.Instance.GetFieldValue<List<SkillBreakGridListItem>>("_dataArray")[723].SetPrivateField("BreakGridListRebel", skillbreaklist);
            SkillBreakGridList.Instance.GetFieldValue<List<SkillBreakGridListItem>>("_dataArray")[723].SetPrivateField("BreakGridListEgoistic", skillbreaklist);

            if (tricks.Length > 0)
            {
                ReadTricks(tricks, tricklist);
            }
            if (hits.Length > 0)
            {
                Readhits(hits, hitslist);
            }
            else
            {
                hitslist[1] = 100;
            }

            if (injurypart.Length > 0)
            {
                Readinjuryparts(injurypart, injurypartlist);
            }
            else
            {
                hitslist[1] = 100;
            }

            if (gongfaanimationname.Length > 0)
            {
                (assetfilename, prepareanimation, castanimation, castparticle, distancewhenfourstepanimation, castsoundeffect) = ReadGongFaAnimationName(gongfaanimationname, assetfilename, prepareanimation, castanimation, castparticle, distancewhenfourstepanimation, castsoundeffect);
            }
            else if (gongfaanimationname.Length == 0)
            {
                assetfilename = "31409";
                prepareanimation = "C_314";
                castanimation = "S_31409";
                castparticle = "Particle_S_31409";
                distancewhenfourstepanimation = new short[] { 40, 40, 40, 40, 40 };
                castsoundeffect = "se_skill_31409";
       
            }
            if (requirements.Length > 0)
            {
                ReadUsingRequirement(requirements, requimentslist);
            }
            else if (requirements.Length == 0)
            {
                requimentslist.Add(new PropertyAndValue(1, 100));
            }

            if (poisonnames.Length > 0)
            {
                ReadPoisons(poisonnames, poisionslist);

                poisionslistinput = new PoisonsAndLevels(poisionslist);

            }
            var (directid, reverseid) = ReadGongFaEffectName(directeffectname, reverseeffectname);

            if (whetherusingdiyeffect&& diyeffect>=1800)
            {
                directid = diyeffect;
            }
            else if (whetherusingdiyeffect && diyeffect < 1800)
            {
                directid = 1800;
            }


                foreach (CombatSkillItem combatSkillItem in ____dataArray)

                {
                    if (combatSkillItem.TemplateId == 723)
                    {
                    sbyte arg1 = (sbyte)level;
                    sbyte arg3 = (sbyte)sect;
                    sbyte arg4 = (sbyte)fiveelement;
                    sbyte arg5 = (sbyte)gtype;
                    string icon = $"sp_icon_combatskill_{sect}_{gtype}";
                    int arg6 = directid;
                    int arg7 = reverseid;
                    string arg8 = assetfilename;
                    string arg9 = prepareanimation;
                    string arg10 = castanimation;
                    string arg11 = castparticle;
                    string arg12 = castsoundeffect;
                    sbyte arg13 = (sbyte)breathstancetotalcost;
                    sbyte arg14 = (sbyte)baseinnerratio;
                    short arg15 = (short)penetrate;
                    short arg16 = (short)totalhit;
                    sbyte arg17 = 100;
                    short arg18 = (short)mobilitycost;
                    short arg19 = (short)distancebonus;
                    typeof(CombatSkillItem).GetField("Grade").SetValue(combatSkillItem, arg1);
                        typeof(CombatSkillItem).GetField("Name").SetValue(combatSkillItem, name);
                        typeof(CombatSkillItem).GetField("Desc").SetValue(combatSkillItem, desc);
                        typeof(CombatSkillItem).GetField("Icon").SetValue(combatSkillItem, icon);
                        typeof(CombatSkillItem).GetField("SectId").SetValue(combatSkillItem, arg3);
                        typeof(CombatSkillItem).GetField("FiveElements").SetValue(combatSkillItem, arg4);
                        typeof(CombatSkillItem).GetField("Type").SetValue(combatSkillItem, arg5);
                        typeof(CombatSkillItem).GetField("UsingRequirement").SetValue(combatSkillItem, requimentslist);
                        typeof(CombatSkillItem).GetField("DirectEffectID").SetValue(combatSkillItem, arg6);
                        typeof(CombatSkillItem).GetField("ReverseEffectID").SetValue(combatSkillItem, arg7);
                        typeof(CombatSkillItem).GetField("AssetFileName").SetValue(combatSkillItem, arg8);
                        typeof(CombatSkillItem).GetField("PrepareAnimation").SetValue(combatSkillItem, arg9);
                        typeof(CombatSkillItem).GetField("CastAnimation").SetValue(combatSkillItem, arg10);
                        typeof(CombatSkillItem).GetField("CastParticle").SetValue(combatSkillItem, arg11);
                        typeof(CombatSkillItem).GetField("DistanceWhenFourStepAnimation").SetValue(combatSkillItem,distancewhenfourstepanimation);
                        typeof(CombatSkillItem).GetField("CastSoundEffect").SetValue(combatSkillItem, arg12);
                        typeof(CombatSkillItem).GetField("BreathStanceTotalCost").SetValue(combatSkillItem, arg13);
                        typeof(CombatSkillItem).GetField("BaseInnerRatio").SetValue(combatSkillItem, arg14);
                        typeof(CombatSkillItem).GetField("Penetrate").SetValue(combatSkillItem, arg15);
                        typeof(CombatSkillItem).GetField("TrickCost").SetValue(combatSkillItem, tricklist);
                        typeof(CombatSkillItem).GetField("TotalHit").SetValue(combatSkillItem, arg16);
                        typeof(CombatSkillItem).GetField("InjuryPartAtkRateDistribution").SetValue(combatSkillItem, injurypartlist);
                        typeof(CombatSkillItem).GetField("PerHitDamageRateDistribution").SetValue(combatSkillItem, hitslist);
                        typeof(CombatSkillItem).GetField("InnerRatioChangeRange").SetValue(combatSkillItem, arg17);
                        typeof(CombatSkillItem).GetField("Poisons").SetValue(combatSkillItem, poisionslistinput);
                        typeof(CombatSkillItem).GetField("MobilityCost").SetValue(combatSkillItem, arg18);
                        typeof(CombatSkillItem).GetField("DistanceAdditionWhenCast").SetValue(combatSkillItem, arg19);

                }
                }
            Loaded = true;
        }

    }
}
