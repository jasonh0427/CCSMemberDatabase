using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MemberDatabase.Data
{
    public class MemberUserInfo : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }


        [PersonalData]
        public DateTime BirthDate { get; set; }

        [PersonalData]
        public string College { get; set; }

        [PersonalData]
        public int? YearOfAdmission { get; set; }

        [PersonalData]
        public int? YearOfGraduation { get; set; }

        [PersonalData]
        public string Subject { get; set; }

        public int Privilege { get; set; }

        public string Spouse { get; set; }
        public string Parent1 { get; set; }
        public string Parent2 { get; set; }
        public string Child1 { get; set; }
        public string Child2 { get; set; }
        public string Child3 { get; set; }
        public string Child4 { get; set; }
    }
}