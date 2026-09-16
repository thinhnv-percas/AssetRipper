using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x749B2C", Offset = "0x749B2C")]
	[Token(Token = "0x2000002")]
	public class DOTweenAnimation : ABSAnimationComponent
	{
		[Token(Token = "0x2000006")]
		public enum AnimationType
		{
			[Token(Token = "0x4000028")]
			None = 0,
			[Token(Token = "0x4000029")]
			Move = 1,
			[Token(Token = "0x400002A")]
			LocalMove = 2,
			[Token(Token = "0x400002B")]
			Rotate = 3,
			[Token(Token = "0x400002C")]
			LocalRotate = 4,
			[Token(Token = "0x400002D")]
			Scale = 5,
			[Token(Token = "0x400002E")]
			Color = 6,
			[Token(Token = "0x400002F")]
			Fade = 7,
			[Token(Token = "0x4000030")]
			Text = 8,
			[Token(Token = "0x4000031")]
			PunchPosition = 9,
			[Token(Token = "0x4000032")]
			PunchRotation = 10,
			[Token(Token = "0x4000033")]
			PunchScale = 11,
			[Token(Token = "0x4000034")]
			ShakePosition = 12,
			[Token(Token = "0x4000035")]
			ShakeRotation = 13,
			[Token(Token = "0x4000036")]
			ShakeScale = 14,
			[Token(Token = "0x4000037")]
			CameraAspect = 15,
			[Token(Token = "0x4000038")]
			CameraBackgroundColor = 16,
			[Token(Token = "0x4000039")]
			CameraFieldOfView = 17,
			[Token(Token = "0x400003A")]
			CameraOrthoSize = 18,
			[Token(Token = "0x400003B")]
			CameraPixelRect = 19,
			[Token(Token = "0x400003C")]
			CameraRect = 20,
			[Token(Token = "0x400003D")]
			UIWidthHeight = 21
		}

		[Token(Token = "0x2000007")]
		public enum TargetType
		{
			[Token(Token = "0x400003F")]
			Unset = 0,
			[Token(Token = "0x4000040")]
			Camera = 1,
			[Token(Token = "0x4000041")]
			CanvasGroup = 2,
			[Token(Token = "0x4000042")]
			Image = 3,
			[Token(Token = "0x4000043")]
			Light = 4,
			[Token(Token = "0x4000044")]
			RectTransform = 5,
			[Token(Token = "0x4000045")]
			Renderer = 6,
			[Token(Token = "0x4000046")]
			SpriteRenderer = 7,
			[Token(Token = "0x4000047")]
			Rigidbody = 8,
			[Token(Token = "0x4000048")]
			Rigidbody2D = 9,
			[Token(Token = "0x4000049")]
			Text = 10,
			[Token(Token = "0x400004A")]
			Transform = 11,
			[Token(Token = "0x400004B")]
			tk2dBaseSprite = 12,
			[Token(Token = "0x400004C")]
			tk2dTextMesh = 13,
			[Token(Token = "0x400004D")]
			TextMeshPro = 14,
			[Token(Token = "0x400004E")]
			TextMeshProUGUI = 15
		}

		[CompilerGenerated]
		[Token(Token = "0x4000001")]
		private static Action<DOTweenAnimation> m_OnReset;

		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x68")]
		public bool targetIsSelf;

		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x70")]
		public GameObject targetGO;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x78")]
		public bool tweenTargetIsTargetGO;

		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x7C")]
		public float delay;

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x80")]
		public float duration;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x84")]
		public Ease easeType;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x88")]
		public AnimationCurve easeCurve;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x90")]
		public LoopType loopType;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x94")]
		public int loops;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x98")]
		public string id;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0xA0")]
		public bool isRelative;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0xA1")]
		public bool isFrom;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0xA2")]
		public bool isIndependentUpdate;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0xA3")]
		public bool autoKill;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0xA4")]
		public bool isActive;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0xA5")]
		public bool isValid;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0xA8")]
		public Component target;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0xB0")]
		public AnimationType animationType;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0xB4")]
		public TargetType targetType;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0xB8")]
		public TargetType forcedTargetType;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0xBC")]
		public bool autoPlay;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0xBD")]
		public bool useTargetAsV3;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0xC0")]
		public float endValueFloat;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0xC4")]
		public Vector3 endValueV3;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0xD0")]
		public Vector2 endValueV2;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0xD8")]
		public Color endValueColor;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0xE8")]
		public string endValueString;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0xF0")]
		public Rect endValueRect;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x100")]
		public Transform endValueTransform;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x108")]
		public bool optionalBool0;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x10C")]
		public float optionalFloat0;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x110")]
		public int optionalInt0;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x114")]
		public RotateMode optionalRotationMode;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x118")]
		public ScrambleMode optionalScrambleMode;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x120")]
		public string optionalString;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x128")]
		private bool _tweenCreated;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x12C")]
		private int _playCount;

		[Token(Token = "0x14000001")]
		public static event Action<DOTweenAnimation> OnReset
		{
			[CompilerGenerated]
			[Token(Token = "0x6000001")]
			[Address(RVA = "0x15B5260", Offset = "0x15B5260", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB6A48]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20298EE]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<DG.Tweening.DOTweenAnimation>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.OnReset, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				Delegate obj = DOTweenAnimation.m_OnReset;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<DOTweenAnimation>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000002")]
			[Address(RVA = "0x15B5314", Offset = "0x15B5314", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EFDA18]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20298EF]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<DG.Tweening.DOTweenAnimation>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.OnReset, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				Delegate obj = DOTweenAnimation.m_OnReset;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<DOTweenAnimation>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x15B53C8", Offset = "0x15B53C8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECFB28]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F0]) = v38;\nL_0018:\n\tv44 = v42.OnReset == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<DG.Tweening.DOTweenAnimation>::Invoke(v42.OnReset, anim);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Dispatch_OnReset(DOTweenAnimation anim)
		{
			if (DOTweenAnimation.OnReset != null)
			{
				DOTweenAnimation.OnReset(anim);
			}
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15B543C", Offset = "0x15B543C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this.isActive;\n\tif (v11) goto L_0024;\n\tv13 = ~this.isValid;\n\tif (v13) goto L_0024;\n\tv17 = this.animationType != 1;\n\tif (v17) goto L_001D;\n\tv54 = ~this.useTargetAsV3;\n\tv45 = ~v54;\n\tif (v45) goto L_0024;\nL_001D:\n\tDG.Tweening.DOTweenAnimation::CreateTween(this);\n\tthis._tweenCreated = 1;\nL_0024:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (isActive && isValid && (animationType != AnimationType.Move || !useTargetAsV3))
			{
				CreateTween();
				_tweenCreated = true;
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15B6B2C", Offset = "0x15B6B2C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this._tweenCreated;\n\tv12 = ~v11;\n\tif (v12) goto L_0018;\n\tv14 = ~this.isActive;\n\tif (v14) goto L_0018;\n\tv18 = ~this.isValid;\n\tif (v18) goto L_0018;\n\tDG.Tweening.DOTweenAnimation::CreateTween(this);\n\tthis._tweenCreated = 1;\nL_0018:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (!_tweenCreated && isActive && isValid)
			{
				CreateTween();
				_tweenCreated = true;
			}
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15B6B70", Offset = "0x15B6B70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.DOTweenAnimation::Dispatch_OnReset(this);\n\treturn;\n")]
		private void Reset()
		{
			Dispatch_OnReset(this);
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x15B6B74", Offset = "0x15B6B74", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.tween == 0;\n\tif (v11) goto L_0012;\n\tv13 = DG.Tweening.TweenExtensions::IsActive(this.tween);\n\tv21 = v13 == 0;\n\tif (v21) goto L_0012;\n\tDG.Tweening.TweenExtensions::Kill(this.tween, 0);\nL_0012:\n\tthis.tween = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (tween != null && tween.IsActive())
			{
				tween.Kill();
			}
			tween = null;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x15B548C", Offset = "0x15B548C", Length = "0x16A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EB17E8]);\n\tv33 = *([v32 @ X8_v110]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20298F1]) = v52;\nL_001B:\n\tv54 = ~this.targetIsSelf;\n\tif (v54) goto L_0022;\n\tv57 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002A;\nL_0022:\n\tv62 = this.targetGO;\nL_002A:\n\tgoto L_0033;\n\tv70 = *([v66 @ X0_v3+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_0033;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, v60, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0033:\n\tv80 = UnityEngine.Object::op_Equality(this.target, 0);\n\tv82 = v80 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_004A;\n\tgoto L_0045;\n\tv100 = *([v84 @ X0_v39+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0045;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v84, v78, v79, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0045:\n\tv225 = UnityEngine.Object::op_Equality(v62, 0);\n\tv95 = v225 == 0;\n\tif (v95) goto L_0099;\nL_004A:\n\tv99 = ~this.targetIsSelf;\n\tif (v99) goto L_006A;\n\tgoto L_005A;\n\tv127 = *([v107 @ X0_v31+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_005A;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v107, v90, v88, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005A:\n\tv117 = UnityEngine.Object::op_Equality(this.target, 0);\n\tv119 = v117 == 0;\n\tif (v119) goto L_006A;\n\tv144 = UnityEngine.Component::get_gameObject(this);\n\tv244 = UnityEngine.Object::get_name(v144);\n\tgoto L_0075;\nL_006A:\n\tv125 = UnityEngine.Component::get_gameObject(this);\n\tv244 = UnityEngine.Object::get_name(v125);\nL_0075:\n\tv254 = System.String::Format(*([v247 @ X8_v10 (System.String)]), v244);\n\tv266 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0097;\n\tv408 = *([v342 @ X8_v14+E0]);\n\tv409 = v408 == 0;\n\tv410 = ~v409;\n\tgoto L_0097;\n\tv443 = v342;\n\tv412 = \"il2cpp_codegen_runtime_class_init\"(v443, v265, v252, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0097:\n\tUnityEngine.Debug::LogWarning(v254, v266);\n\treturn;\nL_0099:\n\tv158 = this.forcedTargetType;\n\tv136 = this.forcedTargetType == 0;\n\tif (v136) goto L_009F;\nL_009C:\n\tthis.targetType = v158;\n\tgoto L_00A2;\nL_009F:\n\tv160 = this.targetType == 0;\n\tif (v160) goto L_00D8;\nL_00A2:\n\tv229 = this.animationType - 1;\n\tv230 = v229 < 0x14;\n\tv231 = ~v230;\n\tv232 = v229 - 0x14;\n\tv234 = v232 == 0;\n\tv239 = ~v234;\n\tv240 = v231 & v239;\n\tif (v240) goto L_07F6;\n\tv258 = 0x183B000 + 0xC10;\n\tv260 = *([v258 @ X10_v8 (System.Int32)+v229 @ X9_v6 (System.Int32)*4]) + v258;\n\t// 179 IndirectJump v260 @ X9_v19, v225 @ X0_v43 (System.Boolean), v225 @ X0_v43 (System.Boolean), v224 @ X1_v18 (UnityEngine.Object), 0, v37 @ X3, v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\tX8 = *([X19+BD]);\n\tif (TEMP) goto L_0714;\n\t*([X19+A0]) = 0;\n\tX0 = *([X22]);\n\tX20 = *([X19+100]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00C3;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C3;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C3:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0487;\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.Object::get_name(X0, X1);\n\tX8 = *([1EB3CF8]);\n\tgoto L_06E6;\nL_00D8:\n\tv262 = System.Object::GetType(this.target);\n\tv156 = DG.Tweening.DOTweenAnimation::TypeToDOTargetType(v262);\n\tgoto L_009C;\n\tif (TEMP) goto L_09BE;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_transform(X0, X1);\n\tV0 = *([X19+C4]);\n\tV1 = *([X19+C8]);\n\tV2 = *([X19+CC]);\n\tV3 = *([X19+80]);\n\tX1 = *([X19+108]);\n\tX2 = 0;\n\t// 231 MakeStruct AGG15B5728_1, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.ShortcutExtensions::DOLocalMove(X0, AGG15B5728_1, V3, X1, X2);\n\tgoto L_07F4;\n\tC = X8 < 8;\n\tC = ~C;\n\tTEMP1 = X8 - 8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 8;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_04AA;\n\tC = X8 < 9;\n\tC = ~C;\n\tTEMP1 = X8 - 9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_04D6;\n\tC = X8 < 0xB;\n\tC = ~C;\n\tTEMP1 = X8 - 0xB;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0xB;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_07F6;\n\tX0 = *([X19+A8]);\n\tV0 = *([X19+C4]);\n\tV1 = *([X19+C8]);\n\tV2 = *([X19+CC]);\n\tV3 = *([X19+80]);\n\tX1 = *([X19+114]);\n\tif (TEMP) goto L_0131;\n\tX8 = *([1F07618]);\n\tX9 = *([X0]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_09C4;\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_09C4;\nL_0131:\n\tX2 = 0;\n\t// 306 MakeStruct AGG15B5798_1, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.ShortcutExtensions::DORotate(X0, AGG15B5798_1, V3, X1, X2);\n\tgoto L_07F4;\n\tif (TEMP) goto L_09BE;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_transform(X0, X1);\n\tV0 = *([X19+C4]);\n\tV1 = *([X19+C8]);\n\tV2 = *([X19+CC]);\n\tV3 = *([X19+80]);\n\tX1 = *([X19+114]);\n\tX2 = 0;\n\t// 320 MakeStruct AGG15B57C4_1, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.ShortcutExtensions::DOLocalRotate(X0, AGG15B57C4_1, V3, X1, X2);\n\tgoto L_07F4;\n\tif (TEMP) goto L_09BE;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_transform(X0, X1);\n\tX8 = *([X19+108]);\n\tX20 = X0;\n\tif (TEMP) goto L_03CB;\n\tV0 = *([X19+C0]);\n\tX0 = &stack[0];\n\tX1 = 0;\n\tstack[8] = 0;\n\tV1 = V0;\n\tV2 = V0;\n\tstack[0] = 0;\n\tX0 = 0x1586898(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = stack[0];\n\tV1 = stack[4];\n\tV2 = stack[8];\n\tgoto L_03CE;\n\tX8 = X8 - 3;\n\tC = X8 < 0xC;\n\tC = ~C;\n\tTEMP1 = X8 - 0xC;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0xC;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X19+A0]) = 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_07F6;\n\tX9 = X9 + 0xC9C;\n\tX8 = *([X9+X8*4]);\n\tX8 = X8 + X9;\n\t// 362 IndirectJump X8, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX0 = *([X19+A8]);\n\tV0 = *([X19+D8]);\n\tV1 = *([X19+DC]);\n\tV2 = *([X19+E0]);\n\tV3 = *([X19+E4]);\n\tV4 = *([X19+80]);\n\tif (TEMP) goto L_0193;\n\tX9 = *([1ED8CD8]);\n\tX8 = *([X0]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_09BD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_09BD;\nL_0193:\n\tX1 = 0;\n\t// 404 MakeStruct AGG15B5884_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tX0 = DG.Tweening.DOTweenModuleUI::DOColor(X0, AGG15B5884_1, V4, X1);\n\tgoto L_07F4;\n\tX8 = X8 - 2;\n\tC = X8 < 0xD;\n\tC = ~C;\n\tTEMP1 = X8 - 0xD;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0xD;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X19+A0]) = 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_07F6;\n\tX9 = X9 + 0xC64;\n\tX8 = *([X9+X8*4]);\n\tX8 = X8 + X9;\n\t// 425 IndirectJump X8, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX0 = *([X19+A8]);\n\tV0 = *([X19+C0]);\n\tV1 = *([X19+80]);\n\tif (TEMP) goto L_01BE;\n\tX8 = *([1F0F248]);\n\tX1 = *([X8]);\n\tX8 = *([X0]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_09BD;\nL_01BE:\n\tX1 = 0;\n\tX0 = DG.Tweening.DOTweenModuleUI::DOFade(X0, V0, V1, X1);\n\tgoto L_07F4;\n\tC = X8 < 0xA;\n\tC = ~C;\n\tTEMP1 \n// ... truncated")]
		public void CreateTween()
		{
			//IL_0234: Expected O, but got I
			GameObject gameObject2;
			if (targetIsSelf)
			{
				GameObject gameObject = base.gameObject;
				gameObject2 = gameObject;
			}
			else
			{
				gameObject2 = targetGO;
			}
			if (target == null || gameObject2 == null)
			{
				string arg;
				string format;
				if (targetIsSelf && target == null)
				{
					GameObject gameObject3 = base.gameObject;
					arg = gameObject3.name;
					format = "{0} :: This DOTweenAnimation's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically";
				}
				else
				{
					GameObject gameObject4 = base.gameObject;
					arg = gameObject4.name;
					format = "{0} :: This DOTweenAnimation's target/GameObject is unset: the tween will not be created.";
				}
				string message = string.Format(format, arg);
				GameObject context = base.gameObject;
				Debug.LogWarning(message, context);
				return;
			}
			TargetType targetType = forcedTargetType;
			bool flag = forcedTargetType == TargetType.Unset;
			UnityEngine.Object obj = null;
			if (!flag)
			{
				goto IL_0170;
			}
			bool flag2 = this.targetType == TargetType.Unset;
			obj = null;
			if (!flag2)
			{
				goto IL_01a3;
			}
			goto IL_023e;
			IL_023e:
			Type type = target.GetType();
			TargetType targetType2 = TypeToDOTargetType(type);
			obj = null;
			targetType = targetType2;
			goto IL_0170;
			IL_0170:
			this.targetType = targetType;
			goto IL_01a3;
			IL_01a3:
			int num = (int)(animationType - 1);
			bool flag3 = num < 20;
			bool flag4 = !flag3;
			int num2 = num - 20;
			bool flag5 = num2 == 0;
			bool flag6 = !flag5;
			if (!(flag4 && flag6))
			{
				int num3 = 25407488 + 3088;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ X10_v8 (System.Int32)+v229 @ X9_v6 (System.Int32)*4]");
				object obj2 = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v260 @ X9_v19 (should have been resolved before IL gen)");
				goto IL_023e;
			}
			if (base.tween == null)
			{
				return;
			}
			if (isFrom)
			{
				Tweener tweener = base.tween as Tweener;
				if (tweener == null)
				{
					throw new InvalidCastException();
				}
				bool flag7 = !isRelative;
				bool flag8 = !flag7;
				Tweener tweener2 = ((Tweener)base.tween).From(flag8);
			}
			else
			{
				bool flag9 = !isRelative;
				bool flag10 = !flag9;
				Tween tween = base.tween.SetRelative(flag10);
			}
			GameObject gameObject6;
			if (targetIsSelf || !tweenTargetIsTargetGO)
			{
				GameObject gameObject5 = base.gameObject;
				gameObject6 = gameObject5;
			}
			else
			{
				gameObject6 = targetGO;
			}
			Tween t = base.tween.SetTarget(gameObject6);
			Tween t2 = t.SetDelay(delay);
			Tween t3 = t2.SetLoops(loops, loopType);
			Tween t4 = t3.SetAutoKill(autoKill);
			TweenCallback action = delegate
			{
				base.tween = null;
			};
			Tween tween2 = t4.OnKill(action);
			if (isSpeedBased)
			{
				Tween tween3 = base.tween.SetSpeedBased();
			}
			if (easeType == Ease.INTERNAL_Custom)
			{
				Tween tween4 = base.tween.SetEase(easeCurve);
			}
			else
			{
				Tween tween5 = base.tween.SetEase(easeType);
			}
			if (!string.IsNullOrEmpty(id))
			{
				Tween tween6 = base.tween.SetId(id);
			}
			Tween tween7 = base.tween.SetUpdate(isIndependentUpdate);
			if (hasOnStart)
			{
				if (onStart != null)
				{
					TweenCallback action2 = onStart.Invoke;
					Tween tween8 = base.tween.OnStart(action2);
				}
			}
			else
			{
				onStart = null;
			}
			if (hasOnPlay)
			{
				if (onPlay != null)
				{
					TweenCallback action3 = onPlay.Invoke;
					Tween tween9 = base.tween.OnPlay(action3);
				}
			}
			else
			{
				onPlay = null;
			}
			if (hasOnUpdate)
			{
				if (onUpdate != null)
				{
					TweenCallback action4 = onUpdate.Invoke;
					Tween tween10 = base.tween.OnUpdate(action4);
				}
			}
			else
			{
				onUpdate = null;
			}
			if (hasOnStepComplete)
			{
				if (onStepComplete != null)
				{
					TweenCallback action5 = onStepComplete.Invoke;
					Tween tween11 = base.tween.OnStepComplete(action5);
				}
			}
			else
			{
				onStepComplete = null;
			}
			if (hasOnComplete)
			{
				if (onComplete != null)
				{
					TweenCallback action6 = onComplete.Invoke;
					Tween tween12 = base.tween.OnComplete(action6);
				}
			}
			else
			{
				onComplete = null;
			}
			if (hasOnRewind)
			{
				if (onRewind != null)
				{
					TweenCallback action7 = onRewind.Invoke;
					Tween tween13 = base.tween.OnRewind(action7);
				}
			}
			else
			{
				onRewind = null;
			}
			if (autoPlay)
			{
				Tween tween14 = base.tween.Play();
			}
			else
			{
				Tween tween15 = base.tween.Pause();
			}
			if (hasOnTweenCreated && onTweenCreated != null)
			{
				onTweenCreated.Invoke();
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x15B7198", Offset = "0x15B7198", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EEA518]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F2]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv63 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v63, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv62 = DG.Tweening.DOTween::Play(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPlay()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.Play(targetOrId);
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x15B7214", Offset = "0x15B7214", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAF198]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F3]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv63 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v63, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv62 = DG.Tweening.DOTween::PlayBackwards(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPlayBackwards()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.PlayBackwards(targetOrId);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x15B7290", Offset = "0x15B7290", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EA3BE0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F4]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv63 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v63, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv62 = DG.Tweening.DOTween::PlayForward(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPlayForward()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.PlayForward(targetOrId);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15B730C", Offset = "0x15B730C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC5300]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F5]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv63 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v63, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv62 = DG.Tweening.DOTween::Pause(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPause()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.Pause(targetOrId);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x15B7388", Offset = "0x15B7388", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE2778]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F6]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv63 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v63, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv62 = DG.Tweening.DOTween::TogglePause(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOTogglePause()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.TogglePause(targetOrId);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15B7404", Offset = "0x15B7404", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EAF7A0]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20298F7]) = v40;\nL_0017:\n\tthis._playCount = 0xFFFFFFFF;\n\tv44 = UnityEngine.Component::get_gameObject(this);\n\tv49 = UnityEngine.GameObject::GetComponents(v44);\n\tv96 = v49.Length - 1;\n\tv100 = v96 & 0x80000000;\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_006D;\n\tv143 = v96 < v49.Length;\n\tv144 = ~v143;\n\tif (v144) goto L_0063;\nL_0032:\n\tv58 = v96 << 3;\n\tv209 = v49 + v58;\n\tv56 = v209 + 0x20;\n\tv210 = *([v56 @ X21_v7]);\n\tv229 = *([v210 @ X8_v11+60]) == 0;\n\tif (v229) goto L_0052;\n\tv224 = DG.Tweening.TweenExtensions::IsInitialized(*([v210 @ X8_v11+60]));\n\tv225 = v224 == 0;\n\tif (v225) goto L_0052;\n\tv242 = v96 < v49.Length;\n\tv220 = ~v242;\n\tif (v220) goto L_0063;\n\tv232 = *([v56 @ X21_v7]);\n\tDG.Tweening.TweenExtensions::Rewind(*([v232 @ X8_v16+60]), 1);\nL_0052:\n\tv96 = v96 - 1;\n\tv238 = v96 & 0x80000000;\n\tv239 = v238 == 0;\n\tv179 = ~v239;\n\tif (v179) goto L_006D;\n\tv241 = v96 < v49.Length;\n\tv203 = ~v241;\n\tv185 = ~v203;\n\tif (v185) goto L_0032;\nL_0063:\n\tv227 = new System.IndexOutOfRangeException();\n\tthrow v227;\nL_006D:\n\treturn;\n\tv87 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DORewind()
		{
			//IL_0027: Expected O, but got I4
			//IL_003a: Expected I4, but got I8
			//IL_00a8: Expected O, but got I
			//IL_00b7: Expected O, but got I
			//IL_017b: Expected O, but got I
			//IL_018e: Expected I4, but got I8
			//IL_00fa: Expected O, but got I
			//IL_0167: Expected O, but got I
			_playCount = -1;
			GameObject gameObject = base.gameObject;
			DOTweenAnimation[] components = gameObject.GetComponents<DOTweenAnimation>();
			object obj = components.Length - 1;
			if ((int)((long)(IntPtr)obj & 0x80000000L) != 0)
			{
				return;
			}
			if ((long)(IntPtr)obj < (long)components.Length)
			{
				do
				{
					int num = (int)((long)(IntPtr)obj << 3);
					object obj2 = (long)(IntPtr)components + (long)num;
					object obj3 = (long)(IntPtr)obj2 + 32L;
					object obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v11+60]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v11+60]");
						if (((Tween)0).IsInitialized())
						{
							if ((long)(IntPtr)obj >= (long)components.Length)
							{
								break;
							}
							object obj5 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v16+60]");
							((Tween)0).Rewind();
						}
					}
					obj = (long)(IntPtr)obj - 1L;
					if ((int)((long)(IntPtr)obj & 0x80000000L) != 0)
					{
						return;
					}
				}
				while ((long)(IntPtr)obj < (long)components.Length);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x15B7504", Offset = "0x15B7504", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv3 = this->klass->vtable[11];\n\tv4 = this->klass->vtable[11];\n\t// 4 IndirectJump v3 @ X3_v1, this @ X0 (DG.Tweening.DOTweenAnimation), this @ X0 (DG.Tweening.DOTweenAnimation), 0, v4 @ X2_v1, v3 @ X3_v1, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DORestart()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<DG.Tweening.DOTweenAnimation>)+1E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<DG.Tweening.DOTweenAnimation>)+1E8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15B7514", Offset = "0x15B7514", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFCB68]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fromHere, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298F8]) = v41;\nL_0017:\n\tthis._playCount = 0xFFFFFFFF;\n\tv44 = this.tween == 0;\n\tif (v44) goto L_0043;\n\tv46 = fromHere == 0;\n\tif (v46) goto L_0024;\n\tv52 = ~this.isRelative;\n\tif (v52) goto L_0024;\n\tDG.Tweening.DOTweenAnimation::ReEvaluateRelativeTween(this);\nL_0024:\n\tv59 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_003D;\n\tv102 = *([v86 @ X8_v17+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003D;\n\tv149 = v86;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v149, v58, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\tv118 = DG.Tweening.DOTween::Restart(v59, 1, -1f);\n\treturn;\nL_0043:\n\tgoto L_0059;\n\tv61 = *([1ED4D80]);\n\tv62 = *([v61 @ X8_v12]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, fromHere, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv66 = 0 | 1;\n\t*([2022B9B]) = v66;\nL_0059:\n\tv82 = v70._logPriority < 2;\n\tif (v82) goto L_006B;\n\tDG.Tweening.Core.Debugger::LogNullTween(this.tween);\n\treturn;\nL_006B:\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DORestart(bool fromHere)
		{
			_playCount = -1;
			if (tween != null)
			{
				if (fromHere && isRelative)
				{
					ReEvaluateRelativeTween();
				}
				GameObject targetOrId = base.gameObject;
				int num = DOTween.Restart(targetOrId);
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(tween);
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x15B79A0", Offset = "0x15B79A0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ECD790]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298F9]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002C;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002C;\n\tv64 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v64, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tv63 = DG.Tweening.DOTween::Complete(v41, 0);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOComplete()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.Complete(targetOrId);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x15B7A20", Offset = "0x15B7A20", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED2E50]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298FA]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0027;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0027;\n\tv60 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v60, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv59 = DG.Tweening.DOTween::Kill(v41, 0);\n\tthis.tween = 0;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOKill()
		{
			GameObject targetOrId = base.gameObject;
			int num = DOTween.Kill(targetOrId);
			tween = null;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x15B7AA8", Offset = "0x15B7AA8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EEB200]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298FB]) = v41;\nL_0017:\n\tv44 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002F;\n\tv52 = *([v48 @ X8_v5+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002F;\n\tv68 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v68, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\tv67 = DG.Tweening.DOTween::Play(v44, id);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayById(string id)
		{
			GameObject gameObject = base.gameObject;
			int num = DOTween.Play(gameObject, id);
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x15B7B34", Offset = "0x15B7B34", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE1338]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298FC]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv58 = DG.Tweening.DOTween::Play(id);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayAllById(string id)
		{
			int num = DOTween.Play(id);
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x15B7B9C", Offset = "0x15B7B9C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F05790]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298FD]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv58 = DG.Tweening.DOTween::Pause(id);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPauseAllById(string id)
		{
			int num = DOTween.Pause(id);
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x15B7C04", Offset = "0x15B7C04", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED9BC0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298FE]) = v41;\nL_0017:\n\tv44 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002F;\n\tv52 = *([v48 @ X8_v5+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002F;\n\tv68 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v68, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\tv67 = DG.Tweening.DOTween::PlayBackwards(v44, id);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayBackwardsById(string id)
		{
			GameObject gameObject = base.gameObject;
			int num = DOTween.PlayBackwards(gameObject, id);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15B7C90", Offset = "0x15B7C90", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF51B0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298FF]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv58 = DG.Tweening.DOTween::PlayBackwards(id);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayBackwardsAllById(string id)
		{
			int num = DOTween.PlayBackwards(id);
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x15B7CF8", Offset = "0x15B7CF8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE0D90]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029900]) = v41;\nL_0017:\n\tv44 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002F;\n\tv52 = *([v48 @ X8_v5+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002F;\n\tv68 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v68, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\tv67 = DG.Tweening.DOTween::PlayForward(v44, id);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayForwardById(string id)
		{
			GameObject gameObject = base.gameObject;
			int num = DOTween.PlayForward(gameObject, id);
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x15B7D84", Offset = "0x15B7D84", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF32A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029901]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, id, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv58 = DG.Tweening.DOTween::PlayForward(id);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayForwardAllById(string id)
		{
			int num = DOTween.PlayForward(id);
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x15B7DEC", Offset = "0x15B7DEC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ED0CC8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029902]) = v42;\nL_0019:\n\tv47 = UnityEngine.Component::GetComponents(this);\n\tv168 = this._playCount;\n\tv52 = v47.Length - 1;\n\tv62 = this._playCount >= v52;\n\tif (v62) goto L_0075;\nL_002D:\n\tv169 = v168 + 1;\n\tthis._playCount = v169;\n\tv171 = v169 < v47.Length;\n\tv99 = ~v171;\n\tif (v99) goto L_0083;\n\tv117 = v47[v169 @ X8_v9 (System.Int32)];\n\tgoto L_004A;\n\tv210 = *([v205 @ X0_v13+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_004A;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v205, v154, v153, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004A:\n\tv219 = UnityEngine.Object::op_Inequality(v47[v169 @ X8_v9 (System.Int32)], 0);\n\tv224 = v219 == 0;\n\tif (v224) goto L_0060;\n\tv233 = *([v117 @ X21_v6 (UnityEngine.Object)+60]) == 0;\n\tif (v233) goto L_0060;\n\tv232 = DG.Tweening.TweenExtensions::IsPlaying(*([v117 @ X21_v6 (UnityEngine.Object)+60]));\n\tv239 = v232 == 0;\n\tv234 = ~v239;\n\tif (v234) goto L_0060;\n\tv230 = DG.Tweening.TweenExtensions::IsComplete(*([v117 @ X21_v6 (UnityEngine.Object)+60]));\n\tv196 = v230 == 0;\n\tif (v196) goto L_0081;\nL_0060:\n\tv168 = this._playCount;\n\tv140 = v47.Length - 1;\n\tv122 = this._playCount < v140;\n\tif (v122) goto L_002D;\nL_0075:\n\treturn;\nL_0081:\n\tv194 = DG.Tweening.TweenExtensions::Play(*([v117 @ X21_v6 (UnityEngine.Object)+60]));\n\treturn;\nL_0083:\n\tv209 = new System.IndexOutOfRangeException();\n\tthrow v209;\n\tv105 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DOPlayNext()
		{
			//IL_00c0: Expected O, but got I
			//IL_00fd: Expected O, but got I
			//IL_0168: Expected O, but got I
			DOTweenAnimation[] components = GetComponents<DOTweenAnimation>();
			int playCount = _playCount;
			int num = components.Length - 1;
			if (_playCount >= num)
			{
				return;
			}
			while (true)
			{
				int num2 = (_playCount = playCount + 1);
				if (num2 >= components.Length)
				{
					break;
				}
				UnityEngine.Object obj = components[num2];
				if (components[num2] != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X21_v6 (UnityEngine.Object)+60]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X21_v6 (UnityEngine.Object)+60]");
						if (!((Tween)0).IsPlaying())
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X21_v6 (UnityEngine.Object)+60]");
							if (!((Tween)0).IsComplete())
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X21_v6 (UnityEngine.Object)+60]");
								Tween tween = ((Tween)0).Play();
								return;
							}
						}
					}
				}
				playCount = _playCount;
				int num3 = components.Length - 1;
				if (_playCount >= num3)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x15B7F2C", Offset = "0x15B7F2C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF1738]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029903]) = v38;\nL_0016:\n\tthis._playCount = 0xFFFFFFFF;\n\tv42 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0029;\n\tv50 = *([v46 @ X8_v6+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0029;\n\tv61 = v46;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v61, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv60 = DG.Tweening.DOTween::Rewind(v42, 1);\n\tDG.Tweening.DOTweenAnimation::DOPlayNext(this);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DORewindAndPlayNext()
		{
			_playCount = -1;
			GameObject targetOrId = base.gameObject;
			int num = DOTween.Rewind(targetOrId);
			DOPlayNext();
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x15B7FBC", Offset = "0x15B7FBC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EF0B88]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029904]) = v41;\nL_0016:\n\tthis._playCount = 0xFFFFFFFF;\n\tgoto L_002C;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002C;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv64 = DG.Tweening.DOTween::Rewind(id, 1);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DORewindAllById(string id)
		{
			_playCount = -1;
			int num = DOTween.Rewind(id);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x15B803C", Offset = "0x15B803C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EEA3B0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029905]) = v41;\nL_0018:\n\tthis._playCount = 0xFFFFFFFF;\n\tv45 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0033;\n\tv53 = *([v49 @ X8_v6+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0033;\n\tv71 = v49;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v71, v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0033:\n\tv70 = DG.Tweening.DOTween::Restart(v45, id, 1, -1f);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DORestartById(string id)
		{
			_playCount = -1;
			GameObject gameObject = base.gameObject;
			int num = DOTween.Restart(gameObject, id);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x15B80D8", Offset = "0x15B80D8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EAF788]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029906]) = v41;\nL_0016:\n\tthis._playCount = 0xFFFFFFFF;\n\tgoto L_002D;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002D;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tv65 = DG.Tweening.DOTween::Restart(id, 1, -1f);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DORestartAllById(string id)
		{
			_playCount = -1;
			int num = DOTween.Restart(id);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x15B815C", Offset = "0x15B815C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0F368]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029907]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v46);\n\tv55 = UnityEngine.Component::GetComponents(this);\n\tv176 = v55.Length;\n\tv69 = v55.Length < 1;\n\tif (v69) goto L_0061;\nL_0036:\n\tv186 = v76 < v176;\n\tv104 = ~v186;\n\tif (v104) goto L_0064;\n\tv113 = v55[v76 @ X21_v6 (System.Int32)];\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Add(v46, v113.tween);\n\tv176 = v55.Length;\n\tv76 = v76 + 1;\n\tv124 = v76 < v55.Length;\n\tif (v124) goto L_0036;\nL_0061:\n\treturn v46;\n\tv114 = new System.NullReferenceException();\nL_0064:\n\tv177 = new System.IndexOutOfRangeException();\n\tthrow v177;\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<Tween> GetTweens()
		{
			List<Tween> list = new List<Tween>();
			DOTweenAnimation[] components = GetComponents<DOTweenAnimation>();
			int num = components.Length;
			if (components.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						DOTweenAnimation dOTweenAnimation = components[num2];
						list.Add(dOTweenAnimation.tween);
						num = components.Length;
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < components.Length);
			}
			return list;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x15B6BD0", Offset = "0x15B6BD0", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAB148]);\n\tv19 = *([v18 @ X8_v25]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029908]) = v38;\nL_0019:\n\tv44 = System.Type::ToString(t);\n\tv53 = System.String::LastIndexOf(v44, \".\");\n\tv105 = v53 + 1;\n\tv76 = v105 == 0;\n\tif (v76) goto L_0035;\n\tv86 = v53 + 1;\n\tv92 = System.String::Substring(v44, v86);\nL_0035:\n\tv154 = System.String::IndexOf(v99, \"Renderer\");\n\tv155 = v154 + 1;\n\tv157 = v155 == 0;\n\tif (v157) goto L_0054;\n\tv192 = System.String::op_Inequality(v99, \"SpriteRenderer\");\n\tv202 = v192 == 0;\n\tv196 = ~v202;\n\tv194 = ~v196;\n\tif (v194) goto L_0054;\n\tgoto L_0054;\nL_0054:\n\tv220 = System.String::op_Equality(v99, \"RawImage\");\n\tv77 = v220 == 0;\n\tv65 = ~v77;\n\tv62 = ~v65;\n\tif (v62) goto L_006D;\n\tgoto L_006D;\nL_006D:\n\tgoto L_0076;\n\tv234 = *([v226 @ X8_v13+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tgoto L_0076;\n\tv244 = v226;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v244, v219, v218, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0076:\n\tv243 = System.Type::GetTypeFromHandle(DG.Tweening.DOTweenAnimation+TargetType);\n\tgoto L_0088;\n\tv250 = *([v101 @ X8_v16+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tif (v252) goto L_0088;\n\tv257 = v101;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v257, v242, v218, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0088:\n\tv93 = System.Enum::Parse(v243, v99);\n\tv122 = v122_asT == 0;\n\tif (v122) goto L_00A6;\n\tv262 = \"il2cpp_vm_object_unbox\"(v93, DG.Tweening.DOTweenAnimation+TargetType, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn *([v262 @ X0_v23]);\n\tv104 = new System.NullReferenceException();\nL_00A6:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TargetType TypeToDOTargetType(Type t)
		{
			//IL_015c: Expected I4, but got O
			//IL_0196: Expected I4, but got O
			//IL_0188: Expected I4, but got O
			string text = t.ToString();
			int num = text.LastIndexOf(".");
			int num2 = num + 1;
			bool flag = num2 == 0;
			string text2 = text;
			if (!flag)
			{
				int startIndex = num + 1;
				string text3 = text.Substring(startIndex);
				text2 = text3;
			}
			int num3 = text2.IndexOf("Renderer");
			if (num3 + 1 != 0 && text2 != "SpriteRenderer")
			{
				text2 = "Renderer";
			}
			if (text2 == "RawImage")
			{
				text2 = "Image";
			}
			Type typeFromHandle = typeof(TargetType);
			object obj = Enum.Parse(typeFromHandle, text2);
			if ((int)((obj is TargetType) ? obj : null) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				return (TargetType)obj2;
			}
			InvalidCastException ex = new InvalidCastException();
			return (TargetType)ex;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x15B8250", Offset = "0x15B8250", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Application::get_isPlaying();\n\tv15 = v11 == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0015;\n\tDG.Tweening.DOTweenAnimation::CreateTween(this);\n\treturnVal1 = this.tween;\nL_0015:\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Tween CreateEditorPreview()
		{
			bool isPlaying = Application.isPlaying;
			bool flag = !isPlaying;
			bool flag2 = !flag;
			Tween result = null;
			if (!flag2)
			{
				CreateTween();
				result = tween;
			}
			return result;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15B6BB8", Offset = "0x15B6BB8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.targetIsSelf;\n\tif (v2) goto L_0007;\n\treturnVal2 = UnityEngine.Component::get_gameObject(this);\n\treturn returnVal2;\nL_0007:\n\treturn this.targetGO;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject GetTweenGO()
		{
			if (targetIsSelf)
			{
				return base.gameObject;
			}
			return targetGO;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x15B7630", Offset = "0x15B7630", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EE5C20]);\n\tv33 = *([v32 @ X8_v43]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029909]) = v52;\nL_001B:\n\tv54 = ~this.targetIsSelf;\n\tif (v54) goto L_0022;\n\tv57 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0029;\nL_0022:\n\tv60 = this.targetGO;\nL_0029:\n\tgoto L_0032;\n\tv69 = *([v65 @ X0_v3+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0032;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v61, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0032:\n\tv79 = UnityEngine.Object::op_Equality(v60, 0);\n\tv81 = v79 == 0;\n\tif (v81) goto L_006C;\n\tv84 = UnityEngine.Component::get_gameObject(this);\n\tv108 = UnityEngine.Object::get_name(v84);\n\tv398 = System.String::Format(\"{0} :: This DOTweenAnimation's target/GameObject is unset: the tween will not be created.\", v108);\n\tv463 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0065;\n\tv481 = *([v455 @ X8_v39+E0]);\n\tv482 = v481 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_0065;\n\tv503 = v455;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v503, v462, v395, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0065:\n\tUnityEngine.Debug::LogWarning(v398, v463);\n\treturn;\nL_006C:\n\tv90 = this.animationType == 2;\n\tif (v90) goto L_00F1;\n\tv105 = this.animationType != 1;\n\tif (v105) goto L_0171;\n\tv293 = this.tween;\n\tv200 = UnityEngine.GameObject::get_transform(v60);\n\tv465 = UnityEngine.Transform::get_position(v200);\n\tgoto L_00A3;\n\tv504 = *([v489 @ X0_v29+E0]);\n\tv505 = v504 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_00A3;\n\tv508 = \"il2cpp_codegen_runtime_class_init\"(v489, v472, v78, v37, v38, v39, v40, v41, v473, v486, v487, v45, v46, v47, v48, v49);\nL_00A3:\n\t// 163 MakeStruct v325 @ AGG15B77E8_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.endValueV3 (UnityEngine.Vector3), this.endValueV3.y (System.Single), this.endValueV3.z (System.Single)\n\tv465 = UnityEngine.Vector3::op_Addition(v465, v325);\n\tv245 = v465.y;\n\tv243 = v465.z;\n\t// 172 Box v381 @ X0_v33, typeof(UnityEngine.Vector3), &v465 @ V0_v6 (UnityEngine.Vector3)\n\tgoto L_FFFFFFFF;\n\tv568 = v568_asT == 0;\n\tif (v568) goto L_0173;\n\tgoto L_FFFFFFFF;\n\tv570 = v570_asT == 0;\n\tif (v570) goto L_0173;\n\tv291 = *([v293 @ X20_v7 (DG.Tweening.Tween)]);\n\tgoto L_0164;\nL_00F1:\n\tv293 = this.tween;\n\tv201 = UnityEngine.GameObject::get_transform(v60);\n\tv465 = UnityEngine.Transform::get_localPosition(v201);\n\tgoto L_0115;\n\tv493 = *([v477 @ X0_v21+E0]);\n\tv494 = v493 == 0;\n\tv495 = ~v494;\n\tif (v495) goto L_0115;\n\tv497 = \"il2cpp_codegen_runtime_class_init\"(v477, v464, v78, v37, v38, v39, v40, v41, v465, v474, v475, v45, v46, v47, v48, v49);\nL_0115:\n\t// 277 MakeStruct v307 @ AGG15B78DC_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.endValueV3 (UnityEngine.Vector3), this.endValueV3.y (System.Single), this.endValueV3.z (System.Single)\n\tv465 = UnityEngine.Vector3::op_Addition(v465, v307);\n\tv245 = v465.y;\n\tv243 = v465.z;\n\t// 286 Box v382 @ X0_v25, typeof(UnityEngine.Vector3), &v465 @ V0_v6 (UnityEngine.Vector3)\n\tgoto L_FFFFFFFF;\n\tv561 = v561_asT == 0;\n\tif (v561) goto L_0173;\n\tv291 = *([v293 @ X20_v7 (DG.Tweening.Tween)]);\n\tgoto L_FFFFFFFF;\n\tv572 = v572_asT == 0;\n\tif (v572) goto L_0173;\nL_0164:\n\t*([v291 @ X8_v13 (Il2CppClass<DG.Tweening.Tween>)+1E0])(v287, v293, v225, 1, *([v291 @ X8_v13 (Il2CppClass<DG.Tweening.Tween>)+1E8]), v225, v39, v40, v41, v465, v245, v243, v241, v239, v237, v48, v49);\nL_0171:\n\treturn;\nL_0173:\n\tv199 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 291 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ReEvaluateRelativeTween()
		{
			//IL_030d: Expected I, but got O
			//IL_01f8: Expected I, but got O
			GameObject gameObject2;
			if (targetIsSelf)
			{
				GameObject gameObject = base.gameObject;
				gameObject2 = gameObject;
			}
			else
			{
				gameObject2 = targetGO;
			}
			if (gameObject2 == null)
			{
				GameObject gameObject3 = base.gameObject;
				string arg = gameObject3.name;
				string message = $"{arg} :: This DOTweenAnimation's target/GameObject is unset: the tween will not be created.";
				GameObject context = base.gameObject;
				Debug.LogWarning(message, context);
				return;
			}
			if (animationType != AnimationType.LocalMove)
			{
				if (animationType != AnimationType.Move)
				{
					return;
				}
				Tween tween = base.tween;
				Transform transform = gameObject2.transform;
				Vector3 position = transform.position;
				Vector3 vector = default(Vector3);
				vector.x = endValueV3.x;
				vector.y = endValueV3.y;
				vector.z = endValueV3.z;
				position += vector;
				float y = position.y;
				float z = position.z;
				object obj = position;
				Tweener tweener = base.tween as Tweener;
				if (tweener != null)
				{
					Tweener tweener2 = base.tween as Tweener;
					if (tweener2 != null)
					{
						IntPtr intPtr = (IntPtr)tween;
						object obj2 = obj;
						float z2 = endValueV3.z;
						float y2 = endValueV3.y;
						Vector3 vector2 = endValueV3;
						goto IL_036e;
					}
				}
			}
			else
			{
				Tween tween = base.tween;
				Transform transform2 = gameObject2.transform;
				Vector3 position = transform2.localPosition;
				Vector3 vector3 = default(Vector3);
				vector3.x = endValueV3.x;
				vector3.y = endValueV3.y;
				vector3.z = endValueV3.z;
				position += vector3;
				float y = position.y;
				float z = position.z;
				object obj3 = position;
				Tweener tweener3 = base.tween as Tweener;
				if (tweener3 != null)
				{
					IntPtr intPtr = (IntPtr)tween;
					Tweener tweener4 = base.tween as Tweener;
					bool flag = tweener4 == null;
					object obj2 = obj3;
					float z2 = endValueV3.z;
					float y2 = endValueV3.y;
					Vector3 vector2 = endValueV3;
					if (!flag)
					{
						goto IL_036e;
					}
				}
			}
			InvalidCastException ex = new InvalidCastException();
			throw new NullReferenceException();
			IL_036e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v291 @ X8_v13 (Il2CppClass<DG.Tweening.Tween>)+1E0] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15B828C", Offset = "0x15B828C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0017;\n\tv20 = *([1EE10D8]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202990A]) = v40;\nL_0017:\n\tthis.targetIsSelf = 1;\n\tthis.tweenTargetIsTargetGO = 1;\n\tthis.duration = 1f;\n\t// 30 NewArr v48 @ X0_v3 (UnityEngine.Keyframe[]), typeof(UnityEngine.Keyframe[]), 2\n\tv50 = &v11 @ stack_-10_v2 - 0x40;\n\t*([v10 @ X29_v1-28]) = 0;\n\t*([v10 @ X29_v1-38]) = 0;\n\t*([v10 @ X29_v1-30]) = 0;\n\t*([v10 @ X29_v1-40]) = 0;\n\tv54 = 0x100AEC0(v50, 0, v24, v25, v26, v27, v28, v29, 0, 0, v32, v33, v34, v35, v36, v37);\n\tv61 = v48.Length == 0;\n\tif (v61) goto L_0092;\n\t*([v48 @ X0_v3 (UnityEngine.Keyframe[])+2C]) = *([v10 @ X29_v1-34]);\n\t*([v48 @ X0_v3 (UnityEngine.Keyframe[])+20]) = *([v10 @ X29_v1-40]);\n\tv128 = 0;\n\tv136 = 0x100AEC0(&v128 @ stack_-90_v3, 0, v24, v25, v26, v27, v28, v29, 1f, 1f, v32, v33, v34, v35, v36, v37);\n\tv155 = v48.Length < 1;\n\tv145 = ~v155;\n\tv144 = v48.Length - 1;\n\tv142 = v144 == 0;\n\tv156 = ~v145;\n\tv137 = v156 | v142;\n\tif (v137) goto L_0092;\n\t*([v48 @ X0_v3 (UnityEngine.Keyframe[])+48]) = v154;\n\t*([v48 @ X0_v3 (UnityEngine.Keyframe[])+3C]) = 0;\n\tv226 = new UnityEngine.AnimationCurve();\n\tUnityEngine.AnimationCurve::.ctor(v226, v48);\n\tthis.easeCurve = v226;\n\tthis.loops = 1;\n\tthis.autoKill = 0x101;\n\tthis.autoPlay = 1;\n\tthis.id = \"\";\n\tv172 = 0;\n\tv240 = 0x101059C(&v172 @ stack_-C0_v1 (System.Single), 0, 0, v25, v26, v27, v28, v29, 1f, 1f, 1f, 1f, v34, v35, v36, v37);\n\tthis.endValueColor.r = 0f;\n\tthis.endValueColor.g = v243;\n\tthis.endValueColor.a = v245;\n\tthis.endValueString = \"\";\n\tv166 = 0;\n\tv249 = 0x10CCF64(&v166 @ stack_-D0_v1 (System.Single), 0, 0, v25, v26, v27, v28, v29, 0, 0, 0, 0, v34, v35, v36, v37);\n\tthis.endValueRect.m_XMin = 0f;\n\tthis.endValueRect.m_YMin = v250;\n\tthis.endValueRect.m_Height = v251;\n\tthis._playCount = 0xFFFFFFFF;\n\tDG.Tweening.Core.ABSAnimationComponent::.ctor(this);\n\treturn;\nL_0092:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tthrow System.NullReferenceException;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimation()
		{
			//IL_0209: Expected O, but got I
			//IL_0055: Expected O, but got I4
			//IL_008b: Expected O, but got I4
			//IL_0151: Expected F4, but got O
			//IL_01a2: Expected F4, but got O
			base._002Ector();
			object obj2 = default(object);
			object obj = obj2;
			targetIsSelf = true;
			tweenTargetIsTargetGO = true;
			duration = 1f;
			Keyframe[] array = new Keyframe[2];
			object obj3 = (long)(IntPtr)obj2 - 64L;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100AEC0 (inside UnityEngine.AnimationCurve::Linear +0x14C)");
			if (array.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-34]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-40]");
				_ = 0;
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100AEC0 (inside UnityEngine.AnimationCurve::Linear +0x14C)");
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj5 = array.Length - 1;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					_ = 0;
					AnimationCurve animationCurve = new AnimationCurve(array);
					easeCurve = animationCurve;
					loops = 1;
					autoKill = true;
					isActive = true;
					autoPlay = true;
					id = "";
					float num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
					endValueColor.r = 0f;
					object obj6 = default(object);
					endValueColor.g = (float)obj6;
					float a = default(float);
					endValueColor.a = a;
					endValueString = "";
					float num2 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
					endValueRect.x = 0f;
					object obj7 = default(object);
					endValueRect.y = (float)obj7;
					float height = default(float);
					endValueRect.height = height;
					_playCount = -1;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
