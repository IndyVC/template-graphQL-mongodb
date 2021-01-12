using Skillz.Models.Companies;
using Skillz.Models.Entities;
using Skillz.Models.Entities.Consultants;
using Skillz.Models.Entities.People;
using Skillz.Models.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Consultants
{
    public class Consultant: Person
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string FunctionName { get; set; }
        public string FunctionLevel { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<ConsultantNote> Notes { get; set; }


        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public ICollection<ConsultantProfile> Profiles { get; set; }
        public ICollection<ConsultantContract> Contracts { get; set; }
        public ICollection<ConsultantSkill> Skills { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        private Consultant()
        {

        }

        public Consultant(string firstName, string lastName, Guid companyId)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyId = companyId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void AddNote(ConsultantNote note) {
            if (Notes == null) Notes = new List<ConsultantNote>();
            Notes.Add(note);
        }

        public void Update(string firstName, string lastName, DateTime dateOfBirth, string mobilePhone, string email, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthdate = dateOfBirth;
            //if (null != this.Address)
            //{
            //    this.Address.Update(address.Street, address.HouseNumber, address.City, address.ZipCode, address.State, address.Country);
            //}
            this.Email = email;
            this.Phone = phoneNumber;
            this.MobilePhone = mobilePhone;
        }


        public override string ToString()
        {

            return $"{FirstName} {LastName}";

        }
    }
}
