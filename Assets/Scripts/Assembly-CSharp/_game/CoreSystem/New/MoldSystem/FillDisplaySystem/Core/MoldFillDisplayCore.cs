using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core
{
	[Token(Token = "0x20002D2")]
	public class MoldFillDisplayCore : MonoBehaviour, IDisposable
	{
		[SerializeField]
		[Token(Token = "0x40008A9")]
		[FieldOffset(Offset = "0x20")]
		internal TextMeshPro m_textPrefab;

		[SerializeField]
		[Token(Token = "0x40008AA")]
		[FieldOffset(Offset = "0x28")]
		internal int m_stopFillFrameThreshold;

		[Inject(false)]
		[Token(Token = "0x40008AB")]
		[FieldOffset(Offset = "0x30")]
		private IMoldFillDisplayCreator _creator;

		[Inject(false)]
		[Token(Token = "0x40008AC")]
		[FieldOffset(Offset = "0x38")]
		private IMoldFillDisplayCleaner _cleaner;

		[Inject(false)]
		[Token(Token = "0x40008AD")]
		[FieldOffset(Offset = "0x40")]
		private IMoldFillDisplaySystem _system;

		[Token(Token = "0x6000C76")]
		[Address(RVA = "0x3ED5BD8", Offset = "0x3ED5BD8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.TextPrefab = this.m_textPrefab;\n\tv45.StopFillFrameThreshold = this.m_stopFillFrameThreshold;\n\treturn v45;\nL_0017:\n\tv45 = new _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayConfig();\n\tSystem.Object::.ctor(v45);\n")]
		public MoldFillDisplayConfig BuildConfig()
		{
			MoldFillDisplayConfig moldFillDisplayConfig = new MoldFillDisplayConfig();
			moldFillDisplayConfig.TextPrefab = m_textPrefab;
			moldFillDisplayConfig.StopFillFrameThreshold = m_stopFillFrameThreshold;
			return moldFillDisplayConfig;
		}

		[Inject(false)]
		[Token(Token = "0x6000C77")]
		[Address(RVA = "0x3ED6AE8", Offset = "0x3ED6AE8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X19_v2 (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator)]);\n\tv150 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator>)+12E]) == 0;\n\tif (v45) goto L_0041;\n\tv119 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator>)+B0]) + 8;\n\tv119 = v119 + 0x10;\n\tv86 = v150 - 1;\n\tv56 = v150 != 1;\n\tv150 = v86;\n\tif (v56) goto L_0023;\nL_0041:\n\t_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator::CreateAll(this._creator);\nL_0041:\n\treturn;\nL_0047:\n\treturn;\nL_0049:\n\tv93 = *([v119 @ X10_v4]) << 4;\n\tv131 = v43 + v93;\n\tv153 = v131 + 0x138;\n\t// 84 IndirectJump [v153 @ X0_v5], this._creator (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator), this._creator (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator), [v153 @ X0_v5+8], [v153 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this._creator;\n\tv39 = this._creator == 0;\n\tif (v39) goto L_0047;\nL_0023:\n\tv111 = *([v119 @ X10_v4-8]) == _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator;\n\tif (v111) goto L_0049;\n")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillDisplayCore::Construct");
		}

		[Token(Token = "0x6000C78")]
		[Address(RVA = "0x3ED6BA4", Offset = "0x3ED6BA4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X19_v2 (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem)]);\n\tv150 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem>)+12E]) == 0;\n\tif (v45) goto L_0041;\n\tv119 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem>)+B0]) + 8;\n\tv119 = v119 + 0x10;\n\tv86 = v150 - 1;\n\tv56 = v150 != 1;\n\tv150 = v86;\n\tif (v56) goto L_0023;\nL_0041:\n\t_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem::Tick(this._system);\nL_0041:\n\treturn;\nL_0047:\n\treturn;\nL_0049:\n\tv93 = *([v119 @ X10_v4]) << 4;\n\tv131 = v43 + v93;\n\tv153 = v131 + 0x138;\n\t// 84 IndirectJump [v153 @ X0_v5], this._system (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem), this._system (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem), [v153 @ X0_v5+8], [v153 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this._system;\n\tv39 = this._system == 0;\n\tif (v39) goto L_0047;\nL_0023:\n\tv111 = *([v119 @ X10_v4-8]) == _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem;\n\tif (v111) goto L_0049;\n")]
		public void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillDisplayCore::Update");
		}

		[Token(Token = "0x6000C79")]
		[Address(RVA = "0x3ED6C60", Offset = "0x3ED6C60", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X19_v2 (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner)]);\n\tv150 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner>)+12E]) == 0;\n\tif (v45) goto L_0041;\n\tv119 = *([v43 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner>)+B0]) + 8;\n\tv119 = v119 + 0x10;\n\tv86 = v150 - 1;\n\tv56 = v150 != 1;\n\tv150 = v86;\n\tif (v56) goto L_0023;\nL_0041:\n\t_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner::ClearAll(this._cleaner);\nL_0041:\n\treturn;\nL_0047:\n\treturn;\nL_0049:\n\tv93 = *([v119 @ X10_v4]) << 4;\n\tv131 = v43 + v93;\n\tv153 = v131 + 0x138;\n\t// 84 IndirectJump [v153 @ X0_v5], this._cleaner (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner), this._cleaner (_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner), [v153 @ X0_v5+8], [v153 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this._cleaner;\n\tv39 = this._cleaner == 0;\n\tif (v39) goto L_0047;\nL_0023:\n\tv111 = *([v119 @ X10_v4-8]) == _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner;\n\tif (v111) goto L_0049;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillDisplayCore::Dispose");
		}

		[Token(Token = "0x6000C7A")]
		[Address(RVA = "0x3ED6D1C", Offset = "0x3ED6D1C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_stopFillFrameThreshold = 2;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldFillDisplayCore()
		{
			m_stopFillFrameThreshold = 2;
		}
	}
}
