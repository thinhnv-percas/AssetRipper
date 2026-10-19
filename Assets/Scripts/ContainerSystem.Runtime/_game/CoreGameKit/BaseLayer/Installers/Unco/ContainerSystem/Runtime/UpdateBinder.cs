using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UncoPackages.ContainerSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x200000B")]
	internal class UpdateBinder : IDisposable
	{
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x10")]
		private IRequireUpdateCall[] _updateUsers;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x18")]
		private IRequireFixedUpdateCall[] _fixedUpdateUsers;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x20")]
		private IRequireAppFocusCall[] _appFocusUsers;

		[Inject(true)]
		[Token(Token = "0x6000013")]
		[Address(RVA = "0x3F2E8E0", Offset = "0x3F2E8E0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = UncoPackages.ContainerSystem.Runtime.Updater::get_Instance();\n\tgoto L_0020;\nL_0020:\n\tv56 = UncoPackages.ContainerSystem.Runtime.Updater::AddUnique(updateUsers, v22._updateUsers);\n\tthis._updateUsers = v56;\n\treturn;\n")]
		public void InitializeUpdateUsers(IEnumerable<IRequireUpdateCall> updateUsers)
		{
			Updater instance = Updater.Instance;
			IRequireUpdateCall[] updateUsers2 = Updater.AddUnique(updateUsers, instance._updateUsers);
			_updateUsers = updateUsers2;
		}

		[Inject(true)]
		[Token(Token = "0x6000014")]
		[Address(RVA = "0x3F2EAC0", Offset = "0x3F2EAC0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = UncoPackages.ContainerSystem.Runtime.Updater::get_Instance();\n\tgoto L_0020;\nL_0020:\n\tv56 = UncoPackages.ContainerSystem.Runtime.Updater::AddUnique(fixedUpdateUsers, v22._fixedUpdateUsers);\n\tthis._fixedUpdateUsers = v56;\n\treturn;\n")]
		public void InitializeFixedUpdateUsers(IEnumerable<IRequireFixedUpdateCall> fixedUpdateUsers)
		{
			Updater instance = Updater.Instance;
			IRequireFixedUpdateCall[] fixedUpdateUsers2 = Updater.AddUnique(fixedUpdateUsers, instance._fixedUpdateUsers);
			_fixedUpdateUsers = fixedUpdateUsers2;
		}

		[Inject(true)]
		[Token(Token = "0x6000015")]
		[Address(RVA = "0x3F2EBA0", Offset = "0x3F2EBA0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = UncoPackages.ContainerSystem.Runtime.Updater::get_Instance();\n\tgoto L_0020;\nL_0020:\n\tv56 = UncoPackages.ContainerSystem.Runtime.Updater::AddUnique(appFocusUsers, v22._appFocusUsers);\n\tthis._appFocusUsers = v56;\n\treturn;\n")]
		public void InitializeAppFocusUsers(IEnumerable<IRequireAppFocusCall> appFocusUsers)
		{
			Updater instance = Updater.Instance;
			IRequireAppFocusCall[] appFocusUsers2 = Updater.AddUnique(appFocusUsers, instance._appFocusUsers);
			_appFocusUsers = appFocusUsers2;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x3F2EC80", Offset = "0x3F2EC80", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UncoPackages.ContainerSystem.Runtime.Updater::get_Instance();\n\tUncoPackages.ContainerSystem.Runtime.Updater::RemoveUpdateUsers(v12, this._updateUsers);\n\tv23 = UncoPackages.ContainerSystem.Runtime.Updater::get_Instance();\n\tUncoPackages.ContainerSystem.Runtime.Updater::RemoveFixedUpdateUsers(v23, this._fixedUpdateUsers);\n\tv24 = UncoPackages.ContainerSystem.Runtime.Updater::get_Instance();\n\tUncoPackages.ContainerSystem.Runtime.Updater::RemoveAppFocusUsers(v24, this._appFocusUsers);\n\treturn;\n")]
		public void Dispose()
		{
			Updater instance = Updater.Instance;
			instance.RemoveUpdateUsers(_updateUsers);
			Updater instance2 = Updater.Instance;
			instance2.RemoveFixedUpdateUsers(_fixedUpdateUsers);
			Updater instance3 = Updater.Instance;
			instance3.RemoveAppFocusUsers(_appFocusUsers);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3F2E8D8", Offset = "0x3F2E8D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UpdateBinder()
		{
		}
	}
}
