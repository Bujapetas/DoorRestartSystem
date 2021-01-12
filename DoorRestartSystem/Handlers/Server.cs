﻿using System.Collections.Generic;
using Exiled;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.EventArgs;
using MEC;

namespace DoorRestartSystem.Handlers
{
    internal sealed class Server
    {
        private readonly Doorestartsystem plugin;
        public Server(Doorestartsystem plugin) => this.plugin = plugin;

       

        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        public void OnRoundStarted()
        {
            Log.Info("Reached OnROundstarted");
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
                Coroutines.Add(Timing.RunCoroutine(plugin.RunBlackoutTimer()));
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
