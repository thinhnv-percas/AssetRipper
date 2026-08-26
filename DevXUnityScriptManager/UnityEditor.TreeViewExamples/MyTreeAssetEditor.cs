using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UnityEditor.TreeViewExamples;

[CustomEditor(typeof(MyTreeAsset))]
public class MyTreeAssetEditor : Editor
{
	private class _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A : _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020<ScriptDbTreeElement>
	{
		public _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A(TreeViewState state, TreeModel<ScriptDbTreeElement> model)
			: base(state, model)
		{
			this.showBorder = true;
			this.showAlternatingRowBackgrounds = true;
		}
	}

	private _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A;

	private SearchField _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020;

	private const string _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020 = "TVS";

	private MyTreeAsset _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020 => (MyTreeAsset)(object)((Editor)this).target;

	private void OnEnable()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		Undo.undoRedoPerformed = (Undo.UndoRedoCallback)Delegate.Combine((Delegate)(object)Undo.undoRedoPerformed, (Delegate)new Undo.UndoRedoCallback(_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020));
		TreeViewState state = new TreeViewState();
		SessionState.GetString(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020 + ((UnityEngine.Object)_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020).GetInstanceID(), "");
		TreeModel<ScriptDbTreeElement> model = new TreeModel<ScriptDbTreeElement>(_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020.treeElements);
		_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A = new _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A(state, model);
		_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.beforeDroppingDraggedItems += _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A;
		((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).Reload();
		_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020 = new SearchField();
		_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020.downOrUpArrowKeyPressed += new SearchField.SearchFieldCallback(((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).SetFocusAndEnsureSelectedItem);
	}

	private void OnDisable()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		Undo.undoRedoPerformed = (Undo.UndoRedoCallback)Delegate.Remove((Delegate)(object)Undo.undoRedoPerformed, (Delegate)new Undo.UndoRedoCallback(_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020));
	}

	private void _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020()
	{
		if (_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A != null)
		{
			_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.treeModel.SetData(_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020.treeElements);
			((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).Reload();
		}
	}

	private void _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A(IList<TreeViewItem> P_0)
	{
		Undo.RecordObject((UnityEngine.Object)(object)_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020, string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A, P_0.Count, (P_0.Count > 1) ? _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020 : ""));
	}

	public override void OnInspectorGUI()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		GUILayout.Space(5f);
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020();
		GUILayout.Space(3f);
		float num = ((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).totalHeight + 20f + 4f;
		Rect rect = GUILayoutUtility.GetRect(0f, 10000f, 0f, num);
		Rect val = default(Rect);
		val = new Rect(rect.x, rect.y, rect.width, 20f);
		Rect val2 = default(Rect);
		val2 = new Rect(rect.x, rect.y + 20f + 2f, rect.width, rect.height - 20f - 4f);
		_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020(val);
		_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(val2);
	}

	private void _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020(Rect P_0)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).searchString = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020.OnGUI(P_0, ((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).searchString);
	}

	private void _0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(Rect P_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).OnGUI(P_0);
	}

	private void _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		EditorGUILayout.HorizontalScope val = new EditorGUILayout.HorizontalScope((GUILayoutOption[])(object)new GUILayoutOption[0]);
		try
		{
			string text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A;
			if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020, (GUIStyle)(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).ExpandAll();
			}
			if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A, (GUIStyle)(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).CollapseAll();
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020, (GUIStyle)(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				Undo.RecordObject((UnityEngine.Object)(object)_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A);
				IList<int> selection = ((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).GetSelection();
				TreeElement treeElement = ((selection.Count == 1) ? _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.treeModel.Find(selection[0]) : null) ?? _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.treeModel.root;
				int depth = ((treeElement != null) ? (treeElement.depth + 1) : 0);
				int num = _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.treeModel.GenerateUniqueID();
				ScriptDbTreeElement element = new ScriptDbTreeElement(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 + num, depth, num);
				_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.treeModel.AddElement(element, treeElement, 0);
				((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).SetSelection((IList<int>)new int[1] { num }, (TreeViewSelectionOptions)2);
			}
			if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A, (GUIStyle)(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				Undo.RecordObject((UnityEngine.Object)(object)_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020);
				IList<int> selection2 = ((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).GetSelection();
				_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A.treeModel.RemoveElements(selection2);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}
