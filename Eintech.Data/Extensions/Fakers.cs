using Bogus;
using Eintech.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eintech.Data.Extensions
{
    public static class Fakers
    {
        //public static Faker<Group> GroupFaker;
        //public static Faker<Models.Person> PeopleFaker;

        public static List<Group> Groups { get; set; } = new List<Group>();
        public static List<Models.Person> People { get; set; } = new List<Models.Person>();

        public static bool IsInit { get; set; }

        /// <summary>
        /// Setup fake data
        /// </summary>
        public static void Init(bool includeNavProperties = false)
        {
            var GroupFaker = GetGroupRules();
            Groups = GroupFaker.Generate(4);            

            foreach (var g in Groups)
            {
                var PeopleFaker = GetPersonRules(includeNavProperties, g.Id, g);

                People.AddRange(PeopleFaker.Generate(10));
            }

            IsInit = true;
        }

        private static Faker<Models.Person> GetPersonRules(bool includeNavProperties, Guid GroupId, Group group)
        {
            var rules = new Faker<Models.Person>()
                .RuleFor(u => u.Id, (f, u) => f.Database.Random.Guid())
                .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.CreatedOn, (f, u) => f.Date.Between(DateTime.Today, DateTime.Today.AddMonths(12)))
                .RuleFor(u => u.GroupId, (f, u) => GroupId)
                ;

            if (includeNavProperties)
                rules.RuleFor(u => u.Group, (f, u) => group);

            return rules;
        }

        private static Faker<Group> GetGroupRules()
        {
            return new Faker<Models.Group>()
                .RuleFor(u => u.Id, (f, u) => f.Database.Random.Guid())
                .RuleFor(u => u.Name, (f, u) => f.Vehicle.Manufacturer())
                ;
        }
    }
}