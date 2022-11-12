using System;
using System.Collections.Generic;
using Config;

namespace taizuchangquanmogai
{

	// Token: 0x02000007 RID: 7
	public class SpecialEffectItemWrapper
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002E54 File Offset: 0x00001054
		public SpecialEffectItemWrapper()
		{
			instance = new SpecialEffectItem(1185, 0, 1, -1, 2804, new int[] { 1169 }, new int[] { 1170 }, new int[0], "CombatSkill.NoSect.FistAndPalm.TaiZuChangQuan");
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002E90 File Offset: 0x00001090
		public SpecialEffectItemWrapper(short templateId)
		{
			instance = new SpecialEffectItem(templateId, 0, 1, -1, 2804, new int[] { 1169 }, new int[] { 1170 }, new int[0], "CombatSkill.NoSect.FistAndPalm.TaiZuChangQuan");
		}

		public SpecialEffectItemWrapper(short templateId,SpecialEffectItem template)
		{
			instance = template;
			instance.SetPrivateField("TemplateId", templateId);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002EDF File Offset: 0x000010DF
		public void SetName(string name)
		{
			instance.SetPrivateField("Name", name);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002EF2 File Offset: 0x000010F2
		public void SetDesc(string desc)
		{
			instance.SetPrivateField("Desc", new string[] { desc });
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002F0E File Offset: 0x0000110E
		public void SetShortDesc(string shortDesc)
		{
			instance.SetPrivateField("ShortDesc", new string[] { shortDesc });
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002F2A File Offset: 0x0000112A
		public void SetClassName(string className)
		{
			instance.SetPrivateField("ClassName", className);
		}

		// Token: 0x04000025 RID: 37
		public SpecialEffectItem instance;
	}
}
