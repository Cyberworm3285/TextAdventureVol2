using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Commands
{
    class CommandApplication
    {
        private CommandApplication instance;

        #region Properties

        public CommandApplication Instance
        {
            get
            {
                return instance ?? (instance = new CommandApplication());
            }
        }

        #endregion
    }
}
