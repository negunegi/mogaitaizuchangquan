return {
	Source = 1,
	Title = "魔改太祖长拳",
	FileId = 2877099653,
	HasArchive = false,
	Author = "Negu",
	DefaultSettings = 
	{
		[1] = 
		{
			StepSize = 180,
			MinValue = 0,
			MaxValue = 3060,
			Key = "penetrate",
			DefaultValue = 1020,
			Description = "功法的穿透加成，大拙手为1020，太祖长拳为180。",
			SettingType = "Slider",
			DisplayName = "功法穿透加成"
		},
		[2] = 
		{
			StepSize = 10,
			MinValue = 0,
			MaxValue = 720,
			Key = "totalhit",
			DefaultValue = 170,
			Description = "功法的命中加成，大拙手为170，太祖长拳为60",
			SettingType = "Slider",
			DisplayName = "命中加成"
		},
		[3] = 
		{
			DisplayName = "功法名",
			Key = "Name",
			SettingType = "InputField",
			Description = "功法的名字,也就是将“太祖长拳”变成什么",
			DefaultValue = "太初纯阳拳"
		},
		[4] = 
		{
			DisplayName = "功法描述",
			Key = "Desc",
			SettingType = "InputField",
			Description = "功法的描述,也就是将“太祖长拳有三十二式blabla”变成什么",
			DefaultValue = "“太初有无，无有无名。”太初纯阳拳乃武当失传功法。其一之所起，有一而未形”,运自然之力，拳力和煦如阳光普照，慢劲快打而后发先至，刚猛无俦，震古烁今。"
		},
		[5] = 
		{
			MinValue = 0,
			MaxValue = 8,
			Key = "Level",
			DefaultValue = 8,
			Description = "功法的品级，0为下九品，8为神一品",
			SettingType = "Slider",
			DisplayName = "品级"
		},
		[6] = 
		{
			MinValue = 0,
			MaxValue = 100,
			Key = "BaseInnerRatio",
			DefaultValue = 50,
			Description = "功法的基础发挥，0为全架势发挥，100为全提气发挥。",
			SettingType = "Slider",
			DisplayName = "基础内功发挥"
		},
	    [7] = 
		{
			DisplayName = "功法的式",
			Key = "Tricks",
			SettingType = "InputField",
			Description = "功法的式消耗,请用“式xn,式xn,式xn......”输入，其中“x”为英文的字母x，“,”为英文的逗号，如消耗崩点拿各一个为“崩x1,点x1,拿x1”，支持游戏里面任何现存的式。不需要式请空置。",
			DefaultValue = "崩x1"
		},
		[8] = 
		{
			DisplayName = "门派",
			Options = 
			{
				[1] = "无门无派",
				[2] = "少林",
				[3] = "峨眉",
				[4] = "百花",
				[5] = "武当",
				[6] = "元山",
				[7] = "狮相",
				[8] = "然山",
				[9] = "璇女",
				[10] = "铸剑",
				[11] = "空桑",
				[12] = "金刚",
				[13] = "五仙",
				[14] = "界青",
				[15] = "伏龙",
				[16] = "血犼"
			},
			Key = "Sect",
			SettingType = "Dropdown",
			Description = "选择功法是哪个门派，注意！！如果你选择的门派没有此类型的功法则功法图标会为空，例如狮相门的乐器。",
			DefaultValue = 0
		},
	[9] = 
		{
			DisplayName = "属性",
			Options = 
			{
				[1] = "金刚",
				[2] = "紫霞",
				[3] = "玄阴",
				[4] = "纯阳",
				[5] = "归元",
				[6] = "混元"
			},
			Key = "FiveElement",
			SettingType = "Dropdown",
			Description = "选择功法是哪个五元属性",
			DefaultValue = 0
		},
	[10] = 
		{
			DisplayName = "类型",
			Options = 
			{
				[1] = "拳掌",
				[2] = "指法",
				[3] = "腿法",
				[4] = "暗器",
				[5] = "剑法",
				[6] = "刀法",
				[7] = "长兵",
				[8] = "奇门",
				[9] = "软兵",
				[10] = "御射",
				[11] = "乐器"
			},
			Key = "Type",
			SettingType = "Dropdown",
			Description = "选择功法是哪个类型,如“剑法、腿法等”，注意！！如果你选择的门派没有此类型的功法则功法图标会为空，例如狮相门的乐器",
			DefaultValue = 0
		},
		[11] = 
		{
			MinValue = 0,
			MaxValue = 100,
			Key = "BreathStanceTotalCost",
			DefaultValue = 100,
			Description = "功法的气势提气总消耗，消耗比率依据内功发挥而定。",
			SettingType = "Slider",
			DisplayName = "气势提气总消耗"
		},
	    [12] = 
		{
			DisplayName = "功法的命中分布",
			Key = "Hits",
			SettingType = "InputField",
			Description = "功法的命中分布,请用“力道命中值,精妙命中值,迅疾命中值,动心命中值”，其中“,”为英文的逗号。如纯精妙命中为“0,100,0,0”。四个命中值加和必须为100。空置默认为纯精妙命中。",
			DefaultValue = "0,100,0,0"
		},
	    [13] = 
		{
			DisplayName = "功法的打点分布",
			Key = "InjuryPartAtkRateDistribution",
			SettingType = "InputField",
			Description = "功法的打点分布,请用“胸背命中值,腰腹命中值,头部命中值(如果动心命中这里为心神命中值),左手命中值,右手命中值,左腿命中值,右腿命中值”标识。其中“,”为英文的逗号。如大拙手命中为“80,20,1,10,10,0,0”。则代表大拙手打击胸腹概率为80/(80+20+1+10+10)，依次类推",
			DefaultValue = "80,20,1,10,10,0,0"
		},
		[14] = 
		{
			DisplayName = "功法动画",
			Key = "GongFaAnimationName",
			SettingType = "InputField",
			Description = "功法的动画特效，请输入你想要替换的动画的催破功法的中文，如想要化龙掌的动画特效请输入化龙掌。输入非催破功法名字一定红字。空置默认为化龙掌。注意！！！如果你使用的兵器和功法动画完全不符合会红字！！例如用琴配剑法动画。",
			DefaultValue = "化龙掌"
		},
		[15] = 
		{
			DisplayName = "功法正练特效",
			Key = "DirectEffectName",
			SettingType = "InputField",
			Description = "此功法的正练特效，请输入你想要的正练特效的催破功法的中文,如想要化龙掌的正练特效请输入化龙掌。输入非催破功法可能会红字。空置默认为diy特效巨太阴一明指。",
			DefaultValue = "无极剑式"
		},
		[16] = 
		{
			DisplayName = "功法逆练特效",
			Key = "ReverseEffectName",
			SettingType = "InputField",
			Description = "此功法的逆练特效，请输入你想要的逆练特效的催破功法的中文,如想要化龙掌的逆练特效请输入化龙掌。输入非催破功法可能会红字。空置默认为diy特效巨太阴一明指。",
			DefaultValue = "无极剑式"
		},
		[17] = {
			Key = "DirectEffectReverse",
			DisplayName = "正练特效反转",
			SettingType = "Toggle",
			DefaultValue = false,
			Description = "（此方法暂时不生效，预留接口！！！！）你输入正练特效的功法取其逆练特效作为此自定义功法的正练特效。如你在功法正练特效输入框输入化龙掌并激活此选项则会以化龙掌的逆练特效作为此功法的正练特效。"
		},
		[18] = {
			Key = "ReverseEffectDirect",
			DisplayName = "逆练特效反转",
			SettingType = "Toggle",
			DefaultValue = false,
			Description = "（此方法暂时不生效，预留接口！！！！）你输入逆练特效的功法取其正练特效作为此自定义功法的逆练特效。如你在功法逆练特效输入框输入化龙掌并激活此选项则会以化龙掌的正练特效作为此功法的逆练特效。"
		},
		[19] = 
		{
			DisplayName = "功法需求",
			Key = "UsingRequirement",
			SettingType = "InputField",
			Description = "此功法的使用需求,请用“需求xn,需求xn,需求xn.....”输入,其中“x”为英文的字母x，“,”为英文的逗号，如需求为膂力100、道法100、体质100为“膂力x100,道法造诣x100,体质x100”，支持游戏里面任何现存的大部分属性。",
			DefaultValue = "悟性x20,体质x50,道法造诣x100,拳掌造诣x100"
		},
		[20] = 
		{
			DisplayName = "功法所带毒素",
			Key = "Poisons",
			SettingType = "InputField",
			Description = "此功法的毒素,请用“烈毒量,烈毒严重程度,郁毒量,郁毒严重程度,赤毒量,赤毒严重程度,寒毒量,寒毒严重程度,腐毒量,腐毒严重程度,幻毒量,幻毒严重程度”输入,其中“x”为英文的字母x，“,”为英文的逗号，如需求为烈毒量200为奇毒，幻毒量200为生毒则输入“200,3,0,0,0,0,0,0,0,0,200,1”，支持游戏里面任何现存的全部毒性。",
			DefaultValue = "0,0,0,0,0,0,0,0,0,0,0,0"
		},
		[21] =
		{
			DisplayName = "功法全总纲黄点加成",
			Key = "YellowPerk",
			SettingType = "InputField",
			Description = "功法各个总纲的黄点数量,请用“黄点xn,黄点xn,黄点xn.....”输入,其中“x”为英文的字母x，“,”为英文的逗号，如需求为神合2个、化极2个、破限2个则输入“神合x2,化极x2,破限x2”，尽量只输入催破独有的黄点，作者没测过输入别的类型功法会不会红字。",
			DefaultValue = "神合x2,百炼x2,摧元x2,化极x2,增威x2,破限x2"
		},
		[22] =
		{
			DisplayName = "激活DIY特效",
			Key = "WhetherUsingDIYEffect",
			SettingType = "Toggle",
			Description = "是否激活DIY特效，激活以后功法正练特效将会变成你所选的diy特效。",
			DefaultValue = false
		},
		[23] = 
		{
			DisplayName = "DIY特效",
			Options = 
			{
				[1] = "特效1",
				[2] = "特效2"
			},
			Key = "DIYEffect",
			SettingType = "Dropdown",
			Description = "选择你的DIY特效，特效1：十成消除敌人所有真气，特效2：十成功法无法反震，消除敌人所有真气，敌人内息直接断绝。",
			DefaultValue = 0
		},
		[24] = 
		{
			MinValue = 0,
			MaxValue = 100,
			Key = "MobilityCost",
			DefaultValue = 0,
			Description = "功法的移动消耗，0为0%，100为消耗100%移动。",
			SettingType = "Slider",
			DisplayName = "移动消耗"
		},
		[25] = 
		{
			MinValue = 0,
			MaxValue = 200,
			Key = "DistanceAdditionWhenCast",
			DefaultValue = 0,
			Description = "功法的施放距离加成，15为1.5，100为10。太祖长拳为15。",
			SettingType = "Slider",
			DisplayName = "施放距离加成"
		}
	},
	FrontendPlugins = 
	{
		[1] = "taizuchangquanmogai.dll"
	},
	BackendPlugins = 
	{
		[1] = "mogaitaizuchangquanbackend.dll"
	},
	Cover = "cover.png",
	Description = "现在此mod可以修改功法名、描述、穿透加成、命中加成、品级、基础内功发挥、门派、类型、属性、消耗的式，更多接口正在后续更新中，喜欢的话留言下呗！"
}