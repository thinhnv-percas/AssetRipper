using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[ExecuteAlways]
	[RequireComponent(typeof(Animator))]
	[Token(Token = "0x2000004")]
	public abstract class AdaptationBase : MonoBehaviour, INotchSimulatorTarget
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		internal Rect[] storedSimulatedCutoutsRelative;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x28")]
		internal Rect storedSimulatedSafeAreaRelative;

		[SerializeField]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x38")]
		private SupportedOrientations supportedOrientations;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x40")]
		private BlendedClipsAdaptor portraitOrDefaultAdaptation;

		[SerializeField]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x48")]
		private BlendedClipsAdaptor landscapeAdaptation;

		[Token(Token = "0x17000001")]
		private BlendedClipsAdaptor SelectedAdaptation
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x3F449B8", Offset = "0x3F449B8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_0027;\nL_0027:\n\tv64 = UnityEngine.Screen::get_width();\n\tv107 = UnityEngine.Screen::get_height();\n\tv91 = v64 - v107;\n\tv89 = v91 < 0;\n\tv87 = v91 == 0;\n\tv85 = v64 ^ v107;\n\tv83 = v64 ^ v91;\n\tv81 = v85 & v83;\n\tv79 = v81 < 0;\n\tv110 = v89 == v79;\n\tv71 = ~v87;\n\tv74 = v110 & v71;\n\tv68 = ~v74;\n\tif (v68) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv98 = 0x48;\n\tgoto L_0045;\nL_FFFFFFFF:\n\tv98 = 0x40;\nL_0046:\n\tv55 = 0x40;\n\treturn *([this @ X0 (E7.NotchSolution.AdaptationBase)+v55 @ X8_v4 (System.Int32)]);\nL_001C:\n\tv48 = this.supportedOrientations != 1;\n\tif (v48) goto L_0046;\nL_0045:\n\treturn *([this @ X0 (E7.NotchSolution.AdaptationBase)+v98 @ X8_v9 (System.Int32)]);\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AdaptationBase::get_SelectedAdaptation");
				return default;
			}
		}

		[Token(Token = "0x17000002")]
		private Animator AnimatorComponent
		{
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x3F44A8C", Offset = "0x3F44A8C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\treturnVal1 = UnityEngine.Component::GetComponent(this);\n\treturn returnVal1;\n")]
			get
			{
				return GetComponent<Animator>();
			}
		}

		[Token(Token = "0x17000003")]
		protected Rect SafeAreaRelative
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x3F44AE4", Offset = "0x3F44AE4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_001C:\n\treturnVal1 = E7.NotchSolution.NotchSolutionUtility::get_ScreenSafeAreaRelative();\n\treturn returnVal1;\nL_0016:\n\tgoto L_001C;\n")]
			get
			{
				return NotchSolutionUtility.ScreenSafeAreaRelative;
			}
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x3F44C44", Offset = "0x3F44C44", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = E7.NotchSolution.AdaptationBase::Adapt(this);\n\treturn;\n")]
		private void Start()
		{
			Adapt();
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x3F44C50", Offset = "0x3F44C50", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv50 = UnityEngine.Application::get_isPlaying();\n\tv58 = v50 == 0;\n\tif (v58) goto L_003D;\n\treturn;\nL_003D:\n\tv77 = E7.NotchSolution.AdaptationBase::Adapt(v77);\nL_003D:\n\treturn;\n")]
		private void Update()
		{
			if (!Application.isPlaying)
			{
				AdaptationBase adaptationBase = default(AdaptationBase);
				adaptationBase.Adapt();
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x3F44CEC", Offset = "0x3F44CEC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storedSimulatedSafeAreaRelative.x = simulatedSafeAreaRelative;\n\tthis.storedSimulatedSafeAreaRelative.y = simulatedSafeAreaRelative.y;\n\tthis.storedSimulatedSafeAreaRelative.width = simulatedSafeAreaRelative.width;\n\tthis.storedSimulatedSafeAreaRelative.height = simulatedSafeAreaRelative.height;\n\tthis.storedSimulatedCutoutsRelative = simulatedCutoutsRelative;\n\tv32 = E7.NotchSolution.AdaptationBase::Adapt(v32);\n\treturn;\n")]
		void INotchSimulatorTarget.SimulatorUpdate(Rect simulatedSafeAreaRelative, Rect[] simulatedCutoutsRelative)
		{
			storedSimulatedSafeAreaRelative.x = simulatedSafeAreaRelative.x;
			storedSimulatedSafeAreaRelative.y = simulatedSafeAreaRelative.y;
			storedSimulatedSafeAreaRelative.width = simulatedSafeAreaRelative.width;
			storedSimulatedSafeAreaRelative.height = simulatedSafeAreaRelative.height;
			storedSimulatedCutoutsRelative = simulatedCutoutsRelative;
			AdaptationBase adaptationBase = default(AdaptationBase);
			adaptationBase.Adapt();
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x3F44D24", Offset = "0x3F44D24", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tthis.portraitOrDefaultAdaptation = v46;\n\tv58 = new E7.NotchSolution.BlendedClipsAdaptor();\n\tSystem.Object::.ctor(v58);\n\tv58.adaptationCurve = curve;\n\tthis.landscapeAdaptation = v58;\n\treturn;\nL_0018:\n\tv46 = new E7.NotchSolution.BlendedClipsAdaptor();\n\tSystem.Object::.ctor(v46);\n\tv46.adaptationCurve = curve;\n")]
		internal void ResetAdaptationToCurve(AnimationCurve curve)
		{
			BlendedClipsAdaptor blendedClipsAdaptor = (BlendedClipsAdaptor)FormatterServices.GetUninitializedObject(typeof(BlendedClipsAdaptor));
			blendedClipsAdaptor.adaptationCurve = curve;
			portraitOrDefaultAdaptation = blendedClipsAdaptor;
			BlendedClipsAdaptor blendedClipsAdaptor2 = (BlendedClipsAdaptor)FormatterServices.GetUninitializedObject(typeof(BlendedClipsAdaptor));
			blendedClipsAdaptor2.adaptationCurve = curve;
			landscapeAdaptation = blendedClipsAdaptor2;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x3F44E0C", Offset = "0x3F44E0C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_002C;\nL_002C:\n\tv76 = UnityEngine.Screen::get_width();\n\tv109 = UnityEngine.Screen::get_height();\n\tv105 = v76 - v109;\n\tv103 = v105 < 0;\n\tv101 = v105 == 0;\n\tv99 = v76 ^ v109;\n\tv97 = v76 ^ v105;\n\tv95 = v99 & v97;\n\tv93 = v95 < 0;\n\tv146 = v103 == v93;\n\tv86 = ~v101;\n\tv88 = v146 & v86;\n\tv83 = ~v88;\n\tif (v83) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv161 = 0x48;\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv161 = 0x40;\nL_004C:\n\tgoto L_005E;\nL_004D:\n\tv64 = 0x40;\n\tv137 = this->klass;\n\tv119 = 0xB2C1000 + 0xA08;\n\tgoto L_005E;\n\tE7.NotchSolution.BlendedClipsAdaptor::Adapt(v137, valueForAdaptationCurve, v140);\n\treturn;\nL_0021:\n\tv57 = this.supportedOrientations != 1;\n\tif (v57) goto L_004D;\nL_0044:\n\tv137 = this->klass;\n\tv119 = 0xB2C1000 + 0xA08;\n\tgoto L_004C;\nL_005E:\n\tv140 = UnityEngine.Component::GetComponent /* +1 sharing this address */(this, *([v119 @ X22_v1 (System.Int32)]));\n")]
		protected internal void Adapt(float valueForAdaptationCurve)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AdaptationBase::Adapt");
		}

		[Token(Token = "0x600000B")]
		public abstract void Adapt();

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x3F45200", Offset = "0x3F45200", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_0021;\nL_0021:\n\tthis.storedSimulatedCutoutsRelative = v51.defaultCutouts;\n\tthis.storedSimulatedSafeAreaRelative = v57.defaultSafeArea;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal AdaptationBase()
		{
			storedSimulatedCutoutsRelative = NotchSolutionUtility.defaultCutouts;
			storedSimulatedSafeAreaRelative = NotchSolutionUtility.defaultSafeArea;
		}
	}
}
