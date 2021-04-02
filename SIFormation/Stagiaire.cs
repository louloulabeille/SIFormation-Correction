using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SIFormation.Models

{
    public class Stagiaire : INotifyPropertyChanged
    {
        private string _matricule;
        private string _nom;
        private string _prenom;
        private string _eMail;
        private string _telephone;
        private DateTime? _dateNaissance;
        private string _photo;
        private int _idGroupe;


        [Required]
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                if (value != _nom)
                {
                    SetProperty(ref _nom, value);

                }
            }
        }
        [Required]
        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                SetProperty(ref _prenom, value);
            }
        }


        public DateTime? DateNaissance { get => _dateNaissance; set => SetProperty(ref _dateNaissance, value); }
        [EmailAddress]
        public string Email { get => _eMail; set => SetProperty(ref _eMail, value); }
        [Key]
        [RegularExpression(@"\d{8}",ErrorMessage = "Doit comporter 8 chiffres")]
        public string Matricule { get => _matricule; set => SetProperty(ref _matricule, value); }
        [Phone]
        public string Telephone { get => _telephone; set => SetProperty(ref _telephone, value); }

        public string Photo { get => _photo; set => SetProperty(ref _photo, value); }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int IdGroup { get => _idGroupe; set => SetProperty(ref _idGroupe, value); }
        void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Object.Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }
        public override bool Equals(Object obj)
        {
            Stagiaire sc = obj as Stagiaire;
            return sc == null ? false : sc._matricule == this._matricule;
        }


        public bool Equals(Stagiaire stagiaire)
        {
            return stagiaire == null ? false : stagiaire._matricule == this._matricule;
        }

        public static bool operator ==(Stagiaire stagA, Stagiaire stagB)
        {
            return stagA is null ? stagB is null : stagA.Equals(stagB);
        }

        public static bool operator !=(Stagiaire stagA, Stagiaire stagB)
        {
            return stagA is null ? !(stagB is null) : !(stagA.Equals(stagB));
        }

        public override int GetHashCode()
        {
            // Uniquement si non nul
            return (_matricule != null) ? _matricule.GetHashCode() : 0;
        }
    }
}
