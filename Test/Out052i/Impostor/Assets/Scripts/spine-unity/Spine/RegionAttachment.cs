using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200003B")]
	public class RegionAttachment : Attachment, IHasRendererObject
	{
		[Token(Token = "0x400014C")]
		public const int BLX = 0;

		[Token(Token = "0x400014D")]
		public const int BLY = 1;

		[Token(Token = "0x400014E")]
		public const int ULX = 2;

		[Token(Token = "0x400014F")]
		public const int ULY = 3;

		[Token(Token = "0x4000150")]
		public const int URX = 4;

		[Token(Token = "0x4000151")]
		public const int URY = 5;

		[Token(Token = "0x4000152")]
		public const int BRX = 6;

		[Token(Token = "0x4000153")]
		public const int BRY = 7;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x18")]
		internal float x;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x1C")]
		internal float y;

		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x20")]
		internal float rotation;

		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x24")]
		internal float scaleX;

		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x28")]
		internal float scaleY;

		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x2C")]
		internal float width;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x30")]
		internal float height;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x34")]
		internal float regionOffsetX;

		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x38")]
		internal float regionOffsetY;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x3C")]
		internal float regionWidth;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x40")]
		internal float regionHeight;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x44")]
		internal float regionOriginalWidth;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x48")]
		internal float regionOriginalHeight;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x50")]
		internal float[] offset;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x58")]
		internal float[] uvs;

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x60")]
		internal float r;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x64")]
		internal float g;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x68")]
		internal float b;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x6C")]
		internal float a;

		[Token(Token = "0x1700007E")]
		public float X
		{
			[Token(Token = "0x60001C0")]
			[Address(RVA = "0x152F628", Offset = "0x152F628", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.x;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return X;
			}
			[Token(Token = "0x60001C1")]
			[Address(RVA = "0x152F630", Offset = "0x152F630", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.x = value;\n\treturn;\n")]
			set
			{
				X = value;
			}
		}

		[Token(Token = "0x1700007F")]
		public float Y
		{
			[Token(Token = "0x60001C2")]
			[Address(RVA = "0x152F638", Offset = "0x152F638", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.y;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Y;
			}
			[Token(Token = "0x60001C3")]
			[Address(RVA = "0x152F640", Offset = "0x152F640", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.y = value;\n\treturn;\n")]
			set
			{
				Y = value;
			}
		}

		[Token(Token = "0x17000080")]
		public float Rotation
		{
			[Token(Token = "0x60001C4")]
			[Address(RVA = "0x152F648", Offset = "0x152F648", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rotation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Rotation;
			}
			[Token(Token = "0x60001C5")]
			[Address(RVA = "0x152F650", Offset = "0x152F650", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotation = value;\n\treturn;\n")]
			set
			{
				Rotation = value;
			}
		}

		[Token(Token = "0x17000081")]
		public float ScaleX
		{
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0x152F658", Offset = "0x152F658", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleX;
			}
			[Token(Token = "0x60001C7")]
			[Address(RVA = "0x152F660", Offset = "0x152F660", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleX = value;\n\treturn;\n")]
			set
			{
				ScaleX = value;
			}
		}

		[Token(Token = "0x17000082")]
		public float ScaleY
		{
			[Token(Token = "0x60001C8")]
			[Address(RVA = "0x152F668", Offset = "0x152F668", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scaleY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScaleY;
			}
			[Token(Token = "0x60001C9")]
			[Address(RVA = "0x152F670", Offset = "0x152F670", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scaleY = value;\n\treturn;\n")]
			set
			{
				ScaleY = value;
			}
		}

		[Token(Token = "0x17000083")]
		public float Width
		{
			[Token(Token = "0x60001CA")]
			[Address(RVA = "0x152F678", Offset = "0x152F678", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.width;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
			[Token(Token = "0x60001CB")]
			[Address(RVA = "0x152F680", Offset = "0x152F680", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.width = value;\n\treturn;\n")]
			set
			{
				Width = value;
			}
		}

		[Token(Token = "0x17000084")]
		public float Height
		{
			[Token(Token = "0x60001CC")]
			[Address(RVA = "0x152F688", Offset = "0x152F688", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.height;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
			[Token(Token = "0x60001CD")]
			[Address(RVA = "0x152F690", Offset = "0x152F690", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.height = value;\n\treturn;\n")]
			set
			{
				Height = value;
			}
		}

		[Token(Token = "0x17000085")]
		public float R
		{
			[Token(Token = "0x60001CE")]
			[Address(RVA = "0x152F698", Offset = "0x152F698", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R;
			}
			[Token(Token = "0x60001CF")]
			[Address(RVA = "0x152F6A0", Offset = "0x152F6A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r = value;\n\treturn;\n")]
			set
			{
				R = value;
			}
		}

		[Token(Token = "0x17000086")]
		public float G
		{
			[Token(Token = "0x60001D0")]
			[Address(RVA = "0x152F6A8", Offset = "0x152F6A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G;
			}
			[Token(Token = "0x60001D1")]
			[Address(RVA = "0x152F6B0", Offset = "0x152F6B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g = value;\n\treturn;\n")]
			set
			{
				G = value;
			}
		}

		[Token(Token = "0x17000087")]
		public float B
		{
			[Token(Token = "0x60001D2")]
			[Address(RVA = "0x152F6B8", Offset = "0x152F6B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B;
			}
			[Token(Token = "0x60001D3")]
			[Address(RVA = "0x152F6C0", Offset = "0x152F6C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b = value;\n\treturn;\n")]
			set
			{
				B = value;
			}
		}

		[Token(Token = "0x17000088")]
		public float A
		{
			[Token(Token = "0x60001D4")]
			[Address(RVA = "0x152F6C8", Offset = "0x152F6C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.a;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return A;
			}
			[Token(Token = "0x60001D5")]
			[Address(RVA = "0x152F6D0", Offset = "0x152F6D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a = value;\n\treturn;\n")]
			set
			{
				A = value;
			}
		}

		[Token(Token = "0x17000089")]
		public string Path
		{
			[CompilerGenerated]
			[Token(Token = "0x60001D6")]
			[Address(RVA = "0x152F6D8", Offset = "0x152F6D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Path>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Path;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001D7")]
			[Address(RVA = "0x152F6E0", Offset = "0x152F6E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Path>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Path = value;
			}
		}

		[Token(Token = "0x1700008A")]
		public object RendererObject
		{
			[CompilerGenerated]
			[Token(Token = "0x60001D8")]
			[Address(RVA = "0x152F6E8", Offset = "0x152F6E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RendererObject>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RendererObject;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001D9")]
			[Address(RVA = "0x152F6F0", Offset = "0x152F6F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RendererObject>k__BackingField = value;\n\treturn;\n")]
			set
			{
				RendererObject = value;
			}
		}

		[Token(Token = "0x1700008B")]
		public float RegionOffsetX
		{
			[Token(Token = "0x60001DA")]
			[Address(RVA = "0x152F6F8", Offset = "0x152F6F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOffsetX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOffsetX;
			}
			[Token(Token = "0x60001DB")]
			[Address(RVA = "0x152F700", Offset = "0x152F700", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOffsetX = value;\n\treturn;\n")]
			set
			{
				RegionOffsetX = value;
			}
		}

		[Token(Token = "0x1700008C")]
		public float RegionOffsetY
		{
			[Token(Token = "0x60001DC")]
			[Address(RVA = "0x152F708", Offset = "0x152F708", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOffsetY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOffsetY;
			}
			[Token(Token = "0x60001DD")]
			[Address(RVA = "0x152F710", Offset = "0x152F710", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOffsetY = value;\n\treturn;\n")]
			set
			{
				RegionOffsetY = value;
			}
		}

		[Token(Token = "0x1700008D")]
		public float RegionWidth
		{
			[Token(Token = "0x60001DE")]
			[Address(RVA = "0x152F718", Offset = "0x152F718", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionWidth;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionWidth;
			}
			[Token(Token = "0x60001DF")]
			[Address(RVA = "0x152F720", Offset = "0x152F720", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionWidth = value;\n\treturn;\n")]
			set
			{
				RegionWidth = value;
			}
		}

		[Token(Token = "0x1700008E")]
		public float RegionHeight
		{
			[Token(Token = "0x60001E0")]
			[Address(RVA = "0x152F728", Offset = "0x152F728", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionHeight;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionHeight;
			}
			[Token(Token = "0x60001E1")]
			[Address(RVA = "0x152F730", Offset = "0x152F730", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionHeight = value;\n\treturn;\n")]
			set
			{
				RegionHeight = value;
			}
		}

		[Token(Token = "0x1700008F")]
		public float RegionOriginalWidth
		{
			[Token(Token = "0x60001E2")]
			[Address(RVA = "0x152F738", Offset = "0x152F738", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOriginalWidth;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOriginalWidth;
			}
			[Token(Token = "0x60001E3")]
			[Address(RVA = "0x152F740", Offset = "0x152F740", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOriginalWidth = value;\n\treturn;\n")]
			set
			{
				RegionOriginalWidth = value;
			}
		}

		[Token(Token = "0x17000090")]
		public float RegionOriginalHeight
		{
			[Token(Token = "0x60001E4")]
			[Address(RVA = "0x152F748", Offset = "0x152F748", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regionOriginalHeight;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RegionOriginalHeight;
			}
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0x152F750", Offset = "0x152F750", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.regionOriginalHeight = value;\n\treturn;\n")]
			set
			{
				RegionOriginalHeight = value;
			}
		}

		[Token(Token = "0x17000091")]
		public float[] Offset
		{
			[Token(Token = "0x60001E6")]
			[Address(RVA = "0x152F758", Offset = "0x152F758", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.offset;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Offset;
			}
		}

		[Token(Token = "0x17000092")]
		public float[] UVs
		{
			[Token(Token = "0x60001E7")]
			[Address(RVA = "0x152F760", Offset = "0x152F760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.uvs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UVs;
			}
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0x152F768", Offset = "0x152F768", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B47]) = v40;\nL_0016:\n\tthis.scaleX = 0f;\n\t// 25 NewArr v44 @ X0_v3 (System.Single[]), typeof(System.Single[]), 8\n\tthis.offset = v44;\n\t// 29 NewArr v47 @ X0_v5 (System.Single[]), typeof(System.Single[]), 8\n\tthis.uvs = v47;\n\tthis.r = 0f;\n\tSpine.Attachment::.ctor(this, name);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RegionAttachment(string name)
		{
			ScaleX = 0f;
			offset = new float[8];
			uvs = new float[8];
			R = 0f;
			base._002Ector(name);
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0x152F7F0", Offset = "0x152F7F0", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = Spine.MathUtils;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A37B48]) = v49;\nL_001E:\n\tv94 = this.width * 0.5f;\n\tv93 = this.height * 0.5f;\n\tv67 = this.regionOriginalWidth != 0;\n\tif (v67) goto L_0035;\n\tv68 = this.width * 0.5f;\n\tv106 = -v68;\n\tv70 = this.height * 0.5f;\n\tv105 = -v70;\n\tgoto L_004C;\nL_0035:\n\tv77 = this.regionOffsetX / this.regionOriginalWidth;\n\tv78 = this.regionOriginalWidth - this.regionOffsetX;\n\tv79 = v78 - this.regionWidth;\n\tv80 = this.regionOffsetY / this.regionOriginalHeight;\n\tv81 = this.regionOriginalHeight - this.regionOffsetY;\n\tv82 = v81 - this.regionHeight;\n\tv83 = v79 / this.regionOriginalWidth;\n\tv84 = v82 / this.regionOriginalHeight;\n\tv85 = this.width * v77;\n\tv86 = this.height * v80;\n\tv87 = this.width * v83;\n\tv88 = this.height * v84;\n\tv106 = v85 - v94;\n\tv105 = v86 - v93;\n\tv94 = v94 - v87;\n\tv93 = v93 - v88;\nL_004C:\n\tgoto L_004F;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v107, methodInfo, v33, v34, v35, v36, v37, v38, v96, v95, v97, v104, v103, v102, v101, v100);\nL_004F:\n\tv117 = Spine.MathUtils::CosDeg(this.rotation);\n\tv120 = Spine.MathUtils::SinDeg(this.rotation);\n\tv121 = this.offset;\n\tv169 = v106 * this.scaleX;\n\tv170 = v105 * this.scaleY;\n\tv171 = v169 * v117;\n\tv172 = v170 * v120;\n\tv173 = v171 + this.x;\n\tv174 = v173 - v172;\n\tv121[0] = v174;\n\tv245 = v169 * v120;\n\tv251 = v170 * v117;\n\tv237 = v251 + this.y;\n\tv242 = v245 + v237;\n\tv121[1] = v242;\n\tv238 = v93 * this.scaleY;\n\tv243 = v238 * v120;\n\tv239 = v173 - v243;\n\tv121[2] = v239;\n\tv240 = v238 * v117;\n\tv248 = v240 + this.y;\n\tv246 = v245 + v248;\n\tv121[3] = v246;\n\tv247 = v94 * this.scaleX;\n\tv241 = v247 * v117;\n\tv250 = v241 + this.x;\n\tv244 = v250 - v243;\n\tv121[4] = v244;\n\tv236 = v247 * v120;\n\tv249 = v236 + v248;\n\tv121[5] = v249;\n\tv235 = v250 - v172;\n\tv121[6] = v235;\n\tv280 = v236 + v237;\n\tv121[7] = v280;\n\treturn;\n\tv164 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateOffset()
		{
			float num = Width * 0.5f;
			float num2 = Height * 0.5f;
			float num4;
			float num6;
			if (RegionOriginalWidth == 0f)
			{
				float num3 = Width * 0.5f;
				num4 = 0f - num3;
				float num5 = Height * 0.5f;
				num6 = 0f - num5;
			}
			else
			{
				float num7 = RegionOffsetX / RegionOriginalWidth;
				float num8 = RegionOriginalWidth - RegionOffsetX;
				float num9 = num8 - RegionWidth;
				float num10 = RegionOffsetY / RegionOriginalHeight;
				float num11 = RegionOriginalHeight - RegionOffsetY;
				float num12 = num11 - RegionHeight;
				float num13 = num9 / RegionOriginalWidth;
				float num14 = num12 / RegionOriginalHeight;
				float num15 = Width * num7;
				float num16 = Height * num10;
				float num17 = Width * num13;
				float num18 = Height * num14;
				num4 = num15 - num;
				num6 = num16 - num2;
				num -= num17;
				num2 -= num18;
			}
			float num19 = MathUtils.CosDeg(Rotation);
			float num20 = MathUtils.SinDeg(Rotation);
			float[] array = Offset;
			float num21 = num4 * ScaleX;
			float num22 = num6 * ScaleY;
			float num23 = num21 * num19;
			float num24 = num22 * num20;
			float num25 = num23 + X;
			float num26 = num25 - num24;
			array[0] = num26;
			float num27 = num21 * num20;
			float num28 = num22 * num19;
			float num29 = num28 + Y;
			float num30 = num27 + num29;
			array[1] = num30;
			float num31 = num2 * ScaleY;
			float num32 = num31 * num20;
			float num33 = num25 - num32;
			array[2] = num33;
			float num34 = num31 * num19;
			float num35 = num34 + Y;
			float num36 = num27 + num35;
			array[3] = num36;
			float num37 = num * ScaleX;
			float num38 = num37 * num19;
			float num39 = num38 + X;
			float num40 = num39 - num32;
			array[4] = num40;
			float num41 = num37 * num20;
			float num42 = num41 + num35;
			array[5] = num42;
			float num43 = num39 - num24;
			array[6] = num43;
			float num44 = num41 + num29;
			array[7] = num44;
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0x152F9C4", Offset = "0x152F9C4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = rotate == 0;\n\tif (v8) goto L_0053;\n\tv2[4] = u;\n\tv2[5] = v2;\n\tv2[6] = u;\n\tv2[7] = v;\n\tv2[0] = u2;\n\tv2[1] = v;\n\tv2[2] = u2;\n\tv171 = this.uvs + 0x2C;\n\tgoto L_0088;\nL_0053:\n\tv2[2] = u;\n\tv2[3] = v2;\n\tv2[4] = u;\n\tv2[5] = v;\n\tv2[6] = u2;\n\tv2[7] = v;\n\tv2[0] = u2;\n\tv171 = this.uvs + 0x24;\nL_0088:\n\t*([v171 @ X8_v2]) = v2;\n\treturn;\n\tv10 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetUVs(float u, float v, float u2, float v2, bool rotate)
		{
			//IL_00bb: Expected O, but got I
			//IL_0168: Expected O, but got I
			//IL_0175: Expected O, but got F4
			object obj;
			if (rotate)
			{
				((float[])v2)[4] = u;
				((float[])v2)[5] = v2;
				((float[])v2)[6] = u;
				((float[])v2)[7] = v;
				((float[])v2)[0] = u2;
				((float[])v2)[1] = v;
				((float[])v2)[2] = u2;
				obj = (nint)UVs + 44;
			}
			else
			{
				((float[])v2)[2] = u;
				((float[])v2)[3] = v2;
				((float[])v2)[4] = u;
				((float[])v2)[5] = v;
				((float[])v2)[6] = u2;
				((float[])v2)[7] = v;
				((float[])v2)[0] = u2;
				obj = (nint)UVs + 36;
			}
			obj = v2;
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0x152FA7C", Offset = "0x152FA7C", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.offset;\n\tv137 = offset + 1;\n\tv266 = bone.a * v4[6];\n\tv131 = bone.b * v4[7];\n\tv267 = v266 + v131;\n\tv134 = bone.worldX + v267;\n\tworldVertices[offset @ X3 (System.Int32)] = v134;\n\tv269 = bone.c * v4[6];\n\tv146 = bone.d * v4[7];\n\tv138 = stride + offset;\n\tv270 = v269 + v146;\n\tv153 = bone.worldY + v270;\n\tworldVertices[v137 @ X10_v3 (System.Int32)] = v153;\n\tv119 = v138 + 1;\n\tv273 = bone.a * v4[0];\n\tv132 = bone.b * v4[1];\n\tv274 = v273 + v132;\n\tv135 = bone.worldX + v274;\n\tworldVertices[v138 @ X10_v4 (System.Int32)] = v135;\n\tv275 = bone.c * v4[0];\n\tv148 = bone.d * v4[1];\n\tv139 = v138 + stride;\n\tv276 = v275 + v148;\n\tv155 = bone.worldY + v276;\n\tworldVertices[v119 @ X11_v5 (System.Int32)] = v155;\n\tv121 = v139 + 1;\n\tv279 = bone.a * v4[2];\n\tv133 = bone.b * v4[3];\n\tv280 = v279 + v133;\n\tv136 = bone.worldX + v280;\n\tworldVertices[v139 @ X10_v5 (System.Int32)] = v136;\n\tv281 = bone.c * v4[2];\n\tv150 = bone.d * v4[3];\n\tv140 = v139 + stride;\n\tv282 = v281 + v150;\n\tv157 = bone.worldY + v282;\n\tworldVertices[v121 @ X11_v7 (System.Int32)] = v157;\n\tv229 = v140 + 1;\n\tv285 = bone.a * v4[4];\n\tv160 = bone.b * v4[5];\n\tv286 = v285 + v160;\n\tv162 = bone.worldX + v286;\n\tworldVertices[v140 @ X10_v6 (System.Int32)] = v162;\n\tv287 = bone.c * v4[4];\n\tv243 = bone.d * v4[5];\n\tv245 = v287 + v243;\n\tv241 = bone.worldY + v245;\n\tworldVertices[v229 @ X8_v4 (System.Int32)] = v241;\n\treturn;\n\tv8 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ComputeWorldVertices(Bone bone, float[] worldVertices, int offset, int stride = 2)
		{
			float[] array = Offset;
			int num = offset + 1;
			float num2 = bone.A * array[6];
			float num3 = bone.B * array[7];
			float num4 = num2 + num3;
			float num5 = bone.WorldX + num4;
			worldVertices[offset] = num5;
			float num6 = bone.C * array[6];
			float num7 = bone.D * array[7];
			int num8 = stride + offset;
			float num9 = num6 + num7;
			float num10 = bone.WorldY + num9;
			worldVertices[num] = num10;
			int num11 = num8 + 1;
			float num12 = bone.A * array[0];
			float num13 = bone.B * array[1];
			float num14 = num12 + num13;
			float num15 = bone.WorldX + num14;
			worldVertices[num8] = num15;
			float num16 = bone.C * array[0];
			float num17 = bone.D * array[1];
			int num18 = num8 + stride;
			float num19 = num16 + num17;
			float num20 = bone.WorldY + num19;
			worldVertices[num11] = num20;
			int num21 = num18 + 1;
			float num22 = bone.A * array[2];
			float num23 = bone.B * array[3];
			float num24 = num22 + num23;
			float num25 = bone.WorldX + num24;
			worldVertices[num18] = num25;
			float num26 = bone.C * array[2];
			float num27 = bone.D * array[3];
			int num28 = num18 + stride;
			float num29 = num26 + num27;
			float num30 = bone.WorldY + num29;
			worldVertices[num21] = num30;
			int num31 = num28 + 1;
			float num32 = bone.A * array[4];
			float num33 = bone.B * array[5];
			float num34 = num32 + num33;
			float num35 = bone.WorldX + num34;
			worldVertices[num28] = num35;
			float num36 = bone.C * array[4];
			float num37 = bone.D * array[5];
			float num38 = num36 + num37;
			float num39 = bone.WorldY + num38;
			worldVertices[num31] = num39;
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0x152FBF0", Offset = "0x152FBF0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.RegionAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B49]) = v37;\nL_0015:\n\tv40 = new Spine.RegionAttachment();\n\tSpine.RegionAttachment::.ctor(v40, this.<Name>k__BackingField);\n\tv40.<RendererObject>k__BackingField = this.<RendererObject>k__BackingField;\n\tv40.regionOffsetX = this.regionOffsetX;\n\tv40.regionOriginalWidth = this.regionOriginalWidth;\n\tv40.<Path>k__BackingField = this.<Path>k__BackingField;\n\tv40.scaleY = this.scaleY;\n\tv40.x = this.x;\n\tv40.width = this.width;\n\tSystem.Array::Copy(this.uvs, 0, v40.uvs, 0, 8);\n\tSystem.Array::Copy(this.offset, 0, v40.offset, 0, 8);\n\tv40.r = this.r;\n\treturn v40;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Attachment Copy()
		{
			RegionAttachment regionAttachment = new RegionAttachment(Name);
			regionAttachment.RendererObject = RendererObject;
			regionAttachment.RegionOffsetX = RegionOffsetX;
			regionAttachment.RegionOriginalWidth = RegionOriginalWidth;
			regionAttachment.Path = Path;
			regionAttachment.ScaleY = ScaleY;
			regionAttachment.X = X;
			regionAttachment.Width = Width;
			Array.Copy(UVs, 0, regionAttachment.UVs, 0, 8);
			Array.Copy(Offset, 0, regionAttachment.Offset, 0, 8);
			regionAttachment.R = R;
			return regionAttachment;
		}
	}
}
