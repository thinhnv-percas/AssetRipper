using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[HelpURL("https://exceed7.com/notch-solution/components/adaptation/aspect-ratio-adaptation.html")]
	[Token(Token = "0x2000016")]
	public class AspectRatioAdaptation : AdaptationBase
	{
		[Token(Token = "0x1700000C")]
		private float AspectRatio
		{
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x3F46180", Offset = "0x3F46180", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Screen::get_width();\n\tv14 = UnityEngine.Screen::get_height();\n\tv26 = v11 <= v14;\n\tif (v26) goto L_0027;\n\tv28 = UnityEngine.Screen::get_width();\n\tv33 = UnityEngine.Screen::get_height();\n\treturnVal1 = v28 / v33;\n\treturn returnVal1;\nL_0027:\n\tv30 = UnityEngine.Screen::get_height();\n\tv36 = UnityEngine.Screen::get_width();\n\treturnVal2 = v30 / v36;\n\treturn returnVal2;\n")]
			get
			{
				int width = Screen.width;
				int height = Screen.height;
				if (width > height)
				{
					int width2 = Screen.width;
					int height2 = Screen.height;
					return (float)width2 / (float)height2;
				}
				int height3 = Screen.height;
				int width3 = Screen.width;
				return (float)height3 / (float)width3;
			}
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x3F46200", Offset = "0x3F46200", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = E7.NotchSolution.AspectRatioAdaptation::<Reset>g__GenDefaultCurve|2_0();\n\tE7.NotchSolution.AdaptationBase::ResetAdaptationToCurve(this, v12);\n\treturn;\n")]
		private void Reset()
		{
			AnimationCurve curve = GenDefaultCurve();
			ResetAdaptationToCurve(curve);
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x3F46228", Offset = "0x3F46228", Length = "0x1A4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+20]) = v57;\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+2C]) = v137;\n\tUnityEngine.Keyframe::.ctor(&v152 @ stack_-60_v4 (UnityEngine.Keyframe), 1.7777778f, 0.5333333f, 1.2f, 1.2f);\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+54]) = 0;\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+4C]) = 0;\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+3C]) = v152;\n\tUnityEngine.Keyframe::.ctor(&v163 @ stack_-80_v4 (UnityEngine.Keyframe), 2.1666667f, 1f, 1.2f, 1.2f);\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+70]) = 0;\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+68]) = 0;\n\t*([v42 @ X0_v3 (UnityEngine.Keyframe[])+58]) = v163;\n\tv238 = new UnityEngine.AnimationCurve();\n\tUnityEngine.AnimationCurve::.ctor(v238, v42);\n\treturn v238;\nL_0018:\n\t// 24 NewArr v42 @ X0_v3 (UnityEngine.Keyframe[]), typeof(UnityEngine.Keyframe[]), 3\n\tv47 = 0;\n\tv48 = 0;\n\tv49 = 0;\n\tUnityEngine.Keyframe::.ctor(&v57 @ stack_-40_v2 (UnityEngine.Keyframe), 1.3333334f, 0f, 1.2f, 1.2f);\n")]
			static AnimationCurve GenDefaultCurve()
			{
				Keyframe[] keys = new Keyframe[3];
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				Keyframe keyframe = new Keyframe(1.3333334f, 0f, 1.2f, 1.2f);
				Keyframe keyframe2 = new Keyframe(1.7777778f, 0.5333333f, 1.2f, 1.2f);
				_ = 0;
				_ = 0;
				Keyframe keyframe3 = new Keyframe(2.1666667f, 1f, 1.2f, 1.2f);
				_ = 0;
				_ = 0;
				return new AnimationCurve(keys);
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x3F463CC", Offset = "0x3F463CC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Screen::get_width();\n\tv16 = UnityEngine.Screen::get_height();\n\tv28 = v13 <= v16;\n\tif (v28) goto L_0020;\n\tv30 = UnityEngine.Screen::get_width();\n\tv40 = UnityEngine.Screen::get_height();\n\tv39 = v30;\n\tgoto L_0026;\nL_0020:\n\tv32 = UnityEngine.Screen::get_height();\n\tv40 = UnityEngine.Screen::get_width();\n\tv39 = v32;\nL_0026:\n\tv43 = v39 / v40;\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v43);\n\treturn;\n")]
		public override void Adapt()
		{
			int width = Screen.width;
			int height = Screen.height;
			int num;
			int num2;
			if (width > height)
			{
				int width2 = Screen.width;
				num = Screen.height;
				num2 = width2;
			}
			else
			{
				int height2 = Screen.height;
				num = Screen.width;
				num2 = height2;
			}
			float valueForAdaptationCurve = (float)num2 / (float)num;
			Adapt(valueForAdaptationCurve);
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x3F46440", Offset = "0x3F46440", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_0021;\nL_0021:\n\tthis.storedSimulatedCutoutsRelative = v51.defaultCutouts;\n\tthis.storedSimulatedSafeAreaRelative = v57.defaultSafeArea;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AspectRatioAdaptation()
		{
			storedSimulatedCutoutsRelative = NotchSolutionUtility.defaultCutouts;
			storedSimulatedSafeAreaRelative = NotchSolutionUtility.defaultSafeArea;
		}
	}
}
