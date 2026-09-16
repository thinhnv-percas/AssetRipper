using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Token(Token = "0x2000004")]
public class GDPR : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x2000005")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x4000018")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x4000019")]
		public static UnityAction _003C_003E9__3_0;

		[Token(Token = "0x400001A")]
		public static UnityAction _003C_003E9__3_1;

		[Token(Token = "0x400001B")]
		public static UnityAction _003C_003E9__3_2;

		[Token(Token = "0x6000022")]
		[Address(RVA = "0xBF5844", Offset = "0xBF5844", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GDPR+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355B1]) = v34;\nL_0012:\n\tv36 = new GDPR+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0xBF58A0", Offset = "0xBF58A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal void _003CStart_003Eb__3_0()
		{
			((AdManager)this).OnUserClickPrivacyPolicy();
		}

		internal void _003CStart_003Eb__3_1()
		{
			AdManager.Instance.OnUserClickAccept();
		}

		internal void _003CStart_003Eb__3_2()
		{
			AdManager.Instance.OnUserClickCancel();
		}
	}

	[Token(Token = "0x4000015")]
	[FieldOffset(Offset = "0x20")]
	public Button ShowPP;

	[Token(Token = "0x4000016")]
	[FieldOffset(Offset = "0x28")]
	public Button Accept;

	[Token(Token = "0x4000017")]
	[FieldOffset(Offset = "0x30")]
	public Button Cancle;

	[Token(Token = "0x6000020")]
	[Address(RVA = "0xBF55CC", Offset = "0xBF55CC", Length = "0x270")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv117 = Il2CppMethodInfo;\n\tv118 = \"il2cpp_codegen_initialize_runtime_metadata\"(v117, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv120 = GDPR+<>c;\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv145 = UnityEngine.Events.UnityAction;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A355B0]) = v40;\nL_001F:\n\tv41 = this.ShowPP;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v41.m_OnClick);\n\tv103 = this.ShowPP;\n\tgoto L_0035;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v147, v73, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv153 = GDPR+<>c;\nL_0035:\n\tv58 = v154.<>9__3_0;\n\tv156 = v154.<>9__3_0 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0054;\n\tgoto L_0044;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v152, v73, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv172 = GDPR+<>c;\nL_0044:\n\tv167 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v167, v174.<>9, Il2CppMethodInfo);\n\tv169.<>9__3_0 = v167;\nL_0054:\n\tUnityEngine.Events.UnityEvent::AddListener(v103.m_OnClick, v58);\n\tv105 = this.Accept;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v105.m_OnClick);\n\tv106 = this.Accept;\n\tgoto L_0069;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v179, v76, v53, v62, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv185 = GDPR+<>c;\nL_0069:\n\tv59 = v186.<>9__3_1;\n\tv188 = v186.<>9__3_1 == 0;\n\tv189 = ~v188;\n\tif (v189) goto L_0088;\n\tgoto L_0078;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v184, v76, v53, v62, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv204 = GDPR+<>c;\nL_0078:\n\tv199 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v199, v206.<>9, Il2CppMethodInfo);\n\tv201.<>9__3_1 = v199;\nL_0088:\n\tUnityEngine.Events.UnityEvent::AddListener(v106.m_OnClick, v59);\n\tv108 = this.Cancle;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v108.m_OnClick);\n\tv109 = this.Cancle;\n\tgoto L_009D;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v211, v79, v55, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv217 = GDPR+<>c;\nL_009D:\n\tv114 = v218.<>9__3_2;\n\tv220 = v218.<>9__3_2 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_00C3;\n\tgoto L_00AC;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v216, v79, v55, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv236 = GDPR+<>c;\nL_00AC:\n\tv230 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v230, v238.<>9, Il2CppMethodInfo);\n\tv232.<>9__3_2 = v230;\nL_00C3:\n\tUnityEngine.Events.UnityEvent::AddListener(v109.m_OnClick, v114);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		Button showPP = ShowPP;
		showPP.onClick.RemoveAllListeners();
		Button showPP2 = ShowPP;
		UnityAction call = _003C_003Ec._003C_003E9__3_0;
		if (_003C_003Ec._003C_003E9__3_0 == null)
		{
			call = (_003C_003Ec._003C_003E9__3_0 = delegate
			{
				((AdManager)(object)_003C_003Ec._003C_003E9).OnUserClickPrivacyPolicy();
			});
		}
		showPP2.onClick.AddListener(call);
		Button accept = Accept;
		accept.onClick.RemoveAllListeners();
		Button accept2 = Accept;
		UnityAction call2 = _003C_003Ec._003C_003E9__3_1;
		if (_003C_003Ec._003C_003E9__3_1 == null)
		{
			call2 = (_003C_003Ec._003C_003E9__3_1 = delegate
			{
				AdManager.Instance.OnUserClickAccept();
			});
		}
		accept2.onClick.AddListener(call2);
		Button cancle = Cancle;
		cancle.onClick.RemoveAllListeners();
		Button cancle2 = Cancle;
		UnityAction call3 = _003C_003Ec._003C_003E9__3_2;
		if (_003C_003Ec._003C_003E9__3_2 == null)
		{
			call3 = (_003C_003Ec._003C_003E9__3_2 = delegate
			{
				AdManager.Instance.OnUserClickCancel();
			});
		}
		cancle2.onClick.AddListener(call3);
	}

	[Token(Token = "0x6000021")]
	[Address(RVA = "0xBF583C", Offset = "0xBF583C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GDPR()
	{
	}
}
