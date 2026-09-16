using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200005A")]
	public class SkeletonData
	{
		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x10")]
		internal string name;

		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x18")]
		internal ExposedList<BoneData> bones;

		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x20")]
		internal ExposedList<SlotData> slots;

		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x28")]
		internal ExposedList<Skin> skins;

		[Token(Token = "0x400023E")]
		[FieldOffset(Offset = "0x30")]
		internal Skin defaultSkin;

		[Token(Token = "0x400023F")]
		[FieldOffset(Offset = "0x38")]
		internal ExposedList<EventData> events;

		[Token(Token = "0x4000240")]
		[FieldOffset(Offset = "0x40")]
		internal ExposedList<Animation> animations;

		[Token(Token = "0x4000241")]
		[FieldOffset(Offset = "0x48")]
		internal ExposedList<IkConstraintData> ikConstraints;

		[Token(Token = "0x4000242")]
		[FieldOffset(Offset = "0x50")]
		internal ExposedList<TransformConstraintData> transformConstraints;

		[Token(Token = "0x4000243")]
		[FieldOffset(Offset = "0x58")]
		internal ExposedList<PathConstraintData> pathConstraints;

		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x60")]
		internal float x;

		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x64")]
		internal float y;

		[Token(Token = "0x4000246")]
		[FieldOffset(Offset = "0x68")]
		internal float width;

		[Token(Token = "0x4000247")]
		[FieldOffset(Offset = "0x6C")]
		internal float height;

		[Token(Token = "0x4000248")]
		[FieldOffset(Offset = "0x70")]
		internal string version;

		[Token(Token = "0x4000249")]
		[FieldOffset(Offset = "0x78")]
		internal string hash;

		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x80")]
		internal float fps;

		[Token(Token = "0x400024B")]
		[FieldOffset(Offset = "0x88")]
		internal string imagesPath;

		[Token(Token = "0x400024C")]
		[FieldOffset(Offset = "0x90")]
		internal string audioPath;

		[Token(Token = "0x17000121")]
		public string Name
		{
			[Token(Token = "0x60003A5")]
			[Address(RVA = "0x1540A08", Offset = "0x1540A08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[Token(Token = "0x60003A6")]
			[Address(RVA = "0x1540A10", Offset = "0x1540A10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.name = value;\n\treturn;\n")]
			set
			{
				Name = value;
			}
		}

		[Token(Token = "0x17000122")]
		public ExposedList<BoneData> Bones
		{
			[Token(Token = "0x60003A7")]
			[Address(RVA = "0x1540A18", Offset = "0x1540A18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x17000123")]
		public ExposedList<SlotData> Slots
		{
			[Token(Token = "0x60003A8")]
			[Address(RVA = "0x1540A20", Offset = "0x1540A20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slots;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Slots;
			}
		}

		[Token(Token = "0x17000124")]
		public ExposedList<Skin> Skins
		{
			[Token(Token = "0x60003A9")]
			[Address(RVA = "0x1540A28", Offset = "0x1540A28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skins;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Skins;
			}
			[Token(Token = "0x60003AA")]
			[Address(RVA = "0x1540A30", Offset = "0x1540A30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skins = value;\n\treturn;\n")]
			set
			{
				Skins = value;
			}
		}

		[Token(Token = "0x17000125")]
		public Skin DefaultSkin
		{
			[Token(Token = "0x60003AB")]
			[Address(RVA = "0x1540A38", Offset = "0x1540A38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.defaultSkin;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultSkin;
			}
			[Token(Token = "0x60003AC")]
			[Address(RVA = "0x1540A40", Offset = "0x1540A40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.defaultSkin = value;\n\treturn;\n")]
			set
			{
				DefaultSkin = value;
			}
		}

		[Token(Token = "0x17000126")]
		public ExposedList<EventData> Events
		{
			[Token(Token = "0x60003AD")]
			[Address(RVA = "0x1540A48", Offset = "0x1540A48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.events;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Events;
			}
			[Token(Token = "0x60003AE")]
			[Address(RVA = "0x1540A50", Offset = "0x1540A50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.events = value;\n\treturn;\n")]
			set
			{
				Events = value;
			}
		}

		[Token(Token = "0x17000127")]
		public ExposedList<Animation> Animations
		{
			[Token(Token = "0x60003AF")]
			[Address(RVA = "0x1540A58", Offset = "0x1540A58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animations;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Animations;
			}
			[Token(Token = "0x60003B0")]
			[Address(RVA = "0x1540A60", Offset = "0x1540A60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.animations = value;\n\treturn;\n")]
			set
			{
				Animations = value;
			}
		}

		[Token(Token = "0x17000128")]
		public ExposedList<IkConstraintData> IkConstraints
		{
			[Token(Token = "0x60003B1")]
			[Address(RVA = "0x1540A68", Offset = "0x1540A68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ikConstraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IkConstraints;
			}
			[Token(Token = "0x60003B2")]
			[Address(RVA = "0x1540A70", Offset = "0x1540A70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ikConstraints = value;\n\treturn;\n")]
			set
			{
				IkConstraints = value;
			}
		}

		[Token(Token = "0x17000129")]
		public ExposedList<TransformConstraintData> TransformConstraints
		{
			[Token(Token = "0x60003B3")]
			[Address(RVA = "0x1540A78", Offset = "0x1540A78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.transformConstraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TransformConstraints;
			}
			[Token(Token = "0x60003B4")]
			[Address(RVA = "0x1540A80", Offset = "0x1540A80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.transformConstraints = value;\n\treturn;\n")]
			set
			{
				TransformConstraints = value;
			}
		}

		[Token(Token = "0x1700012A")]
		public ExposedList<PathConstraintData> PathConstraints
		{
			[Token(Token = "0x60003B5")]
			[Address(RVA = "0x1540A88", Offset = "0x1540A88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.pathConstraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PathConstraints;
			}
			[Token(Token = "0x60003B6")]
			[Address(RVA = "0x1540A90", Offset = "0x1540A90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.pathConstraints = value;\n\treturn;\n")]
			set
			{
				PathConstraints = value;
			}
		}

		[Token(Token = "0x1700012B")]
		public float X
		{
			[Token(Token = "0x60003B7")]
			[Address(RVA = "0x1540A98", Offset = "0x1540A98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.x;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return X;
			}
			[Token(Token = "0x60003B8")]
			[Address(RVA = "0x1540AA0", Offset = "0x1540AA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.x = value;\n\treturn;\n")]
			set
			{
				X = value;
			}
		}

		[Token(Token = "0x1700012C")]
		public float Y
		{
			[Token(Token = "0x60003B9")]
			[Address(RVA = "0x1540AA8", Offset = "0x1540AA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.y;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Y;
			}
			[Token(Token = "0x60003BA")]
			[Address(RVA = "0x1540AB0", Offset = "0x1540AB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.y = value;\n\treturn;\n")]
			set
			{
				Y = value;
			}
		}

		[Token(Token = "0x1700012D")]
		public float Width
		{
			[Token(Token = "0x60003BB")]
			[Address(RVA = "0x1540AB8", Offset = "0x1540AB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.width;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
			[Token(Token = "0x60003BC")]
			[Address(RVA = "0x1540AC0", Offset = "0x1540AC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.width = value;\n\treturn;\n")]
			set
			{
				Width = value;
			}
		}

		[Token(Token = "0x1700012E")]
		public float Height
		{
			[Token(Token = "0x60003BD")]
			[Address(RVA = "0x1540AC8", Offset = "0x1540AC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.height;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
			[Token(Token = "0x60003BE")]
			[Address(RVA = "0x1540AD0", Offset = "0x1540AD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.height = value;\n\treturn;\n")]
			set
			{
				Height = value;
			}
		}

		[Token(Token = "0x1700012F")]
		public string Version
		{
			[Token(Token = "0x60003BF")]
			[Address(RVA = "0x1540AD8", Offset = "0x1540AD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.version;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Version;
			}
			[Token(Token = "0x60003C0")]
			[Address(RVA = "0x1540AE0", Offset = "0x1540AE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.version = value;\n\treturn;\n")]
			set
			{
				Version = value;
			}
		}

		[Token(Token = "0x17000130")]
		public string Hash
		{
			[Token(Token = "0x60003C1")]
			[Address(RVA = "0x1540AE8", Offset = "0x1540AE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.hash;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Hash;
			}
			[Token(Token = "0x60003C2")]
			[Address(RVA = "0x1540AF0", Offset = "0x1540AF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hash = value;\n\treturn;\n")]
			set
			{
				Hash = value;
			}
		}

		[Token(Token = "0x17000131")]
		public string ImagesPath
		{
			[Token(Token = "0x60003C3")]
			[Address(RVA = "0x1540AF8", Offset = "0x1540AF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.imagesPath;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ImagesPath;
			}
			[Token(Token = "0x60003C4")]
			[Address(RVA = "0x1540B00", Offset = "0x1540B00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.imagesPath = value;\n\treturn;\n")]
			set
			{
				ImagesPath = value;
			}
		}

		[Token(Token = "0x17000132")]
		public string AudioPath
		{
			[Token(Token = "0x60003C5")]
			[Address(RVA = "0x1540B08", Offset = "0x1540B08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.audioPath;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudioPath;
			}
			[Token(Token = "0x60003C6")]
			[Address(RVA = "0x1540B10", Offset = "0x1540B10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.audioPath = value;\n\treturn;\n")]
			set
			{
				AudioPath = value;
			}
		}

		[Token(Token = "0x17000133")]
		public float Fps
		{
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0x1540B18", Offset = "0x1540B18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fps;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Fps;
			}
			[Token(Token = "0x60003C8")]
			[Address(RVA = "0x1540B20", Offset = "0x1540B20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fps = value;\n\treturn;\n")]
			set
			{
				Fps = value;
			}
		}

		[Token(Token = "0x60003C9")]
		[Address(RVA = "0x1540B28", Offset = "0x1540B28", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = boneName == 0;\n\tif (v12) goto L_0051;\n\tv14 = this.bones;\n\tv96 = v14.Count < 1;\n\tif (v96) goto L_FFFFFFFF;\n\tv112 = v14.Items;\nL_002B:\n\tv104 = v112[v108 @ X23_v8 (System.Int32)];\n\tv144 = System.String::op_Equality(v104.name, boneName);\n\tv257 = v144 == 0;\n\tv171 = ~v257;\n\tif (v171) goto L_004B;\n\tv108 = v108 + 1;\n\tv152 = v14.Count != v108;\n\tif (v152) goto L_002B;\nL_004B:\n\treturn v186;\n\tv137 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0051:\n\tv138 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v138, \"boneName\", \"boneName cannot be null.\");\n\tthrow v138;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneData FindBone(string boneName)
		{
			BoneData result;
			if (boneName != null)
			{
				ExposedList<BoneData> exposedList = Bones;
				if (exposedList.Count < 1)
				{
					goto IL_0105;
				}
				BoneData[] items = exposedList.Items;
				int num = 0;
				while (true)
				{
					BoneData boneData = items[num];
					bool flag = boneData.Name == boneName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_0105;
				}
				goto IL_0132;
			}
			ArgumentNullException ex = new ArgumentNullException("boneName", "boneName cannot be null.");
			throw ex;
			IL_0105:
			result = null;
			goto IL_0132;
			IL_0132:
			return result;
		}

		[Token(Token = "0x60003CA")]
		[Address(RVA = "0x1540C10", Offset = "0x1540C10", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = boneName == 0;\n\tif (v10) goto L_004F;\n\tv12 = this.bones;\n\tv92 = v12.Count < 1;\n\tif (v92) goto L_FFFFFFFF;\n\tv106 = v12.Items;\nL_002A:\n\tv127 = v106[v179 @ X20_v5 (System.Int32)];\n\tv138 = System.String::op_Equality(v127.name, boneName);\n\tv247 = v138 == 0;\n\tv164 = ~v247;\n\tif (v164) goto L_0049;\n\tv179 = v179 + 1;\n\tv145 = v12.Count != v179;\n\tif (v145) goto L_002A;\nL_0049:\n\treturn v179;\n\tv131 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_004F:\n\tv132 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v132, \"boneName\", \"boneName cannot be null.\");\n\tthrow v132;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindBoneIndex(string boneName)
		{
			int num;
			if (boneName != null)
			{
				ExposedList<BoneData> exposedList = Bones;
				if (exposedList.Count < 1)
				{
					goto IL_00f4;
				}
				BoneData[] items = exposedList.Items;
				num = 0;
				while (true)
				{
					BoneData boneData = items[num];
					if (boneData.Name == boneName)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00f4;
				}
				goto IL_0125;
			}
			ArgumentNullException ex = new ArgumentNullException("boneName", "boneName cannot be null.");
			throw ex;
			IL_00f4:
			num = -1;
			goto IL_0125;
			IL_0125:
			return num;
		}

		[Token(Token = "0x60003CB")]
		[Address(RVA = "0x1540CF8", Offset = "0x1540CF8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = slotName == 0;\n\tif (v12) goto L_0051;\n\tv14 = this.slots;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv109 = v14.Items;\n\tv107 = v109[v118 @ X23_v8 (System.Int32)];\n\tv159 = System.String::op_Equality(v107.name, slotName);\n\tv261 = v159 == 0;\n\tv186 = ~v261;\n\tif (v186) goto L_004B;\n\tv118 = v118 + 1;\n\tv168 = v14.Count != v118;\n\tif (v168) goto L_001B;\nL_004B:\n\treturn v198;\n\tv151 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0051:\n\tv152 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v152, \"slotName\", \"slotName cannot be null.\");\n\tthrow v152;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SlotData FindSlot(string slotName)
		{
			SlotData result;
			if (slotName != null)
			{
				ExposedList<SlotData> exposedList = Slots;
				if (exposedList.Count < 1)
				{
					goto IL_00f3;
				}
				int num = 0;
				while (true)
				{
					SlotData[] items = exposedList.Items;
					SlotData slotData = items[num];
					bool flag = slotData.Name == slotName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00f3;
				}
				goto IL_0120;
			}
			ArgumentNullException ex = new ArgumentNullException("slotName", "slotName cannot be null.");
			throw ex;
			IL_00f3:
			result = null;
			goto IL_0120;
			IL_0120:
			return result;
		}

		[Token(Token = "0x60003CC")]
		[Address(RVA = "0x1540DE0", Offset = "0x1540DE0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = slotName == 0;\n\tif (v10) goto L_004F;\n\tv12 = this.slots;\n\tv94 = v12.Count < 1;\n\tif (v94) goto L_FFFFFFFF;\nL_001A:\n\tv102 = v12.Items;\n\tv103 = v102[v193 @ X20_v5 (System.Int32)];\n\tv152 = System.String::op_Equality(v103.name, slotName);\n\tv251 = v152 == 0;\n\tv178 = ~v251;\n\tif (v178) goto L_0049;\n\tv193 = v193 + 1;\n\tv160 = v12.Count != v193;\n\tif (v160) goto L_001A;\nL_0049:\n\treturn v193;\n\tv144 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_004F:\n\tv145 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v145, \"slotName\", \"slotName cannot be null.\");\n\tthrow v145;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindSlotIndex(string slotName)
		{
			int num;
			if (slotName != null)
			{
				ExposedList<SlotData> exposedList = Slots;
				if (exposedList.Count < 1)
				{
					goto IL_00e2;
				}
				num = 0;
				while (true)
				{
					SlotData[] items = exposedList.Items;
					SlotData slotData = items[num];
					if (slotData.Name == slotName)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00e2;
				}
				goto IL_0113;
			}
			ArgumentNullException ex = new ArgumentNullException("slotName", "slotName cannot be null.");
			throw ex;
			IL_00e2:
			num = -1;
			goto IL_0113;
			IL_0113:
			return num;
		}

		[Token(Token = "0x60003CD")]
		[Address(RVA = "0x1540EC8", Offset = "0x1540EC8", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, skinName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, skinName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, skinName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv96 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, skinName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A37B99]) = v39;\nL_001C:\n\tv40 = 0;\n\tv43 = v81 == 0;\n\tif (v43) goto L_004E;\n\tv48 = this.skins == 0;\n\tif (v48) goto L_0062;\n\tv76 = Spine.ExposedList`1<Spine.Skin>::GetEnumerator(this.skins);\nL_002F:\n\tv106 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv111 = v106 == 0;\n\tif (v111) goto L_FFFFFFFF;\n\tv60 = 0;\n\tv101 = System.String::op_Equality(v60.name, v81);\n\tv103 = v101 == 0;\n\tif (v103) goto L_002F;\n\tgoto L_0041;\nL_0041:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0049:\n\treturn v180;\n\tthrow System.NullReferenceException;\nL_004E:\n\tv94 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v94, \"skinName\", \"skinName cannot be null.\");\n\tthrow v94;\nL_0062:\n\tv93 = new System.NullReferenceException();\n\tgoto L_006F;\n\tgoto L_006F;\nL_006F:\n\tv122 = v81 != 1;\n\tif (v122) goto L_007D;\n\tv128 = 0x1854E70(v93, v81, methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv180 = *([v128 @ X0_v13]);\n\tv148 = 0x1854E80(v128, v81, methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv134 = *([v128 @ X0_v13]) == 0;\n\tif (v134) goto L_0049;\n\tthrow System.OutOfMemoryException;\nL_007D:\n\tgoto L_0081;\n\tX19 = X0;\nL_0081:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0088;\n\tv215 = 0xBD3CD0(v93, *([v92 @ X21_v2 (Il2CppMethodInfo)]), methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0088:\n\tv218 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v218, *([v92 @ X21_v2 (Il2CppMethodInfo)]), methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Skin FindSkin(string skinName)
		{
			//IL_00e8: Expected O, but got I4
			//IL_00f1: Expected I, but got O
			//IL_00f7: Expected O, but got I
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			string text = default(string);
			bool flag = text == null;
			nint num = 0;
			if (!flag)
			{
				bool flag2 = Skins == null;
				num = 27488256;
				Skin result;
				if (!flag2)
				{
					ExposedList<Skin>.Enumerator enumerator2 = Skins.GetEnumerator();
					while (true)
					{
						if (enumerator.MoveNext())
						{
							Skin skin = null;
							if (skin.Name == text)
							{
								result = null;
								break;
							}
							continue;
						}
						result = null;
						break;
					}
					enumerator.Dispose();
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					if ((nint)text != 1)
					{
						enumerator.Dispose();
						OutOfMemoryException ex2 = new OutOfMemoryException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
						Skin result2 = default(Skin);
						return result2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					object obj = default(object);
					result = (Skin)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					enumerator.Dispose();
					if (obj != null)
					{
						throw new OutOfMemoryException();
					}
				}
				return result;
			}
			ArgumentNullException ex3 = new ArgumentNullException("skinName", "skinName cannot be null.");
			object obj2 = 0;
			nint num2 = unchecked((nint)"skinName cannot be null.");
			text = (string)0;
			throw ex3;
		}

		[Token(Token = "0x60003CE")]
		[Address(RVA = "0x1541084", Offset = "0x1541084", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, eventDataName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, eventDataName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, eventDataName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv96 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, eventDataName, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A37B9A]) = v39;\nL_001C:\n\tv40 = 0;\n\tv43 = v81 == 0;\n\tif (v43) goto L_004E;\n\tv48 = this.events == 0;\n\tif (v48) goto L_0062;\n\tv76 = Spine.ExposedList`1<Spine.EventData>::GetEnumerator(this.events);\nL_002F:\n\tv106 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv111 = v106 == 0;\n\tif (v111) goto L_FFFFFFFF;\n\tv60 = 0;\n\tv101 = System.String::op_Equality(v60.name, v81);\n\tv103 = v101 == 0;\n\tif (v103) goto L_002F;\n\tgoto L_0041;\nL_0041:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0049:\n\treturn v180;\n\tthrow System.NullReferenceException;\nL_004E:\n\tv94 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v94, \"eventDataName\", \"eventDataName cannot be null.\");\n\tthrow v94;\nL_0062:\n\tv93 = new System.NullReferenceException();\n\tgoto L_006F;\n\tgoto L_006F;\nL_006F:\n\tv122 = v81 != 1;\n\tif (v122) goto L_007D;\n\tv128 = 0x1854E70(v93, v81, methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv180 = *([v128 @ X0_v13]);\n\tv148 = 0x1854E80(v128, v81, methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv134 = *([v128 @ X0_v13]) == 0;\n\tif (v134) goto L_0049;\n\tthrow System.OutOfMemoryException;\nL_007D:\n\tgoto L_0081;\n\tX19 = X0;\nL_0081:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0088;\n\tv215 = 0xBD3CD0(v93, *([v92 @ X21_v2 (Il2CppMethodInfo)]), methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0088:\n\tv218 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v218, *([v92 @ X21_v2 (Il2CppMethodInfo)]), methodInfo, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EventData FindEvent(string eventDataName)
		{
			//IL_00e8: Expected O, but got I4
			//IL_00f1: Expected I, but got O
			//IL_00f7: Expected O, but got I
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			string text = default(string);
			bool flag = text == null;
			nint num = 0;
			if (!flag)
			{
				bool flag2 = Events == null;
				num = 27488256;
				EventData result;
				if (!flag2)
				{
					ExposedList<EventData>.Enumerator enumerator2 = Events.GetEnumerator();
					while (true)
					{
						if (enumerator.MoveNext())
						{
							EventData eventData = null;
							if (eventData.Name == text)
							{
								result = null;
								break;
							}
							continue;
						}
						result = null;
						break;
					}
					enumerator.Dispose();
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					if ((nint)text != 1)
					{
						enumerator.Dispose();
						OutOfMemoryException ex2 = new OutOfMemoryException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
						EventData result2 = default(EventData);
						return result2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					object obj = default(object);
					result = (EventData)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					enumerator.Dispose();
					if (obj != null)
					{
						throw new OutOfMemoryException();
					}
				}
				return result;
			}
			ArgumentNullException ex3 = new ArgumentNullException("eventDataName", "eventDataName cannot be null.");
			object obj2 = 0;
			nint num2 = unchecked((nint)"eventDataName cannot be null.");
			text = (string)0;
			throw ex3;
		}

		[Token(Token = "0x60003CF")]
		[Address(RVA = "0x1541240", Offset = "0x1541240", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = animationName == 0;\n\tif (v12) goto L_0051;\n\tv14 = this.animations;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv109 = v14.Items;\n\tv107 = v109[v118 @ X23_v8 (System.Int32)];\n\tv159 = System.String::op_Equality(v107.name, animationName);\n\tv261 = v159 == 0;\n\tv186 = ~v261;\n\tif (v186) goto L_004B;\n\tv118 = v118 + 1;\n\tv168 = v14.Count != v118;\n\tif (v168) goto L_001B;\nL_004B:\n\treturn v198;\n\tv151 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0051:\n\tv152 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v152, \"animationName\", \"animationName cannot be null.\");\n\tthrow v152;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Animation FindAnimation(string animationName)
		{
			Animation result;
			if (animationName != null)
			{
				ExposedList<Animation> exposedList = Animations;
				if (exposedList.Count < 1)
				{
					goto IL_00f3;
				}
				int num = 0;
				while (true)
				{
					Animation[] items = exposedList.Items;
					Animation animation = items[num];
					bool flag = animation.Name == animationName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00f3;
				}
				goto IL_0120;
			}
			ArgumentNullException ex = new ArgumentNullException("animationName", "animationName cannot be null.");
			throw ex;
			IL_00f3:
			result = null;
			goto IL_0120;
			IL_0120:
			return result;
		}

		[Token(Token = "0x60003D0")]
		[Address(RVA = "0x1541328", Offset = "0x1541328", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = constraintName == 0;\n\tif (v12) goto L_0051;\n\tv14 = this.ikConstraints;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv109 = v14.Items;\n\tv107 = v109[v118 @ X23_v8 (System.Int32)];\n\tv159 = System.String::op_Equality(v107.name, constraintName);\n\tv261 = v159 == 0;\n\tv186 = ~v261;\n\tif (v186) goto L_004B;\n\tv118 = v118 + 1;\n\tv168 = v14.Count != v118;\n\tif (v168) goto L_001B;\nL_004B:\n\treturn v198;\n\tv151 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0051:\n\tv152 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v152, \"constraintName\", \"constraintName cannot be null.\");\n\tthrow v152;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IkConstraintData FindIkConstraint(string constraintName)
		{
			IkConstraintData result;
			if (constraintName != null)
			{
				ExposedList<IkConstraintData> exposedList = IkConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_00f3;
				}
				int num = 0;
				while (true)
				{
					IkConstraintData[] items = exposedList.Items;
					IkConstraintData ikConstraintData = items[num];
					bool flag = ikConstraintData.Name == constraintName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00f3;
				}
				goto IL_0120;
			}
			ArgumentNullException ex = new ArgumentNullException("constraintName", "constraintName cannot be null.");
			throw ex;
			IL_00f3:
			result = null;
			goto IL_0120;
			IL_0120:
			return result;
		}

		[Token(Token = "0x60003D1")]
		[Address(RVA = "0x1541410", Offset = "0x1541410", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = constraintName == 0;\n\tif (v12) goto L_0051;\n\tv14 = this.transformConstraints;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv109 = v14.Items;\n\tv107 = v109[v118 @ X23_v8 (System.Int32)];\n\tv159 = System.String::op_Equality(v107.name, constraintName);\n\tv261 = v159 == 0;\n\tv186 = ~v261;\n\tif (v186) goto L_004B;\n\tv118 = v118 + 1;\n\tv168 = v14.Count != v118;\n\tif (v168) goto L_001B;\nL_004B:\n\treturn v198;\n\tv151 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0051:\n\tv152 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v152, \"constraintName\", \"constraintName cannot be null.\");\n\tthrow v152;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformConstraintData FindTransformConstraint(string constraintName)
		{
			TransformConstraintData result;
			if (constraintName != null)
			{
				ExposedList<TransformConstraintData> exposedList = TransformConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_00f3;
				}
				int num = 0;
				while (true)
				{
					TransformConstraintData[] items = exposedList.Items;
					TransformConstraintData transformConstraintData = items[num];
					bool flag = transformConstraintData.Name == constraintName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00f3;
				}
				goto IL_0120;
			}
			ArgumentNullException ex = new ArgumentNullException("constraintName", "constraintName cannot be null.");
			throw ex;
			IL_00f3:
			result = null;
			goto IL_0120;
			IL_0120:
			return result;
		}

		[Token(Token = "0x60003D2")]
		[Address(RVA = "0x15414F8", Offset = "0x15414F8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = constraintName == 0;\n\tif (v12) goto L_0053;\n\tv14 = this.pathConstraints;\n\tv98 = v14.Count < 1;\n\tif (v98) goto L_FFFFFFFF;\nL_001B:\n\tv110 = v14.Items;\n\tv108 = v110[v119 @ X23_v8 (System.Int32)];\n\tv161 = System.String::Equals(v108.name, constraintName);\n\tv262 = v161 == 0;\n\tv188 = ~v262;\n\tif (v188) goto L_004D;\n\tv119 = v119 + 1;\n\tv170 = v14.Count != v119;\n\tif (v170) goto L_001B;\nL_004D:\n\treturn v200;\n\tv153 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0053:\n\tv154 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v154, \"constraintName\", \"constraintName cannot be null.\");\n\tthrow v154;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathConstraintData FindPathConstraint(string constraintName)
		{
			PathConstraintData result;
			if (constraintName != null)
			{
				ExposedList<PathConstraintData> exposedList = PathConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_00f3;
				}
				int num = 0;
				while (true)
				{
					PathConstraintData[] items = exposedList.Items;
					PathConstraintData pathConstraintData = items[num];
					bool flag = pathConstraintData.Name.Equals(constraintName);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = items[num];
					if (flag3)
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00f3;
				}
				goto IL_0120;
			}
			ArgumentNullException ex = new ArgumentNullException("constraintName", "constraintName cannot be null.");
			throw ex;
			IL_00f3:
			result = null;
			goto IL_0120;
			IL_0120:
			return result;
		}

		[Token(Token = "0x60003D3")]
		[Address(RVA = "0x15415E4", Offset = "0x15415E4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = pathConstraintName == 0;\n\tif (v10) goto L_0051;\n\tv12 = this.pathConstraints;\n\tv94 = v12.Count < 1;\n\tif (v94) goto L_FFFFFFFF;\nL_001A:\n\tv103 = v12.Items;\n\tv104 = v103[v195 @ X20_v5 (System.Int32)];\n\tv154 = System.String::Equals(v104.name, pathConstraintName);\n\tv252 = v154 == 0;\n\tv180 = ~v252;\n\tif (v180) goto L_004B;\n\tv195 = v195 + 1;\n\tv162 = v12.Count != v195;\n\tif (v162) goto L_001A;\nL_004B:\n\treturn v195;\n\tv146 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0051:\n\tv147 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v147, \"pathConstraintName\", \"pathConstraintName cannot be null.\");\n\tthrow v147;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindPathConstraintIndex(string pathConstraintName)
		{
			int num;
			if (pathConstraintName != null)
			{
				ExposedList<PathConstraintData> exposedList = PathConstraints;
				if (exposedList.Count < 1)
				{
					goto IL_00e2;
				}
				num = 0;
				while (true)
				{
					PathConstraintData[] items = exposedList.Items;
					PathConstraintData pathConstraintData = items[num];
					if (pathConstraintData.Name.Equals(pathConstraintName))
					{
						break;
					}
					num++;
					if (exposedList.Count != num)
					{
						continue;
					}
					goto IL_00e2;
				}
				goto IL_0113;
			}
			ArgumentNullException ex = new ArgumentNullException("pathConstraintName", "pathConstraintName cannot be null.");
			throw ex;
			IL_00e2:
			num = -1;
			goto IL_0113;
			IL_0113:
			return num;
		}

		[Token(Token = "0x60003D4")]
		[Address(RVA = "0x15416D0", Offset = "0x15416D0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.name == 0;\n\tif (v2) goto L_0006;\n\treturn this.name;\nL_0006:\n\treturnVal2 = System.Object::ToString(this);\n\treturn returnVal2;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			if (Name != null)
			{
				return Name;
			}
			return base.ToString();
		}

		[Token(Token = "0x60003D5")]
		[Address(RVA = "0x15416E8", Offset = "0x15416E8", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0059;\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv104 = Il2CppMethodInfo;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv109 = Spine.ExposedList`1<Spine.Animation>;\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv114 = Spine.ExposedList`1<Spine.EventData>;\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv121 = Spine.ExposedList`1<Spine.TransformConstraintData>;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv128 = Spine.ExposedList`1<Spine.BoneData>;\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv135 = Spine.ExposedList`1<Spine.IkConstraintData>;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv142 = Spine.ExposedList`1<Spine.Skin>;\n\tv143 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv149 = Spine.ExposedList`1<Spine.PathConstraintData>;\n\tv150 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv156 = Spine.ExposedList`1<Spine.SlotData>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v156, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37B9B]) = v70;\nL_0059:\n\tv72 = new Spine.ExposedList`1<Spine.BoneData>();\n\tSpine.ExposedList`1<Spine.BoneData>::.ctor(v72);\n\tthis.bones = v72;\n\tv82 = new Spine.ExposedList`1<Spine.SlotData>();\n\tSpine.ExposedList`1<Spine.SlotData>::.ctor(v82);\n\tthis.slots = v82;\n\tv92 = new Spine.ExposedList`1<Spine.Skin>();\n\tSpine.ExposedList`1<Spine.Skin>::.ctor(v92);\n\tthis.skins = v92;\n\tv102 = new Spine.ExposedList`1<Spine.EventData>();\n\tSpine.ExposedList`1<Spine.EventData>::.ctor(v102);\n\tthis.events = v102;\n\tv112 = new Spine.ExposedList`1<Spine.Animation>();\n\tSpine.ExposedList`1<Spine.Animation>::.ctor(v112);\n\tthis.animations = v112;\n\tv126 = new Spine.ExposedList`1<Spine.IkConstraintData>();\n\tSpine.ExposedList`1<Spine.IkConstraintData>::.ctor(v126);\n\tthis.ikConstraints = v126;\n\tv140 = new Spine.ExposedList`1<Spine.TransformConstraintData>();\n\tSpine.ExposedList`1<Spine.TransformConstraintData>::.ctor(v140);\n\tthis.transformConstraints = v140;\n\tv154 = new Spine.ExposedList`1<Spine.PathConstraintData>();\n\tSpine.ExposedList`1<Spine.PathConstraintData>::.ctor(v154);\n\tthis.pathConstraints = v154;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonData()
		{
			ExposedList<BoneData> exposedList = new ExposedList<BoneData>();
			bones = exposedList;
			ExposedList<SlotData> exposedList2 = new ExposedList<SlotData>();
			slots = exposedList2;
			ExposedList<Skin> exposedList3 = new ExposedList<Skin>();
			Skins = exposedList3;
			ExposedList<EventData> exposedList4 = new ExposedList<EventData>();
			Events = exposedList4;
			ExposedList<Animation> exposedList5 = new ExposedList<Animation>();
			Animations = exposedList5;
			ExposedList<IkConstraintData> exposedList6 = new ExposedList<IkConstraintData>();
			IkConstraints = exposedList6;
			ExposedList<TransformConstraintData> exposedList7 = new ExposedList<TransformConstraintData>();
			TransformConstraints = exposedList7;
			ExposedList<PathConstraintData> exposedList8 = new ExposedList<PathConstraintData>();
			PathConstraints = exposedList8;
		}
	}
}
