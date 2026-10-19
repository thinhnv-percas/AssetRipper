using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ElephantSDK
{
	[Token(Token = "0x2000957")]
	public class OfferUIManager : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200095A")]
		private sealed class _003C_003Ec__DisplayClass27_0
		{
			[Token(Token = "0x4001F81")]
			[FieldOffset(Offset = "0x10")]
			public string value;

			[Token(Token = "0x6002807")]
			[Address(RVA = "0x3E4BB80", Offset = "0x3E4BB80", Length = "0x8")]
			public _003C_003Ec__DisplayClass27_0()
			{
			}

			internal bool _003CPurchaseAction_003Eb__0(PurchaseOption po)
			{
				return po.name == value;
			}
		}

		[Token(Token = "0x4001F77")]
		[FieldOffset(Offset = "0x20")]
		private Canvas _dynamicCanvas;

		[Token(Token = "0x4001F78")]
		[FieldOffset(Offset = "0x28")]
		private GameObject _uiContainer;

		[Token(Token = "0x4001F79")]
		private static OfferAssetManager _offerAssetManager;

		[Token(Token = "0x4001F7A")]
		[FieldOffset(Offset = "0x30")]
		private string _iapNames;

		[Token(Token = "0x4001F7B")]
		[FieldOffset(Offset = "0x38")]
		private List<PurchaseOption> _currentPurchaseOptions;

		[Token(Token = "0x4001F7C")]
		[FieldOffset(Offset = "0x40")]
		private List<Button> _currentPurchaseButtons;

		[Token(Token = "0x4001F7D")]
		[FieldOffset(Offset = "0x48")]
		private GameObject _loadingPanel;

		[Token(Token = "0x60027EB")]
		[Address(RVA = "0x3E48C30", Offset = "0x3E48C30", Length = "0x168")]
		private void OnEnable()
		{
			OnOfferUIFetched value = DisplayOfferUI;
			ElephantCore.add_onOfferUIFetched(value);
			Action value2 = DismissOfferUI;
			Elephant.add_OnDismissOfferUI(value2);
			Action value3 = EnablePurchaseButtons;
			Elephant.add_OnOfferClosed(value3);
		}

		[Token(Token = "0x60027EC")]
		[Address(RVA = "0x3E48D98", Offset = "0x3E48D98", Length = "0x168")]
		private void OnDisable()
		{
			OnOfferUIFetched value = DisplayOfferUI;
			ElephantCore.remove_onOfferUIFetched(value);
			Action value2 = DismissOfferUI;
			Elephant.remove_OnDismissOfferUI(value2);
			Action value3 = EnablePurchaseButtons;
			Elephant.remove_OnOfferClosed(value3);
		}

		[Token(Token = "0x60027ED")]
		[Address(RVA = "0x3E48F00", Offset = "0x3E48F00", Length = "0x53C")]
		private void DisplayOfferUI()
		{
			if (_dynamicCanvas != null)
			{
				ElephantLog.Log("OFFERUI", "There is already a shown offer!");
				return;
			}
			_iapNames = "";
			List<PurchaseOption> currentPurchaseOptions = _currentPurchaseOptions;
			if (_currentPurchaseOptions != null)
			{
				currentPurchaseOptions.Clear();
				if (currentPurchaseOptions.Count >= 1)
				{
				}
				List<Button> currentPurchaseButtons = _currentPurchaseButtons;
				if (_currentPurchaseButtons != null)
				{
					currentPurchaseButtons.Clear();
					if (currentPurchaseButtons.Count >= 1)
					{
					}
					OfferAssetManager instance = OfferAssetManager._instance;
					if (OfferAssetManager._instance == null)
					{
						OfferAssetManager instance2 = new OfferAssetManager();
						OfferAssetManager._instance = instance2;
						instance = OfferAssetManager._instance;
					}
					_offerAssetManager = instance;
					CreateCanvas();
					CreateBlockingPanel();
					CreateComponents();
					Elephant.TriggerOfferShown(_currentPurchaseOptions);
					OfferAssetManager offerAssetManager = _offerAssetManager;
					if (_offerAssetManager != null)
					{
						offerAssetManager.iapNames = _iapNames;
						OfferAssetManager offerAssetManager2 = _offerAssetManager;
						if (_offerAssetManager != null)
						{
							OfferData currentOffer = offerAssetManager2.currentOffer;
							if (offerAssetManager2.currentOffer != null)
							{
								OfferMetaData offerMetaData = offerAssetManager2.offerMetaData;
								if (offerAssetManager2.offerMetaData != null)
								{
									Elephant.OfferShownEvent(currentOffer.Segment, _iapNames, currentOffer.OfferName, offerMetaData.triggerPoint);
									return;
								}
								NullReferenceException ex = new NullReferenceException();
							}
							else
							{
								NullReferenceException ex = new NullReferenceException();
							}
						}
						else
						{
							NullReferenceException ex = new NullReferenceException();
						}
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
					}
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
		}

		[Token(Token = "0x60027EE")]
		[Address(RVA = "0x3E49A4C", Offset = "0x3E49A4C", Length = "0x144")]
		private unsafe void EnablePurchaseButtons()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferUIManager::EnablePurchaseButtons");
		}

		[Token(Token = "0x60027EF")]
		[Address(RVA = "0x3E49B90", Offset = "0x3E49B90", Length = "0x1C8")]
		private void DismissOfferUI()
		{
			if (_dynamicCanvas != null)
			{
				OfferAssetManager offerAssetManager = _offerAssetManager;
				OfferData currentOffer = offerAssetManager.currentOffer;
				OfferMetaData offerMetaData = offerAssetManager.offerMetaData;
				Elephant.OfferClosedEvent(currentOffer.Segment, _iapNames, currentOffer.OfferName, offerMetaData.triggerPoint);
				GameObject obj = _dynamicCanvas.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
			else
			{
				ElephantLog.LogError("OFFERUI", "No canvas to destroy.");
			}
		}

		[Token(Token = "0x60027F0")]
		[Address(RVA = "0x3E496AC", Offset = "0x3E496AC", Length = "0x218")]
		private void CreateBlockingPanel()
		{
			GameObject gameObject = new GameObject("BlockingPanel");
			Transform transform = gameObject.transform;
			Transform parent = _dynamicCanvas.transform;
			transform.SetParent(parent, worldPositionStays: false);
			Transform transform2 = gameObject.transform;
			transform2.SetAsFirstSibling();
			Image image = gameObject.AddComponent<Image>();
			Color color = default(Color);
			color.r = 0f;
			color.g = 0f;
			color.b = 0f;
			color.a = 0f;
			image.color = color;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = Vector2.zero.x;
			anchorMin.y = Vector2.zero.y;
			component.anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = Vector2.one.x;
			anchorMax.y = Vector2.one.y;
			component.anchorMax = anchorMax;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = Vector2.zero.x;
			sizeDelta.y = Vector2.zero.y;
			component.sizeDelta = sizeDelta;
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = Vector2.zero.x;
			anchoredPosition.y = Vector2.zero.y;
			component.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x60027F1")]
		[Address(RVA = "0x3E49D58", Offset = "0x3E49D58", Length = "0x2F4")]
		private void IsFullWide()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferUIManager::IsFullWide");
		}

		[Token(Token = "0x60027F2")]
		[Address(RVA = "0x3E4943C", Offset = "0x3E4943C", Length = "0x270")]
		private void CreateCanvas()
		{
			//IL_0138: Expected I4, but got I8
			GameObject gameObject = new GameObject("DynamicCanvas");
			Canvas dynamicCanvas = gameObject.AddComponent<Canvas>();
			_dynamicCanvas = dynamicCanvas;
			_dynamicCanvas.renderMode = default(RenderMode);
			_dynamicCanvas.sortingOrder = 1000;
			GameObject gameObject2 = _dynamicCanvas.gameObject;
			GraphicRaycaster graphicRaycaster = gameObject2.AddComponent<GraphicRaycaster>();
			_dynamicCanvas.pixelPerfect = true;
			GameObject gameObject3 = _dynamicCanvas.gameObject;
			CanvasScaler canvasScaler = gameObject3.AddComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			OfferAssetManager offerAssetManager = _offerAssetManager;
			OfferUIData offerUIData = offerAssetManager.offerUIData;
			ContainerData container = offerUIData.container;
			Vector2 referenceResolution = default(Vector2);
			referenceResolution.x = container.width;
			referenceResolution.y = container.height;
			canvasScaler.referenceResolution = referenceResolution;
			canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
			GameObject uiContainer = new GameObject("UIContainer");
			_uiContainer = uiContainer;
			Transform transform = _uiContainer.transform;
			Transform parent = _dynamicCanvas.transform;
			transform.SetParent(parent, worldPositionStays: false);
			RectTransform rectTransform = _uiContainer.AddComponent<RectTransform>();
			OfferAssetManager offerAssetManager2 = _offerAssetManager;
			OfferUIData offerUIData2 = offerAssetManager2.offerUIData;
			((OfferUIManager)(object)rectTransform).SetContainerRectTransform(rectTransform, offerUIData2.container);
		}

		[Token(Token = "0x60027F3")]
		[Address(RVA = "0x3E498C4", Offset = "0x3E498C4", Length = "0x188")]
		private void CreateComponents()
		{
			OfferAssetManager offerAssetManager = _offerAssetManager;
			OfferUIData offerUIData = offerAssetManager.offerUIData;
			ComponentData[] components = offerUIData.components;
			if (components.Length < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				ComponentData componentData = components[num];
				if (componentData.type == "image")
				{
					CreateImage(components[num]);
				}
				else if (componentData.type == "button")
				{
					CreateButton(components[num]);
				}
				else if (componentData.type == "text")
				{
					CreateText(components[num]);
				}
				else
				{
					bool flag = componentData.type == "animation";
				}
				num++;
			}
			while (num < components.Length);
		}

		[Token(Token = "0x60027F4")]
		[Address(RVA = "0x3E4A144", Offset = "0x3E4A144", Length = "0x140")]
		private void CreateImage(ComponentData component)
		{
			GameObject gameObject = new GameObject("DynamicImage");
			Transform transform = gameObject.transform;
			Transform parent = _uiContainer.transform;
			transform.SetParent(parent, worldPositionStays: false);
			RawImage rawImage = gameObject.AddComponent<RawImage>();
			((OfferUIManager)(object)rawImage).SetImage(component.url, rawImage, gameObject, component);
			if (component.name.Contains("background"))
			{
				IsFullWide();
			}
		}

		[Token(Token = "0x60027F5")]
		[Address(RVA = "0x3E4AE58", Offset = "0x3E4AE58", Length = "0x21C")]
		private void SetImage(string url, RawImage rawImage, GameObject imgObject, ComponentData component)
		{
			string fileNameFromUrl = Utils.GetFileNameFromUrl(url);
			string subdirectoryPath = Utils.GetSubdirectoryPath();
			string path = Path.Combine(subdirectoryPath, fileNameFromUrl);
			byte[] data = File.ReadAllBytes(path);
			Texture2D texture2D = new Texture2D(2, 2);
			bool flag = texture2D.LoadImage(data);
			rawImage.texture = texture2D;
			OfferAssetManager offerAssetManager = _offerAssetManager;
			OfferUIData offerUIData = offerAssetManager.offerUIData;
			ContainerData container = offerUIData.container;
			RectTransform component2 = imgObject.GetComponent<RectTransform>();
			int width = texture2D.width;
			int height = texture2D.height;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = width;
			sizeDelta.y = height;
			component2.sizeDelta = sizeDelta;
			RectTransform component3 = imgObject.GetComponent<RectTransform>();
			float num = component.height * 0.5f;
			float num2 = component.y + num;
			float num3 = container.height * 0.5f;
			float y = num3 - num2;
			float num4 = component.width * 0.5f;
			float num5 = component.x + num4;
			float num6 = container.width * 0.5f;
			float x = num5 - num6;
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = x;
			anchoredPosition.y = y;
			component3.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x60027F6")]
		[Address(RVA = "0x3E4A284", Offset = "0x3E4A284", Length = "0x36C")]
		private void CreateButton(ComponentData component)
		{
			GameObject gameObject = new GameObject("DynamicButton");
			Transform transform = gameObject.transform;
			Transform parent = _uiContainer.transform;
			transform.SetParent(parent, worldPositionStays: false);
			Button button = gameObject.AddComponent<Button>();
			Image img = (Image)(button.targetGraphic = gameObject.AddComponent<Image>());
			ComponentData componentData = component;
			((OfferUIManager)(object)button).SetButtonImage(componentData.url, img);
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			((OfferUIManager)(object)component2).SetRectTransform(component2, component);
			ComponentData componentData2 = component;
			if (componentData2.action == "purchase")
			{
				UnityAction call = delegate
				{
					ComponentData componentData3 = component;
					PurchaseAction(componentData3.name);
				};
				button.onClick.AddListener(call);
				List<Button> currentPurchaseButtons = _currentPurchaseButtons;
				currentPurchaseButtons.Add(button);
			}
			else if (componentData2.action == "close")
			{
				UnityAction call2 = CloseAction;
				button.onClick.AddListener(call2);
			}
		}

		[Token(Token = "0x60027F7")]
		[Address(RVA = "0x3E4B07C", Offset = "0x3E4B07C", Length = "0x160")]
		private void SetButtonImage(string url, Image img)
		{
			string fileNameFromUrl = Utils.GetFileNameFromUrl(url);
			string subdirectoryPath = Utils.GetSubdirectoryPath();
			string path = Path.Combine(subdirectoryPath, fileNameFromUrl);
			byte[] data = File.ReadAllBytes(path);
			Texture2D texture2D = new Texture2D(2, 2);
			bool flag = texture2D.LoadImage(data);
			int width = texture2D.width;
			int height = texture2D.height;
			Rect rect = default(Rect);
			rect.x = 0f;
			rect.y = 0f;
			rect.width = width;
			rect.height = height;
			Vector2 pivot = default(Vector2);
			pivot.x = 0.5f;
			pivot.y = 0.5f;
			Sprite sprite = Sprite.Create(texture2D, rect, pivot);
			img.sprite = sprite;
		}

		[Token(Token = "0x60027F8")]
		[Address(RVA = "0x3E4A5F0", Offset = "0x3E4A5F0", Length = "0x868")]
		private void CreateText(ComponentData component)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferUIManager::CreateText");
		}

		[Token(Token = "0x60027F9")]
		[Address(RVA = "0x3E4B724", Offset = "0x3E4B724", Length = "0xE4")]
		private void AdjustFontSizeToFit(Text uiText, RectTransform textRect)
		{
			Canvas.ForceUpdateCanvases();
			if ((object)textRect == null)
			{
				float preferredWidth = uiText.preferredWidth;
				throw new NullReferenceException();
			}
			Rect rect2 = default(Rect);
			int fontSize3;
			do
			{
				float preferredWidth2 = uiText.preferredWidth;
				Rect rect = textRect.rect;
				bool flag = rect2.x < rect.width;
				bool flag2 = rect2.x == rect.width;
				bool flag3 = rect2.x == rect2.x;
				bool flag4 = rect.width == rect.width;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				bool flag9 = flag7 && flag8;
				rect2 = rect;
				if (!flag9)
				{
					float preferredHeight = uiText.preferredHeight;
					rect2 = textRect.rect;
					bool flag10 = rect.x < rect2.height;
					bool flag11 = rect.x == rect2.height;
					bool flag12 = rect.x == rect.x;
					bool flag13 = rect2.height == rect2.height;
					bool flag14 = flag12 && flag13;
					bool flag15 = !flag14;
					bool flag16 = flag10 == flag15;
					bool flag17 = !flag11;
					if (!(flag16 && flag17))
					{
						break;
					}
				}
				int fontSize = uiText.fontSize;
				int fontSize2 = fontSize - 1;
				uiText.fontSize = fontSize2;
				Canvas.ForceUpdateCanvases();
				fontSize3 = uiText.fontSize;
			}
			while (fontSize3 >= 1);
		}

		[Token(Token = "0x60027FA")]
		[Address(RVA = "0x3E4B2B0", Offset = "0x3E4B2B0", Length = "0x170")]
		private string FormatPriceString(string priceDetails, Font font)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferUIManager::FormatPriceString");
			return default;
		}

		[Token(Token = "0x60027FB")]
		[Address(RVA = "0x3E4B808", Offset = "0x3E4B808", Length = "0xA4")]
		private bool HasAllCharacters(Font font, string str)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferUIManager::HasAllCharacters");
			return default;
		}

		[Token(Token = "0x60027FC")]
		[Address(RVA = "0x3E4B420", Offset = "0x3E4B420", Length = "0x2DC")]
		private TextAnchor TextAlignmentMapper(ComponentData component)
		{
			string text_align_vertical;
			if (component.text_align_horizontal == "LEFT")
			{
				text_align_vertical = component.text_align_vertical;
				if (!(component.text_align_vertical == "TOP"))
				{
					if (component.text_align_vertical == "CENTER")
					{
						goto IL_012b;
					}
					goto IL_0298;
				}
			}
			else
			{
				if (component.text_align_horizontal == "CENTER")
				{
					if (component.text_align_vertical == "TOP")
					{
						return TextAnchor.UpperCenter;
					}
					if (component.text_align_vertical == "CENTER")
					{
						return TextAnchor.MiddleCenter;
					}
					if (component.text_align_vertical == "BOTTOM")
					{
						return TextAnchor.LowerCenter;
					}
					return TextAnchor.UpperCenter;
				}
				if (component.text_align_horizontal == "RIGHT")
				{
					if (component.text_align_vertical == "TOP")
					{
						return TextAnchor.UpperRight;
					}
					if (component.text_align_vertical == "CENTER")
					{
						return TextAnchor.MiddleRight;
					}
					if (component.text_align_vertical == "BOTTOM")
					{
						return TextAnchor.LowerRight;
					}
					return TextAnchor.UpperRight;
				}
				if (component.text_align_horizontal == "JUSTIFY")
				{
					text_align_vertical = component.text_align_vertical;
					if (!(component.text_align_vertical == "TOP"))
					{
						if (component.text_align_vertical == "CENTER")
						{
							goto IL_012b;
						}
						goto IL_0298;
					}
				}
			}
			return default(TextAnchor);
			IL_012b:
			return TextAnchor.MiddleLeft;
			IL_0298:
			if (text_align_vertical == "BOTTOM")
			{
				return TextAnchor.LowerLeft;
			}
			return default(TextAnchor);
		}

		[Token(Token = "0x60027FD")]
		[Address(RVA = "0x3E4B1DC", Offset = "0x3E4B1DC", Length = "0xCC")]
		private void SetRectTransform(RectTransform rectTransform, ComponentData component)
		{
			OfferAssetManager offerAssetManager = _offerAssetManager;
			OfferUIData offerUIData = offerAssetManager.offerUIData;
			ContainerData container = offerUIData.container;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = component.width;
			sizeDelta.y = component.height;
			rectTransform.sizeDelta = sizeDelta;
			float num = component.width * 0.5f;
			float num2 = component.x + num;
			float num3 = container.width * 0.5f;
			float x = num2 - num3;
			float num4 = container.height * 0.5f;
			float num5 = component.height * 0.5f;
			float num6 = component.y + num5;
			float y = num4 - num6;
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = x;
			anchoredPosition.y = y;
			rectTransform.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x60027FE")]
		[Address(RVA = "0x3E4A04C", Offset = "0x3E4A04C", Length = "0xF8")]
		private void SetContainerRectTransform(RectTransform rectTransform, ContainerData container)
		{
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = Vector2.zero.x;
			anchorMin.y = Vector2.zero.y;
			rectTransform.anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = Vector2.one.x;
			anchorMax.y = Vector2.one.y;
			rectTransform.anchorMax = anchorMax;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = container.width;
			sizeDelta.y = container.height;
			rectTransform.sizeDelta = sizeDelta;
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = Vector2.zero.x;
			anchoredPosition.y = Vector2.zero.y;
			rectTransform.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x60027FF")]
		[Address(RVA = "0x3E4B8AC", Offset = "0x3E4B8AC", Length = "0x2D4")]
		private unsafe void PurchaseAction(string componentName)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferUIManager::PurchaseAction");
		}

		[Token(Token = "0x6002800")]
		[Address(RVA = "0x3E4BB88", Offset = "0x3E4BB88", Length = "0x70")]
		private void CloseAction()
		{
			Elephant.TriggerOfferDismissed(_currentPurchaseOptions);
			DismissOfferUI();
		}

		[Token(Token = "0x6002801")]
		[Address(RVA = "0x3E4B6FC", Offset = "0x3E4B6FC", Length = "0x28")]
		private static Vector2 GetOriginalTopLeft(Vector2 boundingBoxPosition, Vector2 boundingBoxSize, Vector2 originalSize)
		{
			float num = boundingBoxSize.x * 0.5f;
			float num2 = boundingBoxPosition.x + num;
			float num3 = originalSize.x * 0.5f;
			float x = num2 - num3;
			Vector2 result = default(Vector2);
			result.x = x;
			return result;
		}

		[Token(Token = "0x6002802")]
		[Address(RVA = "0x3E4BBF8", Offset = "0x3E4BBF8", Length = "0xE0")]
		public OfferUIManager()
		{
			List<PurchaseOption> currentPurchaseOptions = new List<PurchaseOption>();
			_currentPurchaseOptions = currentPurchaseOptions;
			List<Button> currentPurchaseButtons = new List<Button>();
			_currentPurchaseButtons = currentPurchaseButtons;
		}
	}
}
