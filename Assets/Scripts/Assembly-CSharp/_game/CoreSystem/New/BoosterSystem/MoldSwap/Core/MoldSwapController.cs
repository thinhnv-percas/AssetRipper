using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Configs;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Core.Data;
using _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Commands;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.SwitchSystem;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Core
{
	[Token(Token = "0x2000486")]
	public class MoldSwapController : MonoBehaviour, IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x2000488")]
		private sealed class _003C_003Ec__DisplayClass35_0
		{
			[Token(Token = "0x4000EBE")]
			[FieldOffset(Offset = "0x10")]
			public EntityId capturedId;

			[Token(Token = "0x4000EBF")]
			[FieldOffset(Offset = "0x18")]
			public MoldSwapController _003C_003E4__this;

			[Token(Token = "0x60012DB")]
			[Address(RVA = "0x3CDC114", Offset = "0x3CDC114", Length = "0x8")]
			public _003C_003Ec__DisplayClass35_0()
			{
			}

			internal void _003CBuildPhase1ArcUp_003Eb__0()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController._003C_003Ec__DisplayClass35_0::_003CBuildPhase1ArcUp_003Eb__0");
			}
		}

		[Inject(false)]
		[Token(Token = "0x4000EA2")]
		[FieldOffset(Offset = "0x20")]
		private MoldSwapConfigSO _config;

		[Inject(false)]
		[Token(Token = "0x4000EA3")]
		[FieldOffset(Offset = "0x28")]
		private MoldSwapScorer _scorer;

		[Inject(false)]
		[Token(Token = "0x4000EA4")]
		[FieldOffset(Offset = "0x30")]
		private MoldSwapAnimator _animator;

		[Inject(false)]
		[Token(Token = "0x4000EA5")]
		[FieldOffset(Offset = "0x38")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000EA6")]
		[FieldOffset(Offset = "0x40")]
		private MoldGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x4000EA7")]
		[FieldOffset(Offset = "0x48")]
		private MoldFillHandler _fillHandler;

		[Inject(false)]
		[Token(Token = "0x4000EA8")]
		[FieldOffset(Offset = "0x50")]
		private MoldLinkedHandler _linkedHandler;

		[Inject(true)]
		[Token(Token = "0x4000EA9")]
		[FieldOffset(Offset = "0x58")]
		private MoldLinkVisualController _linkVisual;

		[Inject(false)]
		[Token(Token = "0x4000EAA")]
		[FieldOffset(Offset = "0x60")]
		private MoldVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000EAB")]
		[FieldOffset(Offset = "0x68")]
		private MoldVisualCmdProcessor _cmdProcessor;

		[Inject(false)]
		[Token(Token = "0x4000EAC")]
		[FieldOffset(Offset = "0x70")]
		private MoldAbsorptionBridge _absorptionBridge;

		[Inject(false)]
		[Token(Token = "0x4000EAD")]
		[FieldOffset(Offset = "0x78")]
		private SandParticleQueries _particleQueries;

		[Inject(true)]
		[Token(Token = "0x4000EAE")]
		[FieldOffset(Offset = "0x80")]
		private IWinCheckSuppressor _winSuppressor;

		[Inject(true)]
		[Token(Token = "0x4000EAF")]
		[FieldOffset(Offset = "0x88")]
		private IFailCheckSuppressor _failSuppressor;

		[Inject(true)]
		[Token(Token = "0x4000EB0")]
		[FieldOffset(Offset = "0x90")]
		private GameplaySoundController _soundController;

		[CompilerGenerated]
		[Token(Token = "0x4000EB2")]
		[FieldOffset(Offset = "0xA0")]
		internal Action OnCompleted;

		[Token(Token = "0x4000EB3")]
		[FieldOffset(Offset = "0xA8")]
		private SpriteRenderer _backdrop;

		[Token(Token = "0x4000EB4")]
		[FieldOffset(Offset = "0xB0")]
		private readonly Dictionary<int, Vector3> _originalScales;

		[Token(Token = "0x4000EB5")]
		[FieldOffset(Offset = "0xB8")]
		private Sequence _activeMaster;

		[Token(Token = "0x4000EB6")]
		[FieldOffset(Offset = "0xC8")]
		private Sequence _activeArcDown;

		[Token(Token = "0x4000EB7")]
		[FieldOffset(Offset = "0xD8")]
		private IDisposable _activeAbsorptionLock;

		[Token(Token = "0x4000EB8")]
		[FieldOffset(Offset = "0xE0")]
		private IDisposable _activeWinSuppress;

		[Token(Token = "0x4000EB9")]
		[FieldOffset(Offset = "0xE8")]
		private IDisposable _activeFailSuppress;

		[Token(Token = "0x4000EBA")]
		[FieldOffset(Offset = "0xF0")]
		private bool _disposed;

		[Token(Token = "0x1700019F")]
		[field: Token(Token = "0x4000EB1")]
		[field: FieldOffset(Offset = "0x98")]
		public bool IsExecuting
		{
			[Token(Token = "0x60012BB")]
			[Address(RVA = "0x3CD98CC", Offset = "0x3CD98CC", Length = "0x8")]
			get;
			[Token(Token = "0x60012BC")]
			[Address(RVA = "0x3CD98D4", Offset = "0x3CD98D4", Length = "0x8")]
			private set;
		}

		[CompilerGenerated]
		[Token(Token = "0x60012BD")]
		[Address(RVA = "0x3CD8904", Offset = "0x3CD8904", Length = "0xA4")]
		public void add_OnCompleted(Action value)
		{
			Action action = OnCompleted;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnCompleted, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60012BE")]
		[Address(RVA = "0x3CD8B8C", Offset = "0x3CD8B8C", Length = "0xA4")]
		public void remove_OnCompleted(Action value)
		{
			Action action = OnCompleted;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnCompleted, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x60012BF")]
		[Address(RVA = "0x3CD8D78", Offset = "0x3CD8D78", Length = "0xA78")]
		public bool Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::Execute");
			return default;
		}

		[Token(Token = "0x60012C0")]
		[Address(RVA = "0x3CDB814", Offset = "0x3CDB814", Length = "0x498")]
		public void ExecuteInstant()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::ExecuteInstant");
		}

		[Inject(false)]
		[Token(Token = "0x60012C1")]
		[Address(RVA = "0x3CDBE10", Offset = "0x3CDBE10", Length = "0x8")]
		private void Construct()
		{
			_disposed = false;
		}

		[Token(Token = "0x60012C2")]
		[Address(RVA = "0x3CDBE18", Offset = "0x3CDBE18", Length = "0x158")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::Dispose");
		}

		[Token(Token = "0x60012C3")]
		[Address(RVA = "0x3CDC110", Offset = "0x3CDC110", Length = "0x4")]
		private void OnDestroy()
		{
			Dispose();
		}

		[Token(Token = "0x60012C4")]
		[Address(RVA = "0x3CDB064", Offset = "0x3CDB064", Length = "0x384")]
		private void BuildPhase1ArcUp(Sequence master, List<EntityId> allIds, List<Vector3> showcasePositions, float showcaseScale)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::BuildPhase1ArcUp");
		}

		[Token(Token = "0x60012C5")]
		[Address(RVA = "0x3CDB3E8", Offset = "0x3CDB3E8", Length = "0x42C")]
		private void BuildPhase2ShowcaseSwap(Sequence master, SwapPlan plan, List<EntityId> allIds, List<Vector3> showcasePositions)
		{
			//IL_0598: Expected I4, but got I8
			//IL_010b: Expected I4, but got I8
			//IL_05d2: Expected I4, but got I8
			//IL_0145: Expected I4, but got I8
			int num = 0;
			List<SwapEntry> list;
			if (allIds != null)
			{
				List<SwapEntry> swaps = plan.Swaps;
				if (showcasePositions != null)
				{
					int num2 = 0;
					int num3 = 0;
					Sequence sequence3 = default(Sequence);
					Sequence sequence6 = default(Sequence);
					Sequence sequence9 = default(Sequence);
					Sequence sequence12 = default(Sequence);
					while (num2 < swaps.Count)
					{
						SwapEntry swapEntry = swaps[num2];
						int num4 = allIds.IndexOf(swapEntry.frontId);
						int num5 = allIds.IndexOf(swapEntry.backId);
						if ((int)(num4 & 0x80000000L) == 0 && (int)(num5 & 0x80000000L) == 0)
						{
							int num6 = num4 - showcasePositions.Count;
							bool flag = num6 < 0;
							int num7 = num4 ^ showcasePositions.Count;
							int num8 = num4 ^ num6;
							int num9 = num7 & num8;
							bool flag2 = num9 < 0;
							bool flag4;
							if (flag != flag2)
							{
								bool flag3 = (uint)num5 < (uint)showcasePositions.Count;
								flag4 = !flag3;
							}
							else
							{
								flag4 = true;
							}
							if (!flag4)
							{
								Sequence sequence = Sequence.Create();
								CycleMode cycleMode = default(CycleMode);
								if (num2 != 0)
								{
									float duration = (float)num2 * 0.05f;
									Sequence sequence2 = sequence3.ChainDelay(duration);
								}
								Action callback = delegate
								{
									if (_soundController != null)
									{
										_soundController.PlayBoosterSwap();
									}
								};
								Sequence sequence4 = sequence3.ChainCallback(callback);
								Vector3 toLocalPos = showcasePositions[num5];
								MoldSwapConfigSO config = _config;
								TweenSettings showcaseSwapX = config.showcaseSwapX;
								TweenSettings showcaseSwapY = config.showcaseSwapY;
								TweenSettings showcaseSwapZ = config.showcaseSwapZ;
								Sequence sequence5 = _animator.PlaySwapArc(swapEntry.frontId, toLocalPos, showcaseSwapX, showcaseSwapY, showcaseSwapZ);
								if (sequence6.isAlive)
								{
									Sequence sequence7 = sequence3.Chain(sequence6);
								}
								Vector3 toLocalPos2 = showcasePositions[num4];
								MoldSwapConfigSO config2 = _config;
								TweenSettings showcaseSwapX2 = config2.showcaseSwapX;
								showcaseSwapY = config2.showcaseSwapY;
								showcaseSwapZ = config2.showcaseSwapZ;
								Sequence sequence8 = _animator.PlaySwapArc(swapEntry.backId, toLocalPos2, showcaseSwapX2, showcaseSwapY, showcaseSwapZ);
								if (sequence9.isAlive)
								{
									Sequence sequence10 = sequence3.Group(sequence9);
								}
								Sequence sequence11 = master;
								if (sequence12.isAlive)
								{
									if (num3 != 0)
									{
										Sequence sequence13 = sequence11.Group(sequence12);
									}
									else
									{
										Sequence sequence14 = sequence11.Chain(sequence12);
										num3 = 1;
									}
								}
							}
						}
						num2++;
						swaps = plan.Swaps;
					}
					return;
				}
				int num10 = 0;
				while (true)
				{
					if (num10 >= swaps.Count)
					{
						return;
					}
					SwapEntry swapEntry2 = swaps[num10];
					int num11 = allIds.IndexOf(swapEntry2.frontId);
					int num12 = allIds.IndexOf(swapEntry2.backId);
					if ((int)(num11 & 0x80000000L) != 0 || (int)(num12 & 0x80000000L) != 0)
					{
						num10++;
						swaps = plan.Swaps;
						continue;
					}
					break;
				}
				NullReferenceException ex = new NullReferenceException();
				list = (List<SwapEntry>)(object)ex;
			}
			else
			{
				list = plan.Swaps;
				if (list.Count < 1)
				{
					return;
				}
			}
			SwapEntry swapEntry3 = list[0];
			throw new NullReferenceException();
		}

		[Token(Token = "0x60012C6")]
		[Address(RVA = "0x3CDC18C", Offset = "0x3CDC18C", Length = "0x750")]
		private unsafe void CommitDataAndStartArcDown(SwapPlan plan, List<EntityId> allIds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::CommitDataAndStartArcDown");
		}

		[Token(Token = "0x60012C7")]
		[Address(RVA = "0x3CDC8E4", Offset = "0x3CDC8E4", Length = "0x3FC")]
		private unsafe void Finalize(SwapPlan plan, List<EntityId> allIds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::Finalize");
		}

		[Token(Token = "0x60012C8")]
		[Address(RVA = "0x3CDBF70", Offset = "0x3CDBF70", Length = "0x1A0")]
		private void ReleaseExecutionHandles()
		{
			if (_activeFailSuppress != null)
			{
				_activeFailSuppress.Dispose();
			}
			_activeFailSuppress = null;
			if (_activeWinSuppress != null)
			{
				_activeWinSuppress.Dispose();
			}
			_activeWinSuppress = null;
			if (_activeAbsorptionLock != null)
			{
				_activeAbsorptionLock.Dispose();
			}
			_activeAbsorptionLock = null;
		}

		[Token(Token = "0x60012C9")]
		[Address(RVA = "0x3CDA2FC", Offset = "0x3CDA2FC", Length = "0x294")]
		private void BreakParticipantLinks(SwapPlan plan)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::BreakParticipantLinks");
		}

		[Token(Token = "0x60012CA")]
		[Address(RVA = "0x3CDA590", Offset = "0x3CDA590", Length = "0x554")]
		private void MarkInSwap(EntityId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::MarkInSwap");
		}

		[Token(Token = "0x60012CB")]
		[Address(RVA = "0x3CDCCE0", Offset = "0x3CDCCE0", Length = "0xD0")]
		private void ClearInSwap(EntityId id)
		{
			EntityId id2 = default(EntityId);
			Entity entity = _em.GetEntity(id2);
			if (_em.IsValid(entity) && _em.HasComponent<MoldInSwapTag>(entity))
			{
				_em.RemoveComponent<MoldInSwapTag>(entity);
			}
		}

		[Token(Token = "0x60012CC")]
		[Address(RVA = "0x3CDBCAC", Offset = "0x3CDBCAC", Length = "0x164")]
		private void SnapEntityTransformToVisualGrid(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::SnapEntityTransformToVisualGrid");
		}

		[Token(Token = "0x60012CD")]
		[Address(RVA = "0x3CDCF34", Offset = "0x3CDCF34", Length = "0x3B8")]
		private Entity FindVisualGridCell(int col, int row)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::FindVisualGridCell");
			return default;
		}

		[Token(Token = "0x60012CE")]
		[Address(RVA = "0x3CDAAE4", Offset = "0x3CDAAE4", Length = "0x2FC")]
		private List<Vector3> CalculateShowcasePositions(int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::CalculateShowcasePositions");
			return default;
		}

		[Token(Token = "0x60012CF")]
		[Address(RVA = "0x3CDADE0", Offset = "0x3CDADE0", Length = "0x1EC")]
		private float CalculateShowcaseScale(int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::CalculateShowcaseScale");
			return default;
		}

		[Token(Token = "0x60012D0")]
		[Address(RVA = "0x3CDD2EC", Offset = "0x3CDD2EC", Length = "0x1A8")]
		private float ResolveMoldCellWidth()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::ResolveMoldCellWidth");
			return default;
		}

		[Token(Token = "0x60012D1")]
		[Address(RVA = "0x3CDD494", Offset = "0x3CDD494", Length = "0x224")]
		private void EnsureBackdrop()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapController::EnsureBackdrop");
		}

		[Token(Token = "0x60012D2")]
		[Address(RVA = "0x3CDAFCC", Offset = "0x3CDAFCC", Length = "0x98")]
		private void FadeBackdropIn()
		{
			EnsureBackdrop();
			GameObject gameObject = _backdrop.gameObject;
			gameObject.SetActive(value: true);
			Color color = default(Color);
			color.r = 0f;
			color.g = 0f;
			color.b = 0f;
			color.a = 0f;
			_backdrop.color = color;
			MoldSwapConfigSO config = _config;
			TweenSettings backdropFadeIn = config.backdropFadeIn;
			Tween tween = Tween.Alpha(_backdrop, config.backdropMaxAlpha, backdropFadeIn);
		}

		[Token(Token = "0x60012D3")]
		[Address(RVA = "0x3CDCDB0", Offset = "0x3CDCDB0", Length = "0x184")]
		private void FadeBackdropOut()
		{
			if (_backdrop == null)
			{
				return;
			}
			MoldSwapConfigSO config = _config;
			TweenSettings backdropFadeOut = config.backdropFadeOut;
			Tween tween = Tween.Alpha(_backdrop, 0f, backdropFadeOut);
			Tween tween2 = tween;
			if (tween2.isAlive)
			{
				Action onComplete = delegate
				{
					if (_backdrop != null)
					{
						GameObject gameObject2 = _backdrop.gameObject;
						gameObject2.SetActive(value: false);
					}
				};
				Tween tween3 = tween2.OnComplete(onComplete);
			}
			else
			{
				GameObject gameObject = _backdrop.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[Token(Token = "0x60012D4")]
		[Address(RVA = "0x3CDD6B8", Offset = "0x3CDD6B8", Length = "0xB8")]
		private static Sprite CreateWhitePixelSprite()
		{
			Texture2D texture2D = new Texture2D(1, 1);
			Color color = default(Color);
			color.r = 1f;
			color.g = 1f;
			color.b = 1f;
			color.a = 1f;
			texture2D.SetPixel(0, 0, color);
			texture2D.Apply();
			Rect rect = default(Rect);
			rect.x = 0f;
			rect.y = 0f;
			rect.width = 1f;
			rect.height = 1f;
			Vector2 pivot = default(Vector2);
			pivot.x = 0.5f;
			pivot.y = 0.5f;
			return Sprite.Create(texture2D, rect, pivot, 1f);
		}

		[Token(Token = "0x60012D5")]
		[Address(RVA = "0x3CDC11C", Offset = "0x3CDC11C", Length = "0x70")]
		private static void GroupOrChain(Sequence master, Sequence sub, ref bool phaseStarted)
		{
			Sequence sequence = master;
			Sequence sequence2 = default(Sequence);
			if (sequence2.isAlive)
			{
				if (phaseStarted)
				{
					Sequence sequence3 = sequence.Group(sequence2);
					return;
				}
				Sequence sequence4 = sequence.Chain(sequence2);
				phaseStarted = true;
			}
		}

		[Token(Token = "0x60012D6")]
		[Address(RVA = "0x3CDD770", Offset = "0x3CDD770", Length = "0x8C")]
		public MoldSwapController()
		{
			Dictionary<int, Vector3> originalScales = new Dictionary<int, Vector3>();
			_originalScales = originalScales;
		}
	}
}
