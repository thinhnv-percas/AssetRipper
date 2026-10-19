using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using UnityEngine;

namespace Systems.RemoteManagementSystem.ScriptableObjects
{
	[CreateAssetMenu(fileName = "RemoteConfig", menuName = "UFC/RemoteDataSystem/RemoteConfig", order = 0)]
	[Token(Token = "0x2000009")]
	public class RemoteConfig : ScriptableObject
	{
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x18")]
		public string Key;

		[SerializeField]
		[TextArea(1, 30)]
		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x20")]
		public string Value;

		[SerializeField]
		[TextArea(1, 30)]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x28")]
		protected string DevValue;

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x81C9160", Offset = "0x81C9160", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv50 = UnityEngine.Application::get_isEditor();\n\tv59 = v50 == 0;\n\tif (v59) goto L_005E;\n\tv71 = this + 0x28;\n\tgoto L_0026;\nL_0026:\n\tv94 = Unco.Extensions.StringExtensions::IsNullOrWhiteSpace(this.DevValue);\n\tv136 = this + 0x20;\n\tv118 = v94 == 0;\n\tv103 = ~v118;\n\tv100 = ~v103;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_FFFFFFFF:\n\tv136 = v71;\nL_005E:\n\treturn this.Value;\nL_0040:\n\treturn *([v136 @ X8_v12]);\n")]
		public string GetValue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RemoteConfig::GetValue");
			return default;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x81C9240", Offset = "0x81C9240", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public RemoteConfig()
		{
		}
	}
}
