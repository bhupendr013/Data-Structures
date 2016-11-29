using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class State
    {
        public abstract void PressPlay(MusicPlayerContext context);
    }

    public class StandByState : State
    {
        public override void PressPlay(MusicPlayerContext context)
        {

            context.SetState(new PlayingState());
        }
    }

    public class PlayingState : State
    {
        public override void PressPlay(MusicPlayerContext context)
        {
            context.SetState(new StandByState());
        }
    }

    public abstract class MusicPlayerContext
    {
        public State state;
        public abstract void RequestPlay();
        public abstract void SetState(State state);
        public abstract State GetState();

    }

    public class MusicPlayerControl : MusicPlayerContext
    {
        State state;
        public MusicPlayerControl(State state)
        {
            this.state = state;
        }

        public override void RequestPlay()
        {
            state.PressPlay(this);
        }

        public override void SetState(State state)
        {
            this.state = state;
        }
        public override State GetState()
        {
            return this.state;
        }
    }
    class StatePattern
    {
        public void ControlState()
        {
            MusicPlayerControl mp = new MusicPlayerControl(new StandByState());
            mp.RequestPlay();
            mp.SetState(new PlayingState());
            mp.RequestPlay();
        }
    }
}
