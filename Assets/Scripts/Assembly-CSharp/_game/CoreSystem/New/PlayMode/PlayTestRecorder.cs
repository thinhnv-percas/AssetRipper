using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.Events;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.PlayReport;
using _game.CoreSystem.New.LevelGeneratorSystem.Report;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E4")]
	public sealed class PlayTestRecorder : IDisposable
	{
		[Token(Token = "0x4000C53")]
		[FieldOffset(Offset = "0x10")]
		private readonly LevelPlayMode _mode;

		[Token(Token = "0x4000C54")]
		[FieldOffset(Offset = "0x18")]
		private readonly string _levelId;

		[Token(Token = "0x4000C55")]
		[FieldOffset(Offset = "0x20")]
		private readonly string _reportDir;

		[Token(Token = "0x4000C56")]
		[FieldOffset(Offset = "0x28")]
		private readonly string _reportHtmlPath;

		[Token(Token = "0x4000C57")]
		[FieldOffset(Offset = "0x30")]
		internal readonly IReadOnlyList<(int x, int y, string color)> _intended;

		[Token(Token = "0x4000C58")]
		[FieldOffset(Offset = "0x38")]
		internal readonly AutoTapSequencer _seq;

		[Inject(false)]
		[Token(Token = "0x4000C59")]
		[FieldOffset(Offset = "0x40")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000C5A")]
		[FieldOffset(Offset = "0x48")]
		private TopGridHandler _grid;

		[Inject(true)]
		[Token(Token = "0x4000C5B")]
		[FieldOffset(Offset = "0x50")]
		private ConveyorController _conveyor;

		[Inject(true)]
		[Token(Token = "0x4000C5C")]
		[FieldOffset(Offset = "0x58")]
		private EventBus _eventBus;

		[Token(Token = "0x4000C5D")]
		[FieldOffset(Offset = "0x60")]
		private readonly List<(int x, int y, string color, int occupancy)> _played;

		[Token(Token = "0x4000C5E")]
		[FieldOffset(Offset = "0x68")]
		private bool _hasPending;

		[Token(Token = "0x4000C5F")]
		[FieldOffset(Offset = "0x70")]
		private (int x, int y, string color) _pendingTap;

		[Token(Token = "0x4000C60")]
		[FieldOffset(Offset = "0x80")]
		internal bool _finished;

		[Token(Token = "0x4000C61")]
		[FieldOffset(Offset = "0x84")]
		private int _capacity;

		[Token(Token = "0x1700014B")]
		public bool HasNextStep
		{
			[Token(Token = "0x6001064")]
			[Address(RVA = "0x3CB15F0", Offset = "0x3CB15F0", Length = "0x20")]
			get
			{
				if (!_finished && _seq != null)
				{
					return _seq.HasNext;
				}
				return false;
			}
		}

		[Token(Token = "0x1700014C")]
		public int NextStepIndex
		{
			[Token(Token = "0x6001065")]
			[Address(RVA = "0x3CB1B2C", Offset = "0x3CB1B2C", Length = "0x18")]
			get
			{
				AutoTapSequencer seq = _seq;
				if (_seq != null)
				{
					return seq.Index;
				}
				return 0;
			}
		}

		[Token(Token = "0x1700014D")]
		public int TotalSteps
		{
			[Token(Token = "0x6001066")]
			[Address(RVA = "0x3CB1A6C", Offset = "0x3CB1A6C", Length = "0xC0")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PlayTestRecorder::get_TotalSteps");
				return default;
			}
		}

		[Token(Token = "0x6001062")]
		[Address(RVA = "0x3CB2BE0", Offset = "0x3CB2BE0", Length = "0x170")]
		public PlayTestRecorder(LevelPlayMode mode, string levelId, string reportDir, string reportHtmlPath, IReadOnlyList<(int x, int y, string color)> intendedPath)
		{
			List<(int, int, string, int)> played = new List<(int, int, string, int)>();
			_played = played;
			_mode = mode;
			_levelId = ((levelId != null) ? levelId : "");
			_reportDir = ((reportDir != null) ? reportDir : "");
			_reportHtmlPath = ((reportHtmlPath != null) ? reportHtmlPath : "");
			_intended = intendedPath;
			bool flag = mode != LevelPlayMode.BasedOnPath;
			AutoTapSequencer seq = null;
			if (!flag)
			{
				AutoTapSequencer autoTapSequencer = new AutoTapSequencer(intendedPath);
				seq = autoTapSequencer;
			}
			_seq = seq;
		}

		[Inject(false)]
		[Token(Token = "0x6001063")]
		[Address(RVA = "0x3CB318C", Offset = "0x3CB318C", Length = "0x138")]
		public void Construct()
		{
			if (_eventBus != null)
			{
				Action<UventLevelCompleted> observer = OnWin;
				_eventBus.ListenEvent(observer);
			}
			if (_mode == LevelPlayMode.Manual && _eventBus != null)
			{
				Action<USandCubeClicked> observer2 = OnManualTap;
				_eventBus.ListenEvent(observer2);
			}
		}

		[Token(Token = "0x6001067")]
		[Address(RVA = "0x3CB32C4", Offset = "0x3CB32C4", Length = "0xE4")]
		private void OnManualTap(USandCubeClicked e)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayTestRecorder::OnManualTap");
		}

		[Token(Token = "0x6001068")]
		[Address(RVA = "0x3CB166C", Offset = "0x3CB166C", Length = "0x270")]
		public void FireStep()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayTestRecorder::FireStep");
		}

		[Token(Token = "0x6001069")]
		[Address(RVA = "0x3CB33A8", Offset = "0x3CB33A8", Length = "0x4C")]
		private void RecordPendingThenSet((int x, int y, string color) tap)
		{
			FlushPending();
			_pendingTap = tap;
			_hasPending = true;
		}

		[Token(Token = "0x600106A")]
		[Address(RVA = "0x3CB33F4", Offset = "0x3CB33F4", Length = "0x224")]
		private unsafe void FlushPending()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayTestRecorder::FlushPending");
		}

		[Token(Token = "0x600106B")]
		[Address(RVA = "0x3CB3618", Offset = "0x3CB3618", Length = "0xCC")]
		private int SampleOccupancy()
		{
			if (_conveyor == null)
			{
				return 0;
			}
			ConveyorController conveyor = _conveyor;
			if (conveyor.MaxParticleCapacity >= 1)
			{
				_capacity = conveyor.MaxParticleCapacity;
			}
			return conveyor.CurrentParticleCount;
		}

		[Token(Token = "0x600106C")]
		[Address(RVA = "0x3CB36E4", Offset = "0x3CB36E4", Length = "0x8")]
		private void OnWin(UventLevelCompleted _)
		{
			Finish(won: true);
		}

		[Token(Token = "0x600106D")]
		[Address(RVA = "0x3CB36EC", Offset = "0x3CB36EC", Length = "0x3BC")]
		private void Finish(bool won)
		{
			if (_finished)
			{
				return;
			}
			_finished = true;
			FlushPending();
			PlayReportModel m = PlayReportBuilder.Build(_mode, _levelId, won, _played, _intended);
			int particleCapacity = _capacity;
			NullReferenceException ex = default(NullReferenceException);
			if (_capacity <= 0)
			{
				if (_conveyor != null)
				{
					ConveyorController conveyor = _conveyor;
					if ((object)_conveyor == null)
					{
						ex = new NullReferenceException();
						goto IL_0361;
					}
					particleCapacity = conveyor.MaxParticleCapacity;
				}
				else
				{
					particleCapacity = 0;
				}
			}
			List<(int, int, string, int)> played = _played;
			if (_played != null)
			{
				int[] array = new int[played.Count];
				List<(int, int, object, int)> played2 = (List<(int, int, object, int)>)(object)_played;
				if (_played != null)
				{
					if (array != null)
					{
						int num = 0;
						while (num < played2.Count)
						{
							(int, int, object, int) tuple = played2[num];
							if ((uint)num < (uint)array.Length)
							{
								array[num] = tuple.Item4;
								num++;
								bool flag = _played == null;
								bool flag2 = !flag;
								played2 = (List<(int, int, object, int)>)(object)_played;
								if (flag2)
								{
									continue;
								}
								goto IL_01cc;
							}
							goto IL_0297;
						}
					}
					else if (played2.Count >= 1)
					{
						(int, int, object, int) tuple2 = _played[0];
						ex = new NullReferenceException();
						goto IL_0361;
					}
					float[] playedPercent = FillCurveData.PlayedPercent(array, particleCapacity);
					string text = PlayReportWriter.ApplyToReport(_reportHtmlPath, m, playedPercent);
					if (text != null)
					{
						string message = "[PlayTestRecorder] Play result merged into report: " + text;
						Debug.Log(message);
					}
					else
					{
						string message2 = "[PlayTestRecorder] No generation report at '" + _reportHtmlPath + "' — play result not persisted.";
						Debug.LogWarning(message2);
					}
					return;
				}
				goto IL_01cc;
			}
			ex = new NullReferenceException();
			goto IL_0361;
			IL_0297:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			goto IL_0361;
			IL_01cc:
			ex = new NullReferenceException();
			goto IL_0361;
			IL_0361:
			throw ex;
		}

		[Token(Token = "0x600106E")]
		[Address(RVA = "0x3CB3AA8", Offset = "0x3CB3AA8", Length = "0x158")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayTestRecorder::Dispose");
		}
	}
}
