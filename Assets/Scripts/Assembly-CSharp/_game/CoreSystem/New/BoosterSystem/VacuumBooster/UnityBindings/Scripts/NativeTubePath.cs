using System;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts
{
	[Token(Token = "0x2000442")]
	public struct NativeTubePath : IDisposable
	{
		[Token(Token = "0x4000D4A")]
		[FieldOffset(Offset = "0x0")]
		private NativeArray<float3> _points;

		[Token(Token = "0x17000167")]
		public int PointCount
		{
			[Token(Token = "0x60011B0")]
			[Address(RVA = "0x3CC374C", Offset = "0x3CC374C", Length = "0x58")]
			get
			{
				if ((object)_points != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts.NativeTubePath)+8]");
					return 0;
				}
				return 0;
			}
		}

		[Token(Token = "0x17000168")]
		public bool IsCreated
		{
			[Token(Token = "0x60011B1")]
			[Address(RVA = "0x3CC37A4", Offset = "0x3CC37A4", Length = "0x48")]
			get
			{
				bool flag = (object)_points == null;
				return !flag;
			}
		}

		[Token(Token = "0x17000169")]
		public float3 this[int i]
		{
			[Token(Token = "0x60011B2")]
			[Address(RVA = "0x3CC37EC", Offset = "0x3CC37EC", Length = "0x18")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NativeTubePath::get_Item");
				return default;
			}
		}

		[Token(Token = "0x60011B3")]
		[Address(RVA = "0x3CC3804", Offset = "0x3CC3804", Length = "0xAC")]
		public NativeTubePath(Transform[] transforms, Allocator allocator)
		{
			if (transforms != null && transforms.Length != 0)
			{
				Allocator allocator2 = default(Allocator);
				NativeArray<float3> points = new NativeArray<float3>(transforms.Length, allocator2);
				_points = points;
				Refresh(transforms);
			}
			else
			{
				_points = default(NativeArray<float3>);
				_ = 0;
			}
		}

		[Token(Token = "0x60011B4")]
		[Address(RVA = "0x3CC38B0", Offset = "0x3CC38B0", Length = "0x13C")]
		public void Refresh(Transform[] transforms)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NativeTubePath::Refresh");
		}

		[Token(Token = "0x60011B5")]
		[Address(RVA = "0x3CC39EC", Offset = "0x3CC39EC", Length = "0x70")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NativeTubePath::Dispose");
		}
	}
}
