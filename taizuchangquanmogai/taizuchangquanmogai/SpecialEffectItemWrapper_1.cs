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
				List<SpecialEffectItem> fieldValue =  SpecialEffect.Instance.GetFieldValue<List<SpecialEffectItem>>("_dataArray");
				this.instance = ReflectionExtensions.DeepCopy(fieldValue[1185]);
			}

			// Token: 0x06000024 RID: 36 RVA: 0x00002E90 File Offset: 0x00001090
			public SpecialEffectItemWrapper(short templateId)
			{
				List<SpecialEffectItem> fieldValue = SpecialEffect.Instance.GetFieldValue<List<SpecialEffectItem>>("_dataArray");
				this.instance = ReflectionExtensions.DeepCopy(fieldValue[1185]);
				this.instance.SetPrivateField("TemplateId", templateId);
			}

			// Token: 0x06000025 RID: 37 RVA: 0x00002EDF File Offset: 0x000010DF
			public void SetName(string name)
			{
				this.instance.SetPrivateField("Name", name);
			}

			// Token: 0x06000026 RID: 38 RVA: 0x00002EF2 File Offset: 0x000010F2
			public void SetDesc(string desc)
			{
				this.instance.SetPrivateField("Desc", new string[] { desc });
			}

			// Token: 0x06000027 RID: 39 RVA: 0x00002F0E File Offset: 0x0000110E
			public void SetShortDesc(string shortDesc)
			{
				this.instance.SetPrivateField("ShortDesc", new string[] { shortDesc });
			}

			// Token: 0x06000028 RID: 40 RVA: 0x00002F2A File Offset: 0x0000112A
			public void SetClassName(string className)
			{
				this.instance.SetPrivateField("ClassName", className);
			}

			// Token: 0x04000025 RID: 37
			public SpecialEffectItem instance;
		}
	}
