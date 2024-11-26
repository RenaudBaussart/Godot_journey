using Godot;
using System;
public partial class ButtonMinus : Button
{
	public override void _Ready()
	{
		// Connecte le signal "pressed" à la méthode OnButtonPressed
		Pressed += OnButtonPressed;
	}
	private void OnButtonPressed(){
		var baseScene = GetParent<BaseScene>();
		baseScene.RemoveToScore(1);
	}
}
