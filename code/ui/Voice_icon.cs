using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class Voice_icon : Panel
{

	public Voice_icon()
	{
		Add.Label("🔊", "icon" );
	}

	public override void Tick()
	{
		base.Tick();

		SetClass( "open", Input.Down( InputButton.Voice ) );

	}
}
