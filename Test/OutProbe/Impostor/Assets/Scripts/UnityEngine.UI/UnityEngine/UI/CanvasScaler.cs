using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Layout/Canvas Scaler", 101)]
	[ExecuteAlways]
	[RequireComponent(typeof(Canvas))]
	[Token(Token = "0x200003C")]
	public class CanvasScaler : UIBehaviour
	{
		[Token(Token = "0x200003D")]
		public enum ScaleMode
		{
			[Token(Token = "0x4000143")]
			ConstantPixelSize = 0,
			[Token(Token = "0x4000144")]
			ScaleWithScreenSize = 1,
			[Token(Token = "0x4000145")]
			ConstantPhysicalSize = 2
		}

		[Token(Token = "0x200003E")]
		public enum ScreenMatchMode
		{
			[Token(Token = "0x4000147")]
			MatchWidthOrHeight = 0,
			[Token(Token = "0x4000148")]
			Expand = 1,
			[Token(Token = "0x4000149")]
			Shrink = 2
		}

		[Token(Token = "0x200003F")]
		public enum Unit
		{
			[Token(Token = "0x400014B")]
			Centimeters = 0,
			[Token(Token = "0x400014C")]
			Millimeters = 1,
			[Token(Token = "0x400014D")]
			Inches = 2,
			[Token(Token = "0x400014E")]
			Points = 3,
			[Token(Token = "0x400014F")]
			Picas = 4
		}

		[Tooltip("Determines how UI elements in the Canvas are scaled.")]
		[SerializeField]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x20")]
		private ScaleMode m_UiScaleMode;

		[Tooltip("If a sprite has this 'Pixels Per Unit' setting, then one pixel in the sprite will cover one unit in the UI.")]
		[SerializeField]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x24")]
		protected float m_ReferencePixelsPerUnit;

		[Tooltip("Scales all UI elements in the Canvas by this factor.")]
		[SerializeField]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x28")]
		protected float m_ScaleFactor;

		[Tooltip("The resolution the UI layout is designed for. If the screen resolution is larger, the UI will be scaled up, and if it's smaller, the UI will be scaled down. This is done in accordance with the Screen Match Mode.")]
		[SerializeField]
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x2C")]
		protected Vector2 m_ReferenceResolution;

		[SerializeField]
		[Tooltip("A mode used to scale the canvas area if the aspect ratio of the current resolution doesn't fit the reference resolution.")]
		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x34")]
		protected ScreenMatchMode m_ScreenMatchMode;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Determines if the scaling is using the width or height as reference, or a mix in between.")]
		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x38")]
		protected float m_MatchWidthOrHeight;

		[Token(Token = "0x4000139")]
		private const float kLogBase = 2f;

		[Tooltip("The physical unit to specify positions and sizes in.")]
		[SerializeField]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x3C")]
		protected Unit m_PhysicalUnit;

		[Tooltip("The DPI to assume if the screen DPI is not known.")]
		[SerializeField]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x40")]
		protected float m_FallbackScreenDPI;

		[SerializeField]
		[Tooltip("The pixels per inch to use for sprites that have a 'Pixels Per Unit' setting that matches the 'Reference Pixels Per Unit' setting.")]
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x44")]
		protected float m_DefaultSpriteDPI;

		[Tooltip("The amount of pixels per unit to use for dynamically created bitmaps in the UI, such as Text.")]
		[SerializeField]
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x48")]
		protected float m_DynamicPixelsPerUnit;

		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x50")]
		private Canvas m_Canvas;

		[NonSerialized]
		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x58")]
		private float m_PrevScaleFactor;

		[NonSerialized]
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x5C")]
		private float m_PrevReferencePixelsPerUnit;

		[SerializeField]
		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x60")]
		protected bool m_PresetInfoIsWorld;

		[Token(Token = "0x1700009B")]
		public ScaleMode uiScaleMode
		{
			[Token(Token = "0x6000259")]
			[Address(RVA = "0x182382C", Offset = "0x182382C", Length = "0x8")]
			get
			{
				return ScaleMode.ConstantPixelSize;
			}
			[Token(Token = "0x600025A")]
			[Address(RVA = "0x1823834", Offset = "0x1823834", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700009C")]
		public float referencePixelsPerUnit
		{
			[Token(Token = "0x600025B")]
			[Address(RVA = "0x182383C", Offset = "0x182383C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600025C")]
			[Address(RVA = "0x1823844", Offset = "0x1823844", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700009D")]
		public float scaleFactor
		{
			[Token(Token = "0x600025D")]
			[Address(RVA = "0x182384C", Offset = "0x182384C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600025E")]
			[Address(RVA = "0x1823854", Offset = "0x1823854", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x1700009E")]
		public Vector2 referenceResolution
		{
			[Token(Token = "0x600025F")]
			[Address(RVA = "0x1823868", Offset = "0x1823868", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000260")]
			[Address(RVA = "0x1823870", Offset = "0x1823870", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x1700009F")]
		public ScreenMatchMode screenMatchMode
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0x18238D4", Offset = "0x18238D4", Length = "0x8")]
			get
			{
				return ScreenMatchMode.MatchWidthOrHeight;
			}
			[Token(Token = "0x6000262")]
			[Address(RVA = "0x18238DC", Offset = "0x18238DC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000A0")]
		public float matchWidthOrHeight
		{
			[Token(Token = "0x6000263")]
			[Address(RVA = "0x18238E4", Offset = "0x18238E4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000264")]
			[Address(RVA = "0x18238EC", Offset = "0x18238EC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000A1")]
		public Unit physicalUnit
		{
			[Token(Token = "0x6000265")]
			[Address(RVA = "0x18238F4", Offset = "0x18238F4", Length = "0x8")]
			get
			{
				return Unit.Centimeters;
			}
			[Token(Token = "0x6000266")]
			[Address(RVA = "0x18238FC", Offset = "0x18238FC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000A2")]
		public float fallbackScreenDPI
		{
			[Token(Token = "0x6000267")]
			[Address(RVA = "0x1823904", Offset = "0x1823904", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000268")]
			[Address(RVA = "0x182390C", Offset = "0x182390C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000A3")]
		public float defaultSpriteDPI
		{
			[Token(Token = "0x6000269")]
			[Address(RVA = "0x1823914", Offset = "0x1823914", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600026A")]
			[Address(RVA = "0x182391C", Offset = "0x182391C", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x170000A4")]
		public float dynamicPixelsPerUnit
		{
			[Token(Token = "0x600026B")]
			[Address(RVA = "0x182392C", Offset = "0x182392C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600026C")]
			[Address(RVA = "0x1823934", Offset = "0x1823934", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0x182393C", Offset = "0x182393C", Length = "0x48")]
		protected CanvasScaler()
		{
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0x1823984", Offset = "0x1823984", Length = "0xC4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0x1823A48", Offset = "0x1823A48", Length = "0x10")]
		private void Canvas_preWillRenderCanvases()
		{
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0x1823A58", Offset = "0x1823A58", Length = "0xA8")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0x1823B80", Offset = "0x1823B80", Length = "0xFC")]
		protected virtual void Handle()
		{
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0x1823C7C", Offset = "0x1823C7C", Length = "0x20")]
		protected virtual void HandleWorldCanvas()
		{
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0x1823C9C", Offset = "0x1823C9C", Length = "0x20")]
		protected virtual void HandleConstantPixelSize()
		{
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0x1823CBC", Offset = "0x1823CBC", Length = "0x234")]
		protected virtual void HandleScaleWithScreenSize()
		{
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0x1823EF0", Offset = "0x1823EF0", Length = "0x68")]
		protected virtual void HandleConstantPhysicalSize()
		{
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0x1823B00", Offset = "0x1823B00", Length = "0x40")]
		protected void SetScaleFactor(float scaleFactor)
		{
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0x1823B40", Offset = "0x1823B40", Length = "0x40")]
		protected void SetReferencePixelsPerUnit(float referencePixelsPerUnit)
		{
		}
	}
}
