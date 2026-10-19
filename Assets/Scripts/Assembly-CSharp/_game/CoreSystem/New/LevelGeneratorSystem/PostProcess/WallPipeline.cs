using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Actions;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x200033F")]
	public static class WallPipeline
	{
		[Token(Token = "0x2000340")]
		public readonly struct Stats
		{
			[Token(Token = "0x40009A0")]
			[FieldOffset(Offset = "0x0")]
			public readonly WallTrapClosure.Stats Trap1;

			[Token(Token = "0x40009A1")]
			[FieldOffset(Offset = "0xC")]
			public readonly int Extended;

			[Token(Token = "0x40009A2")]
			[FieldOffset(Offset = "0x10")]
			public readonly WallTrapClosure.Stats Trap2;

			[Token(Token = "0x6000DCB")]
			[Address(RVA = "0x3EFC920", Offset = "0x3EFC920", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Trap1 = trap1;\n\t*([this @ X0 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallPipeline+Stats)+8]) = trap1.Unresolved;\n\tthis.Extended = extended;\n\tthis.Trap2 = trap2;\n\t*([this @ X0 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallPipeline+Stats)+18]) = trap2.Unresolved;\n\treturn;\n")]
			public Stats(WallTrapClosure.Stats trap1, int extended, WallTrapClosure.Stats trap2)
			{
				Trap1 = trap1;
				_ = trap1.Unresolved;
				Extended = extended;
				Trap2 = trap2;
				_ = trap2.Unresolved;
			}

			[Token(Token = "0x6000DCC")]
			[Address(RVA = "0x3EFC934", Offset = "0x3EFC934", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\treturnVal1 = System.String::Format(\"trap1=({0}) extended={1} trap2=({2})\", v57, v67, v75);\n\treturn returnVal1;\nL_001D:\n\tv51 = this.Trap1;\n\tv52 = this.Trap1;\n\tv51.Unresolved = this.Trap1.Unresolved;\n\t// 35 Box v57 @ X0_v3 (System.Object), typeof(_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure+Stats), &v52 @ stack_-50_v1 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure+Stats)\n\tv62 = this.Extended;\n\tv64 = 0xB7D5000 + 0x538;\n\tv67 = \"il2cpp_vm_object_box\"(*([v64 @ X8_v7 (System.Int32)+48]), &v62 @ stack_-54_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv69 = this.Trap2;\n\tv70 = this.Trap2;\n\tv69.Unresolved = this.Trap2.Unresolved;\n\t// 51 Box v75 @ X0_v7 (System.Object), typeof(_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure+Stats), &v70 @ stack_-60_v1 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure+Stats)\n")]
			public override string ToString()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallPipeline.Stats::ToString");
				return default;
			}
		}

		[Token(Token = "0x400099F")]
		public static readonly bool ExtensionEnabled;

		[Token(Token = "0x6000DCA")]
		[Address(RVA = "0x3EFBBF4", Offset = "0x3EFBBF4", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0048;\n\tv169 = v99.Count;\n\tv126 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure::Apply(actions, gridSize, log);\n\tv184 = log == 0;\n\tv132 = ~v184;\n\tv172 = gridSize;\n\tv173 = v126;\n\tif (v132) goto L_006A;\n\tv172 = gridSize;\n\tv173 = v126;\n\tgoto L_0083;\nL_0056:\n\tv87 = log == 0;\n\tif (v87) goto L_007F;\n\tSystem.Action`1<System.String>::Invoke(log, \"[wall-ext] disabled (2026-06-16); skipping extension\");\n\tv110 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure::Apply(actions, gridSize, log);\n\tv169 = 0;\n\tv172 = gridSize;\n\tv173 = v110;\nL_007F:\n\tv114 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure::Apply(actions, gridSize, log);\n\tv169 = 0;\n\tv172 = gridSize;\n\tv173 = v114;\nL_0029:\n\tv60 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure::Apply(actions, gridSize, log);\n\tv78 = v67.ExtensionEnabled != 1;\n\tif (v78) goto L_0056;\nL_0048:\n\tv99 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallExtensionPass::ApplyAndCollect(actions, gridSize, log);\nL_006A:\n\tv143 = v60;\n\tv60.Unresolved = gridSize;\n\t// 113 Box v150 @ X0_v7 (System.Object), typeof(_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallPipeline+Stats), &v143 @ stack_-70_v2 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapClosure+Stats)\n\tv188 = System.String::Format(\"[wall-pipeline] {0}\", v150);\n\tSystem.Action`1<System.String>::Invoke(log, v188);\n\tgoto L_0083;\nL_0083:\n\treturnBuffer.Trap1 = v60;\n\t*([returnBuffer @ X8 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallPipeline+Stats)+8]) = gridSize;\n\treturnBuffer.Extended = v169;\n\treturnBuffer.Trap2 = v173;\n\t*([returnBuffer @ X8 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallPipeline+Stats)+18]) = v172;\n\treturn returnBuffer;\n")]
		public static Stats Run(IGeneratorActions actions, Vector2Int gridSize, Action<string> log = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallPipeline::Run");
			return default;
		}
	}
}
