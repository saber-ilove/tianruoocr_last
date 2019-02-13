using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace 天若OCR文字识别
{
	// Token: 0x0200002D RID: 45
	public static class inihelp
	{
		public static string CONFIGPATH = AppDomain.CurrentDomain.BaseDirectory + "天若OCR文字识别.json";
		public static JObject ini;

		public static void LoadConfig()
		{
			try
			{
				ini = JObject.Parse(File.ReadAllText(CONFIGPATH));
			}
			catch (Exception ex)
			{
				ini = new JObject();
			}
		}

		public static void SaveConfig()
		{
			File.WriteAllText(CONFIGPATH, ini.ToString());
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0001D92C File Offset: 0x0001BB2C
		public static string GetValue(string sectionName, string key)
		{
			if (ini[sectionName] == null || ini[sectionName][key] == null)
			{
				return "发生错误";
			}
			return (string)ini[sectionName][key];
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001D9D0 File Offset: 0x0001BBD0
		public static void SetValue(string sectionName, string key, string value)
		{
			if (ini[sectionName] == null)
			{
				ini[sectionName] = new JObject();
			}
			ini[sectionName][key] = value;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001D9D0 File Offset: 0x0001BBD0
		public static void InitValue(string sectionName, string key, string value)
		{
			if (GetValue(sectionName, key) == "发生错误")
			{
				SetValue(sectionName, key, value);
			}
		}
	}
}
