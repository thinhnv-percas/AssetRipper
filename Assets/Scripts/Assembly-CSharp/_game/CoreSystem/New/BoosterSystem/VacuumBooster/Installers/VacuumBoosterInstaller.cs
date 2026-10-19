using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;
using _game.CoreSystem.VacuumSystem;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Installers
{
	[Token(Token = "0x200045B")]
	public class VacuumBoosterInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200045C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000E20")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000E21")]
			public static Func<Instancer, VacuumTargetPlanner> _003C_003E9__2_0;

			[Token(Token = "0x4000E22")]
			public static Func<Instancer, VacuumReservationService> _003C_003E9__2_1;

			[Token(Token = "0x4000E23")]
			public static Func<Instancer, VacuumDispatchCoordinator> _003C_003E9__2_2;

			[Token(Token = "0x4000E24")]
			public static Func<Instancer, VacuumSequenceRunner> _003C_003E9__2_3;

			[Token(Token = "0x4000E25")]
			public static Func<Instancer, VacuumFacade> _003C_003E9__2_4;

			[Token(Token = "0x600124F")]
			[Address(RVA = "0x3CCE2CC", Offset = "0x3CCE2CC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001250")]
			[Address(RVA = "0x3CCE330", Offset = "0x3CCE330", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal VacuumTargetPlanner _003CInstallBindings_003Eb__2_0(Instancer x)
			{
				VacuumTargetPlanner instance = new VacuumTargetPlanner();
				return x.InjectInstance(instance);
			}

			internal VacuumReservationService _003CInstallBindings_003Eb__2_1(Instancer x)
			{
				VacuumReservationService instance = new VacuumReservationService();
				return x.InjectInstance(instance);
			}

			internal VacuumDispatchCoordinator _003CInstallBindings_003Eb__2_2(Instancer x)
			{
				VacuumDispatchCoordinator instance = new VacuumDispatchCoordinator();
				return x.InjectInstance(instance);
			}

			internal VacuumSequenceRunner _003CInstallBindings_003Eb__2_3(Instancer x)
			{
				VacuumSequenceRunner instance = new VacuumSequenceRunner();
				return x.InjectInstance(instance);
			}

			internal VacuumFacade _003CInstallBindings_003Eb__2_4(Instancer x)
			{
				VacuumFacade instance = new VacuumFacade();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000E1E")]
		[FieldOffset(Offset = "0x18")]
		private VacuumConfig m_config;

		[SerializeField]
		[Token(Token = "0x4000E1F")]
		[FieldOffset(Offset = "0x20")]
		private VacuumSpawner m_vacuumBoosterPrefab;

		[Token(Token = "0x600124D")]
		[Address(RVA = "0x3CCDA90", Offset = "0x3CCDA90", Length = "0x824")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			//IL_090b: Expected O, but got I4
			//IL_0921: Expected O, but got I
			//IL_00a2: Expected O, but got I4
			//IL_04d4: Expected O, but got I4
			//IL_051c: Expected O, but got I4
			//IL_053b: Expected O, but got I
			//IL_054b: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0106: Expected O, but got I
			//IL_015a: Expected O, but got I4
			//IL_05f7: Expected O, but got I4
			//IL_0616: Expected O, but got I
			//IL_0626: Expected O, but got I
			//IL_094a: Expected O, but got I4
			//IL_0960: Expected O, but got I
			//IL_0212: Expected O, but got I4
			//IL_01ae: Expected O, but got I
			//IL_01be: Expected O, but got I
			//IL_05af: Expected O, but got I4
			//IL_06d2: Expected O, but got I4
			//IL_06f1: Expected O, but got I
			//IL_0701: Expected O, but got I
			//IL_02ca: Expected O, but got I4
			//IL_0266: Expected O, but got I
			//IL_0276: Expected O, but got I
			//IL_0989: Expected O, but got I4
			//IL_099f: Expected O, but got I
			//IL_07ad: Expected O, but got I4
			//IL_07cc: Expected O, but got I
			//IL_07dc: Expected O, but got I
			//IL_068a: Expected O, but got I4
			//IL_031e: Expected O, but got I
			//IL_032e: Expected O, but got I
			//IL_09c8: Expected O, but got I4
			//IL_09de: Expected O, but got I
			//IL_0765: Expected O, but got I4
			//IL_0a07: Expected O, but got I4
			//IL_0a1d: Expected O, but got I
			containerBuilder.AddSingleton(m_config);
			bool flag = m_vacuumBoosterPrefab != null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			VacuumSpawner vacuumSpawner = null;
			int num;
			if (!flag3)
			{
				num = 187289600 + 664;
			}
			else
			{
				VacuumSpawner spawnerInstance;
				VacuumSpawner vacuumSpawner2 = (spawnerInstance = UnityEngine.Object.Instantiate(m_vacuumBoosterPrefab));
				Func<Instancer, VacuumSpawner> factory = delegate(Instancer x)
				{
					bool flag29 = x.TryResolve<GameplayContainerRoot>(out var result);
					if (result == null || !(result.Transform != null))
					{
						return spawnerInstance;
					}
					Transform transform = spawnerInstance.transform;
					transform.SetParent(result.Transform, worldPositionStays: false);
					return spawnerInstance;
				};
				Type[] array = new Type[1];
				Type typeFromHandle = typeof(VacuumSpawner);
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
				containerBuilder.AddSingleton(factory, array);
				num = 187289600 + 664;
				vacuumSpawner = vacuumSpawner2;
			}
			int num2 = 187441152 + 3576;
			bool flag4 = _003C_003Ec._003C_003E9__2_0 == null;
			int num3 = num;
			VacuumSpawner vacuumSpawner3 = vacuumSpawner;
			if (!flag4)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
				object obj2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X0_v157+E4]");
				bool flag5 = (nint)0 == 0;
				num3 = num;
				vacuumSpawner3 = vacuumSpawner;
				if (!flag5)
				{
					goto IL_00d7;
				}
			}
			else
			{
				Func<Instancer, VacuumTargetPlanner> func = delegate(Instancer x)
				{
					VacuumTargetPlanner instance = new VacuumTargetPlanner();
					return x.InjectInstance(instance);
				};
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ X8_v75+B8]");
				object obj4 = (nint)0 + (nint)8;
				obj4 = func;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
				object obj2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X0_v157+E4]");
				bool flag6 = (nint)0 == 0;
				bool flag7 = !flag6;
				num = num;
				vacuumSpawner = vacuumSpawner;
				if (flag7)
				{
					goto IL_00d7;
				}
			}
			object obj5 = num3;
			int num4 = 187441152 + 3560;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X0_v89+B8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v58+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v58+10]");
			bool flag8 = (nint)0 == 0;
			bool flag9 = !flag8;
			num = num3;
			vacuumSpawner = vacuumSpawner3;
			int num5 = num4;
			if (flag9)
			{
				goto IL_0143;
			}
			goto IL_092e;
			IL_09ac:
			object obj8;
			Func<Instancer, VacuumSequenceRunner> func2 = ((_003C_003Ec)obj8)._003CInstallBindings_003Eb__2_3;
			object obj9 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ X8_v39+B8]");
			object obj10 = (nint)0 + (nint)32;
			obj10 = func2;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			object obj11 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ X0_v142+E4]");
			bool flag10 = (nint)0 == 0;
			bool flag11 = !flag10;
			num = num3;
			vacuumSpawner = vacuumSpawner3;
			if (flag11)
			{
				goto IL_02ff;
			}
			goto IL_07a5;
			IL_07a5:
			object obj12 = num3;
			int num6 = 187441152 + 3552;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X0_v47+B8]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ X8_v22+28]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ X8_v22+28]");
			bool flag12 = (nint)0 == 0;
			bool flag13 = !flag12;
			vacuumSpawner = vacuumSpawner3;
			int num7 = num6;
			num = num3;
			if (flag13)
			{
				goto IL_0363;
			}
			goto IL_09eb;
			IL_02ff:
			num6 = 187441152 + 3552;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ X0_v142+B8]");
			obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ X8_v22+28]");
			obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ X8_v22+28]");
			bool flag14 = (nint)0 == 0;
			num7 = num6;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag14)
			{
				goto IL_0363;
			}
			goto IL_09eb;
			IL_02b3:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			obj11 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ X0_v142+E4]");
			bool flag15 = (nint)0 == 0;
			num3 = num;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag15)
			{
				goto IL_02ff;
			}
			goto IL_07a5;
			IL_0247:
			int num8 = 187441152 + 3568;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X0_v147+B8]");
			obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ X8_v34+20]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ X8_v34+20]");
			bool flag16 = (nint)0 == 0;
			int num9 = num8;
			num3 = num;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag16)
			{
				goto IL_02b3;
			}
			goto IL_09ac;
			IL_06ca:
			object obj16 = num3;
			num8 = 187441152 + 3568;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ X0_v61+B8]");
			obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ X8_v34+20]");
			obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ X8_v34+20]");
			bool flag17 = (nint)0 == 0;
			bool flag18 = !flag17;
			num = num3;
			vacuumSpawner = vacuumSpawner3;
			num9 = num8;
			if (flag18)
			{
				goto IL_02b3;
			}
			goto IL_09ac;
			IL_037f:
			UnityEngine.Object obj17;
			if (!(obj17 != null))
			{
				return;
			}
			VacuumBoosterBridge component = ((Component)obj17).GetComponent<VacuumBoosterBridge>();
			VacuumBoosterBridge bridge = component;
			if (bridge != null)
			{
				Func<Instancer, VacuumBoosterBridge> factory2 = (Instancer x) => x.InjectMono(bridge);
				containerBuilder.AddSingleton(factory2);
			}
			return;
			IL_0363:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			obj17 = vacuumSpawner;
			goto IL_037f;
			IL_09eb:
			Func<Instancer, VacuumFacade> func3 = ((_003C_003Ec)obj13)._003CInstallBindings_003Eb__2_4;
			object obj18 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ X8_v27+B8]");
			object obj19 = (nint)0 + (nint)40;
			obj19 = func3;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			obj17 = vacuumSpawner3;
			goto IL_037f;
			IL_00d7:
			num4 = 187441152 + 3560;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X0_v157+B8]");
			obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v58+10]");
			obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v58+10]");
			bool flag19 = (nint)0 == 0;
			num5 = num4;
			num3 = num;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag19)
			{
				goto IL_0143;
			}
			goto IL_092e;
			IL_092e:
			Func<Instancer, VacuumReservationService> func4 = ((_003C_003Ec)obj6)._003CInstallBindings_003Eb__2_1;
			object obj20 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X8_v63+B8]");
			object obj21 = (nint)0 + (nint)16;
			obj21 = func4;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			object obj22 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X0_v152+E4]");
			bool flag20 = (nint)0 == 0;
			bool flag21 = !flag20;
			num = num3;
			vacuumSpawner = vacuumSpawner3;
			if (flag21)
			{
				goto IL_018f;
			}
			goto IL_05ef;
			IL_0143:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			obj22 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X0_v152+E4]");
			bool flag22 = (nint)0 == 0;
			num3 = num;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag22)
			{
				goto IL_018f;
			}
			goto IL_05ef;
			IL_05ef:
			object obj23 = num3;
			int num10 = 187441152 + 3544;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ X0_v75+B8]");
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X8_v46+18]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X8_v46+18]");
			bool flag23 = (nint)0 == 0;
			bool flag24 = !flag23;
			num = num3;
			vacuumSpawner = vacuumSpawner3;
			int num11 = num10;
			if (flag24)
			{
				goto IL_01fb;
			}
			goto IL_096d;
			IL_018f:
			num10 = 187441152 + 3544;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X0_v152+B8]");
			obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X8_v46+18]");
			obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X8_v46+18]");
			bool flag25 = (nint)0 == 0;
			num11 = num10;
			num3 = num;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag25)
			{
				goto IL_01fb;
			}
			goto IL_096d;
			IL_096d:
			Func<Instancer, VacuumDispatchCoordinator> func5 = ((_003C_003Ec)obj24)._003CInstallBindings_003Eb__2_2;
			object obj26 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ X8_v51+B8]");
			object obj27 = (nint)0 + (nint)24;
			obj27 = func5;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			object obj28 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X0_v147+E4]");
			bool flag26 = (nint)0 == 0;
			bool flag27 = !flag26;
			num = num3;
			vacuumSpawner = vacuumSpawner3;
			if (flag27)
			{
				goto IL_0247;
			}
			goto IL_06ca;
			IL_01fb:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			obj28 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X0_v147+E4]");
			bool flag28 = (nint)0 == 0;
			num3 = num;
			vacuumSpawner3 = vacuumSpawner;
			if (!flag28)
			{
				goto IL_0247;
			}
			goto IL_06ca;
		}

		[Token(Token = "0x600124E")]
		[Address(RVA = "0x3CCE2C4", Offset = "0x3CCE2C4", Length = "0x8")]
		public VacuumBoosterInstaller()
		{
		}
	}
}
