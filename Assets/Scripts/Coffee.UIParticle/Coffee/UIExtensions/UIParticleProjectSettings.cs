using AssetRipperInjected;
using Coffee.UIParticleInternal;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIExtensions
{
	[Token(Token = "0x2000028")]
	public class UIParticleProjectSettings : PreloadedProjectSettings<UIParticleProjectSettings>
	{
		[Header("Setting")]
		[SerializeField]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x18")]
		internal bool m_EnableLinearToGamma;

		[Header("Editor")]
		[Tooltip("Hide the automatically generated objects.\n  - UIParticleRenderer\n  - UIParticle BakingCamera")]
		[SerializeField]
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x19")]
		internal bool m_HideGeneratedObjects;

		[Token(Token = "0x17000023")]
		public static bool enableLinearToGamma
		{
			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x3F28964", Offset = "0x3F28964", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn v40.m_EnableLinearToGamma;\nL_0014:\n\tv40 = Coffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::get_instance();\n")]
			get
			{
				UIParticleProjectSettings uIParticleProjectSettings = PreloadedProjectSettings<UIParticleProjectSettings>.instance;
				return uIParticleProjectSettings.m_EnableLinearToGamma;
			}
			[Token(Token = "0x60000F8")]
			[Address(RVA = "0x3F289B8", Offset = "0x3F289B8", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.m_EnableLinearToGamma = value;\n\treturn;\nL_0017:\n\tv45 = Coffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::get_instance();\n")]
			set
			{
				UIParticleProjectSettings uIParticleProjectSettings = PreloadedProjectSettings<UIParticleProjectSettings>.instance;
				uIParticleProjectSettings.m_EnableLinearToGamma = value;
			}
		}

		[Token(Token = "0x17000024")]
		public static HideFlags globalHideFlags
		{
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0x3F27040", Offset = "0x3F27040", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv47 = v40.m_HideGeneratedObjects == 0;\n\tv54 = ~v47;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0x3F;\n\tgoto L_002F;\nL_FFFFFFFF:\n\treturnVal2 = 0x3C;\nL_0014:\n\tv40 = Coffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::get_instance();\nL_002F:\n\treturn returnVal2;\n")]
			get
			{
				UIParticleProjectSettings uIParticleProjectSettings = PreloadedProjectSettings<UIParticleProjectSettings>.instance;
				if (uIParticleProjectSettings.m_HideGeneratedObjects)
				{
					return HideFlags.HideAndDontSave | HideFlags.HideInInspector;
				}
				return HideFlags.DontSave | HideFlags.NotEditable;
			}
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x3F28A18", Offset = "0x3F28A18", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\t*([this @ X0 (Coffee.UIExtensions.UIParticleProjectSettings)+18]) = 0x101;\n\tCoffee.UIParticleInternal.PreloadedProjectSettings`1<Coffee.UIExtensions.UIParticleProjectSettings>::.ctor(this);\n\treturn;\n")]
		public UIParticleProjectSettings()
		{
			_ = 257;
		}
	}
}
