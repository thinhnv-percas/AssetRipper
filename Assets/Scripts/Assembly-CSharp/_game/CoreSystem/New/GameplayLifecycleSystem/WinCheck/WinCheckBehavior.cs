using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003EB")]
	public class WinCheckBehavior : IStateBehavior, IDisposable
	{
		[Token(Token = "0x4000C6F")]
		private const float CheckInterval = 1.25f;

		[Inject(false)]
		[Token(Token = "0x4000C70")]
		[FieldOffset(Offset = "0x10")]
		private IWinCheckSuppressor _suppressor;

		[Inject(false)]
		[Token(Token = "0x4000C71")]
		[FieldOffset(Offset = "0x18")]
		private WinDetector _detector;

		[Inject(false)]
		[Token(Token = "0x4000C72")]
		[FieldOffset(Offset = "0x20")]
		private IBaseLayerWinService _winService;

		[Token(Token = "0x4000C73")]
		[FieldOffset(Offset = "0x28")]
		private bool _won;

		[Token(Token = "0x4000C74")]
		[FieldOffset(Offset = "0x2C")]
		private float _checkAccumulator;

		[Token(Token = "0x1700014F")]
		[field: Token(Token = "0x4000C75")]
		[field: FieldOffset(Offset = "0x30")]
		public float LastEvaluationUnscaledTime
		{
			[Token(Token = "0x600107C")]
			[Address(RVA = "0x3CB4698", Offset = "0x3CB4698", Length = "0x8")]
			get;
			[Token(Token = "0x600107D")]
			[Address(RVA = "0x3CB46A0", Offset = "0x3CB46A0", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000150")]
		public bool Won
		{
			[Token(Token = "0x600107E")]
			[Address(RVA = "0x3CB46A8", Offset = "0x3CB46A8", Length = "0x8")]
			get
			{
				return _won;
			}
		}

		[Token(Token = "0x600107F")]
		[Address(RVA = "0x3CB46B0", Offset = "0x3CB46B0", Length = "0x30")]
		public void OnStateEnter()
		{
			_won = false;
			_checkAccumulator = 0f;
			float unscaledTime = Time.unscaledTime;
			LastEvaluationUnscaledTime = unscaledTime;
		}

		[Token(Token = "0x6001080")]
		[Address(RVA = "0x3CB46E0", Offset = "0x3CB46E0", Length = "0x4")]
		public void OnStateExit()
		{
		}

		[Token(Token = "0x6001081")]
		[Address(RVA = "0x3CB46E4", Offset = "0x3CB46E4", Length = "0x120")]
		public void OnStateUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinCheckBehavior::OnStateUpdate");
		}

		[Token(Token = "0x6001082")]
		[Address(RVA = "0x3CB4AD4", Offset = "0x3CB4AD4", Length = "0x4")]
		public void Dispose()
		{
		}

		[Token(Token = "0x6001083")]
		[Address(RVA = "0x3CB4AD8", Offset = "0x3CB4AD8", Length = "0x8")]
		public WinCheckBehavior()
		{
		}
	}
}
