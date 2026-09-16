using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000D7")]
	internal abstract class BaseNativeEEARegionValidator : IPlatformEEARegionValidator
	{
		[Serializable]
		[Token(Token = "0x20001B8")]
		protected class GoogleServiceResponse
		{
			[SerializeField]
			[Token(Token = "0x40006A3")]
			[FieldOffset(Offset = "0x10")]
			private bool is_request_in_eea_or_unknown;

			[Token(Token = "0x17000329")]
			public bool IsFromEEA
			{
				[Token(Token = "0x6000CF5")]
				[Address(RVA = "0xC09210", Offset = "0xC09210", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.is_request_in_eea_or_unknown;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return IsFromEEA;
				}
			}

			[Token(Token = "0x6000CF6")]
			[Address(RVA = "0xC09218", Offset = "0xC09218", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public GoogleServiceResponse()
			{
			}
		}

		[Token(Token = "0x40003CA")]
		[FieldOffset(Offset = "0x10")]
		protected bool isValidateCoroutineRunning;

		[Token(Token = "0x1700022A")]
		protected virtual string GoogleServiceUrl
		{
			[Token(Token = "0x60007AC")]
			[Address(RVA = "0xC07BA8", Offset = "0xC07BA8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F02600]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023007]) = v35;\nL_0018:\n\treturn \"https://adservice.google.com/getconfig/pubvendors?pubs=%1$s&amp;es=2\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "https://adservice.google.com/getconfig/pubvendors?pubs=%1$s&amp;es=2";
			}
		}

		[Token(Token = "0x60007AD")]
		public abstract string GetCountryCodeViaLocale();

		[Token(Token = "0x60007AE")]
		public abstract string GetCountryCodeViaTelephony();

		[Token(Token = "0x60007AF")]
		public abstract EEARegionStatus ValidateViaTimezone();

		[Token(Token = "0x60007B0")]
		[Address(RVA = "0xC085A8", Offset = "0xC085A8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EFDB68]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methods, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023008]) = v44;\nL_0018:\n\tv46 = ~this.isValidateCoroutineRunning;\n\tif (v46) goto L_0036;\n\tgoto L_0031;\n\tv57 = *([v49 @ X0_v9+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v49, methods, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0031:\n\tUnityEngine.Debug::Log(\"Another validation progress is running.\");\n\treturn;\nL_0036:\n\tv56 = EasyMobile.Internal.Privacy.BaseNativeEEARegionValidator::ValidateEEARegionStatusCoroutine(this, methods, callback);\n\tgoto L_004E;\n\tv81 = *([v77 @ X8_v6+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_004E;\n\tv110 = v77;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v110, v54, v55, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004E:\n\tv96 = EasyMobile.Internal.RuntimeHelper::RunCoroutine(v56);\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ValidateEEARegionStatus(List<EEARegionValidationMethods> methods, Action<EEARegionStatus> callback)
		{
			if (isValidateCoroutineRunning)
			{
				Debug.Log("Another validation progress is running.");
				return;
			}
			IEnumerator routine = ValidateEEARegionStatusCoroutine(methods, callback);
			Coroutine coroutine = RuntimeHelper.RunCoroutine(routine);
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x738230", Offset = "0x738230")]
		[Token(Token = "0x60007B1")]
		[Address(RVA = "0xC08680", Offset = "0xC08680", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EBEEC8]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methods, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023009]) = v44;\nL_001A:\n\tv48 = new EasyMobile.Internal.Privacy.BaseNativeEEARegionValidator+<ValidateEEARegionStatusCoroutine>d__8();\n\tSystem.Object::.ctor(v48);\n\tv48.<>1__state = 0;\n\tv48.<>4__this = this;\n\tv48.methods = methods;\n\tv48.callback = callback;\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator ValidateEEARegionStatusCoroutine(List<EEARegionValidationMethods> methods, Action<EEARegionStatus> callback)
		{
			_003CValidateEEARegionStatusCoroutine_003Ed__8 _003CValidateEEARegionStatusCoroutine_003Ed__9 = null;
			_003CValidateEEARegionStatusCoroutine_003Ed__9._003C_003E1__state = 0;
			_003CValidateEEARegionStatusCoroutine_003Ed__9._003C_003E4__this = this;
			_003CValidateEEARegionStatusCoroutine_003Ed__9.methods = methods;
			_003CValidateEEARegionStatusCoroutine_003Ed__9.callback = callback;
			return _003CValidateEEARegionStatusCoroutine_003Ed__9;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x738294", Offset = "0x738294")]
		[Token(Token = "0x60007B2")]
		[Address(RVA = "0xC08734", Offset = "0xC08734", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA88B0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultsStack, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202300A]) = v41;\nL_0018:\n\tv45 = new EasyMobile.Internal.Privacy.BaseNativeEEARegionValidator+<ValidateViaGoogleServiceCoroutine>d__9();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n\tv45.resultsStack = resultsStack;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual IEnumerator ValidateViaGoogleServiceCoroutine(Stack<EEARegionStatus> resultsStack)
		{
			_003CValidateViaGoogleServiceCoroutine_003Ed__9 _003CValidateViaGoogleServiceCoroutine_003Ed__10 = null;
			_003CValidateViaGoogleServiceCoroutine_003Ed__10._003C_003E1__state = 0;
			_003CValidateViaGoogleServiceCoroutine_003Ed__10._003C_003E4__this = this;
			_003CValidateViaGoogleServiceCoroutine_003Ed__10.resultsStack = resultsStack;
			return _003CValidateViaGoogleServiceCoroutine_003Ed__10;
		}

		[Token(Token = "0x60007B3")]
		[Address(RVA = "0xC07C68", Offset = "0xC07C68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseNativeEEARegionValidator()
		{
		}
	}
}
