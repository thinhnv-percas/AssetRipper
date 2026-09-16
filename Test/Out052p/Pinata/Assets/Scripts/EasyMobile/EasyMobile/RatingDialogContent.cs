using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000092")]
	public class RatingDialogContent
	{
		[Token(Token = "0x4000362")]
		public const string PRODUCT_NAME_PLACEHOLDER = "$PRODUCT_NAME";

		[Token(Token = "0x4000363")]
		public static readonly RatingDialogContent Default;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733568", Offset = "0x733568")]
		[Token(Token = "0x4000364")]
		[FieldOffset(Offset = "0x10")]
		private string mTitle;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x7335B4", Offset = "0x7335B4")]
		[Token(Token = "0x4000365")]
		[FieldOffset(Offset = "0x18")]
		private string mMessage;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733600", Offset = "0x733600")]
		[Token(Token = "0x4000366")]
		[FieldOffset(Offset = "0x20")]
		private string mLowRatingMessage;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x73364C", Offset = "0x73364C")]
		[Token(Token = "0x4000367")]
		[FieldOffset(Offset = "0x28")]
		private string mHighRatingMessage;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733698", Offset = "0x733698")]
		[Token(Token = "0x4000368")]
		[FieldOffset(Offset = "0x30")]
		private string mPostponeButtonText;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x7336E4", Offset = "0x7336E4")]
		[Token(Token = "0x4000369")]
		[FieldOffset(Offset = "0x38")]
		private string mRefuseButtonText;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x733730", Offset = "0x733730")]
		[Token(Token = "0x400036A")]
		[FieldOffset(Offset = "0x40")]
		private string mRateButtonText;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x73377C", Offset = "0x73377C")]
		[Token(Token = "0x400036B")]
		[FieldOffset(Offset = "0x48")]
		private string mCancelButtonText;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x7337C8", Offset = "0x7337C8")]
		[Token(Token = "0x400036C")]
		[FieldOffset(Offset = "0x50")]
		private string mFeedbackButtonText;

		[Token(Token = "0x170001B4")]
		public string Title
		{
			[Token(Token = "0x6000609")]
			[Address(RVA = "0xFD2730", Offset = "0xFD2730", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTitle;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Title;
			}
			[Token(Token = "0x600060A")]
			[Address(RVA = "0xFD2738", Offset = "0xFD2738", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mTitle = value;\n\treturn;\n")]
			set
			{
				Title = value;
			}
		}

		[Token(Token = "0x170001B5")]
		public string Message
		{
			[Token(Token = "0x600060B")]
			[Address(RVA = "0xFD2740", Offset = "0xFD2740", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMessage;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Message;
			}
			[Token(Token = "0x600060C")]
			[Address(RVA = "0xFD2748", Offset = "0xFD2748", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMessage = value;\n\treturn;\n")]
			set
			{
				Message = value;
			}
		}

		[Token(Token = "0x170001B6")]
		public string LowRatingMessage
		{
			[Token(Token = "0x600060D")]
			[Address(RVA = "0xFD2750", Offset = "0xFD2750", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mLowRatingMessage;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LowRatingMessage;
			}
			[Token(Token = "0x600060E")]
			[Address(RVA = "0xFD2758", Offset = "0xFD2758", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mLowRatingMessage = value;\n\treturn;\n")]
			set
			{
				LowRatingMessage = value;
			}
		}

		[Token(Token = "0x170001B7")]
		public string HighRatingMessage
		{
			[Token(Token = "0x600060F")]
			[Address(RVA = "0xFD2760", Offset = "0xFD2760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mHighRatingMessage;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HighRatingMessage;
			}
			[Token(Token = "0x6000610")]
			[Address(RVA = "0xFD2768", Offset = "0xFD2768", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mHighRatingMessage = value;\n\treturn;\n")]
			set
			{
				HighRatingMessage = value;
			}
		}

		[Token(Token = "0x170001B8")]
		public string PostponeButtonText
		{
			[Token(Token = "0x6000611")]
			[Address(RVA = "0xFD2770", Offset = "0xFD2770", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPostponeButtonText;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PostponeButtonText;
			}
			[Token(Token = "0x6000612")]
			[Address(RVA = "0xFD2778", Offset = "0xFD2778", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mPostponeButtonText = value;\n\treturn;\n")]
			set
			{
				PostponeButtonText = value;
			}
		}

		[Token(Token = "0x170001B9")]
		public string RefuseButtonText
		{
			[Token(Token = "0x6000613")]
			[Address(RVA = "0xFD2780", Offset = "0xFD2780", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mRefuseButtonText;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RefuseButtonText;
			}
			[Token(Token = "0x6000614")]
			[Address(RVA = "0xFD2788", Offset = "0xFD2788", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mRefuseButtonText = value;\n\treturn;\n")]
			set
			{
				RefuseButtonText = value;
			}
		}

		[Token(Token = "0x170001BA")]
		public string RateButtonText
		{
			[Token(Token = "0x6000615")]
			[Address(RVA = "0xFD2790", Offset = "0xFD2790", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mRateButtonText;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RateButtonText;
			}
			[Token(Token = "0x6000616")]
			[Address(RVA = "0xFD2798", Offset = "0xFD2798", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mRateButtonText = value;\n\treturn;\n")]
			set
			{
				RateButtonText = value;
			}
		}

		[Token(Token = "0x170001BB")]
		public string CancelButtonText
		{
			[Token(Token = "0x6000617")]
			[Address(RVA = "0xFD27A0", Offset = "0xFD27A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCancelButtonText;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CancelButtonText;
			}
			[Token(Token = "0x6000618")]
			[Address(RVA = "0xFD27A8", Offset = "0xFD27A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCancelButtonText = value;\n\treturn;\n")]
			set
			{
				CancelButtonText = value;
			}
		}

		[Token(Token = "0x170001BC")]
		public string FeedbackButtonText
		{
			[Token(Token = "0x6000619")]
			[Address(RVA = "0xFD27B0", Offset = "0xFD27B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mFeedbackButtonText;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FeedbackButtonText;
			}
			[Token(Token = "0x600061A")]
			[Address(RVA = "0xFD27B8", Offset = "0xFD27B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mFeedbackButtonText = value;\n\treturn;\n")]
			set
			{
				FeedbackButtonText = value;
			}
		}

		[Token(Token = "0x600061B")]
		[Address(RVA = "0xFD27C0", Offset = "0xFD27C0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF1958]);\n\tv19 = *([v18 @ X8_v31]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256AA]) = v38;\nL_0018:\n\tthis.mTitle = \"Rate $PRODUCT_NAME\";\n\tthis.mMessage = \"How would you rate $PRODUCT_NAME?\";\n\tthis.mLowRatingMessage = \"That's bad. Would you like to give us some feedback instead?\";\n\tthis.mHighRatingMessage = \"Awesome! Let's do it!\";\n\tthis.mPostponeButtonText = \"Not Now\";\n\tthis.mRefuseButtonText = \"Don't Ask Again\";\n\tthis.mRateButtonText = \"Rate Now!\";\n\tthis.mCancelButtonText = \"Cancel\";\n\tthis.mFeedbackButtonText = \"Send Feedback\";\n\tSystem.Object::.ctor(this);\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RatingDialogContent()
		{
			Title = "Rate $PRODUCT_NAME";
			Message = "How would you rate $PRODUCT_NAME?";
			LowRatingMessage = "That's bad. Would you like to give us some feedback instead?";
			HighRatingMessage = "Awesome! Let's do it!";
			PostponeButtonText = "Not Now";
			RefuseButtonText = "Don't Ask Again";
			RateButtonText = "Rate Now!";
			CancelButtonText = "Cancel";
			FeedbackButtonText = "Send Feedback";
		}

		[Token(Token = "0x600061C")]
		[Address(RVA = "0xFD2898", Offset = "0xFD2898", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_0026;\n\tv46 = *([1EB1D50]);\n\tv47 = *([v46 @ X8_v38]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, title, message, lowRatingMessage, highRatingMessage, postponeButtonText, refuseButtonText, rateButtonText, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20256AB]) = v59;\nL_0026:\n\tthis.mTitle = \"Rate $PRODUCT_NAME\";\n\tthis.mMessage = \"How would you rate $PRODUCT_NAME?\";\n\tthis.mLowRatingMessage = \"That's bad. Would you like to give us some feedback instead?\";\n\tthis.mHighRatingMessage = \"Awesome! Let's do it!\";\n\tthis.mPostponeButtonText = \"Not Now\";\n\tthis.mRefuseButtonText = \"Don't Ask Again\";\n\tthis.mRateButtonText = \"Rate Now!\";\n\tthis.mCancelButtonText = \"Cancel\";\n\tthis.mFeedbackButtonText = \"Send Feedback\";\n\tSystem.Object::.ctor(this);\n\tv134 = *([v22 @ X29_v1+10]);\n\tv104 = title != 0;\n\tif (v104) goto L_FFFFFFFF;\n\tgoto L_0067;\nL_0067:\n\tv119 = message != 0;\n\tif (v119) goto L_FFFFFFFF;\n\tgoto L_0076;\nL_0076:\n\tthis.mTitle = v109;\n\tthis.mMessage = v185;\n\tv195 = lowRatingMessage != 0;\n\tif (v195) goto L_FFFFFFFF;\n\tgoto L_0087;\nL_0087:\n\tv208 = highRatingMessage != 0;\n\tif (v208) goto L_FFFFFFFF;\n\tgoto L_0096;\nL_0096:\n\tthis.mLowRatingMessage = v198;\n\tthis.mHighRatingMessage = v211;\n\tv221 = postponeButtonText != 0;\n\tif (v221) goto L_FFFFFFFF;\n\tgoto L_00A7;\nL_00A7:\n\tv234 = refuseButtonText != 0;\n\tif (v234) goto L_FFFFFFFF;\n\tgoto L_00B6;\nL_00B6:\n\tthis.mPostponeButtonText = v224;\n\tthis.mRefuseButtonText = v123;\n\tv246 = rateButtonText != 0;\n\tif (v246) goto L_FFFFFFFF;\n\tgoto L_00C7;\nL_00C7:\n\tv258 = v134 != 0;\n\tif (v258) goto L_00D6;\n\tgoto L_00D6;\nL_00D6:\n\tv129 = *([v22 @ X29_v1+18]) != 0;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tthis.mRateButtonText = v126;\n\tthis.mCancelButtonText = v134;\n\tthis.mFeedbackButtonText = v178;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 182 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RatingDialogContent(string title, string message, string lowRatingMessage, string highRatingMessage, string postponeButtonText, string refuseButtonText, string rateButtonText, string cancelButtonText, string feedbackButtonText)
		{
			//IL_0023: Expected O, but got I
			//IL_012c: Expected O, but got I
			base._002Ector();
			object obj2 = default(object);
			object obj = obj2;
			Title = "Rate $PRODUCT_NAME";
			Message = "How would you rate $PRODUCT_NAME?";
			LowRatingMessage = "That's bad. Would you like to give us some feedback instead?";
			HighRatingMessage = "Awesome! Let's do it!";
			PostponeButtonText = "Not Now";
			RefuseButtonText = "Don't Ask Again";
			RateButtonText = "Rate Now!";
			CancelButtonText = "Cancel";
			FeedbackButtonText = "Send Feedback";
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+10]");
			string text = (string)0;
			string title2 = ((title != null) ? title : "");
			string message2 = ((message != null) ? message : "");
			Title = title2;
			Message = message2;
			string lowRatingMessage2 = ((lowRatingMessage != null) ? lowRatingMessage : "");
			string highRatingMessage2 = ((highRatingMessage != null) ? highRatingMessage : "");
			LowRatingMessage = lowRatingMessage2;
			HighRatingMessage = highRatingMessage2;
			string postponeButtonText2 = ((postponeButtonText != null) ? postponeButtonText : "");
			string refuseButtonText2 = ((refuseButtonText != null) ? refuseButtonText : "");
			PostponeButtonText = postponeButtonText2;
			RefuseButtonText = refuseButtonText2;
			string rateButtonText2 = ((rateButtonText != null) ? rateButtonText : "");
			if (text == null)
			{
				text = "";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+18]");
			string feedbackButtonText2;
			if ((IntPtr)0 == (IntPtr)0)
			{
				feedbackButtonText2 = "";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+18]");
				feedbackButtonText2 = (string)0;
			}
			RateButtonText = rateButtonText2;
			CancelButtonText = text;
			FeedbackButtonText = feedbackButtonText2;
		}

		[Token(Token = "0x600061D")]
		[Address(RVA = "0xFD2A28", Offset = "0xFD2A28", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EF2980]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20256AC]) = v37;\nL_0015:\n\tv41 = new EasyMobile.RatingDialogContent();\n\tEasyMobile.RatingDialogContent::.ctor(v41);\n\tv44.Default = v41;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static RatingDialogContent()
		{
			RatingDialogContent ratingDialogContent = new RatingDialogContent();
			Default = ratingDialogContent;
		}
	}
}
