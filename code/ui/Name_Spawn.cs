using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;


public class Name_Spawn : Panel
{
	public Label Label;
	Dictionary<string, Button> Buttons;
	public Name_Spawn()
	{
		Buttons = new Dictionary<string, Sandbox.UI.Button>();

		Style.FlexWrap = Wrap.Wrap;
		Style.JustifyContent = Justify.Center;
		Style.AlignItems = Align.Center;
		Style.AlignContent = Align.Center;

		Add.Label( "RP Name", "text" );

		AddTest( "padding: 10px; text-align: center; background-color: rgba( red, 0.5 ); border-radius: 4px; color: white;", "Your name" );
		Add.Label( " ", "space" );

		Add.Button( "Play", "bp_close", () => CloseMenu() );

	}

	void CloseMenu()
	{
		SetClass( "close", true );
	}

	private Sandbox.UI.TextEntry AddTest( string style, string text )
	{
		var p = Add.TextEntry( text );

		p.Style.Set( style );

		return p;
	}
}
