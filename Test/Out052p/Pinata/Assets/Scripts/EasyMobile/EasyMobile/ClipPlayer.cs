using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x73107C", Offset = "0x73107C")]
	[Attribute(Type = typeof(RequireComponent), RVA = "0x73107C", Offset = "0x73107C")]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000054")]
	public class ClipPlayer : MonoBehaviour, IClipPlayer
	{
		[SerializeField]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x18")]
		private ClipPlayerScaleMode _scaleMode;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x20")]
		private Material mat;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x28")]
		private IEnumerator playCoroutine;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x30")]
		private bool isPaused;

		[Token(Token = "0x17000146")]
		public ClipPlayerScaleMode ScaleMode
		{
			[Token(Token = "0x600043D")]
			[Address(RVA = "0xA4F2C8", Offset = "0xA4F2C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._scaleMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleMode;
			}
			[Token(Token = "0x600043E")]
			[Address(RVA = "0xA4F2D0", Offset = "0xA4F2D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._scaleMode = value;\n\treturn;\n")]
			set
			{
				ScaleMode = value;
			}
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0xA4F2D8", Offset = "0xA4F2D8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEFDD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F53]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tv46 = UnityEngine.Renderer::get_material(v43);\n\tthis.mat = v46;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			MeshRenderer component = GetComponent<MeshRenderer>();
			Material material = component.material;
			mat = material;
		}

		[Token(Token = "0x6000440")]
		[Address(RVA = "0xA4F340", Offset = "0xA4F340", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EC7BA8]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021F54]) = v47;\nL_0019:\n\tv48 = clip == 0;\n\tif (v48) goto L_002A;\n\tv49 = clip.<Frames>k__BackingField;\n\tv53 = v49.Length == 0;\n\tif (v53) goto L_002A;\n\tv52 = ~clip.isDisposed;\n\tif (v52) goto L_003F;\nL_002A:\n\tgoto L_003C;\n\tv65 = *([v59 @ X0_v2+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003C;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v59, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\nL_003C:\n\tUnityEngine.Debug::LogError(\"Attempted to play an empty or disposed clip.\");\n\treturn;\nL_003F:\n\tv84 = this.playCoroutine == 0;\n\tif (v84) goto L_0047;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this.playCoroutine);\n\tthis.playCoroutine = 0;\nL_0047:\n\tEasyMobile.ClipPlayer::Resize(this, clip);\n\tthis.isPaused = 0;\n\tv119 = EasyMobile.ClipPlayer::CRPlay(this, clip, startDelay, loop);\n\tthis.playCoroutine = v119;\n\tv94 = UnityEngine.MonoBehaviour::StartCoroutine(this, v119);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000441")]
		[Address(RVA = "0xA4F5EC", Offset = "0xA4F5EC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPaused = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pause()
		{
			isPaused = true;
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0xA4F5F8", Offset = "0xA4F5F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPaused = 0;\n\treturn;\n")]
		public void Resume()
		{
			isPaused = false;
		}

		[Token(Token = "0x6000443")]
		[Address(RVA = "0xA4F454", Offset = "0xA4F454", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.playCoroutine == 0;\n\tif (v11) goto L_0011;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this.playCoroutine);\n\tthis.playCoroutine = 0;\nL_0011:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Stop()
		{
			if (playCoroutine != null)
			{
				StopCoroutine(playCoroutine);
				playCoroutine = null;
			}
		}

		[Token(Token = "0x6000444")]
		[Address(RVA = "0xA4F488", Offset = "0xA4F488", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = this._scaleMode == 0;\n\tif (v19) goto L_0040;\n\tv33 = UnityEngine.Component::get_transform(this);\n\tv119 = clip.<Width>k__BackingField / clip.<Height>k__BackingField;\n\tv121 = UnityEngine.Transform::get_localScale(v33);\n\tv146 = this._scaleMode == 2;\n\tif (v146) goto L_0041;\n\tv160 = this._scaleMode != 1;\n\tif (v160) goto L_0044;\n\tv124 = v121 / v119;\n\tgoto L_0044;\nL_0040:\n\treturn;\nL_0041:\n\tv161 = v119 * v121.y;\nL_0044:\n\tv98 = UnityEngine.Component::get_transform(this);\n\t// 83 MakeStruct v37 @ AGGA4F544_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v161 @ V8_v7 (System.Single), v124 @ V9_v5 (System.Single), v121.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v98, v37);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Resize(AnimatedClip clip)
		{
			if (ScaleMode == ClipPlayerScaleMode.None)
			{
				return;
			}
			Transform transform = base.transform;
			int num = clip.Width / clip.Height;
			Vector3 localScale = transform.localScale;
			float y;
			float x;
			if (ScaleMode != ClipPlayerScaleMode.AutoWidth)
			{
				bool flag = ScaleMode != ClipPlayerScaleMode.AutoHeight;
				y = localScale.y;
				x = localScale.x;
				if (!flag)
				{
					y = localScale.x / (float)num;
					x = localScale.x;
				}
			}
			else
			{
				x = (float)num * localScale.y;
				y = localScale.y;
			}
			Transform transform2 = base.transform;
			Vector3 localScale2 = default(Vector3);
			localScale2.x = x;
			localScale2.y = y;
			localScale2.z = localScale.z;
			transform2.localScale = localScale2;
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x734764", Offset = "0x734764")]
		[Token(Token = "0x6000445")]
		[Address(RVA = "0xA4F550", Offset = "0xA4F550", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F0D7E0]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, clip, loop, methodInfo, v34, v35, v36, v37, startDelay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021F55]) = v47;\nL_001C:\n\tv51 = new EasyMobile.ClipPlayer+<CRPlay>d__13();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.clip = clip;\n\tv51.<>4__this = this;\n\tv51.startDelay = startDelay;\n\tv51.loop = loop;\n\treturn v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CRPlay(AnimatedClip clip, float startDelay, bool loop)
		{
			_003CCRPlay_003Ed__13 _003CCRPlay_003Ed__14 = null;
			_003CCRPlay_003Ed__14._003C_003E1__state = 0;
			_003CCRPlay_003Ed__14.clip = clip;
			_003CCRPlay_003Ed__14._003C_003E4__this = this;
			_003CCRPlay_003Ed__14.startDelay = startDelay;
			_003CCRPlay_003Ed__14.loop = loop;
			return _003CCRPlay_003Ed__14;
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0xA4F62C", Offset = "0xA4F62C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._scaleMode = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ClipPlayer()
		{
			ScaleMode = ClipPlayerScaleMode.AutoHeight;
		}
	}
}
