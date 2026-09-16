using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EpicToonFX
{
	[Token(Token = "0x2000066")]
	public class ETFXPitchRandomizer : MonoBehaviour
	{
		[Token(Token = "0x40002AD")]
		[FieldOffset(Offset = "0x18")]
		public float randomPercent;

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xA05920", Offset = "0xA05920", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EF7C10]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C8E]) = v40;\nL_0016:\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv48 = UnityEngine.Component::GetComponent(v43);\n\tv59 = UnityEngine.AudioSource::get_pitch(v48);\n\tv85 = -this.randomPercent;\n\tv87 = v85 / 100f;\n\tv88 = this.randomPercent / 100f;\n\tv89 = UnityEngine.Random::Range(v87, v88);\n\tv90 = v89 + 1f;\n\tv69 = v59 * v90;\n\tUnityEngine.AudioSource::set_pitch(v48, v69);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			//IL_002f: Expected O, but got F4
			Transform transform = base.transform;
			AudioSource component = transform.GetComponent<AudioSource>();
			float pitch = component.pitch;
			object obj = 0f - randomPercent;
			float min = (float)obj / 100f;
			float max = randomPercent / 100f;
			float num = Random.Range(min, max);
			float num2 = num + 1f;
			float pitch2 = pitch * num2;
			component.pitch = pitch2;
		}

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0xA059D8", Offset = "0xA059D8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.randomPercent = 10f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXPitchRandomizer()
		{
			randomPercent = 10f;
		}
	}
}
