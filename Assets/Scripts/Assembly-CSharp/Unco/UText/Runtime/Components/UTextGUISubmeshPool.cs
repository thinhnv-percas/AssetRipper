using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;
using UnityEngine;

namespace Unco.UText.Runtime.Components
{
	[Token(Token = "0x20007C3")]
	internal sealed class UTextGUISubmeshPool
	{
		[Token(Token = "0x40019FC")]
		[FieldOffset(Offset = "0x10")]
		private readonly Transform _parent;

		[Token(Token = "0x40019FD")]
		[FieldOffset(Offset = "0x18")]
		internal readonly List<UTextGUISubmeshChild> _children;

		[Token(Token = "0x40019FE")]
		[FieldOffset(Offset = "0x20")]
		private Material _defaultSpriteMaterial;

		[Token(Token = "0x60020C7")]
		[Address(RVA = "0x3DBC2FC", Offset = "0x3DBC2FC", Length = "0xA8")]
		public UTextGUISubmeshPool(Transform parent)
		{
			List<UTextGUISubmeshChild> children = new List<UTextGUISubmeshChild>();
			_children = children;
			_parent = parent;
		}

		[Token(Token = "0x60020C8")]
		[Address(RVA = "0x3DBB9E0", Offset = "0x3DBB9E0", Length = "0x140")]
		public void Acquire(int count)
		{
			List<UTextGUISubmeshChild> children = _children;
			while (children.Count < count)
			{
				UTextGUISubmeshChild item = CreateChild();
				children.Add(item);
				children = _children;
			}
			int num = 0;
			while (num < children.Count)
			{
				UTextGUISubmeshChild uTextGUISubmeshChild = children[num];
				int num2 = num - count;
				bool flag = num2 < 0;
				int num3 = num ^ count;
				int num4 = num ^ num2;
				int num5 = num3 & num4;
				bool flag2 = num5 < 0;
				bool flag3 = flag == flag2;
				bool active = !flag3;
				uTextGUISubmeshChild.SetActive(active);
				num++;
				children = _children;
				if (_children == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x60020C9")]
		[Address(RVA = "0x3DBC55C", Offset = "0x3DBC55C", Length = "0x64")]
		public UTextGUISubmeshChild Get(int i)
		{
			int index = default(int);
			return _children[index];
		}

		[Token(Token = "0x60020CA")]
		[Address(RVA = "0x3DBC3A4", Offset = "0x3DBC3A4", Length = "0x1B8")]
		public Material ResolveMaterial(UTextSpriteAsset atlas, Material overrideMaterial)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUISubmeshPool::ResolveMaterial");
			return default;
		}

		[Token(Token = "0x60020CB")]
		[Address(RVA = "0x3DBB86C", Offset = "0x3DBB86C", Length = "0x13C")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUISubmeshPool::Dispose");
		}

		[Token(Token = "0x60020CC")]
		[Address(RVA = "0x3DBCA20", Offset = "0x3DBCA20", Length = "0x44C")]
		private UTextGUISubmeshChild CreateChild()
		{
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(RectTransform);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_01df;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(CanvasRenderer);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_01df;
				}
			}
			array[1] = typeFromHandle2;
			GameObject gameObject = new GameObject("UTextGUI.Sprite", array);
			gameObject.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
			Transform transform = gameObject.transform;
			if ((object)transform.GetType() == typeof(RectTransform))
			{
				transform.SetParent(_parent, worldPositionStays: false);
				Vector2 anchorMin = default(Vector2);
				anchorMin.x = Vector2.zero.x;
				anchorMin.y = Vector2.zero.y;
				((RectTransform)transform).anchorMin = anchorMin;
				Vector2 anchorMax = default(Vector2);
				anchorMax.x = Vector2.one.x;
				anchorMax.y = Vector2.one.y;
				((RectTransform)transform).anchorMax = anchorMax;
				Vector2 offsetMin = default(Vector2);
				offsetMin.x = Vector2.zero.x;
				offsetMin.y = Vector2.zero.y;
				((RectTransform)transform).offsetMin = offsetMin;
				Vector2 offsetMax = default(Vector2);
				offsetMax.x = Vector2.zero.x;
				offsetMax.y = Vector2.zero.y;
				((RectTransform)transform).offsetMax = offsetMax;
				Vector3 localScale = default(Vector3);
				localScale.x = Vector3.one.x;
				localScale.y = Vector3.one.y;
				localScale.z = Vector3.one.z;
				transform.localScale = localScale;
				Quaternion localRotation = default(Quaternion);
				localRotation.x = Quaternion.identity.x;
				localRotation.y = Quaternion.identity.y;
				localRotation.z = Quaternion.identity.z;
				localRotation.w = Quaternion.identity.w;
				transform.localRotation = localRotation;
				CanvasRenderer component = gameObject.GetComponent<CanvasRenderer>();
				Mesh mesh = new Mesh();
				mesh.name = "UTextGUI.Sprite";
				mesh.hideFlags = HideFlags.DontSave;
				mesh.MarkDynamic();
				UTextGUISubmeshChild uTextGUISubmeshChild = new UTextGUISubmeshChild();
				uTextGUISubmeshChild.GameObject = gameObject;
				uTextGUISubmeshChild.RectTransform = (RectTransform)transform;
				uTextGUISubmeshChild.Renderer = component;
				uTextGUISubmeshChild.Mesh = mesh;
				return uTextGUISubmeshChild;
			}
			return (UTextGUISubmeshChild)(object)new InvalidCastException();
			IL_01df:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60020CD")]
		[Address(RVA = "0x3DBD078", Offset = "0x3DBD078", Length = "0x154")]
		private static void DestroyObj(UnityEngine.Object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUISubmeshPool::DestroyObj");
		}
	}
}
