using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.LavaLamp.Runtime
{
	[AddComponentMenu("UI/LavaLamp Image")]
	[Token(Token = "0x20007F8")]
	public class LavaLampImage : Image
	{
		[Token(Token = "0x4001A88")]
		private const string DEFAULT_MATERIAL_RESOURCE_PATH = "Materials/DefaultLavaLamp";

		[SerializeField]
		[Tooltip("Per-instance phase seed. Randomised when the component is added; edit by hand to manually desync or resync Images.")]
		[Token(Token = "0x4001A89")]
		[FieldOffset(Offset = "0x110")]
		private float m_PhaseSeed;

		[SerializeField]
		[Tooltip("Blob colour override. Alpha controls the blend: 0 = pure HSV-darkened sprite (no override), 1 = blob region painted with this exact colour. Default is white-alpha-0, so a fresh component matches the original 'just darker' overlay until you push the slider.")]
		[Token(Token = "0x4001A8A")]
		[FieldOffset(Offset = "0x114")]
		private Color m_BlobTint;

		[Token(Token = "0x4001A8B")]
		private static Material s_defaultMaterial;

		[Token(Token = "0x1700034E")]
		public float PhaseSeed
		{
			[Token(Token = "0x60021B5")]
			[Address(RVA = "0x3DC8FB4", Offset = "0x3DC8FB4", Length = "0x8")]
			get
			{
				return m_PhaseSeed;
			}
			[Token(Token = "0x60021B6")]
			[Address(RVA = "0x3DC8FBC", Offset = "0x3DC8FBC", Length = "0x24")]
			set
			{
				if (PhaseSeed != value)
				{
					m_PhaseSeed = value;
					base.SetVerticesDirty();
				}
			}
		}

		[Token(Token = "0x1700034F")]
		public Color BlobTint
		{
			[Token(Token = "0x60021B7")]
			[Address(RVA = "0x3DC8FE0", Offset = "0x3DC8FE0", Length = "0x14")]
			get
			{
				return m_BlobTint;
			}
			[Token(Token = "0x60021B8")]
			[Address(RVA = "0x3DC8FF4", Offset = "0x3DC8FF4", Length = "0x74")]
			set
			{
				float num = BlobTint.r - value.r;
				float num2 = m_BlobTint.g - value.g;
				float num3 = m_BlobTint.b - value.b;
				float num4 = m_BlobTint.a - value.a;
				float num5 = num * num;
				float num6 = num2 * num2;
				float num7 = num5 + num6;
				float num8 = num3 * num3;
				float num9 = num8 + num7;
				float num10 = num4 * num4;
				float num11 = num10 + num9;
				if (!(num11 < 9.9999994E-11f))
				{
					m_BlobTint.r = value.r;
					m_BlobTint.g = value.g;
					m_BlobTint.b = value.b;
					m_BlobTint.a = value.a;
					base.SetVerticesDirty();
				}
			}
		}

		[Token(Token = "0x17000350")]
		public override Material defaultMaterial
		{
			[Token(Token = "0x60021B9")]
			[Address(RVA = "0x3DC9068", Offset = "0x3DC9068", Length = "0x184")]
			get
			{
				Object obj;
				if (!(s_defaultMaterial == null))
				{
					obj = s_defaultMaterial;
				}
				else
				{
					Material material = Resources.Load<Material>("Materials/DefaultLavaLamp");
					s_defaultMaterial = material;
					obj = s_defaultMaterial;
				}
				if (obj != null)
				{
					return s_defaultMaterial;
				}
				return base.defaultMaterial;
			}
		}

		[Token(Token = "0x60021BA")]
		[Address(RVA = "0x3DC91EC", Offset = "0x3DC91EC", Length = "0x48")]
		protected override void Awake()
		{
			base.Awake();
			if (PhaseSeed == 0f)
			{
				float value = Random.value;
				float phaseSeed = value * 1000f;
				m_PhaseSeed = phaseSeed;
			}
		}

		[Token(Token = "0x60021BB")]
		[Address(RVA = "0x3DC9234", Offset = "0x3DC9234", Length = "0x28")]
		protected override void OnEnable()
		{
			base.OnEnable();
			EnsureCanvasChannels();
		}

		[Token(Token = "0x60021BC")]
		[Address(RVA = "0x3DC9358", Offset = "0x3DC9358", Length = "0x28")]
		protected override void OnCanvasHierarchyChanged()
		{
			base.OnCanvasHierarchyChanged();
			EnsureCanvasChannels();
		}

		[Token(Token = "0x60021BD")]
		[Address(RVA = "0x3DC9380", Offset = "0x3DC9380", Length = "0x28")]
		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			EnsureCanvasChannels();
		}

		[Token(Token = "0x60021BE")]
		[Address(RVA = "0x3DC925C", Offset = "0x3DC925C", Length = "0xFC")]
		private void EnsureCanvasChannels()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E13D]");
			Canvas canvas2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Canvas canvas = base.canvas;
				canvas2 = canvas;
			}
			else
			{
				_ = 1;
				Canvas canvas3 = base.canvas;
				canvas2 = canvas3;
			}
			if (!(canvas2 == null))
			{
				AdditionalCanvasShaderChannels additionalShaderChannels = canvas2.additionalShaderChannels;
				int num = (int)(~additionalShaderChannels);
				if ((3 & num) != 0)
				{
					AdditionalCanvasShaderChannels additionalShaderChannels2 = canvas2.additionalShaderChannels;
					AdditionalCanvasShaderChannels additionalShaderChannels3 = additionalShaderChannels2 | (AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2);
					canvas2.additionalShaderChannels = additionalShaderChannels3;
				}
			}
		}

		[Token(Token = "0x60021BF")]
		[Address(RVA = "0x3DC93A8", Offset = "0x3DC93A8", Length = "0xFC")]
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			base.OnPopulateMesh(vh);
			UIVertex vertex = default(UIVertex);
			object obj = vertex;
			int currentVertCount = vh.currentVertCount;
			_ = 0;
			if (currentVertCount >= 1)
			{
				int num = 0;
				do
				{
					vh.PopulateUIVertex(ref vertex, num);
					_ = BlobTint;
					UIVertex vertex2 = vertex;
					vh.SetUIVertex(vertex2, num);
					num++;
				}
				while (currentVertCount != num);
			}
		}

		[Token(Token = "0x60021C0")]
		[Address(RVA = "0x3DC94A4", Offset = "0x3DC94A4", Length = "0xAC")]
		public LavaLampImage()
		{
			Color color = Color.HSVToRGB(0f, 0f, 0.95f, hdr: true);
			m_BlobTint.r = color.r;
			m_BlobTint.g = color.g;
			m_BlobTint.b = color.b;
			m_BlobTint.a = color.a;
		}
	}
}
