using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Serializable]
	[Token(Token = "0x2000011")]
	public struct LootEntry
	{
		[Tooltip("The reward data")]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x0")]
		public LootDrop loot;

		[Tooltip("Weight for random selection probability")]
		[Range(0f, 100f)]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x18")]
		public float weight;

		[Tooltip("Minimum amount if using random ranges")]
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x1C")]
		public float minAmount;

		[Tooltip("Maximum amount if using random ranges")]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x20")]
		public float maxAmount;

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81D56F0", Offset = "0x81D56F0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Unco.RewardSystem.LootEntry)+10]) = loot.Amount;\n\tthis.loot = loot.LootType;\n\tthis.weight = weight;\n\tthis.minAmount = minAmount;\n\tthis.maxAmount = maxAmount;\n\tgoto L_0027;\nL_FFFFFFFF:\n\tv86 = v69;\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv86 = v135;\n\tthis.maxAmount = loot.Amount;\nL_FFFFFFFF:\n\tv135 = v120;\n\tgoto L_0077;\n\tthis.minAmount = this.maxAmount;\nL_0027:\n\tv60 = UnityEngine.Mathf::Abs(maxAmount);\n\tv62 = UnityEngine.Mathf::Max(v60, 0f);\n\tv69 = v62 * 0x358637BD;\n\tv135 = v64.Epsilon * 8f;\n\tv72 = v69 < v135;\n\tv73 = v69 == v135;\n\tv76 = v69 == v69;\n\tv77 = v135 == v135;\n\tv78 = v76 & v77;\n\tv79 = ~v78;\n\tv80 = v72 == v79;\n\tv81 = ~v73;\n\tv82 = v80 & v81;\n\tv83 = ~v82;\n\tif (v83) goto L_FFFFFFFF;\nL_0044:\n\t// 68 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv87 = 0 < v86;\n\tv95 = ~v87;\n\tif (v95) goto L_0055;\nL_005F:\n\tv111 = UnityEngine.Mathf::Abs(this.minAmount);\n\tv116 = UnityEngine.Mathf::Max(v111, 0f);\n\tv120 = v116 * 0x358637BD;\n\tv121 = v120 < v135;\n\tv122 = v120 == v135;\n\tv125 = v120 == v120;\n\tv126 = v135 == v135;\n\tv127 = v125 & v126;\n\tv128 = ~v127;\n\tv129 = v121 == v128;\n\tv130 = ~v122;\n\tv131 = v129 & v130;\n\tv132 = ~v131;\n\tif (v132) goto L_0077;\nL_0077:\n\t// 119 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv136 = v120 < v135;\n\tv144 = ~v136;\n\tif (v144) goto L_008F;\nL_0055:\n\tgoto L_005F;\nL_008F:\n\treturn;\n")]
		public LootEntry(LootDrop loot, float weight = 1f, float minAmount = 0f, float maxAmount = 0f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LootEntry::.ctor");
			this = default;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81D582C", Offset = "0x81D582C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv66 = v51;\nL_FFFFFFFF:\n\tv90 = v73;\n\tgoto L_0047;\n\treturn this.minAmount;\nL_0068:\n\treturnVal2 = UnityEngine.Random::Range(this.minAmount, this.maxAmount);\n\treturn returnVal2;\nL_001A:\n\tv66 = UnityEngine.Mathf::Abs(this.minAmount);\n\tv51 = UnityEngine.Mathf::Abs(this.maxAmount);\n\tv52 = v66 < v51;\n\tv53 = v66 == v51;\n\tv56 = v66 == v66;\n\tv57 = v51 == v51;\n\tv58 = v56 & v57;\n\tv59 = ~v58;\n\tv60 = v52 == v59;\n\tv61 = ~v53;\n\tv62 = v60 & v61;\n\tv63 = ~v62;\n\tif (v63) goto L_FFFFFFFF;\nL_0033:\n\tv73 = v66 * 0x358637BD;\n\tv90 = v68.Epsilon * 8f;\n\tv76 = v73 < v90;\n\tv77 = v73 == v90;\n\tv80 = v73 == v73;\n\tv81 = v90 == v90;\n\tv82 = v80 & v81;\n\tv83 = ~v82;\n\tv84 = v76 == v83;\n\tv85 = ~v77;\n\tv86 = v84 & v85;\n\tv87 = ~v86;\n\tif (v87) goto L_0047;\nL_0047:\n\t// 71 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv92 = 8f < v90;\n\tv100 = ~v92;\n\tif (v100) goto L_0068;\n")]
		public float GetRandomAmount()
		{
			float num = Mathf.Abs(minAmount);
			float num2 = Mathf.Abs(maxAmount);
			bool flag = num < num2;
			bool flag2 = num == num2;
			bool flag3 = num == num;
			bool flag4 = num2 == num2;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (!(flag7 && flag8))
			{
				num = num2;
			}
			float num3 = num * 1E-06f;
			float num4 = Mathf.Epsilon * 8f;
			bool flag9 = num3 < num4;
			bool flag10 = num3 == num4;
			bool flag11 = num3 == num3;
			bool flag12 = num4 == num4;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			if (flag15 && flag16)
			{
				num4 = num3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (8f < num4)
			{
				return minAmount;
			}
			return UnityEngine.Random.Range(minAmount, maxAmount);
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81D58EC", Offset = "0x81D58EC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_FFFFFFFF:\n\tv121 = this.minAmount;\n\tgoto L_0023;\n\tgoto L_003C;\nL_FFFFFFFF:\n\tv81 = v66;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv105 = v90;\n\tv117 = UnityEngine.Random::Range(v121, this.maxAmount);\nL_FFFFFFFF:\n\tv121 = v117;\nL_0023:\n\tv81 = UnityEngine.Mathf::Abs(this.minAmount);\n\tv66 = UnityEngine.Mathf::Abs(this.maxAmount);\n\tv67 = v81 < v66;\n\tv68 = v81 == v66;\n\tv71 = v81 == v81;\n\tv72 = v66 == v66;\n\tv73 = v71 & v72;\n\tv74 = ~v73;\n\tv75 = v67 == v74;\n\tv76 = ~v68;\n\tv77 = v75 & v76;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\nL_003C:\n\tv105 = v81 * 0x358637BD;\n\tv90 = v83.Epsilon * 8f;\n\tv91 = v105 < v90;\n\tv92 = v105 == v90;\n\tv95 = v105 == v105;\n\tv96 = v90 == v90;\n\tv97 = v95 & v96;\n\tv98 = ~v97;\n\tv99 = v91 == v98;\n\tv100 = ~v92;\n\tv101 = v99 & v100;\n\tv102 = ~v101;\n\tif (v102) goto L_FFFFFFFF;\nL_0050:\n\t// 80 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv106 = v90 < v105;\n\tif (v106) goto L_005F;\nL_005F:\n\treturnBuffer.Amount = 0f;\n\treturnBuffer.LootData = 0;\n\treturnBuffer.LootType = this.loot;\n\treturnBuffer.LootData = this.loot.LootData;\n\treturnBuffer.Amount = v121;\n\treturn returnBuffer;\n")]
		public LootDrop GetRandomLootDrop()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LootEntry::GetRandomLootDrop");
			return default;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81D59F0", Offset = "0x81D59F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.String::IsNullOrEmpty(this.loot);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0016;\n\treturn 0;\nL_0016:\n\tv24 = System.String::IsNullOrEmpty(this.loot.LootData);\n\tv56 = v24 == 0;\n\tif (v56) goto L_0022;\n\treturn 0;\nL_0022:\n\tv45 = this.weight < 0;\n\tv42 = this.weight == 0;\n\tv36 = this.weight == this.weight;\n\tv33 = ~v36;\n\tv69 = v45 == v33;\n\tv27 = ~v42;\n\tv30 = v69 & v27;\n\treturn v30;\n")]
		public bool IsValid()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LootEntry::IsValid");
			return default;
		}
	}
}
