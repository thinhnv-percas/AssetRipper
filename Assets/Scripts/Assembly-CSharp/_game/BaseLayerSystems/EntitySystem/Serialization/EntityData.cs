using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Serializable]
	[Token(Token = "0x200006A")]
	public class EntityData
	{
		[JsonProperty("id")]
		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x10")]
		public string Id;

		[JsonProperty("components")]
		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x18")]
		public List<ComponentData> Components;

		[Token(Token = "0x600017A")]
		[Address(RVA = "0x3C6EBAC", Offset = "0x3C6EBAC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis.Components = v52;\n\treturn;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tv52 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.ComponentData>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.ComponentData>::.ctor(v52);\n")]
		public EntityData()
		{
			List<ComponentData> components = new List<ComponentData>();
			Components = components;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0x3C6EC38", Offset = "0x3C6EC38", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tthis.Components = v70;\n\tgoto L_003F;\nL_003F:\n\tv105 = 0xB313000 + 0x308;\n\tgoto L_0049;\n\tthis.Id = v124;\n\treturn;\nL_0022:\n\tgoto L_002D;\nL_0049:\n\tv106 = entity >> 0x20;\n\tv107 = entity;\n\tv109 = 0xB7D5000 + 0x538;\n\tv112 = \"il2cpp_vm_object_box\"(*([v109 @ X23_v4 (System.Int32)+48]), &v107 @ stack_-44_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = v106;\n\tv119 = \"il2cpp_vm_object_box\"(*([v109 @ X23_v4 (System.Int32)+48]), &v116 @ stack_-48_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv124 = System.String::Format(*([v105 @ X21_v5 (System.Int32)]), v112, v119);\nL_002D:\n\tSystem.Object::.ctor(this);\n\tv70 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.ComponentData>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.ComponentData>::.ctor(v70);\n")]
		public EntityData(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityData::.ctor");
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x48CE0E0", Offset = "0x48CE0E0", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tgoto L_0023;\n\tgoto L_0023;\n\tv48 = 0x220C2B8(methodInfo, v43, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t_game.BaseLayerSystems.EntitySystem.Serialization.ComponentData::.ctor(v77, v71);\n\tv82 = this.Components == 0;\n\tif (v82) goto L_0077;\n\tv87 = v64._version + 1;\n\tv64._version = v87;\n\tv89 = v64._items == 0;\n\tif (v89) goto L_0077;\n\tgoto L_005E;\nL_005E:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.ComponentData>::Add(this.Components, v77);\n\tv164 = *([A4731E0]);\n\tv107 = *([v164 @ X9_v9]) != *([v17 @ X8_v2]);\n\tif (v107) goto L_0078;\n\treturn;\nL_0077:\n\tthrow v77;\nL_0078:\n\tv150 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0023:\n\tv56 = Il2CppClass<T>;\n\tv60 = *([v56 @ X20_v2 (Il2CppClass<T>)+FC]) + 0xF;\n\tv61 = v60 & 0x1FFFFFFF0;\n\t// 40 StackAlloc v62 @ X21_v2 (System.Byte*), v61 @ X9_v2 (System.Int32)\n\tv64 = this.Components;\n\tv66 = 0x8BF6A1C(v62, v43, *([v56 @ X20_v2 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 47 Box v71 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), v62 @ X21_v2 (System.Byte*)\n\tv77 = new _game.BaseLayerSystems.EntitySystem.Serialization.ComponentData();\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void AddComponent<T>(T component) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityData::AddComponent");
		}
	}
}
