using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000060")]
	public class Slot
	{
		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x10")]
		internal SlotData data;

		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x18")]
		internal Bone bone;

		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x20")]
		internal float r;

		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x24")]
		internal float g;

		[Token(Token = "0x4000262")]
		[FieldOffset(Offset = "0x28")]
		internal float b;

		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x2C")]
		internal float a;

		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x30")]
		internal float r2;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x34")]
		internal float g2;

		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x38")]
		internal float b2;

		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x3C")]
		internal bool hasSecondColor;

		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x40")]
		internal Attachment attachment;

		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x48")]
		internal float attachmentTime;

		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x50")]
		internal ExposedList<float> deform;

		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x58")]
		internal int attachmentState;

		[Token(Token = "0x1700013C")]
		public SlotData Data
		{
			[Token(Token = "0x6000401")]
			[Address(RVA = "0x154E344", Offset = "0x154E344", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x1700013D")]
		public Bone Bone
		{
			[Token(Token = "0x6000402")]
			[Address(RVA = "0x154E34C", Offset = "0x154E34C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bone;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bone;
			}
		}

		[Token(Token = "0x1700013E")]
		public Skeleton Skeleton
		{
			[Token(Token = "0x6000403")]
			[Address(RVA = "0x154E354", Offset = "0x154E354", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.bone;\n\treturn v2.skeleton;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Bone bone = Bone;
				return bone.Skeleton;
			}
		}

		[Token(Token = "0x1700013F")]
		public float R
		{
			[Token(Token = "0x6000404")]
			[Address(RVA = "0x154E370", Offset = "0x154E370", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R;
			}
			[Token(Token = "0x6000405")]
			[Address(RVA = "0x154E378", Offset = "0x154E378", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r = value;\n\treturn;\n")]
			set
			{
				R = value;
			}
		}

		[Token(Token = "0x17000140")]
		public float G
		{
			[Token(Token = "0x6000406")]
			[Address(RVA = "0x154E380", Offset = "0x154E380", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G;
			}
			[Token(Token = "0x6000407")]
			[Address(RVA = "0x154E388", Offset = "0x154E388", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g = value;\n\treturn;\n")]
			set
			{
				G = value;
			}
		}

		[Token(Token = "0x17000141")]
		public float B
		{
			[Token(Token = "0x6000408")]
			[Address(RVA = "0x154E390", Offset = "0x154E390", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B;
			}
			[Token(Token = "0x6000409")]
			[Address(RVA = "0x154E398", Offset = "0x154E398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b = value;\n\treturn;\n")]
			set
			{
				B = value;
			}
		}

		[Token(Token = "0x17000142")]
		public float A
		{
			[Token(Token = "0x600040A")]
			[Address(RVA = "0x154E3A0", Offset = "0x154E3A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.a;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return A;
			}
			[Token(Token = "0x600040B")]
			[Address(RVA = "0x154E3A8", Offset = "0x154E3A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a = value;\n\treturn;\n")]
			set
			{
				A = value;
			}
		}

		[Token(Token = "0x17000143")]
		public float R2
		{
			[Token(Token = "0x600040D")]
			[Address(RVA = "0x154E478", Offset = "0x154E478", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.r2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return R2;
			}
			[Token(Token = "0x600040E")]
			[Address(RVA = "0x154E480", Offset = "0x154E480", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.r2 = value;\n\treturn;\n")]
			set
			{
				R2 = value;
			}
		}

		[Token(Token = "0x17000144")]
		public float G2
		{
			[Token(Token = "0x600040F")]
			[Address(RVA = "0x154E488", Offset = "0x154E488", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.g2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return G2;
			}
			[Token(Token = "0x6000410")]
			[Address(RVA = "0x154E490", Offset = "0x154E490", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.g2 = value;\n\treturn;\n")]
			set
			{
				G2 = value;
			}
		}

		[Token(Token = "0x17000145")]
		public float B2
		{
			[Token(Token = "0x6000411")]
			[Address(RVA = "0x154E498", Offset = "0x154E498", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.b2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return B2;
			}
			[Token(Token = "0x6000412")]
			[Address(RVA = "0x154E4A0", Offset = "0x154E4A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.b2 = value;\n\treturn;\n")]
			set
			{
				B2 = value;
			}
		}

		[Token(Token = "0x17000146")]
		public bool HasSecondColor
		{
			[Token(Token = "0x6000413")]
			[Address(RVA = "0x154E4A8", Offset = "0x154E4A8", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\treturn v2.hasSecondColor;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				SlotData slotData = Data;
				return slotData.HasSecondColor;
			}
			[Token(Token = "0x6000414")]
			[Address(RVA = "0x154E4C4", Offset = "0x154E4C4", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\tv2.hasSecondColor = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				SlotData slotData = Data;
				slotData.hasSecondColor = value;
			}
		}

		[Token(Token = "0x17000147")]
		public Attachment Attachment
		{
			[Token(Token = "0x6000416")]
			[Address(RVA = "0x154E590", Offset = "0x154E590", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Attachment;
			}
			[Token(Token = "0x6000417")]
			[Address(RVA = "0x154DE98", Offset = "0x154DE98", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37BBC]) = v36;\nL_0017:\n\tv42 = this.attachment == value;\n\tif (v42) goto L_0039;\n\tv47 = this.bone;\n\tthis.attachment = value;\n\tv53 = v47.skeleton;\n\tthis.attachmentTime = v53.time;\n\tSpine.ExposedList`1<System.Single>::Clear(this.deform, 0);\n\treturn;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Attachment != value)
				{
					Bone bone = Bone;
					attachment = value;
					Skeleton skeleton = bone.Skeleton;
					attachmentTime = skeleton.Time;
					Deform.Clear(clearArray: false);
				}
			}
		}

		[Token(Token = "0x17000148")]
		public float AttachmentTime
		{
			[Token(Token = "0x6000418")]
			[Address(RVA = "0x154E598", Offset = "0x154E598", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.bone;\n\tv5 = v2.skeleton;\n\treturnVal1 = v5.time - this.attachmentTime;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Bone bone = Bone;
				Skeleton skeleton = bone.Skeleton;
				return skeleton.Time - attachmentTime;
			}
			[Token(Token = "0x6000419")]
			[Address(RVA = "0x154E5C4", Offset = "0x154E5C4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.bone;\n\tv5 = v2.skeleton;\n\tv26 = v5.time - value;\n\tthis.attachmentTime = v26;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Bone bone = Bone;
				Skeleton skeleton = bone.Skeleton;
				float num = skeleton.Time - value;
				attachmentTime = num;
			}
		}

		[Token(Token = "0x17000149")]
		public ExposedList<float> Deform
		{
			[Token(Token = "0x600041A")]
			[Address(RVA = "0x154E5F0", Offset = "0x154E5F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.deform;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Deform;
			}
			[Token(Token = "0x600041B")]
			[Address(RVA = "0x154E5F8", Offset = "0x154E5F8", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.deform == 0;\n\tif (v8) goto L_0010;\n\tthis.deform = value;\n\treturn;\nL_0010:\n\tv43 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v43, \"deform\", \"deform cannot be null.\");\n\tthrow v43;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Deform != null)
				{
					deform = value;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException("deform", "deform cannot be null.");
				throw ex;
			}
		}

		[Token(Token = "0x60003FF")]
		[Address(RVA = "0x154E000", Offset = "0x154E000", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, data, bone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = Spine.ExposedList`1<System.Single>;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, data, bone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37BB8]) = v48;\nL_001E:\n\tv50 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v50);\n\tthis.deform = v50;\n\tSystem.Object::.ctor(this);\n\tv57 = data == 0;\n\tif (v57) goto L_003F;\n\tv58 = bone == 0;\n\tif (v58) goto L_004B;\n\tthis.data = data;\n\tthis.bone = bone;\n\tv63 = ~data.hasSecondColor;\n\tif (v63) goto L_003A;\n\tthis.b2 = 0f;\n\tthis.r2 = 0f;\nL_003A:\n\tSpine.Slot::SetToSetupPose(this);\n\treturn;\nL_003F:\n\tv67 = new System.ArgumentNullException();\n\tgoto L_0058;\nL_004B:\n\tv76 = new System.ArgumentNullException();\nL_0058:\n\tSystem.ArgumentNullException::.ctor(v100, v102, v111);\n\tthrow v100;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Slot(SlotData data, Bone bone)
		{
			ExposedList<float> exposedList = new ExposedList<float>();
			deform = exposedList;
			ArgumentNullException ex2;
			if (data != null)
			{
				if (bone != null)
				{
					this.data = data;
					this.bone = bone;
					if (data.HasSecondColor)
					{
						B2 = 0f;
						R2 = 0f;
					}
					SetToSetupPose();
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "bone cannot be null.";
				ex2 = ex;
				string text2 = "bone";
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "data cannot be null.";
				ex2 = ex3;
				string text2 = "data";
			}
			throw ex2;
		}

		[Token(Token = "0x6000400")]
		[Address(RVA = "0x154E1B0", Offset = "0x154E1B0", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, slot, bone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, slot, bone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = Spine.ExposedList`1<System.Single>;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, slot, bone, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37BB9]) = v48;\nL_0021:\n\tv50 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v50);\n\tthis.deform = v50;\n\tSystem.Object::.ctor(this);\n\tv60 = slot == 0;\n\tif (v60) goto L_0055;\n\tv61 = bone == 0;\n\tif (v61) goto L_0061;\n\tthis.data = slot.data;\n\tthis.bone = bone;\n\tthis.r = slot.r;\n\tv68 = ~slot.hasSecondColor;\n\tif (v68) goto L_FFFFFFFF;\n\tv83 = slot.r2;\n\tv82 = slot.b2;\n\tgoto L_003A;\nL_003A:\n\tthis.b2 = v82;\n\tthis.r2 = v83;\n\tthis.hasSecondColor = slot.hasSecondColor;\n\tthis.attachment = slot.attachment;\n\tthis.attachmentTime = slot.attachmentTime;\n\tSpine.ExposedList`1<System.Single>::AddRange(this.deform, slot.deform);\n\treturn;\nL_0055:\n\tv72 = new System.ArgumentNullException();\n\tgoto L_006E;\nL_0061:\n\tv77 = new System.ArgumentNullException();\nL_006E:\n\tSystem.ArgumentNullException::.ctor(v121, v119, v127);\n\tthrow v121;\n\tthrow System.NullReferenceException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Slot(Slot slot, Bone bone)
		{
			ExposedList<float> exposedList = new ExposedList<float>();
			deform = exposedList;
			ArgumentNullException ex2;
			if (slot != null)
			{
				if (bone != null)
				{
					data = slot.Data;
					this.bone = bone;
					R = slot.R;
					float num;
					float num2;
					if (slot.hasSecondColor)
					{
						num = slot.R2;
						num2 = slot.B2;
					}
					else
					{
						num2 = 0f;
						num = 0f;
					}
					B2 = num2;
					R2 = num;
					hasSecondColor = slot.hasSecondColor;
					attachment = slot.Attachment;
					attachmentTime = slot.attachmentTime;
					Deform.AddRange(slot.Deform);
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "bone cannot be null.";
				string text2 = "bone";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "slot cannot be null.";
				string text2 = "slot";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x600040C")]
		[Address(RVA = "0x154E3B0", Offset = "0x154E3B0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = Spine.MathUtils;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37BBA]) = v39;\nL_0019:\n\tgoto L_001F;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_001F:\n\tv51 = Spine.MathUtils::Clamp(this.r, 0f, 1f);\n\tthis.r = v51;\n\tv57 = Spine.MathUtils::Clamp(this.g, 0f, 1f);\n\tthis.g = v57;\n\tv63 = Spine.MathUtils::Clamp(this.b, 0f, 1f);\n\tthis.b = v63;\n\tv69 = Spine.MathUtils::Clamp(this.a, 0f, 1f);\n\tthis.a = v69;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClampColor()
		{
			float num = MathUtils.Clamp(R, 0f, 1f);
			R = num;
			float num2 = MathUtils.Clamp(G, 0f, 1f);
			G = num2;
			float num3 = MathUtils.Clamp(B, 0f, 1f);
			B = num3;
			float num4 = MathUtils.Clamp(A, 0f, 1f);
			A = num4;
		}

		[Token(Token = "0x6000415")]
		[Address(RVA = "0x154E4E4", Offset = "0x154E4E4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = Spine.MathUtils;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37BBB]) = v39;\nL_0019:\n\tgoto L_001F;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_001F:\n\tv51 = Spine.MathUtils::Clamp(this.r2, 0f, 1f);\n\tthis.r2 = v51;\n\tv57 = Spine.MathUtils::Clamp(this.g2, 0f, 1f);\n\tthis.g2 = v57;\n\tv63 = Spine.MathUtils::Clamp(this.b2, 0f, 1f);\n\tthis.b2 = v63;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClampSecondColor()
		{
			float num = MathUtils.Clamp(R2, 0f, 1f);
			R2 = num;
			float num2 = MathUtils.Clamp(G2, 0f, 1f);
			G2 = num2;
			float num3 = MathUtils.Clamp(B2, 0f, 1f);
			B2 = num3;
		}

		[Token(Token = "0x600041C")]
		[Address(RVA = "0x154E13C", Offset = "0x154E13C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.data;\n\tthis.r = v4.r;\n\tv10 = ~v4.hasSecondColor;\n\tif (v10) goto L_0011;\n\tthis.r2 = v4.r2;\n\tthis.b2 = v4.b2;\nL_0011:\n\tv42 = v4.attachmentName == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv18 = this.bone;\n\tthis.attachment = 0;\n\tv63 = Spine.Skeleton::GetAttachment(v18.skeleton, v4.index, v4.attachmentName);\n\tgoto L_0024;\nL_0024:\n\tSpine.Slot::set_Attachment(this, v50);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToSetupPose()
		{
			SlotData slotData = Data;
			R = slotData.R;
			if (slotData.HasSecondColor)
			{
				R2 = slotData.R2;
				B2 = slotData.B2;
			}
			Attachment attachment2;
			if (slotData.AttachmentName != null)
			{
				Bone bone = Bone;
				this.attachment = null;
				Attachment attachment = bone.Skeleton.GetAttachment(slotData.Index, slotData.AttachmentName);
				attachment2 = attachment;
			}
			else
			{
				attachment2 = null;
			}
			Attachment = attachment2;
		}

		[Token(Token = "0x600041D")]
		[Address(RVA = "0x154E674", Offset = "0x154E674", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\treturn v2.name;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			SlotData slotData = Data;
			return slotData.Name;
		}
	}
}
