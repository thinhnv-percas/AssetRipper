using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EasyMobile.Internal.Privacy
{
	[ExecuteInEditMode]
	[Token(Token = "0x20000DC")]
	public class EditorConsentDialogClickableText : Text, IPointerClickHandler, IEventSystemHandler, IPointerExitHandler, IPointerEnterHandler, ISelectHandler
	{
		[Serializable]
		[Token(Token = "0x20001BC")]
		public struct IconName
		{
			[Token(Token = "0x40006B5")]
			[FieldOffset(Offset = "0x0")]
			public string name;

			[Token(Token = "0x40006B6")]
			[FieldOffset(Offset = "0x8")]
			public Sprite sprite;
		}

		[Token(Token = "0x20001BD")]
		private class HrefInfo
		{
			[Token(Token = "0x40006B7")]
			[FieldOffset(Offset = "0x10")]
			public int startIndex;

			[Token(Token = "0x40006B8")]
			[FieldOffset(Offset = "0x14")]
			public int endIndex;

			[Token(Token = "0x40006B9")]
			[FieldOffset(Offset = "0x18")]
			public string name;

			[Token(Token = "0x40006BA")]
			[FieldOffset(Offset = "0x20")]
			public readonly List<Rect> boxes;

			[Token(Token = "0x6000D09")]
			[Address(RVA = "0xB4CCA8", Offset = "0xB4CCA8", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBD960]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202273A]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<UnityEngine.Rect>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Rect>::.ctor(v42);\n\tthis.boxes = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public HrefInfo()
			{
				List<Rect> list = new List<Rect>();
				boxes = list;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001BE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006BB")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006BC")]
			public static Predicate<Image> _003C_003E9__31_0;

			[Token(Token = "0x6000D0A")]
			[Address(RVA = "0xB4CFBC", Offset = "0xB4CFBC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB6B30]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022738]) = v37;\nL_0015:\n\tv41 = new EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000D0B")]
			[Address(RVA = "0xB4D020", Offset = "0xB4D020", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CUpdateQuadImage_003Eb__31_0(Image image)
			{
				return image == null;
			}
		}

		[Token(Token = "0x40003CF")]
		[FieldOffset(Offset = "0xF0")]
		public readonly string HyperlinkColor = "#0000EE";

		[CompilerGenerated]
		[Token(Token = "0x40003D0")]
		[FieldOffset(Offset = "0xF8")]
		private Action<string> m_OnHyperlinkClicked;

		[Token(Token = "0x40003D1")]
		[FieldOffset(Offset = "0x100")]
		private readonly List<Image> imagesPool;

		[Token(Token = "0x40003D2")]
		[FieldOffset(Offset = "0x108")]
		private readonly List<GameObject> culledImagesPool;

		[Token(Token = "0x40003D3")]
		[FieldOffset(Offset = "0x110")]
		private readonly List<int> imagesVertexIndex;

		[Token(Token = "0x40003D4")]
		private static readonly StringBuilder textBuilder;

		[Token(Token = "0x40003D5")]
		private static readonly Regex hrefRegex;

		[Token(Token = "0x40003D6")]
		private static readonly Regex regex;

		[Token(Token = "0x40003D7")]
		[FieldOffset(Offset = "0x118")]
		private readonly List<HrefInfo> hrefInfos;

		[Token(Token = "0x40003D8")]
		[FieldOffset(Offset = "0x120")]
		private string fixedString;

		[Token(Token = "0x40003D9")]
		[FieldOffset(Offset = "0x128")]
		private bool clearImages;

		[Token(Token = "0x40003DA")]
		[FieldOffset(Offset = "0x130")]
		private string outputText;

		[Token(Token = "0x40003DB")]
		[FieldOffset(Offset = "0x138")]
		private IconName[] inspectorIconList;

		[Token(Token = "0x40003DC")]
		[FieldOffset(Offset = "0x140")]
		private Dictionary<string, Sprite> iconList;

		[Token(Token = "0x40003DD")]
		[FieldOffset(Offset = "0x148")]
		private float imageScalingFactor;

		[Token(Token = "0x40003DE")]
		[FieldOffset(Offset = "0x14C")]
		private Vector2 imageOffset;

		[Token(Token = "0x40003DF")]
		[FieldOffset(Offset = "0x158")]
		private Button button;

		[Token(Token = "0x40003E0")]
		[FieldOffset(Offset = "0x160")]
		private List<Vector2> positions;

		[Token(Token = "0x40003E1")]
		[FieldOffset(Offset = "0x168")]
		private string previousText;

		[Token(Token = "0x40003E2")]
		[FieldOffset(Offset = "0x170")]
		private bool isCreatingHrefInfos;

		[Token(Token = "0x14000035")]
		public event Action<string> OnHyperlinkClicked
		{
			[CompilerGenerated]
			[Token(Token = "0x60007C5")]
			[Address(RVA = "0xB4A51C", Offset = "0xB4A51C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE7008]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202272A]) = v43;\nL_0017:\n\tv45 = this + 0xF8;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 248L;
				Delegate obj2 = this.m_OnHyperlinkClicked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string>))
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
			[Token(Token = "0x60007C6")]
			[Address(RVA = "0xB4A5C0", Offset = "0xB4A5C0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ECA7A0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202272B]) = v43;\nL_0017:\n\tv45 = this + 0xF8;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 248L;
				Delegate obj2 = this.m_OnHyperlinkClicked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string>))
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

		[Token(Token = "0x60007C7")]
		[Address(RVA = "0xB4A664", Offset = "0xB4A664", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Graphic::SetVerticesDirty(this);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogClickableText::UpdateQuadImage(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetVerticesDirty()
		{
			base.SetVerticesDirty();
			UpdateQuadImage();
		}

		[Token(Token = "0x60007C8")]
		[Address(RVA = "0xB4B1AC", Offset = "0xB4B1AC", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_001B;\n\tv30 = *([1EA6E28]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, eventData, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202272C]) = v49;\nL_001B:\n\t*([v18 @ X29_v1-28]) = 0;\n\tv57 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv59 = eventData == 0;\n\tif (v59) goto L_00A8;\n\tv64 = UnityEngine.EventSystems.PointerEventData::get_pressEventCamera(eventData);\n\tgoto L_0038;\n\tv183 = *([v142 @ X8_v11+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0038;\n\tv191 = v142;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v191, v63, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0038:\n\tv169 = &v19 @ stack_-10_v2 - 0x28;\n\t// 62 MakeStruct v111 @ AGGB4B268_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), eventData.<position>k__BackingField (UnityEngine.Vector2), eventData.<position>k__BackingField.y (System.Single)\n\tv190 = UnityEngine.RectTransformUtility::ScreenPointToLocalPointInRectangle(v57, v111, v64, v169);\n\tv178 = this.hrefInfos == 0;\n\tif (v178) goto L_00A8;\n\tv206 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::GetEnumerator(this.hrefInfos);\n\tgoto L_008F;\nL_0052:\n\tv251 = *([v210 @ stack_-88+20]);\n\tv415 = *([v251 @ X22_v8+18]);\n\tv233 = *([v251 @ X22_v8+18]) < 1;\n\tif (v233) goto L_008F;\nL_0063:\n\tv416 = v415 < v370;\n\tv379 = ~v416;\n\tv378 = v415 - v370;\n\tv376 = v378 == 0;\n\tv417 = ~v376;\n\tv371 = v379 & v417;\n\tif (v371) goto L_0074;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0074:\n\tv230 = v370 << 4;\n\tv388 = *([v251 @ X22_v8+10]) + v230;\n\tv68 = *([v388 @ X8_v23+20]);\n\tv257 = 0x10CD1C8(&v68 @ V2_v4, 0, v169, 0, v35, v36, v37, v38, *([v18 @ X29_v1-28]), *([v18 @ X29_v1-24]), *([v388 @ X8_v23+20]), v42, v43, v44, v45, v46);\n\tv422 = v257 & 1;\n\tv423 = v422 == 0;\n\tv260 = ~v423;\n\tif (v260) goto L_0096;\n\tv415 = *([v251 @ X22_v8+18]);\n\tv370 = v370 + 1;\n\tv232 = v370 < *([v251 @ X22_v8+18]);\n\tif (v232) goto L_0063;\nL_008F:\n\tv258 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::MoveNext(&v108 @ stack_-98_v4 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>));\n\tv269 = v258 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0052;\n\tgoto L_00A1;\nL_0096:\n\tv385 = this.OnHyperlinkClicked == 0;\n\tif (v385) goto L_00A1;\n\tSystem.Action`1<System.String>::Invoke(this.OnHyperlinkClicked, *([v210 @ stack_-88+18]));\nL_00A1:\n\tv363 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::Dispose(&v108 @ stack_-98_v4 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>));\n\tgoto L_00CE;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00A8:\n\tv182 = new System.NullReferenceException();\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\nL_00B7:\n\tv201 = v124 != 1;\n\tif (v201) goto L_00CF;\n\tv207 = 0x6D2BC0(v182, v124, v169, v164, v35, v36, v37, v38, v117, v165, v68, v42, v43, v44, v45, v46);\n\tv214 = 0x6D2490(v207, v124, v169, v164, v35, v36, v37, v38, v117, v165, v68, v42, v43, v44, v45, v46);\n\tv218 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::Dispose(&v103 @ stack_-70_v4 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>));\n\tv271 = *([v207 @ X0_v10]) == 0;\n\tv220 = ~v271;\n\tif (v220) goto L_00D3;\nL_00CE:\n\treturn;\nL_00CF:\n\tv208 = 0x6D2380(v182, v124, v169, v164, v35, v36, v37, v38, v117, v165, v68, v42, v43, v44, v45, v46);\nL_00D3:\n\tthrow System.TypeLoadException;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnPointerClick(PointerEventData eventData)
		{
			//IL_0354: Expected O, but got I4
			//IL_0099: Expected O, but got I4
			//IL_00c0: Expected I, but got O
			//IL_0104: Expected O, but got I
			//IL_017a: Expected O, but got I
			//IL_018a: Expected O, but got I
			//IL_0282: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			RectTransform rect = base.rectTransform;
			bool flag = eventData == null;
			List<HrefInfo>.Enumerator enumerator2 = default(List<HrefInfo>.Enumerator);
			List<HrefInfo>.Enumerator enumerator = enumerator2;
			object obj3 = 0;
			IntPtr intPtr = (IntPtr)0;
			if (!flag)
			{
				Camera pressEventCamera = eventData.pressEventCamera;
				ref Vector2 localPoint = ref *(Vector2*)((long)(IntPtr)obj2 - 40L);
				Vector2 screenPoint = default(Vector2);
				screenPoint.x = eventData.position.x;
				screenPoint.y = eventData.position.y;
				bool flag2 = RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, pressEventCamera, out localPoint);
				bool flag3 = hrefInfos == null;
				enumerator = default(List<HrefInfo>.Enumerator);
				obj3 = 0;
				float y = eventData.position.y;
				List<HrefInfo>.Enumerator enumerator3 = (List<HrefInfo>.Enumerator)eventData.position;
				intPtr = (IntPtr)pressEventCamera;
				if (!flag3)
				{
					List<HrefInfo>.Enumerator enumerator4 = hrefInfos.GetEnumerator();
					y = eventData.position.y;
					object obj7 = default(object);
					while (enumerator2.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ stack_-88+20]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X22_v8+18]");
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X22_v8+18]");
						if (0L < 1L)
						{
							continue;
						}
						int num2 = 0;
						while (true)
						{
							bool flag4 = num < num2;
							bool flag5 = !flag4;
							int num3 = num - num2;
							bool flag6 = num3 == 0;
							bool flag7 = !flag6;
							if (!(flag5 && flag7))
							{
								throw new ArgumentOutOfRangeException();
							}
							int num4 = num2 << 4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X22_v8+10]");
							object obj5 = 0L + (long)num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ X8_v23+20]");
							object obj6 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD1C8 (inside UnityEngine.Rect::MinMaxRect +0x22C)");
							if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X22_v8+18]");
							num = 0;
							num2++;
							int num5 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X22_v8+18]");
							if ((long)num5 >= 0L)
							{
								goto IL_0212;
							}
						}
						if (this.OnHyperlinkClicked != null)
						{
							Action<string> action = this.OnHyperlinkClicked;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ stack_-88+18]");
							action((string)0);
						}
						break;
						IL_0212:;
					}
					enumerator2.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (intPtr == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj8 = default(object);
				if (obj8 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60007C9")]
		[Address(RVA = "0xB4B3D8", Offset = "0xB4B3D8", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EF6938]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventData, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202272D]) = v44;\nL_0019:\n\tv48 = this.imagesPool;\n\tv49 = this.imagesPool == 0;\n\tif (v49) goto L_0071;\n\tv61 = v48._size < 1;\n\tif (v61) goto L_0096;\n\tv121 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.imagesPool);\nL_0038:\n\tv240 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v86 @ stack_-78_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv162 = v240 == 0;\n\tif (v162) goto L_006A;\n\tgoto L_004B;\n\tv256 = *([v248 @ X0_v20+E0]);\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_004B;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v248, v238, v127, v29, v30, v31, v32, v33, v84, v67, v65, v63, v38, v39, v40, v41);\nL_004B:\n\tv228 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv232 = v228 == 0;\n\tif (v232) goto L_0038;\n\tv229 = UnityEngine.Behaviour::get_isActiveAndEnabled(this.button);\n\tv233 = v229 == 0;\n\tif (v233) goto L_0038;\n\tv274 = this.button;\n\tv221 = *([v178 @ stack_-68]);\n\t*([v221 @ X9_v4+2A0])(v230, v178, *([v221 @ X9_v4+2A8]), 0, v29, v30, v31, v32, v33, v274.m_Colors.m_HighlightedColor, v274.m_Colors.m_HighlightedColor.g, v274.m_Colors.m_HighlightedColor.b, v274.m_Colors.m_HighlightedColor.a, v38, v39, v40, v41);\n\tgoto L_0038;\nL_006A:\n\tv159 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v86 @ stack_-78_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_0096;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv109 = new System.NullReferenceException();\nL_0071:\n\tv116 = new System.NullReferenceException();\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\nL_0081:\n\tv140 = v88 != 1;\n\tif (v140) goto L_0097;\n\tv241 = 0x6D2BC0(v116, v88, 0, v29, v30, v31, v32, v33, v83, v66, v64, v62, v38, v39, v40, v41);\n\tv244 = 0x6D2490(v241, v88, 0, v29, v30, v31, v32, v33, v83, v66, v64, v62, v38, v39, v40, v41);\n\tv158 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v77 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv263 = *([v241 @ X0_v10]) == 0;\n\tv161 = ~v263;\n\tif (v161) goto L_009B;\nL_0096:\n\treturn;\nL_0097:\n\tv242 = 0x6D2380(v116, v88, 0, v29, v30, v31, v32, v33, v83, v66, v64, v62, v38, v39, v40, v41);\nL_009B:\n\tthrow System.TypeLoadException;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerEnter(PointerEventData eventData)
		{
			List<Image> list = imagesPool;
			bool flag = imagesPool == null;
			List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
			List<Image>.Enumerator enumerator = enumerator2;
			if (!flag)
			{
				if (list.Count < 1)
				{
					return;
				}
				List<Image>.Enumerator enumerator3 = imagesPool.GetEnumerator();
				object obj2 = default(object);
				while (enumerator2.MoveNext())
				{
					if (this.button != null && this.button.isActiveAndEnabled)
					{
						Button button = this.button;
						object obj = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v221 @ X9_v4+2A0] (should have been resolved before IL gen)");
					}
				}
				enumerator2.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			PointerEventData pointerEventData = default(PointerEventData);
			if ((IntPtr)pointerEventData == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj3 = default(object);
				if (obj3 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60007CA")]
		[Address(RVA = "0xB4B58C", Offset = "0xB4B58C", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EBC890]);\n\tv25 = *([v24 @ X8_v28]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventData, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202272E]) = v44;\nL_0019:\n\tv48 = this.imagesPool;\n\tv61 = v48._size < 1;\n\tif (v61) goto L_00A8;\n\tv121 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(v48);\nL_0038:\n\tv298 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v86 @ stack_-78_v5 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv175 = v298 == 0;\n\tif (v175) goto L_0077;\n\tgoto L_004B;\n\tv309 = *([v301 @ X0_v26+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_004B;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v301, v296, v133, v29, v30, v31, v32, v33, v84, v67, v65, v63, v38, v39, v40, v41);\nL_004B:\n\tv318 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv324 = v318 == 0;\n\tif (v324) goto L_006A;\n\tv215 = UnityEngine.Behaviour::get_isActiveAndEnabled(this.button);\n\tv332 = v215 == 0;\n\tif (v332) goto L_006A;\n\tv219 = this.button;\n\tv275 = this.button == 0;\n\tif (v275) goto L_0080;\n\tv282 = *([v224 @ stack_-68]);\n\t*([v282 @ X9_v9+2A0])(v289, v224, *([v282 @ X9_v9+2A8]), 0, v29, v30, v31, v32, v33, v219.m_Colors, v219.m_Colors.m_NormalColor.g, v219.m_Colors.m_NormalColor.b, v219.m_Colors.m_NormalColor.a, v38, v39, v40, v41);\n\tgoto L_0038;\nL_006A:\n\tv337 = UnityEngine.UI.Graphic::get_color(this);\n\tv295 = *([v224 @ stack_-68]);\n\t*([v295 @ X8_v22+2A0])(v290, v224, *([v295 @ X8_v22+2A8]), 0, v29, v30, v31, v32, v33, v84, v219.m_Colors.m_NormalColor.g, v219.m_Colors.m_NormalColor.b, v219.m_Colors.m_NormalColor.a, v38, v39, v40, v41);\n\tgoto L_0038;\nL_0077:\n\tv172 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v86 @ stack_-78_v5 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_00A8;\n\tv340 = new System.NullReferenceException();\n\tv109 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0080:\n\tv278 = new System.NullReferenceException();\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\nL_0093:\n\tv153 = v263 != 1;\n\tif (v153) goto L_00A9;\n\tv307 = 0x6D2BC0(v278, v263, v132, v29, v30, v31, v32, v33, v146, v127, v125, v123, v38, v39, v40, v41);\n\tv319 = 0x6D2490(v307, v263, v132, v29, v30, v31, v32, v33, v146, v127, v125, v123, v38, v39, v40, v41);\n\tv171 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v198 @ stack_-60_v4 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv338 = *([v307 @ X0_v11]) == 0;\n\tv174 = ~v338;\n\tif (v174) goto L_00AD;\nL_00A8:\n\treturn;\nL_00A9:\n\tv308 = 0x6D2380(v278, v263, v132, v29, v30, v31, v32, v33, v146, v127, v125, v123, v38, v39, v40, v41);\nL_00AD:\n\tthrow System.TypeLoadException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerExit(PointerEventData eventData)
		{
			List<Image> list = imagesPool;
			if (list.Count < 1)
			{
				return;
			}
			List<Image>.Enumerator enumerator = list.GetEnumerator();
			List<Image>.Enumerator enumerator3 = default(List<Image>.Enumerator);
			List<Image>.Enumerator enumerator2 = enumerator3;
			object obj2 = default(object);
			while (true)
			{
				if (enumerator3.MoveNext())
				{
					if (this.button != null && this.button.isActiveAndEnabled)
					{
						Button button = this.button;
						if ((object)this.button == null)
						{
							break;
						}
						object obj = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v282 @ X9_v9+2A0] (should have been resolved before IL gen)");
						enumerator2 = (List<Image>.Enumerator)((Selectable)button).m_Colors;
					}
					else
					{
						Color color = base.color;
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ X8_v22+2A0] (should have been resolved before IL gen)");
					}
					continue;
				}
				enumerator3.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			object obj4 = default(object);
			if ((IntPtr)obj4 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				List<Image>.Enumerator enumerator4 = default(List<Image>.Enumerator);
				enumerator4.Dispose();
				object obj5 = default(object);
				if (obj5 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60007CB")]
		[Address(RVA = "0xB4B784", Offset = "0xB4B784", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB3720]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventData, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202272F]) = v44;\nL_0019:\n\tv48 = this.imagesPool;\n\tv49 = this.imagesPool == 0;\n\tif (v49) goto L_0071;\n\tv61 = v48._size < 1;\n\tif (v61) goto L_0096;\n\tv121 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.imagesPool);\nL_0038:\n\tv240 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v86 @ stack_-78_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv162 = v240 == 0;\n\tif (v162) goto L_006A;\n\tgoto L_004B;\n\tv256 = *([v248 @ X0_v20+E0]);\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_004B;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v248, v238, v127, v29, v30, v31, v32, v33, v84, v67, v65, v63, v38, v39, v40, v41);\nL_004B:\n\tv228 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv232 = v228 == 0;\n\tif (v232) goto L_0038;\n\tv229 = UnityEngine.Behaviour::get_isActiveAndEnabled(this.button);\n\tv233 = v229 == 0;\n\tif (v233) goto L_0038;\n\tv274 = this.button;\n\tv221 = *([v178 @ stack_-68]);\n\t*([v221 @ X9_v4+2A0])(v230, v178, *([v221 @ X9_v4+2A8]), 0, v29, v30, v31, v32, v33, v274.m_Colors.m_HighlightedColor, v274.m_Colors.m_HighlightedColor.g, v274.m_Colors.m_HighlightedColor.b, v274.m_Colors.m_HighlightedColor.a, v38, v39, v40, v41);\n\tgoto L_0038;\nL_006A:\n\tv159 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v86 @ stack_-78_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_0096;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv109 = new System.NullReferenceException();\nL_0071:\n\tv116 = new System.NullReferenceException();\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\n\tgoto L_0081;\nL_0081:\n\tv140 = v88 != 1;\n\tif (v140) goto L_0097;\n\tv241 = 0x6D2BC0(v116, v88, 0, v29, v30, v31, v32, v33, v83, v66, v64, v62, v38, v39, v40, v41);\n\tv244 = 0x6D2490(v241, v88, 0, v29, v30, v31, v32, v33, v83, v66, v64, v62, v38, v39, v40, v41);\n\tv158 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v77 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv263 = *([v241 @ X0_v10]) == 0;\n\tv161 = ~v263;\n\tif (v161) goto L_009B;\nL_0096:\n\treturn;\nL_0097:\n\tv242 = 0x6D2380(v116, v88, 0, v29, v30, v31, v32, v33, v83, v66, v64, v62, v38, v39, v40, v41);\nL_009B:\n\tthrow System.TypeLoadException;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnSelect(BaseEventData eventData)
		{
			List<Image> list = imagesPool;
			bool flag = imagesPool == null;
			List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
			List<Image>.Enumerator enumerator = enumerator2;
			if (!flag)
			{
				if (list.Count < 1)
				{
					return;
				}
				List<Image>.Enumerator enumerator3 = imagesPool.GetEnumerator();
				object obj2 = default(object);
				while (enumerator2.MoveNext())
				{
					if (this.button != null && this.button.isActiveAndEnabled)
					{
						Button button = this.button;
						object obj = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v221 @ X9_v4+2A0] (should have been resolved before IL gen)");
					}
				}
				enumerator2.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			BaseEventData baseEventData = default(BaseEventData);
			if ((IntPtr)baseEventData == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj3 = default(object);
				if (obj3 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60007CC")]
		[Address(RVA = "0xB4B938", Offset = "0xB4B938", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED1D50]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022730]) = v42;\nL_0017:\n\tUnityEngine.EventSystems.UIBehaviour::Start(this);\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tv50 = this.inspectorIconList;\n\tthis.button = v49;\n\tv51 = this.inspectorIconList == 0;\n\tif (v51) goto L_005D;\n\tv161 = v50.Length;\n\tv53 = v50.Length == 0;\n\tif (v53) goto L_005D;\n\tv71 = v50.Length < 1;\n\tif (v71) goto L_005D;\nL_0033:\n\tv176 = v133 < v161;\n\tv152 = ~v176;\n\tif (v152) goto L_0060;\n\tv59 = v133 << 4;\n\tv180 = this.inspectorIconList + v59;\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>::Add(this.iconList, *([v180 @ X8_v8+20]), v50[v133 @ X9_v3 (System.Int32)].sprite);\n\tv161 = v50.Length;\n\tv133 = v133 + 1;\n\tv69 = v133 < v50.Length;\n\tif (v69) goto L_0033;\nL_005D:\n\tEasyMobile.Internal.Privacy.EditorConsentDialogClickableText::ResetHrefInfos(this);\n\treturn;\n\tv178 = new System.NullReferenceException();\nL_0060:\n\tv179 = new System.IndexOutOfRangeException();\n\tthrow v179;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Start()
		{
			//IL_007b: Expected O, but got I
			//IL_00a5: Expected O, but got I
			base.Start();
			Button component = GetComponent<Button>();
			IconName[] array = inspectorIconList;
			button = component;
			if (inspectorIconList != null)
			{
				int num = array.Length;
				if (array.Length != 0 && array.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							int num3 = num2 << 4;
							object obj = (long)(IntPtr)inspectorIconList + (long)num3;
							Dictionary<string, Sprite> dictionary = iconList;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X8_v8+20]");
							dictionary.Add((string)0, array[num2].sprite);
							num = array.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < array.Length);
				}
			}
			ResetHrefInfos();
		}

		[Token(Token = "0x60007CD")]
		[Address(RVA = "0xB4BA98", Offset = "0xB4BA98", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBC020]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022731]) = v42;\nL_0016:\n\tv44 = ~this.clearImages;\n\tif (v44) goto L_005B;\n\tv93 = this.culledImagesPool;\nL_0028:\n\tv173 = v158 >= v93._size;\n\tif (v173) goto L_0054;\n\tv191 = v93._size < v158;\n\tv130 = ~v191;\n\tv128 = v93._size - v158;\n\tv124 = v128 == 0;\n\tv192 = ~v124;\n\tv114 = v130 & v192;\n\tif (v114) goto L_0038;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0038:\n\tv202 = v93._items;\n\tgoto L_0048;\n\tv208 = *([v203 @ X0_v16+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0048;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v203, v146, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0048:\n\tUnityEngine.Object::DestroyImmediate(v202[v158 @ X21_v8 (System.Int32)]);\n\tv158 = v158 + 1;\n\tv214 = this.culledImagesPool == 0;\n\tv137 = ~v214;\n\tif (v137) goto L_0028;\n\tthrow System.NullReferenceException;\nL_0054:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Clear(v93);\n\tthis.clearImages = 0;\nL_005B:\n\tv99 = UnityEngine.UI.Text::get_text(this);\n\tv103 = System.String::op_Inequality(this.previousText, v99);\n\tv145 = v103 == 0;\n\tif (v145) goto L_0074;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogClickableText::ResetHrefInfos(this);\n\treturn;\nL_0074:\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Update()
		{
			if (clearImages)
			{
				List<GameObject> list = culledImagesPool;
				int num = 0;
				while (num < list.Count)
				{
					bool flag = list.Count < num;
					bool flag2 = !flag;
					int num2 = list.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					GameObject[] items = list._items;
					UnityEngine.Object.DestroyImmediate(items[num]);
					num++;
					bool flag5 = culledImagesPool == null;
					bool flag6 = !flag5;
					list = culledImagesPool;
					if (!flag6)
					{
						throw new NullReferenceException();
					}
				}
				list.Clear();
				clearImages = false;
			}
			string text = base.text;
			if (previousText != text)
			{
				ResetHrefInfos();
			}
		}

		[Token(Token = "0x60007CE")]
		[Address(RVA = "0xB4A68C", Offset = "0xB4A68C", Length = "0xB20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv36 = *([1ED5618]);\n\tv37 = *([v36 @ X8_v153]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022732]) = v56;\nL_001D:\n\tv58 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText::GetOutputText(this);\n\tthis.outputText = v58;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.imagesVertexIndex);\n\tgoto L_003A;\n\tv406 = *([v336 @ X0_v10 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+E0]);\n\tv407 = v406 == 0;\n\tv408 = ~v407;\n\t// 49 ConditionalJump @b277, v408 @ TEMP_v159\n\tv431 = \"il2cpp_codegen_runtime_class_init\"(v336, v64, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv410 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText;\nL_003A:\n\tv389 = System.Text.RegularExpressions.Regex::Matches(v403.regex, this.outputText);\n\tv460 = System.Text.RegularExpressions.MatchCollection::GetEnumerator(v389);\nL_004C:\n\tgoto L_0073;\n\tv839 = *([v763 @ X8_v56+B0]);\n\tv840 = 0;\n\tv841 = v839 + 8;\n\tv843 = *([v946 @ X11_v37-8]);\n\tv951 = v843 == v764;\n\tif (v951) goto L_006C;\n\tv863 = v945 + 1;\n\tv1007 = v863 < v765;\n\tv861 = ~v1007;\n\tv865 = v946 + 0x10;\n\tv845 = ~v861;\n\tif (v845) goto L_FFFFFFFF;\n\tv866 = v560;\n\tv867 = 0;\n\tv868 = 0x8909C4(v866, v764, v867, v705, v42, v43, v44, v45, v700, v691, v689, v675, v50, v51, v52, v53);\n\tgoto L_0073;\nL_006C:\n\tv1008 = *([v946 @ X11_v37]);\n\tv1009 = v1008 << 4;\n\tv1010 = v763 + v1009;\n\tv1011 = v1010 + 0x130;\nL_0073:\n\tv1032 = System.Collections.IEnumerator::MoveNext(v460);\n\tv1034 = v1032 == 0;\n\tif (v1034) goto L_FFFFFFFF;\n\tv1085 = *([v460 @ X0_v14 (System.Collections.IEnumerator)]);\n\tv1088 = *([v1085 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v1088) goto L_0099;\n\tv1333 = *([v1085 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_007F:\n\t;\n\tv1338 = *([v1333 @ X11_v32-8]) == System.Collections.IEnumerator;\n\tif (v1338) goto L_009B;\n\tv1332 = v1332 + 1;\n\tv1398 = v1332 < *([v1085 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv1191 = ~v1398;\n\tv1333 = v1333 + 0x10;\n\tv1175 = ~v1191;\n\tif (v1175) goto L_007F;\nL_0099:\n\tv1417 = System.Predicate`1<UnityEngine.UI.Image>::.ctor(v460, System.Collections.IEnumerator, 1);\n\tgoto L_00A0;\nL_009B:\n\t;\n\tv1400 = *([v1333 @ X11_v32]) + 1;\n\tv1401 = v1400 << 4;\n\tv1402 = v1085 + v1401;\n\tv1417 = v1402 + 0x130;\nL_00A0:\n\t;\n\t*([v1417 @ X0_v97 (System.Predicate`1<UnityEngine.UI.Image>)])(v1422, v460, *([v1417 @ X0_v97 (System.Predicate`1<UnityEngine.UI.Image>)+8]), v1415, Il2CppMethodInfo, v42, v43, v44, v45, v793, v787, v785, v2657.w, v50, v51, v52, v53);\n\tgoto L_FFFFFFFF;\n\tv1718 = v1718_asT == 0;\n\tif (v1718) goto L_02AE;\n\tv1992 = *([v1422 @ X0_v99+18]) & 0x3FFFFFFF;\n\tv1993 = v1992 << 2;\n\tv1995 = 3 | v1993;\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.imagesVertexIndex, v1995);\n\tgoto L_00E1;\n\tv2125 = *([v2073 @ X0_v133 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+<>c>)+E0]);\n\tv2126 = v2125 == 0;\n\tv2127 = ~v2126;\n\tif (v2127) goto L_00E1;\n\tv2188 = \"il2cpp_codegen_runtime_class_init\"(v2073, v1995, v1996, v705, v42, v43, v44, v45, v700, v691, v689, v675, v50, v51, v52, v53);\n\tv2129 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+<>c;\nL_00E1:\n\tv1128 = v2132.<>9__31_0;\n\tv2134 = v2132.<>9__31_0 == 0;\n\tv2135 = ~v2134;\n\tif (v2135) goto L_0109;\n\tgoto L_00F4;\n\tv2266 = *([v2128 @ X0_v134 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+<>c>)+E0]);\n\tv2267 = v2266 == 0;\n\tv2268 = ~v2267;\n\tif (v2268) goto L_00F4;\n\tv2270 = \"il2cpp_codegen_runtime_class_init\"(v2128, v1995, v1996, v705, v42, v43, v44, v45, v700, v691, v689, v675, v50, v51, v52, v53);\n\tv2390 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+<>c;\n\tv2272 = *([v2390 @ X8_v145+B8]);\nL_00F4:\n\tv2276 = new System.Predicate`1<UnityEngine.UI.Image>();\n\tSystem.Predicate`1<UnityEngine.UI.Image>::.ctor(v2276, v2271.<>9, Il2CppMethodInfo);\n\tv2201.<>9__31_0 = v2276;\nL_0109:\n\tv2036 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::RemoveAll(this.imagesPool, v1128);\n\tv2040 = this.imagesPool;\n\tv2393 = v2040._size == 0;\n\tv2394 = ~v2393;\n\tif (v2394) goto L_0117;\n\tUnityEngine.Component::GetComponentsInChildren(this, v2040);\nL_0117:\n\tv2120 = this.imagesVertexIndex;\n\tv2172 = this.imagesPool;\n\tv1134 = v2120._size <= v2172._size;\n\tif (v1134) goto L_01C8;\n\tgoto L_0144;\n\tv2430 = *([v2417 @ X0_v175+E0]);\n\tv2431 = v2430 == 0;\n\tv2432 = ~v2431;\n\tif (v2432) goto L_0144;\n\tv2434 = \"il2cpp_codegen_runtime_class_init\"(v2417, v2112, v1157, v706, v42, v43, v44, v45, v2416, v691, v689, v675, v50, v51, v52, v53);\nL_0144:\n\tv1105 = 0;\n\tv2439 = UnityEngine.UI.DefaultControls::CreateImage(&v1105 @ stack_-E0_v32 (System.Int32));\n\tv1163 = UnityEngine.Component::get_gameObject(this);\n\tv1316 = UnityEngine.GameObject::get_layer(v1163);\n\tUnityEngine.GameObject::set_layer(v2439, v1316);\n\tv2454 = UnityEngine.GameObject::get_transform(v2439);\n\tv2457 = v2454 == 0;\n\tif (v2457) goto L_FFFFFFFF;\n\tv2478 = *([v2454 @ X0_v184 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v2478) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0174;\nL_0174:\n\tgoto L_017C;\n\tv2503 = *([v2495 @ X0_v185+E0]);\n\tv2504 = v2503 == 0;\n\tv2505 = ~v2504;\n\tgoto L_017C;\n\tv2507 = \"il2cpp_codegen_runtime_class_init\"(v2495, v2453, v2065, v706, v42, v43, v44, v45, v1123, v1115, v1113, v675, v50, v51, v52, v53);\nL_017C:\n\tv2511 = UnityEngine.Object::op_Implicit(v2054);\n\tv2522 = v2511 == 0;\n\tif (v2522) goto L_01BF;\n\tv2068 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv2069 = v2054 == 0;\n\tif (v2069) goto L_02DA;\n\tUnityEngine.Transform::SetParent(v2054, v2068);\n\tgoto L_0196;\n\tv2625 = *([v2620 @ X0_v196+E0]);\n\tv2626 = v2625 == 0;\n\tv2627 = ~v2626;\n\tif (v2627) goto L_0196;\n\tv2629 = \"il2cpp_codegen_runtime_class_init\"(v2620, v2066, v2574, v706, v42, v43, v44, v45, v1123, v1115, v1113, v675, v50, v51, v52, v53);\nL_0196:\n\tv2633 = UnityEngine.Vector3::get_zero();\n\tUnityEngine.Transform::set_localPosition(v2054, v2633);\n\tgoto L_01AA;\n\tv2651 = *([v2647 @ X0_v200+E0]);\n\tv2652 = v2651 == 0;\n\tv2653 = ~v2652;\n\tif (v2653) goto L_01AA;\n\tv2655 = \"il2cpp_codegen_runtime_class_init\"(v2647, v2642, v2574, v706, v42, v43, v44, v45, v2633, v2639, v2640, v675, v50, v51, v52, v53);\nL_01AA:\n\tv2657 = UnityEngine.Quaternion::get_identity();\n\tUnityEngine.Transform::set_localRotation(v2054, v2657);\n\tv793 = UnityEngine.Vector3::get_one();\n\tv787 = v793.y;\n\tv1476 = v793.z;\n\tUnityEngine.Transform::set_localScale(v2054, v793);\nL_01BF:\n\tv1519 = UnityEngine.GameObject::GetComponent(v2439);\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::Add(this.imagesPool, v1519);\nL_01C8:\n\tv2256 = *([v1422 @ X0_v99]);\n\t*([v2256 @ X8_v89+180])(v2252, v1422, *([v2256 @ X8_v89+188]), v2246, Il2CppMethodInfo, v42, v43, v44, v45, v793, v787, v785, v2657.w, v50, v51, v52, v53);\n\tv2318 = System.Text.RegularExpressions.GroupCollection::get_Item(v2252, 1);\n\tv2366 = System.Text.RegularExpressions.Capture::get_Value(v2318);\n\tv2370 = this.imagesVertexIndex;\n\tv2395 = this.imagesPool;\n\tv797 = v2370._size - 1;\n\tv2450 = v2395._size < v797;\n\tv819 = ~v2450;\n\tv817 = v2395._size - v797;\n\tv813 = v817 == 0;\n\tv2451 = ~v813;\n\tv803 = v819 & v2451;\n\tif (v803) goto L_01EE;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01EE:\n\tv2456 = v2395._items;\n\tv669 = v2456[v797 @ X23_v39 (System.Int32)];\n\tgoto L_0202;\n\tv2480 = *([v2458 @ X0_v145+E0]);\n\tv2481 = v2480 == 0;\n\tv2482 = ~v2481;\n\tif (v2482) goto L_0202;\n\tv2484 = \"il2cpp_codegen_runtime_class_init\"(v2458, v828, v826, v706, v42, v43, v44, v45, v793, v787, v785, v676, v50, v51, v52, v53);\nL_0202:\n\tv2487 = UnityEngine.Object::op_Equality(*([v669 @ X21_v39 (UnityEngine.UI.Graphic)+C0]), 0);\n\tv2500 = v2487 == 0;\n\tv2501 = ~v2500;\n\tif (v2501) goto L_0212;\n\tv2524 = UnityEngine.Object::get_name(*([v669 @ X21_v39 (UnityEngine.UI.Graphic)+C0]));\n\tv2517 = System.String::op_Inequality(v2524, v2366);\n\tv2519 = v2517 == 0;\n\tif (v2519) goto L_0250;\nL_0212:\n\tv1850 = this.inspectorIconList;\n\tv2520 = this.inspectorIconList == 0;\n\tif (v2520) goto L_0250\n// ... truncated")]
		protected unsafe void UpdateQuadImage()
		{
			//IL_09b1: Expected I, but got O
			//IL_0048: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_0124: Expected O, but got I
			//IL_0133: Expected O, but got I
			//IL_00d1: Expected O, but got I
			//IL_0284: Expected O, but got Ref
			//IL_0575: Expected O, but got I
			//IL_05c2: Expected O, but got I
			//IL_0451: Expected I4, but got F4
			//IL_09e8: Expected I, but got O
			//IL_0a2a: Expected I, but got O
			//IL_06c2: Expected O, but got I
			//IL_06d8: Expected O, but got I
			//IL_093c: Expected O, but got I
			//IL_094c: Expected O, but got I
			//IL_0977: Expected F4, but got I
			string text = GetOutputText();
			outputText = text;
			imagesVertexIndex.Clear();
			MatchCollection matchCollection = regex.Matches(outputText);
			IEnumerator enumerator = matchCollection.GetEnumerator();
			IntPtr intPtr2;
			int num5;
			Vector2 sizeDelta = default(Vector2);
			Vector3 vector = default(Vector3);
			float num10 = default(float);
			Vector2 anchoredPosition = default(Vector2);
			object obj5 = default(object);
			NullReferenceException ex2 = default(NullReferenceException);
			Predicate<Image> predicate3 = default(Predicate<Image>);
			GroupCollection groupCollection = default(GroupCollection);
			NullReferenceException ex3;
			Transform transform3;
			Predicate<Image> predicate2;
			while (true)
			{
				int num4;
				if (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00ea;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1333 @ X11_v32-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00ea;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					Predicate<Image> predicate = (Predicate<Image>)((long)(IntPtr)obj3 + 304L);
					num4 = 0;
					goto IL_0f41;
				}
				intPtr2 = (IntPtr)null;
				num5 = 0;
				break;
				IL_0749:
				Image[] items;
				int num6;
				IconName[] array;
				int num7;
				items[num6].sprite = array[num7].sprite;
				IntPtr intPtr3 = default(IntPtr);
				goto IL_077c;
				IL_073a:
				intPtr3 = default(IntPtr);
				goto IL_077c;
				IL_077c:
				RectTransform rectTransform = items[num6].rectTransform;
				int num8 = base.fontSize;
				int num9 = base.fontSize;
				sizeDelta.x = vector.x;
				sizeDelta.y = num10;
				rectTransform.sizeDelta = sizeDelta;
				items[num6].enabled = true;
				List<Vector2> list = positions;
				List<Image> list2 = imagesPool;
				bool flag3 = list.Count != list2.Count;
				int num11 = num9;
				float num12 = num10;
				Vector3 vector2 = vector;
				if (!flag3)
				{
					RectTransform rectTransform2 = items[num6].rectTransform;
					List<int> list3 = imagesVertexIndex;
					List<Vector2> list4 = positions;
					int num13 = list3.Count - 1;
					bool flag4 = list4.Count < num13;
					bool flag5 = !flag4;
					int num14 = list4.Count - num13;
					bool flag6 = num14 == 0;
					bool flag7 = !flag6;
					if (!(flag5 && flag7))
					{
						throw new ArgumentOutOfRangeException();
					}
					Vector2[] items2 = list4._items;
					int num15 = num13 << 3;
					object obj4 = (long)(IntPtr)list4._items + (long)num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ X8_v102+20]");
					vector2 = (Vector3)0;
					num12 = items2[num13].y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ X8_v102+20]");
					anchoredPosition.x = 0f;
					anchoredPosition.y = items2[num13].y;
					rectTransform2.anchoredPosition = anchoredPosition;
					num11 = num9;
				}
				continue;
				IL_09cd:
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
				IL_00ea:
				num4 = 1;
				goto IL_0f41;
				IL_0f41:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1417 @ X0_v97 (System.Predicate`1<UnityEngine.UI.Image>)] (should have been resolved before IL gen)");
				Match match = obj5 as Match;
				if (match != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1422 @ X0_v99+18]");
					int num16 = 0;
					int num17 = num16 << 2;
					int item = 3 | num17;
					imagesVertexIndex.Add(item);
					Predicate<Image> match2 = _003C_003Ec._003C_003E9__31_0;
					if (_003C_003Ec._003C_003E9__31_0 == null)
					{
						match2 = (_003C_003Ec._003C_003E9__31_0 = (Image image) => image == null);
					}
					int num18 = imagesPool.RemoveAll(match2);
					List<Image> list5 = imagesPool;
					bool flag8 = list5.Count == 0;
					bool flag9 = !flag8;
					IntPtr intPtr4 = (IntPtr)0;
					if (!flag9)
					{
						GetComponentsInChildren(list5);
						intPtr4 = (IntPtr)0;
					}
					List<int> list6 = imagesVertexIndex;
					List<Image> list7 = imagesPool;
					if (list6.Count > list7.Count)
					{
						int num19 = 0;
						GameObject gameObject = DefaultControls.CreateImage((DefaultControls.Resources)(&num19));
						GameObject gameObject2 = base.gameObject;
						int layer = gameObject2.layer;
						gameObject.layer = layer;
						Transform transform = gameObject.transform;
						UnityEngine.Object obj6;
						if ((object)transform != null)
						{
							Transform transform2 = (((object)transform.GetType() != typeof(RectTransform)) ? null : transform);
							obj6 = transform2;
						}
						else
						{
							obj6 = null;
						}
						bool flag10 = obj6;
						bool flag11 = !flag10;
						float num20 = 0f;
						num12 = 0f;
						vector2 = default(Vector3);
						if (!flag11)
						{
							RectTransform rectTransform3 = base.rectTransform;
							bool flag12 = (object)obj6 == null;
							transform3 = rectTransform3;
							if (flag12)
							{
								ex2 = (NullReferenceException)(object)new Predicate<Image>(rectTransform3, (IntPtr)ex2);
								bool flag13 = (IntPtr)rectTransform3 != (IntPtr)1;
								ex3 = ex2;
								predicate2 = (Predicate<Image>)(object)ex2;
								if (!flag13)
								{
									intPtr2 = (IntPtr)predicate3;
									num5 = -1;
									break;
								}
								return;
							}
							((Transform)obj6).SetParent((Transform)rectTransform3);
							Vector3 zero = Vector3.zero;
							((Transform)obj6).localPosition = zero;
							Quaternion identity = Quaternion.identity;
							((Transform)obj6).localRotation = identity;
							vector2 = Vector3.one;
							num12 = vector2.y;
							num20 = vector2.z;
							((Transform)obj6).localScale = vector2;
						}
						Image component = gameObject.GetComponent<Image>();
						imagesPool.Add(component);
						num11 = (int)num20;
						intPtr4 = (IntPtr)0;
					}
					object obj7 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2256 @ X8_v89+180] (should have been resolved before IL gen)");
					Group obj8 = groupCollection.get_Item(1);
					string value = obj8.Value;
					List<int> list8 = imagesVertexIndex;
					List<Image> list9 = imagesPool;
					num6 = list8.Count - 1;
					bool flag14 = list9.Count < num6;
					bool flag15 = !flag14;
					int num21 = list9.Count - num6;
					bool flag16 = num21 == 0;
					bool flag17 = !flag16;
					if (!(flag15 && flag17))
					{
						throw new ArgumentOutOfRangeException();
					}
					items = list9._items;
					Graphic graphic = items[num6];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ X21_v39 (UnityEngine.UI.Graphic)+C0]");
					bool flag18 = (UnityEngine.Object)0 == null;
					bool flag19 = !flag18;
					bool flag20 = !flag19;
					IntPtr intPtr5 = default(IntPtr);
					if (!flag20)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ X21_v39 (UnityEngine.UI.Graphic)+C0]");
						string text2 = ((UnityEngine.Object)0).name;
						bool flag21 = text2 != value;
						bool flag22 = !flag21;
						intPtr5 = default(IntPtr);
						intPtr3 = default(IntPtr);
						if (flag22)
						{
							goto IL_077c;
						}
					}
					array = inspectorIconList;
					bool flag23 = inspectorIconList == null;
					intPtr3 = intPtr5;
					if (!flag23)
					{
						int num22 = array.Length;
						bool flag24 = array.Length == 0;
						intPtr3 = intPtr5;
						if (!flag24)
						{
							bool flag25 = array.Length < 1;
							intPtr3 = intPtr5;
							if (!flag25)
							{
								num7 = 0;
								while (num7 < num22)
								{
									int num23 = num7 << 4;
									object obj9 = (long)(IntPtr)inspectorIconList + (long)num23;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2560 @ X8_v105+20]");
									if (!((string)0 == value))
									{
										num22 = array.Length;
										num7++;
										if (num7 < array.Length)
										{
											continue;
										}
										goto IL_073a;
									}
									goto IL_0749;
								}
								goto IL_09cd;
							}
						}
					}
					goto IL_077c;
				}
				InvalidCastException ex4 = new InvalidCastException();
				goto IL_09cd;
			}
			(enumerator as IDisposable)?.Dispose();
			if (num5 + 1 != 0 || intPtr2 == (IntPtr)0)
			{
				List<int> list10 = imagesVertexIndex;
				List<Image> list11 = imagesPool;
				int num24 = list10.Count;
				do
				{
					if (num24 < list11.Count)
					{
						bool flag26 = list11.Count < num24;
						bool flag27 = !flag26;
						int num25 = list11.Count - num24;
						bool flag28 = num25 == 0;
						bool flag29 = !flag28;
						if (!(flag27 && flag29))
						{
							throw new ArgumentOutOfRangeException();
						}
						Image[] items3 = list11._items;
						if ((bool)items3[num24])
						{
							List<Image> list12 = imagesPool;
							bool flag30 = list12.Count < num24;
							bool flag31 = !flag30;
							int num26 = list12.Count - num24;
							bool flag32 = num26 == 0;
							bool flag33 = !flag32;
							if (!(flag31 && flag33))
							{
								throw new ArgumentOutOfRangeException();
							}
							Image[] items4 = list12._items;
							GameObject gameObject3 = items4[num24].gameObject;
							gameObject3.SetActive(value: false);
							List<Image> list13 = imagesPool;
							bool flag34 = list13.Count < num24;
							bool flag35 = !flag34;
							int num27 = list13.Count - num24;
							bool flag36 = num27 == 0;
							bool flag37 = !flag36;
							if (!(flag35 && flag37))
							{
								throw new ArgumentOutOfRangeException();
							}
							Image[] items5 = list13._items;
							GameObject gameObject4 = items5[num24].gameObject;
							gameObject4.hideFlags = HideFlags.HideAndDontSave;
							List<Image> list14 = imagesPool;
							bool flag38 = list14.Count < num24;
							bool flag39 = !flag38;
							int num28 = list14.Count - num24;
							bool flag40 = num28 == 0;
							bool flag41 = !flag40;
							if (!(flag39 && flag41))
							{
								throw new ArgumentOutOfRangeException();
							}
							Image[] items6 = list14._items;
							GameObject item2 = items6[num24].gameObject;
							culledImagesPool.Add(item2);
							List<Image> list15 = imagesPool;
							bool flag42 = list15.Count < num24;
							bool flag43 = !flag42;
							int num29 = list15.Count - num24;
							bool flag44 = num29 == 0;
							bool flag45 = !flag44;
							if (!(flag43 && flag45))
							{
								throw new ArgumentOutOfRangeException();
							}
							Image[] items7 = list15._items;
							bool flag46 = list15.Remove(items7[num24]);
						}
						list11 = imagesPool;
						num24++;
						continue;
					}
					List<GameObject> list16 = culledImagesPool;
					if (list16.Count >= 2)
					{
						clearImages = true;
					}
					return;
				}
				while (imagesPool != null);
				throw new NullReferenceException();
			}
			TypeLoadException ex5 = new TypeLoadException();
			ex3 = null;
			transform3 = null;
			predicate2 = (Predicate<Image>)(object)ex5;
		}

		[Token(Token = "0x60007CF")]
		[Address(RVA = "0xB4C604", Offset = "0xB4C604", Length = "0x6A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv48 = *([1EB6150]);\n\tv49 = *([v48 @ X8_v61]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, toFill, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv67 = 0 | 1;\n\t*([2022733]) = v67;\nL_0025:\n\tv72 = 0x6D26F0(&v506 @ stack_-E0_v18 (UnityEngine.UIVertex), 0, 0x4C, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv77 = 0;\n\tv81 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText::GetOutputText(this);\n\tthis.m_Text = v81;\n\tUnityEngine.UI.Text::OnPopulateMesh(this, toFill);\n\tthis.m_Text = this.m_Text;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::Clear(this.positions);\n\tv236 = 0x6D26F0(&v506 @ stack_-E0_v18 (UnityEngine.UIVertex), 0, 0x4C, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv230 = this.imagesVertexIndex;\nL_0050:\n\tv612 = v205 >= v230._size;\n\tif (v612) goto L_0101;\n\tv710 = v230._size < v205;\n\tv498 = ~v710;\n\tv494 = v230._size - v205;\n\tv486 = v494 == 0;\n\tv711 = ~v486;\n\tv466 = v498 & v711;\n\tif (v466) goto L_0060;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0060:\n\tv160 = this.imagesPool;\n\tv814 = v230._items;\n\tv817 = v160._size < v205;\n\tv196 = ~v817;\n\tv192 = v160._size - v205;\n\tv184 = v192 == 0;\n\tv818 = ~v184;\n\tv164 = v196 & v818;\n\tif (v164) goto L_0077;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0077:\n\tv838 = v160._items;\n\tv219 = UnityEngine.UI.Graphic::get_rectTransform(v838[v205 @ X25_v14 (System.Int32)]);\n\tv452 = UnityEngine.RectTransform::get_sizeDelta(v219);\n\tv1024 = UnityEngine.UI.VertexHelper::get_currentVertCount(toFill);\n\tv467 = v814[v205 @ X25_v14 (System.Int32)] >= v1024;\n\tif (v467) goto L_00FA;\n\tUnityEngine.UI.VertexHelper::PopulateUIVertex(toFill, &v506 @ stack_-E0_v18 (UnityEngine.UIVertex), v814[v205 @ X25_v14 (System.Int32)]);\n\tv1072 = v452 * 0.5f;\n\tv1073 = v452.y * 0.5f;\n\tv1074 = v1072 + v506;\n\tv1075 = v1073 + v411;\n\tv812 = 0;\n\tv1077 = 0x1588A6C(&v812 @ stack_-180_v9 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>), 0, v814[v205 @ X25_v14 (System.Int32)], 0, v53, v54, v55, v56, v1074, v1075, v1072, v1073, v61, v62, v63, v64);\n\tgoto L_00B9;\n\tv1096 = *([v1085 @ X0_v110 (Il2CppClass<UnityEngine.Vector2>)+E0]);\n\tv1097 = v1096 == 0;\n\tv1098 = ~v1097;\n\tif (v1098) goto L_00B9;\n\tv1100 = \"il2cpp_codegen_runtime_class_init\"(v1085, v513, v509, v437, v53, v54, v55, v56, v1074, v1075, v1072, v1073, v61, v62, v63, v64);\nL_00B9:\n\t// 185 MakeStruct v425 @ AGGB4C7D8_0_v12 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v1104 @ stack_-17C (System.Single)\n\t// 186 MakeStruct v422 @ AGGB4C7D8_1_v12 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.imageOffset (UnityEngine.Vector2), this.imageOffset.y (System.Single)\n\tv453 = UnityEngine.Vector2::op_Addition(v425, v422);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::Add(this.positions, v453);\n\tv1039 = v814[v205 @ X25_v14 (System.Int32)] - 3;\n\tUnityEngine.UI.VertexHelper::PopulateUIVertex(toFill, &v506 @ stack_-E0_v18 (UnityEngine.UIVertex), v1039);\n\tv1041 = v814[v205 @ X25_v14 (System.Int32)] < 0x80000003;\n\tif (v1041) goto L_00FA;\nL_00DF:\n\tUnityEngine.UI.VertexHelper::PopulateUIVertex(toFill, &v506 @ stack_-E0_v18 (UnityEngine.UIVertex), v814[v205 @ X25_v14 (System.Int32)]);\n\tv1250 = 0x6D2410(&v1247 @ stack_-168, &v506 @ stack_-E0_v18 (UnityEngine.UIVertex), 0x4C, 0, v53, v54, v55, v56, v453, v453.y, this.imageOffset, this.imageOffset.y, v61, v62, v63, v64);\n\tUnityEngine.UI.VertexHelper::SetUIVertex(toFill, &v1247 @ stack_-168, v1215);\n\tv1215 = v1215 - 1;\n\tv1040 = v1215 > v1039;\n\tif (v1040) goto L_00DF;\nL_00FA:\n\tv230 = this.imagesVertexIndex;\n\tv205 = v205 + 1;\n\tv1068 = this.imagesVertexIndex == 0;\n\tv519 = ~v1068;\n\tif (v519) goto L_0050;\n\tthrow System.NullReferenceException;\nL_0101:\n\tv617 = v230._size == 0;\n\tif (v617) goto L_010F;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(v230);\nL_010F:\n\tv813 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::GetEnumerator(this.hrefInfos);\nL_011E:\n\tv337 = System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::MoveNext(&v812 @ stack_-180_v9 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>));\n\tv866 = v337 == 0;\n\tif (v866) goto L_021D;\n\tSystem.Collections.Generic.List`1<UnityEngine.Rect>::Clear(*([v820 @ stack_-170+20]));\n\tv858 = UnityEngine.UI.VertexHelper::get_currentVertCount(toFill);\n\tv845 = *([v820 @ stack_-170+10]) >= v858;\n\tif (v845) goto L_011E;\n\tv792 = *([v820 @ stack_-170+10]);\n\tUnityEngine.UI.VertexHelper::PopulateUIVertex(toFill, &v506 @ stack_-E0_v18 (UnityEngine.UIVertex), *([v820 @ stack_-170+10]));\n\tgoto L_014E;\n\tv1105 = *([v1089 @ X0_v49+E0]);\n\tv1106 = v1105 == 0;\n\tv1107 = ~v1106;\n\tif (v1107) goto L_014E;\n\tv1109 = \"il2cpp_codegen_runtime_class_init\"(v1089, v1079, v1078, v1082, v53, v54, v55, v56, v295, v293, v285, v283, v267, v265, v63, v64);\nL_014E:\n\tv1113 = UnityEngine.Vector3::get_zero();\n\tv1124 = 0x100E128(&v77 @ stack_-118_v1, 0, *([v820 @ stack_-170+10]), 0, v53, v54, v55, v56, v506, v411, v409, v1113, v1113.y, v1113.z, v63, v64);\n\tv707 = *([v820 @ stack_-170+10]);\n\tgoto L_01D1;\nL_0161:\n\tUnityEngine.UI.VertexHelper::PopulateUIVertex(toFill, &v506 @ stack_-E0_v18 (UnityEngine.UIVertex), v707);\n\tv1253 = 0x100E4C4(&v77 @ stack_-118_v1, 0, v707, 0, v53, v54, v55, v56, v1149, v1147, v1143, v1142, v1138, v1137, v63, v64);\n\tv670 = v506 >= v1149;\n\tif (v670) goto L_01C6;\n\tv1265 = 0x100E4C4(&v77 @ stack_-118_v1, 0, v707, 0, v53, v54, v55, v56, v1149, v1147, v1143, v1142, v1138, v1137, v63, v64);\n\tgoto L_018A;\n\tv1294 = *([v1279 @ X0_v78+E0]);\n\tv1295 = v1294 == 0;\n\tv1296 = ~v1295;\n\tif (v1296) goto L_018A;\n\tv1298 = \"il2cpp_codegen_runtime_class_init\"(v1279, v1264, v695, v655, v53, v54, v55, v56, v1149, v1147, v1143, v1141, v638, v636, v63, v64);\nL_018A:\n\t// 394 MakeStruct v628 @ AGGB4CA0C_0_v10 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1149 @ V0_v13 (UnityEngine.UIVertex), v1147 @ V1_v12, v1143 @ V2_v12\n\tv1304 = UnityEngine.Vector2::op_Implicit(v628);\n\tv1309 = 0x100E390(&v77 @ stack_-118_v1, 0, v707, 0, v53, v54, v55, v56, v1304, v1304.y, v1143, v1142, v1138, v1137, v63, v64);\n\t// 403 MakeStruct v626 @ AGGB4CA28_0_v10 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1304 @ V0_v22 (UnityEngine.Vector2), v1304.y (System.Single), v1143 @ V2_v12\n\tv1311 = UnityEngine.Vector2::op_Implicit(v626);\n\tv701 = 0x10CCF70(&v812 @ stack_-180_v9 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>), 0, v707, 0, v53, v54, v55, v56, v1304, v1304.y, v1311, v1311.y, v1138, v1137, v63, v64);\n\t// 423 MakeStruct v1283 @ AGGB4CA60_1_v10 (UnityEngine.Rect), typeof(UnityEngine.Rect), v812 @ stack_-180_v9 (System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>+Enumerator<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>), v1104 @ stack_-17C (System.Single), 0, v1305 @ stack_-174 (System.Single)\n\tSystem.Collections.Generic.List`1<UnityEngine.Rect>::Add(*([v820 @ stack_-170+20]), v1283);\n\tgoto L_01B4;\n\tv1325 = *([v1321 @ X0_v87+E0]);\n\tv1326 = v1325 == 0;\n\tv1327 = ~v1326;\n\tif (v1327) goto L_01B4;\n\tv1329 = \"il2cpp_codegen_runtime_class_init\"(v1321, v1315, v695, v655, v53, v54, v55, v56, v1316, v1317, v1318, v1319, v638, v636, v63, v64);\nL_01B4:\n\tv1331 = UnityEngine.Vector3::get_zero();\n\tv1291 = 0x100E128(&v77 @ stack_-118_v1, 0, v707, 0, v53, v54, v55, v56, v506, v411, v409, v1331, v1331.y, v1331.z, v63, v64);\n\tgoto L_01C7;\nL_01C6:\n\tv1271 = 0x100E858(&v77 @ stack_-118_v1, 0, v707, 0, v53, v54, v55, v56, v506, v411, v409, v1142, v1138, v1137, v63, v64);\nL_01C7:\n\n// ... truncated")]
		protected unsafe override void OnPopulateMesh(VertexHelper toFill)
		{
			//IL_08d8: Expected O, but got I4
			//IL_03ed: Expected O, but got I
			//IL_04b6: Expected O, but got I4
			//IL_070c: Expected F4, but got O
			//IL_0719: Expected F4, but got O
			//IL_0726: Expected F4, but got O
			//IL_0778: Expected F4, but got O
			//IL_0935: Expected O, but got Ref
			//IL_07cb: Expected F4, but got O
			//IL_0808: Expected O, but got I
			//IL_06ac: Expected O, but got I4
			//IL_0531: Expected F4, but got O
			//IL_053e: Expected F4, but got O
			//IL_054b: Expected F4, but got O
			//IL_059d: Expected F4, but got O
			//IL_05cb: Expected F4, but got O
			//IL_0608: Expected O, but got I
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			object obj = 0;
			string text = GetOutputText();
			m_Text = text;
			base.OnPopulateMesh(toFill);
			m_Text = this.text;
			positions.Clear();
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			List<int> list = imagesVertexIndex;
			int num = 0;
			UIVertex vertex = default(UIVertex);
			object obj2 = default(object);
			List<HrefInfo>.Enumerator enumerator = default(List<HrefInfo>.Enumerator);
			Vector2 vector = default(Vector2);
			float y = default(float);
			Vector2 vector2 = default(Vector2);
			object obj3 = default(object);
			while (num < list.Count)
			{
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				List<Image> list2 = imagesPool;
				int[] items = list._items;
				bool flag5 = list2.Count < num;
				bool flag6 = !flag5;
				int num3 = list2.Count - num;
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				Image[] items2 = list2._items;
				RectTransform rectTransform = items2[num].rectTransform;
				Vector2 sizeDelta = rectTransform.sizeDelta;
				int currentVertCount = toFill.currentVertCount;
				if (items[num] < currentVertCount)
				{
					toFill.PopulateUIVertex(ref vertex, items[num]);
					float num4 = sizeDelta.x * 0.5f;
					float num5 = sizeDelta.y * 0.5f;
					float num6 = num4 + (float)vertex;
					float num7 = num5 + (float)obj2;
					enumerator = default(List<HrefInfo>.Enumerator);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					vector.x = 0f;
					vector.y = y;
					vector2.x = imageOffset.x;
					vector2.y = imageOffset.y;
					Vector2 item = vector + vector2;
					positions.Add(item);
					int num8 = items[num] - 3;
					toFill.PopulateUIVertex(ref vertex, num8);
					if (items[num] >= 2147483651L)
					{
						int num9 = items[num];
						do
						{
							toFill.PopulateUIVertex(ref vertex, items[num]);
							Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
							toFill.SetUIVertex((UIVertex)(&obj3), num9);
							num9--;
						}
						while (num9 > num8);
					}
				}
				list = imagesVertexIndex;
				num++;
				if (imagesVertexIndex == null)
				{
					throw new NullReferenceException();
				}
			}
			if (list.Count != 0)
			{
				list.Clear();
			}
			List<HrefInfo>.Enumerator enumerator2 = hrefInfos.GetEnumerator();
			object obj5 = default(object);
			Vector3 vector4 = default(Vector3);
			Vector3 vector6 = default(Vector3);
			Rect item2 = default(Rect);
			float height = default(float);
			Vector3 vector8 = default(Vector3);
			Vector3 vector10 = default(Vector3);
			Rect item3 = default(Rect);
			object obj8 = default(object);
			List<HrefInfo>.Enumerator enumerator3 = default(List<HrefInfo>.Enumerator);
			object obj9 = default(object);
			while (true)
			{
				if (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+20]");
					((List<Rect>)0).Clear();
					int currentVertCount2 = toFill.currentVertCount;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+10]");
					if (0L >= (long)currentVertCount2)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+10]");
					int num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+10]");
					toFill.PopulateUIVertex(ref vertex, 0);
					Vector3 zero = Vector3.zero;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E128 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x60)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+10]");
					int num11 = 0;
					float z = zero.z;
					float y2 = zero.y;
					Vector3 vector3 = zero;
					object obj4 = obj5;
					object obj6 = 0;
					object obj7 = obj2;
					UIVertex uIVertex = vertex;
					while (true)
					{
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+14]");
						if ((long)num12 >= 0L)
						{
							break;
						}
						int currentVertCount3 = toFill.currentVertCount;
						if (num11 < currentVertCount3)
						{
							toFill.PopulateUIVertex(ref vertex, num11);
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
							if (System.Runtime.CompilerServices.Unsafe.As<UIVertex, UIntPtr>(ref vertex) < System.Runtime.CompilerServices.Unsafe.As<UIVertex, UIntPtr>(ref uIVertex))
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
								vector4.x = (float)uIVertex;
								vector4.y = (float)obj7;
								vector4.z = (float)obj4;
								Vector2 vector5 = vector4;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
								vector6.x = vector5.x;
								vector6.y = vector5.y;
								vector6.z = (float)obj4;
								Vector2 vector7 = vector6;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF70 (inside UnityEngine.RangeAttribute::.ctor +0x29C)");
								item2.x = (float)enumerator;
								item2.y = y;
								item2.width = 0f;
								item2.height = height;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+20]");
								((List<Rect>)0).Add(item2);
								Vector3 zero2 = Vector3.zero;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E128 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x60)");
								z = zero2.z;
								y2 = zero2.y;
								vector3 = zero2;
								obj4 = obj5;
								obj7 = obj2;
								uIVertex = vertex;
							}
							else
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E858 (inside UnityEngine.Bounds::op_Inequality +0x138)");
								obj4 = obj5;
								obj7 = obj2;
								uIVertex = vertex;
							}
							int num13 = num11 + 1;
							obj6 = 0;
							num10 = num11;
							num11 = num13;
							continue;
						}
						break;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
					vector8.x = (float)uIVertex;
					vector8.y = (float)obj7;
					vector8.z = (float)obj4;
					Vector2 vector9 = vector8;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
					vector10.x = vector9.x;
					vector10.y = vector9.y;
					vector10.z = (float)obj4;
					Vector2 vector11 = vector10;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF70 (inside UnityEngine.RangeAttribute::.ctor +0x29C)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+20]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						item3.x = (float)enumerator;
						item3.y = y;
						item3.width = 0f;
						item3.height = height;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ stack_-170+20]");
						((List<Rect>)0).Add(item3);
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)obj8 != (IntPtr)1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						break;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					enumerator3.Dispose();
					if (obj9 != null)
					{
						break;
					}
				}
				else
				{
					enumerator.Dispose();
				}
				UpdateQuadImage();
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60007D0")]
		[Address(RVA = "0xB4BBB4", Offset = "0xB4BBB4", Length = "0xA50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EDCE20]);\n\tv35 = *([v34 @ X8_v156]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022734]) = v54;\nL_0021:\n\tgoto L_0029;\n\tv61 = *([v57 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0029;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText;\nL_0029:\n\tv69 = v68.textBuilder;\n\tSystem.Text.StringBuilder::set_Length(v68.textBuilder, 0);\n\tv216 = UnityEngine.UI.Text::get_text(this);\n\tv174 = this.inspectorIconList;\n\tthis.fixedString = v216;\n\tv217 = this.inspectorIconList == 0;\n\tif (v217) goto L_0104;\n\tv540 = v174.Length;\n\tv283 = v174.Length == 0;\n\tif (v283) goto L_0104;\n\tv293 = v174.Length < 1;\n\tif (v293) goto L_0104;\nL_0050:\n\tv542 = v109 < v540;\n\tv169 = ~v542;\n\tif (v169) goto L_02CB;\n\tv104 = v109 << 4;\n\tv593 = this.inspectorIconList + v104;\n\tv594 = *([v593 @ X8_v128+20]) == 0;\n\tif (v594) goto L_00F0;\n\tv685 = System.String::op_Inequality(*([v593 @ X8_v128+20]), *([v236 @ X23_v53 (System.String)]));\n\tv698 = v685 == 0;\n\tif (v698) goto L_00F0;\n\t// 107 NewArr v192 @ X0_v191 (System.Object[]), typeof(System.Object[]), 5\n\tv1100 = *([v290 @ X26_v42 (System.String)]) == 0;\n\tif (v1100) goto L_0078;\n\t// 116 IsInst v69 @ X0_v4 (System.Text.StringBuilder), typeof(System.Object), [v290 @ X26_v42 (System.String)]\nL_0078:\n\tv635 = v192.Length == 0;\n\tif (v635) goto L_02CB;\n\tv192[0] = *([v290 @ X26_v42 (System.String)]);\n\t// 127 IsInst v69 @ X0_v4 (System.Text.StringBuilder), typeof(System.Object), [v593 @ X8_v128+20]\n\tv643 = v192.Length;\n\tv1492 = v192.Length < 1;\n\tv621 = ~v1492;\n\tv618 = v192.Length - 1;\n\tv612 = v618 == 0;\n\tv1493 = ~v621;\n\tv597 = v1493 | v612;\n\tif (v597) goto L_02CB;\n\tv192[1] = *([v593 @ X8_v128+20]);\n\tv1554 = \" size=\" == 0;\n\tif (v1554) goto L_009A;\n\t// 149 IsInst v69 @ X0_v4 (System.Text.StringBuilder), typeof(System.Object), \" size=\"\n\tv643 = v192.Length;\nL_009A:\n\tv1645 = v643 < 2;\n\tv623 = ~v1645;\n\tv620 = v643 - 2;\n\tv614 = v620 == 0;\n\tv1646 = ~v623;\n\tv599 = v1646 | v614;\n\tif (v599) goto L_02CB;\n\tv192[2] = \" size=\";\n\tv1738 = UnityEngine.UI.Text::get_fontSize(this);\n\t// 177 Box v69 @ X0_v4 (System.Text.StringBuilder), typeof(System.Int32), &v1738 @ X0_v201 (System.Int32)\n\tv1867 = v69 == 0;\n\tif (v1867) goto L_00BB;\n\t// 184 IsInst v69 @ X0_v4 (System.Text.StringBuilder), typeof(System.Object), v69 @ X0_v4 (System.Text.StringBuilder)\nL_00BB:\n\tv644 = v192.Length;\n\tv1920 = v192.Length < 3;\n\tv622 = ~v1920;\n\tv619 = v192.Length - 3;\n\tv613 = v619 == 0;\n\tv1921 = ~v622;\n\tv598 = v1921 | v613;\n\tif (v598) goto L_02CB;\n\tv192[3] = v69;\n\tv1964 = \" width=1 />\" == 0;\n\tif (v1964) goto L_00D7;\n\t// 206 IsInst v69 @ X0_v4 (System.Text.StringBuilder), typeof(System.Object), \" width=1 />\"\n\tv644 = v192.Length;\n\tgoto L_00D7;\nL_00D7:\n\tv2035 = v644 < 4;\n\tv254 = ~v2035;\n\tv252 = v644 - 4;\n\tv248 = v252 == 0;\n\tv2036 = ~v254;\n\tv238 = v2036 | v248;\n\tif (v238) goto L_02CB;\n\tv192[4] = \" width=1 />\";\n\tv267 = System.String::Concat(v192);\n\tv697 = System.String::Replace(this.fixedString, *([v593 @ X8_v128+20]), v267);\n\tthis.fixedString = v697;\nL_00F0:\n\tv540 = v174.Length;\n\tv109 = v109 + 1;\n\tv292 = v109 < v174.Length;\n\tif (v292) goto L_0050;\nL_0104:\n\tgoto L_0111;\n\tv362 = *([v320 @ X0_v104 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+E0]);\n\tv363 = v362 == 0;\n\tv364 = ~v363;\n\t// 264 ConditionalJump @b250, v364 @ TEMP_v117\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v320, v190, v185, v88, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv366 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText;\nL_0111:\n\tv193 = System.Text.RegularExpressions.Regex::Matches(v205.hrefRegex, this.fixedString);\n\tv646 = System.Text.RegularExpressions.MatchCollection::GetEnumerator(v193);\n\tgoto L_0298;\nL_0121:\n\tv1310 = *([v1381 @ X21_v1 (System.Collections.IEnumerator)]);\n\tv1313 = *([v1310 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v1313) goto L_0143;\n\tv1497 = *([v1310 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0129:\n\t;\n\tv1511 = *([v1497 @ X11_v45-8]) == *([v871 @ X28_v37 (Il2CppClass<System.Collections.IEnumerator>)]);\n\tif (v1511) goto L_0145;\n\tv1496 = v1496 + 1;\n\tv1584 = v1496 < *([v1310 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv1454 = ~v1584;\n\tv1497 = v1497 + 0x10;\n\tv1438 = ~v1454;\n\tif (v1438) goto L_0129;\nL_0143:\n\t;\n\tgoto L_014A;\nL_0145:\n\t;\n\tv1586 = *([v1497 @ X11_v45]) + 1;\n\tv1587 = v1586 << 4;\n\tv1588 = v1310 + v1587;\n\tv69 = v1588 + 0x130;\nL_014A:\n\t;\n\tv69 = System.Collections.IEnumerator::get_Current(v1381);\n\tv516 = v69 == 0;\n\tif (v516) goto L_0173;\n\tv519 = *([v69 @ X0_v4 (System.Text.StringBuilder)]);\n\tv512 = *([v869 @ X25_v37 (Il2CppClass<System.Text.RegularExpressions.Match>)]);\n\tv1681 = *([v519 @ X8_v118+128]) < *([v512 @ X1_v73 (System.String)+128]);\n\tv503 = ~v1681;\n\tv479 = ~v503;\n\tif (v479) goto L_02D2;\n\tv468 = *([v512 @ X1_v73 (System.String)+128]) << 3;\n\tv1765 = *([v519 @ X8_v118+C8]) + v468;\n\tv480 = *([v1765 @ X8_v120-8]) != v512;\n\tif (v480) goto L_02D2;\nL_0173:\n\tgoto L_0180;\n\tv1767 = *([v1683 @ X0_v116 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+E0]);\n\tv1768 = v1767 == 0;\n\tv1769 = ~v1768;\n\t// 375 ConditionalJump @b253, v1769 @ TEMP_v115\n\tv1831 = \"il2cpp_codegen_runtime_class_init\"(v1683, v582, v510, v460, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1770 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText;\nL_0180:\n\t;\n\tv734 = *([v69 @ X0_v4 (System.Text.StringBuilder)+18]) - v1423;\n\tv738 = System.String::Substring(this.fixedString, v1423, v734);\n\tv69 = System.Text.StringBuilder::Append(v732.textBuilder, v738);\n\tv851 = System.String::Concat(\"<color=\", this.HyperlinkColor, \">\");\n\tv69 = System.Text.StringBuilder::Append(v2014.textBuilder, v851);\n\tv986 = *([v69 @ X0_v4 (System.Text.StringBuilder)]);\n\t*([v986 @ X8_v70+180])(v981, v69, *([v986 @ X8_v70+188]), 0, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1635 = System.Text.RegularExpressions.GroupCollection::get_Item(v981, 1);\n\tv2095 = ~this.isCreatingHrefInfos;\n\tif (v2095) goto L_01F8;\n\tv2100 = new EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo();\n\tEasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo::.ctor(v2100);\n\tgoto L_01C1;\n\tv2121 = *([v2114 @ X0_v160 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+E0]);\n\tv2122 = v2121 == 0;\n\tv2123 = ~v2122;\n\tif (v2123) goto L_01C1;\n\tv2154 = \"il2cpp_codegen_runtime_class_init\"(v2114, v941, v939, v823, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv2125 = EasyMobile.Internal.Privacy.EditorConsentDialogClickableText;\nL_01C1:\n\tv69 = v948.textBuilder;\n\tv1150 = System.Text.StringBuilder::get_Length(v948.textBuilder);\n\tv2178 = v1150 << 2;\n\tv2100.startIndex = v2178;\n\tv69 = v1055.textBuilder;\n\tv2181 = System.Text.StringBuilder::get_Length(v1055.textBuilder);\n\tv1266 = *([v69 @ X0_v4 (System.Text.StringBuilder)]);\n\t*([v1266 @ X8_v109+180])(v1261, v1055.textBuilder, *([v1266 @ X8_v109+188]), 0, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1344 = System.Text.RegularExpressions.GroupCollection::get_Item(v1261, 2);\n\tv2198 = v1344._length + v2181;\n\tv2199 = v2198 << 2;\n\tv1349 = v2199 - 1;\n\tv2100.endIndex = v1349;\n\tv2203 = System.Text.RegularExpressions.Capture::get_Value(v1635);\n\tv2100.name = v2203;\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::Add(this.hrefInfos, v2100);\n\tgoto L_0265;\nL_01F8:\n\tv1620 = this.hrefInfos;\n\tv2113 = v1620._size < 1;\n\tif (v2113) goto L_FFFFFFFF;\n\tv2118 = v1620._size < v870;\n\tv1720 = ~v2118;\n\tv1718 = v1620._size - v870;\n\tv1714 = v1718 == 0;\n\tv2119 = ~v1714;\n\tv1704 = v1720 & v2119;\n\tif (v1704) goto L_0216;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0216:\n\tv2130 = v1620._items;\n\tv1702 = v2130[v870\n// ... truncated")]
		protected string GetOutputText()
		{
			//IL_0443: Expected I, but got O
			//IL_045a: Expected I, but got O
			//IL_0ae8: Expected I, but got O
			//IL_0b98: Expected O, but got I
			//IL_0b26: Expected O, but got I
			//IL_0471: Expected I, but got O
			//IL_0bd4: Expected I, but got O
			//IL_0be2: Expected I, but got O
			//IL_0bad: Expected I4, but got O
			//IL_0bbb: Expected O, but got I
			//IL_0bca: Expected O, but got I
			//IL_00d8: Expected O, but got I
			//IL_04af: Expected O, but got I
			//IL_0b72: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_056c: Expected O, but got I
			//IL_0525: Unknown result type (might be due to invalid IL or missing references)
			//IL_052a: Expected O, but got Unknown
			//IL_0547: Expected O, but got I
			//IL_0556: Expected O, but got I
			//IL_04fb: Expected O, but got I
			//IL_101f: Expected O, but got I
			//IL_05dc: Expected O, but got I
			//IL_0cfe: Expected O, but got I
			//IL_01b7: Expected O, but got I
			//IL_0a1a: Expected I, but got O
			//IL_01ca: Expected O, but got I4
			//IL_01f6: Expected O, but got I4
			//IL_0ede: Expected I, but got O
			//IL_0245: Expected O, but got I
			//IL_0dde: Expected O, but got I
			//IL_0280: Expected O, but got I4
			//IL_02ed: Expected O, but got I4
			//IL_0319: Expected O, but got I4
			//IL_0e3c: Expected O, but got I
			//IL_0a10: Expected I, but got O
			//IL_039b: Expected O, but got I4
			//IL_03e0: Expected O, but got I
			//IL_0d66: Expected O, but got I4
			//IL_0c51: Expected O, but got I4
			//IL_0c59: Expected I, but got O
			//IL_0c67: Expected O, but got I4
			//IL_0c82: Expected I, but got O
			StringBuilder stringBuilder = textBuilder;
			textBuilder.Length = 0;
			string text = base.text;
			IconName[] array = inspectorIconList;
			fixedString = text;
			if (inspectorIconList != null)
			{
				int num = array.Length;
				if (array.Length != 0 && array.Length >= 1)
				{
					int num2 = 0;
					string text2 = "<quad name=";
					string text3 = "";
					while (num2 < num)
					{
						int num3 = num2 << 4;
						object obj = (long)(IntPtr)inspectorIconList + (long)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X8_v128+20]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X8_v128+20]");
							if ((string)0 != text3)
							{
								object[] array2 = new object[5];
								if (text2 != null)
								{
									stringBuilder = (StringBuilder)(text2 as object);
								}
								if (array2.Length == 0)
								{
									break;
								}
								array2[0] = text2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X8_v128+20]");
								stringBuilder = (StringBuilder)(0 as object);
								object obj2 = array2.Length;
								bool flag = array2.Length < 1;
								bool flag2 = !flag;
								object obj3 = array2.Length - 1;
								bool flag3 = obj3 == null;
								bool flag4 = !flag2;
								if (flag4 || flag3)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X8_v128+20]");
								array2[1] = 0;
								if (" size=" != null)
								{
									stringBuilder = (StringBuilder)(" size=" as object);
									obj2 = array2.Length;
								}
								bool flag5 = (long)(IntPtr)obj2 < 2L;
								bool flag6 = !flag5;
								object obj4 = (long)(IntPtr)obj2 - 2L;
								bool flag7 = obj4 == null;
								bool flag8 = !flag6;
								if (flag8 || flag7)
								{
									break;
								}
								array2[2] = " size=";
								int num4 = base.fontSize;
								stringBuilder = (StringBuilder)(object)num4;
								if (stringBuilder != null)
								{
									stringBuilder = (StringBuilder)(stringBuilder as object);
								}
								object obj5 = array2.Length;
								bool flag9 = array2.Length < 3;
								bool flag10 = !flag9;
								object obj6 = array2.Length - 3;
								bool flag11 = obj6 == null;
								bool flag12 = !flag10;
								if (flag12 || flag11)
								{
									break;
								}
								array2[3] = stringBuilder;
								if (" width=1 />" != null)
								{
									stringBuilder = (StringBuilder)(" width=1 />" as object);
									obj5 = array2.Length;
								}
								bool flag13 = (long)(IntPtr)obj5 < 4L;
								bool flag14 = !flag13;
								object obj7 = (long)(IntPtr)obj5 - 4L;
								bool flag15 = obj7 == null;
								bool flag16 = !flag14;
								if (flag16 || flag15)
								{
									break;
								}
								array2[4] = " width=1 />";
								string newValue = string.Concat(array2);
								string obj8 = fixedString;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X8_v128+20]");
								string text4 = obj8.Replace((string)0, newValue);
								fixedString = text4;
								text2 = "<quad name=";
							}
						}
						num = array.Length;
						num2++;
						if (num2 < array.Length)
						{
							continue;
						}
						goto IL_0402;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					goto IL_0c03;
				}
			}
			goto IL_0402;
			IL_0c03:
			throw new TypeLoadException();
			IL_0402:
			MatchCollection matchCollection = hrefRegex.Matches(fixedString);
			IEnumerator enumerator = matchCollection.GetEnumerator();
			IEnumerator enumerator2 = enumerator;
			IntPtr intPtr = (IntPtr)typeof(Match);
			int num5 = 0;
			IntPtr intPtr2 = (IntPtr)typeof(IEnumerator);
			int num6 = 0;
			IntPtr intPtr6;
			IntPtr intPtr7;
			int num14;
			EditorConsentDialogClickableText editorConsentDialogClickableText;
			GroupCollection groupCollection = default(GroupCollection);
			GroupCollection groupCollection2 = default(GroupCollection);
			GroupCollection groupCollection3 = default(GroupCollection);
			List<HrefInfo> list3 = default(List<HrefInfo>);
			string result = default(string);
			GroupCollection groupCollection4 = default(GroupCollection);
			while (true)
			{
				IntPtr intPtr3 = (IntPtr)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ X8_v56 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0b8b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ X8_v56 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj9 = 0L + 8L;
				int num7 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1103 @ X11_v50-8]");
					if ((IntPtr)0 == intPtr2)
					{
						break;
					}
					num7++;
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ X8_v56 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag17 = (long)num8 < 0L;
					bool flag18 = !flag17;
					obj9 = (long)(IntPtr)obj9 + 16L;
					if (!flag18)
					{
						continue;
					}
					goto IL_0b8b;
				}
				int num9 = obj9 << 4;
				object obj10 = (long)intPtr3 + (long)num9;
				stringBuilder = (StringBuilder)((long)(IntPtr)obj10 + 304L);
				goto IL_0f5e;
				IL_0f5e:
				stringBuilder = (StringBuilder)enumerator2.Current;
				if ((uint)((ulong)(long)(IntPtr)stringBuilder & 1uL) != 0)
				{
					IntPtr intPtr4 = (IntPtr)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1310 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1310 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj11 = 0L + 8L;
						int num10 = 0;
						bool flag20;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1497 @ X11_v45-8]");
							if ((IntPtr)0 != intPtr2)
							{
								num10++;
								int num11 = num10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1310 @ X8_v59 (Il2CppClass<System.Collections.IEnumerator>)+126]");
								bool flag19 = (long)num11 < 0L;
								flag20 = !flag19;
								obj11 = (long)(IntPtr)obj11 + 16L;
								continue;
							}
							object obj12 = obj11 + 1;
							int num12 = (int)((long)(IntPtr)obj12 << 4);
							object obj13 = (long)intPtr4 + (long)num12;
							stringBuilder = (StringBuilder)((long)(IntPtr)obj13 + 304L);
							break;
						}
						while (!flag20);
					}
					stringBuilder = (StringBuilder)enumerator2.Current;
					if (stringBuilder != null)
					{
						object obj14 = stringBuilder;
						string text5 = (string)(long)intPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ X8_v118+128]");
						IntPtr intPtr5 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ X1_v73 (System.String)+128]");
						if ((long)intPtr5 >= 0L)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ X1_v73 (System.String)+128]");
							int num13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ X8_v118+C8]");
							object obj15 = 0L + (long)num13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1765 @ X8_v120-8]");
							if ((IntPtr)0 == (IntPtr)text5)
							{
								goto IL_0609;
							}
						}
						throw new InvalidCastException();
					}
					goto IL_0609;
				}
				intPtr6 = (IntPtr)null;
				intPtr7 = (IntPtr)typeof(EditorConsentDialogClickableText);
				num14 = 0;
				editorConsentDialogClickableText = this;
				break;
				IL_0609:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v4 (System.Text.StringBuilder)+18]");
				int length = (int)(-num6);
				string value = fixedString.Substring(num6, length);
				stringBuilder = textBuilder.Append(value);
				string value2 = "<color=" + HyperlinkColor + ">";
				stringBuilder = textBuilder.Append(value2);
				object obj16 = stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v986 @ X8_v70+180] (should have been resolved before IL gen)");
				Group obj17 = groupCollection.get_Item(1);
				if (isCreatingHrefInfos)
				{
					HrefInfo hrefInfo = new HrefInfo();
					stringBuilder = textBuilder;
					int length2 = textBuilder.Length;
					int startIndex = length2 << 2;
					hrefInfo.startIndex = startIndex;
					stringBuilder = textBuilder;
					int length3 = textBuilder.Length;
					object obj18 = stringBuilder;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1266 @ X8_v109+180] (should have been resolved before IL gen)");
					Group obj19 = groupCollection2.get_Item(2);
					int num15 = obj19.Length + length3;
					int num16 = num15 << 2;
					int endIndex = num16 - 1;
					hrefInfo.endIndex = endIndex;
					string value3 = obj17.Value;
					hrefInfo.name = value3;
					hrefInfos.Add(hrefInfo);
					IntPtr intPtr8 = (IntPtr)0;
				}
				else
				{
					List<HrefInfo> list = hrefInfos;
					if (list.Count >= 1)
					{
						bool flag21 = list.Count < num5;
						bool flag22 = !flag21;
						int num17 = list.Count - num5;
						bool flag23 = num17 == 0;
						bool flag24 = !flag23;
						if (!(flag22 && flag24))
						{
							throw new ArgumentOutOfRangeException();
						}
						HrefInfo[] items = list._items;
						HrefInfo hrefInfo2 = items[num5];
						stringBuilder = textBuilder;
						int length4 = textBuilder.Length;
						int startIndex2 = length4 << 2;
						hrefInfo2.startIndex = startIndex2;
						List<HrefInfo> list2 = hrefInfos;
						bool flag25 = list2.Count < num5;
						bool flag26 = !flag25;
						int num18 = list2.Count - num5;
						bool flag27 = num18 == 0;
						bool flag28 = !flag27;
						if (!(flag26 && flag28))
						{
							throw new ArgumentOutOfRangeException();
						}
						stringBuilder = textBuilder;
						HrefInfo[] items2 = list2._items;
						HrefInfo hrefInfo3 = items2[num5];
						int length5 = textBuilder.Length;
						object obj20 = stringBuilder;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1960 @ X8_v95+180] (should have been resolved before IL gen)");
						Group obj21 = groupCollection3.get_Item(2);
						bool flag29 = obj21 == null;
						editorConsentDialogClickableText = this;
						if (flag29)
						{
							NullReferenceException ex2 = new NullReferenceException();
							if (2 == 1)
							{
								((List<HrefInfo>)(object)ex2).Add((HrefInfo)2);
								intPtr6 = (IntPtr)list3;
								list3.Add((HrefInfo)2);
								enumerator2 = enumerator;
								intPtr7 = (IntPtr)typeof(EditorConsentDialogClickableText);
								num14 = -1;
								break;
							}
							((List<HrefInfo>)(object)ex2).Add((HrefInfo)2);
							return result;
						}
						num5++;
						int num19 = obj21.Length + length5;
						int num20 = num19 << 2;
						int endIndex2 = num20 - 1;
						hrefInfo3.endIndex = endIndex2;
						IntPtr intPtr8 = (IntPtr)null;
					}
					else
					{
						IntPtr intPtr8 = (IntPtr)null;
					}
				}
				IntPtr intPtr9 = (IntPtr)typeof(EditorConsentDialogClickableText);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2150 @ X0_v130 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2150 @ X0_v130 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						enumerator2 = enumerator;
						goto IL_0f20;
					}
				}
				enumerator2 = enumerator;
				goto IL_0f20;
				IL_0f20:
				object obj22 = stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1084 @ X9_v51+180] (should have been resolved before IL gen)");
				Group obj23 = groupCollection4.get_Item(2);
				string value4 = obj23.Value;
				stringBuilder = textBuilder.Append(value4);
				stringBuilder = textBuilder;
				stringBuilder = stringBuilder.Append("</color>");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v4 (System.Text.StringBuilder)+1C]");
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v4 (System.Text.StringBuilder)+18]");
				num6 = (int)((long)intPtr10 + 0L);
				continue;
				IL_0b8b:
				((List<HrefInfo>)enumerator2).Add((HrefInfo)(long)intPtr2);
				goto IL_0f5e;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num14 + 1 != 0 || intPtr6 == (IntPtr)0)
			{
				if (editorConsentDialogClickableText.isCreatingHrefInfos)
				{
					editorConsentDialogClickableText.isCreatingHrefInfos = false;
				}
				stringBuilder = (StringBuilder)(long)intPtr7;
				string text6 = editorConsentDialogClickableText.fixedString;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v4 (System.Text.StringBuilder)+B8]");
				object obj24 = 0;
				int length6 = text6.Length - num6;
				string value5 = text6.Substring(num6, length6);
				stringBuilder = ((StringBuilder)obj24).Append(value5);
				return textBuilder.ToString();
			}
			goto IL_0c03;
		}

		[Token(Token = "0x60007D1")]
		[Address(RVA = "0xB4BA14", Offset = "0xB4BA14", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBC510]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022735]) = v38;\nL_0017:\n\tv43 = UnityEngine.UI.Text::get_text(this);\n\tthis.previousText = v43;\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::Clear(this.hrefInfos);\n\tthis.isCreatingHrefInfos = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetHrefInfos()
		{
			string text = base.text;
			previousText = text;
			hrefInfos.Clear();
			isCreatingHrefInfos = true;
		}

		[Token(Token = "0x60007D2")]
		[Address(RVA = "0xB4CD18", Offset = "0xB4CD18", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F08540]);\n\tv21 = *([v20 @ X8_v44]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022736]) = v40;\nL_0017:\n\tthis.HyperlinkColor = \"#0000EE\";\n\tv47 = new System.Collections.Generic.List`1<UnityEngine.UI.Image>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::.ctor(v47);\n\tthis.imagesPool = v47;\n\tv55 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v55);\n\tthis.culledImagesPool = v55;\n\tv63 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v63);\n\tthis.imagesVertexIndex = v63;\n\tv71 = new System.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>();\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Privacy.EditorConsentDialogClickableText+HrefInfo>::.ctor(v71);\n\tthis.hrefInfos = v71;\n\tthis.fixedString = \"\";\n\tthis.outputText = \"\";\n\tv82 = new System.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.Sprite>::.ctor(v82);\n\tthis.iconList = v82;\n\tthis.imageScalingFactor = 1f;\n\tgoto L_005E;\n\tv94 = *([v90 @ X0_v12+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_005E;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v90, v86, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005E:\n\tv102 = UnityEngine.Vector2::get_zero();\n\tthis.imageOffset.x = v102;\n\tthis.imageOffset.y = v102.y;\n\tv107 = new System.Collections.Generic.List`1<UnityEngine.Vector2>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(v107);\n\tthis.isCreatingHrefInfos = 1;\n\tthis.positions = v107;\n\tthis.previousText = \"\";\n\tgoto L_0084;\n\tv120 = *([v116 @ X0_v17+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0084;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v111, v24, v25, v26, v27, v28, v29, v102, v103, v32, v33, v34, v35, v36, v37);\nL_0084:\n\tUnityEngine.UI.Text::.ctor(this);\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogClickableText()
		{
			List<Image> list = new List<Image>();
			imagesPool = list;
			List<GameObject> list2 = new List<GameObject>();
			culledImagesPool = list2;
			imagesVertexIndex = new List<int>();
			hrefInfos = new List<HrefInfo>();
			fixedString = "";
			outputText = "";
			iconList = new Dictionary<string, Sprite>();
			imageScalingFactor = 1f;
			Vector2 zero = Vector2.zero;
			imageOffset.x = zero.x;
			imageOffset.y = zero.y;
			List<Vector2> list3 = new List<Vector2>();
			isCreatingHrefInfos = true;
			positions = list3;
			previousText = "";
			base._002Ector();
		}

		[Token(Token = "0x60007D3")]
		[Address(RVA = "0xB4CEE0", Offset = "0xB4CEE0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF7808]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2022737]) = v39;\nL_0016:\n\tv43 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v43);\n\tv50.textBuilder = v43;\n\tv53 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v53, \"<a href=([^>\\\\n\\\\s]+)>(.*?)(</a>)\", 0x10);\n\tv61.hrefRegex = v53;\n\tv63 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v63, \"<quad name=(.+?) size=(\\\\d*\\\\.?\\\\d+%?) width=(\\\\d*\\\\.?\\\\d+%?) />\", 0x10);\n\tv71.regex = v63;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static EditorConsentDialogClickableText()
		{
			StringBuilder stringBuilder = new StringBuilder();
			textBuilder = stringBuilder;
			Regex regex = new Regex("<a href=([^>\\n\\s]+)>(.*?)(</a>)", RegexOptions.Singleline);
			hrefRegex = regex;
			Regex regex2 = new Regex("<quad name=(.+?) size=(\\d*\\.?\\d+%?) width=(\\d*\\.?\\d+%?) />", RegexOptions.Singleline);
			EditorConsentDialogClickableText.regex = regex2;
		}
	}
}
