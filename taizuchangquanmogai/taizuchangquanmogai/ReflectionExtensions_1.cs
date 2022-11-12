using System;


using System.Reflection;

namespace taizuchangquanmogai
{
	// Token: 0x0200000A RID: 10
	public static class ReflectionExtensions
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00003098 File Offset: 0x00001298
		public static T GetFieldValue<T>(this object instance, string fieldname)
		{
			BindingFlags bindingAttr = (BindingFlags)52;
			FieldInfo field = instance.GetType().GetField(fieldname, bindingAttr);
			return (T)((field != null) ? field.GetValue(instance) : null);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000030C8 File Offset: 0x000012C8
		public static void SetPrivateField(this object instance, string fieldname, object value)
		{
			BindingFlags bindingAttr = (BindingFlags)52;
			instance.GetType().GetField(fieldname, bindingAttr).SetValue(instance, value);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000030EC File Offset: 0x000012EC
		public static T CallPrivateMethod<T>(this object instance, string methodname, params object[] param)
		{
			BindingFlags bindingAttr = (BindingFlags)52;
			return (T)instance.GetType().GetMethod(methodname, bindingAttr).Invoke(instance, param);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003118 File Offset: 0x00001318
		public static void CallPrivateMethod(this object instance, string methodname, params object[] param)
		{
			BindingFlags bindingAttr = (BindingFlags)52;
			instance.GetType().GetMethod(methodname, bindingAttr).Invoke(instance, param);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003140 File Offset: 0x00001340
		public static void SetPrivateProperty(this object instance, string propertyname, object value)
		{
			BindingFlags bindingAttr = (BindingFlags)36;
			instance.GetType().GetProperty(propertyname, bindingAttr).SetValue(instance, value, null);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003168 File Offset: 0x00001368
		public static T DeepCopy<T>(T obj)
		{
			if (obj is string || obj.GetType().IsValueType)
			{
				return obj;
			}
			object obj2 = Activator.CreateInstance(obj.GetType());
			foreach (FieldInfo fieldInfo in obj.GetType().GetFields((BindingFlags)60))
			{
				try
				{
					fieldInfo.SetValue(obj2, ReflectionExtensions.DeepCopy<object>(fieldInfo.GetValue(obj)));
				}
				catch
				{
				}
			}
			return (T)((object)obj2);
		}
	}
}
