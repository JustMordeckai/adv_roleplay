
using Sandbox;
using Sandbox.Hooks;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	public partial class Exrp_ScoreboardEntry : Panel
	{

		public Client Client;

		public Label PlayerName;
		public Label Kills;
		public Label Deaths;
		public Label Ping;
		public Label Id;

		public Exrp_ScoreboardEntry()
		{
			AddClass( "entry" );

			PlayerName = Add.Label( "PlayerName", "name" );
			Id = Add.Label( "", "id" );
			Kills = Add.Label( "", "kills" );
			Deaths = Add.Label( "", "deaths" );
			Ping = Add.Label( "", "ping" );
		}

		RealTimeSince TimeSinceUpdate = 0;

		public override void Tick()
		{
			base.Tick();

			if ( !IsVisible )
				return;

			if ( !Client.IsValid() )
				return;

			if ( TimeSinceUpdate < 0.1f )
				return;

			TimeSinceUpdate = 0;
			UpdateData();
		}

		public virtual void UpdateData()
		{
			PlayerName.Text = Client.Name;
			Id.Text = Client.PlayerId.ToString();
			Kills.Text = Client.GetInt( "kills" ).ToString();
			Deaths.Text = Client.GetInt( "deaths" ).ToString();
			Ping.Text = Client.Ping.ToString();
			SetClass( "me", Client == Local.Client );
		}

		public virtual void UpdateFrom( Client client )
		{
			Client = client;
			UpdateData();
		}
	}
}
