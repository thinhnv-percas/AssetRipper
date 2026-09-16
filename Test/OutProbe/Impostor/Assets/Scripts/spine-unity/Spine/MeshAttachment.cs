using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000038")]
	public class MeshAttachment : VertexAttachment, IHasRendererObject
	{
		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x40")]
		internal float regionOffsetX;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x44")]
		internal float regionOffsetY;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x48")]
		internal float regionWidth;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x4C")]
		internal float regionHeight;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x50")]
		internal float regionOriginalWidth;

		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x54")]
		internal float regionOriginalHeight;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x58")]
		private MeshAttachment parentMesh;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x60")]
		internal float[] uvs;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x68")]
		internal float[] regionUVs;

		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x70")]
		internal int[] triangles;

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x78")]
		internal float r;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x7C")]
		internal float g;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x80")]
		internal float b;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x84")]
		internal float a;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x88")]
		internal int hulllength;

		[CompilerGenerated]
		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0xB0")]
		internal bool _003CRegionRotate_003Ek__BackingField;

		[Token(Token = "0x1700005E")]
		public int HullLength
		{
			[Token(Token = "0x6000176")]
			[Address(RVA = "0x152E714", Offset = "0x152E714", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.hulllength;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HullLength;
			}
			[Token(Token = "0x6000177")]
			[Address(RVA = "0x152E71C", Offset = "0x152E71C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hulllength = value;\n\treturn;\n")]
			set
			{
				HullLength = value;
			}
		}

		[Token(Token = "0x1700005F")]
		public float[] RegionUVs
		{
			[Token(Token = "0x6000178")]
			[Address(RVA = "0x152E724", Offset = "0x152E724", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionUVs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionUVs;
			}
			[Token(Token = "0x6000179")]
			[Address(RVA = "0x152E72C", Offset = "0x152E72C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionUVs = value;\n\treturn;\n")]
			set
			{
				RegionUVs = value;
			}
		}

		[Token(Token = "0x17000060")]
		public float[] UVs
		{
			[Token(Token = "0x600017A")]
			[Address(RVA = "0x152E734", Offset = "0x152E734", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.uvs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UVs;
			}
			[Token(Token = "0x600017B")]
			[Address(RVA = "0x152E73C", Offset = "0x152E73C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.uvs = value;\n\treturn;\n")]
			set
			{
				UVs = value;
			}
		}

		[Token(Token = "0x17000061")]
		public int[] Triangles
		{
			[Token(Token = "0x600017C")]
			[Address(RVA = "0x152E744", Offset = "0x152E744", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.triangles;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Triangles;
			}
			[Token(Token = "0x600017D")]
			[Address(RVA = "0x152E74C", Offset = "0x152E74C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.triangles = value;\n\treturn;\n")]
			set
			{
				Triangles = value;
			}
		}

		[Token(Token = "0x17000062")]
		public float R
		{
			[Token(Token = "0x600017E")]
			[Address(RVA = "0x152E754", Offset = "0x152E754", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R;
			}
			[Token(Token = "0x600017F")]
			[Address(RVA = "0x152E75C", Offset = "0x152E75C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r = value;\n\treturn;\n")]
			set
			{
				R = value;
			}
		}

		[Token(Token = "0x17000063")]
		public float G
		{
			[Token(Token = "0x6000180")]
			[Address(RVA = "0x152E764", Offset = "0x152E764", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G;
			}
			[Token(Token = "0x6000181")]
			[Address(RVA = "0x152E76C", Offset = "0x152E76C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g = value;\n\treturn;\n")]
			set
			{
				G = value;
			}
		}

		[Token(Token = "0x17000064")]
		public float B
		{
			[Token(Token = "0x6000182")]
			[Address(RVA = "0x152E774", Offset = "0x152E774", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B;
			}
			[Token(Token = "0x6000183")]
			[Address(RVA = "0x152E77C", Offset = "0x152E77C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b = value;\n\treturn;\n")]
			set
			{
				B = value;
			}
		}

		[Token(Token = "0x17000065")]
		public float A
		{
			[Token(Token = "0x6000184")]
			[Address(RVA = "0x152E784", Offset = "0x152E784", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.a;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return A;
			}
			[Token(Token = "0x6000185")]
			[Address(RVA = "0x152E78C", Offset = "0x152E78C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a = value;\n\treturn;\n")]
			set
			{
				A = value;
			}
		}

		[Token(Token = "0x17000066")]
		public string Path
		{
			[CompilerGenerated]
			[Token(Token = "0x6000186")]
			[Address(RVA = "0x152E794", Offset = "0x152E794", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Path>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Path;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000187")]
			[Address(RVA = "0x152E79C", Offset = "0x152E79C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Path>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Path = value;
			}
		}

		[Token(Token = "0x17000067")]
		public object RendererObject
		{
			[CompilerGenerated]
			[Token(Token = "0x6000188")]
			[Address(RVA = "0x152E7A4", Offset = "0x152E7A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RendererObject>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RendererObject;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000189")]
			[Address(RVA = "0x152E7AC", Offset = "0x152E7AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RendererObject>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RendererObject = value;
			}
		}

		[Token(Token = "0x17000068")]
		public float RegionU
		{
			[CompilerGenerated]
			[Token(Token = "0x600018A")]
			[Address(RVA = "0x152E7B4", Offset = "0x152E7B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RegionU>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionU;
			}
			[CompilerGenerated]
			[Token(Token = "0x600018B")]
			[Address(RVA = "0x152E7BC", Offset = "0x152E7BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RegionU>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RegionU = value;
			}
		}

		[Token(Token = "0x17000069")]
		public float RegionV
		{
			[CompilerGenerated]
			[Token(Token = "0x600018C")]
			[Address(RVA = "0x152E7C4", Offset = "0x152E7C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RegionV>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionV;
			}
			[CompilerGenerated]
			[Token(Token = "0x600018D")]
			[Address(RVA = "0x152E7CC", Offset = "0x152E7CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RegionV>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RegionV = value;
			}
		}

		[Token(Token = "0x1700006A")]
		public float RegionU2
		{
			[CompilerGenerated]
			[Token(Token = "0x600018E")]
			[Address(RVA = "0x152E7D4", Offset = "0x152E7D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RegionU2>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionU2;
			}
			[CompilerGenerated]
			[Token(Token = "0x600018F")]
			[Address(RVA = "0x152E7DC", Offset = "0x152E7DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RegionU2>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RegionU2 = value;
			}
		}

		[Token(Token = "0x1700006B")]
		public float RegionV2
		{
			[CompilerGenerated]
			[Token(Token = "0x6000190")]
			[Address(RVA = "0x152E7E4", Offset = "0x152E7E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RegionV2>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionV2;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000191")]
			[Address(RVA = "0x152E7EC", Offset = "0x152E7EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RegionV2>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RegionV2 = value;
			}
		}

		[Token(Token = "0x1700006C")]
		public bool RegionRotate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000192")]
			[Address(RVA = "0x152E7F4", Offset = "0x152E7F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RegionRotate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionRotate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000193")]
			[Address(RVA = "0x152E7FC", Offset = "0x152E7FC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RegionRotate>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CRegionRotate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700006D")]
		public int RegionDegrees
		{
			[CompilerGenerated]
			[Token(Token = "0x6000194")]
			[Address(RVA = "0x152E808", Offset = "0x152E808", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RegionDegrees>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionDegrees;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000195")]
			[Address(RVA = "0x152E810", Offset = "0x152E810", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RegionDegrees>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RegionDegrees = value;
			}
		}

		[Token(Token = "0x1700006E")]
		public float RegionOffsetX
		{
			[Token(Token = "0x6000196")]
			[Address(RVA = "0x152E818", Offset = "0x152E818", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOffsetX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOffsetX;
			}
			[Token(Token = "0x6000197")]
			[Address(RVA = "0x152E820", Offset = "0x152E820", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOffsetX = value;\n\treturn;\n")]
			set
			{
				RegionOffsetX = value;
			}
		}

		[Token(Token = "0x1700006F")]
		public float RegionOffsetY
		{
			[Token(Token = "0x6000198")]
			[Address(RVA = "0x152E828", Offset = "0x152E828", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOffsetY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOffsetY;
			}
			[Token(Token = "0x6000199")]
			[Address(RVA = "0x152E830", Offset = "0x152E830", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOffsetY = value;\n\treturn;\n")]
			set
			{
				RegionOffsetY = value;
			}
		}

		[Token(Token = "0x17000070")]
		public float RegionWidth
		{
			[Token(Token = "0x600019A")]
			[Address(RVA = "0x152E838", Offset = "0x152E838", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionWidth;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionWidth;
			}
			[Token(Token = "0x600019B")]
			[Address(RVA = "0x152E840", Offset = "0x152E840", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionWidth = value;\n\treturn;\n")]
			set
			{
				RegionWidth = value;
			}
		}

		[Token(Token = "0x17000071")]
		public float RegionHeight
		{
			[Token(Token = "0x600019C")]
			[Address(RVA = "0x152E848", Offset = "0x152E848", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionHeight;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionHeight;
			}
			[Token(Token = "0x600019D")]
			[Address(RVA = "0x152E850", Offset = "0x152E850", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionHeight = value;\n\treturn;\n")]
			set
			{
				RegionHeight = value;
			}
		}

		[Token(Token = "0x17000072")]
		public float RegionOriginalWidth
		{
			[Token(Token = "0x600019E")]
			[Address(RVA = "0x152E858", Offset = "0x152E858", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOriginalWidth;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOriginalWidth;
			}
			[Token(Token = "0x600019F")]
			[Address(RVA = "0x152E860", Offset = "0x152E860", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOriginalWidth = value;\n\treturn;\n")]
			set
			{
				RegionOriginalWidth = value;
			}
		}

		[Token(Token = "0x17000073")]
		public float RegionOriginalHeight
		{
			[Token(Token = "0x60001A0")]
			[Address(RVA = "0x152E868", Offset = "0x152E868", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOriginalHeight;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOriginalHeight;
			}
			[Token(Token = "0x60001A1")]
			[Address(RVA = "0x152E870", Offset = "0x152E870", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOriginalHeight = value;\n\treturn;\n")]
			set
			{
				RegionOriginalHeight = value;
			}
		}

		[Token(Token = "0x17000074")]
		public MeshAttachment ParentMesh
		{
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0x152E878", Offset = "0x152E878", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.parentMesh;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParentMesh;
			}
			[Token(Token = "0x60001A3")]
			[Address(RVA = "0x152E880", Offset = "0x152E880", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.parentMesh = value;\n\tv2 = value == 0;\n\tif (v2) goto L_0013;\n\tthis.bones = value.bones;\n\tthis.vertices = value.vertices;\n\tthis.worldVerticesLength = value.worldVerticesLength;\n\tthis.regionUVs = value.regionUVs;\n\tthis.triangles = value.triangles;\n\tthis.hulllength = value.hulllength;\n\tthis.<Edges>k__BackingField = value.<Edges>k__BackingField;\n\tthis.<Width>k__BackingField = value.<Width>k__BackingField;\nL_0013:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				parentMesh = value;
				if (value != null)
				{
					Bones = value.Bones;
					Vertices = value.Vertices;
					WorldVerticesLength = value.WorldVerticesLength;
					RegionUVs = value.RegionUVs;
					Triangles = value.Triangles;
					HullLength = value.HullLength;
					Edges = value.Edges;
					Width = value.Width;
				}
			}
		}

		[Token(Token = "0x17000075")]
		public int[] Edges
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A4")]
			[Address(RVA = "0x152E8CC", Offset = "0x152E8CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Edges>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Edges;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0x152E8D4", Offset = "0x152E8D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Edges>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Edges = value;
			}
		}

		[Token(Token = "0x17000076")]
		public float Width
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A6")]
			[Address(RVA = "0x152E8DC", Offset = "0x152E8DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Width>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A7")]
			[Address(RVA = "0x152E8E4", Offset = "0x152E8E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Width>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Width = value;
			}
		}

		[Token(Token = "0x17000077")]
		public float Height
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A8")]
			[Address(RVA = "0x152E8EC", Offset = "0x152E8EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Height>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A9")]
			[Address(RVA = "0x152E8F4", Offset = "0x152E8F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Height>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Height = value;
			}
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x152E2D4", Offset = "0x152E2D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.VertexAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B3F]) = v40;\nL_0016:\n\tthis.r = 0f;\n\tgoto L_0026;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, name, methodInfo, v25, v26, v27, v28, v29, v41, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tSpine.VertexAttachment::.ctor(this, name);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshAttachment(string name)
		{
			R = 0f;
			base._002Ector(name);
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x152E8FC", Offset = "0x152E8FC", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = System.Single[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B40]) = v33;\nL_0010:\n\tv156 = this.uvs;\n\tv35 = this.regionUVs;\n\tv36 = this.uvs == 0;\n\tif (v36) goto L_002A;\n\tv50 = v156.Length != v35.Length;\n\tif (v50) goto L_002A;\n\tgoto L_0033;\nL_002A:\n\t// 42 NewArr v156 @ X0_v3 (System.Single[]), typeof(System.Single[]), v35.Length\n\tthis.uvs = v156;\nL_0033:\n\tv130 = this.<RegionDegrees>k__BackingField == 0xB4;\n\tif (v130) goto L_00C3;\n\tv99 = this.<RegionDegrees>k__BackingField != 0x5A;\n\tif (v99) goto L_0134;\n\tv286 = v156.Length < 1;\n\tif (v286) goto L_0209;\n\tv419 = this.<RegionU2>k__BackingField - this.<RegionU>k__BackingField;\n\tv420 = this.<RegionV2>k__BackingField - this.<RegionV>k__BackingField;\n\tv421 = this.regionOriginalHeight - this.regionOffsetY;\n\tv422 = this.regionHeight / v419;\n\tv423 = v421 - this.regionHeight;\n\tv424 = this.regionOriginalWidth - this.regionOffsetX;\n\tv425 = this.regionWidth / v420;\n\tv426 = v424 - this.regionWidth;\n\tv344 = v423 / v422;\n\tv346 = v426 / v425;\n\tv336 = this.regionOriginalHeight / v422;\n\tv333 = this.regionOriginalWidth / v425;\n\tv326 = this.<RegionU>k__BackingField - v344;\n\tv323 = this.<RegionV>k__BackingField - v346;\nL_006C:\n\tv469 = v468 + 1;\n\tv664 = v336 * v35[v469 @ X11_v18 (System.Int32)];\n\tv523 = v326 + v664;\n\tv156[v468 @ X9_v10 (System.Int32)] = v523;\n\tv409 = v468 + 2;\n\tv690 = 1f - v35[v468 @ X9_v10 (System.Int32)];\n\tv691 = v333 * v690;\n\tv351 = v323 + v691;\n\tv156[v469 @ X11_v18 (System.Int32)] = v351;\n\tv355 = v409 < v156.Length;\n\tif (v355) goto L_006C;\n\tgoto L_0209;\nL_00C3:\n\tv274 = v156.Length < 1;\n\tif (v274) goto L_0209;\n\tv294 = this.<RegionV2>k__BackingField - this.<RegionV>k__BackingField;\n\tv295 = this.regionHeight / v294;\n\tv298 = this.<RegionU2>k__BackingField - this.<RegionU>k__BackingField;\n\tv299 = this.regionWidth / v298;\n\tv301 = this.regionOriginalWidth - this.regionOffsetX;\n\tv302 = v301 - this.regionWidth;\n\tv303 = v302 / v299;\n\tv304 = this.regionOffsetY / v295;\n\tv305 = this.regionOriginalWidth / v299;\n\tv306 = this.regionOriginalHeight / v295;\n\tv307 = this.<RegionU>k__BackingField - v303;\n\tv308 = this.<RegionV>k__BackingField - v304;\nL_00F6:\n\tv515 = v434 + 1;\n\tv658 = 1f - v35[v434 @ X10_v4 (System.Int32)];\n\tv659 = v305 * v658;\n\tv524 = v307 + v659;\n\tv156[v434 @ X10_v4 (System.Int32)] = v524;\n\tv434 = v515 + 1;\n\tv684 = 1f - v35[v515 @ X10_v6 (System.Int32)];\n\tv685 = v306 * v684;\n\tv352 = v308 + v685;\n\tv156[v515 @ X10_v6 (System.Int32)] = v352;\n\tv356 = v434 < v156.Length;\n\tif (v356) goto L_00F6;\n\tgoto L_0209;\nL_0134:\n\tv261 = this.<RegionU2>k__BackingField - this.<RegionU>k__BackingField;\n\tv262 = this.<RegionV2>k__BackingField - this.<RegionV>k__BackingField;\n\tv77 = this.regionWidth / v261;\n\tv74 = this.regionHeight / v262;\n\tv101 = this.<RegionDegrees>k__BackingField != 0x10E;\n\tif (v101) goto L_01AD;\n\tv357 = v156.Length < 1;\n\tif (v357) goto L_0209;\n\tv482 = this.regionOffsetY / v77;\n\tv483 = this.regionOffsetX / v74;\n\tv337 = this.regionOriginalHeight / v77;\n\tv334 = this.regionOriginalWidth / v74;\n\tv327 = this.<RegionU>k__BackingField - v482;\n\tv324 = this.<RegionV>k__BackingField - v483;\nL_0156:\n\tv511 = v633 + 1;\n\tv673 = 1f - v35[v511 @ X11_v14 (System.Int32)];\n\tv674 = v337 * v673;\n\tv526 = v327 + v674;\n\tv156[v633 @ X9_v7 (System.Int32)] = v526;\n\tv410 = v633 + 2;\n\tv698 = v334 * v35[v633 @ X9_v7 (System.Int32)];\n\tv353 = v324 + v698;\n\tv156[v511 @ X11_v14 (System.Int32)] = v353;\n\tv358 = v410 < v156.Length;\n\tif (v358) goto L_0156;\n\tgoto L_0209;\nL_01AD:\n\tv359 = v156.Length < 1;\n\tif (v359) goto L_0209;\n\tv350 = this.regionOffsetX / v77;\n\tv343 = this.regionOriginalHeight - this.regionOffsetY;\n\tv487 = v343 - this.regionHeight;\n\tv488 = v487 / v74;\n\tv335 = this.regionOriginalWidth / v77;\n\tv325 = this.<RegionU>k__BackingField - v350;\n\tv322 = this.<RegionV>k__BackingField - v488;\n\tv332 = this.regionOriginalHeight / v74;\nL_01D7:\n\tv519 = v517 + 1;\n\tv679 = v335 * v35[v517 @ X10_v10 (System.Int32)];\n\tv522 = v325 + v679;\n\tv156[v517 @ X10_v10 (System.Int32)] = v522;\n\tv517 = v519 + 1;\n\tv704 = v332 * v35[v519 @ X10_v12 (System.Int32)];\n\tv347 = v322 + v704;\n\tv156[v519 @ X10_v12 (System.Int32)] = v347;\n\tv354 = v517 < v156.Length;\n\tif (v354) goto L_01D7;\nL_0209:\n\treturn;\n\tv155 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 402 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateUVs()
		{
			float[] array = UVs;
			float[] array2 = RegionUVs;
			if (UVs == null || array.Length != array2.Length)
			{
				array = (UVs = new float[array2.Length]);
			}
			if (RegionDegrees != 180)
			{
				if (RegionDegrees == 90)
				{
					if (array.Length >= 1)
					{
						float num = RegionU2 - RegionU;
						float num2 = RegionV2 - RegionV;
						float num3 = RegionOriginalHeight - RegionOffsetY;
						float num4 = RegionHeight / num;
						float num5 = num3 - RegionHeight;
						float num6 = RegionOriginalWidth - RegionOffsetX;
						float num7 = RegionWidth / num2;
						float num8 = num6 - RegionWidth;
						float num9 = num5 / num4;
						float num10 = num8 / num7;
						float num11 = RegionOriginalHeight / num4;
						float num12 = RegionOriginalWidth / num7;
						float num13 = RegionU - num9;
						float num14 = RegionV - num10;
						int num15 = 0;
						bool flag;
						do
						{
							int num16 = num15 + 1;
							float num17 = num11 * array2[num16];
							float num18 = num13 + num17;
							array[num15] = num18;
							int num19 = num15 + 2;
							float num20 = 1f - array2[num15];
							float num21 = num12 * num20;
							float num22 = num14 + num21;
							array[num16] = num22;
							flag = num19 < array.Length;
							num15 = num19;
						}
						while (flag);
					}
					return;
				}
				float num23 = RegionU2 - RegionU;
				float num24 = RegionV2 - RegionV;
				float num25 = RegionWidth / num23;
				float num26 = RegionHeight / num24;
				if (RegionDegrees == 270)
				{
					if (array.Length >= 1)
					{
						float num27 = RegionOffsetY / num25;
						float num28 = RegionOffsetX / num26;
						float num29 = RegionOriginalHeight / num25;
						float num30 = RegionOriginalWidth / num26;
						float num31 = RegionU - num27;
						float num32 = RegionV - num28;
						int num33 = 0;
						bool flag2;
						do
						{
							int num34 = num33 + 1;
							float num35 = 1f - array2[num34];
							float num36 = num29 * num35;
							float num37 = num31 + num36;
							array[num33] = num37;
							int num38 = num33 + 2;
							float num39 = num30 * array2[num33];
							float num40 = num32 + num39;
							array[num34] = num40;
							flag2 = num38 < array.Length;
							num33 = num38;
						}
						while (flag2);
					}
				}
				else if (array.Length >= 1)
				{
					float num41 = RegionOffsetX / num25;
					float num42 = RegionOriginalHeight - RegionOffsetY;
					float num43 = num42 - RegionHeight;
					float num44 = num43 / num26;
					float num45 = RegionOriginalWidth / num25;
					float num46 = RegionU - num41;
					float num47 = RegionV - num44;
					float num48 = RegionOriginalHeight / num26;
					int num49 = 0;
					do
					{
						int num50 = num49 + 1;
						float num51 = num45 * array2[num49];
						float num52 = num46 + num51;
						array[num49] = num52;
						num49 = num50 + 1;
						float num53 = num48 * array2[num50];
						float num54 = num47 + num53;
						array[num50] = num54;
					}
					while (num49 < array.Length);
				}
			}
			else if (array.Length >= 1)
			{
				float num55 = RegionV2 - RegionV;
				float num56 = RegionHeight / num55;
				float num57 = RegionU2 - RegionU;
				float num58 = RegionWidth / num57;
				float num59 = RegionOriginalWidth - RegionOffsetX;
				float num60 = num59 - RegionWidth;
				float num61 = num60 / num58;
				float num62 = RegionOffsetY / num56;
				float num63 = RegionOriginalWidth / num58;
				float num64 = RegionOriginalHeight / num56;
				float num65 = RegionU - num61;
				float num66 = RegionV - num62;
				int num67 = 0;
				do
				{
					int num68 = num67 + 1;
					float num69 = 1f - array2[num67];
					float num70 = num63 * num69;
					float num71 = num65 + num70;
					array[num67] = num71;
					num67 = num68 + 1;
					float num72 = 1f - array2[num68];
					float num73 = num64 * num72;
					float num74 = num66 + num73;
					array[num68] = num74;
				}
				while (num67 < array.Length);
			}
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x152ECA8", Offset = "0x152ECA8", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = System.Int32[];\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = Spine.MeshAttachment;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv54 = System.Single[];\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37B41]) = v36;\nL_0018:\n\tv38 = this.parentMesh == 0;\n\tif (v38) goto L_0026;\n\treturnVal1 = Spine.MeshAttachment::NewLinkedMesh(this);\n\treturn returnVal1;\nL_0026:\n\tv52 = new Spine.MeshAttachment();\n\tSpine.MeshAttachment::.ctor(v52, this.<Name>k__BackingField);\n\tv52.<RendererObject>k__BackingField = this.<RendererObject>k__BackingField;\n\tv52.regionOffsetX = this.regionOffsetX;\n\tv52.regionOriginalWidth = this.regionOriginalWidth;\n\tv52.<RegionRotate>k__BackingField = this.<RegionRotate>k__BackingField;\n\tv52.<RegionDegrees>k__BackingField = this.<RegionDegrees>k__BackingField;\n\tv52.<RegionU>k__BackingField = this.<RegionU>k__BackingField;\n\tv52.<Path>k__BackingField = this.<Path>k__BackingField;\n\tv52.r = this.r;\n\tSpine.VertexAttachment::CopyTo(this, v52);\n\tv138 = this.regionUVs;\n\t// 71 NewArr v143 @ X0_v8 (System.Single[]), typeof(System.Single[]), v138.Length\n\tv52.regionUVs = v143;\n\tv127 = this.regionUVs;\n\tSystem.Array::Copy(this.regionUVs, 0, v143, 0, *([v127 @ X0_v9 (System.Array)+18]));\n\tv139 = this.uvs;\n\t// 87 NewArr v145 @ X0_v11 (System.Single[]), typeof(System.Single[]), v139.Length\n\tv52.uvs = v145;\n\tv128 = this.uvs;\n\tSystem.Array::Copy(this.uvs, 0, v145, 0, *([v128 @ X0_v12 (System.Array)+18]));\n\tv140 = this.triangles;\n\t// 105 NewArr v148 @ X0_v14 (System.Int32[]), typeof(System.Int32[]), v140.Length\n\tv52.triangles = v148;\n\tv129 = this.triangles;\n\tSystem.Array::Copy(this.triangles, 0, v148, 0, *([v129 @ X0_v15 (System.Array)+18]));\n\tv52.hulllength = this.hulllength;\n\tv89 = this.<Edges>k__BackingField;\n\tv151 = this.<Edges>k__BackingField == 0;\n\tif (v151) goto L_0088;\n\t// 123 NewArr v153 @ X0_v19 (System.Int32[]), typeof(System.Int32[]), v89.Length\n\tv52.<Edges>k__BackingField = v153;\n\tv130 = this.<Edges>k__BackingField;\n\tSystem.Array::Copy(this.<Edges>k__BackingField, 0, v153, 0, *([v130 @ X0_v20 (System.Array)+18]));\nL_0088:\n\tv52.<Width>k__BackingField = this.<Width>k__BackingField;\n\treturn v52;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Attachment Copy()
		{
			if (ParentMesh != null)
			{
				return NewLinkedMesh();
			}
			MeshAttachment meshAttachment = new MeshAttachment(Name);
			meshAttachment.RendererObject = RendererObject;
			meshAttachment.RegionOffsetX = RegionOffsetX;
			meshAttachment.RegionOriginalWidth = RegionOriginalWidth;
			meshAttachment.RegionRotate = RegionRotate;
			meshAttachment.RegionDegrees = RegionDegrees;
			meshAttachment.RegionU = RegionU;
			meshAttachment.Path = Path;
			meshAttachment.R = R;
			CopyTo(meshAttachment);
			float[] array = RegionUVs;
			float[] destinationArray = (meshAttachment.RegionUVs = new float[array.Length]);
			Array array3 = RegionUVs;
			float[] sourceArray = RegionUVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X0_v9 (System.Array)+18]");
			Array.Copy(sourceArray, 0, destinationArray, 0, 0);
			float[] uVs = UVs;
			float[] destinationArray2 = (meshAttachment.UVs = new float[uVs.Length]);
			Array uVs2 = UVs;
			float[] uVs3 = UVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v12 (System.Array)+18]");
			Array.Copy(uVs3, 0, destinationArray2, 0, 0);
			int[] array5 = Triangles;
			int[] destinationArray3 = (meshAttachment.Triangles = new int[array5.Length]);
			Array array7 = Triangles;
			int[] sourceArray2 = Triangles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X0_v15 (System.Array)+18]");
			Array.Copy(sourceArray2, 0, destinationArray3, 0, 0);
			meshAttachment.HullLength = HullLength;
			int[] edges = Edges;
			if (Edges != null)
			{
				int[] destinationArray4 = (meshAttachment.Edges = new int[edges.Length]);
				Array edges2 = Edges;
				int[] edges3 = Edges;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X0_v20 (System.Array)+18]");
				Array.Copy(edges3, 0, destinationArray4, 0, 0);
			}
			meshAttachment.Width = Width;
			return meshAttachment;
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x152EE8C", Offset = "0x152EE8C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.MeshAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B42]) = v37;\nL_0015:\n\tv40 = new Spine.MeshAttachment();\n\tSpine.MeshAttachment::.ctor(v40, this.<Name>k__BackingField);\n\tv40.<RendererObject>k__BackingField = this.<RendererObject>k__BackingField;\n\tv40.regionOffsetX = this.regionOffsetX;\n\tv40.regionOriginalWidth = this.regionOriginalWidth;\n\tv40.<RegionDegrees>k__BackingField = this.<RegionDegrees>k__BackingField;\n\tv40.<RegionRotate>k__BackingField = this.<RegionRotate>k__BackingField;\n\tv40.<RegionU>k__BackingField = this.<RegionU>k__BackingField;\n\tv40.<Path>k__BackingField = this.<Path>k__BackingField;\n\tv40.r = this.r;\n\tv40.deformAttachment = this.deformAttachment;\n\tv64 = this.parentMesh != 0;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\tSpine.MeshAttachment::set_ParentMesh(v40, v68);\n\tSpine.MeshAttachment::UpdateUVs(v40);\n\treturn v40;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshAttachment NewLinkedMesh()
		{
			MeshAttachment meshAttachment = new MeshAttachment(Name);
			meshAttachment.RendererObject = RendererObject;
			meshAttachment.RegionOffsetX = RegionOffsetX;
			meshAttachment.RegionOriginalWidth = RegionOriginalWidth;
			meshAttachment.RegionDegrees = RegionDegrees;
			meshAttachment.RegionRotate = RegionRotate;
			meshAttachment.RegionU = RegionU;
			meshAttachment.Path = Path;
			meshAttachment.R = R;
			meshAttachment.DeformAttachment = DeformAttachment;
			MeshAttachment meshAttachment2 = ((ParentMesh != null) ? ParentMesh : this);
			meshAttachment.ParentMesh = meshAttachment2;
			meshAttachment.UpdateUVs();
			return meshAttachment;
		}
	}
}
