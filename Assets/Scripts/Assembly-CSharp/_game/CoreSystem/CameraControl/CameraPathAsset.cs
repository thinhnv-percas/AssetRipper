using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[CreateAssetMenu(menuName = "SandFlow/Camera/Camera Path", fileName = "CameraPath")]
	[Token(Token = "0x2000530")]
	public class CameraPathAsset : ScriptableObject
	{
		[Token(Token = "0x4001188")]
		[FieldOffset(Offset = "0x18")]
		public string PathName;

		[Token(Token = "0x4001189")]
		[FieldOffset(Offset = "0x20")]
		public float TransitionDuration = 1f;

		[Token(Token = "0x400118A")]
		[FieldOffset(Offset = "0x24")]
		public CameraEaseType Ease;

		[Token(Token = "0x400118B")]
		[FieldOffset(Offset = "0x28")]
		public List<CameraPose> Poses;

		[Token(Token = "0x170001F6")]
		public int PoseCount
		{
			[Token(Token = "0x60015AE")]
			[Address(RVA = "0x3D13C30", Offset = "0x3D13C30", Length = "0x4C")]
			get
			{
				List<CameraPose> poses = Poses;
				return poses.Count;
			}
		}

		[Token(Token = "0x170001F7")]
		public float TotalDuration
		{
			[Token(Token = "0x60015AF")]
			[Address(RVA = "0x3D13C7C", Offset = "0x3D13C7C", Length = "0x68")]
			get
			{
				List<CameraPose> poses = Poses;
				bool flag = poses.Count < 2;
				float result = 0f;
				if (!flag)
				{
					int num = poses.Count - 1;
					result = TransitionDuration * (float)num;
				}
				return result;
			}
		}

		[Token(Token = "0x60015B0")]
		[Address(RVA = "0x3D13CE4", Offset = "0x3D13CE4", Length = "0x40")]
		public static float ApplyEase(float t, CameraEaseType ease)
		{
			float num2 = default(float);
			float num = 1f - num2;
			float num3 = num * num;
			float num4 = 1f - num3;
			float num5 = num2 * num2;
			int num6 = (int)(ease - 1);
			bool flag = num6 == 0;
			float num7 = num2 + num2;
			float num8 = 3f - num7;
			float num9 = num5 * num8;
			if (flag)
			{
				num2 = num9;
			}
			if (ease == CameraEaseType.EaseIn)
			{
				num2 = num5;
			}
			if (ease == CameraEaseType.EaseOut)
			{
				num2 = num4;
			}
			return num2;
		}

		[Token(Token = "0x60015B1")]
		[Address(RVA = "0x3D13D24", Offset = "0x3D13D24", Length = "0x98")]
		public CameraPathAsset()
		{
			List<CameraPose> poses = new List<CameraPose>();
			Poses = poses;
		}
	}
}
