using System;
using System.Runtime.CompilerServices;
using Systems.FlowSystem.Scripts.Core;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.States;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.Systems.ElephantStorage;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x20005FD")]
	public abstract class LevelBasedFlowStep : FlowStep, IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x40014A5")]
		[FieldOffset(Offset = "0x28")]
		protected ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x40014A6")]
		[FieldOffset(Offset = "0x30")]
		protected EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40014A7")]
		[FieldOffset(Offset = "0x38")]
		private FlowStorageData _flowData;

		[Inject(false)]
		[Token(Token = "0x40014A8")]
		[FieldOffset(Offset = "0x40")]
		private IPlayerDataHandler _dataHandler;

		[SerializeField]
		[Token(Token = "0x40014A9")]
		[FieldOffset(Offset = "0x48")]
		protected internal Pair<int, int> m_levelRange;

		[SerializeField]
		[Token(Token = "0x40014AA")]
		[FieldOffset(Offset = "0x50")]
		private string m_flowName;

		[SerializeField]
		[Token(Token = "0x40014AB")]
		[FieldOffset(Offset = "0x58")]
		internal bool m_persistCompletion;

		[Token(Token = "0x600199D")]
		[Address(RVA = "0x3D4B238", Offset = "0x3D4B238", Length = "0x14C")]
		public override void InitFlow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelBasedFlowStep::InitFlow");
		}

		[Token(Token = "0x600199E")]
		[Address(RVA = "0x3D4B384", Offset = "0x3D4B384", Length = "0x150")]
		private void OnLevelStarted(UventChapterStateChanged obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelBasedFlowStep::OnLevelStarted");
		}

		[Token(Token = "0x600199F")]
		[Address(RVA = "0x3D4B4D4", Offset = "0x3D4B4D4", Length = "0xF8")]
		protected internal void OnTutorialComplete()
		{
			if (m_persistCompletion)
			{
				FlowStorageData flowData = _flowData;
				flowData.CompletedFlows[m_flowName] = true;
				_dataHandler.Save();
			}
			LevelBasedFlowStep levelBasedFlowStep = default(LevelBasedFlowStep);
			levelBasedFlowStep.Dispose();
		}

		[Token(Token = "0x60019A0")]
		protected abstract void StartTutorial();

		[Token(Token = "0x60019A1")]
		[Address(RVA = "0x3D4B5CC", Offset = "0x3D4B5CC", Length = "0xA8")]
		protected internal virtual void RemoveTutorial()
		{
			Action<UventChapterStateChanged> observer = OnLevelStarted;
			_eventBus.RemoveListener(observer);
		}

		[Token(Token = "0x60019A2")]
		[Address(RVA = "0x3D4B674", Offset = "0x3D4B674", Length = "0x148")]
		public override bool IsFlowCompleted()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelBasedFlowStep::IsFlowCompleted");
			return default;
		}

		[Token(Token = "0x60019A3")]
		[Address(RVA = "0x3D4B7BC", Offset = "0x3D4B7BC", Length = "0xA8")]
		public virtual void Dispose()
		{
			Action<UventChapterStateChanged> observer = OnLevelStarted;
			_eventBus.RemoveListener(observer);
		}

		[Token(Token = "0x60019A4")]
		[Address(RVA = "0x3D4B864", Offset = "0x3D4B864", Length = "0x88")]
		protected internal LevelBasedFlowStep()
		{
			Pair<int, int> levelRange = new Pair<int, int>(0, 10);
			m_levelRange = levelRange;
			m_persistCompletion = true;
		}
	}
}
