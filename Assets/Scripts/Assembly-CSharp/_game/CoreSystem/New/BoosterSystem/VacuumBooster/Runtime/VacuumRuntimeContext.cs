using System;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x200044F")]
	public class VacuumRuntimeContext : IDisposable
	{
		[Token(Token = "0x4000DBC")]
		[FieldOffset(Offset = "0x20")]
		public float3 MouthWorld;

		[Token(Token = "0x4000DBD")]
		[FieldOffset(Offset = "0x2C")]
		public float3 DispatchMouthWorld;

		[Token(Token = "0x4000DBE")]
		[FieldOffset(Offset = "0x38")]
		public float3 DispatchMouthRight;

		[Token(Token = "0x4000DBF")]
		[FieldOffset(Offset = "0x44")]
		public float3 DispatchMouthForward;

		[Token(Token = "0x4000DC0")]
		[FieldOffset(Offset = "0x50")]
		public float3 BulbWorldCenter;

		[Token(Token = "0x4000DC1")]
		[FieldOffset(Offset = "0x5C")]
		public float3 BulbUp;

		[Token(Token = "0x4000DC2")]
		[FieldOffset(Offset = "0x68")]
		public float3 BulbRight;

		[Token(Token = "0x4000DC3")]
		[FieldOffset(Offset = "0x74")]
		public float3 BulbForward;

		[Token(Token = "0x4000DC4")]
		[FieldOffset(Offset = "0x80")]
		public float3 BulbScale;

		[Token(Token = "0x4000DC5")]
		[FieldOffset(Offset = "0x8C")]
		public float InitialBulbScaleX;

		[Token(Token = "0x4000DC6")]
		[FieldOffset(Offset = "0x90")]
		public float SuctionMinRadius;

		[Token(Token = "0x4000DC7")]
		[FieldOffset(Offset = "0x94")]
		public float SuctionMaxRadius;

		[Token(Token = "0x4000DC8")]
		[FieldOffset(Offset = "0x98")]
		public float SuctionRadiusDuration;

		[Token(Token = "0x4000DC9")]
		[FieldOffset(Offset = "0xA0")]
		public NativeAnimationCurve SuctionRadiusCurve;

		[Token(Token = "0x4000DCA")]
		[FieldOffset(Offset = "0xB0")]
		public NativeAnimationCurve XYAttractionCurve;

		[Token(Token = "0x4000DCB")]
		[FieldOffset(Offset = "0xC0")]
		public NativeAnimationCurve ZRiseCurve;

		[Token(Token = "0x4000DCC")]
		[FieldOffset(Offset = "0xD0")]
		public float ArrivalRadius;

		[Token(Token = "0x4000DCD")]
		[FieldOffset(Offset = "0xD4")]
		public float VacuumMaxSpeed;

		[Token(Token = "0x4000DCE")]
		[FieldOffset(Offset = "0xD8")]
		public float2 MouthScaleRange;

		[Token(Token = "0x4000DCF")]
		[FieldOffset(Offset = "0xE0")]
		public float Mouth3DAxisMultiplier;

		[Token(Token = "0x4000DD0")]
		[FieldOffset(Offset = "0xE8")]
		public NativeAnimationCurve MouthScaleCurve;

		[Token(Token = "0x4000DD1")]
		[FieldOffset(Offset = "0xF8")]
		public NativeTubePath TubePath;

		[Token(Token = "0x4000DD2")]
		[FieldOffset(Offset = "0x108")]
		public NativeAnimationCurve TubeSpeedCurve;

		[Token(Token = "0x4000DD3")]
		[FieldOffset(Offset = "0x118")]
		public float2 TubeSpeedRange;

		[Token(Token = "0x4000DD4")]
		[FieldOffset(Offset = "0x120")]
		public float TubeRadius;

		[Token(Token = "0x4000DD5")]
		[FieldOffset(Offset = "0x124")]
		public float BulbRadius;

		[Token(Token = "0x4000DD6")]
		[FieldOffset(Offset = "0x128")]
		public float BulbSettleSpeed;

		[Token(Token = "0x4000DD7")]
		[FieldOffset(Offset = "0x12C")]
		public float DispatchRadius;

		[Token(Token = "0x4000DD8")]
		[FieldOffset(Offset = "0x130")]
		public float2 DispatchTubeSpeedRange;

		[Token(Token = "0x4000DD9")]
		[FieldOffset(Offset = "0x138")]
		public NativeAnimationCurve DispatchScaleDownCurve;

		[Token(Token = "0x4000DDA")]
		[FieldOffset(Offset = "0x148")]
		public AbsorptionProfile DispatchProfile;

		[Token(Token = "0x4000DDB")]
		[FieldOffset(Offset = "0x164")]
		public int TotalDispatched;

		[Token(Token = "0x4000DDC")]
		[FieldOffset(Offset = "0x168")]
		public int CurrentBulbCount;

		[Token(Token = "0x4000DDD")]
		[FieldOffset(Offset = "0x170")]
		public VacuumSession Session;

		[Token(Token = "0x17000190")]
		[field: Token(Token = "0x4000DB8")]
		public static VacuumRuntimeContext Current
		{
			[Token(Token = "0x600121F")]
			[Address(RVA = "0x3CCC190", Offset = "0x3CCC190", Length = "0x4C")]
			get;
			[Token(Token = "0x6001220")]
			[Address(RVA = "0x3CCC1DC", Offset = "0x3CCC1DC", Length = "0x5C")]
			private set;
		}

		[Token(Token = "0x17000191")]
		[field: Token(Token = "0x4000DB9")]
		[field: FieldOffset(Offset = "0x10")]
		public bool IsActive
		{
			[Token(Token = "0x6001221")]
			[Address(RVA = "0x3CCC238", Offset = "0x3CCC238", Length = "0x8")]
			get;
			[Token(Token = "0x6001222")]
			[Address(RVA = "0x3CCC240", Offset = "0x3CCC240", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000192")]
		[field: Token(Token = "0x4000DBA")]
		[field: FieldOffset(Offset = "0x11")]
		public bool IsSuctioning
		{
			[Token(Token = "0x6001223")]
			[Address(RVA = "0x3CCC248", Offset = "0x3CCC248", Length = "0x8")]
			get;
			[Token(Token = "0x6001224")]
			[Address(RVA = "0x3CCC250", Offset = "0x3CCC250", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000193")]
		[field: Token(Token = "0x4000DBB")]
		[field: FieldOffset(Offset = "0x18")]
		public double SuctionStartTime
		{
			[Token(Token = "0x6001225")]
			[Address(RVA = "0x3CCC258", Offset = "0x3CCC258", Length = "0x8")]
			get;
			[Token(Token = "0x6001226")]
			[Address(RVA = "0x3CCC260", Offset = "0x3CCC260", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x6001227")]
		[Address(RVA = "0x3CCC268", Offset = "0x3CCC268", Length = "0x6C")]
		public void BeginSession(VacuumSession session)
		{
			Session = session;
			IsActive = true;
			IsSuctioning = false;
			Current = this;
		}

		[Token(Token = "0x6001228")]
		[Address(RVA = "0x3CCC2D4", Offset = "0x3CCC2D4", Length = "0x10")]
		public void StartSuction(double startTime)
		{
			IsSuctioning = true;
			SuctionStartTime = startTime;
		}

		[Token(Token = "0x6001229")]
		[Address(RVA = "0x3CCC2E4", Offset = "0x3CCC2E4", Length = "0x8")]
		public void StopSuction()
		{
			IsSuctioning = false;
		}

		[Token(Token = "0x600122A")]
		[Address(RVA = "0x3CCC2EC", Offset = "0x3CCC2EC", Length = "0x1FC")]
		public void EndSession()
		{
			//IL_01e0: Expected O, but got I4
			//IL_01f0: Expected O, but got I
			//IL_03d5: Expected O, but got I4
			//IL_03e5: Expected O, but got I
			//IL_040f: Expected O, but got I4
			IsActive = false;
			IsSuctioning = false;
			Session = null;
			if (!TubePath.IsCreated)
			{
				if (!SuctionRadiusCurve.IsCreated)
				{
					goto IL_008a;
				}
			}
			else
			{
				TubePath.Dispose();
				if (!SuctionRadiusCurve.IsCreated)
				{
					goto IL_008a;
				}
			}
			SuctionRadiusCurve.Dispose();
			if (!XYAttractionCurve.IsCreated)
			{
				goto IL_00be;
			}
			goto IL_027e;
			IL_0406:
			object obj = 0;
			return;
			IL_01d8:
			int num;
			object obj2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X8_v13+B8]");
			obj = 0;
			if (obj != this)
			{
				return;
			}
			goto IL_0406;
			IL_03c7:
			_ = 1;
			int num2;
			object obj3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ X8_v8+B8]");
			obj = 0;
			if (obj != this)
			{
				return;
			}
			goto IL_0406;
			IL_008a:
			if (!XYAttractionCurve.IsCreated)
			{
				goto IL_00be;
			}
			goto IL_027e;
			IL_027e:
			XYAttractionCurve.Dispose();
			if (!ZRiseCurve.IsCreated)
			{
				goto IL_00f2;
			}
			goto IL_02b8;
			IL_00be:
			if (!ZRiseCurve.IsCreated)
			{
				goto IL_00f2;
			}
			goto IL_02b8;
			IL_02b8:
			ZRiseCurve.Dispose();
			if (!MouthScaleCurve.IsCreated)
			{
				goto IL_0126;
			}
			goto IL_02f2;
			IL_00f2:
			if (!MouthScaleCurve.IsCreated)
			{
				goto IL_0126;
			}
			goto IL_02f2;
			IL_02f2:
			MouthScaleCurve.Dispose();
			if (!TubeSpeedCurve.IsCreated)
			{
				goto IL_015a;
			}
			goto IL_032c;
			IL_0126:
			if (!TubeSpeedCurve.IsCreated)
			{
				goto IL_015a;
			}
			goto IL_032c;
			IL_032c:
			TubeSpeedCurve.Dispose();
			if (!DispatchScaleDownCurve.IsCreated)
			{
				goto IL_018e;
			}
			goto IL_0366;
			IL_015a:
			if (!DispatchScaleDownCurve.IsCreated)
			{
				goto IL_018e;
			}
			goto IL_0366;
			IL_0366:
			DispatchScaleDownCurve.Dispose();
			num = 187260928 + 864;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193AE3]");
			int num3 = (int)((nint)0 & (nint)1);
			bool flag = num3 == 0;
			bool flag2 = !flag;
			num2 = num;
			if (flag2)
			{
				goto IL_01d8;
			}
			goto IL_03c7;
			IL_018e:
			num = 187260928 + 864;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193AE3]");
			int num4 = (int)((nint)0 & (nint)1);
			bool flag3 = num4 == 0;
			num2 = num;
			if (!flag3)
			{
				goto IL_01d8;
			}
			goto IL_03c7;
		}

		[Token(Token = "0x600122B")]
		[Address(RVA = "0x3CCC4E8", Offset = "0x3CCC4E8", Length = "0x4")]
		public void Dispose()
		{
			EndSession();
		}

		[Token(Token = "0x600122C")]
		[Address(RVA = "0x3CCC4EC", Offset = "0x3CCC4EC", Length = "0x1FC")]
		public void CaptureFromVacuumMono(VacuumMono vacuum)
		{
			Vector3 mouthWorldPosition = vacuum.MouthWorldPosition;
			MouthWorld.x = mouthWorldPosition.x;
			MouthWorld.y = mouthWorldPosition.y;
			MouthWorld.z = mouthWorldPosition.z;
			Vector3 dispatchMouthWorldPosition = vacuum.DispatchMouthWorldPosition;
			DispatchMouthWorld.x = dispatchMouthWorldPosition.x;
			DispatchMouthWorld.y = dispatchMouthWorldPosition.y;
			DispatchMouthWorld.z = dispatchMouthWorldPosition.z;
			if (vacuum.DispatchMouthTransform != null)
			{
				Vector3 right = vacuum.DispatchMouthTransform.right;
				float3 float5 = right;
				DispatchMouthRight.x = float5.x;
				DispatchMouthRight.y = float5.y;
				DispatchMouthRight.z = float5.z;
				Vector3 forward = vacuum.DispatchMouthTransform.forward;
				float3 float6 = forward;
				DispatchMouthForward.x = float6.x;
				DispatchMouthForward.y = float6.y;
				DispatchMouthForward.z = float6.z;
			}
			Vector3 bulbWorldCenter = vacuum.BulbWorldCenter;
			BulbWorldCenter.x = bulbWorldCenter.x;
			BulbWorldCenter.y = bulbWorldCenter.y;
			BulbWorldCenter.z = bulbWorldCenter.z;
			if (!(vacuum.BulbTransform != null))
			{
				if (!TubePath.IsCreated)
				{
					return;
				}
			}
			else
			{
				Vector3 up = vacuum.BulbTransform.up;
				float3 float7 = up;
				BulbUp.x = float7.x;
				BulbUp.y = float7.y;
				BulbUp.z = float7.z;
				Vector3 right2 = vacuum.BulbTransform.right;
				float3 float8 = right2;
				BulbRight.x = float8.x;
				BulbRight.y = float8.y;
				BulbRight.z = float8.z;
				Vector3 forward2 = vacuum.BulbTransform.forward;
				float3 float9 = forward2;
				BulbForward.x = float9.x;
				BulbForward.y = float9.y;
				BulbForward.z = float9.z;
				Vector3 lossyScale = vacuum.BulbTransform.lossyScale;
				float3 float10 = lossyScale;
				BulbScale.x = float10.x;
				BulbScale.y = float10.y;
				BulbScale.z = float10.z;
				if (!TubePath.IsCreated)
				{
					return;
				}
			}
			TubePath.Refresh(vacuum.TubePathPoints);
		}

		[Token(Token = "0x600122D")]
		[Address(RVA = "0x3CCC6E8", Offset = "0x3CCC6E8", Length = "0x22C")]
		public void InitializeFromVacuumMono(VacuumMono vacuum)
		{
			CaptureFromVacuumMono(vacuum);
			float initialBulbScaleX = ((vacuum.BulbTransform != null) ? vacuum.BulbTransform.lossyScale.x : 1f);
			InitialBulbScaleX = initialBulbScaleX;
			SuctionMinRadius = vacuum.SuctionMinRadius;
			SuctionRadiusDuration = vacuum.SuctionRadiusDuration;
			int num = 0;
			NativeAnimationCurve suctionRadiusCurve = new NativeAnimationCurve(vacuum.SuctionRadiusCurve, Allocator.Persistent);
			SuctionRadiusCurve = suctionRadiusCurve;
			int num2 = 0;
			NativeAnimationCurve xYAttractionCurve = new NativeAnimationCurve(vacuum.XYAttractionCurve, Allocator.Persistent);
			XYAttractionCurve = xYAttractionCurve;
			NativeAnimationCurve zRiseCurve = new NativeAnimationCurve(vacuum.ZRiseCurve, Allocator.Persistent);
			ZRiseCurve = zRiseCurve;
			MouthScaleRange = vacuum.MouthScaleRange;
			Mouth3DAxisMultiplier = vacuum.Mouth3DAxisMultiplier;
			NativeAnimationCurve mouthScaleCurve = new NativeAnimationCurve(vacuum.MouthScaleCurve, Allocator.Persistent);
			MouthScaleCurve = mouthScaleCurve;
			NativeTubePath tubePath = new NativeTubePath(vacuum.TubePathPoints, Allocator.Persistent);
			TubePath = tubePath;
			NativeAnimationCurve tubeSpeedCurve = new NativeAnimationCurve(vacuum.TubeSpeedCurve, Allocator.Persistent);
			TubeSpeedCurve = tubeSpeedCurve;
			TubeSpeedRange = vacuum.TubeSpeedRange;
			TubeRadius = vacuum.TubeRadius;
			BulbRadius = vacuum.BulbRadius;
			DispatchRadius = vacuum.DispatchRadius;
			DispatchTubeSpeedRange = vacuum.DispatchTubeSpeedRange;
			NativeAnimationCurve dispatchScaleDownCurve = new NativeAnimationCurve(vacuum.DispatchScaleDownCurve, Allocator.Persistent);
			DispatchScaleDownCurve = dispatchScaleDownCurve;
			DispatchProfile.targetScatter = vacuum.m_dispatchAbsorptionProfile.targetScatter;
			DispatchProfile.zCurveSkew = vacuum.m_dispatchAbsorptionProfile.zCurveSkew;
			DispatchProfile = vacuum.m_dispatchAbsorptionProfile;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			ArrivalRadius = vacuum.VacuumMaxSpeed;
		}

		[Token(Token = "0x600122E")]
		[Address(RVA = "0x3CCC914", Offset = "0x3CCC914", Length = "0x8")]
		public VacuumRuntimeContext()
		{
		}
	}
}
