using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_ClickTheCircles
{
    public class GameState
    {
        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

        public virtual bool StateShouldChange()
        {
            return false;
        }

        public virtual GameStates GetNextGameState()
        {
            return GameStates.None;
        }
    }

    public enum GameStates
    {
        None,
        GameLoop,
        EndScreen
    }
}
