using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelixToolkit.Wpf;

public abstract class SelectionCommand : ICommand
{
	protected readonly Viewport3D Viewport;

	private Cursor oldCursor;

	public SelectionHitMode SelectionHitMode { get; set; }

	protected Point MouseDownPoint { get; private set; }

	public event EventHandler CanExecuteChanged;

	private event EventHandler<ModelsSelectedEventArgs> ModelsSelected;

	protected SelectionCommand(Viewport3D viewport, EventHandler<ModelsSelectedEventArgs> eventHandler)
	{
		Viewport = viewport;
		ModelsSelected = eventHandler;
	}

	public void Execute(object parameter)
	{
		OnMouseDown(Viewport);
	}

	public bool CanExecute(object parameter)
	{
		return true;
	}

	protected virtual void Started(ManipulationEventArgs e)
	{
		MouseDownPoint = e.CurrentPosition;
	}

	protected virtual void Delta(ManipulationEventArgs e)
	{
	}

	protected virtual void Completed(ManipulationEventArgs e)
	{
	}

	protected virtual void OnModelsSelected(ModelsSelectedEventArgs e)
	{
		ModelsSelected?.Invoke(Viewport, e);
	}

	protected abstract Cursor GetCursor();

	protected virtual void OnMouseDown(object sender)
	{
		Viewport.MouseMove += OnMouseMove;
		Viewport.MouseUp += OnMouseUp;
		Viewport.Focus();
		Viewport.CaptureMouse();
		Started(new ManipulationEventArgs(Mouse.GetPosition(Viewport)));
		oldCursor = Viewport.Cursor;
		Viewport.Cursor = GetCursor();
	}

	protected virtual void OnMouseUp(object sender, MouseButtonEventArgs e)
	{
		Viewport.MouseMove -= OnMouseMove;
		Viewport.MouseUp -= OnMouseUp;
		Viewport.ReleaseMouseCapture();
		Viewport.Cursor = oldCursor;
		Completed(new ManipulationEventArgs(Mouse.GetPosition(Viewport)));
		e.Handled = true;
	}

	protected virtual void OnMouseMove(object sender, MouseEventArgs e)
	{
		Delta(new ManipulationEventArgs(Mouse.GetPosition(Viewport)));
		e.Handled = true;
	}

	protected virtual void OnCanExecutedChanged(object sender, EventArgs e)
	{
		CanExecuteChanged?.Invoke(sender, e);
	}
}
