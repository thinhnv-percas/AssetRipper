using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x200000A")]
	public class All1VfxRandomTimeSeed : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x20")]
		private float minSeedValue;

		[SerializeField]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x24")]
		private float maxSeedValue;

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x3C25148", Offset = "0x3C25148", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tUnityEngine.MaterialPropertyBlock::SetFloat(v46, \"_TimingSeed\", v57);\n\tv70 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.Renderer::SetPropertyBlock(v70, v46);\n\treturn;\nL_001D:\n\tv46 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v46);\n\tv57 = UnityEngine.Random::Range(this.minSeedValue, this.maxSeedValue);\n")]
		private void Start()
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			float value = Random.Range(minSeedValue, maxSeedValue);
			materialPropertyBlock.SetFloat("_TimingSeed", value);
			Renderer component = GetComponent<Renderer>();
			component.SetPropertyBlock(materialPropertyBlock);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x3C2520C", Offset = "0x3C2520C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxSeedValue = 100f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public All1VfxRandomTimeSeed()
		{
			maxSeedValue = 100f;
		}
	}
}
