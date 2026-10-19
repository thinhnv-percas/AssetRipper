using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts
{
	[Token(Token = "0x2000138")]
	public class TopGridVisualGridController : MonoBehaviour
	{
		[Token(Token = "0x40003F8")]
		private const float DefaultPadding = 0.05f;

		[Token(Token = "0x40003F9")]
		private const float Fallback = 1f;

		[Token(Token = "0x40003FA")]
		private const float FixedYPosition = 2.75f;

		[Inject(false)]
		[Token(Token = "0x40003FB")]
		[FieldOffset(Offset = "0x20")]
		internal TopGridHandler _gridHandler;

		[Token(Token = "0x170000A0")]
		public float CellSize
		{
			[Token(Token = "0x6000630")]
			[Address(RVA = "0x3DB2D04", Offset = "0x3DB2D04", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv13 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this._gridHandler, &v6 @ stack_-20_v1 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv35 = v13 == 0;\n\tv41 = ~v35;\n\tv42 = ~v41;\n\tif (v42) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_0021;\nL_FFFFFFFF:\n\treturnVal2 = 1f;\nL_0021:\n\treturn returnVal2;\n")]
			get
			{
				GridComponent grid = default(GridComponent);
				if (_gridHandler.TryGetGridComponent(out grid))
				{
					return 0f;
				}
				return 1f;
			}
		}

		[Token(Token = "0x170000A1")]
		public float EffectiveCubeSize
		{
			[Token(Token = "0x6000631")]
			[Address(RVA = "0x3DB2D48", Offset = "0x3DB2D48", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv13 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this._gridHandler, &v6 @ stack_-20_v1 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv31 = ~v13;\nL_FFFFFFFF:\n\treturnVal2 = 1f;\n\tif (v31) goto L_0028;\n\tv35 = v34 + v34;\n\tv36 = v34 < 0;\n\tv37 = v34 == 0;\n\tv40 = v34 == v34;\n\tv41 = ~v40;\n\tv45 = v36 == v41;\n\tv46 = ~v37;\n\tv47 = v45 & v46;\n\tv48 = ~v47;\n\tif (v48) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv93 = v35;\n\tgoto L_0024;\nL_FFFFFFFF:\n\tv93 = 0x3DCCCCCD;\nL_0028:\n\treturn returnVal2;\nL_0024:\n\treturnVal2 = 0 - v93;\n")]
			get
			{
				GridComponent grid = default(GridComponent);
				bool flag = _gridHandler.TryGetGridComponent(out grid);
				bool flag2 = !flag;
				float result = 1f;
				if (!flag2)
				{
					object obj = default(object);
					int num = (int)((nint)obj + (nint)obj);
					bool flag3 = (nint)obj < 0;
					bool flag4 = obj == null;
					bool flag5 = obj == obj;
					bool flag6 = !flag5;
					bool flag7 = flag3 == flag6;
					bool flag8 = !flag4;
					int num2 = ((!(flag7 && flag8)) ? 1036831949 : num);
					result = 0f - (float)num2;
				}
				return result;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000632")]
		[Address(RVA = "0x3DB2DA4", Offset = "0x3DB2DA4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.Component::get_transform(this);\n\tv20 = UnityEngine.Transform::get_position(v17);\n\tv36 = UnityEngine.Component::get_transform(this);\n\t// 35 MakeStruct v53 @ AGG3DB2E00_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v20 @ V0_v2 (UnityEngine.Vector3), 2.75f, v20.z (System.Single)\n\tUnityEngine.Transform::set_position(v36, v53);\n\treturn;\n")]
		private void Construct(ILevel level)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = default(Vector3);
			position2.x = position.x;
			position2.y = 2.75f;
			position2.z = position.z;
			transform2.position = position2;
		}

		[Inject(true)]
		[Token(Token = "0x6000633")]
		[Address(RVA = "0x3DB2E08", Offset = "0x3DB2E08", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = tempHolder == 0;\n\tif (v0) goto L_0009;\n\ttempHolder.Controller = this;\n\treturn;\nL_0009:\n\treturn;\n")]
		private void RegisterToTempHolder(TempTopGridVisualHolder tempHolder)
		{
			if (tempHolder != null)
			{
				tempHolder.Controller = this;
			}
		}

		[Token(Token = "0x6000634")]
		[Address(RVA = "0x3DB2E24", Offset = "0x3DB2E24", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this._gridHandler, &v28 @ stack_-50_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv74 = v30 == 0;\n\tif (v74) goto L_002E;\n\t// 25 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 28 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv78 = v28 * v79;\n\tv81 = coord + 0x3F;\n\tv82 = v81 * v79;\n\tv83 = v78 * 0x3F;\n\t// 34 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv84 = v82 - v83;\n\tv37 = 0;\n\tv40 = v84;\n\tgoto L_003B;\nL_002E:\n\tgoto L_0038;\n\t// 66 MakeStruct v101 @ AGG3DB2EF4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v40 @ stack_-60_v2 (UnityEngine.Vector3), v144 @ V0.S1, v37 @ V8_v2 (System.Single)\n\treturnVal2 = UnityEngine.Transform::TransformPoint(v60, v101);\n\treturn returnVal2;\nL_003B:\n\tv60 = UnityEngine.Component::get_transform(this);\nL_0038:\n\tv37 = v128.zero.z;\n\tv40 = v128.zero;\n")]
		public Vector3 GridToWorld(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualGridController::GridToWorld");
			return default;
		}

		[Token(Token = "0x6000635")]
		[Address(RVA = "0x3DB2F14", Offset = "0x3DB2F14", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this._gridHandler, &v19 @ stack_-30_v2 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv37 = v21 == 0;\n\tif (v37) goto L_002E;\n\t// 20 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 23 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv41 = v19 * v42;\n\tv44 = coord + 0x3F;\n\tv45 = v44 * v42;\n\tv46 = v41 * 0x3F;\n\t// 29 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\treturnVal2 = v45 - v46;\n\treturn returnVal2;\nL_002E:\n\tgoto L_003E;\nL_003E:\n\treturn v64.zero;\n")]
		public Vector3 GridToLocal(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualGridController::GridToLocal");
			return default;
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0x3DB2FD8", Offset = "0x3DB2FD8", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this._gridHandler, &v35 @ stack_-70_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv63 = v37 == 0;\n\tif (v63) goto L_00AD;\n\tv49 = UnityEngine.Component::get_transform(this);\n\tv157 = UnityEngine.Transform::InverseTransformPoint(v49, worldPos);\n\tv215 = 0 * v212;\n\tv217 = v215 * 0.5f;\n\tv218 = v157 + v217;\n\tgoto L_0041;\nL_FFFFFFFF:\n\tv205 = 0xFFFFFFFF80000000;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv205 = v189;\nL_0071:\n\tv190 = UnityEngine.Mathf::Floor(v199);\n\tv274 = v190 == 0x7F800000;\n\tv167 = ~v274;\n\tif (v167) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv191 = 0xFFFFFFFF80000000;\n\tgoto L_0083;\nL_FFFFFFFF:\n\tv191 = v199;\n\tv296 = v205 >= v212;\n\tif (v296) goto L_00B0;\n\tv298 = v191 & 0x80000000;\n\tv299 = v298 == 0;\n\tv201 = ~v299;\n\tif (v201) goto L_00B0;\n\tv162 = v191 >= v35;\n\tif (v162) goto L_00B0;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v159 @ stack_-60_v3 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v205, v191);\nL_FFFFFFFF:\n\treturnVal2 = v159;\n\tgoto L_00BD;\nL_00AD:\n\treturnVal2 = _game.CoreSystem.New.GridEcsBinding.GridCoord::get_Invalid();\n\tgoto L_00BD;\nL_00B0:\n\treturnVal2 = _game.CoreSystem.New.GridEcsBinding.GridCoord::get_Invalid();\nL_00BD:\n\treturn returnVal2;\nL_0041:\n\tv195 = 0 * v35;\n\tv189 = v218 / 0;\n\tgoto L_004A;\nL_005E:\n\tv254 = v195 * 0.5f;\n\tv255 = v157.y + v254;\n\tgoto L_006B;\nL_0083:\n\tv283 = v205 & 0x80000000;\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_00B0;\nL_004A:\n\tv238 = UnityEngine.Mathf::Floor(v189);\n\tv243 = v238 == 0x7F800000;\n\tv250 = ~v243;\n\tif (v250) goto L_FFFFFFFF;\nL_006B:\n\tv199 = v255 / 0;\n\tgoto L_0071;\n")]
		public GridCoord WorldToGrid(Vector3 worldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualGridController::WorldToGrid");
			return default;
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0x3DB3198", Offset = "0x3DB3198", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TopGridVisualGridController()
		{
		}
	}
}
