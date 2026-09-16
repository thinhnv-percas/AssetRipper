using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000D")]
public class IronSourceSegment
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x2000010")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x4000063")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x4000064")]
		public static Func<KeyValuePair<string, string>, string> _003C_003E9__10_0;

		[Token(Token = "0x4000065")]
		public static Func<IGrouping<string, KeyValuePair<string, string>>, string> _003C_003E9__10_1;

		[Token(Token = "0x4000066")]
		public static Func<IGrouping<string, KeyValuePair<string, string>>, string> _003C_003E9__10_2;

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x159E530", Offset = "0x159E530", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EE7208]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20297BD]) = v37;\nL_0015:\n\tv41 = new IronSourceSegment+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x159E594", Offset = "0x159E594", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal string _003CgetSegmentAsDict_003Eb__10_0(KeyValuePair<string, string> d)
		{
			return (string)d;
		}

		internal string _003CgetSegmentAsDict_003Eb__10_1(IGrouping<string, KeyValuePair<string, string>> d)
		{
			return d.Key;
		}

		internal string _003CgetSegmentAsDict_003Eb__10_2(IGrouping<string, KeyValuePair<string, string>> d)
		{
			//IL_0015: Expected O, but got I
			KeyValuePair<string, string> keyValuePair = d.First();
			return (string)0;
		}
	}

	[Token(Token = "0x4000057")]
	[FieldOffset(Offset = "0x10")]
	public int age;

	[Token(Token = "0x4000058")]
	[FieldOffset(Offset = "0x18")]
	public string gender;

	[Token(Token = "0x4000059")]
	[FieldOffset(Offset = "0x20")]
	public int level;

	[Token(Token = "0x400005A")]
	[FieldOffset(Offset = "0x24")]
	public int isPaying;

	[Token(Token = "0x400005B")]
	[FieldOffset(Offset = "0x28")]
	public long userCreationDate;

	[Token(Token = "0x400005C")]
	[FieldOffset(Offset = "0x30")]
	public double iapt;

	[Token(Token = "0x400005D")]
	[FieldOffset(Offset = "0x38")]
	public string segmentName;

	[Token(Token = "0x400005E")]
	[FieldOffset(Offset = "0x40")]
	public Dictionary<string, string> customs;

	[Token(Token = "0x600017E")]
	[Address(RVA = "0x159E438", Offset = "0x159E438", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED6530]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297BA]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v44);\n\tthis.customs = v44;\n\tthis.age = 0xFFFFFFFF;\n\tthis.level = -1;\n\tthis.userCreationDate = -1;\n\tthis.iapt = 0d;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceSegment()
	{
		//IL_0030: Expected I8, but got I4
		base._002Ector();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		customs = dictionary;
		age = -1;
		level = -1;
		userCreationDate = -1L;
		iapt = 0.0;
	}

	[Token(Token = "0x600017F")]
	[Address(RVA = "0x159E4C0", Offset = "0x159E4C0", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv26 = *([1EDA378]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20297BB]) = v44;\nL_0026:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(this.customs, key, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setCustom(string key, string value)
	{
		customs.Add(key, value);
	}

	[Token(Token = "0x6000180")]
	[Address(RVA = "0x1590C80", Offset = "0x1590C80", Length = "0x498")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EC8100]);\n\tv25 = *([v24 @ X8_v77]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20297BC]) = v44;\nL_0019:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v48);\n\tv53 = this.age;\n\tv54 = this.age + 1;\n\tv56 = v54 == 0;\n\tif (v56) goto L_003B;\n\t// 43 Box v64 @ X0_v70 (System.Object), typeof(System.Int32), &v53 @ X8_v7 (System.Int32)\n\tv86 = System.String::Concat(v64);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"age\", v86);\nL_003B:\n\tv84 = System.String::IsNullOrEmpty(this.gender);\n\tv88 = v84 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_004B;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"gender\", this.gender);\nL_004B:\n\tv53 = this.level;\n\tv105 = this.level + 1;\n\tv107 = v105 == 0;\n\tif (v107) goto L_0065;\n\t// 87 Box v203 @ X0_v65 (System.Object), typeof(System.Int32), &v53 @ X8_v7 (System.Int32)\n\tv180 = System.String::Concat(v203);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"level\", v180);\nL_0065:\n\tv53 = this.isPaying;\n\tv216 = this.isPaying < 1;\n\tv162 = ~v216;\n\tv132 = this.isPaying - 1;\n\tv166 = v132 == 0;\n\tv217 = ~v166;\n\tv116 = v162 & v217;\n\tif (v116) goto L_0085;\n\t// 119 Box v221 @ X0_v61 (System.Object), typeof(System.Int32), &v53 @ X8_v7 (System.Int32)\n\tv181 = System.String::Concat(v221);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"isPaying\", v181);\nL_0085:\n\tv193 = this.userCreationDate;\n\tv234 = this.userCreationDate + 1;\n\tv167 = v234 == 0;\n\tif (v167) goto L_00A1;\n\t// 145 Box v281 @ X0_v57 (System.Object), typeof(System.Int64), &v193 @ X8_v15 (System.Int64)\n\tv182 = System.String::Concat(v281);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"userCreationDate\", v182);\nL_00A1:\n\tv183 = System.String::IsNullOrEmpty(this.segmentName);\n\tv294 = v183 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_00B1;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"segmentName\", this.segmentName);\nL_00B1:\n\tv113 = this.iapt;\n\tv117 = this.iapt <= 0;\n\tif (v117) goto L_00D7;\n\t// 196 Box v319 @ X0_v52 (System.Object), typeof(System.Double), &v113 @ V0_v2 (System.Double)\n\tv184 = System.String::Concat(v319);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v48, \"iapt\", v184);\nL_00D7:\n\tv337 = System.Linq.Enumerable::Concat(v48, this.customs);\n\tgoto L_00E8;\n\tv345 = *([v341 @ X8_v21 (Il2CppClass<IronSourceSegment+<>c>)+E0]);\n\tv346 = v345 == 0;\n\tv347 = ~v346;\n\tif (v347) goto L_00E8;\n\tv360 = v341;\n\tv350 = \"il2cpp_codegen_runtime_class_init\"(v360, v333, v336, v320, v30, v31, v32, v33, v113, v35, v36, v37, v38, v39, v40, v41);\n\tv353 = IronSourceSegment+<>c;\nL_00E8:\n\tv382 = v354.<>9__10_0;\n\tv356 = v354.<>9__10_0 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_010E;\n\tgoto L_00FC;\n\tv390 = *([v352 @ X8_v22 (Il2CppClass<IronSourceSegment+<>c>)+E0]);\n\tv391 = v390 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00FC;\n\tv407 = v352;\n\tv396 = \"il2cpp_codegen_runtime_class_init\"(v407, v333, v336, v320, v30, v31, v32, v33, v113, v35, v36, v37, v38, v39, v40, v41);\n\tv398 = IronSourceSegment+<>c;\n\tv394 = *([v398 @ X8_v57+B8]);\nL_00FC:\n\tv377 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.String>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.String>::.ctor(v377, v393.<>9, Il2CppMethodInfo);\n\tv381.<>9__10_0 = v377;\nL_010E:\n\tv389 = System.Linq.Enumerable::GroupBy(v337, v382);\n\tgoto L_011D;\n\tv411 = *([v402 @ X8_v26 (Il2CppClass<IronSourceSegment+<>c>)+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tgoto L_011D;\n\tv425 = v402;\n\tv416 = \"il2cpp_codegen_runtime_class_init\"(v425, v387, v388, v368, v30, v31, v32, v33, v113, v35, v36, v37, v38, v39, v40, v41);\n\tv419 = IronSourceSegment+<>c;\nL_011D:\n\tv447 = v420.<>9__10_1;\n\tv422 = v420.<>9__10_1 == 0;\n\tv423 = ~v422;\n\tif (v423) goto L_0141;\n\tgoto L_0131;\n\tv452 = *([v418 @ X8_v27 (Il2CppClass<IronSourceSegment+<>c>)+E0]);\n\tv453 = v452 == 0;\n\tv454 = ~v453;\n\tif (v454) goto L_0131;\n\tv477 = v418;\n\tv458 = \"il2cpp_codegen_runtime_class_init\"(v477, v387, v388, v368, v30, v31, v32, v33, v113, v35, v36, v37, v38, v39, v40, v41);\n\tv460 = IronSourceSegment+<>c;\n\tv456 = *([v460 @ X8_v48+B8]);\nL_0131:\n\tv442 = new System.Func`2<System.Linq.IGrouping`2<System.String, System.Collections.Generic.KeyValuePair`2<System.String, System.String>>, System.String>();\n\tSystem.Func`2<System.Linq.IGrouping`2<System.String, System.Collections.Generic.KeyValuePair`2<System.String, System.String>>, System.String>::.ctor(v442, v455.<>9, Il2CppMethodInfo);\n\tv438.<>9__10_1 = v442;\nL_0141:\n\tgoto L_014A;\n\tv464 = *([v445 @ X8_v28 (Il2CppClass<IronSourceSegment+<>c>)+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tgoto L_014A;\n\tv482 = v445;\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v482, v439, v435, v433, v30, v31, v32, v33, v113, v35, v36, v37, v38, v39, v40, v41);\n\tv472 = IronSourceSegment+<>c;\nL_014A:\n\tv488 = v473.<>9__10_2;\n\tv475 = v473.<>9__10_2 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_0171;\n\tgoto L_015E;\n\tv505 = *([v471 @ X8_v29 (Il2CppClass<IronSourceSegment+<>c>)+E0]);\n\tv506 = v505 == 0;\n\tv507 = ~v506;\n\tif (v507) goto L_015E;\n\tv517 = v471;\n\tv511 = \"il2cpp_codegen_runtime_class_init\"(v517, v439, v435, v433, v30, v31, v32, v33, v113, v35, v36, v37, v38, v39, v40, v41);\n\tv513 = IronSourceSegment+<>c;\n\tv509 = *([v513 @ X8_v40+B8]);\nL_015E:\n\tv499 = new System.Func`2<System.Linq.IGrouping`2<System.String, System.Collections.Generic.KeyValuePair`2<System.String, System.String>>, System.String>();\n\tSystem.Func`2<System.Linq.IGrouping`2<System.String, System.Collections.Generic.KeyValuePair`2<System.String, System.String>>, System.String>::.ctor(v499, v508.<>9, Il2CppMethodInfo);\n\tv502.<>9__10_2 = v499;\nL_0171:\n\treturnVal2 = System.Linq.Enumerable::ToDictionary(v389, v447, v488);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 248 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Dictionary<string, string> getSegmentAsDict()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num = age;
		if (age + 1 != 0)
		{
			object obj = num;
			string value = string.Concat(obj);
			dictionary.Add("age", value);
		}
		if (!string.IsNullOrEmpty(gender))
		{
			dictionary.Add("gender", gender);
		}
		num = level;
		if (level + 1 != 0)
		{
			object obj2 = num;
			string value2 = string.Concat(obj2);
			dictionary.Add("level", value2);
		}
		num = isPaying;
		bool flag = isPaying < 1;
		bool flag2 = !flag;
		int num2 = isPaying - 1;
		bool flag3 = num2 == 0;
		bool flag4 = !flag3;
		if (!(flag2 && flag4))
		{
			object obj3 = num;
			string value3 = string.Concat(obj3);
			dictionary.Add("isPaying", value3);
		}
		long num3 = userCreationDate;
		long num4 = userCreationDate + 1;
		if (num4 != 0)
		{
			object obj4 = num3;
			string value4 = string.Concat(obj4);
			dictionary.Add("userCreationDate", value4);
		}
		if (!string.IsNullOrEmpty(segmentName))
		{
			dictionary.Add("segmentName", segmentName);
		}
		double num5 = iapt;
		if (iapt > 0.0)
		{
			object obj5 = num5;
			string value5 = string.Concat(obj5);
			dictionary.Add("iapt", value5);
		}
		IEnumerable<KeyValuePair<string, string>> source = dictionary.Concat(customs);
		Func<KeyValuePair<string, string>, string> keySelector = _003C_003Ec._003C_003E9__10_0;
		if (_003C_003Ec._003C_003E9__10_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__10_0 = (KeyValuePair<string, string> d) => (string)d);
		}
		IEnumerable<IGrouping<string, KeyValuePair<string, string>>> source2 = source.GroupBy(keySelector);
		Func<IGrouping<string, KeyValuePair<string, string>>, string> keySelector2 = _003C_003Ec._003C_003E9__10_1;
		if (_003C_003Ec._003C_003E9__10_1 == null)
		{
			keySelector2 = (_003C_003Ec._003C_003E9__10_1 = (IGrouping<string, KeyValuePair<string, string>> d) => d.Key);
		}
		Func<IGrouping<string, KeyValuePair<string, string>>, string> elementSelector = _003C_003Ec._003C_003E9__10_2;
		if (_003C_003Ec._003C_003E9__10_2 == null)
		{
			elementSelector = (_003C_003Ec._003C_003E9__10_2 = delegate(IGrouping<string, KeyValuePair<string, string>> d)
			{
				//IL_0015: Expected O, but got I
				KeyValuePair<string, string> keyValuePair = d.First();
				return (string)0;
			});
		}
		return source2.ToDictionary(keySelector2, elementSelector);
	}
}
