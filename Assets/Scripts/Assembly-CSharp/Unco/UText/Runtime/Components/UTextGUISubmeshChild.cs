using System;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;
using UnityEngine;

namespace Unco.UText.Runtime.Components
{
	[Token(Token = "0x20007C4")]
	internal sealed class UTextGUISubmeshChild
	{
		[Token(Token = "0x40019FF")]
		[FieldOffset(Offset = "0x10")]
		public GameObject GameObject;

		[Token(Token = "0x4001A00")]
		[FieldOffset(Offset = "0x18")]
		public RectTransform RectTransform;

		[Token(Token = "0x4001A01")]
		[FieldOffset(Offset = "0x20")]
		public CanvasRenderer Renderer;

		[Token(Token = "0x4001A02")]
		[FieldOffset(Offset = "0x28")]
		public Mesh Mesh;

		[Token(Token = "0x60020CE")]
		[Address(RVA = "0x3DBCE6C", Offset = "0x3DBCE6C", Length = "0x19C")]
		public void SetActive(bool a)
		{
			if (GameObject == null)
			{
				return;
			}
			CanvasRenderer renderer;
			bool cull;
			if (a)
			{
				if (!(Renderer != null))
				{
					goto IL_012b;
				}
				renderer = Renderer;
				cull = false;
			}
			else
			{
				if (!(Renderer != null))
				{
					goto IL_012b;
				}
				Renderer.SetMesh(null);
				Renderer.Clear();
				renderer = Renderer;
				cull = true;
			}
			renderer.cull = cull;
			goto IL_012b;
			IL_012b:
			bool activeSelf = GameObject.activeSelf;
			if (activeSelf != a)
			{
				GameObject.SetActive(a);
			}
		}

		[Token(Token = "0x60020CF")]
		[Address(RVA = "0x3DBC5C0", Offset = "0x3DBC5C0", Length = "0x378")]
		public void ApplySubmesh(TextMeshBuilder.Result result, TextMeshBuilder.SubMeshRange range, Material material)
		{
			if (Mesh == null)
			{
				return;
			}
			Vector3[] array = new Vector3[range.VertexCount];
			Vector2[] array2 = new Vector2[range.VertexCount];
			Vector2[] array3 = new Vector2[range.VertexCount];
			Color32[] array4 = new Color32[range.VertexCount];
			int[] array5 = new int[range.IndexCount];
			Array.Copy(result.Vertices, range.VertexStart, array, 0, range.VertexCount);
			Array.Copy(result.UVs, range.VertexStart, array2, 0, range.VertexCount);
			Array.Copy(result.UV2, range.VertexStart, array3, 0, range.VertexCount);
			Array.Copy(result.Colors, range.VertexStart, array4, 0, range.VertexCount);
			if (range.IndexCount >= 1)
			{
				int[] triangles = result.Triangles;
				int num = 0;
				do
				{
					int num2 = num + range.IndexStart;
					int num3 = triangles[num2] - range.VertexStart;
					array5[num] = num3;
					num++;
				}
				while (range.IndexCount != num);
			}
			Mesh.Clear();
			Mesh.SetVertices(array);
			Mesh.SetUVs(0, array2);
			Mesh.SetUVs(1, array3);
			Mesh.SetColors(array4);
			Mesh.SetTriangles(array5, 0, calculateBounds: false);
			Bounds bounds = result.Bounds;
			Mesh.bounds = bounds;
			if (Renderer != null)
			{
				Renderer.SetMesh(Mesh);
				Renderer.SetMaterial(material, range.Texture);
			}
		}

		[Token(Token = "0x60020D0")]
		[Address(RVA = "0x3DBD008", Offset = "0x3DBD008", Length = "0x70")]
		public void Destroy()
		{
			DestroyObj(Mesh);
			Mesh = null;
			DestroyObj(GameObject);
			GameObject = null;
			RectTransform = null;
			Renderer = null;
		}

		[Token(Token = "0x60020D1")]
		[Address(RVA = "0x3DBD1D4", Offset = "0x3DBD1D4", Length = "0x154")]
		internal static void DestroyObj(UnityEngine.Object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUISubmeshChild::DestroyObj");
		}

		[Token(Token = "0x60020D2")]
		[Address(RVA = "0x3DBD1CC", Offset = "0x3DBD1CC", Length = "0x8")]
		public UTextGUISubmeshChild()
		{
		}
	}
}
