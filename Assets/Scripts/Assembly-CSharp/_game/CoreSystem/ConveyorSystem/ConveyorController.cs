using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using PrimeTween;
using TMPro;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using _game.CoreSystem.New.GameplayAreaSystem;

namespace _game.CoreSystem.ConveyorSystem
{
	[Token(Token = "0x200050E")]
	public class ConveyorController : MonoBehaviour, IDifficultyMaterialController
	{
		[SerializeField]
		[Token(Token = "0x40010ED")]
		[FieldOffset(Offset = "0x20")]
		private SplineContainer m_splineContainer;

		[SerializeField]
		[Token(Token = "0x40010EE")]
		[FieldOffset(Offset = "0x28")]
		private float m_beltSpeed;

		[SerializeField]
		[Token(Token = "0x40010EF")]
		[FieldOffset(Offset = "0x2C")]
		private float m_influenceYThreshold;

		[SerializeField]
		[Token(Token = "0x40010F0")]
		[FieldOffset(Offset = "0x30")]
		private float m_beltAcceleration;

		[SerializeField]
		[Token(Token = "0x40010F1")]
		[FieldOffset(Offset = "0x34")]
		private bool m_reverseDirection;

		[SerializeField]
		[Token(Token = "0x40010F2")]
		[FieldOffset(Offset = "0x38")]
		private int m_sampleCount;

		[SerializeField]
		[Token(Token = "0x40010F3")]
		[FieldOffset(Offset = "0x3C")]
		private float m_corridorHalfWidth;

		[SerializeField]
		[Token(Token = "0x40010F4")]
		[FieldOffset(Offset = "0x40")]
		private float m_corridorStrength;

		[SerializeField]
		[Token(Token = "0x40010F5")]
		[FieldOffset(Offset = "0x44")]
		private float m_gateY;

		[SerializeField]
		[Token(Token = "0x40010F6")]
		[FieldOffset(Offset = "0x48")]
		private Vector2 m_gateXRange;

		[SerializeField]
		[Token(Token = "0x40010F7")]
		[FieldOffset(Offset = "0x50")]
		private float m_freezeYThreshold;

		[SerializeField]
		[Token(Token = "0x40010F8")]
		[FieldOffset(Offset = "0x54")]
		private float m_wakeUpYThreshold;

		[SerializeField]
		[Range(0.5f, 1f)]
		[Token(Token = "0x40010F9")]
		[FieldOffset(Offset = "0x58")]
		private float m_reopenRatio;

		[SerializeField]
		[Token(Token = "0x40010FA")]
		[FieldOffset(Offset = "0x60")]
		private GameObject m_gateVisual;

		[SerializeField]
		[Token(Token = "0x40010FB")]
		[FieldOffset(Offset = "0x68")]
		private TweenSettings m_gateScaleSettings;

		[SerializeField]
		[Token(Token = "0x40010FC")]
		[FieldOffset(Offset = "0x98")]
		private ConveyorArrowIndicator m_arrowIndicator;

		[SerializeField]
		[Token(Token = "0x40010FD")]
		[FieldOffset(Offset = "0xA0")]
		private TextMeshPro m_fillText;

		[SerializeField]
		[Token(Token = "0x40010FE")]
		[FieldOffset(Offset = "0xA8")]
		private Color m_normalColor;

		[SerializeField]
		[Token(Token = "0x40010FF")]
		[FieldOffset(Offset = "0xB8")]
		private Color m_warningColor;

		[SerializeField]
		[Range(0f, 1f)]
		[Token(Token = "0x4001100")]
		[FieldOffset(Offset = "0xC8")]
		private float m_warningThreshold;

		[SerializeField]
		[Token(Token = "0x4001101")]
		[FieldOffset(Offset = "0xCC")]
		private float m_textUpdateInterval;

		[SerializeField]
		[Token(Token = "0x4001102")]
		[FieldOffset(Offset = "0xD0")]
		private TweenSettings m_flashSettings;

		[SerializeField]
		[Token(Token = "0x4001103")]
		[FieldOffset(Offset = "0x100")]
		private ShakeSettings m_warningPunchSettings;

		[SerializeField]
		[Token(Token = "0x4001104")]
		[FieldOffset(Offset = "0x140")]
		private int m_capacityMultiplier;

		[Token(Token = "0x4001105")]
		[FieldOffset(Offset = "0x148")]
		private NativeArray<float2> _sampledPoints;

		[Token(Token = "0x4001106")]
		[FieldOffset(Offset = "0x158")]
		private NativeArray<float2> _sampledTangents;

		[Token(Token = "0x4001107")]
		[FieldOffset(Offset = "0x168")]
		private NativeArray<float2> _segmentDirs;

		[Token(Token = "0x4001108")]
		[FieldOffset(Offset = "0x178")]
		private NativeArray<float> _segmentInvLenSq;

		[Token(Token = "0x4001109")]
		[FieldOffset(Offset = "0x188")]
		private bool _initialized;

		[Token(Token = "0x400110A")]
		[FieldOffset(Offset = "0x18C")]
		private int _maxParticleCapacity;

		[Token(Token = "0x400110B")]
		[FieldOffset(Offset = "0x190")]
		private float _splineLength;

		[Token(Token = "0x400110C")]
		[FieldOffset(Offset = "0x194")]
		private bool _isGateClosed;

		[Token(Token = "0x400110D")]
		[FieldOffset(Offset = "0x198")]
		private int _currentParticleCount;

		[Token(Token = "0x400110E")]
		[FieldOffset(Offset = "0x19C")]
		private bool _isWarningActive;

		[Token(Token = "0x400110F")]
		[FieldOffset(Offset = "0x1A0")]
		private Tween _flashTween;

		[Token(Token = "0x4001110")]
		[FieldOffset(Offset = "0x1B0")]
		private Tween _punchTween;

		[Token(Token = "0x4001111")]
		[FieldOffset(Offset = "0x1C0")]
		private Tween _gateScaleTween;

		[Token(Token = "0x4001112")]
		[FieldOffset(Offset = "0x1D0")]
		private int _lastDisplayedPct;

		[Token(Token = "0x4001113")]
		[FieldOffset(Offset = "0x1D4")]
		private float _nextTextUpdateTime;

		[Token(Token = "0x4001114")]
		[FieldOffset(Offset = "0x1D8")]
		private float _beltSpeedMultiplier;

		[CompilerGenerated]
		[Token(Token = "0x4001115")]
		[FieldOffset(Offset = "0x1E0")]
		private Action<int> OnParticleCountChanged;

		[Token(Token = "0x170001CF")]
		public NativeArray<float2> SampledPoints
		{
			[Token(Token = "0x600150A")]
			[Address(RVA = "0x3D0BC4C", Offset = "0x3D0BC4C", Length = "0xC")]
			get
			{
				return _sampledPoints;
			}
		}

		[Token(Token = "0x170001D0")]
		public NativeArray<float2> SampledTangents
		{
			[Token(Token = "0x600150B")]
			[Address(RVA = "0x3D0BC58", Offset = "0x3D0BC58", Length = "0xC")]
			get
			{
				return _sampledTangents;
			}
		}

		[Token(Token = "0x170001D1")]
		public NativeArray<float2> SegmentDirs
		{
			[Token(Token = "0x600150C")]
			[Address(RVA = "0x3D0BC64", Offset = "0x3D0BC64", Length = "0xC")]
			get
			{
				return _segmentDirs;
			}
		}

		[Token(Token = "0x170001D2")]
		public NativeArray<float> SegmentInvLenSq
		{
			[Token(Token = "0x600150D")]
			[Address(RVA = "0x3D0BC70", Offset = "0x3D0BC70", Length = "0xC")]
			get
			{
				return _segmentInvLenSq;
			}
		}

		[Token(Token = "0x170001D3")]
		public int SampleCount
		{
			[Token(Token = "0x600150E")]
			[Address(RVA = "0x3D0BC7C", Offset = "0x3D0BC7C", Length = "0x1C")]
			get
			{
				if (IsInitialized)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.ConveyorSystem.ConveyorController)+150]");
					return 0;
				}
				return 0;
			}
		}

		[Token(Token = "0x170001D4")]
		public float BeltSpeed
		{
			[Token(Token = "0x600150F")]
			[Address(RVA = "0x3D0BC98", Offset = "0x3D0BC98", Length = "0x10")]
			get
			{
				return m_beltSpeed * BeltSpeedMultiplier;
			}
		}

		[Token(Token = "0x170001D5")]
		public float BeltSpeedMultiplier
		{
			[Token(Token = "0x6001510")]
			[Address(RVA = "0x3D0BCA8", Offset = "0x3D0BCA8", Length = "0x8")]
			get
			{
				return _beltSpeedMultiplier;
			}
			[Token(Token = "0x6001511")]
			[Address(RVA = "0x3D0BCB0", Offset = "0x3D0BCB0", Length = "0x8")]
			set
			{
				_beltSpeedMultiplier = value;
			}
		}

		[Token(Token = "0x170001D6")]
		public float InfluenceYThreshold
		{
			[Token(Token = "0x6001512")]
			[Address(RVA = "0x3D0BCB8", Offset = "0x3D0BCB8", Length = "0x8")]
			get
			{
				return m_influenceYThreshold;
			}
		}

		[Token(Token = "0x170001D7")]
		public float BeltAcceleration
		{
			[Token(Token = "0x6001513")]
			[Address(RVA = "0x3D0BCC0", Offset = "0x3D0BCC0", Length = "0x8")]
			get
			{
				return m_beltAcceleration;
			}
		}

		[Token(Token = "0x170001D8")]
		public float CorridorHalfWidth
		{
			[Token(Token = "0x6001514")]
			[Address(RVA = "0x3D0BCC8", Offset = "0x3D0BCC8", Length = "0x8")]
			get
			{
				return m_corridorHalfWidth;
			}
		}

		[Token(Token = "0x170001D9")]
		public float CorridorStrength
		{
			[Token(Token = "0x6001515")]
			[Address(RVA = "0x3D0BCD0", Offset = "0x3D0BCD0", Length = "0x8")]
			get
			{
				return m_corridorStrength;
			}
		}

		[Token(Token = "0x170001DA")]
		public bool IsInitialized
		{
			[Token(Token = "0x6001516")]
			[Address(RVA = "0x3D0BCD8", Offset = "0x3D0BCD8", Length = "0x8")]
			get
			{
				return _initialized;
			}
		}

		[Token(Token = "0x170001DB")]
		public int MaxParticleCapacity
		{
			[Token(Token = "0x6001517")]
			[Address(RVA = "0x3D0BCE0", Offset = "0x3D0BCE0", Length = "0x8")]
			get
			{
				return _maxParticleCapacity;
			}
		}

		[Token(Token = "0x170001DC")]
		public float SplineLength
		{
			[Token(Token = "0x6001518")]
			[Address(RVA = "0x3D0BCE8", Offset = "0x3D0BCE8", Length = "0x8")]
			get
			{
				return _splineLength;
			}
		}

		[Token(Token = "0x170001DD")]
		public float GateY
		{
			[Token(Token = "0x6001519")]
			[Address(RVA = "0x3D0BCF0", Offset = "0x3D0BCF0", Length = "0x8")]
			get
			{
				return m_gateY;
			}
		}

		[Token(Token = "0x170001DE")]
		public float GateXMin
		{
			[Token(Token = "0x600151A")]
			[Address(RVA = "0x3D0BCF8", Offset = "0x3D0BCF8", Length = "0x8")]
			get
			{
				return m_gateXRange.x;
			}
		}

		[Token(Token = "0x170001DF")]
		public float GateXMax
		{
			[Token(Token = "0x600151B")]
			[Address(RVA = "0x3D0BD00", Offset = "0x3D0BD00", Length = "0x8")]
			get
			{
				return m_gateXRange.y;
			}
		}

		[Token(Token = "0x170001E0")]
		public bool IsGateClosed
		{
			[Token(Token = "0x600151C")]
			[Address(RVA = "0x3D0BD08", Offset = "0x3D0BD08", Length = "0x8")]
			get
			{
				return _isGateClosed;
			}
		}

		[Token(Token = "0x170001E1")]
		public int CurrentParticleCount
		{
			[Token(Token = "0x600151D")]
			[Address(RVA = "0x3D0BD10", Offset = "0x3D0BD10", Length = "0x8")]
			get
			{
				return _currentParticleCount;
			}
		}

		[Token(Token = "0x170001E2")]
		public float FreezeYThreshold
		{
			[Token(Token = "0x600151E")]
			[Address(RVA = "0x3D0BD18", Offset = "0x3D0BD18", Length = "0x8")]
			get
			{
				return m_freezeYThreshold;
			}
		}

		[Token(Token = "0x170001E3")]
		public float WakeUpYThreshold
		{
			[Token(Token = "0x600151F")]
			[Address(RVA = "0x3D0BD20", Offset = "0x3D0BD20", Length = "0x8")]
			get
			{
				return m_wakeUpYThreshold;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6001520")]
		[Address(RVA = "0x3D0BD28", Offset = "0x3D0BD28", Length = "0xB4")]
		public void add_OnParticleCountChanged(Action<int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::add_OnParticleCountChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001521")]
		[Address(RVA = "0x3D0BDDC", Offset = "0x3D0BDDC", Length = "0xB4")]
		public void remove_OnParticleCountChanged(Action<int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::remove_OnParticleCountChanged");
		}

		[Token(Token = "0x6001522")]
		[Address(RVA = "0x3D0BE90", Offset = "0x3D0BE90", Length = "0x10")]
		public void SetCapacity(int particlesPerCube)
		{
			int maxParticleCapacity = m_capacityMultiplier * particlesPerCube;
			_maxParticleCapacity = maxParticleCapacity;
		}

		[Token(Token = "0x6001523")]
		[Address(RVA = "0x3D0BEA0", Offset = "0x3D0BEA0", Length = "0xC")]
		public void OverrideMaxCapacity(int capacity)
		{
			_maxParticleCapacity = capacity;
			_isGateClosed = false;
		}

		[Token(Token = "0x6001524")]
		[Address(RVA = "0x3D0BEAC", Offset = "0x3D0BEAC", Length = "0xCC")]
		public void UpdateGateState(int particleCount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::UpdateGateState");
		}

		[Token(Token = "0x6001525")]
		[Address(RVA = "0x3D0BF78", Offset = "0x3D0BF78", Length = "0x188")]
		private void AnimateGateVisual(bool closed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::AnimateGateVisual");
		}

		[Token(Token = "0x6001526")]
		[Address(RVA = "0x3D0C100", Offset = "0x3D0C100", Length = "0x23C")]
		private void UpdateFillDisplay()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::UpdateFillDisplay");
		}

		[Token(Token = "0x6001527")]
		[Address(RVA = "0x3D0C33C", Offset = "0x3D0C33C", Length = "0x128")]
		private void StartWarningAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::StartWarningAnimation");
		}

		[Token(Token = "0x6001528")]
		[Address(RVA = "0x3D0C464", Offset = "0x3D0C464", Length = "0x134")]
		private void StopWarningAnimation()
		{
			_isWarningActive = false;
			_flashTween.Stop();
			_punchTween.Stop();
			if (m_fillText != null)
			{
				Color color = default(Color);
				color.r = m_normalColor.r;
				color.g = m_normalColor.g;
				color.b = m_normalColor.b;
				color.a = m_normalColor.a;
				m_fillText.color = color;
				Transform transform = m_fillText.transform;
				Vector3 localScale = default(Vector3);
				localScale.x = Vector3.one.x;
				localScale.y = Vector3.one.y;
				localScale.z = Vector3.one.z;
				transform.localScale = localScale;
			}
		}

		[Token(Token = "0x6001529")]
		[Address(RVA = "0x3D0C598", Offset = "0x3D0C598", Length = "0x668")]
		public unsafe void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::Initialize");
		}

		[Token(Token = "0x600152A")]
		[Address(RVA = "0x3D0CC00", Offset = "0x3D0CC00", Length = "0x228")]
		public void Cleanup()
		{
			OnParticleCountChanged = null;
			ConveyorArrowIndicator arrowIndicator = m_arrowIndicator;
			if ((object)m_arrowIndicator != null)
			{
				arrowIndicator._phase = 0f;
				m_arrowIndicator.DestroyArrows();
			}
			StopWarningAnimation();
			_gateScaleTween.Stop();
			if ((object)_sampledPoints != null)
			{
				_sampledPoints.Dispose();
			}
			if ((object)_sampledTangents != null)
			{
				_sampledTangents.Dispose();
			}
			if ((object)_segmentDirs != null)
			{
				_segmentDirs.Dispose();
			}
			if ((object)_segmentInvLenSq != null)
			{
				_segmentInvLenSq.Dispose();
			}
			_initialized = false;
			_maxParticleCapacity = 0;
			_isGateClosed = false;
			_currentParticleCount = 0;
			_isWarningActive = false;
			_lastDisplayedPct = -1;
			BeltSpeedMultiplier = 1f;
			UnityEngine.Object fillText;
			if (!(m_gateVisual != null))
			{
				fillText = m_fillText;
			}
			else
			{
				Transform transform = m_gateVisual.transform;
				Vector3 localScale = default(Vector3);
				localScale.x = 0f;
				localScale.y = 1f;
				localScale.z = 1f;
				transform.localScale = localScale;
				fillText = m_fillText;
			}
			if (fillText != null)
			{
				TextMeshPro textMeshPro = default(TextMeshPro);
				textMeshPro.text = "0%";
			}
		}

		[Token(Token = "0x600152B")]
		[Address(RVA = "0x3D0CE28", Offset = "0x3D0CE28", Length = "0x4")]
		private void OnDestroy()
		{
			Cleanup();
		}

		[Token(Token = "0x600152C")]
		[Address(RVA = "0x3D0CE2C", Offset = "0x3D0CE2C", Length = "0x4")]
		private void OnDrawGizmos()
		{
		}

		[Token(Token = "0x600152D")]
		[Address(RVA = "0x3D0CE30", Offset = "0x3D0CE30", Length = "0x58")]
		public BackgroundMaterialController GetMatController()
		{
			return GetComponent<BackgroundMaterialController>();
		}

		[Token(Token = "0x600152E")]
		[Address(RVA = "0x3D0CE88", Offset = "0x3D0CE88", Length = "0x84")]
		public ConveyorController()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorController::.ctor");
		}
	}
}
