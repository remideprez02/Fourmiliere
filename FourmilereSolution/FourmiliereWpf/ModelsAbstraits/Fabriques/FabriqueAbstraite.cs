using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibAbstraite
{
    public abstract class FabriqueAbstraite
    {
        public abstract string Titre { get; }
        public abstract EnvironnementAbstrait CreerEnvironnement();
        public abstract ZoneAbstraite CreerZone(string nom, int x, int y);
        public abstract AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin);
        public abstract PersonnageAbstrait CreerPersonnage(string nom, ZoneAbstraite position);
        public abstract ObjetAbstrait CreerObjet(string nom);

    }
}
