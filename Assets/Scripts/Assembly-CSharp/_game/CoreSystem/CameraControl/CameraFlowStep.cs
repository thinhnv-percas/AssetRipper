using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Serializable]
	[Token(Token = "0x2000522")]
	public class CameraFlowStep
	{
		[Token(Token = "0x4001152")]
		[FieldOffset(Offset = "0x10")]
		public string Label;

		[Token(Token = "0x4001153")]
		[FieldOffset(Offset = "0x18")]
		public CameraFlowTriggerType Trigger;

		[Token(Token = "0x4001154")]
		[FieldOffset(Offset = "0x20")]
		public string TriggerEventTypeName;

		[Token(Token = "0x4001155")]
		[FieldOffset(Offset = "0x28")]
		public CameraFlowActionType Action;

		[Token(Token = "0x4001156")]
		[FieldOffset(Offset = "0x2C")]
		public float DelayBeforeAction;

		[Token(Token = "0x4001157")]
		[FieldOffset(Offset = "0x30")]
		public CameraPose TargetPose;

		[Token(Token = "0x4001158")]
		[FieldOffset(Offset = "0x50")]
		public float TransitionDuration;

		[Token(Token = "0x4001159")]
		[FieldOffset(Offset = "0x54")]
		public CameraEaseType Ease;

		[Token(Token = "0x400115A")]
		[FieldOffset(Offset = "0x58")]
		public CameraPathAsset Path;

		[Token(Token = "0x400115B")]
		[FieldOffset(Offset = "0x60")]
		public GameObject TrackTarget;

		[Token(Token = "0x6001579")]
		[Address(RVA = "0x3D11B70", Offset = "0x3D11B70", Length = "0x14")]
		public CameraFlowStep()
		{
			TransitionDuration = 1f;
		}
	}
}
