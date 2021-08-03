using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class Health : Panel
{
	public Label Label;

	public Health()
	{
		Add.Label("❤ ", "icon" );
		Label = Add.Label("100", "value" );
	}

	public override void Tick()
	{
		base.Tick();

		SetClass( "open", Input.Down( InputButton.Score ) );

		var player = Local.Pawn;
		if ( player == null ) return;

		Label.Text = $"{player.Health.CeilToInt()}";

	}
}
