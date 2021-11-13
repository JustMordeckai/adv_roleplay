using Sandbox;
using Sandbox.UI;

[Library]
public partial class AdvRpHud : HudEntity<RootPanel>
{
	public AdvRpHud()
	{
		if ( !IsClient )
			return;

		RootPanel.StyleSheet.Load( "/ui/AdvRpHud.scss" );

		RootPanel.AddChild<NameTags>();
		//RootPanel.AddChild<CrosshairCanvas>();
		//RootPanel.AddChild<ChatBox>();
		RootPanel.AddChild<VoiceList>();
		RootPanel.AddChild<KillFeed>();
		RootPanel.AddChild<Exrp_Scoreboard<Exrp_ScoreboardEntry>>();
		RootPanel.AddChild<Health>();
		RootPanel.AddChild<FirstSpawn>();
		RootPanel.AddChild<InventoryBar>();
		RootPanel.AddChild<CurrentTool>();
		RootPanel.AddChild<SpawnMenu>();
		RootPanel.AddChild<Voice_icon>();
		RootPanel.SetTemplate( "/ui/AdvRpHud.html" );
	}
}
