using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Systems.FeatureSystem.Core;
using Systems.FeatureSystem.Data;
using Systems.ShopSystem.Scripts.Core;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.Systems.ShopSystem.Scripts.Core;

namespace Systems.ShopSystem.Scripts.Ui.ShopGroups
{
	[Token(Token = "0x2000054")]
	public class ShopGroupViewController : MonoBehaviour
	{
		[Token(Token = "0x2000055")]
		private readonly struct FilterEntry
		{
			[Token(Token = "0x40000D9")]
			[FieldOffset(Offset = "0x0")]
			public readonly string PackId;

			[Token(Token = "0x40000DA")]
			[FieldOffset(Offset = "0x8")]
			public readonly ShopFilterController Filter;

			[Token(Token = "0x40000DB")]
			[FieldOffset(Offset = "0x10")]
			public readonly bool Enabled;

			[Token(Token = "0x6000120")]
			[Address(RVA = "0x3C6AD70", Offset = "0x3C6AD70", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.PackId = packId;\n\tthis.Filter = filter;\n\tthis.Enabled = enabled;\n\treturn;\n")]
			public FilterEntry(string packId, ShopFilterController filter, bool enabled)
			{
				PackId = packId;
				Filter = filter;
				Enabled = enabled;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000056")]
		private sealed class _003C_003Ec__DisplayClass22_0
		{
			[Token(Token = "0x40000DC")]
			[FieldOffset(Offset = "0x10")]
			public string groupId;

			[Token(Token = "0x40000DD")]
			[FieldOffset(Offset = "0x18")]
			public ShopGroupViewController _003C_003E4__this;

			[Token(Token = "0x6000121")]
			[Address(RVA = "0x3C6AD68", Offset = "0x3C6AD68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass22_0()
			{
			}

			internal void _003CBuildFilters_003Eb__0()
			{
				_003C_003E4__this.Select(groupId);
			}
		}

		[Token(Token = "0x40000CA")]
		private const int LINE_ROW_CAPACITY = 3;

		[SerializeField]
		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_groupViewContainer;

		[SerializeField]
		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x28")]
		private Transform m_filterContainer;

		[SerializeField]
		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x30")]
		private ShopFilterController m_filterPrefab;

		[SerializeField]
		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x38")]
		private SeparatorAutoHide m_viewTypeSeparatorPrefab;

		[SerializeField]
		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x40")]
		private string m_layoutId;

		[SerializeField]
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x48")]
		private List<string> m_activeKeys;

		[Inject(false)]
		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x50")]
		private ShopService _shopService;

		[Inject(false)]
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x58")]
		private FeatureService _featureService;

		[Inject(false)]
		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x60")]
		private ShopVisualHub _shopVisualHub;

		[Inject(false)]
		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x68")]
		private Instancer _instancer;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x70")]
		private readonly List<FilterEntry> _filterEntries;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x78")]
		private string _activePackId;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x80")]
		private Dictionary<string, ShopGroupView> _instantiatedGroupViews;

		[CompilerGenerated]
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x88")]
		private Action<string> OnGroupChanged;

		[Token(Token = "0x17000033")]
		public string ActivePackId
		{
			[Token(Token = "0x6000115")]
			[Address(RVA = "0x3C69CF4", Offset = "0x3C69CF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ActivePackId;\n")]
			get
			{
				return _activePackId;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6000116")]
		[Address(RVA = "0x3C69CFC", Offset = "0x3C69CFC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnGroupChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnGroupChanged (System.Action`1<System.String>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnGroupChanged(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupViewController::add_OnGroupChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000117")]
		[Address(RVA = "0x3C69DB0", Offset = "0x3C69DB0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnGroupChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnGroupChanged (System.Action`1<System.String>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnGroupChanged(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupViewController::remove_OnGroupChanged");
		}

		[Inject(false)]
		[Token(Token = "0x6000118")]
		[Address(RVA = "0x3C69E64", Offset = "0x3C69E64", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController::BuildGroupViews(this);\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController::SelectFirstEnabled(this);\n\treturn;\n")]
		public void Init()
		{
			BuildGroupViews();
			SelectFirstEnabled();
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x3C69E88", Offset = "0x3C69E88", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\n\tv144 = this.m_activeKeys;\n\tv69 = this.m_activeKeys == 0;\n\tif (v69) goto L_005B;\n\tv87 = v144.Count > 0;\n\tif (v87) goto L_0069;\nL_005B:\n\tv172 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetActiveGroupKeys(this._shopService);\n\tgoto L_FFFFFFFF;\nL_0062:\n\tv172 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetOrderedGroupKeys(this._shopService, this.m_layoutId);\nL_FFFFFFFF:\n\tv144 = v172;\n\tv456 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v144);\n\tv286 = v456._list;\nL_FFFFFFFF:\n\tv290 = 0;\nL_FFFFFFFF:\n\tv679 = 0;\nL_FFFFFFFF:\n\tv344 = 0;\n\tv435 = this._shopService == 0;\n\tif (v435) goto L_015B;\n\tv491 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetGroupConfig(this._shopService, v456.Current);\n\tv495 = v491 == 0;\n\tif (v495) goto L_0091;\n\tv436 = this._shopVisualHub == 0;\n\tif (v436) goto L_015D;\n\tv578 = _game.Systems.ShopSystem.Scripts.Core.ShopVisualHub::GetGroupViewPrefab(this._shopVisualHub, v491.viewType);\n\tgoto L_00AF;\nL_00AF:\n\tv492 = UnityEngine.Object::op_Equality(v578, 0);\n\tv586 = v492 == 0;\n\tv496 = ~v586;\n\tif (v496) goto L_0091;\n\tgoto L_00BE;\nL_00BE:\n\tv596 = UnityEngine.Object::op_Inequality(this.m_viewTypeSeparatorPrefab, 0);\n\tv606 = v344 != 0;\n\tif (v606) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv609 = 0;\n\tgoto L_00CF;\nL_FFFFFFFF:\n\tv609 = v596;\n\tv615 = System.String::op_Inequality(v344, v491.viewType);\n\tv626 = v615 == 0;\n\tif (v626) goto L_00ED;\n\tgoto L_00E5;\nL_00E5:\n\tv623 = UnityEngine.Object::Instantiate(this.m_viewTypeSeparatorPrefab, this.m_groupViewContainer);\nL_FFFFFFFF:\n\tv290 = 0;\nL_FFFFFFFF:\n\tv679 = 0;\n\tgoto L_00FA;\nL_00FA:\n\tv657 = UnityEngine.Object::op_Equality(v290, 0);\n\tv420 = v679 - 2;\n\tv417 = v420 < 0;\n\tv414 = v420 == 0;\n\tv411 = v679 ^ 2;\n\tv408 = v679 ^ v420;\n\tv405 = v411 & v408;\n\tv402 = v405 < 0;\n\tv669 = v417 == v402;\n\tv670 = ~v669;\n\tv399 = v670 | v414;\n\tv360 = ~v399;\n\tif (v360) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv674 = v657;\n\tgoto L_010E;\nL_FFFFFFFF:\n\tv674 = 1;\n\tv440 = this._shopVisualHub;\n\tgoto L_0120;\nL_0120:\n\tv684 = UnityEngine.Object::Instantiate(v440.LineRowPrefab, this.m_groupViewContainer);\nL_FFFFFFFF:\n\tv290 = v684;\nL_FFFFFFFF:\n\tv679 = 0;\nL_0128:\n\tv313 = this.m_groupViewContainer;\nL_FFFFFFFF:\n\tv290 = 0;\nL_FFFFFFFF:\n\tv679 = 0;\nL_FFFFFFFF:\n\t;\n\tv338 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(this._instancer, v578, v313, 1);\n\tv340 = v338 == 0;\nL_FFFFFFFF:\n\tv216 = &v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\tv381 = 0;\nL_FFFFFFFF:\n\tv391 = v578;\n\tif (v340) goto L_0162;\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView::Init(v338, v456.Current);\n\tv437 = *([v351 @ X0_v10]) == 0;\n\tif (v437) goto L_0164;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::set_Item(*([v351 @ X0_v10]), v456.Current, v338);\n\tv344 = v491.viewType;\n\tgoto L_0091;\nL_FFFFFFFF:\n\tv216 = &v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv266 = 0;\n\treturn;\nL_015B:\n\tv429 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv216 = &v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\tv381 = 0;\nL_FFFFFFFF:\n\tv391 = 0;\n\tgoto L_0169;\nL_015D:\n\tv430 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv216 = &v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\tv381 = 0;\nL_FFFFFFFF:\n\tv391 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv427 = v429;\n\tgoto L_0169;\nL_0161:\n\tv268 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv216 = v214;\nL_FFFFFFFF:\n\tv381 = v220;\nL_FFFFFFFF:\n\tv391 = v233;\nL_0162:\n\tv346 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv216 = &v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\tv381 = 0;\nL_FFFFFFFF:\n\tv391 = v456.Current;\nL_FFFFFFFF:\n\tv427 = v430;\n\tgoto L_0169;\nL_0164:\n\tv427 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv427 = v346;\n\tgoto L_0169;\nL_0166:\n\tv432 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv216 = &v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\tv381 = 0;\nL_FFFFFFFF:\n\tv391 = v456.Current;\n\tgoto L_0169;\nL_0169:\n\t// 361 Interrupt\n\tgoto L_018A;\nL_018A:\n\tv466 = v391 != 1;\n\tif (v466) goto L_0193;\n\tv477 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv266 = *([v477 @ X0_v68]);\n\tv504 = 0x8BF5BF4(v477, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0149;\nL_0193:\n\tv480 = 0x3173CEC(&v381 @ stack_-98_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv506 = 0x8BF0368(v427, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv512 = 0xA1B8(v506, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0043:\n\tv60 = System.String::IsNullOrEmpty(this.m_layoutId);\n\tv64 = ~v60;\n\tif (v64) goto L_0062;\nL_0069:\n\tv180 = new System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>::.ctor(v180);\n\tv351 = this + 0x80;\n\tthis._instantiatedGroupViews = v180;\nL_0091:\n\tv501 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v286 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>));\n\tv511 = v501 == 0;\n\tif (v511) goto L_FFFFFFFF;\nL_00CF:\n\tv611 = v609 == 0;\n\tif (v611) goto L_00ED;\nL_00ED:\n\tv634 = System.String::op_Equality(v491.viewType, \"line\");\n\tv637 = v634 == 0;\n\tif (v637) goto L_0128;\nL_010E:\n\tv676 = v674 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v676) goto L_0123;\nL_012A:\n\tv438 = this._instancer == 0;\n\tif (v438) goto L_0166;\nL_0149:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v216);\n\tv522 = v266 == 0;\n\tv260 = ~v522;\n\tif (v260) goto L_0161;\nL_0123:\n\tv679 = v679 + 1;\nL_FFFFFFFF:\n\tv313 = v290;\n\tgoto L_012A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void BuildGroupViews()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupViewController::BuildGroupViews");
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x3C6A590", Offset = "0x3C6A590", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tthis.ActivePackId = packId;\n\tv104 = System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>::get_Item(this._instantiatedGroupViews, packId);\n\tv107 = UnityEngine.Component::get_gameObject(v104);\n\tUnityEngine.GameObject::SetActive(v107, 1);\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController::UpdateFilterVisuals(this);\n\tv62 = this.OnGroupChanged == 0;\n\tif (v62) goto L_004C;\n\tSystem.Action`1<System.String>::Invoke(this.OnGroupChanged, packId);\n\treturn;\nL_004C:\n\treturn;\nL_001A:\n\tv48 = System.String::op_Equality(packId, this.ActivePackId);\n\tv50 = v48 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_004C;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Select(string packId)
		{
			if (!(packId == ActivePackId))
			{
				_activePackId = packId;
				Component component = _instantiatedGroupViews[packId];
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: true);
				UpdateFilterVisuals();
				if (OnGroupChanged != null)
				{
					OnGroupChanged(packId);
				}
			}
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x3C6A888", Offset = "0x3C6A888", Length = "0x4E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\nL_0047:\n\tv69 = UnityEngine.Object::op_Equality(this.m_filterPrefab, 0);\n\tv77 = v69 == 0;\n\tif (v77) goto L_005D;\n\tgoto L_0151;\nL_005D:\n\tgoto L_0060;\nL_0060:\n\tv245 = UnityEngine.Object::op_Equality(this.m_filterContainer, 0);\n\tv250 = v245 == 0;\n\tif (v250) goto L_0072;\n\tgoto L_0151;\nL_0072:\n\tv342 = System.String::IsNullOrEmpty(this.m_layoutId);\n\tv348 = ~v342;\n\tif (v348) goto L_008D;\n\tv446 = this.m_activeKeys;\n\tv353 = this.m_activeKeys == 0;\n\tif (v353) goto L_0087;\n\tv371 = v446.Count > 0;\n\tif (v371) goto L_0098;\nL_0087:\n\tv384 = this._shopService == 0;\n\tv419 = 0;\n\tif (v384) goto L_0160;\n\tv446 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetActiveGroupKeys(this._shopService);\n\tv419 = 0;\n\tgoto L_0092;\nL_008D:\n\tv355 = this._shopService == 0;\n\tv419 = 0;\n\tif (v355) goto L_0160;\n\tv419 = this.m_layoutId;\n\tv446 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetOrderedGroupKeys(this._shopService, this.m_layoutId);\nL_0092:\n\tv427 = v446 == 0;\n\tif (v427) goto L_0160;\nL_0098:\n\tv453 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v446);\n\tv459 = v453._list;\n\tv161 = v453._list;\n\tv147 = &v472 @ stack_-C8_v6 (System.Collections.Generic.List`1<System.String>);\n\tgoto L_00BA;\nL_00B2:\n\tv459 = v472;\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::Add(this._filterEntries, &v459 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>));\nL_00BA:\n\tv516 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v161 @ stack_-A0_v4 (System.Collections.Generic.List`1<System.String>));\n\tv249 = v516 == 0;\n\tif (v249) goto L_0143;\n\tv528 = new Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+<>c__DisplayClass22_0();\n\tSystem.Object::.ctor(v528);\n\tv532 = v528 == 0;\n\tif (v532) goto L_0156;\n\tv528.<>4__this = this;\n\tv540 = this._shopService == 0;\n\tif (v540) goto L_0158;\n\tv543 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetGroupConfig(this._shopService, v453.Current);\n\tv557 = v543 == 0;\n\tif (v557) goto L_0152;\n\tv558 = this._instantiatedGroupViews == 0;\n\tif (v558) goto L_0154;\n\tv503 = System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>::ContainsKey(this._instantiatedGroupViews, v543.groupKey);\n\tv507 = v503 == 0;\n\tif (v507) goto L_00BA;\n\tgoto L_00EC;\nL_00EC:\n\tv580 = UnityEngine.Object::Instantiate(this.m_filterPrefab, this.m_filterContainer);\n\tv528.groupId = v543.groupKey;\n\tv588 = new System.Action();\n\tSystem.Action::.ctor(v588, v528, Il2CppMethodInfo);\n\tv556 = v580 == 0;\n\tif (v556) goto L_015E;\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController::Init(v580, v543.groupVisualName, v588);\n\tv593 = UnityEngine.Component::get_gameObject(v580);\n\tv560 = v593 == 0;\n\tif (v560) goto L_015C;\n\tUnityEngine.GameObject::SetActive(v593, 1);\n\tv512 = this._filterEntries;\n\t*([v147 @ X26_v4+8]) = 0;\n\t*([v147 @ X26_v4+10]) = 0;\n\tv602 = this._filterEntries == 0;\n\tif (v602) goto L_015A;\n\tv607 = v512._version + 1;\n\tv512._version = v607;\n\tv506 = v512._items == 0;\n\tif (v506) goto L_015A;\n\tgoto L_00B2;\nL_0143:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v161 @ stack_-A0_v4 (System.Collections.Generic.List`1<System.String>));\nL_0151:\n\treturn;\nL_0152:\n\tv552 = new System.NullReferenceException();\n\tv419 = v453.Current;\n\tgoto L_015F;\nL_0154:\n\tv553 = new System.NullReferenceException();\n\tv419 = v453.Current;\n\tgoto L_015F;\nL_0156:\n\tthrow v528;\nL_0158:\n\tv544 = new System.NullReferenceException();\n\tv419 = this;\n\tgoto L_015F;\nL_015A:\n\tv554 = new System.NullReferenceException();\n\tv419 = v580;\n\tgoto L_015F;\nL_015C:\n\tv555 = new System.NullReferenceException();\n\tv419 = 0;\n\tgoto L_015F;\nL_015E:\n\tthrow v588;\nL_015F:\n\t// 351 Interrupt\n\tv155 = 0;\nL_017B:\n\tv197 = v419 != 1;\n\tif (v197) goto L_018C;\n\tv517 = 0x8BF5BC4(v432, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv524 = 0x8BF5BF4(v517, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v161 @ stack_-A0_v4 (System.Collections.Generic.List`1<System.String>));\n\tv252 = *([v517 @ X0_v17]) == 0;\n\tif (v252) goto L_0151;\n\tv519 = new System.OutOfMemoryException();\n\tv155 = *([v517 @ X0_v17]);\n\tv432 = v519;\nL_018C:\n\tv522 = 0x3173CEC(&v155 @ stack_-B0 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv526 = 0x8BF0368(v432, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv321 = 0xA1B8(v526, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0044:\n\tgoto L_0047;\nL_0160:\n\tv432 = new System.NullReferenceException();\n\tgoto L_017B;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void BuildFilters()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupViewController::BuildFilters");
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x3C6A32C", Offset = "0x3C6A32C", Length = "0x264")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv72 = &v73 @ stack_-C8 (System.Int32);\n\tv74 = System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::GetEnumerator(this._filterEntries);\n\tv80 = v73.m_value;\n\tv181 = *([v72 @ X8_v7+20]) & 1;\n\tv143 = v181 == 0;\n\tif (v143) goto L_005C;\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController::Select(this, *([v72 @ X8_v7+10]));\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::Dispose(&v80 @ stack_-70_v4 (System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>));\nL_0073:\n\treturn;\nL_0076:\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::Dispose(&v80 @ stack_-70_v4 (System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>));\n\tv123 = this._instantiatedGroupViews == 0;\n\tv73 = 0;\n\tif (v123) goto L_00A0;\n\tv200 = System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>::GetEnumerator(this._instantiatedGroupViews);\n\tv255 = v200._dictionary;\n\tv269 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v255 @ stack_-A0_v2 (System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>));\n\tv327 = v269 == 0;\n\tif (v327) goto L_0095;\n\tSystems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController::Select(this, *([v200 @ X0_v24 (System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>+Enumerator<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>)+10]));\nL_0095:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v255 @ stack_-A0_v2 (System.Collections.Generic.Dictionary`2<System.String, Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView>));\n\treturn;\nL_00A0:\n\tv127 = new System.NullReferenceException();\n\tgoto L_00AD;\nL_00AD:\n\tv156 = Il2CppMethodInfo != 1;\n\tv172 = v127;\n\tif (v156) goto L_00BD;\n\tv163 = 0x8BF5BC4(v127, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv183 = 0x8BF5BF4(v163, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v80 @ stack_-70_v4 (System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>));\n\tv171 = *([v163 @ X0_v12]) == 0;\n\tif (v171) goto L_0073;\n\tv169 = new System.OutOfMemoryException();\n\tv73 = *([v163 @ X0_v12]);\n\tv172 = v169;\nL_00DB:\n\tv191 = 0x8BF0368(v172, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv201 = 0xA1B8(v191, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0036:\n\tv55 = this._filterEntries == 0;\n\tif (v55) goto L_00A0;\nL_005C:\n\tv141 = System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::MoveNext(&v80 @ stack_-70_v4 (System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>));\n\tv161 = v141 == 0;\n\tif (v161) goto L_0076;\nL_00BD:\n\tv177 = 0x3179954(&v73 @ stack_-C8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00DB;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void SelectFirstEnabled()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupViewController::SelectFirstEnabled");
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x3C6A66C", Offset = "0x3C6A66C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv69 = System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::GetEnumerator(this._filterEntries);\n\tv167 = v69;\n\tv150 = v69._current.Filter;\n\tv265 = System.String::op_Equality(v69.Current, this.ActivePackId);\n\tv347 = v265 == 0;\n\tv404 = ~v347;\n\tv405 = ~v404;\n\tif (v405) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv409 = 0x2C;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv409 = 0x3C;\nL_FFFFFFFF:\n\tv416 = 0x28;\n\tgoto L_0073;\nL_FFFFFFFF:\n\tv416 = 0x38;\nL_FFFFFFFF:\n\tv339 = 0x24;\n\tgoto L_007A;\nL_FFFFFFFF:\n\tv339 = 0x34;\nL_FFFFFFFF:\n\tv426 = 0x20;\n\tgoto L_0086;\nL_FFFFFFFF:\n\tv426 = 0x30;\n\tv211 = v265 == 0;\n\tv430 = ~v211;\n\tv431 = ~v430;\n\tif (v431) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv434 = 0x54;\n\tgoto L_009F;\nL_FFFFFFFF:\n\tv434 = 0x64;\nL_FFFFFFFF:\n\tv439 = 0x50;\n\tgoto L_00A6;\nL_FFFFFFFF:\n\tv439 = 0x60;\nL_FFFFFFFF:\n\tv195 = 0x4C;\n\tgoto L_00AD;\nL_FFFFFFFF:\n\tv195 = 0x5C;\nL_FFFFFFFF:\n\tv446 = 0x48;\n\tgoto L_00B7;\nL_FFFFFFFF:\n\tv446 = 0x58;\nL_00C1:\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::Dispose(&v167 @ stack_-90_v4 (System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>));\nL_00CF:\n\treturn;\nL_00DE:\n\tv244 = v168 != 1;\n\tif (v244) goto L_00EF;\n\tv247 = 0x8BF5BC4(v178, v168, 0, v38, v39, v40, v41, v42, v79, v70, v72, v74, v47, v48, v49, v50);\n\tv270 = 0x8BF5BF4(v247, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::Dispose(&v57 @ stack_-90_v1 (System.Int32));\n\tv255 = *([v247 @ X0_v11]) == 0;\n\tif (v255) goto L_00CF;\n\tv253 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv138 = *([v247 @ X0_v11]);\nL_FFFFFFFF:\n\tv178 = v253;\nL_00EF:\n\tv262 = 0x3179914(&v138 @ stack_-A0_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv272 = 0x8BF0368(v178, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv332 = 0xA1B8(v272, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0025:\n\tv57 = 0;\n\tv60 = this._filterEntries == 0;\nL_FFFFFFFF:\n\tv138 = 0;\n\tif (v60) goto L_00D2;\nL_006A:\n\tv412 = ~v347;\n\tv413 = ~v412;\n\tif (v413) goto L_FFFFFFFF;\nL_0073:\n\tv418 = ~v347;\n\tv419 = ~v418;\n\tif (v419) goto L_FFFFFFFF;\nL_007A:\n\t;\n\tv341 = ~v347;\n\tv340 = ~v341;\n\tif (v340) goto L_FFFFFFFF;\nL_0086:\n\t;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v6 (UnityEngine.Color), typeof(UnityEngine.Color), [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v426 @ X8_v20 (System.Int32)], [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v339 @ X10_v7 (System.Int32)], [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v416 @ X9_v7 (System.Int32)], [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v409 @ X8_v18 (System.Int32)]\n\tv427 = UnityEngine.UI.Graphic::set_color(v150.m_bgImage, Color_arg);\nL_009F:\n\tv435 = ~v211;\n\tv436 = ~v435;\n\tif (v436) goto L_FFFFFFFF;\nL_00A6:\n\tv440 = ~v211;\n\tv441 = ~v440;\n\tif (v441) goto L_FFFFFFFF;\nL_00AD:\n\t;\n\tv199 = ~v211;\n\tv197 = ~v199;\n\tif (v197) goto L_FFFFFFFF;\nL_00B7:\n\t;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v446 @ X8_v24 (System.Int32)], [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v195 @ X10_v8 (System.Int32)], [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v439 @ X9_v10 (System.Int32)], [v150 @ stack_-78_v3 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v434 @ X8_v23 (System.Int32)]\n\tv223 = TMPro.TMP_Text::set_color(v150.m_text, Color_arg);\n\tgoto L_0047;\nL_00D2:\n\tv178 = new System.NullReferenceException();\n\tgoto L_00DE;\nL_0047:\n\tv234 = System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::MoveNext(&v167 @ stack_-90_v4 (System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>+Enumerator<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>));\n\tv246 = v234 == 0;\n\tif (v246) goto L_00C1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void UpdateFilterVisuals()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupViewController::UpdateFilterVisuals");
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x3C6ADB8", Offset = "0x3C6ADB8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		private bool IsFeatureEnabled(FeatureType featureType)
		{
			return true;
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x3C6ADD4", Offset = "0x3C6ADD4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>();\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupViewController+FilterEntry>::.ctor(v48);\n\tthis._filterEntries = v48;\n")]
		public ShopGroupViewController()
		{
			List<FilterEntry> filterEntries = new List<FilterEntry>();
			_filterEntries = filterEntries;
		}
	}
}
