using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entities
{
    class EnnemiLine : Entity
    {
        public List<Ennemi> EnnemiLineList { get; private set; }

        public EnnemiLine(List<Ennemi> ennemiLineList)
        {
            this.EnnemiLineList = ennemiLineList;
        }
    }
}
