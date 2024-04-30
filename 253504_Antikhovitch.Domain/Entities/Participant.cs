using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Domain.Entities
{
    public class Participant : Entity
    {
        private Participant() { }

        public Participant(Person? personalData, byte[] image, int points = 0)
        {
            PersonalData = personalData;
            Points = points;
            Image = image;
        }

        public new int Id { get; set; }

        public byte[] Image { get; set; }

        public Person? PersonalData { get; private set; }

        public int Points { get; private set; }

        public int? TeamId { get; private set; }

        public void AddToTeam(int? teamId)
        {
            if (teamId <= 0)
                return;
            TeamId = teamId;
        }

        public void LeaveTeam()
        {
            TeamId = 0;
        }

        public void ChangePoint(int points)
        {
            if (points < 0 || points > 100)
                return;
            Points = points;
        }

        public void ChangeInfo(Person? personData)
        {
            if (PersonalData != null)
            {
                PersonalData = personData;
            }
        }

        public void ChangeImage(byte[] image)
        {
            if (image != null)
            {
                Image = image;
            }
        }

        public void RemoveFromTeam(int? teamId)
        {
            TeamId = 0;
        }

        public sealed record Person(string? Name, DateTime? DateOfBirth);
    }
}
