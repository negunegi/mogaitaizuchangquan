using System;
using System.IO;
using System.Text;

namespace taizuchangquanmogai
{
	public class Debug
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002AE0 File Offset: 0x00000CE0
		public static void Log(string text)
		{
			StreamWriter streamWriter = File.AppendText(Debug.logFile);
			DateTime now = DateTime.Now;
			streamWriter.WriteLine(string.Format("{0}-{1}-{2} {3}:{4}:{5}：{6}", new object[] { now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, text }));
			streamWriter.Close();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002B78 File Offset: 0x00000D78
		public static void Log<T>(T[] array)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString() + ", ");
			}
			Debug.Log(stringBuilder.ToString());
		}

		// Token: 0x04000023 RID: 35
		private static string logFile = "FRONTE_log.txt";
	}
}

