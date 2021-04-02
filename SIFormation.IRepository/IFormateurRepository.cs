using SIFormation.Models;
using System.Collections.Generic;

namespace SIFormation.IRepository
{
    public interface IFormateurRepository
    {
        IEnumerable<Formateur> GetAll();
        Formateur Find(string matricule);
        void Insert(Formateur formateur);
        void Update(Formateur formateur);
        void Delete(string matricule);
    }
}