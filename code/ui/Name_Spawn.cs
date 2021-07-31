using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public class Name_Spawn : Panel
{
	public Label Label;
	Dictionary<string, Sandbox.UI.Button> Buttons;
	public Name_Spawn()
	{
		Buttons = new Dictionary<string, Sandbox.UI.Button>();

		Style.FlexWrap = Wrap.Wrap;
		Style.JustifyContent = Justify.Center;
		Style.AlignItems = Align.Center;
		Style.AlignContent = Align.Center;

		AddTest( "padding: 10px; text-align: center;", "Future menu for choosing the RP name that will appear when the player spawns." );

	}

	public override void Tick()
	{
		base.Tick();

		SetClass( "open", Input.Down( InputButton.Voice ) );
	}

	private Sandbox.UI.TextEntry AddTest( string style, string text )
	{
		var p = Add.TextEntry( text );

		p.Style.Set( style );

		return p;
	}
}
