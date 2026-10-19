using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.MoldSystem.Visual
{
	[Token(Token = "0x20002AD")]
	public class MoldVisualGridController : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x400084C")]
		[FieldOffset(Offset = "0x20")]
		private MoldConfig _config;

		[Inject(false)]
		[Token(Token = "0x400084D")]
		[FieldOffset(Offset = "0x28")]
		private EntityManager _em;

		[Token(Token = "0x400084E")]
		[FieldOffset(Offset = "0x30")]
		private float _stepX;

		[Token(Token = "0x400084F")]
		[FieldOffset(Offset = "0x34")]
		private float _stepY;

		[Token(Token = "0x170000F9")]
		public float CellWidth
		{
			[Token(Token = "0x6000BEF")]
			[Address(RVA = "0x3ECE16C", Offset = "0x3ECE16C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._config;\n\treturn v0.cellWidth;\n")]
			get
			{
				MoldConfig config = _config;
				return config.cellWidth;
			}
		}

		[Token(Token = "0x170000FA")]
		public float CellHeight
		{
			[Token(Token = "0x6000BF0")]
			[Address(RVA = "0x3ECE188", Offset = "0x3ECE188", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._config;\n\treturn v0.cellHeight;\n")]
			get
			{
				MoldConfig config = _config;
				return config.cellHeight;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000BF1")]
		[Address(RVA = "0x3ECE1A4", Offset = "0x3ECE1A4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._config;\n\tv5 = v0.cellWidth + v0.spacing;\n\tthis._stepX = v5;\n\treturn;\n")]
		private void Construct()
		{
			MoldConfig config = _config;
			float stepX = config.cellWidth + config.spacing.x;
			_stepX = stepX;
		}

		[Token(Token = "0x6000BF2")]
		[Address(RVA = "0x3EC9190", Offset = "0x3EC9190", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetColumns(this._em);\n\tv29 = 0 - coord.y;\n\tv32 = v29 + -0.5f;\n\tv49 = v32 * this._stepY;\n\tv44 = coord.y < 1;\n\tif (v44) goto L_002B;\n\tv45 = this._config;\n\tv49 = v49 - v45.frontRowGap;\n\tv77 = coord - v25;\n\tv79 = v77 + 0.5f;\n\tv80 = this._stepX * v79;\n\t// 64 MakeStruct v92 @ AGG3EC9230_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v80 @ V0_v6 (System.Single), v49 @ V8_v2 (System.Single), 0\n\treturnVal2 = UnityEngine.Transform::TransformPoint(v56, v92);\n\treturn returnVal2;\nL_002B:\n\tv56 = UnityEngine.Component::get_transform(this);\n")]
		public Vector3 GridToWorld(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualGridController::GridToWorld");
			return default;
		}

		[Token(Token = "0x6000BF3")]
		[Address(RVA = "0x3ECE1CC", Offset = "0x3ECE1CC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetColumns(this._em);\n\tv40 = coord.y <= 0;\n\tif (v40) goto L_002F;\n\tv50 = v21 * -0.5f;\n\tv67 = coord + v50;\n\tgoto L_0032;\nL_002F:\n\tv45 = v21 * -0.5f;\n\tv67 = coord + v45;\nL_0032:\n\tv72 = v67 + 0.5f;\n\treturnVal1 = this._stepX * v72;\n\treturn returnVal1;\n")]
		public Vector3 GridToLocal(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualGridController::GridToLocal");
			return default;
		}

		[Token(Token = "0x6000BF4")]
		[Address(RVA = "0x3ECE26C", Offset = "0x3ECE26C", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetColumns(this._em);\n\tv39 = _game.CoreSystem.New.MoldSystem.MoldQueryHelper::GetRows(this._em);\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv50 = UnityEngine.Transform::InverseTransformPoint(v43, worldPos);\n\tv86 = -this._stepY;\n\tv74 = v50.y < v86;\n\tv56 = ~v74;\nL_FFFFFFFF:\n\tv105 = v50.y;\n\tif (v56) goto L_003F;\n\tv53 = this._config;\n\tv105 = v50.y + v53.frontRowGap;\nL_FFFFFFFF:\n\tv226 = 0xFFFFFFFF80000000;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv226 = v202;\nL_0077:\n\tv172 = UnityEngine.Mathf::Floor(v240);\n\tv247 = v172 == 0x7F800000;\n\tv146 = ~v247;\n\tif (v146) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv142 = 0xFFFFFFFF80000000;\n\tgoto L_0089;\nL_FFFFFFFF:\n\tv142 = v240;\n\tv268 = v226 >= v35;\n\tif (v268) goto L_00B1;\n\tv291 = v142 & 0x80000000;\n\tv292 = v291 == 0;\n\tv288 = ~v292;\n\tif (v288) goto L_00B1;\n\tv274 = v142 >= v39;\n\tif (v274) goto L_00B1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v294 @ stack_-70_v3 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v226, v142);\nL_FFFFFFFF:\n\treturnVal2 = v294;\n\tgoto L_00C0;\nL_00B1:\n\treturnVal2 = _game.CoreSystem.New.GridEcsBinding.GridCoord::get_Invalid();\nL_00C0:\n\treturn returnVal2;\nL_003F:\n\tv115 = v50 / this._stepX;\n\tgoto L_0049;\nL_0051:\n\tv211 = UnityEngine.Mathf::Floor(v202);\n\tv216 = v211 == 0x7F800000;\n\tv223 = ~v216;\n\tif (v223) goto L_FFFFFFFF;\nL_0065:\n\tv228 = -v105;\n\tgoto L_0071;\nL_0089:\n\tv256 = v226 & 0x80000000;\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_00B1;\nL_0049:\n\tv202 = v35 + v115;\n\tgoto L_0051;\nL_0071:\n\tv240 = v228 / this._stepY;\n\tgoto L_0077;\n")]
		public GridCoord WorldToGrid(Vector3 worldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldVisualGridController::WorldToGrid");
			return default;
		}

		[Token(Token = "0x6000BF5")]
		[Address(RVA = "0x3ECE420", Offset = "0x3ECE420", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldVisualGridController()
		{
		}
	}
}
