using LogginingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogginingApp.Data
{
    public class ParticipantController
    {
        private static ParticipantController controller = new ParticipantController();
        private List<Participant> participants = new List<Participant>();

        public static ParticipantController GetController()
        {
            return controller;
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            return participants;
        }

        public void AddParticipant (Participant participant)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(participant);

            if (!Validator.TryValidateObject(participant,context, results,true))
            {

            }
            else
            {
                participants.Add(participant);
            }
        }
    }
}