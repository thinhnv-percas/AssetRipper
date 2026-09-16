using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[CreateAssetMenu]
	[Token(Token = "0x2000029")]
	public class ObiCollisionMaterial : ScriptableObject
	{
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x18")]
		private IntPtr oniCollisionMaterial;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x20")]
		private Oni.CollisionMaterial adaptor;

		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x40")]
		public float dynamicFriction;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x44")]
		public float staticFriction;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x48")]
		public float stickiness;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x4C")]
		public float stickDistance;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x50")]
		public Oni.MaterialCombineMode frictionCombine;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x54")]
		public Oni.MaterialCombineMode stickinessCombine;

		[Space]
		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x58")]
		public bool rollingContacts;

		[Indent]
		[AttributeAttribute(Type = typeof(VisibleIf), RVA = "0x745C1C", Offset = "0x745C1C")]
		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x5C")]
		public float rollingFriction;

		[Token(Token = "0x17000037")]
		public IntPtr OniCollisionMaterial
		{
			[Token(Token = "0x6000239")]
			[Address(RVA = "0xE426C0", Offset = "0xE426C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.oniCollisionMaterial;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OniCollisionMaterial;
			}
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0xE426C8", Offset = "0xE426C8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Oni::CreateCollisionMaterial();\n\tthis.oniCollisionMaterial = v11;\n\tObi.ObiCollisionMaterial::OnValidate(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			IntPtr intPtr = Oni.CreateCollisionMaterial();
			oniCollisionMaterial = intPtr;
			OnValidate();
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xE42730", Offset = "0xE42730", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED0DC0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024729]) = v38;\nL_0015:\n\tOni::DestroyCollisionMaterial(this.oniCollisionMaterial);\n\tthis.oniCollisionMaterial = 0;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			Oni.DestroyCollisionMaterial(OniCollisionMaterial);
			oniCollisionMaterial = (IntPtr)0;
		}

		[Token(Token = "0x600023C")]
		[Address(RVA = "0xE426F4", Offset = "0xE426F4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this + 0x20;\n\tthis.adaptor = this.dynamicFriction;\n\tthis.adaptor.rollingFriction = this.rollingFriction;\n\tthis.adaptor.stickiness = this.stickiness;\n\tthis.adaptor.stickDistance = this.stickDistance;\n\tthis.adaptor.frictionCombine = this.frictionCombine;\n\tthis.adaptor.stickinessCombine = this.stickinessCombine;\n\tthis.adaptor.rollingContacts = this.rollingContacts;\n\tOni::UpdateCollisionMaterial(this.oniCollisionMaterial, v5);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnValidate()
		{
			//IL_0018: Expected O, but got F4
			ref Oni.CollisionMaterial reference = ref *(Oni.CollisionMaterial*)((long)(IntPtr)this + 32L);
			adaptor = (Oni.CollisionMaterial)dynamicFriction;
			adaptor.rollingFriction = rollingFriction;
			adaptor.stickiness = stickiness;
			adaptor.stickDistance = stickDistance;
			adaptor.frictionCombine = frictionCombine;
			adaptor.stickinessCombine = stickinessCombine;
			adaptor.rollingContacts = rollingContacts;
			Oni.UpdateCollisionMaterial(OniCollisionMaterial, ref reference);
		}

		[Token(Token = "0x600023D")]
		[Address(RVA = "0xE42780", Offset = "0xE42780", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF5C78]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202472A]) = v38;\nL_0013:\n\tthis.oniCollisionMaterial = 0;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCollisionMaterial()
		{
			oniCollisionMaterial = (IntPtr)0;
		}
	}
}
