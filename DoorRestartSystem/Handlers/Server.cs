using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace DoorRestartSystem.Handlers
{
    internal sealed class Server
    {
        private readonly DoorRestartsystem plugin;
        public Server(DoorRestartsystem plugin) => this.plugin = plugin;
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public void OnRoundStarted()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);

            int y = plugin.Gen.Next(100);
            if (y <= plugin.Config.Spawnchance)
            {            
            Coroutines.Add(Timing.RunCoroutine(plugin.RunBlackoutTimer()));
            } 
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
        }

        public void OnWaitingForPlayers()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
        }   
    }
}
