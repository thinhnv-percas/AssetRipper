using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using Unco.RewardSystem;
using UnityEngine;

namespace Systems.RewardSystem.UnityBindings
{
	[Token(Token = "0x2000005")]
	public class GenericElementVisualizer : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000006")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000009")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400000A")]
			public static Func<GenericElementVisualizerState, bool> _003C_003E9__8_0;

			[Token(Token = "0x600000E")]
			[Address(RVA = "0x81D49A8", Offset = "0x81D49A8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Systems.RewardSystem.UnityBindings.GenericElementVisualizer+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600000F")]
			[Address(RVA = "0x81D4A0C", Offset = "0x81D4A0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CLazyLoad_003Eb__8_0(GenericElementVisualizerState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GenericElementVisualizer._003C_003Ec::_003CLazyLoad_003Eb__8_0");
				return default;
			}
		}

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private GenericElementVisualizerState[] _states;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x28")]
		private GenericElementFallbackState _fallbackState;

		[Token(Token = "0x17000001")]
		[field: Token(Token = "0x4000008")]
		[field: FieldOffset(Offset = "0x30")]
		public ShopItemData Data
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x81D43E8", Offset = "0x81D43E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Data;\n")]
			get;
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x81D43F0", Offset = "0x81D43F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Data = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81D43F8", Offset = "0x81D43F8", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv69 = v56.Length < 1;\n\tif (v69) goto L_0077;\n\tv129 = 0;\n\tgoto L_0042;\nL_0036:\n\tv129 = v129 + 1;\n\tv90 = v129 >= v56.Length;\n\tif (v90) goto L_0077;\nL_0042:\n\tv114 = v56[v129 @ X23_v5 (System.Int32)];\n\tv143 = v56[v129 @ X23_v5 (System.Int32)] == 0;\n\tif (v143) goto L_0078;\n\tv221 = Unco.RewardSystem.GenericElementVisualizerState::IsTypeOf(v56[v129 @ X23_v5 (System.Int32)], data);\n\tv222 = v221 & 1;\n\tv223 = v222 == 0;\n\tif (v223) goto L_0065;\n\tv225 = UnityEngine.Component::get_gameObject(v56[v129 @ X23_v5 (System.Int32)]);\n\tv209 = v225 == 0;\n\tif (v209) goto L_007C;\n\tUnityEngine.GameObject::SetActive(v225, 1);\n\tv232 = *([v114 @ X21_v6 (UnityEngine.Component)]);\n\t*([v232 @ X8_v10 (Il2CppClass<UnityEngine.Component>)+178])(v237, v56[v129 @ X23_v5 (System.Int32)], data, *([v232 @ X8_v10 (Il2CppClass<UnityEngine.Component>)+180]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0036;\nL_0065:\n\tv227 = UnityEngine.Component::get_gameObject(v56[v129 @ X23_v5 (System.Int32)]);\n\tv208 = v227 == 0;\n\tif (v208) goto L_007A;\n\tUnityEngine.GameObject::SetActive(v227, 0);\n\tgoto L_0036;\nL_0077:\n\treturn;\nL_0078:\n\tv204 = new System.NullReferenceException();\n\tgoto L_00FB;\nL_007A:\n\tv204 = new System.NullReferenceException();\n\tgoto L_00FB;\nL_007C:\n\tv204 = new System.NullReferenceException();\n\tgoto L_00FB;\nL_007E:\n\tv204 = new System.NullReferenceException();\n\tgoto L_00FB;\nL_00FB:\n\t// 251 Interrupt\n\tv211 = 0x8BF5BF4(v204, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv218 = 0x8BF0368(v204, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv180 = 0x7C03E68(v218, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001B:\n\tthis.Data = data;\n\tSystems.RewardSystem.UnityBindings.GenericElementVisualizer::LazyLoad(this);\n\tv56 = this._states;\n\tv57 = this._states == 0;\n\tif (v57) goto L_007E;\n")]
		public void Initialize(ShopItemData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenericElementVisualizer::Initialize");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81D487C", Offset = "0x81D487C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv73 = v60.Length < 1;\n\tif (v73) goto L_0064;\n\tv87 = 0;\nL_0046:\n\tv159 = Unco.RewardSystem.GenericElementVisualizerState::IsTypeOf(v60[v87 @ X23_v5 (System.Int32)], data);\n\tv229 = v159 == 0;\n\tv161 = ~v229;\n\tif (v161) goto L_0076;\n\tv87 = v87 + 1;\n\tv139 = v87 < v60.Length;\n\tif (v139) goto L_0046;\nL_0064:\n\treturn 0;\nL_0076:\n\tv208 = Unco.RewardSystem.GenericElementVisualizerState::IsEnabled(v208, data, reason);\nL_0076:\n\treturn v60[v87 @ X23_v5 (System.Int32)];\nL_001B:\n\tSystems.RewardSystem.UnityBindings.GenericElementVisualizer::LazyLoad(this);\n\tv54 = 0xB7D5000 + 0x538;\n\tv55 = *([v54 @ X8_v4 (System.Int32)+90]);\n\tv56 = *([v55 @ X8_v5+B8]);\n\t*([reason @ X2 (System.String&)]) = *([v56 @ X8_v6]);\n\tv60 = this._states;\n")]
		public bool IsEnabled(ShopItemData data, out string reason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenericElementVisualizer::IsEnabled");
			reason = default;
			return default;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81D469C", Offset = "0x81D469C", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv76 = UnityEngine.Component::GetComponentsInChildren(this, 1);\n\tgoto L_0050;\n\tgoto L_005E;\nL_006F:\n\tv173 = System.Linq.Enumerable::Where(v76, v161);\n\tv186 = System.Linq.Enumerable::ToArray(v173);\n\tthis._states = v186;\n\tv200 = UnityEngine.Component::GetComponentInChildren(this, 1);\n\tthis._fallbackState = v200;\n\treturn;\nL_009A:\n\treturn;\nL_0035:\n\tv61 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(this._states);\n\tv65 = ~v61;\n\tif (v65) goto L_009A;\nL_0050:\n\tv150 = v148.<>9__8_0 == 0;\n\tv151 = ~v150;\n\tv161 = v148.<>9__8_0;\n\tif (v151) goto L_006F;\nL_005E:\n\tv184 = new System.Func`2<Unco.RewardSystem.GenericElementVisualizerState, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.GenericElementVisualizerState, System.Boolean>::.ctor(v184, v179.<>9, Il2CppMethodInfo);\n\tv196.<>9__8_0 = v184;\n\tv161 = v184;\n")]
		private void LazyLoad()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenericElementVisualizer::LazyLoad");
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x49830CC", Offset = "0x49830CC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0010:\n\tSystems.RewardSystem.UnityBindings.GenericElementVisualizer::LazyLoad(this);\n\tv39 = System.Linq.Enumerable::OfType(this._states);\n\treturnVal1 = System.Linq.Enumerable::FirstOrDefault(v39);\n\treturn returnVal1;\n")]
		public T GetState<T>() where T : GenericElementVisualizerState
		{
			LazyLoad();
			IEnumerable<object> source = _states.OfType<T>();
			return (T)source.FirstOrDefault();
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81D49A0", Offset = "0x81D49A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GenericElementVisualizer()
		{
		}
	}
}
