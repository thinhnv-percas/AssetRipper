using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000033")]
	internal abstract class ResultBase : IInternalResult, IResult
	{
		[CompilerGenerated]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x10")]
		private string _003CError_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x18")]
		private IDictionary<string, object> _003CResultDictionary_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x20")]
		private string _003CRawResult_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x28")]
		private bool _003CCancelled_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x30")]
		private string _003CCallbackId_003Ek__BackingField;

		[Token(Token = "0x17000045")]
		public virtual string Error
		{
			[CompilerGenerated]
			[Token(Token = "0x600010B")]
			[Address(RVA = "0xD34504", Offset = "0xD34504", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Error>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Error;
			}
			[CompilerGenerated]
			[Token(Token = "0x600010C")]
			[Address(RVA = "0xD3450C", Offset = "0xD3450C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Error>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CError_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000046")]
		public virtual IDictionary<string, object> ResultDictionary
		{
			[CompilerGenerated]
			[Token(Token = "0x600010D")]
			[Address(RVA = "0xD34514", Offset = "0xD34514", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ResultDictionary>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ResultDictionary;
			}
			[CompilerGenerated]
			[Token(Token = "0x600010E")]
			[Address(RVA = "0xD3451C", Offset = "0xD3451C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ResultDictionary>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CResultDictionary_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000047")]
		public virtual string RawResult
		{
			[CompilerGenerated]
			[Token(Token = "0x600010F")]
			[Address(RVA = "0xD34524", Offset = "0xD34524", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RawResult>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RawResult;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000110")]
			[Address(RVA = "0xD3452C", Offset = "0xD3452C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RawResult>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CRawResult_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000048")]
		public virtual bool Cancelled
		{
			[CompilerGenerated]
			[Token(Token = "0x6000111")]
			[Address(RVA = "0xD34534", Offset = "0xD34534", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Cancelled>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Cancelled;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000112")]
			[Address(RVA = "0xD3453C", Offset = "0xD3453C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Cancelled>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected internal set
			{
				_003CCancelled_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000049")]
		public virtual string CallbackId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000113")]
			[Address(RVA = "0xD34548", Offset = "0xD34548", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CallbackId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CallbackId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000114")]
			[Address(RVA = "0xD34550", Offset = "0xD34550", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CallbackId>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CCallbackId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700004A")]
		[field: Token(Token = "0x400005D")]
		[field: FieldOffset(Offset = "0x38")]
		protected long? CanvasErrorCode
		{
			[Token(Token = "0x6000115")]
			[Address(RVA = "0xD34558", Offset = "0xD34558", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CanvasErrorCode>k__BackingField;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000116")]
			[Address(RVA = "0xD34564", Offset = "0xD34564", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CanvasErrorCode>k__BackingField = value;\n\t*([this @ X0 (Facebook.Unity.ResultBase)+40]) = methodInfo;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0xD1BC48", Offset = "0xD1BC48", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv21 = Facebook.Unity.ResultBase::GetErrorValue(result.<ResultDictionary>k__BackingField);\n\tv41 = Facebook.Unity.ResultBase::GetCancelledValue(result.<ResultDictionary>k__BackingField);\n\tv45 = Facebook.Unity.ResultBase::GetCallbackId(result.<ResultDictionary>k__BackingField);\n\tFacebook.Unity.ResultBase::Init(this, result, v21, v41, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal ResultBase(ResultContainer result)
		{
			string errorValue = GetErrorValue(result.ResultDictionary);
			bool cancelledValue = GetCancelledValue(result.ResultDictionary);
			string callbackId = GetCallbackId(result.ResultDictionary);
			Init(result, errorValue, cancelledValue, callbackId);
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0xD30384", Offset = "0xD30384", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tFacebook.Unity.ResultBase::Init(this, result, error, cancelled, 0);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal ResultBase(ResultContainer result, string error, bool cancelled)
		{
			Init(result, error, cancelled, null);
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0xD1BED0", Offset = "0xD1BED0", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EBC988]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C94]) = v44;\nL_0019:\n\tv48 = System.Object::ToString(this);\n\tv52 = System.Object::GetType(this);\n\tv57 = System.Reflection.MemberInfo::get_Name(v52);\n\tv63 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v63);\n\tv79 = Facebook.Unity.ResultBase::get_Error(this);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v63, \"Error\", v79);\n\tv127 = Facebook.Unity.ResultBase::get_RawResult(this);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v63, \"RawResult\", v127);\n\tv137 = Facebook.Unity.ResultBase::get_Cancelled(this);\n\tv141 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(&v137 @ X0_v20 (System.Boolean), 0, v127);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v63, \"Cancelled\", v141);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(v48, v57, v63);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_007b: Expected O, but got I4
			string baseString = base.ToString();
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string error = Error;
			dictionary.Add("Error", error);
			string rawResult = RawResult;
			dictionary.Add("RawResult", rawResult);
			bool cancelled = Cancelled;
			((Dictionary<string, string>)cancelled).Add(null, rawResult);
			string value = default(string);
			dictionary.Add("Cancelled", value);
			return Utilities.FormatToString(baseString, name, dictionary);
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0xD34340", Offset = "0xD34340", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = *([1ED7270]);\n\tv35 = *([v34 @ X8_v25]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, result, error, cancelled, callbackId, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023C95]) = v50;\nL_0024:\n\tv59 = Facebook.Unity.ResultBase::set_RawResult(this, result.<RawResult>k__BackingField);\n\tv65 = Facebook.Unity.ResultBase::set_ResultDictionary(this, result.<ResultDictionary>k__BackingField);\n\tv71 = Facebook.Unity.ResultBase::set_Cancelled(this, cancelled);\n\tv77 = Facebook.Unity.ResultBase::set_Error(this, error);\n\tv83 = Facebook.Unity.ResultBase::set_CallbackId(this, callbackId);\n\tv88 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv89 = v88 == 0;\n\tif (v89) goto L_0092;\n\tv96 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv105 = Facebook.Unity.Utilities::TryGetValue(v96, \"error_code\", &v102 @ stack_-48_v3 (System.Int64));\n\tv170 = v105 == 0;\n\tif (v170) goto L_0077;\n\tv204 = 0;\n\tv207 = 0x115C698(&v204 @ stack_-60_v3 (System.Nullable`1<System.Int64>), v102, Il2CppMethodInfo, Il2CppMethodInfo, callbackId, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tthis.<CanvasErrorCode>k__BackingField = 0;\n\t*([this @ X0 (Facebook.Unity.ResultBase)+40]) = 0;\n\tv208 = v102 != 0x1069;\n\tif (v208) goto L_0077;\n\tv225 = Facebook.Unity.ResultBase::set_Cancelled(this, 1);\nL_0077:\n\tv233 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv155 = Facebook.Unity.Utilities::TryGetValue(v233, \"error_message\", &v107 @ stack_-50_v3 (System.String));\n\tv157 = v155 == 0;\n\tif (v157) goto L_0092;\n\tv154 = Facebook.Unity.ResultBase::set_Error(this, v107);\nL_0092:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void Init(ResultContainer result, string error, bool cancelled, string callbackId)
		{
			RawResult = result.RawResult;
			ResultDictionary = result.ResultDictionary;
			Cancelled = cancelled;
			Error = error;
			CallbackId = callbackId;
			IDictionary<string, object> resultDictionary = ResultDictionary;
			if (resultDictionary == null)
			{
				return;
			}
			IDictionary<string, object> resultDictionary2 = ResultDictionary;
			if (resultDictionary2.TryGetValue<long>("error_code", out var value))
			{
				long? num = null;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115C698 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xA8)");
				CanvasErrorCode = null;
				_ = 0;
				if (value == 4201)
				{
					Cancelled = true;
				}
			}
			IDictionary<string, object> resultDictionary3 = ResultDictionary;
			if (resultDictionary3.TryGetValue<string>("error_message", out var value2))
			{
				Error = value2;
			}
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0xD34010", Offset = "0xD34010", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDF730]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C96]) = v38;\nL_0014:\n\tv40 = result == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv50 = Facebook.Unity.Utilities::TryGetValue(result, \"error\", &v46 @ stack_-28_v3 (System.String));\n\tv55 = v50 == 0;\n\tv58 = ~v55;\n\tv59 = ~v58;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\tgoto L_0033;\nL_0033:\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetErrorValue(IDictionary<string, object> result)
		{
			if (result != null)
			{
				if (result.TryGetValue<string>("error", out var value))
				{
					return value;
				}
				return null;
			}
			return null;
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0xD34098", Offset = "0xD34098", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = &v5 @ X29;\n\tgoto L_0014;\n\tv17 = *([1EBF568]);\n\tv18 = *([v17 @ X8_v41]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([2023C97]) = v37;\nL_0014:\n\t*([v5 @ X29-18]) = 0;\n\t*([v5 @ X29-1C]) = 0;\n\t*([v5 @ X29-28]) = 0;\n\tv38 = result == 0;\n\tif (v38) goto L_FFFFFFFF;\n\tv40 = result->klass;\n\tv47 = *([v40 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v47) goto L_0040;\n\tv235 = *([v40 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_002B:\n\tv241 = *([v235 @ X11_v7-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v241) goto L_0043;\n\tv236 = v236 + 1;\n\tv287 = v236 < *([v40 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv144 = ~v287;\n\tv235 = v235 + 0x10;\n\tv128 = ~v144;\n\tif (v128) goto L_002B;\nL_0040:\n\tv294 = 0x8909C4(result, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 6, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0049;\nL_0043:\n\tv289 = *([v235 @ X11_v7]) + 6;\n\tv290 = v289 << 4;\n\tv291 = v40 + v290;\n\tv294 = v291 + 0x130;\nL_0049:\n\tv58 = &v5 @ X29 - 0x18;\n\t*([v294 @ X0_v6])(v110, result, \"cancelled\", v58, *([v294 @ X0_v6+8]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv297 = v110 & 1;\n\tv113 = v297 == 0;\n\tif (v113) goto L_FFFFFFFF;\n\tv209 = &v299 @ stack_-50;\n\t// 86 IsInst v304 @ X0_v10, typeof(System.Nullable`1<System.Boolean>), [v5 @ X29-18]\n\tv206 = v304 == 0;\n\tif (v206) goto L_006B;\n\tv320 = ~v320_asT;\n\tif (v320) goto L_00DA;\nL_006B:\n\tv330 = 0x8D82B0(v304, System.Boolean, &v299 @ stack_-50, *([v294 @ X0_v6+8]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv346 = *([v209 @ X19_v5]) < 0x100;\n\tv190 = ~v346;\n\t*([v5 @ X29-1C]) = *([v209 @ X19_v5]);\n\tif (v190) goto L_00C6;\n\tv115 = *([v5 @ X29-18]);\n\tv347 = *([v5 @ X29-18]) == 0;\n\tif (v347) goto L_0089;\n\tv179 = *([v115 @ X19_v7 (System.String)]) == System.String;\n\tif (v179) goto L_00D0;\nL_0089:\n\tv120 = &v299 @ stack_-50;\n\t// 143 IsInst v342 @ X0_v17, typeof(System.Nullable`1<System.Int32>), [v5 @ X29-18]\n\tv343 = v342 == 0;\n\tif (v343) goto L_00A4;\n\tv331 = v331_asT == 0;\n\tif (v331) goto L_00DA;\nL_00A4:\n\tv109 = 0x8D82B0(v342, System.Int32, &v299 @ stack_-50, *([v294 @ X0_v6+8]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv105 = *([v120 @ X20_v7]) & 0xFF00000000;\n\t*([v5 @ X29-28]) = *([v120 @ X20_v7]);\n\tv112 = v105 == 0;\n\tif (v112) goto L_FFFFFFFF;\n\tv388 = &v5 @ X29 - 0x28;\n\tv389 = System.Nullable`1<System.Int32>::get_Value(v388);\n\tv177 = v389 == 0;\n\tv158 = ~v177;\n\tgoto L_00C3;\nL_00C3:\n\treturn v201;\nL_00C6:\n\tv349 = &v5 @ X29 - 0x1C;\n\tv201 = System.Nullable`1<System.Boolean>::get_Value(v349);\n\tgoto L_00C3;\nL_00D0:\n\tgoto L_00D8;\n\tv377 = *([v371 @ X0_v22+E0]);\n\tv378 = v377 == 0;\n\tv379 = ~v378;\n\tif (v379) goto L_00D8;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v371, v307, v156, v49, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00D8:\n\tv201 = System.Convert::ToBoolean(*([v5 @ X29-18]));\n\tgoto L_00C3;\nL_00DA:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool GetCancelledValue(IDictionary<string, object> result)
		{
			//IL_0015: Expected I, but got O
			//IL_03ae: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00f4: Expected O, but got I
			//IL_0103: Expected O, but got I
			//IL_009c: Expected O, but got I
			//IL_0307: Expected O, but got I
			//IL_014f: Expected I4, but got O
			//IL_01b4: Expected O, but got I
			//IL_0346: Expected I4, but got O
			//IL_0219: Expected O, but got I
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Expected I4, but got Unknown
			//IL_0247: Expected I4, but got O
			//IL_02b6: Expected O, but got I
			//IL_032f: Expected O, but got I
			object obj = obj;
			_ = 0;
			_ = 0;
			_ = 0;
			if (result == null)
			{
				goto IL_02ea;
			}
			IntPtr intPtr = (IntPtr)result;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj2 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b5;
			}
			object obj3 = obj2 + 6;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num3;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_039f;
			IL_039f:
			object obj6 = (long)(IntPtr)obj - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v294 @ X0_v6] (should have been resolved before IL gen)");
			object obj7 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
			{
				object obj9 = default(object);
				object obj8 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X29-18]");
				object obj10 = ((((object)0) is bool?) ? ((object)0) : null);
				if (obj10 == null || (int)((obj10 is bool) ? obj10 : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D82B0");
					if ((long)(IntPtr)obj8 >= 256L)
					{
						bool? flag3 = (bool?)(object)((long)(IntPtr)obj - 28L);
						return ((bool?*)flag3)->Value;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X29-18]");
					string text = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X29-18]");
					if ((IntPtr)0 != (IntPtr)0 && (object)text.GetType() == typeof(string))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X29-18]");
						return Convert.ToBoolean((string)0);
					}
					object obj11 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X29-18]");
					object obj12 = ((((object)0) is int?) ? ((object)0) : null);
					if (obj12 == null || (int)((obj12 is int) ? obj12 : null) != 0)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D82B0");
						if ((int)(obj11 & 0xFF00000000L) != 0)
						{
							int? num4 = (int?)(object)((long)(IntPtr)obj - 40L);
							int value = ((int?*)num4)->Value;
							bool flag4 = value == 0;
							return !flag4;
						}
						goto IL_02ea;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}
			goto IL_02ea;
			IL_02ea:
			return false;
			IL_00b5:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_039f;
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0xD342B8", Offset = "0xD342B8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDE458]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C98]) = v38;\nL_0014:\n\tv40 = result == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv50 = Facebook.Unity.Utilities::TryGetValue(result, \"callback_id\", &v46 @ stack_-28_v3 (System.String));\n\tv55 = v50 == 0;\n\tv58 = ~v55;\n\tv59 = ~v58;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\tgoto L_0033;\nL_0033:\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetCallbackId(IDictionary<string, object> result)
		{
			if (result != null)
			{
				if (result.TryGetValue<string>("callback_id", out var value))
				{
					return value;
				}
				return null;
			}
			return null;
		}
	}
}
