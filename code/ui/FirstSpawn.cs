using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;


public class FirstSpawn : Panel
{
	public Label Label;
	Dictionary<string, Button> Buttons;
	public FirstSpawn()
	{
		Buttons = new Dictionary<string, Button>();

		Style.FlexWrap = Wrap.Wrap;
		Style.JustifyContent = Justify.Center;
		Style.AlignItems = Align.Center;
		Style.AlignContent = Align.Center;

		Add.Label( "Advanced Roleplay", "title" );

		Add.Label( "Press TAB to see Inventory Bar and Health", "text" );
		Add.Label( "'admin_scoreboard' in the console to toggle the Scoreboard", "text" );
		Add.Label( "Press V to see the voice chat activation icon\n ", "text" );

		Add.Button( "Play", "bp_close", () => CloseMenu() );

	}

	void CloseMenu()
	{
		SetClass( "close", true );
	}
}
