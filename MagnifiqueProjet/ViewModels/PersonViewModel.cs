using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagnifiqueProjet.Models;
using ToolBox.Patterns.MVVM.ViewModels;

namespace MagnifiqueProjet.ViewModels
{
    class PersonViewModel : ViewModelBase
    {
        private readonly Person _Entity;

        public PersonViewModel(Person entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _Entity = entity;
        }

        public string Nom
        {
            get { return _Entity.LastName; }
            set
            {
                if (_Entity.LastName != value)
                {
                    _Entity.LastName = value;
                    RaisePropertyChanged(nameof(Nom));
                }
            }
        }

        public string Prenom
        {
            get { return _Entity.FirstName; }
            set
            {
                if (_Entity.FirstName != value)
                {
                    _Entity.FirstName = value;
                    RaisePropertyChanged(nameof(Prenom));
                }
            }
        }

        public int Id
        {
            get { return _Entity.BusinessEntityID; }
            set
            {
                if (_Entity.BusinessEntityID != value)
                {
                    _Entity.BusinessEntityID = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

    }
}
