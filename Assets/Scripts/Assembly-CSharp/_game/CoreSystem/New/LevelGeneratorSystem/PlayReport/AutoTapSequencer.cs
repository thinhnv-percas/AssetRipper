using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PlayReport
{
	[Token(Token = "0x200034A")]
	public sealed class AutoTapSequencer
	{
		[Token(Token = "0x40009B2")]
		[FieldOffset(Offset = "0x10")]
		private readonly IReadOnlyList<(int x, int y, string color)> _path;

		[Token(Token = "0x17000107")]
		[field: Token(Token = "0x40009B3")]
		[field: FieldOffset(Offset = "0x18")]
		public int Index
		{
			[Token(Token = "0x6000DE2")]
			[Address(RVA = "0x3EFE7CC", Offset = "0x3EFE7CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Index;\n")]
			get;
			[Token(Token = "0x6000DE3")]
			[Address(RVA = "0x3EFE7D4", Offset = "0x3EFE7D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Index = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000108")]
		public bool HasNext
		{
			[Token(Token = "0x6000DE5")]
			[Address(RVA = "0x3EFE810", Offset = "0x3EFE810", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tgoto L_0049;\nL_0041:\n\treturn 0;\nL_0013:\n\tv39 = this._path == 0;\n\tif (v39) goto L_0041;\nL_0049:\n\tv175 = System.Collections.Generic.IReadOnlyCollection`1<System.ValueTuple`3<System.Int32, System.Int32, System.String>>::get_Count(this._path);\n\tv116 = this.Index - v175;\n\tv114 = v116 < 0;\n\tv110 = this.Index ^ v175;\n\tv108 = this.Index ^ v116;\n\tv106 = v110 & v108;\n\tv104 = v106 < 0;\n\tv177 = v114 == v104;\n\tv102 = ~v177;\n\treturn v102;\n")]
			get
			{
				if (_path == null)
				{
					return false;
				}
				int count = _path.Count;
				int num = Index - count;
				bool flag = num < 0;
				int num2 = Index ^ count;
				int num3 = Index ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				bool flag3 = flag == flag2;
				return !flag3;
			}
		}

		[Token(Token = "0x6000DE4")]
		[Address(RVA = "0x3EFE7DC", Offset = "0x3EFE7DC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._path = path;\n\treturn;\n")]
		public AutoTapSequencer(IReadOnlyList<(int x, int y, string color)> path)
		{
			_path = path;
		}

		[Token(Token = "0x6000DE6")]
		[Address(RVA = "0x3EFE8D0", Offset = "0x3EFE8D0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tgoto L_004A;\nL_004A:\n\tv184 = System.Collections.Generic.IReadOnlyList`1<System.ValueTuple`3<System.Int32, System.Int32, System.String>>::get_Item(this._path, this.Index);\n\tv131 = v184 >> 0x20;\n\tv165 = this.Index + 1;\n\tthis.Index = v165;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v121 @ stack_-38_v2 (System.ValueTuple`2<System.Int32, System.Int32>), v184, v131);\n\treturn v121;\n")]
		public (int, int) Next()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoTapSequencer::Next");
			return default;
		}
	}
}
