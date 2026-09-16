using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000003")]
public static class Oni
{
	[Token(Token = "0x2000082")]
	public enum ConstraintType
	{
		[Token(Token = "0x400024F")]
		Tether = 0,
		[Token(Token = "0x4000250")]
		Volume = 1,
		[Token(Token = "0x4000251")]
		Chain = 2,
		[Token(Token = "0x4000252")]
		Bending = 3,
		[Token(Token = "0x4000253")]
		Distance = 4,
		[Token(Token = "0x4000254")]
		ShapeMatching = 5,
		[Token(Token = "0x4000255")]
		BendTwist = 6,
		[Token(Token = "0x4000256")]
		StretchShear = 7,
		[Token(Token = "0x4000257")]
		Pin = 8,
		[Token(Token = "0x4000258")]
		ParticleCollision = 9,
		[Token(Token = "0x4000259")]
		Density = 10,
		[Token(Token = "0x400025A")]
		Collision = 11,
		[Token(Token = "0x400025B")]
		Skin = 12,
		[Token(Token = "0x400025C")]
		Aerodynamics = 13,
		[Token(Token = "0x400025D")]
		Stitch = 14,
		[Token(Token = "0x400025E")]
		ParticleFriction = 15,
		[Token(Token = "0x400025F")]
		Friction = 16
	}

	[Flags]
	[Token(Token = "0x2000083")]
	public enum ParticleFlags
	{
		[Token(Token = "0x4000261")]
		SelfCollide = 0x1000000,
		[Token(Token = "0x4000262")]
		Fluid = 0x2000000,
		[Token(Token = "0x4000263")]
		OneSided = 0x4000000
	}

	[Token(Token = "0x2000084")]
	public enum ShapeType
	{
		[Token(Token = "0x4000265")]
		Sphere = 0,
		[Token(Token = "0x4000266")]
		Box = 1,
		[Token(Token = "0x4000267")]
		Capsule = 2,
		[Token(Token = "0x4000268")]
		Heightmap = 3,
		[Token(Token = "0x4000269")]
		TriangleMesh = 4,
		[Token(Token = "0x400026A")]
		EdgeMesh = 5,
		[Token(Token = "0x400026B")]
		SignedDistanceField = 6
	}

	[Token(Token = "0x2000085")]
	public enum MaterialCombineMode
	{
		[Token(Token = "0x400026D")]
		Average = 0,
		[Token(Token = "0x400026E")]
		Minimium = 1,
		[Token(Token = "0x400026F")]
		Multiply = 2,
		[Token(Token = "0x4000270")]
		Maximum = 3
	}

	[Token(Token = "0x2000086")]
	public enum NormalsUpdate
	{
		[Token(Token = "0x4000272")]
		Recalculate = 0,
		[Token(Token = "0x4000273")]
		Skin = 1
	}

	[Token(Token = "0x2000087")]
	public enum ProfileMask : uint
	{
		[Token(Token = "0x4000275")]
		ThreadIdMask = 4294901760u,
		[Token(Token = "0x4000276")]
		TypeMask = 255u,
		[Token(Token = "0x4000277")]
		StackLevelMask = 65280u
	}

	[StructLayout((LayoutKind)0, Size = 88)]
	[Token(Token = "0x2000088")]
	public struct ProfileInfo
	{
		[Token(Token = "0x4000278")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public double start;

		[Token(Token = "0x4000279")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public double end;

		[Token(Token = "0x400027A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public uint info;

		[Token(Token = "0x400027B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public int pad;

		[Token(Token = "0x400027C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public string name;
	}

	[StructLayout((LayoutKind)0, Size = 28)]
	[Token(Token = "0x2000089")]
	public struct GridCell
	{
		[Token(Token = "0x400027D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector3 center;

		[Token(Token = "0x400027E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public Vector3 size;

		[Token(Token = "0x400027F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public int count;
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 40)]
	[Token(Token = "0x200008A")]
	public struct SolverParameters
	{
		[Token(Token = "0x20000CF")]
		public enum Interpolation
		{
			[Token(Token = "0x400035C")]
			None = 0,
			[Token(Token = "0x400035D")]
			Interpolate = 1
		}

		[Token(Token = "0x20000D0")]
		public enum Mode
		{
			[Token(Token = "0x400035F")]
			Mode3D = 0,
			[Token(Token = "0x4000360")]
			Mode2D = 1
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746C98", Offset = "0x746C98")]
		[Token(Token = "0x4000280")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Mode mode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746CD0", Offset = "0x746CD0")]
		[Token(Token = "0x4000281")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public Interpolation interpolation;

		[Token(Token = "0x4000282")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public Vector3 gravity;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746D08", Offset = "0x746D08")]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746D08", Offset = "0x746D08")]
		[Token(Token = "0x4000283")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public float damping;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746D5C", Offset = "0x746D5C")]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746D5C", Offset = "0x746D5C")]
		[Token(Token = "0x4000284")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public float shockPropagation;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746DB0", Offset = "0x746DB0")]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746DB0", Offset = "0x746DB0")]
		[Token(Token = "0x4000285")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public float maxAnisotropy;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746E04", Offset = "0x746E04")]
		[Token(Token = "0x4000286")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public float maxDepenetration;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746E3C", Offset = "0x746E3C")]
		[Token(Token = "0x4000287")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public float sleepThreshold;

		[Token(Token = "0x6000500")]
		[Address(RVA = "0x856348", Offset = "0x856348", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this + 0x10;\n\tv6 = 0x102CF78(v4, interpolation, methodInfo, v9, v10, v11, v12, v13, gravity, gravity.y, gravity.z, gravity.w, v14, v15, v16, v17);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe SolverParameters(Interpolation interpolation, Vector4 gravity)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @102CF78 (inside Obi.ObiSolver::.ctor +0x228)");
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x200008B")]
	public struct ConstraintParameters
	{
		[Token(Token = "0x20000D1")]
		public enum EvaluationOrder
		{
			[Token(Token = "0x4000362")]
			Sequential = 0,
			[Token(Token = "0x4000363")]
			Parallel = 1
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746E74", Offset = "0x746E74")]
		[Token(Token = "0x4000288")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public EvaluationOrder evaluationOrder;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746EAC", Offset = "0x746EAC")]
		[Token(Token = "0x4000289")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int iterations;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746EE4", Offset = "0x746EE4")]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746EE4", Offset = "0x746EE4")]
		[Token(Token = "0x400028A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public float SORFactor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x746F3C", Offset = "0x746F3C")]
		[Token(Token = "0x400028B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public bool enabled;

		[Token(Token = "0x6000501")]
		[Address(RVA = "0x856214", Offset = "0x856214", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Oni+ConstraintParameters)+10]) = order;\n\t*([this @ X0 (Oni+ConstraintParameters)+14]) = iterations;\n\t*([this @ X0 (Oni+ConstraintParameters)+1C]) = enabled;\n\t*([this @ X0 (Oni+ConstraintParameters)+18]) = 0x3F800000;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConstraintParameters(bool enabled, EvaluationOrder order, int iterations)
		{
			_ = 1065353216;
		}
	}

	[StructLayout((LayoutKind)0, Size = 128)]
	[Token(Token = "0x200008C")]
	public struct Contact
	{
		[Token(Token = "0x400028C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector4 point;

		[Token(Token = "0x400028D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Vector4 normal;

		[Token(Token = "0x400028E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public Vector4 tangent;

		[Token(Token = "0x400028F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public Vector4 bitangent;

		[Token(Token = "0x4000290")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public float distance;

		[Token(Token = "0x4000291")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
		public float normalImpulse;

		[Token(Token = "0x4000292")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		public float tangentImpulse;

		[Token(Token = "0x4000293")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
		public float bitangentImpulse;

		[Token(Token = "0x4000294")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		public float stickImpulse;

		[Token(Token = "0x4000295")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x54")]
		public float rollingFrictionImpulse;

		[Token(Token = "0x4000296")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		public int particle;

		[Token(Token = "0x4000297")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x5C")]
		public int other;
	}

	[StructLayout((LayoutKind)0, Size = 32)]
	[Token(Token = "0x200008D")]
	public struct BoneWeights
	{
		[Token(Token = "0x4000298")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int bone0;

		[Token(Token = "0x4000299")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int bone1;

		[Token(Token = "0x400029A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int bone2;

		[Token(Token = "0x400029B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public int bone3;

		[Token(Token = "0x400029C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public float weight0;

		[Token(Token = "0x400029D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public float weight1;

		[Token(Token = "0x400029E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public float weight2;

		[Token(Token = "0x400029F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public float weight3;

		[Token(Token = "0x6000502")]
		[Address(RVA = "0x8561D0", Offset = "0x8561D0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this + 0x10;\n\tv11 = weight.m_Weight0;\n\tv14 = 0x103AF54(v8, &v11 @ V0_v2 (System.Single), methodInfo, v16, v17, v18, v19, v20, weight.m_Weight0, v21, v22, v23, v24, v25, v26, v27);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe BoneWeights(BoneWeight weight)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			float num = weight.weight0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103AF54 (inside Oni::GetProfilingInfo +0x144)");
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 68)]
	[Token(Token = "0x200008E")]
	public struct Rigidbody
	{
		[Token(Token = "0x40002A0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Quaternion rotation;

		[Token(Token = "0x40002A1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Vector3 linearVelocity;

		[Token(Token = "0x40002A2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public Vector3 angularVelocity;

		[Token(Token = "0x40002A3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public Vector3 centerOfMass;

		[Token(Token = "0x40002A4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
		public Vector3 inertiaTensor;

		[Token(Token = "0x40002A5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public float inverseMass;

		[Token(Token = "0x6000503")]
		[Address(RVA = "0x856294", Offset = "0x856294", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv4 = 0x103B4C0(v0, source, kinematicForParticles, methodInfo, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Set(UnityEngine.Rigidbody source, bool kinematicForParticles)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103B4C0 (inside Oni::GetProfilingInfo +0x6B0)");
		}

		[Token(Token = "0x6000504")]
		[Address(RVA = "0x8562A0", Offset = "0x8562A0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv4 = 0x103B828(v0, source, kinematicForParticles, methodInfo, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Set(Rigidbody2D source, bool kinematicForParticles)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103B828 (inside Oni::GetProfilingInfo +0xA18)");
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 24)]
	[Token(Token = "0x200008F")]
	public struct RigidbodyVelocities
	{
		[Token(Token = "0x40002A6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector3 linearVelocity;

		[Token(Token = "0x40002A7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public Vector3 angularVelocity;
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 80)]
	[Token(Token = "0x2000090")]
	public struct Collider
	{
		[Token(Token = "0x40002A8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Quaternion rotation;

		[Token(Token = "0x40002A9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Vector3 translation;

		[Token(Token = "0x40002AA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public Vector3 scale;

		[Token(Token = "0x40002AB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public Vector3 boundsMin;

		[Token(Token = "0x40002AC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
		public Vector3 boundsMax;

		[Token(Token = "0x40002AD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public int id;

		[Token(Token = "0x40002AE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
		public float contactOffset;

		[Token(Token = "0x40002AF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		public int collisionGroup;

		[Token(Token = "0x40002B0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
		public bool trigger;

		[Token(Token = "0x6000505")]
		[Address(RVA = "0x856204", Offset = "0x856204", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x103AFF4(v0, source, phase, methodInfo, v6, v7, v8, v9, thickness, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
		public unsafe void Set(UnityEngine.Collider source, int phase, float thickness)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103AFF4 (inside Oni::GetProfilingInfo +0x1E4)");
		}

		[Token(Token = "0x6000506")]
		[Address(RVA = "0x85620C", Offset = "0x85620C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x103B260(v0, source, phase, methodInfo, v6, v7, v8, v9, thickness, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
		public unsafe void Set(Collider2D source, int phase, float thickness)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103B260 (inside Oni::GetProfilingInfo +0x450)");
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 64)]
	[Token(Token = "0x2000091")]
	public struct Shape
	{
		[Token(Token = "0x40002B1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector3 center;

		[Token(Token = "0x40002B2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public Vector3 size;

		[Token(Token = "0x40002B3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public IntPtr data;

		[Token(Token = "0x40002B4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public IntPtr indices;

		[Token(Token = "0x40002B5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public int dataCount;

		[Token(Token = "0x40002B6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
		public int indexCount;

		[Token(Token = "0x40002B7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public int resolutionU;

		[Token(Token = "0x40002B8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
		public int resolutionV;

		[Token(Token = "0x40002B9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		public bool is2D;

		[Token(Token = "0x40002BA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x39")]
		public bool accurateContacts;

		[Token(Token = "0x6000507")]
		[Address(RVA = "0x8562AC", Offset = "0x8562AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this + 0x10;\n\tv5 = 0x102D698(v3, methodInfo, v7, v8, v9, v10, v11, v12, center, center.y, center.z, radius, v14, v15, v16, v17);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Set(Vector3 center, float radius)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @102D698 (inside Obi.ObiSphereShapeTracker::UpdateIfNeeded +0x1A4)");
		}

		[Token(Token = "0x6000508")]
		[Address(RVA = "0x8562B4", Offset = "0x8562B4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Oni+Shape)+10]) = center;\n\t*([this @ X0 (Oni+Shape)+14]) = center.y;\n\tthis.data = center.z;\n\t*([this @ X0 (Oni+Shape)+1C]) = size;\n\tthis.indices = size.y;\n\t*([this @ X0 (Oni+Shape)+24]) = size.z;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set(Vector3 center, Vector3 size)
		{
			//IL_001e: Expected I, but got F4
			//IL_0032: Expected I, but got F4
			_ = center.y;
			data = (IntPtr)center.z;
			indices = (IntPtr)size.y;
			_ = size.z;
		}

		[Token(Token = "0x6000509")]
		[Address(RVA = "0x8562C4", Offset = "0x8562C4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Oni+Shape)+10]) = center;\n\t*([this @ X0 (Oni+Shape)+14]) = center.y;\n\tthis.data = center.z;\n\tv16 = 0;\n\tv23 = 0x1586898(&v16 @ stack_-30_v1, 0, methodInfo, v25, v26, v27, v28, v29, radius, height, direction, radius, height, v30, v31, v32);\n\t*([this @ X0 (Oni+Shape)+1C]) = 0;\n\tthis.indices = v35;\n\t*([this @ X0 (Oni+Shape)+24]) = 0;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set(Vector3 center, float radius, float height, int direction)
		{
			//IL_001e: Expected I, but got F4
			//IL_0027: Expected O, but got I4
			_ = center.y;
			data = (IntPtr)center.z;
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			_ = 0;
			IntPtr intPtr = default(IntPtr);
			indices = intPtr;
			_ = 0;
		}

		[Token(Token = "0x600050A")]
		[Address(RVA = "0x856320", Offset = "0x856320", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = resolutionV * resolutionU;\n\t*([this @ X0 (Oni+Shape)+1C]) = size;\n\tthis.indices = size.y;\n\t*([this @ X0 (Oni+Shape)+24]) = size.z;\n\t*([this @ X0 (Oni+Shape)+40]) = resolutionU;\n\t*([this @ X0 (Oni+Shape)+44]) = resolutionV;\n\tthis.dataCount = data;\n\tthis.is2D = v3;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set(Vector3 size, int resolutionU, int resolutionV, IntPtr data)
		{
			//IL_0021: Expected I, but got F4
			int num = resolutionV * resolutionU;
			indices = (IntPtr)size.y;
			_ = size.z;
			dataCount = (int)(long)data;
			indexCount = (int)((ulong)(long)data >> 32);
			is2D = (byte)num != 0;
		}

		[Token(Token = "0x600050B")]
		[Address(RVA = "0x85633C", Offset = "0x85633C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.dataCount = data;\n\tthis.resolutionU = indices;\n\tthis.is2D = dataCount;\n\t*([this @ X0 (Oni+Shape)+3C]) = indicesCount;\n\treturn;\n")]
		public void Set(IntPtr data, IntPtr indices, int dataCount, int indicesCount)
		{
			this.dataCount = (int)(long)data;
			resolutionU = (int)(long)indices;
			is2D = (byte)dataCount != 0;
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 32)]
	[Token(Token = "0x2000092")]
	public struct CollisionMaterial
	{
		[Token(Token = "0x40002BB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float dynamicFriction;

		[Token(Token = "0x40002BC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public float staticFriction;

		[Token(Token = "0x40002BD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public float rollingFriction;

		[Token(Token = "0x40002BE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public float stickiness;

		[Token(Token = "0x40002BF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public float stickDistance;

		[Token(Token = "0x40002C0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public MaterialCombineMode frictionCombine;

		[Token(Token = "0x40002C1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public MaterialCombineMode stickinessCombine;

		[Token(Token = "0x40002C2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public bool rollingContacts;
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 20)]
	[Token(Token = "0x2000093")]
	public struct ElastoplasticMaterial
	{
		[Token(Token = "0x40002C3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float stiffness;

		[Token(Token = "0x40002C4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public float plasticYield;

		[Token(Token = "0x40002C5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public float plasticCreep;

		[Token(Token = "0x40002C6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public float plasticRecovery;

		[Token(Token = "0x40002C7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public float maxDeformation;

		[Token(Token = "0x600050C")]
		[Address(RVA = "0x85622C", Offset = "0x85622C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxDeformation = stiffness;\n\t*([this @ X0 (Oni+ElastoplasticMaterial)+14]) = plasticYield;\n\t*([this @ X0 (Oni+ElastoplasticMaterial)+18]) = plasticCreep;\n\t*([this @ X0 (Oni+ElastoplasticMaterial)+1C]) = plasticRecovery;\n\t*([this @ X0 (Oni+ElastoplasticMaterial)+20]) = maxDeformation;\n\treturn;\n")]
		public ElastoplasticMaterial(float stiffness, float plasticYield, float plasticCreep, float plasticRecovery, float maxDeformation)
		{
			this.maxDeformation = stiffness;
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 64)]
	[Token(Token = "0x2000094")]
	public struct DFNode
	{
		[Token(Token = "0x40002C8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector4 distancesA;

		[Token(Token = "0x40002C9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Vector4 distancesB;

		[Token(Token = "0x40002CA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public Vector4 center;

		[Token(Token = "0x40002CB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public int firstChild;
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 24)]
	[Token(Token = "0x2000095")]
	public struct HalfEdge
	{
		[Token(Token = "0x40002CC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x40002CD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int indexInFace;

		[Token(Token = "0x40002CE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int face;

		[Token(Token = "0x40002CF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public int nextHalfEdge;

		[Token(Token = "0x40002D0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public int pair;

		[Token(Token = "0x40002D1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public int endVertex;

		[Token(Token = "0x600050D")]
		[Address(RVA = "0x856248", Offset = "0x856248", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.pair = index;\n\t*([this @ X0 (Oni+HalfEdge)+24]) = 0xFFFFFFFF;\n\t*([this @ X0 (Oni+HalfEdge)+1C]) = -1;\n\tthis.endVertex = -1;\n\treturn;\n\tX8 = *([X0]);\n\tX2 = 0 | 0x40;\n\t*([X1]) = X8;\n\tX8 = *([X0+8]);\n\t*([X1+8]) = X8;\n\tX8 = *([X0+10]);\n\t*([X1+10]) = X8;\n\tX8 = *([X0+14]);\n\t*([X1+14]) = X8;\n\tX0 = *([X0+18]);\n\tX1 = X1 + 0x18;\n\tX0 = 0x8D8468(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HalfEdge(int index)
		{
			pair = index;
			_ = 4294967295L;
			_ = -1;
			endVertex = -1;
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 20)]
	[Token(Token = "0x2000096")]
	public struct Vertex
	{
		[Token(Token = "0x40002D2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x40002D3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int halfEdge;

		[Token(Token = "0x40002D4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public Vector3 position;

		[Token(Token = "0x600050E")]
		[Address(RVA = "0x856350", Offset = "0x856350", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Oni+Vertex)+10]) = index;\n\t*([this @ X0 (Oni+Vertex)+14]) = halfEdge;\n\t*([this @ X0 (Oni+Vertex)+18]) = position;\n\t*([this @ X0 (Oni+Vertex)+1C]) = position.y;\n\t*([this @ X0 (Oni+Vertex)+20]) = position.z;\n\treturn;\n\t// 8 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX0 = *([X0]);\n\tX19 = X1;\n\tif (TEMP) goto L_001C;\n\tX8 = *([X0]);\n\tX8 = *([X8+12F]);\n\tTEMP = X8 & 8;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0022;\n\tX1 = *([1EEEF48]);\n\tX0 = 0x8D8314(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19]) = X0;\n\tgoto L_001D;\nL_001C:\n\t*([X19]) = 0;\nL_001D:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 32 ShiftStack 32\n\treturn;\nL_0022:\n\tX1 = 0x1EEE000;\n\tX1 = *([1EEEF48]);\n\tX0 = 0x8D831C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19]) = X0;\n\tX8 = *([X0]);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = *([X8+8]);\n\tX19 = stack[0];\n\t// 43 ShiftStack 32\n\t// 44 IndirectJump X1, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\t// 45 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([20268BD]);\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0042;\n\tX8 = *([1ED74D8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20268BD]) = X8;\nL_0042:\n\tX0 = *([X19]);\n\tif (TEMP) goto L_005A;\n\tX8 = *([1EECE88]);\n\tX1 = *([X8]);\n\tX0 = 0x8D8318(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20]) = X0;\n\tX8 = *([X0]);\n\tX8 = *([X8+12F]);\n\tTEMP = X8 & 8;\n\tif (TEMP) goto L_005B;\n\tX2 = *([X19]);\n\tX1 = *([1EEEF48]);\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 87 ShiftStack 48\n\tX0 = 0x8D83B8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\nL_005A:\n\t*([X20]) = 0;\nL_005B:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 96 ShiftStack 48\n\treturn;\n\t// 98 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tif (TEMP) goto L_006F;\n\tX8 = *([X0]);\n\tX8 = *([X8+10]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19]) = 0;\nL_006F:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 114 ShiftStack 32\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vertex(Vector3 position, int index, int halfEdge)
		{
			_ = position.y;
			_ = position.z;
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x2000097")]
	public struct Face
	{
		[Token(Token = "0x40002D5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x40002D6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int halfEdge;

		[Token(Token = "0x600050F")]
		[Address(RVA = "0x85623C", Offset = "0x85623C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Oni+Face)+10]) = index;\n\t*([this @ X0 (Oni+Face)+14]) = 0xFFFFFFFF;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Face(int index)
		{
			_ = 4294967295L;
		}
	}

	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000098")]
	public struct MeshInformation
	{
		[Token(Token = "0x40002D7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float volume;

		[Token(Token = "0x40002D8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public float area;

		[Token(Token = "0x40002D9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int borderEdgeCount;

		[Token(Token = "0x40002DA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public bool closed;

		[Token(Token = "0x40002DB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xD")]
		public bool nonManifold;
	}

	[Token(Token = "0x4000004")]
	public const int ConstraintTypeCount = 17;

	[Token(Token = "0x4000005")]
	private const string LIBNAME = "Oni";

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x1030514", Offset = "0x1030514", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = System.Runtime.InteropServices.GCHandle::Alloc(data, 3);\n\treturnVal1 = v8 & 0xFFFFFFFF;\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static GCHandle PinMemory(object data)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		return (GCHandle)(gCHandle & 0xFFFFFFFFL);
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x10304DC", Offset = "0x10304DC", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\thandle = 0xF74DE0(&handle @ X0 (System.Runtime.InteropServices.GCHandle), 0, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\tv25 = handle & 1;\n\tv26 = v25 == 0;\n\tif (v26) goto L_0011;\n\thandle = 0xF75014(&handle @ X0 (System.Runtime.InteropServices.GCHandle), 0, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\nL_0011:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void UnpinMemory(GCHandle handle)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74DE0 (inside System.Runtime.InteropServices.GCHandle::GetTargetHandle +0x4)");
		if ((handle & 1) != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F75014 (inside System.Runtime.InteropServices.GCHandle::Alloc +0x28)");
		}
	}

	[PreserveSig]
	[Token(Token = "0x6000006")]
	[Address(RVA = "0x10370C4", Offset = "0x10370C4", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([20262B0]);\n\tv10 = *([20262B0]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([20262B0]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateCollider();

	[PreserveSig]
	[Token(Token = "0x6000007")]
	[Address(RVA = "0x103714C", Offset = "0x103714C", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20262B8]);\n\tv14 = *([20262B8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20262B8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, collider, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyCollider(IntPtr collider);

	[PreserveSig]
	[Token(Token = "0x6000008")]
	[Address(RVA = "0x102D45C", Offset = "0x102D45C", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20262C0]);\n\tv14 = *([20262C0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20262C0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, shapeType, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateShape(ShapeType shapeType);

	[PreserveSig]
	[Token(Token = "0x6000009")]
	[Address(RVA = "0x1023718", Offset = "0x1023718", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20262C8]);\n\tv14 = *([20262C8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20262C8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, shape, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyShape(IntPtr shape);

	[PreserveSig]
	[Token(Token = "0x600000A")]
	[Address(RVA = "0x10371E4", Offset = "0x10371E4", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([20262D0]);\n\tv10 = *([20262D0]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([20262D0]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateRigidbody();

	[PreserveSig]
	[Token(Token = "0x600000B")]
	[Address(RVA = "0x103726C", Offset = "0x103726C", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20262D8]);\n\tv14 = *([20262D8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20262D8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, rigidbody, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyRigidbody(IntPtr rigidbody);

	[PreserveSig]
	[Token(Token = "0x600000C")]
	[Address(RVA = "0x1037304", Offset = "0x1037304", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20262E0]);\n\tv18 = *([20262E0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20262E0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, collider, adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void UpdateCollider(IntPtr collider, ref Collider adaptor);

	[PreserveSig]
	[Token(Token = "0x600000D")]
	[Address(RVA = "0x102D73C", Offset = "0x102D73C", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20262E8]);\n\tv18 = *([20262E8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20262E8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, shape, adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void UpdateShape(IntPtr shape, ref Shape adaptor);

	[PreserveSig]
	[Token(Token = "0x600000E")]
	[Address(RVA = "0x10373AC", Offset = "0x10373AC", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20262F0]);\n\tv18 = *([20262F0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20262F0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, rigidbody, adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void UpdateRigidbody(IntPtr rigidbody, ref Rigidbody adaptor);

	[PreserveSig]
	[Token(Token = "0x600000F")]
	[Address(RVA = "0x1037454", Offset = "0x1037454", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20262F8]);\n\tv18 = *([20262F8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), velocities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20262F8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, rigidbody, velocities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetRigidbodyVelocity(IntPtr rigidbody, ref RigidbodyVelocities velocities);

	[PreserveSig]
	[Token(Token = "0x6000010")]
	[Address(RVA = "0x10374FC", Offset = "0x10374FC", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026300]);\n\tv10 = *([2026300]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026300]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateDistanceField();

	[PreserveSig]
	[Token(Token = "0x6000011")]
	[Address(RVA = "0x1037584", Offset = "0x1037584", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026308]);\n\tv14 = *([2026308]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026308]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, df, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyDistanceField(IntPtr df);

	[PreserveSig]
	[Token(Token = "0x6000012")]
	[Address(RVA = "0x103761C", Offset = "0x103761C", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2026310]);\n\tv38 = *([2026310]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_002D;\n\tv42 = 0x1821000 + 0xF74;\n\tv56 = 0x8D848C(&v42 @ X8_v4 (System.Int32), maxDepth, vertexPos, triIndices, numVertices, numTriangles, methodInfo, v58, maxError, v59, v60, v61, v62, v63, v64, v65);\n\t*([2026310]) = v56;\n\tv92 = v56 == 0;\n\tif (v92) goto L_0061;\nL_002D:\n\tv95 = vertexPos + 0x20;\n\tv105 = triIndices + 0x20;\n\tv106 = vertexPos != 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tv122 = triIndices != 0;\n\tif (v122) goto L_FFFFFFFF;\n\tgoto L_0052;\nL_0052:\n\tv42(v134, df, maxDepth, v112, v128, numVertices, numTriangles, methodInfo, v58, maxError, v59, v60, v61, v62, v63, v64, v65);\n\treturn;\nL_0061:\n\tv111 = new System.NotSupportedException();\n\tthrow v111;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void StartBuildingDistanceField(IntPtr df, float maxError, int maxDepth, Vector3[] vertexPos, int[] triIndices, int numVertices, int numTriangles);

	[PreserveSig]
	[Token(Token = "0x6000013")]
	[Address(RVA = "0x1037714", Offset = "0x1037714", Length = "0xA0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026318]);\n\tv14 = *([2026318]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026318]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_0036;\nL_0022:\n\tv18(v78, df, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv87 = v78 == 0;\n\tv92 = ~v87;\n\treturn v92;\nL_0036:\n\tv138 = new System.NotSupportedException();\n\tthrow v138;\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern bool ContinueBuildingDistanceField(IntPtr df);

	[PreserveSig]
	[Token(Token = "0x6000014")]
	[Address(RVA = "0x10377B4", Offset = "0x10377B4", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026320]);\n\tv26 = *([2026320]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_002B;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), methodInfo, v46, v47, v48, v49, v50, v51, x, y, z, v52, v53, v54, v55, v56);\n\t*([2026320]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0037;\nL_002B:\n\tv30(v90, df, methodInfo, v46, v47, v48, v49, v50, v51, x, y, z, v52, v53, v54, v55, v56);\n\treturn x;\nL_0037:\n\tv130 = new System.NotSupportedException();\n\tthrow v130;\n\treturn x;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern float SampleDistanceField(IntPtr df, float x, float y, float z);

	[PreserveSig]
	[Token(Token = "0x6000015")]
	[Address(RVA = "0x1037874", Offset = "0x1037874", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026328]);\n\tv14 = *([2026328]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026328]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, df, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetDistanceFieldNodeCount(IntPtr df);

	[PreserveSig]
	[Token(Token = "0x6000016")]
	[Address(RVA = "0x103790C", Offset = "0x103790C", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026330]);\n\tv18 = *([2026330]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), nodes, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026330]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_003E;\nL_0023:\n\tv80 = nodes + 0x20;\n\tv90 = nodes != 0;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv22(v98, df, v96, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_003E:\n\tv95 = new System.NotSupportedException();\n\tthrow v95;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetDistanceFieldNodes(IntPtr df, DFNode[] nodes);

	[PreserveSig]
	[Token(Token = "0x6000017")]
	[Address(RVA = "0x10379BC", Offset = "0x10379BC", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026338]);\n\tv22 = *([2026338]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0025;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), nodes, num, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026338]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0042;\nL_0025:\n\tv83 = nodes + 0x20;\n\tv93 = nodes != 0;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv26(v102, df, v99, num, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0042:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDistanceFieldNodes(IntPtr df, DFNode[] nodes, int num);

	[PreserveSig]
	[Token(Token = "0x6000018")]
	[Address(RVA = "0x1037A74", Offset = "0x1037A74", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026340]);\n\tv18 = *([2026340]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), distanceField, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026340]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, shape, distanceField, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetShapeDistanceField(IntPtr shape, IntPtr distanceField);

	[PreserveSig]
	[Token(Token = "0x6000019")]
	[Address(RVA = "0x1037B1C", Offset = "0x1037B1C", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026348]);\n\tv18 = *([2026348]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0024;\n\tv22 = 0x1821000 + 0xF74;\n\tv35 = 0x8D848C(&v22 @ X8_v4 (System.Int32), shape, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([2026348]) = v35;\n\tv74 = v35 == 0;\n\tif (v74) goto L_002E;\nL_0024:\n\tv22(v79, collider, shape, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\nL_002E:\n\tv111 = new System.NotSupportedException();\n\tthrow v111;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetColliderShape(IntPtr collider, IntPtr shape);

	[PreserveSig]
	[Token(Token = "0x600001A")]
	[Address(RVA = "0x1037BC0", Offset = "0x1037BC0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026350]);\n\tv18 = *([2026350]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), rigidbody, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026350]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, collider, rigidbody, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetColliderRigidbody(IntPtr collider, IntPtr rigidbody);

	[PreserveSig]
	[Token(Token = "0x600001B")]
	[Address(RVA = "0x1037C68", Offset = "0x1037C68", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026358]);\n\tv18 = *([2026358]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), material, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026358]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, collider, material, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetColliderMaterial(IntPtr collider, IntPtr material);

	[PreserveSig]
	[Token(Token = "0x600001C")]
	[Address(RVA = "0x1037D10", Offset = "0x1037D10", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026360]);\n\tv10 = *([2026360]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026360]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateCollisionMaterial();

	[PreserveSig]
	[Token(Token = "0x600001D")]
	[Address(RVA = "0x1037D98", Offset = "0x1037D98", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026368]);\n\tv14 = *([2026368]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026368]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, material, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyCollisionMaterial(IntPtr material);

	[PreserveSig]
	[Token(Token = "0x600001E")]
	[Address(RVA = "0x1037E30", Offset = "0x1037E30", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026370]);\n\tv18 = *([2026370]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026370]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, material, adaptor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void UpdateCollisionMaterial(IntPtr material, ref CollisionMaterial adaptor);

	[PreserveSig]
	[Token(Token = "0x600001F")]
	[Address(RVA = "0x10271CC", Offset = "0x10271CC", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026378]);\n\tv14 = *([2026378]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026378]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, capacity, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateSolver(int capacity);

	[PreserveSig]
	[Token(Token = "0x6000020")]
	[Address(RVA = "0x1027C74", Offset = "0x1027C74", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026380]);\n\tv14 = *([2026380]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026380]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, solver, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroySolver(IntPtr solver);

	[PreserveSig]
	[Token(Token = "0x6000021")]
	[Address(RVA = "0x1029A90", Offset = "0x1029A90", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026388]);\n\tv18 = *([2026388]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), capacity, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026388]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, capacity, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetCapacity(IntPtr solver, int capacity);

	[PreserveSig]
	[Token(Token = "0x6000022")]
	[Address(RVA = "0x102B4A4", Offset = "0x102B4A4", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026390]);\n\tv26 = *([2026390]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_002B;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), translation, scale, rotation, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([2026390]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0037;\nL_002B:\n\tv30(v90, solver, translation, scale, rotation, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0037:\n\tv128 = new System.NotSupportedException();\n\tthrow v128;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void InitializeFrame(IntPtr solver, ref Vector4 translation, ref Vector4 scale, ref Quaternion rotation);

	[PreserveSig]
	[Token(Token = "0x6000023")]
	[Address(RVA = "0x102B6A8", Offset = "0x102B6A8", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026398]);\n\tv30 = *([2026398]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_002E;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), translation, scale, rotation, methodInfo, v50, v51, v52, dt, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026398]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_003B;\nL_002E:\n\tv34(v94, solver, translation, scale, rotation, methodInfo, v50, v51, v52, dt, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_003B:\n\tv135 = new System.NotSupportedException();\n\tthrow v135;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void UpdateFrame(IntPtr solver, ref Vector4 translation, ref Vector4 scale, ref Quaternion rotation, float dt);

	[PreserveSig]
	[Token(Token = "0x6000024")]
	[Address(RVA = "0x102B778", Offset = "0x102B778", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([20263A0]);\n\tv34 = *([20263A0]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_0031;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), methodInfo, v54, v55, v56, v57, v58, v59, linearVelocityScale, angularVelocityScale, linearInertiaScale, angularInertiaScale, dt, v60, v61, v62);\n\t*([20263A0]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_003F;\nL_0031:\n\tv38(v98, solver, methodInfo, v54, v55, v56, v57, v58, v59, linearVelocityScale, angularVelocityScale, linearInertiaScale, angularInertiaScale, dt, v60, v61, v62);\n\treturn;\nL_003F:\n\tv144 = new System.NotSupportedException();\n\tthrow v144;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void ApplyFrame(IntPtr solver, float linearVelocityScale, float angularVelocityScale, float linearInertiaScale, float angularInertiaScale, float dt);

	[PreserveSig]
	[Token(Token = "0x6000025")]
	[Address(RVA = "0x1037ED8", Offset = "0x1037ED8", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20263A8]);\n\tv14 = *([20263A8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20263A8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, collider, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void AddCollider(IntPtr collider);

	[PreserveSig]
	[Token(Token = "0x6000026")]
	[Address(RVA = "0x1037F70", Offset = "0x1037F70", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20263B0]);\n\tv14 = *([20263B0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20263B0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, collider, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void RemoveCollider(IntPtr collider);

	[PreserveSig]
	[Token(Token = "0x6000027")]
	[Address(RVA = "0x102BA48", Offset = "0x102BA48", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20263B8]);\n\tv14 = *([20263B8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20263B8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, solver, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void RecalculateInertiaTensors(IntPtr solver);

	[PreserveSig]
	[Token(Token = "0x6000028")]
	[Address(RVA = "0x102C9C4", Offset = "0x102C9C4", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20263C0]);\n\tv14 = *([20263C0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20263C0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, solver, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void ResetForces(IntPtr solver);

	[PreserveSig]
	[Token(Token = "0x6000029")]
	[Address(RVA = "0x102AD3C", Offset = "0x102AD3C", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([20263C8]);\n\tv22 = *([20263C8]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), min, max, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([20263C8]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, solver, min, max, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetBounds(IntPtr solver, ref Vector3 min, ref Vector3 max);

	[PreserveSig]
	[Token(Token = "0x600002A")]
	[Address(RVA = "0x1038008", Offset = "0x1038008", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20263D0]);\n\tv14 = *([20263D0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20263D0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, solver, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetParticleGridSize(IntPtr solver);

	[PreserveSig]
	[Token(Token = "0x600002B")]
	[Address(RVA = "0x10380A0", Offset = "0x10380A0", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20263D8]);\n\tv18 = *([20263D8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), cells, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20263D8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_003E;\nL_0023:\n\tv80 = cells + 0x20;\n\tv90 = cells != 0;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv22(v98, solver, v96, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_003E:\n\tv95 = new System.NotSupportedException();\n\tthrow v95;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetParticleGrid(IntPtr solver, GridCell[] cells);

	[PreserveSig]
	[Token(Token = "0x600002C")]
	[Address(RVA = "0x1029EBC", Offset = "0x1029EBC", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20263E0]);\n\tv18 = *([20263E0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), parameters, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20263E0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, parameters, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetSolverParameters(IntPtr solver, ref SolverParameters parameters);

	[PreserveSig]
	[Token(Token = "0x600002D")]
	[Address(RVA = "0x1038150", Offset = "0x1038150", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20263E8]);\n\tv18 = *([20263E8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), parameters, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20263E8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, parameters, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetSolverParameters(IntPtr solver, ref SolverParameters parameters);

	[PreserveSig]
	[Token(Token = "0x600002E")]
	[Address(RVA = "0x102A504", Offset = "0x102A504", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([20263F0]);\n\tv22 = *([20263F0]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0025;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), active, num, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([20263F0]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0042;\nL_0025:\n\tv83 = active + 0x20;\n\tv93 = active != 0;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv26(returnVal1, solver, v99, num, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal1;\nL_0042:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int SetActiveParticles(IntPtr solver, int[] active, int num);

	[PreserveSig]
	[Token(Token = "0x600002F")]
	[Address(RVA = "0x102BEC8", Offset = "0x102BEC8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20263F8]);\n\tv18 = *([20263F8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), methodInfo, v38, v39, v40, v41, v42, v43, delta_time, v44, v45, v46, v47, v48, v49, v50);\n\t*([20263F8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(returnVal1, solver, methodInfo, v38, v39, v40, v41, v42, v43, delta_time, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\nL_002F:\n\tv116 = new System.NotSupportedException();\n\tthrow v116;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CollisionDetection(IntPtr solver, float delta_time);

	[PreserveSig]
	[Token(Token = "0x6000030")]
	[Address(RVA = "0x102C100", Offset = "0x102C100", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026400]);\n\tv18 = *([2026400]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), methodInfo, v38, v39, v40, v41, v42, v43, delta_time, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026400]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(returnVal1, solver, methodInfo, v38, v39, v40, v41, v42, v43, delta_time, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\nL_002F:\n\tv116 = new System.NotSupportedException();\n\tthrow v116;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr Step(IntPtr solver, float delta_time);

	[PreserveSig]
	[Token(Token = "0x6000031")]
	[Address(RVA = "0x102CC88", Offset = "0x102CC88", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026408]);\n\tv30 = *([2026408]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_002E;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), draw_positions, draw_orientations, methodInfo, v50, v51, v52, v53, delta_seconds, unsimulated_time, v54, v55, v56, v57, v58, v59);\n\t*([2026408]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_003B;\nL_002E:\n\tv34(v94, solver, draw_positions, draw_orientations, methodInfo, v50, v51, v52, v53, delta_seconds, unsimulated_time, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_003B:\n\tv135 = new System.NotSupportedException();\n\tthrow v135;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void ApplyPositionInterpolation(IntPtr solver, IntPtr draw_positions, IntPtr draw_orientations, float delta_seconds, float unsimulated_time);

	[PreserveSig]
	[Token(Token = "0x6000032")]
	[Address(RVA = "0x10381F8", Offset = "0x10381F8", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026410]);\n\tv14 = *([2026410]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026410]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, solver, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void UpdateSkeletalAnimation(IntPtr solver);

	[PreserveSig]
	[Token(Token = "0x6000033")]
	[Address(RVA = "0x102C3D0", Offset = "0x102C3D0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026418]);\n\tv18 = *([2026418]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026418]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(returnVal1, solver, type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetConstraintCount(IntPtr solver, int type);

	[PreserveSig]
	[Token(Token = "0x6000034")]
	[Address(RVA = "0x1038290", Offset = "0x1038290", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026420]);\n\tv26 = *([2026420]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0027;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), indices, num, type, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([2026420]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0046;\nL_0027:\n\tv86 = indices + 0x20;\n\tv96 = indices != 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_003A;\nL_003A:\n\tv30(v106, solver, v102, num, type, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0046:\n\tv101 = new System.NotSupportedException();\n\tthrow v101;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetActiveConstraintIndices(IntPtr solver, int[] indices, int num, int type);

	[PreserveSig]
	[Token(Token = "0x6000035")]
	[Address(RVA = "0x10284E8", Offset = "0x10284E8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026428]);\n\tv18 = *([2026428]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), positions, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026428]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, positions, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetRenderableParticlePositions(IntPtr solver, IntPtr positions);

	[PreserveSig]
	[Token(Token = "0x6000036")]
	[Address(RVA = "0x1028440", Offset = "0x1028440", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026430]);\n\tv18 = *([2026430]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), phases, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026430]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, phases, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePhases(IntPtr solver, IntPtr phases);

	[PreserveSig]
	[Token(Token = "0x6000037")]
	[Address(RVA = "0x1027D0C", Offset = "0x1027D0C", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026438]);\n\tv18 = *([2026438]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), positions, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026438]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, positions, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePositions(IntPtr solver, IntPtr positions);

	[PreserveSig]
	[Token(Token = "0x6000038")]
	[Address(RVA = "0x1027DB4", Offset = "0x1027DB4", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026440]);\n\tv18 = *([2026440]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), prevPositions, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026440]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, prevPositions, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePreviousPositions(IntPtr solver, IntPtr prevPositions);

	[PreserveSig]
	[Token(Token = "0x6000039")]
	[Address(RVA = "0x1027F00", Offset = "0x1027F00", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026448]);\n\tv18 = *([2026448]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), orientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026448]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, orientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleOrientations(IntPtr solver, IntPtr orientations);

	[PreserveSig]
	[Token(Token = "0x600003A")]
	[Address(RVA = "0x1027FA8", Offset = "0x1027FA8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026450]);\n\tv18 = *([2026450]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), prevOrientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026450]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, prevOrientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePreviousOrientations(IntPtr solver, IntPtr prevOrientations);

	[PreserveSig]
	[Token(Token = "0x600003B")]
	[Address(RVA = "0x1028590", Offset = "0x1028590", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026458]);\n\tv18 = *([2026458]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), orientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026458]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, orientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetRenderableParticleOrientations(IntPtr solver, IntPtr orientations);

	[PreserveSig]
	[Token(Token = "0x600003C")]
	[Address(RVA = "0x1028248", Offset = "0x1028248", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026460]);\n\tv18 = *([2026460]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), invMasses, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026460]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, invMasses, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleInverseMasses(IntPtr solver, IntPtr invMasses);

	[PreserveSig]
	[Token(Token = "0x600003D")]
	[Address(RVA = "0x10282F0", Offset = "0x10282F0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026468]);\n\tv18 = *([2026468]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), invRotMasses, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026468]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, invRotMasses, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleInverseRotationalMasses(IntPtr solver, IntPtr invRotMasses);

	[PreserveSig]
	[Token(Token = "0x600003E")]
	[Address(RVA = "0x1028398", Offset = "0x1028398", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026470]);\n\tv18 = *([2026470]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), principalRadii, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026470]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, principalRadii, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePrincipalRadii(IntPtr solver, IntPtr principalRadii);

	[PreserveSig]
	[Token(Token = "0x600003F")]
	[Address(RVA = "0x10280F8", Offset = "0x10280F8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026478]);\n\tv18 = *([2026478]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), velocities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026478]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, velocities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleVelocities(IntPtr solver, IntPtr velocities);

	[PreserveSig]
	[Token(Token = "0x6000040")]
	[Address(RVA = "0x10281A0", Offset = "0x10281A0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026480]);\n\tv18 = *([2026480]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), angularVelocities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026480]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, angularVelocities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleAngularVelocities(IntPtr solver, IntPtr angularVelocities);

	[PreserveSig]
	[Token(Token = "0x6000041")]
	[Address(RVA = "0x1028E20", Offset = "0x1028E20", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026488]);\n\tv18 = *([2026488]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), forces, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026488]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, forces, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleExternalForces(IntPtr solver, IntPtr forces);

	[PreserveSig]
	[Token(Token = "0x6000042")]
	[Address(RVA = "0x1028EC8", Offset = "0x1028EC8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026490]);\n\tv18 = *([2026490]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), torques, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026490]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, torques, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleExternalTorques(IntPtr solver, IntPtr torques);

	[PreserveSig]
	[Token(Token = "0x6000043")]
	[Address(RVA = "0x1028F70", Offset = "0x1028F70", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026498]);\n\tv18 = *([2026498]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0024;\n\tv22 = 0x1821000 + 0xF74;\n\tv35 = 0x8D848C(&v22 @ X8_v4 (System.Int32), winds, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([2026498]) = v35;\n\tv74 = v35 == 0;\n\tif (v74) goto L_002E;\nL_0024:\n\tv22(v79, solver, winds, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\nL_002E:\n\tv111 = new System.NotSupportedException();\n\tthrow v111;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleWinds(IntPtr solver, IntPtr winds);

	[PreserveSig]
	[Token(Token = "0x6000044")]
	[Address(RVA = "0x1029014", Offset = "0x1029014", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264A0]);\n\tv18 = *([20264A0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), deltas, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264A0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, deltas, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePositionDeltas(IntPtr solver, IntPtr deltas);

	[PreserveSig]
	[Token(Token = "0x6000045")]
	[Address(RVA = "0x10290BC", Offset = "0x10290BC", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264A8]);\n\tv18 = *([20264A8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), deltas, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264A8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, deltas, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleOrientationDeltas(IntPtr solver, IntPtr deltas);

	[PreserveSig]
	[Token(Token = "0x6000046")]
	[Address(RVA = "0x1029164", Offset = "0x1029164", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264B0]);\n\tv18 = *([20264B0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), counts, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264B0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, counts, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticlePositionConstraintCounts(IntPtr solver, IntPtr counts);

	[PreserveSig]
	[Token(Token = "0x6000047")]
	[Address(RVA = "0x102920C", Offset = "0x102920C", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264B8]);\n\tv18 = *([20264B8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), counts, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264B8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, counts, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleOrientationConstraintCounts(IntPtr solver, IntPtr counts);

	[PreserveSig]
	[Token(Token = "0x6000048")]
	[Address(RVA = "0x10292B4", Offset = "0x10292B4", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264C0]);\n\tv18 = *([20264C0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), normals, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264C0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, normals, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleNormals(IntPtr solver, IntPtr normals);

	[PreserveSig]
	[Token(Token = "0x6000049")]
	[Address(RVA = "0x102935C", Offset = "0x102935C", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264C8]);\n\tv18 = *([20264C8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), tensors, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264C8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, tensors, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleInverseInertiaTensors(IntPtr solver, IntPtr tensors);

	[PreserveSig]
	[Token(Token = "0x600004A")]
	[Address(RVA = "0x10286E0", Offset = "0x10286E0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264D0]);\n\tv18 = *([20264D0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), radii, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264D0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, radii, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleSmoothingRadii(IntPtr solver, IntPtr radii);

	[PreserveSig]
	[Token(Token = "0x600004B")]
	[Address(RVA = "0x1028788", Offset = "0x1028788", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264D8]);\n\tv18 = *([20264D8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), buoyancy, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264D8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, buoyancy, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleBuoyancy(IntPtr solver, IntPtr buoyancy);

	[PreserveSig]
	[Token(Token = "0x600004C")]
	[Address(RVA = "0x1028830", Offset = "0x1028830", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264E0]);\n\tv18 = *([20264E0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), rest_densities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264E0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, rest_densities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleRestDensities(IntPtr solver, IntPtr rest_densities);

	[PreserveSig]
	[Token(Token = "0x600004D")]
	[Address(RVA = "0x10288D8", Offset = "0x10288D8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264E8]);\n\tv18 = *([20264E8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), viscosities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264E8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, viscosities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleViscosities(IntPtr solver, IntPtr viscosities);

	[PreserveSig]
	[Token(Token = "0x600004E")]
	[Address(RVA = "0x1028980", Offset = "0x1028980", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264F0]);\n\tv18 = *([20264F0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), surface_tension, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264F0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, surface_tension, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleSurfaceTension(IntPtr solver, IntPtr surface_tension);

	[PreserveSig]
	[Token(Token = "0x600004F")]
	[Address(RVA = "0x1028A28", Offset = "0x1028A28", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20264F8]);\n\tv18 = *([20264F8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), vort_confinement, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20264F8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, vort_confinement, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleVorticityConfinement(IntPtr solver, IntPtr vort_confinement);

	[PreserveSig]
	[Token(Token = "0x6000050")]
	[Address(RVA = "0x1028AD0", Offset = "0x1028AD0", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026500]);\n\tv22 = *([2026500]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), atmospheric_drag, atmospheric_pressure, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026500]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, solver, atmospheric_drag, atmospheric_pressure, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleAtmosphericDragPressure(IntPtr solver, IntPtr atmospheric_drag, IntPtr atmospheric_pressure);

	[PreserveSig]
	[Token(Token = "0x6000051")]
	[Address(RVA = "0x1028B80", Offset = "0x1028B80", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026508]);\n\tv18 = *([2026508]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), diffusion, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026508]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, diffusion, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleDiffusion(IntPtr solver, IntPtr diffusion);

	[PreserveSig]
	[Token(Token = "0x6000052")]
	[Address(RVA = "0x1028C28", Offset = "0x1028C28", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026510]);\n\tv18 = *([2026510]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), vorticities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026510]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, vorticities, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleVorticities(IntPtr solver, IntPtr vorticities);

	[PreserveSig]
	[Token(Token = "0x6000053")]
	[Address(RVA = "0x1028CD0", Offset = "0x1028CD0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026518]);\n\tv18 = *([2026518]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), fluidData, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026518]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, fluidData, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleFluidData(IntPtr solver, IntPtr fluidData);

	[PreserveSig]
	[Token(Token = "0x6000054")]
	[Address(RVA = "0x1028D78", Offset = "0x1028D78", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026520]);\n\tv18 = *([2026520]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), userData, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026520]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, userData, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleUserData(IntPtr solver, IntPtr userData);

	[PreserveSig]
	[Token(Token = "0x6000055")]
	[Address(RVA = "0x1028638", Offset = "0x1028638", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026528]);\n\tv18 = *([2026528]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), anisotropies, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026528]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, anisotropies, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetParticleAnisotropies(IntPtr solver, IntPtr anisotropies);

	[PreserveSig]
	[Token(Token = "0x6000056")]
	[Address(RVA = "0x1038358", Offset = "0x1038358", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026530]);\n\tv14 = *([2026530]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026530]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, solver, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetDeformableTriangleCount(IntPtr solver);

	[PreserveSig]
	[Token(Token = "0x6000057")]
	[Address(RVA = "0x10383F0", Offset = "0x10383F0", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026538]);\n\tv26 = *([2026538]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0027;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), indices, num, destOffset, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([2026538]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0046;\nL_0027:\n\tv86 = indices + 0x20;\n\tv96 = indices != 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_003A;\nL_003A:\n\tv30(v106, solver, v102, num, destOffset, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0046:\n\tv101 = new System.NotSupportedException();\n\tthrow v101;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableTriangles(IntPtr solver, int[] indices, int num, int destOffset);

	[PreserveSig]
	[Token(Token = "0x6000058")]
	[Address(RVA = "0x10384B8", Offset = "0x10384B8", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026540]);\n\tv22 = *([2026540]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), num, sourceOffset, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026540]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(returnVal1, solver, num, sourceOffset, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal1;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int RemoveDeformableTriangles(IntPtr solver, int num, int sourceOffset);

	[PreserveSig]
	[Token(Token = "0x6000059")]
	[Address(RVA = "0x1029F64", Offset = "0x1029F64", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026548]);\n\tv22 = *([2026548]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), type, parameters, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026548]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, solver, type, parameters, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetConstraintGroupParameters(IntPtr solver, int type, ref ConstraintParameters parameters);

	[PreserveSig]
	[Token(Token = "0x600005A")]
	[Address(RVA = "0x1038568", Offset = "0x1038568", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026550]);\n\tv22 = *([2026550]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), type, parameters, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026550]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, solver, type, parameters, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetConstraintGroupParameters(IntPtr solver, int type, ref ConstraintParameters parameters);

	[PreserveSig]
	[Token(Token = "0x600005B")]
	[Address(RVA = "0x1038618", Offset = "0x1038618", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026558]);\n\tv26 = *([2026558]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0027;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), materials, indices, num, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([2026558]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0055;\nL_0027:\n\tv86 = materials + 0x20;\n\tv96 = indices + 0x20;\n\tv97 = materials != 0;\n\tif (v97) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv113 = indices != 0;\n\tif (v113) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tv30(v122, solver, v103, v119, num, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0055:\n\tv102 = new System.NotSupportedException();\n\tthrow v102;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetCollisionMaterials(IntPtr solver, IntPtr[] materials, int[] indices, int num);

	[PreserveSig]
	[Token(Token = "0x600005C")]
	[Address(RVA = "0x1027E5C", Offset = "0x1027E5C", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026560]);\n\tv18 = *([2026560]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0024;\n\tv22 = 0x1821000 + 0xF74;\n\tv35 = 0x8D848C(&v22 @ X8_v4 (System.Int32), restPositions, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([2026560]) = v35;\n\tv74 = v35 == 0;\n\tif (v74) goto L_002E;\nL_0024:\n\tv22(v79, solver, restPositions, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\nL_002E:\n\tv111 = new System.NotSupportedException();\n\tthrow v111;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetRestPositions(IntPtr solver, IntPtr restPositions);

	[PreserveSig]
	[Token(Token = "0x600005D")]
	[Address(RVA = "0x1028050", Offset = "0x1028050", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026568]);\n\tv18 = *([2026568]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), restOrientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026568]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, restOrientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetRestOrientations(IntPtr solver, IntPtr restOrientations);

	[PreserveSig]
	[Token(Token = "0x600005E")]
	[Address(RVA = "0x10386E8", Offset = "0x10386E8", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2026570]);\n\tv38 = *([2026570]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_002D;\n\tv42 = 0x1821000 + 0xF74;\n\tv56 = 0x8D848C(&v42 @ X8_v4 (System.Int32), halfEdge, skinConstraintBatch, worldToLocal, particleIndices, vertexCapacity, vertexCount, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\t*([2026570]) = v56;\n\tv92 = v56 == 0;\n\tif (v92) goto L_0052;\nL_002D:\n\tv95 = worldToLocal + 0x20;\n\tv105 = worldToLocal != 0;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tv42(returnVal1, solver, halfEdge, skinConstraintBatch, v111, particleIndices, vertexCapacity, vertexCount, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\treturn returnVal1;\nL_0052:\n\tv110 = new System.NotSupportedException();\n\tthrow v110;\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateDeformableMesh(IntPtr solver, IntPtr halfEdge, IntPtr skinConstraintBatch, float[] worldToLocal, IntPtr particleIndices, int vertexCapacity, int vertexCount);

	[PreserveSig]
	[Token(Token = "0x600005F")]
	[Address(RVA = "0x10387D0", Offset = "0x10387D0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026578]);\n\tv18 = *([2026578]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), mesh, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026578]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, mesh, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyDeformableMesh(IntPtr solver, IntPtr mesh);

	[PreserveSig]
	[Token(Token = "0x6000060")]
	[Address(RVA = "0x1038878", Offset = "0x1038878", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([2026580]);\n\tv34 = *([2026580]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_002B;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), vertexIndex, planePoint, planeNormal, updated_edges, num_edges, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\t*([2026580]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_0059;\nL_002B:\n\tv92 = updated_edges + 0x20;\n\tv102 = updated_edges != 0;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_0040:\n\tv38(v114, mesh, vertexIndex, planePoint, planeNormal, v108, num_edges, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv128 = v114 == 0;\n\tv133 = ~v128;\n\treturn v133;\nL_0059:\n\tv107 = new System.NotSupportedException();\n\tthrow v107;\n\treturn returnVal2;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern bool TearDeformableMeshAtVertex(IntPtr mesh, int vertexIndex, ref Vector3 planePoint, ref Vector3 planeNormal, int[] updated_edges, ref int num_edges);

	[PreserveSig]
	[Token(Token = "0x6000061")]
	[Address(RVA = "0x1038960", Offset = "0x1038960", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026588]);\n\tv22 = *([2026588]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), normalsUpdate, skinTangents, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026588]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, mesh, normalsUpdate, skinTangents, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshTBNUpdate(IntPtr mesh, NormalsUpdate normalsUpdate, bool skinTangents);

	[PreserveSig]
	[Token(Token = "0x6000062")]
	[Address(RVA = "0x1038A10", Offset = "0x1038A10", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026590]);\n\tv18 = *([2026590]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), worldToLocal, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026590]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_003E;\nL_0023:\n\tv80 = worldToLocal + 0x20;\n\tv90 = worldToLocal != 0;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv22(v98, mesh, v96, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_003E:\n\tv95 = new System.NotSupportedException();\n\tthrow v95;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshTransform(IntPtr mesh, float[] worldToLocal);

	[PreserveSig]
	[Token(Token = "0x6000063")]
	[Address(RVA = "0x1038AC0", Offset = "0x1038AC0", Length = "0xAC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026598]);\n\tv22 = *([2026598]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0027;\n\tv26 = 0x1821000 + 0xF74;\n\tv39 = 0x8D848C(&v26 @ X8_v4 (System.Int32), sourceMesh, triangleSkinMap, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\t*([2026598]) = v39;\n\tv77 = v39 == 0;\n\tif (v77) goto L_0032;\nL_0027:\n\tv26(v83, mesh, sourceMesh, triangleSkinMap, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturn;\nL_0032:\n\tv117 = new System.NotSupportedException();\n\tthrow v117;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshSkinMap(IntPtr mesh, IntPtr sourceMesh, IntPtr triangleSkinMap);

	[PreserveSig]
	[Token(Token = "0x6000064")]
	[Address(RVA = "0x1038B6C", Offset = "0x1038B6C", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20265A0]);\n\tv18 = *([20265A0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), particleIndices, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20265A0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, mesh, particleIndices, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshParticleIndices(IntPtr mesh, IntPtr particleIndices);

	[PreserveSig]
	[Token(Token = "0x6000065")]
	[Address(RVA = "0x1038C14", Offset = "0x1038C14", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = *([20265A8]);\n\tv42 = *([20265A8]) == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_003B;\n\tv46 = 0x1821000 + 0xF74;\n\tv60 = 0x8D848C(&v46 @ X8_v4 (System.Int32), triangles, vertices, normals, tangents, colors, uv1, uv2, v61, v62, v63, v64, v65, v66, v67, v68);\n\t*([20265A8]) = v60;\n\tv95 = v60 == 0;\n\tif (v95) goto L_004B;\nL_003B:\n\tv46(v110, mesh, triangles, vertices, normals, tangents, colors, uv1, uv2, v61, v62, v63, v64, v65, v66, v67, v68);\n\treturn;\nL_004B:\n\tv164 = new System.NotSupportedException();\n\tthrow v164;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshData(IntPtr mesh, IntPtr triangles, IntPtr vertices, IntPtr normals, IntPtr tangents, IntPtr colors, IntPtr uv1, IntPtr uv2, IntPtr uv3, IntPtr uv4);

	[PreserveSig]
	[Token(Token = "0x6000066")]
	[Address(RVA = "0x1038D0C", Offset = "0x1038D0C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([20265B0]);\n\tv26 = *([20265B0]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0027;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), bindPoses, weights, numBones, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([20265B0]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0055;\nL_0027:\n\tv86 = bindPoses + 0x20;\n\tv96 = weights + 0x20;\n\tv97 = bindPoses != 0;\n\tif (v97) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv113 = weights != 0;\n\tif (v113) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tv30(v122, mesh, v103, v119, numBones, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0055:\n\tv102 = new System.NotSupportedException();\n\tthrow v102;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshAnimationData(IntPtr mesh, float[] bindPoses, BoneWeights[] weights, int numBones);

	[PreserveSig]
	[Token(Token = "0x6000067")]
	[Address(RVA = "0x1038DDC", Offset = "0x1038DDC", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20265B8]);\n\tv18 = *([20265B8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), boneTransforms, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20265B8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_003E;\nL_0023:\n\tv80 = boneTransforms + 0x20;\n\tv90 = boneTransforms != 0;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv22(v98, mesh, v96, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_003E:\n\tv95 = new System.NotSupportedException();\n\tthrow v95;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDeformableMeshBoneTransforms(IntPtr mesh, float[] boneTransforms);

	[PreserveSig]
	[Token(Token = "0x6000068")]
	[Address(RVA = "0x1038E8C", Offset = "0x1038E8C", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20265C0]);\n\tv14 = *([20265C0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20265C0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, mesh, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void ForceDeformableMeshSkeletalSkinning(IntPtr mesh);

	[PreserveSig]
	[Token(Token = "0x6000069")]
	[Address(RVA = "0x102F25C", Offset = "0x102F25C", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20265C8]);\n\tv14 = *([20265C8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20265C8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateBatch(int type);

	[PreserveSig]
	[Token(Token = "0x600006A")]
	[Address(RVA = "0x1038F24", Offset = "0x1038F24", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20265D0]);\n\tv18 = *([20265D0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), dependency, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20265D0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, batch, dependency, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDependency(IntPtr batch, IntPtr dependency);

	[PreserveSig]
	[Token(Token = "0x600006B")]
	[Address(RVA = "0x1038FCC", Offset = "0x1038FCC", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20265D8]);\n\tv14 = *([20265D8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20265D8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, batch, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyBatch(IntPtr batch);

	[PreserveSig]
	[Token(Token = "0x600006C")]
	[Address(RVA = "0x102F2F4", Offset = "0x102F2F4", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20265E0]);\n\tv18 = *([20265E0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), batch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20265E0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(returnVal1, solver, batch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr AddBatch(IntPtr solver, IntPtr batch);

	[PreserveSig]
	[Token(Token = "0x600006D")]
	[Address(RVA = "0x102F39C", Offset = "0x102F39C", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20265E8]);\n\tv18 = *([20265E8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), batch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20265E8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, batch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void RemoveBatch(IntPtr solver, IntPtr batch);

	[PreserveSig]
	[Token(Token = "0x600006E")]
	[Address(RVA = "0x102ECAC", Offset = "0x102ECAC", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20265F0]);\n\tv18 = *([20265F0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), enabled, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20265F0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_003A;\nL_0025:\n\tv22(v82, batch, enabled, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv92 = v82 == 0;\n\tv97 = ~v92;\n\treturn v97;\nL_003A:\n\tv144 = new System.NotSupportedException();\n\tthrow v144;\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern bool EnableBatch(IntPtr batch, bool enabled);

	[PreserveSig]
	[Token(Token = "0x600006F")]
	[Address(RVA = "0x1039064", Offset = "0x1039064", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20265F8]);\n\tv14 = *([20265F8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20265F8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, batch, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetBatchConstraintCount(IntPtr batch);

	[PreserveSig]
	[Token(Token = "0x6000070")]
	[Address(RVA = "0x10390FC", Offset = "0x10390FC", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026600]);\n\tv26 = *([2026600]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0026;\n\tv30 = 0x1821000 + 0xF74;\n\tv43 = 0x8D848C(&v30 @ X8_v4 (System.Int32), forces, num, destOffset, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\t*([2026600]) = v43;\n\tv80 = v43 == 0;\n\tif (v80) goto L_0045;\nL_0026:\n\tv83 = forces + 0x20;\n\tv93 = forces != 0;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\tv30(returnVal1, batch, v99, num, destOffset, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\treturn returnVal1;\nL_0045:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetBatchConstraintForces(IntPtr batch, float[] forces, int num, int destOffset);

	[PreserveSig]
	[Token(Token = "0x6000071")]
	[Address(RVA = "0x1023438", Offset = "0x1023438", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026608]);\n\tv18 = *([2026608]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), num, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026608]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, batch, num, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetActiveConstraints(IntPtr batch, int num);

	[PreserveSig]
	[Token(Token = "0x6000072")]
	[Address(RVA = "0x10391C0", Offset = "0x10391C0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026610]);\n\tv18 = *([2026610]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), num, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026610]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, batch, num, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetConstraintCount(IntPtr batch, int num);

	[PreserveSig]
	[Token(Token = "0x6000073")]
	[Address(RVA = "0x1039268", Offset = "0x1039268", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026618]);\n\tv30 = *([2026618]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_002E;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), indices, restLengths, stiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026618]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_003B;\nL_002E:\n\tv34(v94, batch, indices, restLengths, stiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_003B:\n\tv135 = new System.NotSupportedException();\n\tthrow v135;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetDistanceConstraints(IntPtr batch, IntPtr indices, IntPtr restLengths, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x6000074")]
	[Address(RVA = "0x1039330", Offset = "0x1039330", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026620]);\n\tv30 = *([2026620]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_002E;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), indices, restBends, bendingStiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026620]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_003B;\nL_002E:\n\tv34(v94, batch, indices, restBends, bendingStiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_003B:\n\tv135 = new System.NotSupportedException();\n\tthrow v135;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetBendingConstraints(IntPtr batch, IntPtr indices, IntPtr restBends, IntPtr bendingStiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x6000075")]
	[Address(RVA = "0x1023FFC", Offset = "0x1023FFC", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2026628]);\n\tv38 = *([2026628]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0034;\n\tv42 = 0x1821000 + 0xF74;\n\tv56 = 0x8D848C(&v42 @ X8_v4 (System.Int32), indices, points, normals, radiiBackstops, stiffnesses, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\t*([2026628]) = v56;\n\tv92 = v56 == 0;\n\tif (v92) goto L_0043;\nL_0034:\n\tv42(v102, batch, indices, points, normals, radiiBackstops, stiffnesses, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\treturn;\nL_0043:\n\tv149 = new System.NotSupportedException();\n\tthrow v149;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetSkinConstraints(IntPtr batch, IntPtr indices, IntPtr points, IntPtr normals, IntPtr radiiBackstops, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x6000076")]
	[Address(RVA = "0x10393F8", Offset = "0x10393F8", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026630]);\n\tv26 = *([2026630]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_002B;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), particleIndices, aerodynamicCoeffs, num, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([2026630]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0037;\nL_002B:\n\tv30(v90, batch, particleIndices, aerodynamicCoeffs, num, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0037:\n\tv128 = new System.NotSupportedException();\n\tthrow v128;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetAerodynamicConstraints(IntPtr batch, IntPtr particleIndices, IntPtr aerodynamicCoeffs, int num);

	[PreserveSig]
	[Token(Token = "0x6000077")]
	[Address(RVA = "0x1033EC0", Offset = "0x1033EC0", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([2026638]);\n\tv34 = *([2026638]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_0031;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), triangleIndices, firstTriangle, restVolumes, pressureStiffnesses, num, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\t*([2026638]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_003F;\nL_0031:\n\tv38(v98, batch, triangleIndices, firstTriangle, restVolumes, pressureStiffnesses, num, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn;\nL_003F:\n\tv142 = new System.NotSupportedException();\n\tthrow v142;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetVolumeConstraints(IntPtr batch, IntPtr triangleIndices, IntPtr firstTriangle, IntPtr restVolumes, IntPtr pressureStiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x6000078")]
	[Address(RVA = "0x1023338", Offset = "0x1023338", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = *([2026640]);\n\tv42 = *([2026640]) == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_003B;\n\tv46 = 0x1821000 + 0xF74;\n\tv60 = 0x8D848C(&v46 @ X8_v4 (System.Int32), shapeIndices, firstIndex, numIndices, explicitGroup, materialParameters, restComs, coms, v61, v62, v63, v64, v65, v66, v67, v68);\n\t*([2026640]) = v60;\n\tv95 = v60 == 0;\n\tif (v95) goto L_004B;\nL_003B:\n\tv46(v110, batch, shapeIndices, firstIndex, numIndices, explicitGroup, materialParameters, restComs, coms, v61, v62, v63, v64, v65, v66, v67, v68);\n\treturn;\nL_004B:\n\tv164 = new System.NotSupportedException();\n\tthrow v164;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetShapeMatchingConstraints(IntPtr batch, IntPtr shapeIndices, IntPtr firstIndex, IntPtr numIndices, IntPtr explicitGroup, IntPtr materialParameters, IntPtr restComs, IntPtr coms, IntPtr orientations, int num);

	[PreserveSig]
	[Token(Token = "0x6000079")]
	[Address(RVA = "0x10234E0", Offset = "0x10234E0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026648]);\n\tv18 = *([2026648]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), batch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026648]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, solver, batch, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void CalculateRestShapeMatching(IntPtr solver, IntPtr batch);

	[PreserveSig]
	[Token(Token = "0x600007A")]
	[Address(RVA = "0x10300C4", Offset = "0x10300C4", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2026650]);\n\tv38 = *([2026650]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0034;\n\tv42 = 0x1821000 + 0xF74;\n\tv56 = 0x8D848C(&v42 @ X8_v4 (System.Int32), particleIndices, orientationIndices, restLengths, restOrientations, stiffnesses, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\t*([2026650]) = v56;\n\tv92 = v56 == 0;\n\tif (v92) goto L_0043;\nL_0034:\n\tv42(v102, batch, particleIndices, orientationIndices, restLengths, restOrientations, stiffnesses, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\treturn;\nL_0043:\n\tv149 = new System.NotSupportedException();\n\tthrow v149;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetStretchShearConstraints(IntPtr batch, IntPtr particleIndices, IntPtr orientationIndices, IntPtr restLengths, IntPtr restOrientations, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x600007B")]
	[Address(RVA = "0x10394B8", Offset = "0x10394B8", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026658]);\n\tv30 = *([2026658]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_002E;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), orientationIndices, restDarboux, stiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026658]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_003B;\nL_002E:\n\tv34(v94, batch, orientationIndices, restDarboux, stiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_003B:\n\tv135 = new System.NotSupportedException();\n\tthrow v135;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetBendTwistConstraints(IntPtr batch, IntPtr orientationIndices, IntPtr restDarboux, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x600007C")]
	[Address(RVA = "0x1030F60", Offset = "0x1030F60", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026660]);\n\tv30 = *([2026660]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_002E;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), indices, maxLenghtsScales, stiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026660]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_003B;\nL_002E:\n\tv34(v94, batch, indices, maxLenghtsScales, stiffnesses, num, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_003B:\n\tv135 = new System.NotSupportedException();\n\tthrow v135;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetTetherConstraints(IntPtr batch, IntPtr indices, IntPtr maxLenghtsScales, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x600007D")]
	[Address(RVA = "0x1039580", Offset = "0x1039580", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2026668]);\n\tv38 = *([2026668]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0034;\n\tv42 = 0x1821000 + 0xF74;\n\tv56 = 0x8D848C(&v42 @ X8_v4 (System.Int32), indices, pinOffsets, restDarboux, colliders, stiffnesses, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\t*([2026668]) = v56;\n\tv92 = v56 == 0;\n\tif (v92) goto L_0043;\nL_0034:\n\tv42(v102, batch, indices, pinOffsets, restDarboux, colliders, stiffnesses, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\treturn;\nL_0043:\n\tv149 = new System.NotSupportedException();\n\tthrow v149;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetPinConstraints(IntPtr batch, IntPtr indices, IntPtr pinOffsets, IntPtr restDarboux, IntPtr colliders, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x600007E")]
	[Address(RVA = "0x102F444", Offset = "0x102F444", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = *([2026670]);\n\tv26 = *([2026670]) == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_002B;\n\tv30 = 0x1821000 + 0xF74;\n\tv44 = 0x8D848C(&v30 @ X8_v4 (System.Int32), indices, stiffnesses, num, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\t*([2026670]) = v44;\n\tv83 = v44 == 0;\n\tif (v83) goto L_0037;\nL_002B:\n\tv30(v90, batch, indices, stiffnesses, num, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\treturn;\nL_0037:\n\tv128 = new System.NotSupportedException();\n\tthrow v128;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetStitchConstraints(IntPtr batch, IntPtr indices, IntPtr stiffnesses, int num);

	[PreserveSig]
	[Token(Token = "0x600007F")]
	[Address(RVA = "0x1039660", Offset = "0x1039660", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([2026678]);\n\tv34 = *([2026678]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_0031;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), indices, lengths, firstIndex, numIndex, num, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\t*([2026678]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_003F;\nL_0031:\n\tv38(v98, batch, indices, lengths, firstIndex, numIndex, num, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn;\nL_003F:\n\tv142 = new System.NotSupportedException();\n\tthrow v142;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetChainConstraints(IntPtr batch, IntPtr indices, IntPtr lengths, IntPtr firstIndex, IntPtr numIndex, int num);

	[PreserveSig]
	[Token(Token = "0x6000080")]
	[Address(RVA = "0x102C478", Offset = "0x102C478", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026680]);\n\tv22 = *([2026680]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0024;\n\tv26 = 0x1821000 + 0xF74;\n\tv39 = 0x8D848C(&v26 @ X8_v4 (System.Int32), contacts, n, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\t*([2026680]) = v39;\n\tv77 = v39 == 0;\n\tif (v77) goto L_0041;\nL_0024:\n\tv80 = contacts + 0x20;\n\tv90 = contacts != 0;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_0036;\nL_0036:\n\tv26(v99, solver, v96, n, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturn;\nL_0041:\n\tv95 = new System.NotSupportedException();\n\tthrow v95;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetCollisionContacts(IntPtr solver, Contact[] contacts, int n);

	[PreserveSig]
	[Token(Token = "0x6000081")]
	[Address(RVA = "0x102C90C", Offset = "0x102C90C", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2026688]);\n\tv22 = *([2026688]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0025;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), contacts, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2026688]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0042;\nL_0025:\n\tv83 = contacts + 0x20;\n\tv93 = contacts != 0;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv26(v102, solver, v99, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0042:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetParticleCollisionContacts(IntPtr solver, Contact[] contacts, int n);

	[PreserveSig]
	[Token(Token = "0x6000082")]
	[Address(RVA = "0x1039738", Offset = "0x1039738", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([2026690]);\n\tv34 = *([2026690]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_0031;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), properties, diffusePositions, diffuseProperties, neighbourCount, n, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\t*([2026690]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_003F;\nL_0031:\n\tv38(returnVal1, solver, properties, diffusePositions, diffuseProperties, neighbourCount, n, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn returnVal1;\nL_003F:\n\tv142 = new System.NotSupportedException();\n\tthrow v142;\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int InterpolateDiffuseParticles(IntPtr solver, IntPtr properties, IntPtr diffusePositions, IntPtr diffuseProperties, IntPtr neighbourCount, int n);

	[PreserveSig]
	[Token(Token = "0x6000083")]
	[Address(RVA = "0x1039810", Offset = "0x1039810", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026698]);\n\tv10 = *([2026698]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026698]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateHalfEdgeMesh();

	[PreserveSig]
	[Token(Token = "0x6000084")]
	[Address(RVA = "0x1039898", Offset = "0x1039898", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20266A0]);\n\tv14 = *([20266A0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20266A0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, mesh, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyHalfEdgeMesh(IntPtr mesh);

	[PreserveSig]
	[Token(Token = "0x6000085")]
	[Address(RVA = "0x1039930", Offset = "0x1039930", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([20266A8]);\n\tv22 = *([20266A8]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), vertices, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([20266A8]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, mesh, vertices, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetVertices(IntPtr mesh, IntPtr vertices, int n);

	[PreserveSig]
	[Token(Token = "0x6000086")]
	[Address(RVA = "0x10399E0", Offset = "0x10399E0", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([20266B0]);\n\tv22 = *([20266B0]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), halfedges, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([20266B0]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, mesh, halfedges, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetHalfEdges(IntPtr mesh, IntPtr halfedges, int n);

	[PreserveSig]
	[Token(Token = "0x6000087")]
	[Address(RVA = "0x1039A90", Offset = "0x1039A90", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([20266B8]);\n\tv22 = *([20266B8]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0028;\n\tv26 = 0x1821000 + 0xF74;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), faces, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([20266B8]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0033;\nL_0028:\n\tv26(v86, mesh, faces, n, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0033:\n\tv121 = new System.NotSupportedException();\n\tthrow v121;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetFaces(IntPtr mesh, IntPtr faces, int n);

	[PreserveSig]
	[Token(Token = "0x6000088")]
	[Address(RVA = "0x1039B40", Offset = "0x1039B40", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20266C0]);\n\tv18 = *([20266C0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), normals, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20266C0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, mesh, normals, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetNormals(IntPtr mesh, IntPtr normals);

	[PreserveSig]
	[Token(Token = "0x6000089")]
	[Address(RVA = "0x1039BE8", Offset = "0x1039BE8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20266C8]);\n\tv18 = *([20266C8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), tangents, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20266C8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, mesh, tangents, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetTangents(IntPtr mesh, IntPtr tangents);

	[PreserveSig]
	[Token(Token = "0x600008A")]
	[Address(RVA = "0x1039C90", Offset = "0x1039C90", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20266D0]);\n\tv18 = *([20266D0]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), orientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20266D0]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, mesh, orientations, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetInverseOrientations(IntPtr mesh, IntPtr orientations);

	[PreserveSig]
	[Token(Token = "0x600008B")]
	[Address(RVA = "0x1039D38", Offset = "0x1039D38", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20266D8]);\n\tv18 = *([20266D8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), map, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20266D8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, mesh, map, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetVisualMap(IntPtr mesh, IntPtr map);

	[PreserveSig]
	[Token(Token = "0x600008C")]
	[Address(RVA = "0x1039DE0", Offset = "0x1039DE0", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20266E0]);\n\tv14 = *([20266E0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20266E0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, mesh, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetVertexCount(IntPtr mesh);

	[PreserveSig]
	[Token(Token = "0x600008D")]
	[Address(RVA = "0x1039E78", Offset = "0x1039E78", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20266E8]);\n\tv14 = *([20266E8]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20266E8]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, mesh, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetHalfEdgeCount(IntPtr mesh);

	[PreserveSig]
	[Token(Token = "0x600008E")]
	[Address(RVA = "0x1039F10", Offset = "0x1039F10", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20266F0]);\n\tv14 = *([20266F0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20266F0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, mesh, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetFaceCount(IntPtr mesh);

	[PreserveSig]
	[Token(Token = "0x600008F")]
	[Address(RVA = "0x1039FA8", Offset = "0x1039FA8", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20266F8]);\n\tv18 = *([20266F8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), meshInfo, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20266F8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(returnVal1, mesh, meshInfo, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetHalfEdgeMeshInfo(IntPtr mesh, ref MeshInformation meshInfo);

	[PreserveSig]
	[Token(Token = "0x6000090")]
	[Address(RVA = "0x103A050", Offset = "0x103A050", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026700]);\n\tv30 = *([2026700]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_0029;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), vertices, triangles, vertexCount, triangleCount, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026700]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_0059;\nL_0029:\n\tv89 = vertices + 0x20;\n\tv99 = triangles + 0x20;\n\tv100 = vertices != 0;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tv116 = triangles != 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_004C:\n\tv34(v126, mesh, v106, v122, vertexCount, triangleCount, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_0059:\n\tv105 = new System.NotSupportedException();\n\tthrow v105;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void CalculatePrimitiveCounts(IntPtr mesh, Vector3[] vertices, int[] triangles, int vertexCount, int triangleCount);

	[PreserveSig]
	[Token(Token = "0x6000091")]
	[Address(RVA = "0x103A128", Offset = "0x103A128", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([2026708]);\n\tv34 = *([2026708]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_002B;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), vertices, triangles, vertexCount, triangleCount, scale, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\t*([2026708]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_005D;\nL_002B:\n\tv92 = vertices + 0x20;\n\tv102 = triangles + 0x20;\n\tv103 = vertices != 0;\n\tif (v103) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv119 = triangles != 0;\n\tif (v119) goto L_FFFFFFFF;\n\tgoto L_004F;\nL_004F:\n\tv38(v130, mesh, v109, v125, vertexCount, triangleCount, scale, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn;\nL_005D:\n\tv108 = new System.NotSupportedException();\n\tthrow v108;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void Generate(IntPtr mesh, Vector3[] vertices, int[] triangles, int vertexCount, int triangleCount, ref Vector3 scale);

	[PreserveSig]
	[Token(Token = "0x6000092")]
	[Address(RVA = "0x103A210", Offset = "0x103A210", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = *([2026710]);\n\tv42 = *([2026710]) == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_002F;\n\tv46 = 0x1821000 + 0xF74;\n\tv60 = 0x8D848C(&v46 @ X8_v4 (System.Int32), count, hintNormal, centroid, orientation, principalValues, methodInfo, v62, maxAnisotropy, radius, v63, v64, v65, v66, v67, v68);\n\t*([2026710]) = v60;\n\tv95 = v60 == 0;\n\tif (v95) goto L_0056;\nL_002F:\n\tv98 = points + 0x20;\n\tv108 = points != 0;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_0046;\nL_0046:\n\tv46(v122, v114, count, hintNormal, centroid, orientation, principalValues, methodInfo, v62, maxAnisotropy, radius, v63, v64, v65, v66, v67, v68);\n\treturn;\nL_0056:\n\tv113 = new System.NotSupportedException();\n\tthrow v113;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetPointCloudAnisotropy(Vector3[] points, int count, float maxAnisotropy, float radius, ref Vector3 hintNormal, ref Vector3 centroid, ref Quaternion orientation, ref Vector3 principalValues);

	[PreserveSig]
	[Token(Token = "0x6000093")]
	[Address(RVA = "0x103A308", Offset = "0x103A308", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026718]);\n\tv18 = *([2026718]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), flags, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026718]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(returnVal1, group, flags, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int MakePhase(int group, ParticleFlags flags);

	[PreserveSig]
	[Token(Token = "0x6000094")]
	[Address(RVA = "0x103A3B0", Offset = "0x103A3B0", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026720]);\n\tv14 = *([2026720]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026720]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, phase, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetGroupFromPhase(int phase);

	[PreserveSig]
	[Token(Token = "0x6000095")]
	[Address(RVA = "0x103A448", Offset = "0x103A448", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026728]);\n\tv14 = *([2026728]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026728]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, phase, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetFlagsFromPhase(int phase);

	[PreserveSig]
	[Token(Token = "0x6000096")]
	[Address(RVA = "0x103A4E0", Offset = "0x103A4E0", Length = "0xA0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026730]);\n\tv14 = *([2026730]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, returnVal2, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026730]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_003A;\nL_0021:\n\tv77 = constraintCoordinates + 0x20;\n\tv87 = constraintCoordinates != 0;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\tv18(v94, v93, methodInfo, v34, v35, v36, v37, v38, v39, returnVal2, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal2;\nL_003A:\n\tv92 = new System.NotSupportedException();\n\tthrow v92;\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern float BendingConstraintRest(float[] constraintCoordinates);

	[PreserveSig]
	[Token(Token = "0x6000097")]
	[Address(RVA = "0x103A580", Offset = "0x103A580", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026738]);\n\tv10 = *([2026738]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026738]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateTriangleSkinMap();

	[PreserveSig]
	[Token(Token = "0x6000098")]
	[Address(RVA = "0x103A608", Offset = "0x103A608", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026740]);\n\tv14 = *([2026740]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026740]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, skinmap, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void DestroyTriangleSkinMap(IntPtr skinmap);

	[PreserveSig]
	[Token(Token = "0x6000099")]
	[Address(RVA = "0x103A6A0", Offset = "0x103A6A0", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = *([2026748]);\n\tv30 = *([2026748]) == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_0029;\n\tv34 = 0x1821000 + 0xF74;\n\tv48 = 0x8D848C(&v34 @ X8_v4 (System.Int32), sourcemesh, targetmesh, sourceMasterFlags, targetSlaveFlags, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\t*([2026748]) = v48;\n\tv86 = v48 == 0;\n\tif (v86) goto L_0059;\nL_0029:\n\tv89 = sourceMasterFlags + 0x20;\n\tv99 = targetSlaveFlags + 0x20;\n\tv100 = sourceMasterFlags != 0;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tv116 = targetSlaveFlags != 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_004C:\n\tv34(v126, skinmap, sourcemesh, targetmesh, v106, v122, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\nL_0059:\n\tv105 = new System.NotSupportedException();\n\tthrow v105;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void Bind(IntPtr skinmap, IntPtr sourcemesh, IntPtr targetmesh, uint[] sourceMasterFlags, uint[] targetSlaveFlags);

	[PreserveSig]
	[Token(Token = "0x600009A")]
	[Address(RVA = "0x103A778", Offset = "0x103A778", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026750]);\n\tv14 = *([2026750]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2026750]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(returnVal1, skinmap, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetSkinnedVertexCount(IntPtr skinmap);

	[PreserveSig]
	[Token(Token = "0x600009B")]
	[Address(RVA = "0x103A810", Offset = "0x103A810", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([2026758]);\n\tv34 = *([2026758]) == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_002B;\n\tv38 = 0x1821000 + 0xF74;\n\tv52 = 0x8D848C(&v38 @ X8_v4 (System.Int32), skinIndices, sourceTriIndices, baryPositions, baryNormals, baryTangents, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\t*([2026758]) = v52;\n\tv89 = v52 == 0;\n\tif (v89) goto L_008A;\nL_002B:\n\tv92 = skinIndices + 0x20;\n\tv102 = sourceTriIndices + 0x20;\n\tv103 = skinIndices != 0;\n\tif (v103) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv119 = baryPositions + 0x20;\n\tv120 = sourceTriIndices != 0;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tv136 = baryNormals + 0x20;\n\tv137 = baryPositions != 0;\n\tif (v137) goto L_FFFFFFFF;\n\tgoto L_0065;\nL_0065:\n\tv185 = baryTangents + 0x20;\n\tv219 = baryNormals != 0;\n\tif (v219) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_0075:\n\tv149 = baryTangents != 0;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_007C;\nL_007C:\n\tv38(v183, skinmap, v109, v126, v145, v143, v141, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn;\nL_008A:\n\tv108 = new System.NotSupportedException();\n\tthrow v108;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void GetSkinInfo(IntPtr skinmap, int[] skinIndices, int[] sourceTriIndices, Vector3[] baryPositions, Vector3[] baryNormals, Vector3[] baryTangents);

	[PreserveSig]
	[Token(Token = "0x600009C")]
	[Address(RVA = "0x103A910", Offset = "0x103A910", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2026760]);\n\tv38 = *([2026760]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_002D;\n\tv42 = 0x1821000 + 0xF74;\n\tv56 = 0x8D848C(&v42 @ X8_v4 (System.Int32), skinIndices, sourceTriIndices, baryPositions, baryNormals, baryTangents, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\t*([2026760]) = v56;\n\tv92 = v56 == 0;\n\tif (v92) goto L_008E;\nL_002D:\n\tv95 = skinIndices + 0x20;\n\tv105 = sourceTriIndices + 0x20;\n\tv106 = skinIndices != 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tv122 = baryPositions + 0x20;\n\tv123 = sourceTriIndices != 0;\n\tif (v123) goto L_FFFFFFFF;\n\tgoto L_0057;\nL_0057:\n\tv139 = baryNormals + 0x20;\n\tv140 = baryPositions != 0;\n\tif (v140) goto L_FFFFFFFF;\n\tgoto L_0067;\nL_0067:\n\tv190 = baryTangents + 0x20;\n\tv226 = baryNormals != 0;\n\tif (v226) goto L_FFFFFFFF;\n\tgoto L_0077;\nL_0077:\n\tv154 = baryTangents != 0;\n\tif (v154) goto L_FFFFFFFF;\n\tgoto L_007F;\nL_007F:\n\tv42(v188, skinmap, v112, v129, v150, v148, v146, num, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65);\n\treturn;\nL_008E:\n\tv111 = new System.NotSupportedException();\n\tthrow v111;\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void SetSkinInfo(IntPtr skinmap, int[] skinIndices, int[] sourceTriIndices, Vector3[] baryPositions, Vector3[] baryNormals, Vector3[] baryTangents, int num);

	[PreserveSig]
	[Token(Token = "0x600009D")]
	[Address(RVA = "0x103AA18", Offset = "0x103AA18", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026768]);\n\tv10 = *([2026768]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026768]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(v70, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void CompleteAll();

	[PreserveSig]
	[Token(Token = "0x600009E")]
	[Address(RVA = "0x10315DC", Offset = "0x10315DC", Length = "0x94")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026770]);\n\tv14 = *([2026770]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1821000 + 0xF74;\n\tv31 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([2026770]) = v31;\n\tv71 = v31 == 0;\n\tif (v71) goto L_002A;\nL_0021:\n\tv18(v75, task, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\nL_002A:\n\tv105 = new System.NotSupportedException();\n\tthrow v105;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void Complete(IntPtr task);

	[PreserveSig]
	[Token(Token = "0x600009F")]
	[Address(RVA = "0x1031418", Offset = "0x1031418", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026778]);\n\tv10 = *([2026778]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026778]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern IntPtr CreateEmpty();

	[PreserveSig]
	[Token(Token = "0x60000A0")]
	[Address(RVA = "0x1031548", Offset = "0x1031548", Length = "0x94")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2026780]);\n\tv14 = *([2026780]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0021;\n\tv18 = 0x1821000 + 0xF74;\n\tv31 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([2026780]) = v31;\n\tv71 = v31 == 0;\n\tif (v71) goto L_002A;\nL_0021:\n\tv18(v75, task, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\nL_002A:\n\tv105 = new System.NotSupportedException();\n\tthrow v105;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void Schedule(IntPtr task);

	[PreserveSig]
	[Token(Token = "0x60000A1")]
	[Address(RVA = "0x10314A0", Offset = "0x10314A0", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([2026788]);\n\tv18 = *([2026788]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0025;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v4 (System.Int32), child, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([2026788]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_002F;\nL_0025:\n\tv22(v82, task, child, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_002F:\n\tv115 = new System.NotSupportedException();\n\tthrow v115;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void AddChild(IntPtr task, IntPtr child);

	[PreserveSig]
	[Token(Token = "0x60000A2")]
	[Address(RVA = "0x103AAA0", Offset = "0x103AAA0", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026790]);\n\tv10 = *([2026790]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026790]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetMaxSystemConcurrency();

	[PreserveSig]
	[Token(Token = "0x60000A3")]
	[Address(RVA = "0x103AB28", Offset = "0x103AB28", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([2026798]);\n\tv10 = *([2026798]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([2026798]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(v70, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void ClearProfiler();

	[PreserveSig]
	[Token(Token = "0x60000A4")]
	[Address(RVA = "0x103ABB0", Offset = "0x103ABB0", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([20267A0]);\n\tv14 = *([20267A0]) == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0022;\n\tv18 = 0x1821000 + 0xF74;\n\tv32 = 0x8D848C(&v18 @ X8_v4 (System.Int32), methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20267A0]) = v32;\n\tv74 = v32 == 0;\n\tif (v74) goto L_002B;\nL_0022:\n\tv18(v78, cooked, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_002B:\n\tv109 = new System.NotSupportedException();\n\tthrow v109;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void EnableProfiler(bool cooked);

	[PreserveSig]
	[Token(Token = "0x60000A5")]
	[Address(RVA = "0x103AC48", Offset = "0x103AC48", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([20267A8]);\n\tv18 = *([20267A8]) == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0023;\n\tv22 = 0x1821000 + 0xF74;\n\tv36 = 0x8D848C(&v22 @ X8_v5 (System.Int32), type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20267A8]) = v36;\n\tv77 = v36 == 0;\n\tif (v77) goto L_0033;\nL_0023:\n\tv80 = 0x8D8464(name, type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([20267A8])(v84, v80, type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv86 = 0x8D8480(v80, type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_0033:\n\tv89 = new System.NotSupportedException();\n\tthrow v89;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void BeginSample(string name, byte type);

	[PreserveSig]
	[Token(Token = "0x60000A6")]
	[Address(RVA = "0x103AD00", Offset = "0x103AD00", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([20267B0]);\n\tv10 = *([20267B0]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([20267B0]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(v70, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern void EndSample();

	[PreserveSig]
	[Token(Token = "0x60000A7")]
	[Address(RVA = "0x103AD88", Offset = "0x103AD88", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv69 = *([20267B8]);\n\tv10 = *([20267B8]) == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_001D;\n\tv14 = 0x1821000 + 0xF74;\n\tv69 = 0x8D848C(&v14 @ X8_v3 (System.Int32), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\t*([20267B8]) = v69;\n\tv68 = v69 == 0;\n\tif (v68) goto L_0025;\nL_001D:\n\tv69(returnVal1, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\nL_0025:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static extern int GetProfilingInfoCount();

	[PreserveSig]
	[Token(Token = "0x60000A8")]
	[Address(RVA = "0x103AE10", Offset = "0x103AE10", Length = "0xDDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = *([20267C0]);\n\tv28 = *([20267C0]) == 0;\n\tv29 = ~v28;\n\tif (v29) goto L_0028;\n\tv32 = 0x1821000 + 0xF74;\n\tv46 = 0x8D848C(&v32 @ X8_v8 (System.Int32), num, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([20267C0]) = v46;\n\tv87 = v46 == 0;\n\tif (v87) goto L_006E;\nL_0028:\n\tv90 = info == 0;\n\tif (v90) goto L_005F;\n\tv32 = info.Length;\n\tv93 = info.Length * 0x58;\n\tv95 = 0x8D82B8(v93, num, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv105 = 0x6D26F0(v95, 0, v93, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv32 = *([20267C0]);\n\t*([20267C0])(v146, v95, num, v93, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv150 = v95 == 0;\n\tif (v150) goto L_006B;\n\tv114 = info.Length < 1;\n\tif (v114) goto L_005B;\n\tv261 = info.Length & 0xFFFFFFFF;\n\tv265 = v95 + 0x18;\n\tv264 = info + 0x20;\nL_004E:\n\tv249 = 0x8D8470(v265, num, v93, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v264 @ X19_v6]) = *([v265 @ X20_v6-18]);\n\t*([v264 @ X19_v6+8]) = *([v265 @ X20_v6-10]);\n\t*([v264 @ X19_v6+10]) = *([v265 @ X20_v6-8]);\n\t*([v264 @ X19_v6+14]) = *([v265 @ X20_v6-4]);\n\t*([v264 @ X19_v6+18]) = v249;\n\tv265 = v265 + 0x58;\n\tv247 = v261 - 1;\n\tv264 = v264 + 0x20;\n\tv250 = v261 != 1;\n\tif (v250) goto L_004E;\nL_005B:\n\tv147 = 0x8D8480(v95, num, v93, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tgoto L_006B;\nL_005F:\n\tv32(v98, 0, num, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\nL_006B:\n\treturn;\nL_006E:\n\tv101 = new System.NotSupportedException();\n\tthrow v101;\n\tv235 = 0x100DD4C(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21]) = v235;\n\tv240 = 0x100DD54(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+4]) = v240;\n\tv257 = 0x100DD5C(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+8]) = v257;\n\tv270 = 0x100DD64(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+C]) = v270;\n\tv274 = 0x100DD2C(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+10]) = v53;\n\tv277 = 0x100DD34(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+14]) = v53;\n\tv280 = 0x100DD3C(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+18]) = v53;\n\tv214 = 0x100DD44(0, 0, 0, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t*([v173 @ X0_v21+1C]) = v53;\n\treturn;\n\t// 160 ShiftStack -192\n\tstack[50] = V14;\n\tstack[60] = V13;\n\tstack[68] = V12;\n\tstack[70] = V11;\n\tstack[78] = V10;\n\tstack[80] = V9;\n\tstack[88] = V8;\n\tstack[90] = X22;\n\tstack[98] = X21;\n\tstack[A0] = X20;\n\tstack[A8] = X19;\n\tstack[B0] = X29;\n\tstack[B8] = X30;\n\tX29 = &stack[B0];\n\tX8 = *([20267C8]);\n\tV8 = V0;\n\tX21 = X2;\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BF;\n\tX8 = *([1EEFC00]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20267C8]) = X8;\nL_00BF:\n\tstack[38] = 0;\n\tstack[40] = 0;\n\tstack[30] = 0;\n\tif (TEMP) goto L_017C;\n\tX8 = &stack[18];\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.Collider::get_bounds(X0, X1);\n\tstack[18] = *([X8]);\n\tstack[1C] = *([X8+4]);\n\tstack[20] = *([X8+8]);\n\tstack[24] = *([X8+C]);\n\tstack[28] = *([X8+10]);\n\tstack[2C] = *([X8+14]);\n\tX8 = stack[28];\n\tV0 = stack[18];\n\tX0 = &stack[30];\n\tX1 = 0;\n\tstack[40] = X8;\n\tstack[30] = V0;\n\tX0 = 0x100E4C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE1550]);\n\tV9 = V0;\n\tV10 = V1;\n\tV11 = V2;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00E4;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E4;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00E4:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector3::get_one(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X20;\n\tX1 = 0;\n\tV12 = V0;\n\tV13 = V1;\n\tV14 = V2;\n\tV0 = UnityEngine.Collider::get_contactOffset(X0, X1);\n\tV3 = V0 + V8;\n\tV0 = V12;\n\tV1 = V13;\n\tV2 = V14;\n\tX0 = 0;\n\t// 243 MakeStruct AGG103B0E4_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Multiply(AGG103B0E4_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = V0;\n\tV4 = V1;\n\tV5 = V2;\n\tV0 = V9;\n\tV1 = V10;\n\tV2 = V11;\n\tX0 = 0;\n\t// 254 MakeStruct AGG103B104_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 255 MakeStruct AGG103B104_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Subtraction(AGG103B104_0, AGG103B104_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX8 = &stack[0];\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+28]) = V0;\n\t*([X19+2C]) = V1;\n\t*([X19+30]) = V2;\n\tX0 = UnityEngine.Collider::get_bounds(X0, X1);\n\tstack[0] = *([X8]);\n\tstack[4] = *([X8+4]);\n\tstack[8] = *([X8+8]);\n\tstack[C] = *([X8+C]);\n\tstack[10] = *([X8+10]);\n\tstack[14] = *([X8+14]);\n\tX8 = stack[10];\n\tV0 = stack[0];\n\tX0 = &stack[30];\n\tX1 = 0;\n\tstack[40] = X8;\n\tstack[30] = V0;\n\tX0 = 0x100E564(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0;\n\tV9 = V0;\n\tV10 = V1;\n\tV11 = V2;\n\tV0 = UnityEngine.Vector3::get_one(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X20;\n\tX1 = 0;\n\tV12 = V0;\n\tV13 = V1;\n\tV14 = V2;\n\tV0 = UnityEngine.Collider::get_contactOffset(X0, X1);\n\tV3 = V0 + V8;\n\tV0 = V12;\n\tV1 = V13;\n\tV2 = V14;\n\tX0 = 0;\n\t// 297 MakeStruct AGG103B17C_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Multiply(AGG103B17C_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = V0;\n\tV4 = V1;\n\tV5 = V2;\n\tV0 = V9;\n\tV1 = V10;\n\tV2 = V11;\n\tX0 = 0;\n\t// 308 MakeStruct AGG103B19C_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 309 MakeStruct AGG103B19C_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Addition(AGG103B19C_0, AGG103B19C_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+34]) = V0;\n\t*([X19+38]) = V1;\n\t*([X19+3C]) = V2;\n\tX0 = UnityEngine.Component::get_transform(X0, X1);\n\tif (TEMP) goto L_017D;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+10]) = V0;\n\t*([X19+14]) = V1;\n\t*([X19+18]) = V2;\n\tX0 = UnityEngine.Component::get_transform(X0, X1);\n\tif (TEMP) goto L_017D;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_rotation(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19]) = V0;\n\t*([X19+4]) = V1;\n\t*([X19+8]) = V2;\n\t*([X19+C]) = V3;\n\tX0 = UnityEngine.Component::get_transform(X0, X1);\n\tif (TEMP) goto L_017D;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_lossyScale(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+1C]) = V0;\n\t*([X19+20]) = V1;\n\t*([X19+24]) = V2;\n\t*([X19+44]) = V8;\n\t*([X19+48]) = X21;\n\tX0 = UnityEngine.Collider::get_isTrigger(X0, X1);\n\tX8 = X0 & 1;\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+4C]) = X8;\n\tX0 = UnityEngine.Object::GetInstanceID(X0, X1);\n\t*([X19+40]) = X0;\n\tX29 = stack[B0];\n\tX30 = stack[B8];\n\tX20 = stack[A0];\n\tX19 = stack[A8];\n\tX22 = stack[90];\n\tX21 = stack[98];\n\tV9 = stack[80];\n\tV8 = stack[88];\n\tV11 = stack[70];\n\tV10 = stack[78];\n\tV13 = stack[60];\n\tV12 = stack[68];\n\tV14 = stack[50];\n\t// 378 ShiftStack 192\n\treturn;\nL_017C:\n\tX0 = 0;\nL_017D:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 382 ShiftStack -176\n\tstack[50] = V12;\n\tstack[60] = V11;\n\tstack[68] = V10;\n\tstack[70] = V9;\n\tstack[78] = V8;\n\tstack[80] = X22;\n\tstack[88] = X21;\n\tstack[90] = X20;\n\tstack[98] = X19;\n\tstack[A0] = X29;\n\tstack[A8] = X30;\n\tX29 = &stack[A0];\n\tX8 = *([20267C9]);\n\tV8 = V0;\n\tX21 = X2;\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_019B;\n\tX8 = *([1F04708]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20267C9]) = X8;\nL_019B:\n\tstack[38] = 0;\n\tstack[40] = 0;\n\tstack[30] = 0;\n\tif (TEMP) goto L_0247;\n\tX8 = &stack[18];\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.Collider2D::get_bounds(X0, X1);\n\tstack[18] = *([X8]);\n\tstack[1C] = *([X8+4]);\n\tstack[20] = *([X8+8]);\n\tstack[24] = *([X8+C]);\n\tstack[\n// ... truncated")]
	public static extern void GetProfilingInfo([Out] ProfileInfo[] info, int num);
}
