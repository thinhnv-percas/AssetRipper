using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot.Extra
{
	[RequireComponent(typeof(Canvas))]
	[Token(Token = "0x2000058")]
	public abstract class ScreenshotGallery : MonoBehaviour
	{
		[Token(Token = "0x2000059")]
		public enum DisplayOrder
		{
			[Token(Token = "0x4000224")]
			ALPHABECICAL_ASCENDING = 0,
			[Token(Token = "0x4000225")]
			ALPHABECICAL_DECENDING = 1,
			[Token(Token = "0x4000226")]
			CREATION_DATE_ASCENDING = 2,
			[Token(Token = "0x4000227")]
			CREATION_DATE_DECENDING = 3
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200005A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000228")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000229")]
			public static Func<TextureExporter.ImageFile, string> _003C_003E9__10_0;

			[Token(Token = "0x400022A")]
			public static Func<TextureExporter.ImageFile, string> _003C_003E9__10_1;

			[Token(Token = "0x400022B")]
			public static Func<TextureExporter.ImageFile, DateTime> _003C_003E9__10_2;

			[Token(Token = "0x400022C")]
			public static Func<TextureExporter.ImageFile, DateTime> _003C_003E9__10_3;

			[Token(Token = "0x60001B1")]
			[Address(RVA = "0x3C477DC", Offset = "0x3C477DC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new AlmostEngine.Screenshot.Extra.ScreenshotGallery+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60001B2")]
			[Address(RVA = "0x3C47840", Offset = "0x3C47840", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CLoadImageFiles_003Eb__10_0(TextureExporter.ImageFile x)
			{
				return x.m_Fullname;
			}

			internal string _003CLoadImageFiles_003Eb__10_1(TextureExporter.ImageFile x)
			{
				return x.m_Fullname;
			}

			internal DateTime _003CLoadImageFiles_003Eb__10_2(TextureExporter.ImageFile x)
			{
				return x.m_CreationDate;
			}

			internal DateTime _003CLoadImageFiles_003Eb__10_3(TextureExporter.ImageFile x)
			{
				return x.m_CreationDate;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200005C")]
		private sealed class _003CDelayedUpdate_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400022F")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000230")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000231")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotGallery _003C_003E4__this;

			[Token(Token = "0x1700002D")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001BC")]
				[Address(RVA = "0x3C479A4", Offset = "0x3C479A4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002E")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001BE")]
				[Address(RVA = "0x3C479EC", Offset = "0x3C479EC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0x3C46C08", Offset = "0x3C46C08", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CDelayedUpdate_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001BA")]
			[Address(RVA = "0x3C478D0", Offset = "0x3C478D0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001BB")]
			[Address(RVA = "0x3C478D4", Offset = "0x3C478D4", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv53 = this.<>1__state != 1;\n\tif (v53) goto L_002F;\n\tthis.<>1__state = -1;\n\tv68 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::DoGalleryUpdate(this.<>4__this);\nL_003E:\n\tthis.<>1__state = -1;\n\tv58 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v58);\n\tthis.<>2__current = v58;\n\tthis.<>1__state = 1;\n\tv111 = this.<>1__state == 0;\n\treturn v111;\nL_0015:\n\tv43 = this.<>1__state == 0;\n\tif (v43) goto L_003E;\nL_002F:\n\tv76 = this.<>1__state == 0;\n\treturn v76;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						_003C_003E4__this.DoGalleryUpdate();
					}
					return _003C_003E1__state == 0;
				}
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001BD")]
			[Address(RVA = "0x3C479AC", Offset = "0x3C479AC", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Tooltip("The path on the device from which the screenhots will be loaded. To automatically use the same path than your Screenshot Manager export path, add a SetScreenshotManagerFolderPath component to that object: a path will be automatically set at startup.")]
		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0x20")]
		public string m_ScreenshotFolderPath = "";

		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x28")]
		public DisplayOrder m_DisplayOrder;

		[Tooltip("The greybox object to use when an image is selected.")]
		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x30")]
		public GreyboxCanvas m_GreyBox;

		[Tooltip("The object to use as prefab to instantiate the gallery image object. Note that this object must have a RawImage component.")]
		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x38")]
		public GameObject m_ImageItemPrefab;

		[Token(Token = "0x4000221")]
		[FieldOffset(Offset = "0x40")]
		public List<TextureExporter.ImageFile> m_ImageFiles;

		[HideInInspector]
		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x48")]
		public List<GameObject> m_ImageInstances;

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x3C46ABC", Offset = "0x3C46ABC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v13, 1);\n\tv36 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::LoadImageFiles(this);\n\tv40 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::UpdateGallery(v40);\n\treturn;\n")]
		public virtual void Show()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
			LoadImageFiles();
			ScreenshotGallery screenshotGallery = default(ScreenshotGallery);
			screenshotGallery.UpdateGallery();
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x3C46B10", Offset = "0x3C46B10", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.Extra.ScreenshotGallery+<DelayedUpdate>d__9();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public virtual void UpdateGallery()
		{
			_003CDelayedUpdate_003Ed__9 _003CDelayedUpdate_003Ed__10 = (_003CDelayedUpdate_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdate_003Ed__9));
			_003CDelayedUpdate_003Ed__10._003C_003E1__state = 0;
			_003CDelayedUpdate_003Ed__10._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CDelayedUpdate_003Ed__10);
		}

		[IteratorStateMachine(typeof(_003CDelayedUpdate_003Ed__9))]
		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x3C46B90", Offset = "0x3C46B90", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.Extra.ScreenshotGallery+<DelayedUpdate>d__9();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator DelayedUpdate()
		{
			_003CDelayedUpdate_003Ed__9 _003CDelayedUpdate_003Ed__10 = (_003CDelayedUpdate_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdate_003Ed__9));
			_003CDelayedUpdate_003Ed__10._003C_003E1__state = 0;
			_003CDelayedUpdate_003Ed__10._003C_003E4__this = this;
			return _003CDelayedUpdate_003Ed__10;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x3C46C34", Offset = "0x3C46C34", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::Clear(v49);\n\tv67 = v49.Count < 1;\n\tif (v67) goto L_0056;\nL_0056:\n\tv80 = System.String::IsNullOrEmpty(this.m_ScreenshotFolderPath);\n\tv85 = v80 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_006E;\n\tv174 = AlmostEngine.Screenshot.TextureExporter::LoadFromPath(this.m_ScreenshotFolderPath);\n\tthis.m_ImageFiles = v174;\nL_006E:\n\tv187 = this.m_DisplayOrder > 1;\n\tif (v187) goto L_008E;\n\tv192 = this.m_DisplayOrder == 0;\n\tif (v192) goto L_00BC;\n\tv214 = this.m_DisplayOrder != 1;\n\tif (v214) goto L_00B5;\n\tgoto L_0086;\nL_0086:\n\tv267 = v265.<>9__10_1 == 0;\n\tv268 = ~v267;\n\tv340 = v265.<>9__10_1;\n\tif (v268) goto L_00F5;\n\tgoto L_00DA;\nL_008E:\n\tv197 = this.m_DisplayOrder == 2;\n\tif (v197) goto L_00C9;\n\tv230 = this.m_DisplayOrder != 3;\n\tif (v230) goto L_00B5;\n\tgoto L_00A8;\nL_00A8:\n\tv300 = v298.<>9__10_3 == 0;\n\tv301 = ~v300;\n\tv373 = v298.<>9__10_3;\n\tif (v301) goto L_011C;\n\tgoto L_0101;\nL_00B5:\n\treturn;\nL_00BC:\n\tgoto L_00BF;\nL_00BF:\n\tv248 = v246.<>9__10_0 == 0;\n\tv249 = ~v248;\n\tv276 = v246.<>9__10_0;\n\tif (v249) goto L_0143;\n\tgoto L_0128;\nL_00C9:\n\tgoto L_00CC;\nL_00CC:\n\tv259 = v257.<>9__10_2 == 0;\n\tv260 = ~v259;\n\tv309 = v257.<>9__10_2;\n\tif (v260) goto L_016A;\n\tgoto L_014F;\nL_00DA:\n\tgoto L_00E2;\n\tv340 = v450;\nL_0101:\n\tgoto L_0109;\n\tv373 = v462;\nL_0128:\n\tgoto L_0130;\n\tv276 = v425;\nL_014F:\n\tgoto L_0157;\n\tv309 = v438;\nL_016E:\n\tv409 = System.Linq.Enumerable::ToList(v404);\n\tthis.m_ImageFiles = v409;\n\treturn;\nL_003C:\n\tv49 = this.m_ImageFiles;\nL_00F5:\n\tv360 = System.Linq.Enumerable::OrderByDescending(this.m_ImageFiles, v340);\n\tv404 = v360;\n\tgoto L_016E;\nL_011C:\n\tv393 = System.Linq.Enumerable::OrderByDescending(this.m_ImageFiles, v373);\n\tv404 = v393;\n\tgoto L_016E;\nL_0143:\n\tv296 = System.Linq.Enumerable::OrderBy(this.m_ImageFiles, v276);\n\tv404 = v296;\n\tgoto L_016E;\nL_016A:\n\tv329 = System.Linq.Enumerable::OrderBy(this.m_ImageFiles, v309);\n\tv404 = v329;\nL_00E2:\n\tv450 = new System.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.String>();\n\tSystem.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.String>::.ctor(v450, v445.<>9, Il2CppMethodInfo);\n\tv483.<>9__10_1 = v450;\nL_0109:\n\tv462 = new System.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.DateTime>();\n\tSystem.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.DateTime>::.ctor(v462, v457.<>9, Il2CppMethodInfo);\n\tv486.<>9__10_3 = v462;\nL_0130:\n\tv425 = new System.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.String>();\n\tSystem.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.String>::.ctor(v425, v420.<>9, Il2CppMethodInfo);\n\tv473.<>9__10_0 = v425;\nL_0157:\n\tv438 = new System.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.DateTime>();\n\tSystem.Func`2<AlmostEngine.Screenshot.TextureExporter+ImageFile, System.DateTime>::.ctor(v438, v433.<>9, Il2CppMethodInfo);\n\tv480.<>9__10_2 = v438;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadImageFiles()
		{
			List<TextureExporter.ImageFile> imageFiles = m_ImageFiles;
			imageFiles.Clear();
			if (imageFiles.Count >= 1)
			{
			}
			if (!string.IsNullOrEmpty(m_ScreenshotFolderPath))
			{
				List<TextureExporter.ImageFile> imageFiles2 = TextureExporter.LoadFromPath(m_ScreenshotFolderPath);
				m_ImageFiles = imageFiles2;
			}
			IEnumerable<object> source;
			if (m_DisplayOrder <= DisplayOrder.ALPHABECICAL_DECENDING)
			{
				if (m_DisplayOrder != DisplayOrder.ALPHABECICAL_ASCENDING)
				{
					if (m_DisplayOrder != DisplayOrder.ALPHABECICAL_DECENDING)
					{
						return;
					}
					bool flag = _003C_003Ec._003C_003E9__10_1 == null;
					bool flag2 = !flag;
					Func<object, object> keySelector = (Func<object, object>)_003C_003Ec._003C_003E9__10_1;
					if (!flag2)
					{
						keySelector = (Func<object, object>)(_003C_003Ec._003C_003E9__10_1 = (TextureExporter.ImageFile x) => x.m_Fullname);
					}
					IOrderedEnumerable<object> orderedEnumerable = m_ImageFiles.OrderByDescending(keySelector);
					source = orderedEnumerable;
				}
				else
				{
					bool flag3 = _003C_003Ec._003C_003E9__10_0 == null;
					bool flag4 = !flag3;
					Func<object, object> keySelector2 = (Func<object, object>)_003C_003Ec._003C_003E9__10_0;
					if (!flag4)
					{
						keySelector2 = (Func<object, object>)(_003C_003Ec._003C_003E9__10_0 = (TextureExporter.ImageFile x) => x.m_Fullname);
					}
					IOrderedEnumerable<object> orderedEnumerable2 = m_ImageFiles.OrderBy(keySelector2);
					source = orderedEnumerable2;
				}
			}
			else if (m_DisplayOrder != DisplayOrder.CREATION_DATE_ASCENDING)
			{
				if (m_DisplayOrder != DisplayOrder.CREATION_DATE_DECENDING)
				{
					return;
				}
				bool flag5 = _003C_003Ec._003C_003E9__10_3 == null;
				bool flag6 = !flag5;
				Func<object, DateTime> keySelector3 = (Func<object, DateTime>)_003C_003Ec._003C_003E9__10_3;
				if (!flag6)
				{
					keySelector3 = (Func<object, DateTime>)(_003C_003Ec._003C_003E9__10_3 = (TextureExporter.ImageFile x) => x.m_CreationDate);
				}
				IOrderedEnumerable<object> orderedEnumerable3 = m_ImageFiles.OrderByDescending(keySelector3);
				source = orderedEnumerable3;
			}
			else
			{
				bool flag7 = _003C_003Ec._003C_003E9__10_2 == null;
				bool flag8 = !flag7;
				Func<object, DateTime> keySelector4 = (Func<object, DateTime>)_003C_003Ec._003C_003E9__10_2;
				if (!flag8)
				{
					keySelector4 = (Func<object, DateTime>)(_003C_003Ec._003C_003E9__10_2 = (TextureExporter.ImageFile x) => x.m_CreationDate);
				}
				IOrderedEnumerable<object> orderedEnumerable4 = m_ImageFiles.OrderBy(keySelector4);
				source = orderedEnumerable4;
			}
			List<object> imageFiles3 = source.ToList();
			m_ImageFiles = (List<TextureExporter.ImageFile>)(object)imageFiles3;
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x3C47084", Offset = "0x3C47084", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv117 = 0xB2A6000 + 0x448;\n\tv66 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this.m_ImageInstances);\n\tv135 = v66._list;\n\tgoto L_0045;\nL_0042:\n\tUnityEngine.Object::Destroy(v66.Current);\nL_0045:\n\tv158 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v135 @ stack_-58_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv174 = v158 == 0;\n\tif (v174) goto L_0053;\n\tgoto L_0042;\nL_0053:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v135 @ stack_-58_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv99 = 0;\n\tv115 = Il2CppMethodInfo;\nL_0054:\n\tv128 = this.m_ImageInstances;\n\tv126 = this.m_ImageInstances == 0;\n\tif (v126) goto L_0076;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Clear(v128);\n\tv218 = v128.Count < 1;\n\tif (v218) goto L_0075;\nL_0075:\n\treturn;\nL_0076:\n\tv131 = new System.NullReferenceException();\n\tgoto L_0082;\nL_0082:\n\tv169 = v115 != 1;\n\tv185 = v131;\n\tif (v169) goto L_0092;\n\tv176 = 0x8BF5BC4(v131, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv196 = 0x8BF5BF4(v176, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = *([v117 @ X21_v1 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v135 @ stack_-58_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv184 = *([v176 @ X0_v12]) == 0;\n\tv99 = *([v176 @ X0_v12]);\n\tif (v184) goto L_0054;\n\tv182 = new System.OutOfMemoryException();\n\tv99 = *([v176 @ X0_v12]);\n\tv185 = v182;\n\treturn;\nL_0025:\n\tv135 = 0;\n\tv51 = this.m_ImageInstances == 0;\n\tif (v51) goto L_0076;\nL_0092:\n\tv188 = 0x31776C4(&v99 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv198 = 0x8BF0368(v185, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv204 = 0xA1B8(v198, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe virtual void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotGallery::Clear");
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x3C47220", Offset = "0x3C47220", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv57.<>4__this = this;\n\tgoto L_0051;\nL_0051:\n\tv111 = UnityEngine.Object::Instantiate(this.m_ImageItemPrefab);\n\tv112 = UnityEngine.GameObject::get_transform(v111);\n\tUnityEngine.Transform::SetParent(v112, parent);\n\tv117 = UnityEngine.GameObject::get_transform(v111);\n\tgoto L_0079;\nL_0079:\n\t// 121 MakeStruct v85 @ AGG3C473B4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v256.one (UnityEngine.Vector3), v256.one.y (System.Single), v256.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v117, v85);\n\tv260 = UnityEngine.GameObject::GetComponentInChildren(v111);\n\tv262 = UnityEngine.Object::op_Equality(v260, 0);\n\tv263 = ~v262;\n\tif (v263) goto L_009A;\n\tgoto L_0090;\nL_0090:\n\tUnityEngine.Debug::LogError(\"Can not find the RawImage component in the gallery image. Be sure the canvas game object is enabled before calling this method.\");\nL_009A:\n\tUnityEngine.UI.RawImage::set_texture(v260, image.m_Texture);\n\tv114 = UnityEngine.GameObject::GetComponentInChildren(v111);\n\tv57.index = i;\n\tv115 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v115, v57, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v114.onClick, v115);\n\tv116 = this.m_ImageInstances;\n\tgoto L_00D8;\nL_00D8:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(v116, v111);\n\treturn v111;\nL_0039:\n\tv57 = new AlmostEngine.Screenshot.Extra.ScreenshotGallery+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v57);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual GameObject InstantiateImageObject(TextureExporter.ImageFile image, int i, Transform parent)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(m_ImageItemPrefab);
			Transform transform = gameObject.transform;
			transform.SetParent(parent);
			Transform transform2 = gameObject.transform;
			Vector3 localScale = default(Vector3);
			localScale.x = Vector3.one.x;
			localScale.y = Vector3.one.y;
			localScale.z = Vector3.one.z;
			transform2.localScale = localScale;
			RawImage componentInChildren = gameObject.GetComponentInChildren<RawImage>();
			if (componentInChildren == null)
			{
				Debug.LogError("Can not find the RawImage component in the gallery image. Be sure the canvas game object is enabled before calling this method.");
			}
			componentInChildren.texture = image.m_Texture;
			Button componentInChildren2 = gameObject.GetComponentInChildren<Button>();
			int index = i;
			UnityAction call = delegate
			{
				ScreenshotGallery screenshotGallery = default(ScreenshotGallery);
				screenshotGallery.OnSelectImageCallback(index);
			};
			componentInChildren2.onClick.AddListener(call);
			List<GameObject> imageInstances = m_ImageInstances;
			imageInstances.Add(gameObject);
			return gameObject;
		}

		[Token(Token = "0x60001AD")]
		public abstract void DoGalleryUpdate();

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x3C4750C", Offset = "0x3C4750C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::get_Item(this.m_ImageFiles, index);\n\tv72 = System.IO.File::Exists(v52.m_Fullname);\n\tv93 = ~v72;\n\tif (v93) goto L_0040;\n\tv62 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::get_Item(this.m_ImageFiles, index);\n\tSystem.IO.File::Delete(v62.m_Fullname);\nL_0040:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::RemoveAt(this.m_ImageFiles, index);\n\treturn;\n")]
		public virtual void RemoveImage(int index)
		{
			TextureExporter.ImageFile imageFile = m_ImageFiles[index];
			if (File.Exists(imageFile.m_Fullname))
			{
				TextureExporter.ImageFile imageFile2 = m_ImageFiles[index];
				File.Delete(imageFile2.m_Fullname);
			}
			m_ImageFiles.RemoveAt(index);
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0x3C475D0", Offset = "0x3C475D0", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.m_GreyBox, 0);\n\tv64 = ~v56;\n\tif (v64) goto L_0057;\n\tv78 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v78, 0);\n\tv127 = UnityEngine.Component::get_gameObject(this.m_GreyBox);\n\tUnityEngine.GameObject::SetActive(v127, 1);\n\tAlmostEngine.Screenshot.Extra.GreyboxCanvas::SetImage(this.m_GreyBox, this, id);\n\treturn;\nL_0057:\n\treturn;\n")]
		public virtual void OnSelectImageCallback(int id)
		{
			if (m_GreyBox != null)
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
				GameObject gameObject2 = m_GreyBox.gameObject;
				gameObject2.SetActive(value: true);
				m_GreyBox.SetImage(this, id);
			}
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0x3C476D0", Offset = "0x3C476D0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tthis.m_ImageFiles = v69;\n\tv85 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v85);\n\tthis.m_ImageInstances = v85;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0031:\n\tthis.m_ScreenshotFolderPath = \"\";\n\tv69 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::.ctor(v69);\n")]
		protected internal ScreenshotGallery()
		{
			List<TextureExporter.ImageFile> imageFiles = new List<TextureExporter.ImageFile>();
			m_ImageFiles = imageFiles;
			m_ImageInstances = new List<GameObject>();
		}
	}
}
