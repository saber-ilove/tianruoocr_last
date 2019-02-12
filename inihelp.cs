using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace 天若OCR文字识别
{
	// Token: 0x0200002D RID: 45
	public static class inihelp
	{
		// Token: 0x0600027E RID: 638
		[DllImport("kernel32")]
		public static extern int GetPrivateProfileString(string sectionName, string key, string defaultValue, byte[] returnBuffer, int size, string filePath);

		// Token: 0x0600027F RID: 639
		[DllImport("kernel32")]
		public static extern long WritePrivateProfileString(string sectionName, string key, string value, string filePath);

		public static string CONFIGPATH = AppDomain.CurrentDomain.BaseDirectory + "天若OCR文字识别.ini";

		// Token: 0x06000280 RID: 640 RVA: 0x0001D92C File Offset: 0x0001BB2C
		public static string GetValue(string sectionName, string key)
		{
			byte[] array = new byte[2048];
			int privateProfileString = inihelp.GetPrivateProfileString(sectionName, key, "发生错误", array, 999, CONFIGPATH);
			String val = Encoding.Default.GetString(array, 0, privateProfileString);
			using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "debug.txt")) 
			{
					sw.WriteLine(sectionName + "|" + key + "|" + privateProfileString + "|" + val);
			}	
			return val;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001D9D0 File Offset: 0x0001BBD0
		public static bool SetValue(string sectionName, string key, string value)
		{
			bool result;
			try
			{
				result = ((int)inihelp.WritePrivateProfileString(sectionName, key, value, CONFIGPATH) > 0);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
