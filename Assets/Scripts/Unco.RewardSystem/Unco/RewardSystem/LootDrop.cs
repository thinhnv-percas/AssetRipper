using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ResourceSystem;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public struct LootDrop
	{
		[Tooltip("Type of loot - use LootDropType constants")]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x0")]
		public string LootType;

		[Tooltip("Specific identifier for this loot item")]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x8")]
		public string LootData;

		[Tooltip("Amount or quantity")]
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x10")]
		public float Amount;

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x81D50A8", Offset = "0x81D50A8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.LootType = lootType;\n\tthis.LootData = lootData;\n\tthis.Amount = amount;\n\treturn;\n")]
		public LootDrop(string lootType, string lootData, float amount)
		{
			LootType = lootType;
			LootData = lootData;
			Amount = amount;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81D50F0", Offset = "0x81D50F0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\treturnBuffer.Amount = amount;\n\treturn returnBuffer;\nL_0023:\n\tv60 = Unco.ResourceSystem.ResourceType;\n\tv65 = System.Enum::ToString(&v60 @ stack_-68_v1 (Il2CppClass<Unco.ResourceSystem.ResourceType>));\n\treturnBuffer.Amount = 0f;\n\treturnBuffer.LootData = 0;\n\treturnBuffer.LootType = \"resource\";\n\treturnBuffer.LootData = v65;\n")]
		public static LootDrop Resource(ResourceType type, long amount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LootDrop::Resource");
			return default;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81D51C4", Offset = "0x81D51C4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\treturnBuffer.Amount = amount;\n\treturn returnBuffer;\nL_0023:\n\tv60 = Unco.RewardSystem.HealthRewardType;\n\tv65 = System.Enum::ToString(&v60 @ stack_-68_v1 (Il2CppClass<Unco.RewardSystem.HealthRewardType>));\n\treturnBuffer.Amount = 0f;\n\treturnBuffer.LootData = 0;\n\treturnBuffer.LootType = \"health\";\n\treturnBuffer.LootData = v65;\n")]
		public static LootDrop Health(HealthRewardType rewardType, long amount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LootDrop::Health");
			return default;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81D5298", Offset = "0x81D5298", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.String::IsNullOrEmpty(this.LootType);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0016;\n\treturn 0;\nL_0016:\n\tv24 = System.String::IsNullOrEmpty(this.LootData);\n\treturnVal2 = v24 ^ 1;\n\treturn returnVal2;\n")]
		public bool IsValid()
		{
			if (string.IsNullOrEmpty(LootType))
			{
				return false;
			}
			bool flag = string.IsNullOrEmpty(LootData);
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81D52E4", Offset = "0x81D52E4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = this.Amount;\n\tv49 = 0xB7D5000 + 0x538;\n\tv52 = \"il2cpp_vm_object_box\"(*([v49 @ X8_v4 (System.Int32)+78]), &v47 @ stack_-34_v1 (System.Single), v27, v28, v29, v30, v31, v32, this.Amount, v34, v35, v36, v37, v38, v39, v40);\n\treturnVal1 = System.String::Format(\"LootDrop({0}, {1}, {2})\", this.LootType, this.LootData, v52);\n\treturn returnVal1;\n")]
		public override string ToString()
		{
			float amount = Amount;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"LootDrop({LootType}, {LootData}, {arg})";
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81D5370", Offset = "0x81D5370", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = *([obj @ X1 (System.Object)]) == Unco.RewardSystem.LootDrop;\n\tif (v56) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_003C:\n\treturn 0;\nL_FFFFFFFF:\n\t// -1 IsInst v83_asT @ TEMPCOND_v2 (Unco.RewardSystem.LootDrop), typeof(Unco.RewardSystem.LootDrop), obj @ X1 (System.Object)\n\tv83 = v83_asT == 0;\n\tif (v83) goto L_00A9;\n\tv183 = \"il2cpp_vm_object_unbox\"(obj, Unco.RewardSystem.LootDrop, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturnVal2 = System.String::op_Equality(this.LootType, *([v183 @ X0_v6]));\n\tv179 = ~returnVal2;\n\tif (v179) goto L_0031;\n\treturnVal2 = System.String::op_Equality(this.LootData, *([v183 @ X0_v6+8]));\n\tv180 = ~returnVal2;\n\tif (v180) goto L_0031;\n\tgoto L_0068;\n\tgoto L_0081;\nL_FFFFFFFF:\n\tv215 = v200;\n\tgoto L_0095;\nL_FFFFFFFF:\n\tv87 = v95;\nL_00A9:\n\treturnVal3 = new System.InvalidCastException();\n\treturn returnVal3;\nL_0017:\n\tv47 = obj == 0;\n\tif (v47) goto L_003C;\nL_0031:\n\treturn returnVal2;\nL_0068:\n\tv215 = UnityEngine.Mathf::Abs(this.Amount);\n\tv200 = UnityEngine.Mathf::Abs(*([v183 @ X0_v6+10]));\n\tv201 = v215 < v200;\n\tv202 = v215 == v200;\n\tv205 = v215 == v215;\n\tv206 = v200 == v200;\n\tv207 = v205 & v206;\n\tv208 = ~v207;\n\tv209 = v201 == v208;\n\tv210 = ~v202;\n\tv211 = v209 & v210;\n\tv212 = ~v211;\n\tif (v212) goto L_FFFFFFFF;\nL_0081:\n\tv87 = v215 * 0x358637BD;\n\tv95 = v217.Epsilon * 8f;\n\tv222 = v87 < v95;\n\tv223 = v87 == v95;\n\tv226 = v87 == v87;\n\tv227 = v95 == v95;\n\tv228 = v226 & v227;\n\tv229 = ~v228;\n\tv230 = v222 == v229;\n\tv93 = ~v223;\n\tv102 = v230 & v93;\n\tv90 = ~v102;\n\tif (v90) goto L_FFFFFFFF;\nL_0095:\n\t// 149 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv139 = v95 < v87;\n\treturn v139;\n")]
		public override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LootDrop::Equals");
			return default;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81D54C8", Offset = "0x81D54C8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0037:\n\treturnVal1 = System.HashCode::Combine(this.LootType, this.LootData, Il2CppMethodInfo);\n\treturn returnVal1;\nL_0026:\n\tgoto L_0037;\n")]
		public override int GetHashCode()
		{
			//IL_0018: Expected F4, but got I
			return HashCode.Combine(LootType, LootData, 0f);
		}
	}
}
