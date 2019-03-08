using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MemberDatabase.Data
{
    public class MemberRelationship
    {
        public int Id { get; set; }
        public string SourceUser { get; set; }
        public string TargetUser { get; set; }
        public int Relationship { get; set; }
        public int? Result { get; set; }
        public DateTime ApplyingTime { get; set; }
    }
}
