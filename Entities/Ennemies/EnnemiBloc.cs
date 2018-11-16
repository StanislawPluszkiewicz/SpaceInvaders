using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class EnnemiBloc : Entity
    {
        public List<EnnemiLine> EnnemiBlocList { get; private set; }
        public EnnemiBloc(List<EnnemiLine> ennemiBlocList)
        {
            this.EnnemiBlocList = ennemiBlocList;
        }
    }
}
