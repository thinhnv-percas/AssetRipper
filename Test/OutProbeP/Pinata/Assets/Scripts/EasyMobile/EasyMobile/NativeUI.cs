using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal.NativeAPIs.Android;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200006F")]
	public static class NativeUI
	{
		[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73163C", Offset = "0x73163C")]
		[Token(Token = "0x2000134")]
		public class AlertPopup : MonoBehaviour
		{
			[Serializable]
			[CompilerGenerated]
			[Token(Token = "0x20001D8")]
			private sealed class _003C_003Ec
			{
				[Token(Token = "0x4000703")]
				public static readonly _003C_003Ec _003C_003E9;

				[Token(Token = "0x4000704")]
				public static Action<int> _003C_003E9__14_0;

				[Token(Token = "0x6000D48")]
				[Address(RVA = "0xFCF47C", Offset = "0xFCF47C", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F06030]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202567C]) = v37;\nL_0015:\n\tv41 = new EasyMobile.NativeUI+AlertPopup+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				static _003C_003Ec()
				{
					_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
					_003C_003E9 = _003C_003Ec2;
				}

				[Token(Token = "0x6000D49")]
				[Address(RVA = "0xFCF4E0", Offset = "0xFCF4E0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public _003C_003Ec()
				{
				}

				internal void _003C_002Ector_003Eb__14_0(int _003Cp0_003E)
				{
				}
			}

			[CompilerGenerated]
			[Token(Token = "0x400052C")]
			[FieldOffset(Offset = "0x18")]
			private Action<int> m_OnComplete;

			[Token(Token = "0x400052D")]
			private static readonly string ALERT_GAMEOBJECT = "MobileNativeAlert";

			[Token(Token = "0x17000269")]
			[field: Token(Token = "0x400052B")]
			public static AlertPopup Instance
			{
				[Token(Token = "0x60009AF")]
				[Address(RVA = "0xFCEFD0", Offset = "0xFCEFD0", Length = "0x68")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB69D0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025670]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.NativeUI+AlertPopup;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60009B0")]
				[Address(RVA = "0xFCF038", Offset = "0xFCF038", Length = "0x6C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECC128]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025671]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.NativeUI+AlertPopup;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				private set;
			}

			[Token(Token = "0x1400004F")]
			public event Action<int> OnComplete
			{
				[CompilerGenerated]
				[Token(Token = "0x60009B1")]
				[Address(RVA = "0xFCF0A4", Offset = "0xFCF0A4", Length = "0xA4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB7FE0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2025672]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Int32>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				add
				{
					//IL_0078: Expected O, but got I
					object obj = (long)(IntPtr)this + 24L;
					Delegate obj2 = this.m_OnComplete;
					Delegate obj4 = default(Delegate);
					while (true)
					{
						Delegate obj3 = Delegate.Combine(obj2, value);
						if (obj3 != null && (object)obj3.GetType() != typeof(Action<int>))
						{
							break;
						}
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
						bool flag = obj2 != obj4;
						obj2 = obj4;
						if (!flag)
						{
							return;
						}
					}
					throw new InvalidCastException();
				}
				[CompilerGenerated]
				[Token(Token = "0x60009B2")]
				[Address(RVA = "0xFCF148", Offset = "0xFCF148", Length = "0xA4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB2AD0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2025673]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Int32>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				remove
				{
					//IL_0078: Expected O, but got I
					object obj = (long)(IntPtr)this + 24L;
					Delegate obj2 = this.m_OnComplete;
					Delegate obj4 = default(Delegate);
					while (true)
					{
						Delegate obj3 = Delegate.Remove(obj2, value);
						if (obj3 != null && (object)obj3.GetType() != typeof(Action<int>))
						{
							break;
						}
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
						bool flag = obj2 != obj4;
						obj2 = obj4;
						if (!flag)
						{
							return;
						}
					}
					throw new InvalidCastException();
				}
			}

			[Token(Token = "0x60009B3")]
			[Address(RVA = "0xFCE564", Offset = "0xFCE564", Length = "0x248")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EC5B98]);\n\tv41 = *([v40 @ X8_v50]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, message, button1, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2025674]) = v56;\nL_0024:\n\tgoto L_002E;\n\tv63 = *([v59 @ X0_v2+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002E;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, message, button1, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_002E:\n\tgoto L_0039;\n\tv75 = *([1EBFA48]);\n\tv76 = *([v75 @ X8_v46]);\n\tv77 = \"il2cpp_codegen_initialize_method\"(v76, message, button1, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv80 = 0 | 1;\n\t*([20256F8]) = v80;\nL_0039:\n\tgoto L_0048;\n\tv85 = *([v81 @ X0_v5 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tgoto L_0048;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v81, message, button1, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv89 = EasyMobile.NativeUI+AlertPopup;\nL_0048:\n\tgoto L_0052;\n\tv101 = *([v95 @ X8_v11+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tgoto L_0052;\n\tv112 = v95;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v112, message, button1, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0052:\n\tv111 = UnityEngine.Object::op_Inequality(v94.<Instance>k__BackingField, 0);\n\tv116 = v111 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_00C4;\n\tgoto L_0069;\n\tv155 = *([v118 @ X0_v12 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0069;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v118, v109, v110, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv159 = EasyMobile.NativeUI+AlertPopup;\nL_0069:\n\tv166 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v166, v163.ALERT_GAMEOBJECT);\n\tv197 = UnityEngine.GameObject::AddComponent(v166);\n\tgoto L_0085;\n\tv203 = *([1EA79F0]);\n\tv204 = *([v203 @ X8_v40]);\n\tv205 = \"il2cpp_codegen_initialize_method\"(v204, v196, v174, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv208 = 0 | 1;\n\t*([20256F9]) = v208;\nL_0085:\n\tgoto L_008D;\n\tv213 = *([v209 @ X0_v21 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv214 = v213 == 0;\n\tv215 = ~v214;\n\tgoto L_008D;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v209, v196, v174, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv217 = EasyMobile.NativeUI+AlertPopup;\nL_008D:\n\tv220.<Instance>k__BackingField = v197;\n\tgoto L_00A0;\n\tv228 = *([v223 @ X0_v23+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tgoto L_00A0;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v223, v196, v174, button2, button3, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00A0:\n\tEasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert::ShowThreeButtonsAlert(title, message, button1, button2, button3);\n\tgoto L_00AF;\n\tv240 = *([1EBFA48]);\n\tv241 = *([v240 @ X8_v35]);\n\tv242 = \"il2cpp_codegen_initialize_method\"(v241, v133, v131, v127, v125, v123, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv245 = 0 | 1;\n\t*([20256F8]) = v245;\nL_00AF:\n\tgoto L_00B7;\n\tv250 = *([v246 @ X0_v27 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tgoto L_00B7;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v246, v133, v131, v127, v125, v123, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv254 = EasyMobile.NativeUI+AlertPopup;\nL_00B7:\n\treturnVal1 = v141.<Instance>k__BackingField;\nL_00C4:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static AlertPopup ShowThreeButtonAlert(string title, string message, string button1, string button2, string button3)
			{
				bool flag = Instance != null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				AlertPopup result = null;
				if (!flag3)
				{
					GameObject gameObject = new GameObject(ALERT_GAMEOBJECT);
					AlertPopup alertPopup = gameObject.AddComponent<AlertPopup>();
					Instance = alertPopup;
					AndroidNativeAlert.ShowThreeButtonsAlert(title, message, button1, button2, button3);
					result = Instance;
				}
				return result;
			}

			[Token(Token = "0x60009B4")]
			[Address(RVA = "0xFCE838", Offset = "0xFCE838", Length = "0x238")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EA7548]);\n\tv37 = *([v36 @ X8_v50]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, message, button1, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2025675]) = v53;\nL_0022:\n\tgoto L_002C;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002C;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, message, button1, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002C:\n\tgoto L_0037;\n\tv72 = *([1EBFA48]);\n\tv73 = *([v72 @ X8_v46]);\n\tv74 = \"il2cpp_codegen_initialize_method\"(v73, message, button1, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv77 = 0 | 1;\n\t*([20256F8]) = v77;\nL_0037:\n\tgoto L_0046;\n\tv82 = *([v78 @ X0_v5 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_0046;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v78, message, button1, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv86 = EasyMobile.NativeUI+AlertPopup;\nL_0046:\n\tgoto L_0050;\n\tv98 = *([v92 @ X8_v11+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tgoto L_0050;\n\tv109 = v92;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v109, message, button1, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0050:\n\tv108 = UnityEngine.Object::op_Inequality(v91.<Instance>k__BackingField, 0);\n\tv113 = v108 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_00C0;\n\tgoto L_0067;\n\tv149 = *([v115 @ X0_v12 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0067;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v115, v106, v107, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv153 = EasyMobile.NativeUI+AlertPopup;\nL_0067:\n\tv160 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v160, v157.ALERT_GAMEOBJECT);\n\tv189 = UnityEngine.GameObject::AddComponent(v160);\n\tgoto L_0083;\n\tv195 = *([1EA79F0]);\n\tv196 = *([v195 @ X8_v40]);\n\tv197 = \"il2cpp_codegen_initialize_method\"(v196, v188, v167, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv200 = 0 | 1;\n\t*([20256F9]) = v200;\nL_0083:\n\tgoto L_008B;\n\tv205 = *([v201 @ X0_v21 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tgoto L_008B;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v201, v188, v167, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv209 = EasyMobile.NativeUI+AlertPopup;\nL_008B:\n\tv212.<Instance>k__BackingField = v189;\n\tgoto L_009D;\n\tv220 = *([v215 @ X0_v23+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tgoto L_009D;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v215, v188, v167, button2, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_009D:\n\tEasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert::ShowTwoButtonsAlert(title, message, button1, button2);\n\tgoto L_00AC;\n\tv232 = *([1EBFA48]);\n\tv233 = *([v232 @ X8_v35]);\n\tv234 = \"il2cpp_codegen_initialize_method\"(v233, v128, v126, v122, v120, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv237 = 0 | 1;\n\t*([20256F8]) = v237;\nL_00AC:\n\tgoto L_00B4;\n\tv242 = *([v238 @ X0_v27 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tgoto L_00B4;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v238, v128, v126, v122, v120, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv246 = EasyMobile.NativeUI+AlertPopup;\nL_00B4:\n\treturnVal1 = v136.<Instance>k__BackingField;\nL_00C0:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static AlertPopup ShowTwoButtonAlert(string title, string message, string button1, string button2)
			{
				bool flag = Instance != null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				AlertPopup result = null;
				if (!flag3)
				{
					GameObject gameObject = new GameObject(ALERT_GAMEOBJECT);
					AlertPopup alertPopup = gameObject.AddComponent<AlertPopup>();
					Instance = alertPopup;
					AndroidNativeAlert.ShowTwoButtonsAlert(title, message, button1, button2);
					result = Instance;
				}
				return result;
			}

			[Token(Token = "0x60009B5")]
			[Address(RVA = "0xFCEAEC", Offset = "0xFCEAEC", Length = "0x230")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EDF778]);\n\tv33 = *([v32 @ X8_v50]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, message, button, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2025676]) = v50;\nL_0020:\n\tgoto L_002A;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002A;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, message, button, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_002A:\n\tgoto L_0035;\n\tv69 = *([1EBFA48]);\n\tv70 = *([v69 @ X8_v46]);\n\tv71 = \"il2cpp_codegen_initialize_method\"(v70, message, button, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv74 = 0 | 1;\n\t*([20256F8]) = v74;\nL_0035:\n\tgoto L_0044;\n\tv79 = *([v75 @ X0_v5 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_0044;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v75, message, button, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv83 = EasyMobile.NativeUI+AlertPopup;\nL_0044:\n\tgoto L_004E;\n\tv95 = *([v89 @ X8_v11+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tgoto L_004E;\n\tv106 = v89;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v106, message, button, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004E:\n\tv105 = UnityEngine.Object::op_Inequality(v88.<Instance>k__BackingField, 0);\n\tv110 = v105 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_00BC;\n\tgoto L_0065;\n\tv143 = *([v112 @ X0_v12 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0065;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v112, v103, v104, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv147 = EasyMobile.NativeUI+AlertPopup;\nL_0065:\n\tv154 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v154, v151.ALERT_GAMEOBJECT);\n\tv181 = UnityEngine.GameObject::AddComponent(v154);\n\tgoto L_0081;\n\tv187 = *([1EA79F0]);\n\tv188 = *([v187 @ X8_v40]);\n\tv189 = \"il2cpp_codegen_initialize_method\"(v188, v180, v160, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv192 = 0 | 1;\n\t*([20256F9]) = v192;\nL_0081:\n\tgoto L_0089;\n\tv197 = *([v193 @ X0_v21 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tgoto L_0089;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v193, v180, v160, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv201 = EasyMobile.NativeUI+AlertPopup;\nL_0089:\n\tv204.<Instance>k__BackingField = v181;\n\tgoto L_009A;\n\tv212 = *([v207 @ X0_v23+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tgoto L_009A;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v207, v180, v160, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_009A:\n\tEasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert::ShowOneButtonAlert(title, message, button);\n\tgoto L_00A9;\n\tv224 = *([1EBFA48]);\n\tv225 = *([v224 @ X8_v35]);\n\tv226 = \"il2cpp_codegen_initialize_method\"(v225, v123, v121, v117, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv229 = 0 | 1;\n\t*([20256F8]) = v229;\nL_00A9:\n\tgoto L_00B1;\n\tv234 = *([v230 @ X0_v27 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tgoto L_00B1;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v230, v123, v121, v117, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv238 = EasyMobile.NativeUI+AlertPopup;\nL_00B1:\n\treturnVal1 = v131.<Instance>k__BackingField;\nL_00BC:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static AlertPopup ShowOneButtonAlert(string title, string message, string button)
			{
				bool flag = Instance != null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				AlertPopup result = null;
				if (!flag3)
				{
					GameObject gameObject = new GameObject(ALERT_GAMEOBJECT);
					AlertPopup alertPopup = gameObject.AddComponent<AlertPopup>();
					Instance = alertPopup;
					AndroidNativeAlert.ShowOneButtonAlert(title, message, button);
					result = Instance;
				}
				return result;
			}

			[Token(Token = "0x60009B6")]
			[Address(RVA = "0xFCED90", Offset = "0xFCED90", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE2B40]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025677]) = v41;\nL_001B:\n\tgoto L_002C;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002C;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\treturnVal1 = EasyMobile.NativeUI+AlertPopup::ShowOneButtonAlert(title, message, \"OK\");\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static AlertPopup Alert(string title, string message)
			{
				return ShowOneButtonAlert(title, message, "OK");
			}

			[Token(Token = "0x60009B7")]
			[Address(RVA = "0xFCEF58", Offset = "0xFCEF58", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC9B08]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isLongToast, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025678]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, isLongToast, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tEasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert::ShowToast(message, isLongToast);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static void ShowToast(string message, bool isLongToast = false)
			{
				AndroidNativeAlert.ShowToast(message, isLongToast);
			}

			[Token(Token = "0x60009B8")]
			[Address(RVA = "0xFCF1EC", Offset = "0xFCF1EC", Length = "0x144")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ECC7D8]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, buttonIndex, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2025679]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, buttonIndex, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1EA79F0]);\n\tv63 = *([v62 @ X8_v23]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, buttonIndex, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([20256F9]) = v67;\nL_0031:\n\tgoto L_0039;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_0039;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v68, buttonIndex, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = EasyMobile.NativeUI+AlertPopup;\nL_0039:\n\tv79.<Instance>k__BackingField = 0;\n\tgoto L_0049;\n\tv88 = *([v83 @ X0_v7+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tgoto L_0049;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v83, buttonIndex, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0049:\n\tv97 = System.Convert::ToInt16(buttonIndex);\n\tSystem.Action`1<System.Int32>::Invoke(this.OnComplete, v97);\n\tv108 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_006C;\n\tv139 = *([v112 @ X8_v18+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_006C;\n\tv144 = v112;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v144, v107, v103, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006C:\n\tUnityEngine.Object::Destroy(v108);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void OnNativeAlertCallback(string buttonIndex)
			{
				Instance = null;
				short obj = Convert.ToInt16(buttonIndex);
				this.OnComplete(obj);
				GameObject obj2 = base.gameObject;
				UnityEngine.Object.Destroy(obj2);
			}

			[Token(Token = "0x60009B9")]
			[Address(RVA = "0xFCF330", Offset = "0xFCF330", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB1CB8]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202567A]) = v42;\nL_001B:\n\tgoto L_0023;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.NativeUI+AlertPopup+<>c>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0023;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = EasyMobile.NativeUI+AlertPopup+<>c;\nL_0023:\n\tv81 = v56.<>9__14_0;\n\tv58 = v56.<>9__14_0 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0045;\n\tgoto L_0036;\n\tv84 = *([v52 @ X0_v3 (Il2CppClass<EasyMobile.NativeUI+AlertPopup+<>c>)+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0036;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv108 = EasyMobile.NativeUI+AlertPopup+<>c;\n\tv91 = *([v108 @ X8_v14+B8]);\nL_0036:\n\tv76 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v76, v90.<>9, Il2CppMethodInfo);\n\tv80.<>9__14_0 = v76;\nL_0045:\n\tthis.OnComplete = v81;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AlertPopup()
			{
				Action<int> onComplete = _003C_003Ec._003C_003E9__14_0;
				if (_003C_003Ec._003C_003E9__14_0 == null)
				{
					onComplete = (_003C_003Ec._003C_003E9__14_0 = delegate
					{
					});
				}
				this.OnComplete = onComplete;
			}
		}

		[Token(Token = "0x6000521")]
		[Address(RVA = "0xFCE4D0", Offset = "0xFCE4D0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EA9340]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, message, button1, button2, button3, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202566A]) = v50;\nL_0021:\n\tgoto L_0035;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0035;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, message, button1, button2, button3, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0035:\n\treturnVal1 = EasyMobile.NativeUI+AlertPopup::ShowThreeButtonAlert(title, message, button1, button2, button3);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AlertPopup ShowThreeButtonAlert(string title, string message, string button1, string button2, string button3)
		{
			return AlertPopup.ShowThreeButtonAlert(title, message, button1, button2, button3);
		}

		[Token(Token = "0x6000522")]
		[Address(RVA = "0xFCE7AC", Offset = "0xFCE7AC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EADB00]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, message, button1, button2, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202566B]) = v47;\nL_001F:\n\tgoto L_0031;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0031;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, message, button1, button2, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0031:\n\treturnVal1 = EasyMobile.NativeUI+AlertPopup::ShowTwoButtonAlert(title, message, button1, button2);\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AlertPopup ShowTwoButtonAlert(string title, string message, string button1, string button2)
		{
			return AlertPopup.ShowTwoButtonAlert(title, message, button1, button2);
		}

		[Token(Token = "0x6000523")]
		[Address(RVA = "0xFCEA70", Offset = "0xFCEA70", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC2920]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, message, button, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202566C]) = v44;\nL_001D:\n\tgoto L_002D;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, message, button, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\treturnVal1 = EasyMobile.NativeUI+AlertPopup::ShowOneButtonAlert(title, message, button);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AlertPopup Alert(string title, string message, string button)
		{
			return AlertPopup.ShowOneButtonAlert(title, message, button);
		}

		[Token(Token = "0x6000524")]
		[Address(RVA = "0xFCED1C", Offset = "0xFCED1C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBB9A0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202566D]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\treturnVal1 = EasyMobile.NativeUI+AlertPopup::Alert(title, message);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AlertPopup Alert(string title, string message)
		{
			return AlertPopup.Alert(title, message);
		}

		[Token(Token = "0x6000525")]
		[Address(RVA = "0xFCEE10", Offset = "0xFCEE10", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EABC68]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202566E]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1EBFA48]);\n\tv57 = *([v56 @ X8_v14]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([20256F8]) = v61;\nL_002D:\n\tgoto L_003C;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<EasyMobile.NativeUI+AlertPopup>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_003C;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = EasyMobile.NativeUI+AlertPopup;\nL_003C:\n\tgoto L_004B;\n\tv82 = *([v76 @ X8_v11+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_004B;\n\tv97 = v76;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v97, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004B:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v75.<Instance>k__BackingField, 0);\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsShowingAlert()
		{
			return AlertPopup.Instance != null;
		}

		[Token(Token = "0x6000526")]
		[Address(RVA = "0xFCEEE4", Offset = "0xFCEEE4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC1340]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isLongToast, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202566F]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, isLongToast, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tEasyMobile.NativeUI+AlertPopup::ShowToast(message, isLongToast);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShowToast(string message, bool isLongToast = false)
		{
			AlertPopup.ShowToast(message, isLongToast);
		}
	}
}
