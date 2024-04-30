using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Domain.Entities
{
    public class Team : Entity
    {
        private List<Participant> _participants = new();
        
        private Team() { }
        
        public Team(string name, string sport)
        {
            Name = name;
            Sport = sport;
        }

        public string? Name { get; set; }

        public string? Sport { get; set; }

        public new int Id { get; set; }

        public void ChangeName(string name)
        {
            if (Name != null)
            {
                Name = name;
            }
        }

        public void ChangeSport(string sport)
        {
            if (Sport != null) 
            { 
                Sport = sport; 
            }
        }
        // Публичное свойство для доступа к списку участников команды
        // (только для чтения)

        public IReadOnlyList<Participant> Participants
        {
            get => _participants.AsReadOnly();
        }

    }
}
