using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200004B")]
	public class FBSDKEventBinding
	{
		[CompilerGenerated]
		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x28")]
		private string _003CpathType_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x38")]
		private List<string> _003Cparameters_003Ek__BackingField;

		[Token(Token = "0x17000061")]
		public string eventName
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0xD2C5C4", Offset = "0xD2C5C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<eventName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return eventName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A3")]
			[Address(RVA = "0xD2C5CC", Offset = "0xD2C5CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<eventName>k__BackingField = value;\n\treturn;\n")]
			set
			{
				eventName = value;
			}
		}

		[Token(Token = "0x17000062")]
		public string eventType
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A4")]
			[Address(RVA = "0xD2C5D4", Offset = "0xD2C5D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<eventType>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return eventType;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0xD2C5DC", Offset = "0xD2C5DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<eventType>k__BackingField = value;\n\treturn;\n")]
			set
			{
				eventType = value;
			}
		}

		[Token(Token = "0x17000063")]
		public string appVersion
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A6")]
			[Address(RVA = "0xD2C5E4", Offset = "0xD2C5E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<appVersion>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return appVersion;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A7")]
			[Address(RVA = "0xD2C5EC", Offset = "0xD2C5EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<appVersion>k__BackingField = value;\n\treturn;\n")]
			set
			{
				appVersion = value;
			}
		}

		[Token(Token = "0x17000064")]
		public List<FBSDKCodelessPathComponent> path
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A8")]
			[Address(RVA = "0xD2C5F4", Offset = "0xD2C5F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<path>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return path;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A9")]
			[Address(RVA = "0xD2C5FC", Offset = "0xD2C5FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<path>k__BackingField = value;\n\treturn;\n")]
			set
			{
				path = value;
			}
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0xD2C290", Offset = "0xD2C290", Length = "0x334")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1F004B0]);\n\tv31 = *([v30 @ X8_v53]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, dict, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2023C0E]) = v49;\nL_001E:\n\tSystem.Object::.ctor(this);\n\tv55 = dict == 0;\n\tif (v55) goto L_011F;\n\tv63 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"event_name\");\n\tv151 = v63 == 0;\n\tif (v151) goto L_003A;\n\tv163 = *([v63 @ X0_v16 (System.String)]) != System.String;\n\tif (v163) goto L_011D;\nL_003A:\n\tthis.<eventName>k__BackingField = v63;\n\tv180 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"event_type\");\n\tv250 = v180 == 0;\n\tif (v250) goto L_0050;\n\tv201 = *([v180 @ X0_v20 (System.String)]) != System.String;\n\tif (v201) goto L_011D;\nL_0050:\n\tthis.<eventType>k__BackingField = v180;\n\tv247 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"app_version\");\n\tv251 = v247 == 0;\n\tif (v251) goto L_0066;\n\tv202 = *([v247 @ X0_v22 (System.String)]) != System.String;\n\tif (v202) goto L_011D;\nL_0066:\n\tthis.<appVersion>k__BackingField = v247;\n\tv248 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"event_name\");\n\tv252 = v248 == 0;\n\tif (v252) goto L_007A;\n\tv203 = *([v248 @ X0_v24 (System.String)]) != System.String;\n\tif (v203) goto L_011D;\nL_007A:\n\tthis.<eventName>k__BackingField = v248;\n\tv410 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(dict, \"path\");\n\tv135 = new System.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>();\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>::.ctor(v135);\n\tthis.<path>k__BackingField = v135;\n\tv138 = v410 == 0;\n\tif (v138) goto L_011F;\n\tgoto L_FFFFFFFF;\n\tv445 = v445_asT == 0;\n\tif (v445) goto L_011C;\n\tgoto L_FFFFFFFF;\n\tv454 = v454_asT == 0;\n\tif (v454) goto L_011C;\n\tv498 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v410);\nL_00E0:\n\tv528 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v376 @ stack_-88_v5 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv396 = v528 == 0;\n\tif (v396) goto L_0116;\n\tv531 = new Facebook.Unity.FBSDKCodelessPathComponent();\n\tv534 = v500 == 0;\n\tif (v534) goto L_010A;\n\tgoto L_FFFFFFFF;\n\tv550 = v550_asT == 0;\n\tif (v550) goto L_0119;\nL_010A:\n\tFacebook.Unity.FBSDKCodelessPathComponent::.ctor(v531, v500);\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>::Add(this.<path>k__BackingField, v531);\n\tgoto L_00E0;\nL_0116:\n\tv395 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v376 @ stack_-88_v5 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0145;\nL_0119:\n\tv578 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_011C:\n\tv246 = new System.InvalidCastException();\nL_011D:\n\tthrow System.InvalidCastException;\nL_011F:\n\tv149 = new System.NullReferenceException();\n\tgoto L_012E;\n\tgoto L_012E;\n\tgoto L_012E;\n\tgoto L_012E;\n\tgoto L_012E;\nL_012E:\n\tv190 = v128 != 1;\n\tif (v190) goto L_0146;\n\tv259 = 0x6D2BC0(v149, v128, v125, v34, v35, v36, v37, v38, v195, v40, v41, v42, v43, v44, v45, v46);\n\tv278 = 0x6D2490(v259, v128, v125, v34, v35, v36, v37, v38, v195, v40, v41, v42, v43, v44, v45, v46);\n\tv282 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v66 @ stack_-70_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv308 = *([v259 @ X0_v11]) == 0;\n\tv284 = ~v308;\n\tif (v284) goto L_014A;\nL_0145:\n\treturn;\nL_0146:\n\tv260 = 0x6D2380(v149, v128, v125, v34, v35, v36, v37, v38, v195, v40, v41, v42, v43, v44, v45, v46);\nL_014A:\n\tthrow System.TypeLoadException;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FBSDKEventBinding(Dictionary<string, object> dict)
		{
			//IL_045e: Expected I, but got O
			base._002Ector();
			bool flag = dict == null;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			IntPtr intPtr = (IntPtr)null;
			if (!flag)
			{
				string text = (string)dict.get_Item("event_name");
				IntPtr intPtr2;
				if (text != null)
				{
					bool flag2 = (object)text.GetType() != typeof(string);
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)0;
					if (flag2)
					{
						goto IL_0397;
					}
				}
				eventName = text;
				string text2 = (string)dict.get_Item("event_type");
				if (text2 != null)
				{
					bool flag3 = (object)text2.GetType() != typeof(string);
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)0;
					if (flag3)
					{
						goto IL_0397;
					}
				}
				eventType = text2;
				string text3 = (string)dict.get_Item("app_version");
				if (text3 != null)
				{
					bool flag4 = (object)text3.GetType() != typeof(string);
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)0;
					if (flag4)
					{
						goto IL_0397;
					}
				}
				appVersion = text3;
				string text4 = (string)dict.get_Item("event_name");
				if (text4 != null)
				{
					bool flag5 = (object)text4.GetType() != typeof(string);
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)0;
					if (flag5)
					{
						goto IL_0397;
					}
				}
				eventName = text4;
				object obj = dict.get_Item("path");
				path = new List<FBSDKCodelessPathComponent>();
				bool flag6 = obj == null;
				enumerator = default(List<object>.Enumerator);
				intPtr2 = (IntPtr)0;
				intPtr = (IntPtr)0;
				if (!flag6)
				{
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)0;
					bool flag7 = !(obj is List<object>);
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)0;
					if (!flag7)
					{
						enumerator = default(List<object>.Enumerator);
						intPtr2 = (IntPtr)0;
						bool flag8 = !(obj is List<object>);
						enumerator = default(List<object>.Enumerator);
						intPtr2 = (IntPtr)0;
						if (!flag8)
						{
							object enumerator2 = ((List<object>)obj).GetEnumerator();
							intPtr2 = (IntPtr)0;
							List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
							Dictionary<string, object> dictionary = default(Dictionary<string, object>);
							while (true)
							{
								if (enumerator3.MoveNext())
								{
									FBSDKCodelessPathComponent item = new FBSDKCodelessPathComponent(dictionary);
									if (dictionary != null)
									{
										Dictionary<string, object> dictionary2 = dictionary as Dictionary<string, object>;
										if (dictionary2 == null)
										{
											break;
										}
									}
									path.Add(item);
									intPtr2 = (IntPtr)0;
									continue;
								}
								enumerator3.Dispose();
								return;
							}
							InvalidCastException ex = new InvalidCastException();
							throw new NullReferenceException();
						}
					}
					InvalidCastException ex2 = new InvalidCastException();
					goto IL_0397;
				}
			}
			NullReferenceException ex3 = new NullReferenceException();
			if (intPtr == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj2 = default(object);
				if (obj2 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_0397:
			throw new InvalidCastException();
		}
	}
}
