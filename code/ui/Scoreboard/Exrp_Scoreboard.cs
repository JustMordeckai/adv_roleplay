
using Sandbox;
using Sandbox.Hooks;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI
{
	public partial class Exrp_Scoreboard<T> : Panel where T : Exrp_ScoreboardEntry, new()
	{
		public Panel Canvas { get; protected set; }
		Dictionary<Client, T> Rows = new ();

		public Panel Header { get; protected set; }

		public bool State = false;

		public Exrp_Scoreboard()
		{
			StyleSheet.Load( "/ui/scoreboard/Exrp_Scoreboard.scss" );
			AddClass( "scoreboard" );

			AddHeader();

			Canvas = Add.Panel( "canvas" );

			Scoreboard_Toggle.OnOpenScoreboard += Open;
		}
		public void Open()
		{
			if ( State == false )
				AddClass( "open" );
			else if ( State == true )
				RemoveClass( "open" );
			State = !State;
		}

		public override void Tick()
		{
			base.Tick();

			//SetClass( "open", Input.Down( InputButton.Slot0 ) );

			if ( !IsVisible )
				return;

			//
			// Clients that were added
			//
			foreach ( var client in Client.All.Except( Rows.Keys ) )
			{
				var entry = AddClient( client );
				Rows[client] = entry;
			}

			foreach ( var client in Rows.Keys.Except( Client.All ) )
			{
				if ( Rows.TryGetValue( client, out var row ))
				{
					row?.Delete();
					Rows.Remove( client );
				}
			}
		}


		protected virtual void AddHeader() 
		{
			Header = Add.Panel( "header" );
			Header.Add.Label( "Name", "name" );
			Header.Add.Label( "Id", "id" );
			Header.Add.Label( "Kills", "kills" );
			Header.Add.Label( "Deaths", "deaths" );
			Header.Add.Label( "Ping", "ping" );
		}

		protected virtual T AddClient( Client entry )
		{
			var p = Canvas.AddChild<T>();
			p.Client = entry;
			return p;
		}
	}
}

namespace Sandbox.Hooks
{
	public static partial class Scoreboard_Toggle
	{
		public static event Action OnOpenScoreboard;

		[ClientCmd( "admin_scoreboard" )]
		internal static void MessageMode()
		{
			OnOpenScoreboard?.Invoke();
		}

	}
}
