using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B9")]
	public class TweenerCore<T1, T2, TPlugOptions> : Tweener where TPlugOptions : struct, IPlugOptions
	{
		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x0")]
		public T2 startValue;

		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x0")]
		public T2 endValue;

		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x0")]
		public T2 changeValue;

		[Token(Token = "0x4000251")]
		[FieldOffset(Offset = "0x0")]
		public TPlugOptions plugOptions;

		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x0")]
		public DOGetter<T1> getter;

		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x0")]
		public DOSetter<T1> setter;

		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x0")]
		internal ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin;

		[Token(Token = "0x4000255")]
		private const string _TxtCantChangeSequencedValues = "You cannot change the values of a tween contained inside a Sequence";

		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x0")]
		internal Type _colorType;

		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x0")]
		internal Type _color32Type;

		[Token(Token = "0x6000460")]
		[Address(RVA = "0x11C8690", Offset = "0x11C8690", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv26 = UnityEngine.Color32;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv54 = UnityEngine.Color;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv62 = System.Type;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A361A9]) = v45;\nL_0025:\n\tgoto L_0029;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0029:\n\tv60 = System.Type::GetTypeFromHandle(UnityEngine.Color);\n\t*([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]) = v60;\n\tv65 = System.Type::GetTypeFromHandle(UnityEngine.Color32);\n\t*([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]) = v65;\n\tDG.Tweening.Tweener::.ctor(this);\n\tv72 = System.Type::GetTypeFromHandle(Il2CppClass<T1>);\n\tthis.typeofT1 = v72;\n\tv77 = System.Type::GetTypeFromHandle(Il2CppClass<T2>);\n\tthis.typeofT2 = v77;\n\tv82 = System.Type::GetTypeFromHandle(Il2CppClass<TPlugOptions>);\n\tv83 = this->klass;\n\tthis.typeofTPlugOptions = v82;\n\tthis.tweenType = 0;\n\tv85 = this->klass->vtable[4];\n\tv86 = this->klass->vtable[4];\n\t// 80 IndirectJump v85 @ X2_v1, this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v86 @ X1_v7, v85 @ X2_v1, v29 @ X3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal TweenerCore()
		{
			//IL_0083: Expected I, but got O
			//IL_00b1: Expected O, but got I
			//IL_00c1: Expected O, but got I
			base._002Ector();
			while (true)
			{
				Type typeFromHandle = typeof(Color);
				Type typeFromHandle2 = typeof(Color32);
				Type typeFromHandle3 = typeof(T1);
				this.typeofT1 = typeFromHandle3;
				Type typeFromHandle4 = typeof(T2);
				this.typeofT2 = typeFromHandle4;
				Type typeFromHandle5 = typeof(TPlugOptions);
				nint num = (nint)this;
				this.typeofTPlugOptions = typeFromHandle5;
				this.tweenType = default(TweenType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v10 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+178]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v10 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+180]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v85 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000461")]
		[Address(RVA = "0x11C879C", Offset = "0x11C879C", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv26 = UnityEngine.Color32;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = UnityEngine.Color;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = System.String[];\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv190 = \"You cannot change the values of a tween contained inside a Sequence\";\n\tv191 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv305 = \", should be \";\n\tv306 = \"il2cpp_codegen_initialize_runtime_metadata\"(v305, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv368 = \")\";\n\tv369 = \"il2cpp_codegen_initialize_runtime_metadata\"(v368, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv389 = \"ChangeStartValue: incorrect newStartValue type (is \";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v389, newStartValue, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A361AA]) = v43;\nL_0029:\n\tv45 = ~this.isSequenced;\n\tif (v45) goto L_0033;\n\tgoto L_00E0;\nL_0033:\n\tv102 = System.Object::GetType(newStartValue);\n\tv252 = v102 == this.typeofT2;\n\tif (v252) goto L_0076;\n\tv130 = this.typeofT2 != *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]);\n\tif (v130) goto L_005B;\n\tv375 = v102 == *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]);\n\tif (v375) goto L_FFFFFFFF;\nL_005B:\n\t// 91 NewArr v174 @ X0_v20 (System.String[]), typeof(System.String[]), 5\n\tv174[0] = \"ChangeStartValue: incorrect newStartValue type (is \";\n\tv420 = v102 == 0;\n\tif (v420) goto L_FFFFFFFF;\n\tv450 = System.Type::ToString(v102);\n\tgoto L_00B2;\nL_0076:\n\tgoto L_FFFFFFFF;\n\tv383 = v363;\n\tv384 = 0xB348B0(v383, v363, methodInfo, v28, v29, v30, v31, v32, newDuration, v33, v34, v35, v36, v37, v38, v39);\n\tv385 = v384;\n\tv268 = v268_asT == 0;\n\tif (v268) goto L_0144;\n\tv395 = \"il2cpp_vm_object_unbox\"(newStartValue, Il2CppClass<T2>, methodInfo, v28, v29, v30, v31, v32, newDuration, v125, v34, v35, v36, v37, v38, v39);\n\treturnVal3 = DG.Tweening.Tweener::DoChangeStartValue /* +1 sharing this address */(this, Il2CppMethodInfo, *([v395 @ X0_v14]), methodInfo);\n\treturn returnVal3;\nL_00B2:\n\tv174[1] = v450;\n\tv174[2] = \", should be \";\n\tv451 = this.typeofT2;\n\tv91 = this.typeofT2 == 0;\n\tif (v91) goto L_00D5;\n\tv486 = System.Type::ToString(this.typeofT2);\nL_00D5:\n\tv174[3] = v451;\n\tv174[4] = \")\";\n\tv88 = System.String::Concat(v174);\nL_00E0:\n\tDG.Tweening.Core.Debugger::LogError(v88, this);\nL_00E9:\n\treturn v233;\n\tv131 = v131_asT == 0;\n\tif (v131) goto L_0144;\n\tv397 = \"il2cpp_vm_object_unbox\"(newStartValue, UnityEngine.Color32, methodInfo, v28, v29, v30, v31, v32, newDuration, v125, v34, v35, v36, v37, v38, v39);\n\tv407 = *([v397 @ X0_v33]) & 0xFF;\n\tv409 = *([v397 @ X0_v33]) >> 8;\n\tv117 = v409 & 0xFF;\n\tv411 = *([v397 @ X0_v33]) >> 0x10;\n\tv135 = v411 & 0xFF;\n\tv412 = *([v397 @ X0_v33]) >> 0x18;\n\tv125 = v407 / 0x437F0000;\n\tv123 = v117 / 0x437F0000;\n\tv121 = v135 / 0x437F0000;\n\tv127 = v412 / 0x437F0000;\n\t// 278 Box v416 @ X0_v35, typeof(UnityEngine.Color), &v125 @ V1_v6 (System.Int32)\n\tgoto L_FFFFFFFF;\n\tv467 = v456;\n\tv468 = 0xB348B0(v467, v456, methodInfo, v28, v29, v30, v31, v32, v127, v125, v123, v121, v119, v37, v38, v39);\n\tv469 = v468;\n\tv209 = v209_asT == 0;\n\tif (v209) goto L_0144;\n\tv476 = \"il2cpp_vm_object_unbox\"(v416, Il2CppClass<T2>, methodInfo, v28, v29, v30, v31, v32, v127, v125, v123, v121, v412, v37, v38, v39);\n\tv231 = DG.Tweening.Tweener::DoChangeStartValue /* +1 sharing this address */(this, Il2CppMethodInfo, *([v476 @ X0_v38]), methodInfo);\n\tgoto L_00E9;\n\tv173 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_0144:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 246 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeStartValue(object newStartValue, float newDuration = -1f)
		{
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Expected I4, but got Unknown
			//IL_0221: Expected I4, but got O
			//IL_023d: Expected I4, but got O
			//IL_0259: Expected I4, but got O
			//IL_029a: Expected O, but got I4
			string message;
			if (this.isSequenced)
			{
				message = "You cannot change the values of a tween contained inside a Sequence";
			}
			else
			{
				Type type = newStartValue.GetType();
				if ((object)type == this.typeofT2)
				{
					T2 val = (T2)((newStartValue is T2) ? newStartValue : null);
					if (val != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CC13E0 (DG.Tweening.Tweener::DoChangeStartValue, and 1 more at this address)");
						Tweener result = default(Tweener);
						return result;
					}
					goto IL_02f8;
				}
				Type type2 = this.typeofT2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]");
				if ((object)type2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]");
					if ((object)type == null)
					{
						Color32 color = (Color32)((newStartValue is Color32) ? newStartValue : null);
						if ((object)color != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							int num = obj & 0xFF;
							int num2 = obj >> 8;
							int num3 = num2 & 0xFF;
							int num4 = obj >> 16;
							int num5 = num4 & 0xFF;
							int num6 = obj >> 24;
							int num7 = num / 1132396544;
							int num8 = num3 / 1132396544;
							int num9 = num5 / 1132396544;
							int num10 = num6 / 1132396544;
							object obj2 = (Color)num7;
							T2 val2 = (T2)((obj2 is T2) ? obj2 : null);
							if (val2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CC13E0 (DG.Tweening.Tweener::DoChangeStartValue, and 1 more at this address)");
								TweenerCore<T1, T2, TPlugOptions> result2 = default(TweenerCore<T1, T2, TPlugOptions>);
								return result2;
							}
						}
						goto IL_02f8;
					}
				}
				string[] array = new string[5] { "ChangeStartValue: incorrect newStartValue type (is ", null, null, null, null };
				string text = type?.ToString();
				array[1] = text;
				array[2] = ", should be ";
				Type type3 = this.typeofT2;
				if ((object)this.typeofT2 != null)
				{
					string text2 = this.typeofT2.ToString();
					type3 = (Type)(object)text2;
				}
				array[3] = (string)(object)type3;
				array[4] = ")";
				message = string.Concat(array);
			}
			Debugger.LogError(message, this);
			return this;
			IL_02f8:
			return (Tweener)(object)new InvalidCastException();
		}

		[Token(Token = "0x6000462")]
		[Address(RVA = "0x11C8ACC", Offset = "0x11C8ACC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this->klass;\n\tv8 = this->klass->vtable[10];\n\tv9 = this->klass->vtable[10];\n\t// 11 IndirectJump v8 @ X4_v1, this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), newEndValue @ X1 (System.Object), snapStartValue @ X2 (System.Boolean), v9 @ X3_v1, v8 @ X4_v1, v12 @ X5, v13 @ X6, v14 @ X7, -1f, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeEndValue(object newEndValue, bool snapStartValue)
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v1 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+1D8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v1 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+1E0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X4_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000463")]
		[Address(RVA = "0x11C8AF0", Offset = "0x11C8AF0", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv30 = UnityEngine.Color32;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = UnityEngine.Color;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = System.String[];\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv193 = \"You cannot change the values of a tween contained inside a Sequence\";\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv310 = \", should be \";\n\tv311 = \"il2cpp_codegen_initialize_runtime_metadata\"(v310, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv376 = \")\";\n\tv377 = \"il2cpp_codegen_initialize_runtime_metadata\"(v376, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv397 = \"ChangeEndValue: incorrect newEndValue type (is \";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v397, newEndValue, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A361AB]) = v46;\nL_002B:\n\tv48 = ~this.isSequenced;\n\tif (v48) goto L_0035;\n\tgoto L_00E4;\nL_0035:\n\tv105 = System.Object::GetType(newEndValue);\n\tv257 = v105 == this.typeofT2;\n\tif (v257) goto L_0078;\n\tv133 = this.typeofT2 != *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]);\n\tif (v133) goto L_005D;\n\tv383 = v105 == *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]);\n\tif (v383) goto L_FFFFFFFF;\nL_005D:\n\t// 93 NewArr v177 @ X0_v20 (System.String[]), typeof(System.String[]), 5\n\tv177[0] = \"ChangeEndValue: incorrect newEndValue type (is \";\n\tv428 = v105 == 0;\n\tif (v428) goto L_FFFFFFFF;\n\tv458 = System.Type::ToString(v105);\n\tgoto L_00B6;\nL_0078:\n\tgoto L_FFFFFFFF;\n\tv391 = v371;\n\tv392 = 0xB348B0(v391, v371, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v36, v37, v38, v39, v40, v41, v42);\n\tv393 = v392;\n\tv273 = v273_asT == 0;\n\tif (v273) goto L_014A;\n\tv403 = \"il2cpp_vm_object_unbox\"(newEndValue, Il2CppClass<T2>, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v128, v37, v38, v39, v40, v41, v42);\n\treturnVal3 = DG.Tweening.Tweener::DoChangeEndValue /* +1 sharing this address */(this, snapStartValue, *([v403 @ X0_v14]), Il2CppMethodInfo, methodInfo);\n\treturn returnVal3;\nL_00B6:\n\tv177[1] = v458;\n\tv177[2] = \", should be \";\n\tv459 = this.typeofT2;\n\tv94 = this.typeofT2 == 0;\n\tif (v94) goto L_00D9;\n\tv494 = System.Type::ToString(this.typeofT2);\nL_00D9:\n\tv177[3] = v459;\n\tv177[4] = \")\";\n\tv91 = System.String::Concat(v177);\nL_00E4:\n\tDG.Tweening.Core.Debugger::LogError(v91, this);\nL_00EE:\n\treturn v237;\n\tv134 = v134_asT == 0;\n\tif (v134) goto L_014A;\n\tv405 = \"il2cpp_vm_object_unbox\"(newEndValue, UnityEngine.Color32, snapStartValue, methodInfo, v32, v33, v34, v35, newDuration, v128, v37, v38, v39, v40, v41, v42);\n\tv415 = *([v405 @ X0_v33]) & 0xFF;\n\tv417 = *([v405 @ X0_v33]) >> 8;\n\tv120 = v417 & 0xFF;\n\tv419 = *([v405 @ X0_v33]) >> 0x10;\n\tv138 = v419 & 0xFF;\n\tv420 = *([v405 @ X0_v33]) >> 0x18;\n\tv128 = v415 / 0x437F0000;\n\tv126 = v120 / 0x437F0000;\n\tv124 = v138 / 0x437F0000;\n\tv130 = v420 / 0x437F0000;\n\t// 283 Box v424 @ X0_v35, typeof(UnityEngine.Color), &v128 @ V1_v6 (System.Int32)\n\tgoto L_FFFFFFFF;\n\tv475 = v464;\n\tv476 = 0xB348B0(v475, v464, snapStartValue, methodInfo, v32, v33, v34, v35, v130, v128, v126, v124, v122, v40, v41, v42);\n\tv477 = v476;\n\tv213 = v213_asT == 0;\n\tif (v213) goto L_014A;\n\tv484 = \"il2cpp_vm_object_unbox\"(v424, Il2CppClass<T2>, snapStartValue, methodInfo, v32, v33, v34, v35, v130, v128, v126, v124, v420, v40, v41, v42);\n\tv235 = DG.Tweening.Tweener::DoChangeEndValue /* +1 sharing this address */(this, snapStartValue, *([v484 @ X0_v38]), Il2CppMethodInfo, methodInfo);\n\tgoto L_00EE;\n\tv176 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_014A:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 252 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeEndValue(object newEndValue, float newDuration = -1f, bool snapStartValue = false)
		{
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Expected I4, but got Unknown
			//IL_0221: Expected I4, but got O
			//IL_023d: Expected I4, but got O
			//IL_0259: Expected I4, but got O
			//IL_029a: Expected O, but got I4
			string message;
			if (this.isSequenced)
			{
				message = "You cannot change the values of a tween contained inside a Sequence";
			}
			else
			{
				Type type = newEndValue.GetType();
				if ((object)type == this.typeofT2)
				{
					T2 val = (T2)((newEndValue is T2) ? newEndValue : null);
					if (val != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CBD81C (DG.Tweening.Tweener::DoChangeEndValue, and 1 more at this address)");
						Tweener result = default(Tweener);
						return result;
					}
					goto IL_02f8;
				}
				Type type2 = this.typeofT2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]");
				if ((object)type2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]");
					if ((object)type == null)
					{
						Color32 color = (Color32)((newEndValue is Color32) ? newEndValue : null);
						if ((object)color != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							int num = obj & 0xFF;
							int num2 = obj >> 8;
							int num3 = num2 & 0xFF;
							int num4 = obj >> 16;
							int num5 = num4 & 0xFF;
							int num6 = obj >> 24;
							int num7 = num / 1132396544;
							int num8 = num3 / 1132396544;
							int num9 = num5 / 1132396544;
							int num10 = num6 / 1132396544;
							object obj2 = (Color)num7;
							T2 val2 = (T2)((obj2 is T2) ? obj2 : null);
							if (val2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CBD81C (DG.Tweening.Tweener::DoChangeEndValue, and 1 more at this address)");
								TweenerCore<T1, T2, TPlugOptions> result2 = default(TweenerCore<T1, T2, TPlugOptions>);
								return result2;
							}
						}
						goto IL_02f8;
					}
				}
				string[] array = new string[5] { "ChangeEndValue: incorrect newEndValue type (is ", null, null, null, null };
				string text = type?.ToString();
				array[1] = text;
				array[2] = ", should be ";
				Type type3 = this.typeofT2;
				if ((object)this.typeofT2 != null)
				{
					string text2 = this.typeofT2.ToString();
					type3 = (Type)(object)text2;
				}
				array[3] = (string)(object)type3;
				array[4] = ")";
				message = string.Concat(array);
			}
			Debugger.LogError(message, this);
			return this;
			IL_02f8:
			return (Tweener)(object)new InvalidCastException();
		}

		[Token(Token = "0x6000464")]
		[Address(RVA = "0x11C8E2C", Offset = "0x11C8E2C", Length = "0x4DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv40 = UnityEngine.Color32;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = UnityEngine.Color;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv67 = System.String[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv268 = \"You cannot change the values of a tween contained inside a Sequence\";\n\tv269 = \"il2cpp_codegen_initialize_runtime_metadata\"(v268, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv408 = \", should be \";\n\tv409 = \"il2cpp_codegen_initialize_runtime_metadata\"(v408, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv549 = \"ChangeValues: incorrect value type (is \";\n\tv550 = \"il2cpp_codegen_initialize_runtime_metadata\"(v549, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv609 = \")\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v609, newStartValue, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A361AC]) = v56;\nL_0030:\n\tv58 = ~this.isSequenced;\n\tif (v58) goto L_003A;\n\tgoto L_00F7;\nL_003A:\n\tv793 = System.Object::GetType(newStartValue);\n\tv393 = System.Object::GetType(newEndValue);\n\tv603 = v793 == this.typeofT2;\n\tif (v603) goto L_007E;\n\tv168 = this.typeofT2 != *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]);\n\tif (v168) goto L_006A;\n\tv631 = v793 == *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]);\n\tif (v631) goto L_007E;\nL_006A:\n\t// 106 NewArr v241 @ X0_v66 (System.String[]), typeof(System.String[]), 5\n\tv241[0] = \"ChangeValues: incorrect value type (is \";\n\tv692 = v793 == 0;\n\tif (v692) goto L_FFFFFFFF;\n\tgoto L_00B0;\nL_007E:\n\tv642 = v393 == this.typeofT2;\n\tif (v642) goto L_010C;\n\tv169 = this.typeofT2 != *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]);\n\tif (v169) goto L_009F;\n\tv668 = v393 == *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]);\n\tif (v668) goto L_FFFFFFFF;\nL_009F:\n\t// 159 NewArr v242 @ X0_v43 (System.String[]), typeof(System.String[]), 5\n\tv242[0] = \"ChangeValues: incorrect value type (is \";\n\tv755 = v393 == 0;\n\tif (v755) goto L_FFFFFFFF;\nL_00B0:\n\tv722 = System.Type::ToString(v793);\n\tgoto L_00C9;\nL_00C9:\n\tv111[1] = v722;\n\tv111[2] = \", should be \";\n\tv723 = this.typeofT2;\n\tv109 = this.typeofT2 == 0;\n\tif (v109) goto L_00EC;\n\tv842 = System.Type::ToString(this.typeofT2);\nL_00EC:\n\tv111[3] = v723;\n\tv111[4] = \")\";\n\tv106 = System.String::Concat(v111);\nL_00F7:\n\tDG.Tweening.Core.Debugger::LogError(v106, this);\nL_0106:\n\treturn returnVal1;\nL_010C:\n\tgoto L_FFFFFFFF;\n\tv676 = v659;\n\tv677 = 0xB348B0(v676, v659, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv678 = v677;\n\tv359 = v359_asT == 0;\n\tif (v359) goto L_01F7;\n\tv688 = \"il2cpp_vm_object_unbox\"(newStartValue, Il2CppClass<T2>, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v509, v47, v48, v49, v50, v51, v52);\n\tgoto L_FFFFFFFF;\n\tv776 = v734;\n\tv777 = 0xB348B0(v776, v734, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v46, v47, v48, v49, v50, v51, v52);\n\tv778 = v777;\n\tv447 = v447_asT == 0;\n\tif (v447) goto L_01F9;\n\tv817 = \"il2cpp_vm_object_unbox\"(newEndValue, Il2CppClass<T2>, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v509, v47, v48, v49, v50, v51, v52);\n\treturnVal1 = DG.Tweening.Tweener::DoChangeValues /* +1 sharing this address */(this, Il2CppMethodInfo, newEndValue, *([v688 @ X0_v32]), methodInfo);\n\tgoto L_0106;\n\tv358 = v358_asT == 0;\n\tif (v358) goto L_01F7;\n\tv731 = \"il2cpp_vm_object_unbox\"(newStartValue, UnityEngine.Color32, newEndValue, methodInfo, v42, v43, v44, v45, newDuration, v509, v47, v48, v49, v50, v51, v52);\n\tv763 = *([v731 @ X0_v46]) & 0xFF;\n\tv766 = *([v731 @ X0_v46]) >> 8;\n\tv767 = v766 & 0xFF;\n\tv769 = *([v731 @ X0_v46]) >> 0x10;\n\tv770 = v769 & 0xFF;\n\tv771 = *([v731 @ X0_v46]) >> 0x18;\n\tv509 = v763 / 0x437F0000;\n\tv507 = v767 / 0x437F0000;\n\tv505 = v770 / 0x437F0000;\n\tv511 = v771 / 0x437F0000;\n\t// 378 Box v535 @ X0_v48, typeof(UnityEngine.Color), &v509 @ V1_v8 (System.Int32)\n\tv170 = v170_asT == 0;\n\tif (v170) goto L_01F9;\n\tv820 = \"il2cpp_vm_object_unbox\"(newEndValue, UnityEngine.Color32, newEndValue, methodInfo, v42, v43, v44, v45, v511, v509, v507, v505, v771, v50, v51, v52);\n\tv231 = *([v820 @ X0_v50]) & 0xFF;\n\tv831 = *([v820 @ X0_v50]) >> 8;\n\tv176 = v831 & 0xFF;\n\tv832 = *([v820 @ X0_v50]) >> 0x10;\n\tv135 = v832 & 0xFF;\n\tv833 = *([v820 @ X0_v50]) >> 0x18;\n\tv509 = v231 / 0x437F0000;\n\tv151 = v176 / 0x437F0000;\n\tv149 = v135 / 0x437F0000;\n\tv155 = v833 / 0x437F0000;\n\t// 420 Box v838 @ X0_v52, typeof(UnityEngine.Color), &v509 @ V1_v8 (System.Int32)\n\tgoto L_FFFFFFFF;\n\tv853 = v848;\n\tv854 = 0xB348B0(v853, v848, newEndValue, methodInfo, v42, v43, v44, v45, v155, v153, v151, v149, v157, v50, v51, v52);\n\tv855 = v854;\n\tv171 = v171_asT == 0;\n\tif (v171) goto L_01F7;\n\tv862 = \"il2cpp_vm_object_unbox\"(v535, Il2CppClass<T2>, newEndValue, methodInfo, v42, v43, v44, v45, v155, v509, v151, v149, v833, v50, v51, v52);\n\tgoto L_FFFFFFFF;\n\tv869 = v865;\n\tv870 = 0xB348B0(v869, v865, newEndValue, methodInfo, v42, v43, v44, v45, v155, v153, v151, v149, v157, v50, v51, v52);\n\tv871 = v870;\n\tv304 = v304_asT == 0;\n\tif (v304) goto L_01F9;\n\tv875 = \"il2cpp_vm_object_unbox\"(v838, Il2CppClass<T2>, newEndValue, methodInfo, v42, v43, v44, v45, v155, v509, v151, v149, v833, v50, v51, v52);\n\tv328 = DG.Tweening.Tweener::DoChangeValues /* +1 sharing this address */(this, Il2CppMethodInfo, newEndValue, *([v862 @ X0_v55]), methodInfo);\n\tgoto L_FFFFFFFF;\n\tv240 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_01F7:\n\tthrow System.InvalidCastException;\nL_01F9:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 386 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1f)
		{
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Expected I4, but got Unknown
			//IL_0318: Expected I4, but got O
			//IL_0334: Expected I4, but got O
			//IL_0350: Expected I4, but got O
			//IL_0391: Expected O, but got I4
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Expected I4, but got Unknown
			//IL_03ea: Expected I4, but got O
			//IL_0406: Expected I4, but got O
			//IL_0422: Expected I4, but got O
			//IL_0463: Expected O, but got I4
			string message;
			if (this.isSequenced)
			{
				message = "You cannot change the values of a tween contained inside a Sequence";
				goto IL_0275;
			}
			Type type = newStartValue.GetType();
			Type type2 = newEndValue.GetType();
			if ((object)type == this.typeofT2)
			{
				goto IL_00f5;
			}
			Type type3 = this.typeofT2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]");
			if ((object)type3 == null)
			{
				Type type4 = type;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]");
				if ((object)type4 == null)
				{
					goto IL_00f5;
				}
			}
			string[] array = new string[5] { "ChangeValues: incorrect value type (is ", null, null, null, null };
			bool flag = (object)type == null;
			string[] array2 = array;
			if (flag)
			{
				goto IL_01c0;
			}
			array2 = array;
			goto IL_0529;
			IL_0529:
			string text = type.ToString();
			goto IL_01ca;
			IL_01c0:
			text = null;
			goto IL_01ca;
			IL_04fa:
			throw new InvalidCastException();
			IL_00f5:
			TweenerCore<T1, T2, TPlugOptions> result;
			if ((object)type2 != this.typeofT2)
			{
				Type type5 = this.typeofT2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]");
				if ((object)type5 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]");
					if ((object)type2 == null)
					{
						Color32 color = (Color32)((newStartValue is Color32) ? newStartValue : null);
						if ((object)color == null)
						{
							goto IL_04fa;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj = default(object);
						int num = obj & 0xFF;
						int num2 = obj >> 8;
						int num3 = num2 & 0xFF;
						int num4 = obj >> 16;
						int num5 = num4 & 0xFF;
						int num6 = obj >> 24;
						int num7 = num / 1132396544;
						int num8 = num3 / 1132396544;
						int num9 = num5 / 1132396544;
						int num10 = num6 / 1132396544;
						object obj2 = (Color)num7;
						Color32 color2 = (Color32)((newEndValue is Color32) ? newEndValue : null);
						if ((object)color2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj3 = default(object);
							int num11 = obj3 & 0xFF;
							int num12 = obj3 >> 8;
							int num13 = num12 & 0xFF;
							int num14 = obj3 >> 16;
							int num15 = num14 & 0xFF;
							int num16 = obj3 >> 24;
							num7 = num11 / 1132396544;
							int num17 = num13 / 1132396544;
							int num18 = num15 / 1132396544;
							int num19 = num16 / 1132396544;
							object obj4 = (Color)num7;
							T2 val = (T2)((obj2 is T2) ? obj2 : null);
							if (val == null)
							{
								goto IL_04fa;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							T2 val2 = (T2)((obj4 is T2) ? obj4 : null);
							if (val2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CC2628 (DG.Tweening.Tweener::DoChangeValues, and 1 more at this address)");
								TweenerCore<T1, T2, TPlugOptions> tweenerCore = default(TweenerCore<T1, T2, TPlugOptions>);
								result = tweenerCore;
								goto IL_0289;
							}
						}
						goto IL_0500;
					}
				}
				string[] array3 = new string[5] { "ChangeValues: incorrect value type (is ", null, null, null, null };
				bool flag2 = (object)type2 == null;
				array2 = array3;
				if (flag2)
				{
					goto IL_01c0;
				}
				type = type2;
				array2 = array3;
				goto IL_0529;
			}
			T2 val3 = (T2)((newStartValue is T2) ? newStartValue : null);
			if (val3 == null)
			{
				goto IL_04fa;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			T2 val4 = (T2)((newEndValue is T2) ? newEndValue : null);
			if (val4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CC2628 (DG.Tweening.Tweener::DoChangeValues, and 1 more at this address)");
				Tweener result2 = default(Tweener);
				return result2;
			}
			goto IL_0500;
			IL_01ca:
			array2[1] = text;
			array2[2] = ", should be ";
			Type type6 = this.typeofT2;
			if ((object)this.typeofT2 != null)
			{
				string text2 = this.typeofT2.ToString();
				type6 = (Type)(object)text2;
			}
			array2[3] = (string)(object)type6;
			array2[4] = ")";
			message = string.Concat(array2);
			goto IL_0275;
			IL_0275:
			Debugger.LogError(message, this);
			result = this;
			goto IL_0289;
			IL_0289:
			return result;
			IL_0500:
			return (Tweener)(object)new InvalidCastException();
		}

		[Token(Token = "0x6000465")]
		[Address(RVA = "0x11C9308", Offset = "0x11C9308", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = \"You cannot change the values of a tween contained inside a Sequence\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, newStartValue, methodInfo, v41, v42, v43, v44, v45, newDuration, v29, v27, v25, v23, v46, v47, v48);\n\tv51 = 1;\n\t*([1A361AD]) = v51;\nL_001D:\n\tv53 = ~this.isSequenced;\n\tif (v53) goto L_0031;\n\tDG.Tweening.Core.Debugger::LogError(\"You cannot change the values of a tween contained inside a Sequence\", this);\n\treturn this;\nL_0031:\n\tv59 = *([newStartValue @ X1 (T2)+20]);\n\tv63 = *([v59 @ X8_v4+C0]);\n\treturnVal2 = DG.Tweening.Tweener::DoChangeStartValue /* +1 sharing this address */(this, *([v63 @ X8_v5+30]), newDuration, methodInfo);\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeStartValue(T2 newStartValue, float newDuration = -1f)
		{
			//IL_0022: Expected O, but got I
			//IL_0032: Expected O, but got I
			if (this.isSequenced)
			{
				Debugger.LogError("You cannot change the values of a tween contained inside a Sequence", this);
				return this;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v4+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CC13E0 (DG.Tweening.Tweener::DoChangeStartValue, and 1 more at this address)");
			TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
			return result;
		}

		[Token(Token = "0x6000466")]
		[Address(RVA = "0x11C93D0", Offset = "0x11C93D0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = *([snapStartValue @ X2 (System.Boolean)+20]);\n\tv2 = newEndValue & 1;\n\tv5 = *([v0 @ X8_v1+C0]);\n\treturnVal1 = DG.Tweening.Core.TweenerCore`3::ChangeEndValue /* +1 sharing this address */(this, v2, v9, *([v5 @ X8_v2+48]), methodInfo);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeEndValue(T2 newEndValue, bool snapStartValue)
		{
			//IL_0010: Expected O, but got I
			//IL_002f: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [snapStartValue @ X2 (System.Boolean)+20]");
			object obj = 0;
			int num = (int)((nint)newEndValue & 1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @11CD3E8 (DG.Tweening.Core.TweenerCore`3::ChangeEndValue, and 1 more at this address)");
			TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
			return result;
		}

		[Token(Token = "0x6000467")]
		[Address(RVA = "0x11C93E8", Offset = "0x11C93E8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv42 = \"You cannot change the values of a tween contained inside a Sequence\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, newEndValue, snapStartValue, methodInfo, v45, v46, v47, v48, newDuration, v33, v31, v29, v27, v49, v50, v51);\n\tv54 = 1;\n\t*([1A361AE]) = v54;\nL_001F:\n\tv56 = ~this.isSequenced;\n\tif (v56) goto L_0034;\n\tDG.Tweening.Core.Debugger::LogError(\"You cannot change the values of a tween contained inside a Sequence\", this);\n\treturn this;\nL_0034:\n\tv62 = *([snapStartValue @ X2 (System.Boolean)+20]);\n\tv63 = newEndValue & 1;\n\tv66 = *([v62 @ X8_v4+C0]);\n\treturnVal2 = DG.Tweening.Tweener::DoChangeEndValue /* +1 sharing this address */(this, v63, newDuration, *([v66 @ X8_v5+38]), methodInfo);\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeEndValue(T2 newEndValue, float newDuration = -1f, bool snapStartValue = false)
		{
			//IL_0022: Expected O, but got I
			//IL_0041: Expected O, but got I
			if (this.isSequenced)
			{
				Debugger.LogError("You cannot change the values of a tween contained inside a Sequence", this);
				return this;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [snapStartValue @ X2 (System.Boolean)+20]");
			object obj = 0;
			int num = (int)((nint)newEndValue & 1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v4+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CBD81C (DG.Tweening.Tweener::DoChangeEndValue, and 1 more at this address)");
			TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
			return result;
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0x11C94C4", Offset = "0x11C94C4", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv36 = \"You cannot change the values of a tween contained inside a Sequence\";\n\tv51 = newDuration;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, newStartValue, newEndValue, methodInfo, v57, v58, v59, v60, newDuration, v50, v48, v46, v44, v42, v40, v38);\n\tv76 = v51;\n\tv91 = 1;\n\t*([1A361AF]) = v91;\nL_002E:\n\tv93 = ~this.isSequenced;\n\tif (v93) goto L_0045;\n\tDG.Tweening.Core.Debugger::LogError(\"You cannot change the values of a tween contained inside a Sequence\", this);\n\treturn this;\nL_0045:\n\tv99 = *([newStartValue @ X1 (T2)+20]);\n\tv105 = *([v99 @ X8_v4+C0]);\n\treturnVal2 = DG.Tweening.Tweener::DoChangeValues /* +1 sharing this address */(this, *([v105 @ X8_v5+40]), newEndValue, v75, methodInfo);\n\treturn returnVal2;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeValues(T2 newStartValue, T2 newEndValue, float newDuration = -1f)
		{
			//IL_0022: Expected O, but got I
			//IL_0032: Expected O, but got I
			if (this.isSequenced)
			{
				Debugger.LogError("You cannot change the values of a tween contained inside a Sequence", this);
				return this;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v4+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CC2628 (DG.Tweening.Tweener::DoChangeValues, and 1 more at this address)");
			TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
			return result;
		}

		[Token(Token = "0x6000469")]
		[Address(RVA = "0x11C95CC", Offset = "0x11C95CC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.Reflection.MemberInfo::IsDefined(this._color32Type, this, relative);\n\tthis.hasManuallySetStartValue = 1;\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override Tweener SetFrom(bool relative)
		{
			bool flag = _color32Type.IsDefined((Type)(object)this, relative);
			this.hasManuallySetStartValue = true;
			return this;
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0x11C9608", Offset = "0x11C9608", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.Type::get_MemberType(this._color32Type);\n\tthis.hasManuallySetStartValue = 1;\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Tweener SetFrom(T2 fromValue, bool setImmediately, bool relative)
		{
			MemberTypes memberType = _color32Type.MemberType;
			this.hasManuallySetStartValue = true;
			return this;
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0x11C964C", Offset = "0x11C964C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Tween::Reset(this);\n\tv28 = this._color32Type == 0;\n\tif (v28) goto L_0013;\n\tv33 = System.Reflection.MemberInfo::GetCustomAttributes(this._color32Type, this, Il2CppMethodInfo);\nL_0013:\n\tv42 = this + 0x154;\n\tDG.Tweening.Plugins.Options.ColorOptions::Reset(v42);\n\tthis.hasManuallySetStartValue = 0x100;\n\tthis.tweenPlugin = 0;\n\tthis._colorType = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe sealed override void Reset()
		{
			//IL_0048: Expected O, but got I
			base.Reset();
			if ((object)_color32Type != null)
			{
				object[] customAttributes = _color32Type.GetCustomAttributes((Type)(object)this, inherit: false);
			}
			ColorOptions colorOptions = (ColorOptions)((nint)this + 340);
			((ColorOptions*)colorOptions)->Reset();
			this.hasManuallySetStartValue = false;
			tweenPlugin = null;
			_colorType = null;
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0x11C96B0", Offset = "0x11C96B0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.tweenPlugin;\n\tv6 = this.tweenPlugin == 0;\n\tif (v6) goto L_000F;\n\t*([v4 @ X8_v1 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18])(v10, *([v4 @ X8_v1 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+40]), *([v4 @ X8_v1 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+28]), v71, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\nL_000E:\n\treturn returnVal1;\nL_000F:\n\tv26 = new System.NullReferenceException();\n\tgoto L_001B;\nL_001B:\n\tv30 = v85 != 1;\n\tif (v30) goto L_0037;\n\tv95 = 0x1854E70(v26, v85, v71, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\tv66 = *([v95 @ X0_v8]);\n\tv107 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v66 @ X8_v4]), v71, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\tv108 = v107 & 1;\n\tv64 = v108 == 0;\n\tif (v64) goto L_002D;\n\tv109 = 0x1854E80(v107, *([v66 @ X8_v4]), v71, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\tgoto L_000E;\nL_002D:\n\tv111 = 0x1854E90(8, *([v66 @ X8_v4]), v71, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\t*([v111 @ X0_v14]) = *([v95 @ X0_v8]);\n\tv85 = 0x185A000 + 0xF88;\n\tv113 = 0x1854EA0(v111, v85, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\tv100 = 0x1854E80(v113, v85, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\nL_0037:\n\tv103 = 0xBD3CD0(v82, v85, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\treturnVal2 = 0x9DACB4(v103, v85, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool Validate()
		{
			ABSTweenPlugin<T1, T2, TPlugOptions> aBSTweenPlugin = tweenPlugin;
			if (tweenPlugin != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4 @ X8_v1 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18] (should have been resolved before IL gen)");
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			nint num = default(nint);
			bool flag = num != 1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if ((int)((nint)obj3 & 1) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
				object obj4 = obj2;
				num = 25538440;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x600046D")]
		[Address(RVA = "0x11C9754", Offset = "0x11C9754", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = newType == this.typeofT2;\n\tif (v7) goto L_FFFFFFFF;\n\tv22 = this.typeofT2 != *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]);\n\tif (v22) goto L_FFFFFFFF;\n\tv29 = newType == *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]);\n\tif (v29) goto L_FFFFFFFF;\n\tgoto L_0029;\n\tgoto L_FFFFFFFF;\nL_0029:\n\t*([isColor32ToColor @ X2 (System.Boolean&)]) = v71;\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool ValidateChangeValueType(Type newType, out bool isColor32ToColor)
		{
			isColor32ToColor = default(bool);
			int num;
			bool result;
			if ((object)newType != this.typeofT2)
			{
				Type type = this.typeofT2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+170]");
				if ((object)type == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+178]");
					if ((object)newType == null)
					{
						num = 1;
						goto IL_00b5;
					}
				}
				result = false;
				num = 0;
				goto IL_00a8;
			}
			num = 0;
			goto IL_00b5;
			IL_00a8:
			ref bool reference = ref *(bool*)num;
			return result;
			IL_00b5:
			result = true;
			goto IL_00a8;
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0x11C979C", Offset = "0x11C979C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Tweener::DoUpdateDelay(this, elapsed);\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override float UpdateDelay(float elapsed)
		{
			return Tweener.DoUpdateDelay(this, elapsed);
		}

		[Token(Token = "0x600046F")]
		[Address(RVA = "0x11C97AC", Offset = "0x11C97AC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Tweener::DoStartup(this);\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool Startup()
		{
			return Tweener.DoStartup(this);
		}

		[Token(Token = "0x6000470")]
		[Address(RVA = "0x11C97BC", Offset = "0x11C97BC", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = DG.Tweening.DOTween;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode, updateNotice, methodInfo, v33, prevPosition, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A361B0]) = v44;\nL_001E:\n\tv52 = this.isInverted == 0;\n\tv57 = ~v52;\n\tv59 = v57 ^ useInversePosition;\n\tv61 = v59 == 0;\n\tif (v61) goto L_0032;\n\tgoto L_0032;\nL_0032:\n\tgoto L_0038;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v69, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode, updateNotice, methodInfo, v33, v68, v67, v36, v37, v38, v39, v40, v41);\n\tv75 = DG.Tweening.DOTween;\nL_0038:\n\tv286 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]);\n\tv92 = ~v76.useSafeMode;\n\tif (v92) goto L_006B;\n\tv93 = this._color32Type == 0;\n\tif (v93) goto L_008B;\n\tv120 = System.Reflection.MemberInfo::IsDefined(this._color32Type, v286, this);\n\tgoto L_FFFFFFFF;\nL_006B:\n\t;\n\tv147 = System.Reflection.MemberInfo::IsDefined(this._color32Type, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]), this);\nL_008A:\n\treturn v266;\nL_008B:\n\tv121 = new System.NullReferenceException();\n\tv151 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]) != 1;\n\tif (v151) goto L_00E6;\n\tv285 = 0x1854E70(v121, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]), v288, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\tv175 = *([v285 @ X0_v22]);\n\tv216 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v175 @ X8_v12]), v288, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\tv349 = v216 & 1;\n\tv218 = v349 == 0;\n\tif (v218) goto L_00DC;\n\tv350 = 0x1854E80(v216, *([v175 @ X8_v12]), v288, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\tv169 = DG.Tweening.Core.Debugger::ShouldLogSafeModeCapturedError();\n\tv353 = v169 == 0;\n\tif (v353) goto L_00CE;\n\tv374 = System.Exception::get_TargetSite(*([v285 @ X0_v22]));\n\tv381 = System.Exception::get_Message(*([v285 @ X0_v22]));\n\tv384 = System.Exception::get_StackTrace(*([v285 @ X0_v22]));\n\tv362 = System.String::Format(\"Target or field is missing/null ({0}) ► {1}\\n\\n{2}\\n\\n\", v374, v381, v384);\n\tDG.Tweening.Core.Debugger::LogSafeModeCapturedError(v362, this);\nL_00CE:\n\tgoto L_00D7;\n\tv388 = \"il2cpp_codegen_runtime_class_init\"(v371, v355, v357, v249, v225, v77, methodInfo, v33, v86, v82, v83, v84, v85, v87, v88, v90);\nL_00D7:\n\tv263 = v392.Version + 0x74;\n\tDG.Tweening.Core.SafeModeReport::Add(v263, 1);\n\tgoto L_008A;\n\tthrow System.NullReferenceException;\nL_00DC:\n\tv223 = 0x1854E90(8, v205, v288, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\t*([v223 @ X0_v14]) = *([v219 @ X20_v5]);\n\tv286 = 0x185A000 + 0xF88;\n\tv309 = 0x1854EA0(v223, v286, 0, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\tv300 = 0x1854E80(v309, v286, 0, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\nL_00E6:\n\tv307 = 0xBD3CD0(v302, v286, 0, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\treturnVal2 = 0x9DACB4(v307, v286, 0, useInversePosition, this.tweenPlugin, this._colorType, methodInfo, v33, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+144]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]), this.startValue, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]), this.endValue, this.getter, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]), this.setter);\n\treturn returnVal2;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice)
		{
			//IL_0280: Expected O, but got I
			//IL_005e: Expected I4, but got O
			//IL_005e: Expected O, but got I
			//IL_003b: Expected I4, but got O
			//IL_01ce: Expected O, but got I4
			//IL_018c: Expected O, but got I
			bool flag = !this.isInverted;
			bool flag2 = !flag;
			if (flag2 ^ useInversePosition)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]");
			Type attributeType = (Type)0;
			if (DOTween.useSafeMode)
			{
				if ((object)_color32Type == null)
				{
					NullReferenceException ex = new NullReferenceException();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]");
					bool flag3 = (nint)0 != 1;
					NullReferenceException ex2 = ex;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
						object obj2 = default(object);
						object obj = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj3 = default(object);
						if ((int)((nint)obj3 & 1) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
							if (Debugger.ShouldLogSafeModeCapturedError())
							{
								MethodBase targetSite = ((Exception)obj2).TargetSite;
								string message = ((Exception)obj2).Message;
								string stackTrace = ((Exception)obj2).StackTrace;
								string message2 = $"Target or field is missing/null ({targetSite}) ► {message}\n\n{stackTrace}\n\n";
								Debugger.LogSafeModeCapturedError(message2, this);
							}
							SafeModeReport safeModeReport = (SafeModeReport)((nint)DOTween.Version + 116);
							((SafeModeReport*)safeModeReport)->Add(SafeModeReport.SafeModeReportType.TargetOrFieldMissing);
							return true;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
						object obj5 = default(object);
						object obj4 = obj5;
						attributeType = (Type)(25534464 + 3976);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					bool result = default(bool);
					return result;
				}
				bool flag4 = _color32Type.IsDefined(attributeType, (byte)(int)this != 0);
			}
			else
			{
				Type color32Type = _color32Type;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+154]");
				bool flag5 = color32Type.IsDefined((Type)0, (byte)(int)this != 0);
			}
			return false;
		}
	}
}
