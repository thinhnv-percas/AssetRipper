using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EasyMobile
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x731114", Offset = "0x731114")]
	[Attribute(Type = typeof(RequireComponent), RVA = "0x731114", Offset = "0x731114")]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000056")]
	public class ClipPlayerUI : MonoBehaviour, IClipPlayer
	{
		[SerializeField]
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x18")]
		private ClipPlayerScaleMode _scaleMode;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x20")]
		private RawImage rawImage;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform rt;

		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x30")]
		private IEnumerator playCoroutine;

		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x38")]
		private bool isPaused;

		[Token(Token = "0x17000147")]
		public ClipPlayerScaleMode ScaleMode
		{
			[Token(Token = "0x6000447")]
			[Address(RVA = "0xA4F8A0", Offset = "0xA4F8A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._scaleMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleMode;
			}
			[Token(Token = "0x6000448")]
			[Address(RVA = "0xA4F8A8", Offset = "0xA4F8A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._scaleMode = value;\n\treturn;\n")]
			set
			{
				ScaleMode = value;
			}
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0xA4F8B0", Offset = "0xA4F8B0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDDB70]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F58]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.rawImage = v43;\n\tv48 = UnityEngine.Component::GetComponent(this);\n\tthis.rt = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			RawImage component = GetComponent<RawImage>();
			rawImage = component;
			RectTransform component2 = GetComponent<RectTransform>();
			rt = component2;
		}

		[Token(Token = "0x600044A")]
		[Address(RVA = "0xA4F920", Offset = "0xA4F920", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EED078]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021F59]) = v47;\nL_0019:\n\tv48 = clip == 0;\n\tif (v48) goto L_002A;\n\tv49 = clip.<Frames>k__BackingField;\n\tv53 = v49.Length == 0;\n\tif (v53) goto L_002A;\n\tv52 = ~clip.isDisposed;\n\tif (v52) goto L_003F;\nL_002A:\n\tgoto L_003C;\n\tv65 = *([v59 @ X0_v2+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003C;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v59, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\nL_003C:\n\tUnityEngine.Debug::LogError(\"Attempted to play an empty or disposed clip.\");\n\treturn;\nL_003F:\n\tv84 = this.playCoroutine == 0;\n\tif (v84) goto L_0047;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this.playCoroutine);\n\tthis.playCoroutine = 0;\nL_0047:\n\tEasyMobile.ClipPlayerUI::Resize(this, clip);\n\tthis.isPaused = 0;\n\tv119 = EasyMobile.ClipPlayerUI::CRPlay(this, clip, startDelay, loop);\n\tthis.playCoroutine = v119;\n\tv94 = UnityEngine.MonoBehaviour::StartCoroutine(this, v119);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Play(AnimatedClip clip, float startDelay = 0f, bool loop = true)
		{
			if (clip != null)
			{
				Texture[] frames = clip.Frames;
				if (frames.Length != 0 && !clip.isDisposed)
				{
					if (playCoroutine != null)
					{
						StopCoroutine(playCoroutine);
						playCoroutine = null;
					}
					Resize(clip);
					isPaused = false;
					Coroutine coroutine = StartCoroutine(playCoroutine = CRPlay(clip, startDelay, loop));
					return;
				}
			}
			Debug.LogError("Attempted to play an empty or disposed clip.");
		}

		[Token(Token = "0x600044B")]
		[Address(RVA = "0xA4FC58", Offset = "0xA4FC58", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPaused = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pause()
		{
			isPaused = true;
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0xA4FC64", Offset = "0xA4FC64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPaused = 0;\n\treturn;\n")]
		public void Resume()
		{
			isPaused = false;
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0xA4FA34", Offset = "0xA4FA34", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.playCoroutine == 0;\n\tif (v11) goto L_0011;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this.playCoroutine);\n\tthis.playCoroutine = 0;\nL_0011:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Stop()
		{
			if (playCoroutine != null)
			{
				StopCoroutine(playCoroutine);
				playCoroutine = null;
			}
		}

		[Token(Token = "0x600044E")]
		[Address(RVA = "0xA4FA68", Offset = "0xA4FA68", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F00580]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, clip, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021F5A]) = v45;\nL_0017:\n\tv46 = clip == 0;\n\tif (v46) goto L_004F;\n\tv48 = this._scaleMode == 0;\n\tif (v48) goto L_0084;\n\tv61 = this._scaleMode == 2;\n\tv68 = clip.<Width>k__BackingField / clip.<Height>k__BackingField;\n\tif (v61) goto L_0063;\n\tv82 = this._scaleMode != 1;\n\tif (v82) goto L_0084;\n\tv125 = this.rt;\n\tv213 = UnityEngine.RectTransform::get_sizeDelta(this.rt);\n\tv226 = UnityEngine.RectTransform::get_sizeDelta(this.rt);\n\tv238 = v226 / v68;\n\tgoto L_0075;\nL_004F:\n\tgoto L_0061;\n\tv133 = *([v51 @ X0_v2+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0061;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v51, clip, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0061:\n\tUnityEngine.Debug::LogError(\"Could not resize player: clip is null.\");\n\treturn;\nL_0063:\n\tv125 = this.rt;\n\tv198 = UnityEngine.RectTransform::get_sizeDelta(this.rt);\n\tv224 = UnityEngine.RectTransform::get_sizeDelta(this.rt);\n\tv238 = v224.y;\n\tv228 = v68 * v198.y;\n\tv230 = 0;\nL_0075:\n\tv242 = 0x1588A6C(v240, 0, methodInfo, v30, v31, v32, v33, v34, v228, v238, v37, v38, v39, v40, v41, v42);\n\t// 122 MakeStruct v70 @ AGGA4FB9C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v230 @ stack_-28_v3, v243 @ stack_-24\n\tUnityEngine.RectTransform::set_sizeDelta(v125, v70);\nL_0084:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Resize(AnimatedClip clip)
		{
			//IL_014a: Expected O, but got I4
			//IL_0153: Expected O, but got I4
			//IL_0195: Expected F4, but got O
			//IL_01a2: Expected F4, but got O
			if (clip != null)
			{
				if (ScaleMode == ClipPlayerScaleMode.None)
				{
					return;
				}
				bool flag = ScaleMode == ClipPlayerScaleMode.AutoWidth;
				int num = clip.Width / clip.Height;
				RectTransform rectTransform;
				object obj2 = default(object);
				if (!flag)
				{
					if (ScaleMode != ClipPlayerScaleMode.AutoHeight)
					{
						return;
					}
					rectTransform = rt;
					Vector2 sizeDelta = rt.sizeDelta;
					float num2 = rt.sizeDelta.x / (float)num;
					float x = sizeDelta.x;
					object obj = obj2;
				}
				else
				{
					rectTransform = rt;
					Vector2 sizeDelta2 = rt.sizeDelta;
					float num2 = rt.sizeDelta.y;
					float x = (float)num * sizeDelta2.y;
					obj2 = 0;
					obj2 = 0;
					object obj = obj2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Vector2 sizeDelta3 = default(Vector2);
				sizeDelta3.x = (float)obj2;
				object obj3 = default(object);
				sizeDelta3.y = (float)obj3;
				rectTransform.sizeDelta = sizeDelta3;
			}
			else
			{
				Debug.LogError("Could not resize player: clip is null.");
			}
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7347C8", Offset = "0x7347C8")]
		[Token(Token = "0x600044F")]
		[Address(RVA = "0xA4FBBC", Offset = "0xA4FBBC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EB7288]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021F5B]) = v47;\nL_001C:\n\tv51 = new EasyMobile.ClipPlayerUI+<CRPlay>d__14();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.clip = clip;\n\tv51.<>4__this = this;\n\tv51.startDelay = startDelay;\n\tv51.loop = loop;\n\treturn v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CRPlay(AnimatedClip clip, float startDelay, bool loop)
		{
			_003CCRPlay_003Ed__14 _003CCRPlay_003Ed__15 = null;
			_003CCRPlay_003Ed__15._003C_003E1__state = 0;
			_003CCRPlay_003Ed__15.clip = clip;
			_003CCRPlay_003Ed__15._003C_003E4__this = this;
			_003CCRPlay_003Ed__15.startDelay = startDelay;
			_003CCRPlay_003Ed__15.loop = loop;
			return _003CCRPlay_003Ed__15;
		}

		[Token(Token = "0x6000450")]
		[Address(RVA = "0xA4FC98", Offset = "0xA4FC98", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._scaleMode = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ClipPlayerUI()
		{
			ScaleMode = ClipPlayerScaleMode.AutoHeight;
		}
	}
}
