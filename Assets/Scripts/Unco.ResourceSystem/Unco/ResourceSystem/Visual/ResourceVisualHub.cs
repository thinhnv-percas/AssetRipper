using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;

namespace Unco.ResourceSystem.Visual
{
	[CreateAssetMenu(fileName = "ResourceVisualHub", menuName = "ScriptableObjects/ResourceSystem/ResourceVisualHub", order = 1)]
	[Token(Token = "0x200001A")]
	public class ResourceVisualHub : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x18")]
		private List<Pair<ResourceType, Sprite>> m_sprites;

		[SerializeField]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x20")]
		private List<Pair<string, Sprite>> m_genericSprites;

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x81D3FC4", Offset = "0x81D3FC4", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv47.type = type;\n\tv65 = new System.Predicate`1<Unco.Utils.Pair`2<Unco.ResourceSystem.ResourceType, UnityEngine.Sprite>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<Unco.ResourceSystem.ResourceType, UnityEngine.Sprite>>::.ctor(v65, v47, Il2CppMethodInfo);\n\tv105 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Object>>::Find(this.m_sprites, v65);\n\treturn v65;\nL_0021:\n\tv47 = new Unco.ResourceSystem.Visual.ResourceVisualHub+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v47);\n")]
		public Sprite GetSprite(ResourceType type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceVisualHub::GetSprite");
			return default;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x81D40B0", Offset = "0x81D40B0", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv51.type = type;\n\tv82 = new System.Predicate`1<Unco.Utils.Pair`2<System.String, UnityEngine.Sprite>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<System.String, UnityEngine.Sprite>>::.ctor(v82, v51, Il2CppMethodInfo);\n\tv154 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>::Find(this.m_genericSprites, v82);\n\tgoto L_0059;\nL_0059:\n\tv161 = UnityEngine.Object::op_Equality(v82, 0);\n\tv163 = ~v161;\n\tv164 = ~v163;\n\tif (v164) goto L_0077;\n\treturn v82;\nL_0077:\n\tv188 = System.String::Concat(\"Sprite for type \", v51.type, \" not found in ResourceVisualHub\");\n\tgoto L_0084;\nL_002F:\n\tv51 = new Unco.ResourceSystem.Visual.ResourceVisualHub+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v51);\nL_0084:\n\tUnityEngine.Debug::LogError(v188);\n\treturn 0;\n")]
		public Sprite GetSprite(string type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceVisualHub::GetSprite");
			return default;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x81D4294", Offset = "0x81D4294", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public ResourceVisualHub()
		{
		}
	}
}
