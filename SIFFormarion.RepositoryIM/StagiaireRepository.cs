using Microsoft.Extensions.DependencyInjection;
using SIFormation.IRepository;
using SIFormation.Models;
using System;
using System.Collections;
using System.Collections.Generic;


namespace SIFFormarion.RepositoryIM
{
   
    public class StagiaireRepository : IStagiaireRepository
    {
        private readonly List<Stagiaire> _stagiaires = new List<Stagiaire>();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public ServiceDescriptor this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public StagiaireRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            _stagiaires.Add(new Stagiaire() { Matricule = "20200650", Prenom = "Vincent", Nom = "Bost", Email = "vincent.bost@afpa.fr", DateNaissance = new DateTime(1962, 01, 13),IdGroup=1});
            _stagiaires.Add(new Stagiaire() { Matricule = "20200651", Prenom = "Pierre", Nom = "Bonnelier", Email = "pierre.bonnelier@gmail.com", DateNaissance = new DateTime(1996, 01, 14) });
            _stagiaires.Add(new Stagiaire() { Matricule = "20200652", Prenom = "Romain", Nom = "Sirer", Email = "romain.sirer@gmail.com", DateNaissance = new DateTime(1996, 01, 15) });
            _stagiaires.Add(new Stagiaire() { Matricule = "20200653", Prenom = "Tristan", Nom = "Ranconer", Email = "tristan.rznchoner@gmail.com", DateNaissance = new DateTime(1996, 01, 16) });
        }

        public void Delete(string matricule)
        {
            _stagiaires.Remove(Find(matricule));
        }

        public Stagiaire Find(string matricule)
        {
            return _stagiaires.Find(s => s.Matricule == matricule);
        }

        public IEnumerable<Stagiaire> GetAll()
        {
            return _stagiaires;
        }

        public void Insert(Stagiaire stagiaire)
        {
           _stagiaires.Add(stagiaire);
        }

        public void Update(Stagiaire stagiaire)
        {
            Stagiaire stagiaireU = Find(stagiaire.Matricule);
            if (stagiaireU!=null)
            {
                int i= _stagiaires.IndexOf(stagiaireU);
                _stagiaires.RemoveAt(i);
                _stagiaires.Insert(i, stagiaire);
            }
            
        }

    }
}
    
