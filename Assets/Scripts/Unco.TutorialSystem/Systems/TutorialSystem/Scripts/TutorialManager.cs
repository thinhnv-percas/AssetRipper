using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;

namespace Systems.TutorialSystem.Scripts
{
	[Token(Token = "0x2000011")]
	public class TutorialManager
	{
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x10")]
		private TutorialBaseSo _activeTutorialBase;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x18")]
		private TutorialData _activeTutorialData;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x20")]
		private TutorialType _activeTutorialType;

		[CompilerGenerated]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x28")]
		private Action<TutorialType> OnTutorialStarted;

		[CompilerGenerated]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x30")]
		private Action<TutorialType, int> OnTutorialStepCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x38")]
		private Action<TutorialType> OnTutorialEnded;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x40")]
		private Action _activeTutorialEndAction;

		[Inject(false)]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x48")]
		private Instancer _instancer;

		[Token(Token = "0x1700000D")]
		public bool TutorialActive
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x81E05B0", Offset = "0x81E05B0", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = UnityEngine.Object::op_Inequality(this._activeTutorialBase, 0);\n\tv63 = ~returnVal1;\n\tv64 = ~v63;\n\tif (v64) goto L_0039;\n\treturn returnVal1;\nL_0039:\n\tv136 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetActiveTutorialData(this._activeTutorialBase);\n\tv107 = v136 == 0;\n\tv92 = ~v107;\n\treturn v92;\n")]
			get
			{
				bool flag = _activeTutorialBase != null;
				if (!flag)
				{
					return flag;
				}
				TutorialData activeTutorialData = _activeTutorialBase.GetActiveTutorialData();
				bool flag2 = activeTutorialData == null;
				return !flag2;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6000053")]
		[Address(RVA = "0x81E0670", Offset = "0x81E0670", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnTutorialStarted;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnTutorialStarted (System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnTutorialStarted(Action<TutorialType> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::add_OnTutorialStarted");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000054")]
		[Address(RVA = "0x81E0724", Offset = "0x81E0724", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnTutorialStarted;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnTutorialStarted (System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnTutorialStarted(Action<TutorialType> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::remove_OnTutorialStarted");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000055")]
		[Address(RVA = "0x81E07D8", Offset = "0x81E07D8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<Systems.TutorialSystem.Scripts.TutorialType, System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnTutorialStepCompleted;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnTutorialStepCompleted (System.Action`2<Systems.TutorialSystem.Scripts.TutorialType, System.Int32>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnTutorialStepCompleted(Action<TutorialType, int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::add_OnTutorialStepCompleted");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000056")]
		[Address(RVA = "0x81E088C", Offset = "0x81E088C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<Systems.TutorialSystem.Scripts.TutorialType, System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnTutorialStepCompleted;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnTutorialStepCompleted (System.Action`2<Systems.TutorialSystem.Scripts.TutorialType, System.Int32>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnTutorialStepCompleted(Action<TutorialType, int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::remove_OnTutorialStepCompleted");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000057")]
		[Address(RVA = "0x81E0940", Offset = "0x81E0940", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnTutorialEnded;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnTutorialEnded (System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnTutorialEnded(Action<TutorialType> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::add_OnTutorialEnded");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000058")]
		[Address(RVA = "0x81E09F4", Offset = "0x81E09F4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnTutorialEnded;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnTutorialEnded (System.Action`1<Systems.TutorialSystem.Scripts.TutorialType>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnTutorialEnded(Action<TutorialType> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::remove_OnTutorialEnded");
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x81E0AA8", Offset = "0x81E0AA8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tv55 = Unco.ContainerSystem.Runtime.Instancer::InjectInstance(this._instancer, so);\n\tv66 = ~reset;\n\tif (v66) goto L_0030;\n\tSystems.TutorialSystem.Scripts.TutorialBaseSo::SetActiveIndex(so, 0);\n\tthis._activeTutorialBase = so;\n\tgoto L_0036;\nL_0030:\n\tthis._activeTutorialBase = so;\nL_0036:\n\tthis._activeTutorialType = so.TutorialType;\n\tthis._activeTutorialEndAction = onTutorialEnd;\n\tSystems.TutorialSystem.Scripts.TutorialManager::ContinueTutorial(this);\n\tv86 = this.OnTutorialStarted == 0;\n\tif (v86) goto L_0058;\n\tSystem.Action`1<Systems.TutorialSystem.Scripts.TutorialType>::Invoke(this.OnTutorialStarted, so.TutorialType);\n\treturn;\nL_0058:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StartTutorial(TutorialBaseSo so, bool reset, Action onTutorialEnd = null)
		{
			TutorialBaseSo tutorialBaseSo = _instancer.InjectInstance(so);
			if (reset)
			{
				so.SetActiveIndex(0);
				_activeTutorialBase = so;
			}
			else
			{
				_activeTutorialBase = so;
			}
			_activeTutorialType = so.TutorialType;
			_activeTutorialEndAction = onTutorialEnd;
			ContinueTutorial();
			if (OnTutorialStarted != null)
			{
				OnTutorialStarted(so.TutorialType);
			}
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x81E0CA0", Offset = "0x81E0CA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void SendStartEvent(TutorialBaseSo so)
		{
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x81E0CA4", Offset = "0x81E0CA4", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this._activeTutorialBase, 0);\n\tv67 = ~v59;\n\tv68 = ~v67;\n\tif (v68) goto L_0034;\n\tgoto L_00C9;\nL_0034:\n\tv127 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetActiveTutorialData(this._activeTutorialBase);\n\tv133 = v127 == 0;\n\tif (v133) goto L_00C9;\n\tv226 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this._activeTutorialBase);\n\tv227 = this.OnTutorialStepCompleted == 0;\n\tif (v227) goto L_004E;\n\tv236 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this._activeTutorialBase);\n\tSystem.Action`2<Systems.TutorialSystem.Scripts.TutorialType, System.Int32>::Invoke(this.OnTutorialStepCompleted, this._activeTutorialType, v236);\nL_004E:\n\tv238 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this._activeTutorialBase);\n\tv166 = v238 + 1;\n\tSystems.TutorialSystem.Scripts.TutorialBaseSo::SetActiveIndex(this._activeTutorialBase, v166);\n\tv159 = this._activeTutorialBase;\n\tgoto L_0061;\n\tv88 = v172 < v187.Count;\n\tif (v88) goto L_0076;\n\tthis._activeTutorialType = 0;\nL_0076:\n\tSystems.TutorialSystem.Scripts.TutorialData::Exit(this._activeTutorialData);\n\tgoto L_007F;\nL_007F:\n\tgoto L_0082;\nL_0082:\n\tv273 = UnityEngine.Object::op_Inequality(this._activeTutorialBase, 0);\n\tv283 = ~v273;\n\tv284 = ~v283;\n\tif (v284) goto L_009E;\n\tgoto L_00A4;\nL_009E:\n\tv128 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetActiveTutorialData(this._activeTutorialBase);\n\tv308 = v128 == 0;\n\tv134 = ~v308;\n\tif (v134) goto L_00C9;\nL_00A4:\n\t;\n\tv300 = this._activeTutorialEndAction == 0;\n\tif (v300) goto L_00AB;\n\tSystem.Action::Invoke(this._activeTutorialEndAction);\n\tSystem.Action`1<Systems.TutorialSystem.Scripts.TutorialType>::Invoke(this.OnTutorialEnded, this._activeTutorialType);\n\treturn;\nL_00C9:\n\treturn;\nL_0061:\n\tv172 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this._activeTutorialBase);\n\tv187 = v159.m_TutorialStepList;\nL_00AB:\n\tthis._activeTutorialEndAction = 0;\n\tv135 = this.OnTutorialEnded == 0;\n\tif (v135) goto L_00C9;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StepComplete()
		{
			if (!(_activeTutorialBase != null))
			{
				return;
			}
			TutorialData activeTutorialData = _activeTutorialBase.GetActiveTutorialData();
			if (activeTutorialData == null)
			{
				return;
			}
			int index = _activeTutorialBase.GetIndex();
			if (OnTutorialStepCompleted != null)
			{
				int index2 = _activeTutorialBase.GetIndex();
				OnTutorialStepCompleted(_activeTutorialType, index2);
			}
			int index3 = _activeTutorialBase.GetIndex();
			int activeIndex = index3 + 1;
			_activeTutorialBase.SetActiveIndex(activeIndex);
			TutorialBaseSo activeTutorialBase = _activeTutorialBase;
			int index4 = _activeTutorialBase.GetIndex();
			List<TutorialData> tutorialStepList = activeTutorialBase.m_TutorialStepList;
			if (index4 >= tutorialStepList.Count)
			{
				_activeTutorialType = default(TutorialType);
			}
			_activeTutorialData.Exit();
			if (_activeTutorialBase != null)
			{
				TutorialData activeTutorialData2 = _activeTutorialBase.GetActiveTutorialData();
				if (activeTutorialData2 != null)
				{
					return;
				}
			}
			if (_activeTutorialEndAction != null)
			{
				_activeTutorialEndAction();
			}
			_activeTutorialEndAction = null;
			if (OnTutorialEnded != null)
			{
				OnTutorialEnded(_activeTutorialType);
			}
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x81E0EE8", Offset = "0x81E0EE8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void SendEndEvent(TutorialType type)
		{
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x81E0EE4", Offset = "0x81E0EE4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void SendStepEvent(TutorialType type, int step)
		{
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x81E0BA8", Offset = "0x81E0BA8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv93 = this + 0x10;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this._activeTutorialBase, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0036;\n\tgoto L_004E;\nL_0036:\n\tv88 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetActiveTutorialData(*([v93 @ X20_v2]));\n\tv91 = v88 == 0;\n\tif (v91) goto L_004E;\n\tv131 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetActiveTutorialData(*([v93 @ X20_v2]));\n\tthis._activeTutorialData = v131;\n\tSystems.TutorialSystem.Scripts.TutorialData::Initialize(this._activeTutorialData);\n\treturn;\nL_004E:\n\t*([v93 @ X20_v2]) = 0;\n\treturn;\n")]
		public void ContinueTutorial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialManager::ContinueTutorial");
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x81E0EEC", Offset = "0x81E0EEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._activeTutorialType;\n")]
		public TutorialType GetActiveTutorialType()
		{
			return _activeTutorialType;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x81E0EF4", Offset = "0x81E0EF4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._activeTutorialBase, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0039;\n\treturn 0;\nL_0039:\n\tv89 = this._activeTutorialBase;\n\treturn v89.TutorialType;\n")]
		public TutorialType GetActiveTutorial()
		{
			if (_activeTutorialBase == null)
			{
				return default(TutorialType);
			}
			TutorialBaseSo activeTutorialBase = _activeTutorialBase;
			return activeTutorialBase.TutorialType;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x81E0FB0", Offset = "0x81E0FB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._activeTutorialBase;\n")]
		public TutorialBaseSo GetActiveTutorialBase()
		{
			return _activeTutorialBase;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x81E0FB8", Offset = "0x81E0FB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TutorialManager()
		{
		}
	}
}
