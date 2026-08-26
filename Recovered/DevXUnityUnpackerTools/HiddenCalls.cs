using ARMD;
using @as;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using WASD;

internal static class HiddenCalls
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020
	{
		public static readonly _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020();

		public static Func<Type, bool> _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020;

		internal bool _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A(Type _0020)
		{
			return _0020 != null;
		}
	}

	internal static List<Type> types;

	internal const string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A = "FunAttr";

	internal static Type FunAttrType = Type.GetType("FunAttr");

	internal static PropertyInfo FunAttrNum = Type.GetType("FunAttr").GetProperty("Num");

	internal const string _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 = "CIntA";

	internal static Type CIntAType = Type.GetType("CIntA");

	internal static PropertyInfo CIntANum = Type.GetType("CIntA").GetProperty("Num");

	internal static BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	internal static Dictionary<string, Type> typesDict = new Dictionary<string, Type>();

	public static Dictionary<string, MethodInfo> methodsDict = new Dictionary<string, MethodInfo>();

	public static Dictionary<string, PropertyInfo> propertiesDict = new Dictionary<string, PropertyInfo>();

	public static Dictionary<string, FieldInfo> fieldsDict = new Dictionary<string, FieldInfo>();

	public static List<Type> Types
	{
		get
		{
			if (types != null)
			{
				return types;
			}
			types = new List<Type>();
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020));
			types.Add(typeof(ManyCodeCls));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020));
			types.Add(typeof(AssetParser));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020));
			types.Add(typeof(LicNameManager));
			types.Add(typeof(LicNameManagerGlobal));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020));
			types.Add(typeof(ServerLink));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A));
			types.Add(typeof(CheckNewVerReqManager));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020));
			types.Add(typeof(ShaderInfo));
			types.Add(typeof(CultureFormatter));
			types.Add(typeof(_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A));
			types.Add(typeof(AssetParser));
			types.Add(typeof(RequestManager));
			types.Add(typeof(GetMethodManager));
			types.Add(typeof(_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A));
			types.Add(typeof(ExitManager));
			types.Add(typeof(MaybeAlertManager));
			types.Add(typeof(MainForm));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A));
			types.Add(typeof(GameRecoveryLicManager));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A));
			types.Add(typeof(LicChecker));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020));
			types.Add(typeof(_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A));
			types.Add(typeof(_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020));
			types.Add(typeof(_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A));
			types.Add(typeof(LicensePage));
			types.Add(typeof(例子子));
			types.Add(typeof(Loader));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020));
			types.Add(typeof(_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020));
			types.Add(typeof(_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020));
			foreach (Type type in types)
			{
				try
				{
					if (!type.ContainsGenericParameters && !type.Name.Contains("`"))
					{
						typesDict[type.FullName] = type;
						string text = null;
						object[] customAttributes = type.GetCustomAttributes(inherit: false);
						foreach (object obj in customAttributes)
						{
							if (obj.GetType() == FunAttrType)
							{
								text = (string)FunAttrNum.GetValue(obj, null);
								typesDict[text] = type;
								typesDict[_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(text).ToString()] = type;
								typesDict[Crc64Iso.Compute(text).ToString()] = type;
							}
						}
						MethodInfo[] methods = type.GetMethods(flags);
						if (methods != null)
						{
							MethodInfo[] array = methods;
							foreach (MethodInfo methodInfo in array)
							{
								if (methodInfo != null)
								{
									methodsDict[type.FullName + ":" + methodInfo.Name] = methodInfo;
									customAttributes = methodInfo.GetCustomAttributes(inherit: false);
									foreach (object obj2 in customAttributes)
									{
										if (obj2.GetType() == FunAttrType)
										{
											string text2 = (string)FunAttrNum.GetValue(obj2, null);
											int num = methodInfo.GetParameters().Length;
											methodsDict[_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(text2).ToString()] = methodInfo;
											methodsDict[Crc64Iso.Compute(text2).ToString()] = methodInfo;
											methodsDict[text2] = methodInfo;
											methodsDict[text + ":" + text2] = methodInfo;
											methodsDict[type.FullName + ":" + text2] = methodInfo;
										}
									}
								}
							}
						}
						FieldInfo[] fields = type.GetFields(flags);
						if (fields != null)
						{
							FieldInfo[] array2 = fields;
							foreach (FieldInfo fieldInfo in array2)
							{
								if (fieldInfo != null)
								{
									fieldsDict[type.FullName + ":" + fieldInfo.Name] = fieldInfo;
									customAttributes = fieldInfo.GetCustomAttributes(inherit: false);
									foreach (object obj3 in customAttributes)
									{
										if (obj3.GetType() == FunAttrType)
										{
											string text3 = (string)FunAttrNum.GetValue(obj3, null);
											fieldsDict[_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(text3).ToString()] = fieldInfo;
											fieldsDict[Crc64Iso.Compute(text3).ToString()] = fieldInfo;
											fieldsDict[text3] = fieldInfo;
											fieldsDict[text + ":" + text3] = fieldInfo;
											fieldsDict[type.FullName + ":" + text3] = fieldInfo;
										}
									}
								}
							}
						}
						PropertyInfo[] properties = type.GetProperties(flags);
						if (properties != null)
						{
							PropertyInfo[] array3 = properties;
							foreach (PropertyInfo propertyInfo in array3)
							{
								if (propertyInfo != null)
								{
									propertiesDict[type.FullName + ":" + propertyInfo.Name] = propertyInfo;
									customAttributes = propertyInfo.GetCustomAttributes(inherit: false);
									foreach (object obj4 in customAttributes)
									{
										if (obj4.GetType() == FunAttrType)
										{
											string text4 = (string)FunAttrNum.GetValue(obj4, null);
											propertiesDict[_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(text4).ToString()] = propertyInfo;
											propertiesDict[Crc64Iso.Compute(text4).ToString()] = propertyInfo;
											propertiesDict[text4] = propertyInfo;
											propertiesDict[text + ":" + text4] = propertyInfo;
											propertiesDict[type.FullName + ":" + text4] = propertyInfo;
										}
									}
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
			return types;
		}
	}

	internal static IEnumerable<Type> _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020(this Assembly _0020)
	{
		try
		{
			return _0020.GetTypes();
		}
		catch (ReflectionTypeLoadException ex)
		{
			return ex.Types.Where(_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A);
		}
	}

	internal static bool Call2(string _0020, object _0020_000A = null)
	{
		object obj = CallObjectSafe1(_0020_000A, _0020);
		if (obj is bool)
		{
			return (bool)obj;
		}
		return false;
	}

	internal static void _0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A(string _0020, bool _0020_000A, object _0020_0020 = null)
	{
		CallObjectSafe1(_0020_0020, _0020, _0020_000A);
	}

	internal static string CallString(string _0020, object _0020_000A = null)
	{
		object obj = CallObjectSafe1(_0020_000A, _0020);
		if (obj is string)
		{
			return (string)obj;
		}
		return obj?.ToString();
	}

	internal static void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020(string _0020, string _0020_000A, object _0020_0020 = null)
	{
		CallObjectSafe1(_0020_0020, _0020, _0020_000A);
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A(string _0020, params object[] param)
	{
		return CallObjectSafe1(null, _0020, param);
	}

	internal static void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020(object _0020, string _0020_000A, params object[] param)
	{
		ThreadCaller._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020(_0020, _0020_000A, param);
	}

	internal static void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A(object _0020, string _0020_000A, params object[] param)
	{
		ThreadCaller._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A(_0020, _0020_000A, param);
	}

	internal static object CallObjectSafe3(object _0020, uint _0020_000A, params object[] param)
	{
		try
		{
			return MainCall(_0020, _0020_000A.ToString(), param);
		}
		catch (Exception)
		{
			return null;
		}
	}

	internal static object CallObjectSafe1(object _0020, string _0020_000A, params object[] param)
	{
		try
		{
			return MainCall(_0020, _0020_000A, param);
		}
		catch (Exception)
		{
			return null;
		}
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A(object _0020, string _0020_000A, params object[] param)
	{
		return MainCall(_0020, _0020_000A, param);
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020(object _0020, string _0020_000A, params object[] param)
	{
		try
		{
			return MainCall(_0020, _0020_000A, param);
		}
		catch (Exception)
		{
			try
			{
				return MainCall(_0020, _0020_000A, param);
			}
			catch
			{
			}
			return null;
		}
	}

	internal static object MainCall(object _0020, string _0020_000A, params object[] param)
	{
		Type type = null;
		MethodInfo methodInfo = null;
		FieldInfo fieldInfo = null;
		PropertyInfo propertyInfo = null;
		if (Types.Count == 0 || _0020_000A == null)
		{
			return null;
		}
		if (_0020_000A.StartsWith("@"))
		{
			_0020_000A = _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020(_0020_000A);
		}
		if (_0020_000A == null)
		{
			return null;
		}
		if (methodsDict.ContainsKey(_0020_000A))
		{
			methodInfo = methodsDict[_0020_000A];
			if (methodInfo != null)
			{
				goto IL_028e;
			}
		}
		if (fieldsDict.ContainsKey(_0020_000A))
		{
			fieldInfo = fieldsDict[_0020_000A];
			if (fieldInfo != null)
			{
				goto IL_028e;
			}
		}
		if (propertiesDict.ContainsKey(_0020_000A))
		{
			propertyInfo = propertiesDict[_0020_000A];
			if (propertyInfo != null)
			{
				goto IL_028e;
			}
		}
		string key = Crc64Iso.Compute(_0020_000A).ToString();
		if (methodsDict.ContainsKey(key))
		{
			methodInfo = methodsDict[key];
			if (methodInfo != null)
			{
				goto IL_028e;
			}
		}
		if (fieldsDict.ContainsKey(key))
		{
			fieldInfo = fieldsDict[key];
			if (fieldInfo != null)
			{
				goto IL_028e;
			}
		}
		if (propertiesDict.ContainsKey(key))
		{
			propertyInfo = propertiesDict[key];
			if (propertyInfo != null)
			{
				goto IL_028e;
			}
		}
		key = _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(_0020_000A).ToString();
		if (methodsDict.ContainsKey(key))
		{
			methodInfo = methodsDict[key];
			if (methodInfo != null)
			{
				goto IL_028e;
			}
		}
		if (fieldsDict.ContainsKey(key))
		{
			fieldInfo = fieldsDict[key];
			if (fieldInfo != null)
			{
				goto IL_028e;
			}
		}
		if (propertiesDict.ContainsKey(key))
		{
			propertyInfo = propertiesDict[key];
			if (propertyInfo != null)
			{
				goto IL_028e;
			}
		}
		string text = (_0020 != null) ? (_0020.GetType().FullName + ":") : null;
		if (text != null)
		{
			string key2 = text + _0020_000A;
			if (methodsDict.ContainsKey(key2))
			{
				methodInfo = methodsDict[_0020_000A];
				if (methodInfo != null)
				{
					goto IL_028e;
				}
			}
			if (fieldsDict.ContainsKey(key2))
			{
				fieldInfo = fieldsDict[key2];
				if (fieldInfo != null)
				{
					goto IL_028e;
				}
			}
			if (propertiesDict.ContainsKey(_0020_000A))
			{
				propertyInfo = propertiesDict[key2];
				if (propertyInfo != null)
				{
					goto IL_028e;
				}
			}
		}
		if (methodsDict.ContainsKey(_0020_000A) && methodInfo == null)
		{
			return null;
		}
		if (fieldsDict.ContainsKey(_0020_000A) && fieldInfo == null)
		{
			return null;
		}
		if (propertiesDict.ContainsKey(_0020_000A) && propertyInfo == null)
		{
			return null;
		}
		goto IL_028e;
		IL_028e:
		if (methodInfo != null)
		{
			if (methodInfo.IsStatic)
			{
				return methodInfo.Invoke(null, param);
			}
			if (_0020 == null)
			{
				return null;
			}
			return methodInfo.Invoke(_0020, param);
		}
		if (fieldInfo != null)
		{
			if (param == null || param.Length == 0)
			{
				return fieldInfo.GetValue(_0020);
			}
			object value = fieldInfo.GetValue(_0020);
			fieldInfo.SetValue(_0020, param[0]);
			return value;
		}
		if (propertyInfo != null)
		{
			if (param == null || param.Length == 0)
			{
				return propertyInfo.GetValue(_0020, null);
			}
			object result = null;
			try
			{
				result = propertyInfo.GetValue(_0020, null);
			}
			catch
			{
			}
			propertyInfo.SetValue(_0020, param[0], null);
			return result;
		}
		return null;
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020(object _0020, string _0020_000A, params object[] param)
	{
		if (_0020 != null)
		{
			MethodInfo method = _0020.GetType().GetMethod(_0020_000A, flags);
			if (method != null)
			{
				try
				{
					return method.Invoke(_0020, param);
				}
				catch
				{
				}
			}
		}
		return null;
	}

	internal static object CallObjectClass1(object _0020, string _0020_000A, params object[] param)
	{
		if (_0020 != null)
		{
			MethodInfo[] methods = _0020.GetType().GetMethods(flags);
			foreach (MethodInfo methodInfo in methods)
			{
				if (!(methodInfo != null))
				{
					continue;
				}
				object[] customAttributes = methodInfo.GetCustomAttributes(inherit: false);
				foreach (object obj in customAttributes)
				{
					if (obj.GetType() == FunAttrType && (string)FunAttrNum.GetValue(obj, null) == _0020_000A)
					{
						return methodInfo.Invoke(_0020, param);
					}
				}
			}
		}
		return null;
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020(object _0020, string _0020_000A, string _0020_0020, params object[] param)
	{
		Type type = null;
		foreach (Type type2 in Types)
		{
			if (!type2.ContainsGenericParameters && !type2.Name.Contains("`"))
			{
				object[] customAttributes = type2.GetCustomAttributes(inherit: false);
				foreach (object obj in customAttributes)
				{
					if (obj.GetType() == FunAttrType && (string)FunAttrNum.GetValue(obj, null) == _0020_000A)
					{
						type = type2;
						break;
					}
				}
			}
		}
		if (type == null)
		{
			return null;
		}
		MethodInfo[] methods = type.GetMethods(flags);
		if (methods == null)
		{
			return null;
		}
		MethodInfo[] array = methods;
		foreach (MethodInfo methodInfo in array)
		{
			if (!(methodInfo != null))
			{
				continue;
			}
			object[] customAttributes = methodInfo.GetCustomAttributes(inherit: false);
			foreach (object obj2 in customAttributes)
			{
				if (obj2.GetType() == FunAttrType && (string)FunAttrNum.GetValue(obj2, null) == _0020_0020)
				{
					try
					{
						return methodInfo.Invoke(_0020, param);
					}
					catch
					{
						return null;
					}
				}
			}
		}
		return null;
	}

	internal static object CallInClass(object _0020, ulong _0020_000A, params object[] param)
	{
		if (_0020 != null)
		{
			MethodInfo[] methods = _0020.GetType().GetMethods(flags);
			foreach (MethodInfo methodInfo in methods)
			{
				if (!(methodInfo != null))
				{
					continue;
				}
				object[] customAttributes = methodInfo.GetCustomAttributes(inherit: false);
				foreach (object obj in customAttributes)
				{
					if (obj.GetType() == CIntAType && (ulong)CIntANum.GetValue(obj, null) == _0020_000A)
					{
						try
						{
							return methodInfo.Invoke(_0020, param);
						}
						catch
						{
							return null;
						}
					}
				}
			}
		}
		return null;
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(string _0020, string _0020_000A, params object[] param)
	{
		Type type = typeof(HiddenCalls).Assembly.GetType(_0020);
		if (type != null)
		{
			MethodInfo method = type.GetMethod(_0020_000A, flags);
			if (method != null)
			{
				try
				{
					return method.Invoke(null, param);
				}
				catch
				{
					return null;
				}
			}
		}
		return null;
	}

	internal static object _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A(string _0020, params object[] param)
	{
		foreach (Type type in Types)
		{
			try
			{
				if (!type.ContainsGenericParameters && !type.Name.Contains("`"))
				{
					goto IL_003b;
				}
			}
			catch
			{
			}
			continue;
			IL_003b:
			FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
			if (fields != null && fields.Length == 1)
			{
				FieldInfo fieldInfo = fields[0];
				if (fieldInfo != null)
				{
					try
					{
						object value = fieldInfo.GetValue(null);
						if (value != null && value.ToString() == _0020)
						{
							MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
							if (methods != null && methods.Length == 1)
							{
								return methods[0].Invoke(null, param);
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		return null;
	}
}
