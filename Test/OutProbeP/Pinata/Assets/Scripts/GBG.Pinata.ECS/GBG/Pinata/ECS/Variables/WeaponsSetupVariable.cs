using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.Variables
{
	[CreateAssetMenu]
	[Token(Token = "0x2000063")]
	public class WeaponsSetupVariable : BaseGlobalVariable<WeaponSetup>
	{
		[Token(Token = "0x60000B9")]
		[Address(RVA = "0xCC839C", Offset = "0xCC839C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDE558]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, serializedData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202377E]) = v41;\nL_0016:\n\tv43 = this.value;\n\t// 27 Box v48 @ X0_v3 (System.Object), typeof(GBG.Pinata.ECS.WeaponSetup), &v43 @ X8_v3 (GBG.Pinata.ECS.WeaponSetup)\n\tUnityEngine.JsonUtility::FromJsonOverwrite(serializedData, v48);\n\treturn this.value;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override WeaponSetup Load(string serializedData)
		{
			WeaponSetup weaponSetup = value;
			object objectToOverwrite = weaponSetup;
			JsonUtility.FromJsonOverwrite(serializedData, objectToOverwrite);
			return value;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0xCC8418", Offset = "0xCC8418", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC5AE8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202377F]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box v45 @ X0_v3 (System.Object), typeof(GBG.Pinata.ECS.WeaponSetup), &v40 @ X8_v3 (GBG.Pinata.ECS.WeaponSetup)\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(v45);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string Save()
		{
			WeaponSetup weaponSetup = value;
			object obj = weaponSetup;
			return JsonUtility.ToJson(obj);
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0xCC8484", Offset = "0xCC8484", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF2988]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023780]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WeaponsSetupVariable()
		{
		}
	}
}
