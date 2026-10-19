using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000073")]
	public readonly struct Entity : IEquatable<Entity>
	{
		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x0")]
		public readonly EntityId Id;

		[Token(Token = "0x4000116")]
		public static readonly Entity Invalid = new Entity(EntityId.Invalid);

		[Token(Token = "0x17000046")]
		public bool IsValid
		{
			[Token(Token = "0x60001B0")]
			[Address(RVA = "0x3C6D22C", Offset = "0x3C6D22C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0020:\n\tv54 = this.Id < 0;\n\tv55 = this.Id == 0;\n\tv57 = this.Id ^ this.Id;\n\tv58 = this.Id & v57;\n\tv59 = v58 < 0;\n\tv60 = v54 == v59;\n\tv61 = ~v55;\n\tv62 = v60 & v61;\n\treturn v62;\nL_001A:\n\tgoto L_0020;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Entity::get_IsValid");
				return default;
			}
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0x3C6F298", Offset = "0x3C6F298", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Id = id;\n\treturn;\n")]
		public Entity(EntityId id)
		{
			Id = id;
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0x3C6F2A0", Offset = "0x3C6F2A0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_001F;\nL_001F:\n\tv60 = this.Id != other;\n\tif (v60) goto L_0053;\n\tv89 = other >> 0x20;\n\tv93 = this.Id.Generation - v89;\n\tv95 = v93 == 0;\n\treturn v95;\nL_0053:\n\treturn 0;\n")]
		public bool Equals(Entity other)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Entity::Equals");
			return default;
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0x3C6F370", Offset = "0x3C6F370", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv57 = *([obj @ X1 (System.Object)]) != _game.BaseLayerSystems.EntitySystem.Core.Entity;\n\tif (v57) goto L_008C;\n\t// -1 IsInst v65_asT @ TEMPCOND_v3 (_game.BaseLayerSystems.EntitySystem.Core.Entity), typeof(_game.BaseLayerSystems.EntitySystem.Core.Entity), obj @ X1 (System.Object)\n\tv65 = v65_asT == 0;\n\tif (v65) goto L_008D;\n\tv173 = \"il2cpp_vm_object_unbox\"(obj, _game.BaseLayerSystems.EntitySystem.Core.Entity, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_003D;\nL_003D:\n\tv191 = 0xB28D000 + 0xE20;\n\tv181 = *([B78D6F2]) & 1;\n\tv182 = v181 == 0;\n\tif (v182) goto L_0072;\n\tv193 = *([v191 @ X21_v13 (System.Int32)]);\n\tv195 = *([v193 @ X0_v20+E4]) == 0;\n\tif (v195) goto L_007E;\nL_004F:\n\tv66 = this.Id != *([v173 @ X0_v6]);\n\tif (v66) goto L_008C;\nL_0051:\n\tv164 = *([v173 @ X0_v6]) >> 0x20;\n\tv154 = this.Id.Generation - v164;\n\tv150 = v154 == 0;\n\treturn v150;\nL_0072:\n\t*([B78D6F2]) = 1;\n\tv207 = *([v191 @ X21_v13 (System.Int32)]);\n\tv215 = *([v207 @ X0_v14+E4]) == 0;\n\tv208 = ~v215;\n\tif (v208) goto L_004F;\nL_007E:\n\tv85 = this.Id == *([v173 @ X0_v6]);\n\tif (v85) goto L_0051;\nL_008C:\n\treturn 0;\nL_008D:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\nL_0015:\n\tv43 = obj == 0;\n\tif (v43) goto L_008C;\n")]
		public override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Entity::Equals");
			return default;
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0x3C6F498", Offset = "0x3C6F498", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001A;\nL_001A:\n\tgoto L_001C;\nL_001C:\n\tv88 = 0xB2CA000 + 0xF98;\n\tgoto L_002D;\nL_002D:\n\treturnVal1 = System.HashCode::Combine /* +1 sharing this address */(this.Id, this.Id.Generation, *([v88 @ X22_v4 (System.Int32)]));\n\treturn returnVal1;\n")]
		public override int GetHashCode()
		{
			int num = 187473920 + 3992;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4985CD4 (System.HashCode::Combine, and 1 more at this address)");
			int result = default(int);
			return result;
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0x3C6F60C", Offset = "0x3C6F60C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv48 = this.Id;\n\t// 31 Box v51 @ X0_v3 (System.Object), typeof(_game.BaseLayerSystems.EntitySystem.Core.EntityId), &v48 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityId)\n\treturnVal1 = System.String::Format(\"Entity({0})\", v51);\n\treturn returnVal1;\n")]
		public override string ToString()
		{
			EntityId id = Id;
			object arg = id;
			return $"Entity({arg})";
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0x3C6F698", Offset = "0x3C6F698", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv65 = 0xB28D000 + 0xE20;\n\tv54 = *([B78D6F2]) & 1;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0049;\n\tv71 = *([v65 @ X22_v10 (System.Int32)]);\n\tv73 = *([v71 @ X0_v18+E4]) == 0;\n\tif (v73) goto L_0052;\nL_0022:\n\tv95 = left - right;\n\tv97 = v95 == 0;\n\treturn v97;\nL_0049:\n\t*([B78D6F2]) = 1;\n\tv86 = *([v65 @ X22_v10 (System.Int32)]);\n\tv116 = *([v86 @ X0_v8+E4]) == 0;\n\tv88 = ~v116;\n\tif (v88) goto L_0022;\nL_0052:\n\tv132 = left - right;\n\tv128 = v132 == 0;\n\treturn v128;\n")]
		public static bool operator ==(Entity left, Entity right)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Entity::operator ==");
			return default;
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0x3C6F77C", Offset = "0x3C6F77C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv65 = 0xB28D000 + 0xE20;\n\tv54 = *([B78D6F2]) & 1;\n\tv55 = v54 == 0;\n\tif (v55) goto L_004A;\n\tv71 = *([v65 @ X22_v10 (System.Int32)]);\n\tv73 = *([v71 @ X0_v18+E4]) == 0;\n\tif (v73) goto L_0053;\nL_0022:\n\tv95 = left - right;\n\tv97 = v95 == 0;\n\tv102 = ~v97;\n\treturn v102;\nL_004A:\n\t*([B78D6F2]) = 1;\n\tv86 = *([v65 @ X22_v10 (System.Int32)]);\n\tv117 = *([v86 @ X0_v8+E4]) == 0;\n\tv88 = ~v117;\n\tif (v88) goto L_0022;\nL_0053:\n\tv135 = left - right;\n\tv131 = v135 == 0;\n\tv121 = ~v131;\n\treturn v121;\n")]
		public static bool operator !=(Entity left, Entity right)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Entity::operator !=");
			return default;
		}
	}
}
