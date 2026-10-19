using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tracking
{
	[Serializable]
	[Token(Token = "0x200057E")]
	public class TrackerEntry
	{
		[Token(Token = "0x40012EA")]
		[FieldOffset(Offset = "0x10")]
		public bool enabled;

		[SerializeReference]
		[Token(Token = "0x40012EB")]
		[FieldOffset(Offset = "0x18")]
		public ITracker tracker;

		[Token(Token = "0x40012EC")]
		[FieldOffset(Offset = "0x20")]
		public bool logToElephant;

		[Token(Token = "0x40012ED")]
		[FieldOffset(Offset = "0x21")]
		public bool logToFirebase;

		[Token(Token = "0x6001728")]
		[Address(RVA = "0x3D2842C", Offset = "0x3D2842C", Length = "0x14")]
		public TrackerEntry()
		{
			enabled = true;
			logToElephant = true;
		}
	}
}
