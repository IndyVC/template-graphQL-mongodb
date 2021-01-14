using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Dto
{
    public class ConsultantDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string FunctionName { get; set; }
        public string FunctionLevel { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }

        public ICollection<NoteDto> Notes { get; set; }
    }
}
