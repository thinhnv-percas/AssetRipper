using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIExtensions
{
	[Serializable]
	[Token(Token = "0x200001E")]
	public class AnimatableProperty : ISerializationCallbackReceiver
	{
		[Token(Token = "0x200001F")]
		public enum ShaderPropertyType
		{
			[Token(Token = "0x4000030")]
			Color = 0,
			[Token(Token = "0x4000031")]
			Vector = 1,
			[Token(Token = "0x4000032")]
			Float = 2,
			[Token(Token = "0x4000033")]
			Range = 3,
			[Token(Token = "0x4000034")]
			Texture = 4
		}

		[SerializeField]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x10")]
		private string m_Name;

		[SerializeField]
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x18")]
		private ShaderPropertyType m_Type;

		[Token(Token = "0x17000004")]
		[field: Token(Token = "0x400002E")]
		[field: FieldOffset(Offset = "0x1C")]
		public int id
		{
			[Token(Token = "0x600008A")]
			[Address(RVA = "0x3F22A10", Offset = "0x3F22A10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n")]
			get;
			[Token(Token = "0x600008B")]
			[Address(RVA = "0x3F22A18", Offset = "0x3F22A18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000005")]
		public ShaderPropertyType type
		{
			[Token(Token = "0x600008C")]
			[Address(RVA = "0x3F22A20", Offset = "0x3F22A20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type;\n")]
			get
			{
				return m_Type;
			}
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x3F22A28", Offset = "0x3F22A28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x3F22A2C", Offset = "0x3F22A2C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Shader::PropertyToID(this.m_Name);\n\tthis.id = v14;\n\treturn;\n")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			int num = Shader.PropertyToID(m_Name);
			id = num;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x3F22A58", Offset = "0x3F22A58", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv52 = UnityEngine.Material::HasProperty(material, this.id);\n\tv120 = ~v52;\n\tif (v120) goto L_0125;\n\tv57 = this.type <= 1;\n\tif (v57) goto L_0083;\n\tv54 = this.type - 2;\n\tv309 = v54 < 2;\n\tv104 = ~v309;\n\tif (v104) goto L_00C4;\n\tv154 = UnityEngine.MaterialPropertyBlock::GetFloat(mpb, this.id);\n\tgoto L_004E;\n\tgoto L_006B;\nL_FFFFFFFF:\n\tv144 = v140;\n\tUnityEngine.Material::SetFloat(material, this.id, v154);\n\treturn;\nL_0083:\n\tv203 = this.type == 0;\n\tif (v203) goto L_00E0;\n\tv58 = this.type != 1;\n\tif (v58) goto L_0125;\n\tv152 = UnityEngine.MaterialPropertyBlock::GetVector(mpb, this.id);\n\tv343 = v152 * v152;\n\tv344 = v152.y * v152.y;\n\tv345 = v343 + v344;\n\tv346 = v152.z * v152.z;\n\tv347 = v346 + v345;\n\tv348 = v152.w * v152.w;\n\tv134 = v348 + v347;\n\tv173 = v134 < 0x2EDBE6FE;\n\tif (v173) goto L_0125;\n\tUnityEngine.Material::SetVector(material, this.id, v152);\n\treturn;\nL_00C4:\n\tv59 = this.type != 4;\n\tif (v59) goto L_0125;\n\tv321 = UnityEngine.MaterialPropertyBlock::GetTexture(mpb, this.id);\n\tgoto L_00D6;\nL_00D6:\n\tv198 = UnityEngine.Object::op_Inequality(v321, 0);\n\tv370 = ~v198;\n\tv204 = ~v370;\n\tif (v204) goto L_011A;\n\tgoto L_0125;\nL_00E0:\n\tv153 = UnityEngine.MaterialPropertyBlock::GetColor(mpb, this.id);\n\tv322 = v153 * v153;\n\tv323 = v153.g * v153.g;\n\tv324 = v322 + v323;\n\tv325 = v153.b * v153.b;\n\tv326 = v325 + v324;\n\tv327 = v153.a * v153.a;\n\tv135 = v327 + v326;\n\tv174 = v135 < 0x2EDBE6FE;\n\tif (v174) goto L_0125;\n\tUnityEngine.Material::SetColor(material, this.id, v153);\n\treturn;\nL_011A:\n\tUnityEngine.Material::SetTexture(material, this.id, v321);\n\treturn;\nL_0125:\n\treturn;\nL_004E:\n\tv338 = UnityEngine.Mathf::Abs(v154);\n\tv352 = UnityEngine.Mathf::Max(v338, 0f);\n\tv144 = v352 * 0x358637BD;\n\tv140 = v356.Epsilon * 8f;\n\tv361 = v144 < v140;\n\tv362 = v144 == v140;\n\tv365 = v144 == v144;\n\tv366 = v140 == v140;\n\tv367 = v365 & v366;\n\tv368 = ~v367;\n\tv369 = v361 == v368;\n\tv132 = ~v362;\n\tv157 = v369 & v132;\n\tv129 = ~v157;\n\tif (v129) goto L_FFFFFFFF;\nL_006B:\n\t// 107 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv175 = 0 < v144;\n\tif (v175) goto L_0125;\n")]
		public void UpdateMaterialProperties(Material material, MaterialPropertyBlock mpb)
		{
			if (!material.HasProperty(id))
			{
				return;
			}
			if (type > ShaderPropertyType.Vector)
			{
				int num = (int)(type - 2);
				if ((uint)num < 2u)
				{
					float num2 = mpb.GetFloat(id);
					float a = Mathf.Abs(num2);
					float num3 = Mathf.Max(a, 0f);
					float num4 = num3 * 1E-06f;
					float num5 = Mathf.Epsilon * 8f;
					bool flag = num4 < num5;
					bool flag2 = num4 == num5;
					bool flag3 = num4 == num4;
					bool flag4 = num5 == num5;
					bool flag5 = flag3 && flag4;
					bool flag6 = !flag5;
					bool flag7 = flag == flag6;
					bool flag8 = !flag2;
					if (!(flag7 && flag8))
					{
						num4 = num5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					if (!(0f < num4))
					{
						material.SetFloat(id, num2);
					}
				}
				else if (type == ShaderPropertyType.Texture)
				{
					Texture texture = mpb.GetTexture(id);
					if (texture != null)
					{
						material.SetTexture(id, texture);
					}
				}
			}
			else if (type != ShaderPropertyType.Color)
			{
				if (type == ShaderPropertyType.Vector)
				{
					Vector4 vector = mpb.GetVector(id);
					float num6 = vector.x * vector.x;
					float num7 = vector.y * vector.y;
					float num8 = num6 + num7;
					float num9 = vector.z * vector.z;
					float num10 = num9 + num8;
					float num11 = vector.w * vector.w;
					float num12 = num11 + num10;
					if (!(num12 < 9.9999994E-11f))
					{
						material.SetVector(id, vector);
					}
				}
			}
			else
			{
				Color color = mpb.GetColor(id);
				float num13 = color.r * color.r;
				float num14 = color.g * color.g;
				float num15 = num13 + num14;
				float num16 = color.b * color.b;
				float num17 = num16 + num15;
				float num18 = color.a * color.a;
				float num19 = num18 + num17;
				if (!(num19 < 9.9999994E-11f))
				{
					material.SetColor(id, color);
				}
			}
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x3F22CE4", Offset = "0x3F22CE4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.m_Name = \"\";\n\tthis.type = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AnimatableProperty()
		{
			m_Name = "";
			m_Type = ShaderPropertyType.Vector;
		}
	}
}
