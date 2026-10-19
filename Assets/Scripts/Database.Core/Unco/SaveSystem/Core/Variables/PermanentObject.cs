using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000015")]
	public class PermanentObject<S> : PermanentVariable<S> where S : class, new()
	{
		[Token(Token = "0x6000091")]
		[Address(RVA = "0x5ECB87C", Offset = "0x5ECB87C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Object>::.ctor(this, key, initialValue, remoteData, lastSavedRemoteTime);\n\treturn;\n")]
		public PermanentObject(string key, S initialValue = null, object remoteData = null, DateTime? lastSavedRemoteTime = null)
			: base(key, initialValue, remoteData, lastSavedRemoteTime)
		{
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x5ECB880", Offset = "0x5ECB880", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_0027;\n\tv82 = this == 0;\n\tif (v82) goto L_0065;\n\tthis.CurrentValue = v65;\n\tgoto L_0064;\nL_0038:\n\tgoto L_003C;\nL_003C:\n\tv99 = Newtonsoft.Json.JsonConvert::SerializeObject(obj);\n\tv139 = System.String::IsNullOrWhiteSpace(v99);\n\tv151 = v139 == 0;\n\tif (v151) goto L_004D;\n\tv157 = System.Activator::CreateInstance();\n\tv140 = v157;\n\tgoto L_0055;\nL_004D:\n\tgoto L_0053;\nL_0053:\n\tv169 = Newtonsoft.Json.JsonConvert::DeserializeObject(v99);\n\tv140 = v169;\n\tthis.CurrentValue = v140;\nL_0064:\n\treturn;\nL_0065:\n\tv141 = new System.NullReferenceException();\n\tgoto L_00DF;\nL_0067:\n\tv141 = new System.NullReferenceException();\n\tgoto L_00DF;\n\tthis.CurrentValue = v58;\n\treturn;\nL_00D6:\n\tthrow System.NullReferenceException;\nL_00DF:\n\t// 223 Interrupt\n\tv146 = 0x8BF5BF4(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv153 = 0x8BF0368(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv114 = 0xA1B8(v153, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001A:\n\tv50 = obj == 0;\n\tif (v50) goto L_00C4;\nL_0027:\n\tv65 = 0x21C11D0(obj, Il2CppClass<S>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv68 = v65 == 0;\n\tif (v68) goto L_0038;\nL_0055:\n\tv143 = this == 0;\n\tif (v143) goto L_0067;\nL_00C4:\n\tv58 = System.Activator::CreateInstance();\n\tv66 = this == 0;\n\tif (v66) goto L_00D6;\n")]
		public override void SetCurrentValue(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentObject::SetCurrentValue");
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x5ECBB44", Offset = "0x5ECBB44", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\treturn p.CurrentValue;\n")]
		public static implicit operator S(PermanentObject<S> p)
		{
			return p.CurrentValue;
		}
	}
}
