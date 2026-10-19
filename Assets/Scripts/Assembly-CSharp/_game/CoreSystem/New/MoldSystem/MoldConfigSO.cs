using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.MoldSystem
{
	[CreateAssetMenu(menuName = "Game/Mold Config")]
	[Token(Token = "0x20002A3")]
	public class MoldConfigSO : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x400081D")]
		[FieldOffset(Offset = "0x18")]
		private MoldConfig m_config;

		[Token(Token = "0x170000EB")]
		public MoldConfig Config
		{
			[Token(Token = "0x6000B95")]
			[Address(RVA = "0x3EC7CE0", Offset = "0x3EC7CE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Config;\n")]
			get
			{
				return m_config;
			}
		}

		[Token(Token = "0x6000B96")]
		[Address(RVA = "0x3EC7CE8", Offset = "0x3EC7CE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public MoldConfigSO()
		{
		}
	}
}
