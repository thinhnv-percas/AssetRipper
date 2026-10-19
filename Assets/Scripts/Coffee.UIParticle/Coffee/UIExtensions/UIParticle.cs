using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Coffee.UIParticleInternal;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[Token(Token = "0x2000020")]
	public class UIParticle : MaskableGraphic, ISerializationCallbackReceiver
	{
		[Token(Token = "0x2000021")]
		public enum AutoScalingMode
		{
			[Token(Token = "0x400004E")]
			None = 0,
			[Token(Token = "0x400004F")]
			UIParticle = 1,
			[Token(Token = "0x4000050")]
			Transform = 2
		}

		[Token(Token = "0x2000022")]
		public enum MeshSharing
		{
			[Token(Token = "0x4000052")]
			None = 0,
			[Token(Token = "0x4000053")]
			Auto = 1,
			[Token(Token = "0x4000054")]
			Primary = 2,
			[Token(Token = "0x4000055")]
			PrimarySimulator = 3,
			[Token(Token = "0x4000056")]
			Replica = 4
		}

		[Token(Token = "0x2000023")]
		public enum PositionMode
		{
			[Token(Token = "0x4000058")]
			Relative = 0,
			[Token(Token = "0x4000059")]
			Absolute = 1
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000024")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400005A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400005B")]
			public static Action<UIParticleRenderer> _003C_003E9__88_0;

			[Token(Token = "0x400005C")]
			public static Action<ParticleSystem> _003C_003E9__92_0;

			[Token(Token = "0x400005D")]
			public static Action<ParticleSystem> _003C_003E9__93_0;

			[Token(Token = "0x400005E")]
			public static Action<ParticleSystem> _003C_003E9__95_0;

			[Token(Token = "0x400005F")]
			public static Action<ParticleSystem> _003C_003E9__96_0;

			[Token(Token = "0x4000060")]
			public static Action<ParticleSystem> _003C_003E9__97_0;

			[Token(Token = "0x4000061")]
			public static Action<ParticleSystem> _003C_003E9__98_0;

			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x3F271E4", Offset = "0x3F271E4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Coffee.UIExtensions.UIParticle+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x3F27248", Offset = "0x3F27248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003COnDisable_003Eb__88_0(UIParticleRenderer r)
			{
				r.Reset();
			}

			internal void _003CPlay_003Eb__92_0(ParticleSystem p)
			{
				p.Simulate(0f, withChildren: false, restart: true);
			}

			internal void _003CPause_003Eb__93_0(ParticleSystem p)
			{
				p.Pause();
			}

			internal void _003CStop_003Eb__95_0(ParticleSystem p)
			{
				p.Stop();
			}

			internal void _003CStartEmission_003Eb__96_0(ParticleSystem p)
			{
				ParticleSystem.EmissionModule emission = p.emission;
				ParticleSystem.EmissionModule emissionModule = emission;
				emissionModule.enabled = true;
			}

			internal void _003CStopEmission_003Eb__97_0(ParticleSystem p)
			{
				ParticleSystem.EmissionModule emission = p.emission;
				ParticleSystem.EmissionModule emissionModule = emission;
				emissionModule.enabled = false;
			}

			internal void _003CClear_003Eb__98_0(ParticleSystem p)
			{
				p.Clear();
			}
		}

		[HideInInspector]
		[SerializeField]
		[Obsolete]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0xD8")]
		internal bool m_IsTrail;

		[HideInInspector]
		[FormerlySerializedAs("m_IgnoreParent")]
		[SerializeField]
		[Obsolete]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0xD9")]
		private bool m_IgnoreCanvasScaler;

		[HideInInspector]
		[SerializeField]
		[Obsolete]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0xDA")]
		internal bool m_AbsoluteMode;

		[Tooltip("Scale the rendering particles. When the `3D` toggle is enabled, 3D scale (x, y, z) is supported.")]
		[SerializeField]
		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0xDC")]
		internal Vector3 m_Scale3D;

		[Tooltip("If you want to update material properties (e.g. _MainTex_ST, _Color) in AnimationClip, use this to mark as animatable.")]
		[SerializeField]
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0xE8")]
		internal AnimatableProperty[] m_AnimatableProperties;

		[Tooltip("Particles")]
		[SerializeField]
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0xF0")]
		private List<ParticleSystem> m_Particles;

		[Tooltip("Particle simulation results are shared within the same group. A large number of the same effects can be displayed with a small load.\nNone: Disable mesh sharing.\nAuto: Automatically select Primary/Replica.\nPrimary: Provides particle simulation results to the same group.\nPrimary Simulator: Primary, but do not render the particle (simulation only).\nReplica: Render simulation results provided by the primary.")]
		[SerializeField]
		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0xF8")]
		private MeshSharing m_MeshSharing;

		[Tooltip("Mesh sharing group ID.\nIf non-zero is specified, particle simulation results are shared within the group.")]
		[SerializeField]
		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0xFC")]
		private int m_GroupId;

		[SerializeField]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x100")]
		private int m_GroupMaxId;

		[Tooltip("Emission position mode.\nRelative: The particles will be emitted from the scaled position.\nAbsolute: The particles will be emitted from the world position.")]
		[SerializeField]
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x104")]
		private PositionMode m_PositionMode;

		[SerializeField]
		[Obsolete]
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x108")]
		internal bool m_AutoScaling;

		[SerializeField]
		[Tooltip("How to automatically adjust when the Canvas scale is changed by the screen size or reference resolution.\nNone: Do nothing.\nTransform: Transform.lossyScale (=world scale) will be set to (1, 1, 1).\nUIParticle: UIParticle.scale will be adjusted.")]
		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x10C")]
		private AutoScalingMode m_AutoScalingMode;

		[SerializeField]
		[Tooltip("Use a custom view.\nUse this if the particles are not displayed correctly due to min/max particle size.")]
		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x110")]
		private bool m_UseCustomView;

		[SerializeField]
		[Tooltip("Custom view size.\nChange the bake view size.")]
		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x114")]
		private float m_CustomViewSize;

		[SerializeField]
		[Tooltip("Time scale multiplier.")]
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x118")]
		private float m_TimeScaleMultiplier;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x120")]
		private readonly List<UIParticleRenderer> _renderers;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x128")]
		private Camera _bakeCamera;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x130")]
		private int _groupId;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x134")]
		private bool _isScaleStored;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x138")]
		private Vector3 _storedScale;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x144")]
		private DrivenRectTransformTracker _tracker;

		[CompilerGenerated]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x148")]
		internal Vector3 _003CparentScale_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x154")]
		internal Vector3 _003CcanvasScale_003Ek__BackingField;

		[Token(Token = "0x17000006")]
		public override bool raycastTarget
		{
			[Token(Token = "0x6000091")]
			[Address(RVA = "0x3F22D50", Offset = "0x3F22D50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000092")]
			[Address(RVA = "0x3F22D58", Offset = "0x3F22D58", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x17000007")]
		public MeshSharing meshSharing
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x3F22D5C", Offset = "0x3F22D5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.meshSharing;\n")]
			get
			{
				return m_MeshSharing;
			}
			[Token(Token = "0x6000094")]
			[Address(RVA = "0x3F22D64", Offset = "0x3F22D64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.meshSharing = value;\n\treturn;\n")]
			set
			{
				m_MeshSharing = value;
			}
		}

		[Token(Token = "0x17000008")]
		public int groupId
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0x3F22D6C", Offset = "0x3F22D6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.groupId;\n")]
			get
			{
				return _groupId;
			}
			[Token(Token = "0x6000096")]
			[Address(RVA = "0x3F22D74", Offset = "0x3F22D74", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.m_GroupId == value;\n\tif (v7) goto L_0029;\n\tthis.m_GroupId = value;\n\tv17 = this.groupMaxId == value;\n\tif (v17) goto L_0029;\n\tv37 = this.groupMaxId + 1;\n\tv32 = UnityEngine.Random::Range(value, v37);\n\tthis.groupId = v32;\nL_0029:\n\treturn;\n")]
			set
			{
				if (m_GroupId != value)
				{
					m_GroupId = value;
					if (groupMaxId != value)
					{
						int maxExclusive = groupMaxId + 1;
						int num = UnityEngine.Random.Range(value, maxExclusive);
						_groupId = num;
					}
				}
			}
		}

		[Token(Token = "0x17000009")]
		public int groupMaxId
		{
			[Token(Token = "0x6000097")]
			[Address(RVA = "0x3F22E00", Offset = "0x3F22E00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.groupMaxId;\n")]
			get
			{
				return m_GroupMaxId;
			}
			[Token(Token = "0x6000098")]
			[Address(RVA = "0x3F22E08", Offset = "0x3F22E08", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = v32.groupMaxId == v37;\n\tif (v7) goto L_002A;\n\tv32.groupMaxId = v37;\n\tv17 = v32.m_GroupId == v37;\n\tif (v17) goto L_0029;\n\tv68 = v37 + 1;\n\tv72 = UnityEngine.Random::Range(v32.m_GroupId, v68);\nL_002A:\n\treturn;\nL_0029:\n\tv32.groupId = v72;\n")]
			set
			{
				int num = default(int);
				if (groupMaxId != num)
				{
					m_GroupMaxId = num;
					int num2 = default(int);
					if (m_GroupId != num)
					{
						int maxExclusive = num + 1;
						num2 = UnityEngine.Random.Range(m_GroupId, maxExclusive);
					}
					_groupId = num2;
				}
			}
		}

		[Token(Token = "0x1700000A")]
		public PositionMode positionMode
		{
			[Token(Token = "0x6000099")]
			[Address(RVA = "0x3F22E5C", Offset = "0x3F22E5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.positionMode;\n")]
			get
			{
				return m_PositionMode;
			}
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x3F22E64", Offset = "0x3F22E64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.positionMode = value;\n\treturn;\n")]
			set
			{
				m_PositionMode = value;
			}
		}

		[Obsolete("The absoluteMode is now obsolete. Please use the autoScalingMode instead.", false)]
		[Token(Token = "0x1700000B")]
		public bool absoluteMode
		{
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x3F22E6C", Offset = "0x3F22E6C", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.positionMode - 1;\n\tv6 = v4 == 0;\n\treturn v6;\n")]
			get
			{
				int num = (int)(positionMode - 1);
				return num == 0;
			}
			[Token(Token = "0x600009C")]
			[Address(RVA = "0x3F22E7C", Offset = "0x3F22E7C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.positionMode = value;\n\treturn;\n")]
			set
			{
				positionMode = (value ? PositionMode.Absolute : PositionMode.Relative);
			}
		}

		[Obsolete("The autoScaling is now obsolete. Please use the autoScalingMode instead.", false)]
		[Token(Token = "0x1700000C")]
		public bool autoScaling
		{
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x3F22E94", Offset = "0x3F22E94", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.autoScalingMode == 0;\n\tv11 = ~v6;\n\treturn v11;\n")]
			get
			{
				bool flag = autoScalingMode == AutoScalingMode.None;
				return !flag;
			}
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x3F22EA4", Offset = "0x3F22EA4", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = value == 0;\n\tv21 = ~v15;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv25 = 2;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv25 = 0;\nL_001E:\n\tv33 = this.autoScalingMode == v25;\n\tif (v33) goto L_0046;\n\tthis.autoScalingMode = v25;\n\tv84 = value == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0046;\n\tv49 = this._isScaleStored != 1;\n\tif (v49) goto L_0046;\n\tv39 = UnityEngine.Component::get_transform(this);\n\t// 62 MakeStruct v87 @ AGG3F22F00_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._storedScale (UnityEngine.Vector3), this._storedScale.y (System.Single), this._storedScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v39, v87);\n\tthis._isScaleStored = 0;\nL_0046:\n\treturn;\n")]
			set
			{
				int num = (value ? 2 : 0);
				if (autoScalingMode != (AutoScalingMode)num)
				{
					m_AutoScalingMode = (AutoScalingMode)num;
					if (!value && _isScaleStored)
					{
						Transform transform = base.transform;
						Vector3 localScale = default(Vector3);
						localScale.x = _storedScale.x;
						localScale.y = _storedScale.y;
						localScale.z = _storedScale.z;
						transform.localScale = localScale;
						_isScaleStored = false;
					}
				}
			}
		}

		[Token(Token = "0x1700000D")]
		public AutoScalingMode autoScalingMode
		{
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x3F22F80", Offset = "0x3F22F80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.autoScalingMode;\n")]
			get
			{
				return m_AutoScalingMode;
			}
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x3F22F18", Offset = "0x3F22F18", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this.autoScalingMode == value;\n\tif (v17) goto L_0039;\n\tthis.autoScalingMode = value;\n\tv26 = value == 2;\n\tif (v26) goto L_0039;\n\tv53 = this._isScaleStored != 1;\n\tif (v53) goto L_0039;\n\tv47 = UnityEngine.Component::get_transform(this);\n\t// 49 MakeStruct v32 @ AGG3F22F68_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._storedScale (UnityEngine.Vector3), this._storedScale.y (System.Single), this._storedScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v47, v32);\n\tthis._isScaleStored = 0;\nL_0039:\n\treturn;\n")]
			set
			{
				if (autoScalingMode != value)
				{
					m_AutoScalingMode = value;
					if (value != AutoScalingMode.Transform && _isScaleStored)
					{
						Transform transform = base.transform;
						Vector3 localScale = default(Vector3);
						localScale.x = _storedScale.x;
						localScale.y = _storedScale.y;
						localScale.z = _storedScale.z;
						transform.localScale = localScale;
						_isScaleStored = false;
					}
				}
			}
		}

		[Token(Token = "0x1700000E")]
		public bool useCustomView
		{
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x3F22F88", Offset = "0x3F22F88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.useCustomView;\n")]
			get
			{
				return m_UseCustomView;
			}
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0x3F22F90", Offset = "0x3F22F90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.useCustomView = value;\n\treturn;\n")]
			set
			{
				m_UseCustomView = value;
			}
		}

		[Token(Token = "0x1700000F")]
		public float customViewSize
		{
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x3F22F98", Offset = "0x3F22F98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.customViewSize;\n")]
			get
			{
				return m_CustomViewSize;
			}
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x3F22FA0", Offset = "0x3F22FA0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = v15 < 0x3DCCCCCD;\n\tv12 = ~v3;\n\tif (v12) goto L_0011;\n\tgoto L_0011;\nL_0011:\n\tthis.customViewSize = 0.1f;\n\treturn;\n")]
			set
			{
				float num = default(float);
				if (num < 0.1f)
				{
				}
				m_CustomViewSize = 0.1f;
			}
		}

		[Token(Token = "0x17000010")]
		public float timeScaleMultiplier
		{
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0x3F22FBC", Offset = "0x3F22FBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.timeScaleMultiplier;\n")]
			get
			{
				return m_TimeScaleMultiplier;
			}
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0x3F22FC4", Offset = "0x3F22FC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timeScaleMultiplier = value;\n\treturn;\n")]
			set
			{
				m_TimeScaleMultiplier = value;
			}
		}

		[Token(Token = "0x17000011")]
		internal bool useMeshSharing
		{
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0x3F22FCC", Offset = "0x3F22FCC", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.meshSharing == 0;\n\tv11 = ~v6;\n\treturn v11;\n")]
			get
			{
				bool flag = meshSharing == MeshSharing.None;
				return !flag;
			}
		}

		[Token(Token = "0x17000012")]
		internal bool isPrimary
		{
			[Token(Token = "0x60000A8")]
			[Address(RVA = "0x3F22FDC", Offset = "0x3F22FDC", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.meshSharing & -2;\n\tv5 = v2 - 2;\n\tv7 = v5 == 0;\n\treturn v7;\n")]
			get
			{
				int num = (int)(meshSharing & (MeshSharing)(-2));
				int num2 = num - 2;
				return num2 == 0;
			}
		}

		[Token(Token = "0x17000013")]
		internal bool canSimulate
		{
			[Token(Token = "0x60000A9")]
			[Address(RVA = "0x3F22FF0", Offset = "0x3F22FF0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.meshSharing < 4;\n\tv3 = ~v2;\n\tv11 = ~v3;\n\treturn v11;\n")]
			get
			{
				bool flag = (uint)meshSharing < 4u;
				bool flag2 = !flag;
				return !flag2;
			}
		}

		[Token(Token = "0x17000014")]
		internal bool canRender
		{
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0x3F23000", Offset = "0x3F23000", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.meshSharing < 5;\n\tv3 = ~v2;\n\tv11 = ~v3;\n\tv14 = 0x17 >> this.meshSharing;\n\treturnVal1 = v11 & v14;\n\treturn returnVal1;\n")]
			get
			{
				bool flag = (uint)meshSharing < 5u;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				int num = 23 >> (int)meshSharing;
				return (byte)((flag3 ? 1u : 0u) & (uint)num) != 0;
			}
		}

		[Token(Token = "0x17000015")]
		public float scale
		{
			[Token(Token = "0x60000AB")]
			[Address(RVA = "0x3F2301C", Offset = "0x3F2301C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scale3D;\n")]
			get
			{
				return scale3D.x;
			}
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x3F23024", Offset = "0x3F23024", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Scale3D.x = value;\n\tthis.m_Scale3D.y = value;\n\tthis.m_Scale3D.z = value;\n\treturn;\n")]
			set
			{
				m_Scale3D.x = value;
				m_Scale3D.y = value;
				m_Scale3D.z = value;
			}
		}

		[Token(Token = "0x17000016")]
		public Vector3 scale3D
		{
			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x3F23030", Offset = "0x3F23030", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scale3D;\n")]
			get
			{
				return m_Scale3D;
			}
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x3F2303C", Offset = "0x3F2303C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Scale3D.x = value;\n\tthis.m_Scale3D.y = value.y;\n\tthis.m_Scale3D.z = value.z;\n\treturn;\n")]
			set
			{
				m_Scale3D.x = value.x;
				m_Scale3D.y = value.y;
				m_Scale3D.z = value.z;
			}
		}

		[Token(Token = "0x17000017")]
		public Vector3 scale3DForCalc
		{
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x3F23048", Offset = "0x3F23048", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.scale3D;\n\tv22 = this.autoScalingMode == 2;\n\tif (v22) goto L_0030;\n\tv32 = UnityEngine.Component::get_transform(this);\n\tv90 = UnityEngine.Transform::get_localScale(v32);\n\tv40 = this.scale3D * this.canvasScale;\n\tv62 = v40 * v90;\n\treturnVal1 = v62;\nL_0030:\n\treturn returnVal1;\n")]
			get
			{
				Vector3 result = scale3D;
				if (autoScalingMode != AutoScalingMode.Transform)
				{
					Transform transform = base.transform;
					Vector3 localScale = transform.localScale;
					float num = scale3D.x * canvasScale.x;
					float x = num * localScale.x;
					result.x = x;
				}
				return result;
			}
		}

		[Token(Token = "0x17000018")]
		public List<ParticleSystem> particles
		{
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x3F230CC", Offset = "0x3F230CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.particles;\n")]
			get
			{
				return m_Particles;
			}
		}

		[Token(Token = "0x17000019")]
		[field: Token(Token = "0x400004A")]
		[field: FieldOffset(Offset = "0x145")]
		public bool isPaused
		{
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0x3F230D4", Offset = "0x3F230D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isPaused;\n")]
			get;
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0x3F230DC", Offset = "0x3F230DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPaused = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001A")]
		public Vector3 parentScale
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0x3F230E4", Offset = "0x3F230E4", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.parentScale;\n")]
			get
			{
				return _003CparentScale_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B4")]
			[Address(RVA = "0x3F230F4", Offset = "0x3F230F4", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<parentScale>k__BackingField.x = value;\n\tthis.<parentScale>k__BackingField.y = value.y;\n\tthis.<parentScale>k__BackingField.z = value.z;\n\treturn;\n")]
			private set
			{
				_003CparentScale_003Ek__BackingField.x = value.x;
				_003CparentScale_003Ek__BackingField.y = value.y;
				_003CparentScale_003Ek__BackingField.z = value.z;
			}
		}

		[Token(Token = "0x1700001B")]
		public Vector3 canvasScale
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B5")]
			[Address(RVA = "0x3F23104", Offset = "0x3F23104", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.canvasScale;\n")]
			get
			{
				return _003CcanvasScale_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B6")]
			[Address(RVA = "0x3F23114", Offset = "0x3F23114", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<canvasScale>k__BackingField.x = value;\n\tthis.<canvasScale>k__BackingField.y = value.y;\n\tthis.<canvasScale>k__BackingField.z = value.z;\n\treturn;\n")]
			private set
			{
				_003CcanvasScale_003Ek__BackingField.x = value.x;
				_003CcanvasScale_003Ek__BackingField.y = value.y;
				_003CcanvasScale_003Ek__BackingField.z = value.z;
			}
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x3F23124", Offset = "0x3F23124", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv59 = this.groupMaxId + 1;\n\tv64 = UnityEngine.Random::Range(v64, v59);\nL_0033:\n\tthis.groupId = v64;\n\tgoto L_003B;\nL_003B:\n\tCoffee.UIExtensions.UIParticleUpdater::Register(this);\n\tv82 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v82, this, Il2CppMethodInfo);\n\tUnityEngine.UI.Graphic::RegisterDirtyMaterialCallback(this, v82);\n\tv90 = this.particles;\n\tv104 = v90.Count < 1;\n\tif (v104) goto L_0065;\n\tCoffee.UIExtensions.UIParticle::RefreshParticles(this, v90);\n\tUnityEngine.UI.MaskableGraphic::OnEnable(this);\n\treturn;\nL_0065:\n\tv107 = UnityEngine.Component::get_gameObject(this);\n\tCoffee.UIExtensions.UIParticle::RefreshParticles(this, v107);\n\tUnityEngine.UI.MaskableGraphic::OnEnable(this);\n\treturn;\nL_001F:\n\tthis._isScaleStored = 0;\n\tv64 = this.m_GroupId;\n\tv51 = this.m_GroupId == this.groupMaxId;\n\tif (v51) goto L_0033;\n")]
		protected override void OnEnable()
		{
			_isScaleStored = false;
			int minInclusive = m_GroupId;
			if (m_GroupId != groupMaxId)
			{
				int maxExclusive = groupMaxId + 1;
				minInclusive = UnityEngine.Random.Range(minInclusive, maxExclusive);
			}
			_groupId = minInclusive;
			UIParticleUpdater.Register(this);
			UnityAction action = UpdateRendererMaterial;
			RegisterDirtyMaterialCallback(action);
			List<ParticleSystem> list = particles;
			if (list.Count >= 1)
			{
				RefreshParticles(list);
				base.OnEnable();
			}
			else
			{
				GameObject root = base.gameObject;
				RefreshParticles(root);
				base.OnEnable();
			}
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x3F23704", Offset = "0x3F23704", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv76 = this._isScaleStored != 1;\n\tif (v76) goto L_0052;\n\tv98 = UnityEngine.Component::get_transform(this);\n\t// 76 MakeStruct v78 @ AGG3F237C8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._storedScale (UnityEngine.Vector3), this._storedScale.y (System.Single), this._storedScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v98, v78);\nL_0052:\n\tthis._isScaleStored = 0;\n\tgoto L_0058;\nL_0058:\n\tCoffee.UIExtensions.UIParticleUpdater::Unregister(this);\n\tv249 = this._renderers;\n\tgoto L_0060;\nL_0060:\n\tv178 = v176.<>9__88_0 == 0;\n\tif (v178) goto L_0099;\n\tv245 = v176.<>9__88_0;\nL_006D:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::ForEach(v249, v245);\n\tv267 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v267, this, Il2CppMethodInfo);\n\tUnityEngine.UI.Graphic::UnregisterDirtyMaterialCallback(this, v267);\n\tUnityEngine.UI.MaskableGraphic::OnDisable(this);\n\treturn;\nL_0099:\n\tgoto L_00A1;\n\tv279 = this._renderers == 0;\n\tv159 = ~v279;\n\tv245 = v265;\n\tv249 = v249;\n\tif (v159) goto L_006D;\n\tthrow System.NullReferenceException;\nL_0028:\n\t;\n\tUnityEngine.DrivenRectTransformTracker::Clear(&this._tracker (UnityEngine.DrivenRectTransformTracker));\n\tv62 = this.autoScalingMode != 2;\n\tif (v62) goto L_0052;\nL_00A1:\n\tv265 = new System.Action`1<Coffee.UIExtensions.UIParticleRenderer>();\n\tSystem.Action`1<Coffee.UIExtensions.UIParticleRenderer>::.ctor(v265, v260.<>9, Il2CppMethodInfo);\n\tv275.<>9__88_0 = v265;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDisable()
		{
			_tracker.Clear();
			if (autoScalingMode == AutoScalingMode.Transform && _isScaleStored)
			{
				Transform transform = base.transform;
				Vector3 localScale = default(Vector3);
				localScale.x = _storedScale.x;
				localScale.y = _storedScale.y;
				localScale.z = _storedScale.z;
				transform.localScale = localScale;
			}
			_isScaleStored = false;
			UIParticleUpdater.Unregister(this);
			List<UIParticleRenderer> list = _renderers;
			Action<object> action;
			if (_003C_003Ec._003C_003E9__88_0 != null)
			{
				action = (Action<object>)_003C_003Ec._003C_003E9__88_0;
			}
			else
			{
				Action<UIParticleRenderer> action2 = (_003C_003Ec._003C_003E9__88_0 = delegate(UIParticleRenderer r)
				{
					r.Reset();
				});
				bool flag = _renderers == null;
				bool flag2 = !flag;
				action = (Action<object>)action2;
				list = list;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			list.ForEach(action);
			UnityAction action3 = UpdateRendererMaterial;
			UnregisterDirtyMaterialCallback(action3);
			base.OnDisable();
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x3F23A00", Offset = "0x3F23A00", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x3F23A04", Offset = "0x3F23A04", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x3F23A08", Offset = "0x3F23A08", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.m_IgnoreCanvasScaler == 0;\n\tv4 = ~v3;\n\tif (v4) goto L_001C;\n\tv10 = this.m_AutoScaling == 1;\n\tif (v10) goto L_001C;\n\tv64 = this.m_AbsoluteMode;\n\tv49 = this.m_AbsoluteMode == 1;\n\tif (v49) goto L_002C;\nL_001B:\n\treturn;\nL_001C:\n\tthis.m_IgnoreCanvasScaler = 0;\n\tthis.m_AutoScaling = 0;\n\tthis.autoScalingMode = 2;\n\tv64 = this.m_AbsoluteMode;\n\tv43 = this.m_AbsoluteMode != 1;\n\tif (v43) goto L_001B;\nL_002C:\n\tthis.m_AbsoluteMode = 0;\n\tthis.positionMode = v64;\n\treturn;\n")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			bool flag;
			if (!m_IgnoreCanvasScaler && !m_AutoScaling)
			{
				flag = m_AbsoluteMode;
				if (!m_AbsoluteMode)
				{
					return;
				}
			}
			else
			{
				m_IgnoreCanvasScaler = false;
				m_AutoScaling = false;
				m_AutoScalingMode = AutoScalingMode.Transform;
				flag = m_AbsoluteMode;
				if (!m_AbsoluteMode)
				{
					return;
				}
			}
			m_AbsoluteMode = false;
			positionMode = (flag ? PositionMode.Absolute : PositionMode.Relative);
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x3F23A54", Offset = "0x3F23A54", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv126 = this.particles;\n\tgoto L_001A;\nL_001A:\n\tv112 = v58.<>9__92_0;\n\tv60 = v58.<>9__92_0 == 0;\n\tif (v60) goto L_004F;\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::Exec(v126, v112);\n\tthis.isPaused = 0;\n\treturn;\nL_004F:\n\tgoto L_0057;\n\tv112 = v138;\n\tv126 = v126;\n\tgoto L_0023;\nL_0057:\n\tv138 = new System.Action`1<UnityEngine.ParticleSystem>();\n\tSystem.Action`1<UnityEngine.ParticleSystem>::.ctor(v138, v133.<>9, Il2CppMethodInfo);\n\tv157.<>9__92_0 = v138;\n")]
		public void Play()
		{
			List<ParticleSystem> list = particles;
			Action<ParticleSystem> action = _003C_003Ec._003C_003E9__92_0;
			if (_003C_003Ec._003C_003E9__92_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__92_0 = delegate(ParticleSystem p)
				{
					p.Simulate(0f, withChildren: false, restart: true);
				});
				list = list;
			}
			list.Exec(action);
			isPaused = false;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x3F23BA4", Offset = "0x3F23BA4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv126 = this.particles;\n\tgoto L_001A;\nL_001A:\n\tv112 = v58.<>9__93_0;\n\tv60 = v58.<>9__93_0 == 0;\n\tif (v60) goto L_0050;\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::Exec(v126, v112);\n\tthis.isPaused = 1;\n\treturn;\nL_0050:\n\tgoto L_0058;\n\tv112 = v138;\n\tv126 = v126;\n\tgoto L_0023;\nL_0058:\n\tv138 = new System.Action`1<UnityEngine.ParticleSystem>();\n\tSystem.Action`1<UnityEngine.ParticleSystem>::.ctor(v138, v133.<>9, Il2CppMethodInfo);\n\tv158.<>9__93_0 = v138;\n")]
		public void Pause()
		{
			List<ParticleSystem> list = particles;
			Action<ParticleSystem> action = _003C_003Ec._003C_003E9__93_0;
			if (_003C_003Ec._003C_003E9__93_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__93_0 = delegate(ParticleSystem p)
				{
					p.Pause();
				});
				list = list;
			}
			list.Exec(action);
			isPaused = true;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x3F23CF8", Offset = "0x3F23CF8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isPaused = 0;\n\treturn;\n")]
		public void Resume()
		{
			isPaused = false;
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x3F23D00", Offset = "0x3F23D00", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv126 = this.particles;\n\tgoto L_001A;\nL_001A:\n\tv112 = v58.<>9__95_0;\n\tv60 = v58.<>9__95_0 == 0;\n\tif (v60) goto L_0050;\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::Exec(v126, v112);\n\tthis.isPaused = 1;\n\treturn;\nL_0050:\n\tgoto L_0058;\n\tv112 = v138;\n\tv126 = v126;\n\tgoto L_0023;\nL_0058:\n\tv138 = new System.Action`1<UnityEngine.ParticleSystem>();\n\tSystem.Action`1<UnityEngine.ParticleSystem>::.ctor(v138, v133.<>9, Il2CppMethodInfo);\n\tv158.<>9__95_0 = v138;\n")]
		public void Stop()
		{
			List<ParticleSystem> list = particles;
			Action<ParticleSystem> action = _003C_003Ec._003C_003E9__95_0;
			if (_003C_003Ec._003C_003E9__95_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__95_0 = delegate(ParticleSystem p)
				{
					p.Stop();
				});
				list = list;
			}
			list.Exec(action);
			isPaused = true;
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x3F23E54", Offset = "0x3F23E54", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv126 = this.particles;\n\tgoto L_001A;\nL_001A:\n\tv123 = v58.<>9__96_0;\n\tv60 = v58.<>9__96_0 == 0;\n\tif (v60) goto L_004E;\n\tgoto L_002C;\nL_002C:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::Exec(v126, v123);\n\treturn;\nL_004E:\n\tgoto L_0056;\n\tv123 = v146;\n\tv126 = v126;\n\tgoto L_002C;\nL_0056:\n\tv146 = new System.Action`1<UnityEngine.ParticleSystem>();\n\tSystem.Action`1<UnityEngine.ParticleSystem>::.ctor(v146, v141.<>9, Il2CppMethodInfo);\n\tv157.<>9__96_0 = v146;\n")]
		public void StartEmission()
		{
			List<ParticleSystem> list = particles;
			Action<ParticleSystem> action = _003C_003Ec._003C_003E9__96_0;
			if (_003C_003Ec._003C_003E9__96_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__96_0 = delegate(ParticleSystem p)
				{
					ParticleSystem.EmissionModule emission = p.emission;
					ParticleSystem.EmissionModule emissionModule = emission;
					emissionModule.enabled = true;
				});
				list = list;
			}
			list.Exec(action);
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x3F23F9C", Offset = "0x3F23F9C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv126 = this.particles;\n\tgoto L_001A;\nL_001A:\n\tv123 = v58.<>9__97_0;\n\tv60 = v58.<>9__97_0 == 0;\n\tif (v60) goto L_004E;\n\tgoto L_002C;\nL_002C:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::Exec(v126, v123);\n\treturn;\nL_004E:\n\tgoto L_0056;\n\tv123 = v146;\n\tv126 = v126;\n\tgoto L_002C;\nL_0056:\n\tv146 = new System.Action`1<UnityEngine.ParticleSystem>();\n\tSystem.Action`1<UnityEngine.ParticleSystem>::.ctor(v146, v141.<>9, Il2CppMethodInfo);\n\tv157.<>9__97_0 = v146;\n")]
		public void StopEmission()
		{
			List<ParticleSystem> list = particles;
			Action<ParticleSystem> action = _003C_003Ec._003C_003E9__97_0;
			if (_003C_003Ec._003C_003E9__97_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__97_0 = delegate(ParticleSystem p)
				{
					ParticleSystem.EmissionModule emission = p.emission;
					ParticleSystem.EmissionModule emissionModule = emission;
					emissionModule.enabled = false;
				});
				list = list;
			}
			list.Exec(action);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x3F240E4", Offset = "0x3F240E4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv126 = this.particles;\n\tgoto L_001A;\nL_001A:\n\tv112 = v58.<>9__98_0;\n\tv60 = v58.<>9__98_0 == 0;\n\tif (v60) goto L_0050;\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.ParticleSystemExtensions::Exec(v126, v112);\n\tthis.isPaused = 1;\n\treturn;\nL_0050:\n\tgoto L_0058;\n\tv112 = v138;\n\tv126 = v126;\n\tgoto L_0023;\nL_0058:\n\tv138 = new System.Action`1<UnityEngine.ParticleSystem>();\n\tSystem.Action`1<UnityEngine.ParticleSystem>::.ctor(v138, v133.<>9, Il2CppMethodInfo);\n\tv158.<>9__98_0 = v138;\n")]
		public void Clear()
		{
			List<ParticleSystem> list = particles;
			Action<ParticleSystem> action = _003C_003Ec._003C_003E9__98_0;
			if (_003C_003Ec._003C_003E9__98_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__98_0 = delegate(ParticleSystem p)
				{
					p.Clear();
				});
				list = list;
			}
			list.Exec(action);
			isPaused = true;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x3F24238", Offset = "0x3F24238", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv112 = this._renderers;\n\tv118 = 0;\n\tgoto L_0044;\nL_0036:\n\tv118 = v118 + 1;\n\tv112 = this._renderers;\nL_0044:\n\tv76 = v118 >= v112.Count;\n\tif (v76) goto L_009D;\n\tv235 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(v112, v118);\n\tgoto L_0050;\nL_0050:\n\tv240 = UnityEngine.Object::op_Implicit(v235);\n\tv242 = ~v240;\n\tif (v242) goto L_0036;\n\tgoto L_005C;\nL_005C:\n\tv277 = *([v235 @ X0_v7 (UnityEngine.Object)]);\n\t*([v277 @ X8_v8 (Il2CppClass<UnityEngine.Object>)+338])(v281, v235, *([v277 @ X8_v8 (Il2CppClass<UnityEngine.Object>)+340]), Il2CppMethodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0066;\nL_0066:\n\tv266 = UnityEngine.Object::op_Implicit(v281);\n\tv271 = ~v266;\n\tif (v271) goto L_0036;\n\tgoto L_0072;\nL_0072:\n\tv289 = *([v235 @ X0_v7 (UnityEngine.Object)]);\n\t*([v289 @ X8_v10 (Il2CppClass<UnityEngine.Object>)+338])(v181, v235, *([v289 @ X8_v10 (Il2CppClass<UnityEngine.Object>)+340]), Il2CppMethodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0090;\nL_0090:\n\tSystem.Collections.Generic.List`1<UnityEngine.Material>::Add(result, v181);\n\tgoto L_0036;\nL_009D:\n\treturn;\nL_0022:\n\tv52 = result == 0;\n\tif (v52) goto L_009D;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GetMaterials(List<Material> result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticle::GetMaterials");
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x3F243FC", Offset = "0x3F243FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCoffee.UIExtensions.UIParticle::SetParticleSystemInstance(this, instance, 1);\n\treturn;\n")]
		public void SetParticleSystemInstance(GameObject instance)
		{
			SetParticleSystemInstance(instance, destroyOldParticles: true);
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x3F24404", Offset = "0x3F24404", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv63 = 0;\n\tgoto L_0020;\nL_0020:\n\tv71 = UnityEngine.Object::op_Implicit(instance);\n\tv81 = ~v71;\n\tv82 = ~v81;\n\tif (v82) goto L_0040;\n\tgoto L_00FE;\nL_0040:\n\tv99 = UnityEngine.Component::get_transform(this);\n\tv249 = UnityEngine.Transform::get_childCount(v99);\n\tv129 = v249 < 1;\n\tif (v129) goto L_00CC;\nL_FFFFFFFF:\n\tv258 = 0;\n\tgoto L_0068;\nL_005A:\n\tUnityEngine.Object::Destroy(v275);\nL_005B:\n\tv258 = v258 + 1;\n\tv311 = v249 == v258;\n\tif (v311) goto L_00CC;\nL_0068:\n\tv273 = UnityEngine.Component::get_transform(this);\n\tv274 = UnityEngine.Transform::GetChild(v273, v258);\n\tv275 = UnityEngine.Component::get_gameObject(v274);\n\tv348 = UnityEngine.GameObject::TryGetComponent(v275, &v317 @ stack_-68_v6 (UnityEngine.Camera));\n\tv349 = ~v348;\n\tif (v349) goto L_0096;\n\tgoto L_0081;\nL_0081:\n\tv365 = UnityEngine.Object::op_Equality(v317, this._bakeCamera);\n\tv382 = v365 == 0;\n\tv368 = ~v382;\n\tif (v368) goto L_005B;\n\tgoto L_0096;\nL_0096:\n\tv375 = UnityEngine.GameObject::TryGetComponent(v275, &v63 @ stack_-70_v5 (Coffee.UIExtensions.UIParticleRenderer));\n\tv379 = v375 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_005B;\n\tUnityEngine.GameObject::SetActive(v275, 0);\n\tv397 = ~destroyOldParticles;\n\tif (v397) goto L_005B;\n\tgoto L_00A9;\nL_00A9:\n\tgoto L_00AC;\nL_00AC:\n\tv394 = UnityEngine.Object::op_Implicit(v275);\n\tv398 = ~v394;\n\tif (v398) goto L_005B;\n\tgoto L_00C4;\nL_00C4:\n\tgoto L_005A;\nL_00CC:\n\tv329 = UnityEngine.GameObject::get_transform(instance);\n\tv277 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v329, v277, 0);\n\tgoto L_00EC;\nL_00FE:\n\treturn;\nL_00EC:\n\t// 236 MakeStruct v103 @ AGG3F246B0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v169.zero (UnityEngine.Vector3), v169.zero.y (System.Single), v169.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v329, v103);\n\tCoffee.UIExtensions.UIParticle::RefreshParticles(this, instance);\n")]
		public void SetParticleSystemInstance(GameObject instance, bool destroyOldParticles)
		{
			UIParticleRenderer component = null;
			if (!instance)
			{
				return;
			}
			Transform transform = base.transform;
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num = 0;
				do
				{
					Transform transform2 = base.transform;
					Transform child = transform2.GetChild(num);
					GameObject gameObject = child.gameObject;
					if ((!gameObject.TryGetComponent<Camera>(out var component2) || !(component2 == _bakeCamera)) && !gameObject.TryGetComponent<UIParticleRenderer>(out component))
					{
						gameObject.SetActive(value: false);
						if (destroyOldParticles && (bool)gameObject)
						{
							UnityEngine.Object.Destroy(gameObject);
						}
					}
					num++;
				}
				while (childCount != num);
			}
			Transform transform3 = instance.transform;
			Transform parent = base.transform;
			transform3.SetParent(parent, worldPositionStays: false);
			Vector3 localPosition = default(Vector3);
			localPosition.x = Vector3.zero.x;
			localPosition.y = Vector3.zero.y;
			localPosition.z = Vector3.zero.z;
			transform3.localPosition = localPosition;
			RefreshParticles(instance);
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x3F24978", Offset = "0x3F24978", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv52 = UnityEngine.Object::op_Implicit(prefab);\n\tv60 = ~v52;\n\tif (v60) goto L_0053;\n\tv117 = UnityEngine.GameObject::get_gameObject(prefab);\n\tgoto L_002B;\nL_0053:\n\treturn;\nL_002B:\n\tv122 = UnityEngine.Object::Instantiate(v117);\n\tCoffee.UIExtensions.UIParticle::SetParticleSystemInstance(this, v122, 1);\n\treturn;\n")]
		public void SetParticleSystemPrefab(GameObject prefab)
		{
			if ((bool)prefab)
			{
				GameObject original = prefab.gameObject;
				GameObject instance = UnityEngine.Object.Instantiate(original);
				SetParticleSystemInstance(instance, destroyOldParticles: true);
			}
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x3F236D8", Offset = "0x3F236D8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tCoffee.UIExtensions.UIParticle::RefreshParticles(this, v13);\n\treturn;\n")]
		public void RefreshParticles()
		{
			GameObject root = base.gameObject;
			RefreshParticles(root);
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x3F246E4", Offset = "0x3F246E4", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Implicit(root);\n\tv72 = ~v63;\n\tv73 = ~v72;\n\tif (v73) goto L_0043;\n\tgoto L_00EC;\nL_0043:\n\t;\n\tUnityEngine.GameObject::GetComponentsInChildren(root, 1, this.particles);\n\tv131 = this.particles;\n\tv250 = v131.Count;\n\tv290 = v131.Count < 1;\n\tif (v290) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_0064:\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::RemoveAt(this.particles, v250);\nL_FFFFFFFF:\n\t;\nL_0070:\n\tv165 = v250 <= 0;\n\tif (v165) goto L_00A6;\nL_0075:\n\tv250 = v250 - 1;\n\tv336 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Item(this.particles, v250);\n\tgoto L_0080;\nL_0080:\n\tv342 = UnityEngine.Object::op_Implicit(v336);\n\tv346 = ~v342;\n\tif (v346) goto L_0064;\n\tgoto L_008F;\nL_008F:\n\tv383 = UnityEngine.Component::GetComponentInParent(v336, 1);\n\tgoto L_0096;\nL_0096:\n\tv359 = UnityEngine.Object::op_Inequality(v383, this);\n\tv391 = ~v359;\n\tv363 = ~v391;\n\tif (v363) goto L_0064;\nL_FFFFFFFF:\n\t;\n\tgoto L_0070;\nL_00A6:\n\tv131 = this.particles;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv143 = 0;\n\tgoto L_00BB;\nL_00AD:\n\tv143 = v143 + 1;\n\tv131 = this.particles;\nL_FFFFFFFF:\n\t;\nL_00BB:\n\tv94 = v143 >= v131.Count;\n\tif (v94) goto L_00E0;\n\tv227 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Item(v131, v143);\n\tv345 = UnityEngine.ParticleSystem::get_textureSheetAnimation(v227);\n\tv229 = v345;\n\tv352 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_mode(&v229 @ stack_-58_v5 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv166 = v352 != 1;\nL_FFFFFFFF:\n\t;\n\tif (v166) goto L_00AD;\n\tv373 = UnityEngine.ParticleSystem+TextureSheetAnimationModule::get_uvChannelMask(&v229 @ stack_-58_v5 (UnityEngine.ParticleSystem+TextureSheetAnimationModule));\n\tv387 = v373 == 0;\n\tv379 = ~v387;\nL_FFFFFFFF:\n\t;\n\tif (v379) goto L_00AD;\n\tUnityEngine.ParticleSystem+TextureSheetAnimationModule::set_uvChannelMask(&v229 @ stack_-58_v5 (UnityEngine.ParticleSystem+TextureSheetAnimationModule), 1);\nL_FFFFFFFF:\n\t;\n\tgoto L_00AD;\nL_00E0:\n\tCoffee.UIExtensions.UIParticle::RefreshParticles(this, v131);\nL_00EC:\n\treturn;\n")]
		private void RefreshParticles(GameObject root)
		{
			if (!root)
			{
				return;
			}
			root.GetComponentsInChildren(includeInactive: true, particles);
			List<ParticleSystem> list = particles;
			int num = list.Count;
			if (list.Count >= 1)
			{
				do
				{
					num--;
					UnityEngine.Object obj = particles[num];
					if ((bool)obj)
					{
						UIParticle componentInParent = ((Component)obj).GetComponentInParent<UIParticle>(true);
						if (!(componentInParent != this))
						{
							continue;
						}
					}
					particles.RemoveAt(num);
				}
				while (num > 0);
				list = particles;
			}
			int num2 = 0;
			while (num2 < list.Count)
			{
				ParticleSystem particleSystem = list[num2];
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = particleSystem.textureSheetAnimation;
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = textureSheetAnimation;
				ParticleSystemAnimationMode mode = textureSheetAnimationModule.mode;
				if (mode == ParticleSystemAnimationMode.Sprites && textureSheetAnimationModule.uvChannelMask == (UVChannelFlags)0)
				{
					textureSheetAnimationModule.uvChannelMask = UVChannelFlags.UV0;
				}
				num2++;
				list = particles;
			}
			RefreshParticles(list);
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x3F2339C", Offset = "0x3F2339C", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::Clear(v58);\n\tv76 = v58.Count < 1;\n\tif (v76) goto L_004F;\nL_004F:\n\tv231 = UnityEngine.Component::get_transform(this);\n\tv301 = UnityEngine.Transform::get_childCount(v231);\n\tv154 = v301 < 1;\n\tif (v154) goto L_00A4;\nL_FFFFFFFF:\n\tv130 = 0;\n\tgoto L_0078;\nL_006A:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::Add(v234, v116);\nL_006B:\n\tv130 = v130 + 1;\n\tv397 = v301 == v130;\n\tif (v397) goto L_00A4;\nL_0078:\n\tv232 = UnityEngine.Component::get_transform(this);\n\tv233 = UnityEngine.Transform::GetChild(v232, v130);\n\tv462 = UnityEngine.Component::TryGetComponent(v233, &v116 @ stack_-68_v6 (Coffee.UIExtensions.UIParticleRenderer));\n\tv468 = ~v462;\n\tif (v468) goto L_006B;\n\tv234 = this._renderers;\n\tgoto L_006A;\nL_00A4:\n\tv279 = this._renderers;\n\tv92 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv264 = 0;\n\tv236 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(v279, v264);\n\tCoffee.UIExtensions.UIParticleRenderer::Reset(v236, v264);\n\tv264 = v264 + 1;\n\tv279 = this._renderers;\n\tv469 = this._renderers == 0;\n\tv241 = ~v469;\n\tif (v241) goto L_00BA;\n\tv267 = new System.NullReferenceException();\nL_00D6:\n\tv296 = particleSystems.Count < 1;\n\tif (v296) goto L_0137;\nL_FFFFFFFF:\n\tv314 = 0;\nL_FFFFFFFF:\n\tv266 = 0;\n\tgoto L_00E9;\nL_FFFFFFFF:\n\tv314 = v84;\nL_00E9:\n\t;\n\tv381 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Item(particleSystems, v266);\n\tv408 = *([v92 @ X27_v3 (System.Int32)]);\n\tv410 = *([v408 @ X0_v7+E4]) == 0;\n\tif (v410) goto L_00FB;\n\tv425 = UnityEngine.Object::op_Implicit(v381);\n\tv440 = ~v425;\n\tif (v440) goto L_00DC;\n\tgoto L_0102;\nL_00FB:\n\tv443 = UnityEngine.Object::op_Implicit(v381);\n\tv453 = ~v443;\n\tif (v453) goto L_00DC;\nL_0102:\n\tgoto L_0106;\nL_0106:\n\tv467 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetMainEmitter(v381, particleSystems);\n\tv238 = Coffee.UIExtensions.UIParticle::GetRenderer(this, v314);\n\tCoffee.UIExtensions.UIParticleRenderer::Set(v238, this, v381, 0, v467);\n\tv84 = v314 + 1;\n\tv503 = UnityEngine.ParticleSystem::get_trails(v381);\n\tv80 = v503;\n\tv451 = UnityEngine.ParticleSystem+TrailModule::get_enabled(&v80 @ stack_-70_v6 (UnityEngine.ParticleSystem+TrailModule));\n\tv452 = ~v451;\n\tif (v452) goto L_FFFFFFFF;\n\tv239 = Coffee.UIExtensions.UIParticle::GetRenderer(this, v84);\n\tv314 = v314 + 2;\n\tCoffee.UIExtensions.UIParticleRenderer::Set(v239, this, v381, 1, v467);\n\tgoto L_00DC;\nL_0137:\n\treturn;\nL_0035:\n\tv58 = this._renderers;\nL_00BA:\n\tv153 = v264 >= v279.Count;\n\tif (v153) goto L_00D6;\nL_00DC:\n\tv266 = v266 + 1;\n\tv320 = v266 >= particleSystems.Count;\n\tif (v320) goto L_0137;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshParticles(List<ParticleSystem> particleSystems)
		{
			//IL_0225: Expected O, but got I4
			List<UIParticleRenderer> renderers = _renderers;
			renderers.Clear();
			if (renderers.Count >= 1)
			{
			}
			Transform transform = base.transform;
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num = 0;
				do
				{
					Transform transform2 = base.transform;
					Transform child = transform2.GetChild(num);
					if (child.TryGetComponent<UIParticleRenderer>(out var component))
					{
						List<UIParticleRenderer> renderers2 = _renderers;
						renderers2.Add(component);
					}
					num++;
				}
				while (childCount != num);
			}
			List<UIParticleRenderer> renderers3 = _renderers;
			int num2 = 187244544 + 1440;
			int num3 = 0;
			while (num3 < renderers3.Count)
			{
				UIParticleRenderer uIParticleRenderer = renderers3[num3];
				uIParticleRenderer.Reset(num3);
				num3++;
				renderers3 = _renderers;
				if (_renderers == null)
				{
					NullReferenceException ex = new NullReferenceException();
					break;
				}
			}
			if (particleSystems.Count < 1)
			{
				return;
			}
			int num4 = 0;
			int num5 = 0;
			do
			{
				ParticleSystem particleSystem = particleSystems[num5];
				object obj = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ X0_v7+E4]");
				if ((nint)0 != 0)
				{
					if ((bool)particleSystem)
					{
						goto IL_02a6;
					}
				}
				else if ((bool)particleSystem)
				{
					goto IL_02a6;
				}
				goto IL_03a5;
				IL_02a6:
				ParticleSystem mainEmitter = particleSystem.GetMainEmitter(particleSystems);
				UIParticleRenderer renderer = GetRenderer(num4);
				renderer.Set(this, particleSystem, isTrail: false, mainEmitter);
				int num6 = num4 + 1;
				ParticleSystem.TrailModule trails = particleSystem.trails;
				ParticleSystem.TrailModule trailModule = trails;
				if (!trailModule.enabled)
				{
					num4 = num6;
				}
				else
				{
					UIParticleRenderer renderer2 = GetRenderer(num6);
					num4 += 2;
					renderer2.Set(this, particleSystem, isTrail: true, mainEmitter);
				}
				goto IL_03a5;
				IL_03a5:
				num5++;
			}
			while (num5 < particleSystems.Count);
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x3F2523C", Offset = "0x3F2523C", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.DrivenRectTransformTracker::Clear(&this._tracker (UnityEngine.DrivenRectTransformTracker));\n\tv28 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv31 = UnityEngine.Canvas::get_rootCanvas(v28);\n\tv148 = UnityEngine.Component::get_transform(v31);\n\tv250 = UnityEngine.Transform::get_localScale(v148);\n\tv129 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v250);\n\tthis.<canvasScale>k__BackingField.x = v129;\n\tthis.<canvasScale>k__BackingField.y = v129.y;\n\tthis.<canvasScale>k__BackingField.z = v129.z;\n\tv149 = UnityEngine.Component::get_transform(this);\n\tv150 = UnityEngine.Transform::get_parent(v149);\n\tv130 = UnityEngine.Transform::get_lossyScale(v150);\n\tthis.<parentScale>k__BackingField.x = v130;\n\tthis.<parentScale>k__BackingField.y = v130.y;\n\tthis.<parentScale>k__BackingField.z = v130.z;\n\tv68 = this.autoScalingMode != 2;\n\tif (v68) goto L_00C4;\n\tv151 = UnityEngine.Component::get_transform(this);\n\tv272 = UnityEngine.Transform::get_localScale(v151);\n\tv288 = this._isScaleStored == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_007E;\n\tgoto L_0077;\n\tv349 = v272 - v131;\n\tv350 = v272.y - v131.y;\n\tv34 = v272.z - v131.z;\n\tv351 = v349 * v349;\n\tv352 = v350 * v350;\n\tv353 = v351 + v352;\n\tv354 = v34 * v34;\n\tv40 = v354 + v353;\n\tv97 = v40 < 0x2EDBE6FE;\n\tif (v97) goto L_00DD;\n\tv152 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::set_localScale(v152, v131);\n\treturn;\nL_00C4:\n\tv70 = this._isScaleStored != 1;\n\tif (v70) goto L_00D1;\n\tv153 = UnityEngine.Component::get_transform(this);\n\t// 207 MakeStruct v260 @ AGG3F25450_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._storedScale (UnityEngine.Vector3), this._storedScale.y (System.Single), this._storedScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v153, v260);\nL_00D1:\n\tthis._isScaleStored = 0;\nL_007E:\n\tv323 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tUnityEngine.DrivenRectTransformTracker::Add(&this._tracker (UnityEngine.DrivenRectTransformTracker), this, v323, 0xE0);\n\t// 136 MakeStruct v43 @ AGG3F253A8_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.parentScale (UnityEngine.Vector3), this.<parentScale>k__BackingField.y (System.Single), this.<parentScale>k__BackingField.z (System.Single)\n\tv131 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v43);\nL_0077:\n\tthis._storedScale.x = v272;\n\tthis._storedScale.y = v272.y;\n\tthis._storedScale.z = v272.z;\n\tthis._isScaleStored = 1;\nL_00DD:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void UpdateTransformScale()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticle::UpdateTransformScale");
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x3F25474", Offset = "0x3F25474", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv198 = this._renderers;\n\tv166 = 0xB292000 + 0x5A0;\n\tv201 = 0;\n\tv229 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(v198, v201);\n\tgoto L_0042;\n\tv201 = v201 + 1;\n\tv198 = this._renderers;\n\tv255 = this._renderers == 0;\n\tv174 = ~v255;\n\tif (v174) goto L_0033;\n\tthrow System.NullReferenceException;\nL_004C:\n\t;\n\tCoffee.UIExtensions.UIParticle::RefreshParticles(this, this.particles);\nL_0050:\n\tv234 = Coffee.UIExtensions.UIParticle::GetBakeCamera(this);\n\tv101 = this._renderers;\n\tv88 = 0;\n\tgoto L_0065;\nL_0057:\n\tv88 = v88 + 1;\n\tv101 = this._renderers;\nL_0065:\n\tv62 = v88 >= v101.Count;\n\tif (v62) goto L_008A;\n\tv257 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(v101, v88);\n\tv258 = *([v166 @ X24_v5 (System.Int32)]);\n\tv259 = *([v258 @ X0_v12+E4]) == 0;\n\tif (v259) goto L_0078;\n\tv262 = UnityEngine.Object::op_Implicit(v257);\n\tv264 = ~v262;\n\tif (v264) goto L_0057;\n\tgoto L_007F;\nL_0078:\n\tv267 = UnityEngine.Object::op_Implicit(v257);\n\tv272 = ~v267;\n\tif (v272) goto L_0057;\nL_007F:\n\tCoffee.UIExtensions.UIParticleRenderer::UpdateMesh(v257, v234);\n\tgoto L_0057;\nL_008A:\n\treturn;\nL_001E:\n\tv49 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv53 = ~v49;\n\tif (v53) goto L_008A;\nL_0042:\n\tv221 = UnityEngine.Object::op_Implicit(v229);\n\tv223 = v221 == 0;\n\tif (v223) goto L_004C;\nL_0033:\n\tv125 = v201 >= v198.Count;\n\tif (v125) goto L_0050;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void UpdateRenderers()
		{
			//IL_0123: Expected O, but got I4
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			List<UIParticleRenderer> renderers = _renderers;
			int num = 187244544 + 1440;
			int num2 = 0;
			while (num2 < renderers.Count)
			{
				UIParticleRenderer uIParticleRenderer = renderers[num2];
				if ((bool)uIParticleRenderer)
				{
					num2++;
					renderers = _renderers;
					if (_renderers == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				RefreshParticles(particles);
				break;
			}
			Camera bakeCamera = GetBakeCamera();
			List<UIParticleRenderer> renderers2 = _renderers;
			for (int i = 0; i < renderers2.Count; i++, renderers2 = _renderers)
			{
				UnityEngine.Object obj = renderers2[i];
				object obj2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ X0_v12+E4]");
				if ((nint)0 != 0)
				{
					if (!obj)
					{
						continue;
					}
				}
				else if (!obj)
				{
					continue;
				}
				((UIParticleRenderer)obj).UpdateMesh(bakeCamera);
			}
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x3F22DC4", Offset = "0x3F22DC4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = this.m_GroupId;\n\tv18 = this.m_GroupId == this.groupMaxId;\n\tif (v18) goto L_0016;\n\tv23 = this.groupMaxId + 1;\n\tv30 = UnityEngine.Random::Range(v30, v23);\nL_0016:\n\tthis.groupId = v30;\n\treturn;\n")]
		internal void ResetGroupId()
		{
			int minInclusive = m_GroupId;
			if (m_GroupId != groupMaxId)
			{
				int maxExclusive = groupMaxId + 1;
				minInclusive = UnityEngine.Random.Range(minInclusive, maxExclusive);
			}
			_groupId = minInclusive;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x3F26C30", Offset = "0x3F26C30", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x3F26C34", Offset = "0x3F26C34", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x3F26C38", Offset = "0x3F26C38", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv109 = 0;\n\tgoto L_0033;\nL_0025:\n\tv109 = v109 + 1;\n\tv125 = this._renderers;\nL_0033:\n\tv70 = v109 >= v125.Count;\n\tif (v70) goto L_005E;\n\tv131 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(v125, v109);\n\tgoto L_003F;\nL_003F:\n\tv167 = UnityEngine.Object::op_Implicit(v131);\n\tv169 = ~v167;\n\tif (v169) goto L_0025;\n\tgoto L_004E;\nL_004E:\n\tUnityEngine.UI.MaskableGraphic::set_maskable(v131, this.maskable);\n\tv180 = *([v131 @ X0_v6 (UnityEngine.Object)]);\n\t*([v180 @ X8_v7 (Il2CppClass<UnityEngine.Object>)+308])(v177, v131, *([v180 @ X8_v7 (Il2CppClass<UnityEngine.Object>)+310]), 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0025;\nL_005E:\n\treturn;\nL_001C:\n\tv125 = this._renderers;\n")]
		private void UpdateRendererMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticle::UpdateRendererMaterial");
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x3F24CB4", Offset = "0x3F24CB4", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv61 = v44.Count > index;\n\tif (v61) goto L_006C;\n\tgoto L_003F;\nL_003F:\n\tv118 = Coffee.UIExtensions.UIParticleRenderer::AddRenderer(this, index);\n\tgoto L_0062;\nL_0062:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::Add(v44, v118);\nL_006C:\n\tv174 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(this._renderers, index);\n\tgoto L_0072;\nL_0072:\n\tv223 = UnityEngine.Object::op_Implicit(v174);\n\tv231 = v223 == 0;\n\tif (v231) goto L_0088;\n\tgoto L_00A2;\nL_0088:\n\tgoto L_008C;\nL_008C:\n\tv120 = Coffee.UIExtensions.UIParticleRenderer::AddRenderer(this, index);\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::set_Item(this._renderers, index, v120);\nL_00A2:\n\treturnVal2 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::get_Item(this._renderers, index);\n\treturn returnVal2;\nL_0024:\n\tv44 = this._renderers;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal UIParticleRenderer GetRenderer(int index)
		{
			List<UIParticleRenderer> renderers = _renderers;
			if (renderers.Count <= index)
			{
				UIParticleRenderer item = UIParticleRenderer.AddRenderer(this, index);
				renderers.Add(item);
			}
			UnityEngine.Object obj = _renderers[index];
			if (!obj)
			{
				UIParticleRenderer value = UIParticleRenderer.AddRenderer(this, index);
				_renderers[index] = value;
			}
			return _renderers[index];
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x3F255EC", Offset = "0x3F255EC", Length = "0x554")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_002D:\n\tv63 = UnityEngine.Object::op_Implicit(v52);\n\tv71 = v63 == 0;\n\tif (v71) goto L_007B;\n\tv84 = this.useCustomView == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_008A;\n\tv104 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv113 = UnityEngine.Canvas::get_renderMode(v104);\n\tv117 = v113 == 0;\n\tif (v117) goto L_008A;\n\tv361 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv362 = UnityEngine.Canvas::get_rootCanvas(v361);\n\tv509 = UnityEngine.Canvas::get_worldCamera(v362);\n\tgoto L_004F;\nL_004F:\n\tv114 = UnityEngine.Object::op_Implicit(v509);\n\tv118 = ~v114;\n\tif (v118) goto L_008A;\n\tv363 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv364 = UnityEngine.Canvas::get_rootCanvas(v363);\n\treturnVal4 = UnityEngine.Canvas::get_worldCamera(v364);\n\treturn returnVal4;\nL_007B:\n\treturnVal1 = UnityEngine.Camera::get_main();\n\treturn returnVal1;\nL_008A:\n\tgoto L_008D;\nL_008D:\n\tv130 = UnityEngine.Object::op_Implicit(this._bakeCamera);\n\tv430 = ~v130;\n\tif (v430) goto L_00AD;\n\tv285 = this.useCustomView != 1;\nL_FFFFFFFF:\n\tv321 = 10f;\n\tif (v285) goto L_00A2;\n\tv321 = this.customViewSize;\nL_00A2:\n\tUnityEngine.Camera::set_orthographicSize(this._bakeCamera, v321);\n\tgoto L_01DB;\nL_00AD:\n\tv365 = UnityEngine.Component::get_transform(this);\n\tv448 = UnityEngine.Transform::get_childCount(v365);\n\tv283 = v448 < 1;\n\tif (v283) goto L_00F1;\nL_FFFFFFFF:\n\tv326 = 0;\n\tgoto L_00D2;\nL_00C5:\n\tv326 = v326 + 1;\n\tv490 = v448 == v326;\n\tif (v490) goto L_00F1;\nL_00D2:\n\tv366 = UnityEngine.Component::get_transform(this);\n\tv367 = UnityEngine.Transform::GetChild(v366, v326);\n\tv551 = UnityEngine.Component::TryGetComponent(v367, &v266 @ stack_-48_v6 (UnityEngine.Camera));\n\tv552 = ~v551;\n\tif (v552) goto L_00C5;\n\tv565 = UnityEngine.Object::get_name(v266);\n\tv558 = System.String::op_Equality(v565, \"[generated] UIParticle BakingCamera\");\n\tv502 = ~v558;\n\tif (v502) goto L_00C5;\n\tthis._bakeCamera = v266;\nL_00F1:\n\tgoto L_00F3;\nL_00F3:\n\tv515 = UnityEngine.Object::op_Implicit(this._bakeCamera);\n\tv521 = v515 == 0;\n\tif (v521) goto L_0105;\n\tgoto L_012E;\nL_0105:\n\tv369 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v369, \"[generated] UIParticle BakingCamera\");\n\tUnityEngine.GameObject::SetActive(v369, 0);\n\tv563 = UnityEngine.GameObject::get_transform(v369);\n\tv370 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v563, v370, 0);\n\tv578 = UnityEngine.GameObject::AddComponent(v369);\n\tthis._bakeCamera = v578;\nL_012E:\n\tUnityEngine.Behaviour::set_enabled(this._bakeCamera, 0);\n\tv284 = this.useCustomView != 1;\nL_FFFFFFFF:\n\tv318 = 10f;\n\tif (v284) goto L_0141;\n\tv318 = this.customViewSize;\nL_0141:\n\tUnityEngine.Camera::set_orthographicSize(this._bakeCamera, v318);\n\tv387 = UnityEngine.Component::get_transform(this._bakeCamera);\n\tgoto L_0164;\nL_0164:\n\t// 356 MakeStruct v257 @ AGG3F259EC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, -998637568\n\t// 357 MakeStruct v256 @ AGG3F259EC_2_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v590.identity (UnityEngine.Quaternion), v590.identity.y (System.Single), v590.identity.z (System.Single), v590.identity.w (System.Single)\n\tUnityEngine.Transform::SetPositionAndRotation(v387, v257, v256);\n\tUnityEngine.Camera::set_orthographic(this._bakeCamera, 1);\n\tUnityEngine.Camera::set_farClipPlane(this._bakeCamera, 2000f);\n\tUnityEngine.Camera::set_clearFlags(this._bakeCamera, 4);\n\tUnityEngine.Camera::set_cullingMask(this._bakeCamera, 0);\n\tUnityEngine.Camera::set_allowHDR(this._bakeCamera, 0);\n\tUnityEngine.Camera::set_allowMSAA(this._bakeCamera, 0);\n\tUnityEngine.Camera::set_renderingPath(this._bakeCamera, 1);\n\tUnityEngine.Camera::set_useOcclusionCulling(this._bakeCamera, 0);\n\tv382 = UnityEngine.Component::get_gameObject(this._bakeCamera);\n\tUnityEngine.GameObject::SetActive(v382, 0);\n\tv591 = UnityEngine.Component::get_gameObject(this._bakeCamera);\n\tgoto L_01B6;\n\tv466 = v384.m_HideGeneratedObjects == 0;\n\tv461 = ~v466;\n\tv459 = ~v461;\n\tif (v459) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv473 = 0x3F;\n\tgoto L_01D0;\nL_FFFFFFFF:\n\tv473 = 0x3C;\nL_01DB:\n\treturn this._bakeCamera;\nL_0027:\n\tv52 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_002D;\nL_01B6:\n\tv384 = Coffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::get_instance();\nL_01D0:\n\tUnityEngine.Object::set_hideFlags(v591, v473);\n")]
		private Camera GetBakeCamera()
		{
			Canvas canvas = base.canvas;
			if ((bool)canvas)
			{
				if (!useCustomView)
				{
					Canvas canvas2 = base.canvas;
					if (canvas2.renderMode != RenderMode.ScreenSpaceOverlay)
					{
						Canvas canvas3 = base.canvas;
						Canvas rootCanvas = canvas3.rootCanvas;
						Camera worldCamera = rootCanvas.worldCamera;
						if ((bool)worldCamera)
						{
							Canvas canvas4 = base.canvas;
							Canvas rootCanvas2 = canvas4.rootCanvas;
							return rootCanvas2.worldCamera;
						}
					}
				}
				if ((bool)_bakeCamera)
				{
					bool flag = !useCustomView;
					float orthographicSize = 10f;
					if (!flag)
					{
						orthographicSize = customViewSize;
					}
					_bakeCamera.orthographicSize = orthographicSize;
				}
				else
				{
					Transform transform = base.transform;
					int childCount = transform.childCount;
					if (childCount >= 1)
					{
						int num = 0;
						do
						{
							Transform transform2 = base.transform;
							Transform child = transform2.GetChild(num);
							if (child.TryGetComponent<Camera>(out var component))
							{
								string text = component.name;
								if (text == "[generated] UIParticle BakingCamera")
								{
									_bakeCamera = component;
									break;
								}
							}
							num++;
						}
						while (childCount != num);
					}
					if (!_bakeCamera)
					{
						GameObject gameObject = new GameObject("[generated] UIParticle BakingCamera");
						gameObject.SetActive(value: false);
						Transform transform3 = gameObject.transform;
						Transform parent = base.transform;
						transform3.SetParent(parent, worldPositionStays: false);
						Camera bakeCamera = gameObject.AddComponent<Camera>();
						_bakeCamera = bakeCamera;
					}
					_bakeCamera.enabled = false;
					bool flag2 = !useCustomView;
					float orthographicSize2 = 10f;
					if (!flag2)
					{
						orthographicSize2 = customViewSize;
					}
					_bakeCamera.orthographicSize = orthographicSize2;
					Transform transform4 = _bakeCamera.transform;
					Vector3 position = default(Vector3);
					position.x = 0f;
					position.y = 0f;
					position.z = -1000f;
					Quaternion rotation = default(Quaternion);
					rotation.x = Quaternion.identity.x;
					rotation.y = Quaternion.identity.y;
					rotation.z = Quaternion.identity.z;
					rotation.w = Quaternion.identity.w;
					transform4.SetPositionAndRotation(position, rotation);
					_bakeCamera.orthographic = true;
					_bakeCamera.farClipPlane = 2000f;
					_bakeCamera.clearFlags = CameraClearFlags.Nothing;
					_bakeCamera.cullingMask = 0;
					_bakeCamera.allowHDR = false;
					_bakeCamera.allowMSAA = false;
					_bakeCamera.renderingPath = RenderingPath.Forward;
					_bakeCamera.useOcclusionCulling = false;
					GameObject gameObject2 = _bakeCamera.gameObject;
					gameObject2.SetActive(value: false);
					GameObject gameObject3 = _bakeCamera.gameObject;
					UIParticleProjectSettings instance = PreloadedProjectSettings<UIParticleProjectSettings>.instance;
					HideFlags hideFlags = ((!instance.m_HideGeneratedObjects) ? (HideFlags.DontSave | HideFlags.NotEditable) : (HideFlags.HideAndDontSave | HideFlags.HideInInspector));
					gameObject3.hideFlags = hideFlags;
				}
				return _bakeCamera;
			}
			return Camera.main;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x3F270A4", Offset = "0x3F270A4", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::.ctor(v77);\n\tthis.particles = v77;\n\tthis.autoScalingMode = 2;\n\tthis.customViewSize = 10f;\n\tv94 = new System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>();\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticleRenderer>::.ctor(v94);\n\tthis._renderers = v94;\n\tUnityEngine.UI.MaskableGraphic::.ctor(this);\n\treturn;\nL_002F:\n\tthis.scale3D = 0;\n\tthis.m_Scale3D.z = 10f;\n\t// 52 NewArr v65 @ X0_v3 (Coffee.UIExtensions.AnimatableProperty[]), typeof(Coffee.UIExtensions.AnimatableProperty[]), 0\n\tthis.m_AnimatableProperties = v65;\n\tv77 = new System.Collections.Generic.List`1<UnityEngine.ParticleSystem>();\n")]
		public UIParticle()
		{
			m_Scale3D = default(Vector3);
			m_Scale3D.z = 10f;
			AnimatableProperty[] animatableProperties = new AnimatableProperty[0];
			m_AnimatableProperties = animatableProperties;
			List<ParticleSystem> list = new List<ParticleSystem>();
			m_Particles = list;
			m_AutoScalingMode = AutoScalingMode.Transform;
			m_CustomViewSize = 10f;
			List<UIParticleRenderer> renderers = new List<UIParticleRenderer>();
			_renderers = renderers;
		}
	}
}
