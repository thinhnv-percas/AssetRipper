using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tracking.Tools
{
	[Token(Token = "0x200058C")]
	internal static class ErrorLogCache
	{
		[Token(Token = "0x400132A")]
		private const string CACHE_KEY = "error_logger_cache";

		[Token(Token = "0x400132B")]
		private const int MAX_CACHED_ERRORS = 50;

		[Token(Token = "0x6001784")]
		[Address(RVA = "0x3D2D580", Offset = "0x3D2D580", Length = "0x1E0")]
		public static void AddError(ErrorLogEntry entry)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLogCache::AddError");
		}

		[Token(Token = "0x6001785")]
		[Address(RVA = "0x3D2D760", Offset = "0x3D2D760", Length = "0x24C")]
		public static List<ErrorLogEntry> GetAllErrors()
		{
			List<ErrorLogEntry> result;
			if (PlayerPrefs.HasKey("error_logger_cache"))
			{
				string text = PlayerPrefs.GetString("error_logger_cache");
				if (string.IsNullOrEmpty(text))
				{
					List<ErrorLogEntry> list = new List<ErrorLogEntry>();
					result = list;
				}
				else
				{
					ErrorLogEntryList errorLogEntryList = JsonUtility.FromJson<ErrorLogEntryList>(text);
					if (errorLogEntryList != null)
					{
						result = errorLogEntryList.Errors;
						if (errorLogEntryList.Errors != null)
						{
							goto IL_0059;
						}
					}
					List<ErrorLogEntry> list2 = new List<ErrorLogEntry>();
					result = list2;
				}
			}
			else
			{
				List<ErrorLogEntry> list3 = new List<ErrorLogEntry>();
				result = list3;
			}
			goto IL_0059;
			IL_0059:
			return result;
		}

		[Token(Token = "0x6001786")]
		[Address(RVA = "0x3D2DBA4", Offset = "0x3D2DBA4", Length = "0x140")]
		public static void Clear()
		{
			if (PlayerPrefs.HasKey("error_logger_cache"))
			{
				PlayerPrefs.DeleteKey("error_logger_cache");
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x6001787")]
		[Address(RVA = "0x3D2DCE4", Offset = "0x3D2DCE4", Length = "0x48")]
		public static int GetCount()
		{
			List<ErrorLogEntry> allErrors = GetAllErrors();
			return allErrors.Count;
		}

		[Token(Token = "0x6001788")]
		[Address(RVA = "0x3D2D9AC", Offset = "0x3D2D9AC", Length = "0x1F8")]
		private static void SaveErrors(List<ErrorLogEntry> errors)
		{
			ErrorLogEntryList errorLogEntryList = new ErrorLogEntryList();
			List<ErrorLogEntry> errors2 = new List<ErrorLogEntry>();
			errorLogEntryList.Errors = errors2;
			errorLogEntryList.Errors = errors;
			string value = JsonUtility.ToJson(errorLogEntryList);
			PlayerPrefs.SetString("error_logger_cache", value);
			PlayerPrefs.Save();
		}
	}
}
