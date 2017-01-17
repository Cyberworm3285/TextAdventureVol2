using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Types.Classes
{
    abstract class Entity
    {
        private string name;
        private string Id;
        private string refID;

        #region Properties

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string RefID
        {
            get
            {
                return refID;
            }
            set
            {
                refID = value;
            }
        }

        public string ID
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        #endregion
    }
}
