using Microsoft.Extensions.DependencyInjection;
using SIFormation.Models;
using System.Collections.Generic;

namespace SIFormation.IRepository
{
    public interface IStagiaireRepository 
    {
        IEnumerable<Stagiaire> GetAll();
        Stagiaire Find(string matricule);
        void Insert(Stagiaire stagiaire);
        void Update(Stagiaire stagiaire);
        void Delete(string matricule);
    }
}