using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x2000017")]
	public class RandomSeed : MonoBehaviour
	{
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x20")]
		private readonly int randomSeedProperty;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x28")]
		private MaterialPropertyBlock propertyBlock;

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x3C23A68", Offset = "0x3C23A68", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_0035:\n\tv63 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv68 = ~v63;\n\tif (v68) goto L_006B;\n\tv84 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v84);\n\tthis.propertyBlock = v84;\n\tv121 = UnityEngine.Random::Range(0f, 100f);\n\tUnityEngine.MaterialPropertyBlock::SetFloat(this.propertyBlock, this.randomSeedProperty, v121);\n\tUnityEngine.Renderer::SetPropertyBlock(v49, this.propertyBlock);\n\treturn;\nL_006B:\n\tv93 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0074;\nL_0074:\n\tv113 = UnityEngine.Object::op_Inequality(v93, 0);\n\tv122 = ~v113;\n\tif (v122) goto L_00AB;\n\tv183 = UnityEngine.UI.Image::get_material(v93);\n\tgoto L_0084;\nL_0084:\n\tv187 = UnityEngine.Object::op_Inequality(v183, 0);\n\tv245 = ~v187;\n\tif (v245) goto L_00C0;\n\tv259 = UnityEngine.UI.Image::get_material(v93);\n\tv150 = UnityEngine.Random::Range(0f, 1000f);\n\tUnityEngine.Material::SetFloat(v259, this.randomSeedProperty, v150);\n\treturn;\nL_00AB:\n\tv140 = UnityEngine.Component::get_gameObject(this);\n\tv192 = UnityEngine.Object::get_name(v140);\n\tv274 = 0xB2F7000 + 0xDD8;\n\tv268 = v192;\n\tgoto L_00CA;\nL_00C0:\n\tv161 = UnityEngine.Component::get_gameObject(this);\n\tv271 = UnityEngine.Object::get_name(v161);\n\tv274 = 0xB2F7000 + 0xDB0;\n\tv268 = v271;\nL_00D9:\n\tUnityEngine.Debug::LogError(v219);\n\treturn;\nL_002C:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0035;\nL_00CA:\n\tv219 = System.String::Concat(*([v274 @ X8_v8 (System.Int32)]), v268);\n\tgoto L_00D9;\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RandomSeed::Start");
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x3C23D54", Offset = "0x3C23D54", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Shader::PropertyToID(\"_RandomSeed\");\n\tthis.randomSeedProperty = v46;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RandomSeed()
		{
			int num = Shader.PropertyToID("_RandomSeed");
			randomSeedProperty = num;
		}
	}
}
