using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000075")]
	public readonly struct EntityId : IEquatable<EntityId>
	{
		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x0")]
		public readonly int Index;

		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x4")]
		public readonly int Generation;

		[Token(Token = "0x400011B")]
		public static readonly EntityId Invalid = default(EntityId);

		[Token(Token = "0x17000047")]
		public bool IsValid
		{
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0x3C6F288", Offset = "0x3C6F288", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.Index < 0;\n\tv6 = this.Index == 0;\n\tv8 = this.Index ^ this.Index;\n\tv9 = this.Index & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v6;\n\tv13 = v11 & v12;\n\treturn v13;\n")]
			get
			{
				bool flag = Index < 0;
				bool flag2 = Index == 0;
				int num = Index ^ Index;
				int num2 = Index & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0x3C7078C", Offset = "0x3C7078C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Index = index;\n\tthis.Generation = generation;\n\treturn;\n")]
		public EntityId(int index, int generation)
		{
			Index = index;
			Generation = generation;
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0x3C6EDA8", Offset = "0x3C6EDA8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn returnVal1;\nL_0017:\n\tv45 = this.Index;\n\tv47 = 0xB7D5000 + 0x538;\n\tv50 = \"il2cpp_vm_object_box\"(*([v47 @ X22_v2 (System.Int32)+48]), &v45 @ stack_-34_v1 (System.Int32), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = this.Generation;\n\tv56 = \"il2cpp_vm_object_box\"(*([v47 @ X22_v2 (System.Int32)+48]), &v53 @ stack_-38_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = System.String::Format(\"{0}:{1}\", v50, v56);\n")]
		public string ToSerializable()
		{
			int index = Index;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			int generation = Generation;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			return $"{arg}:{arg2}";
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0x3C70794", Offset = "0x3C70794", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv94 = System.String::Split(s, 0x3A, 0);\n\tv54 = v94.Length != 2;\n\tif (v54) goto L_0054;\n\tv95 = System.Int32::TryParse(v94[0], &v51 @ stack_-24_v3 (System.Int32));\n\tv99 = v95 == 0;\n\tif (v99) goto L_0054;\n\tv96 = System.Int32::TryParse(v94[1], &v48 @ stack_-28_v3 (System.Int32));\n\tv100 = v96 == 0;\n\tif (v100) goto L_0054;\n\treturnVal3 = v51 | v48;\n\treturn returnVal3;\nL_0054:\n\tgoto L_005B;\nL_0017:\n\tv43 = System.String::IsNullOrEmpty(s);\n\tv44 = ~v43;\n\tv45 = ~v44;\n\tif (v45) goto L_0054;\nL_005B:\n\treturnVal1 = v120.Invalid | v120.Invalid.Generation;\n\treturn returnVal1;\n")]
		public static EntityId FromSerializable(string s)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityId::FromSerializable");
			return default;
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0x3C6F348", Offset = "0x3C6F348", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.Index != other;\n\tif (v12) goto L_001A;\n\tv17 = this.Generation - other.Generation;\n\tv19 = v17 == 0;\n\treturn v19;\nL_001A:\n\treturn 0;\n")]
		public bool Equals(EntityId other)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityId::Equals");
			return default;
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0x3C7089C", Offset = "0x3C7089C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv57 = *([obj @ X1 (System.Object)]) != _game.BaseLayerSystems.EntitySystem.Core.EntityId;\n\tif (v57) goto L_006E;\n\t// -1 IsInst v62_asT @ TEMPCOND_v3 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), typeof(_game.BaseLayerSystems.EntitySystem.Core.EntityId), obj @ X1 (System.Object)\n\tv62 = v62_asT == 0;\n\tif (v62) goto L_006F;\n\tv166 = \"il2cpp_vm_object_unbox\"(obj, _game.BaseLayerSystems.EntitySystem.Core.EntityId, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0044;\nL_0044:\n\tv63 = this.Index != *([v166 @ X0_v6]);\n\tif (v63) goto L_006E;\n\tv157 = *([v166 @ X0_v6]) >> 0x20;\n\tv148 = this.Generation - v157;\n\tv144 = v148 == 0;\n\treturn v144;\nL_006E:\n\treturn 0;\nL_006F:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\nL_0015:\n\tv43 = obj == 0;\n\tif (v43) goto L_006E;\n")]
		public override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityId::Equals");
			return default;
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0x3C6F58C", Offset = "0x3C6F58C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_002D:\n\treturnVal1 = System.HashCode::Combine(this.Index, this.Generation);\n\treturn returnVal1;\nL_0021:\n\tgoto L_002D;\n")]
		public override int GetHashCode()
		{
			return HashCode.Combine(Index, Generation);
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0x3C7096C", Offset = "0x3C7096C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0020;\nL_0020:\n\tv61 = this.Index <= 0;\n\tif (v61) goto L_0066;\n\tv96 = this.Index;\n\tv98 = 0xB7D5000 + 0x538;\n\tv101 = \"il2cpp_vm_object_box\"(*([v98 @ X22_v3 (System.Int32)+48]), &v96 @ stack_-34_v1 (System.Int32), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv131 = this.Generation;\n\tv134 = \"il2cpp_vm_object_box\"(*([v98 @ X22_v3 (System.Int32)+48]), &v131 @ stack_-38_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = System.String::Format(\"E{0}:{1}\", v101, v134);\n\treturn returnVal2;\nL_0066:\n\treturn \"Invalid\";\n")]
		public override string ToString()
		{
			if (Index > 0)
			{
				int index = Index;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int generation = Generation;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				return $"E{arg}:{arg2}";
			}
			return "Invalid";
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0x3C70A78", Offset = "0x3C70A78", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv52 = a - b;\n\tv54 = v52 == 0;\n\treturn v54;\n")]
		public static bool operator ==(EntityId a, EntityId b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityId::operator ==");
			return default;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0x3C70B04", Offset = "0x3C70B04", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv52 = a - b;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\treturn v59;\n")]
		public static bool operator !=(EntityId a, EntityId b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityId::operator !=");
			return default;
		}
	}
}
