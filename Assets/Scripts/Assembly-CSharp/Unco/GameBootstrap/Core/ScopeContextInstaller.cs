using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007DC")]
	internal class ScopeContextInstaller : IContainerInstaller
	{
		[Token(Token = "0x4001A53")]
		[FieldOffset(Offset = "0x10")]
		private readonly Transform _parentTransform;

		[Token(Token = "0x4001A54")]
		[FieldOffset(Offset = "0x18")]
		private readonly string _scopeName;

		[Token(Token = "0x6002146")]
		[Address(RVA = "0x3DC3ADC", Offset = "0x3DC3ADC", Length = "0x50")]
		public ScopeContextInstaller(Transform parentTransform, string scopeName)
		{
			_parentTransform = parentTransform;
			_scopeName = scopeName;
		}

		[Token(Token = "0x6002147")]
		[Address(RVA = "0x3DC3B2C", Offset = "0x3DC3B2C", Length = "0x160")]
		public void InstallBindings(ref ContainerInstanceBuilder builder)
		{
			Func<Instancer, ScopeContext> factory = (Instancer instancer) => new ScopeContext(_parentTransform, instancer, _scopeName);
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(ScopeContext);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = typeFromHandle;
			builder.AddSingleton(factory, array);
		}
	}
}
