using System;
using System.Collections.Generic;

namespace Inlämningsuppgift3
{
    class Program
    {
        public List<Customer> customers = new List<Customer>
        {
            new Customer { PersonalIdentityNumber = 1, LastName = "Ernst", FirstName = "Albert", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 2, LastName = "Hoffmeister", FirstName = "Ludwig", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 3, LastName = "Kim", FirstName = "Seung-ya", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 4, LastName = "Johnson", FirstName = "Edwin", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 5, LastName = "Shieldfire", FirstName = "Matthew", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 6, LastName = "Brutus", FirstName = "Marcus", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 7, LastName = "Pierovich", FirstName = "Svoloch", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 8, LastName = "Jakobwicz", FirstName = "Gregor", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 9, LastName = "Durst", FirstName = "Fredric", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 10, LastName = "Ngugi", FirstName = "Nuewe", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 11, LastName = "Li", FirstName = "Chang", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 12, LastName = "Frigas", FirstName = "Emaneul", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 13, LastName = "d'Arc", FirstName = "Jeanne", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 14, LastName = "Ali", FirstName = "Mahmut", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 15, LastName = "Dien", FirstName = "Xuoc", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 16, LastName = "Oystein", FirstName = "Anne", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 17, LastName = "Tsuruya", FirstName = "Miho", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 18, LastName = "Surayaa", FirstName = "Laksmhi", HasPayedMembershipFee = false },
            new Customer { PersonalIdentityNumber = 19, LastName = "Ngugi", FirstName = "Achiba", HasPayedMembershipFee = true },
            new Customer { PersonalIdentityNumber = 20, LastName = "Inoue", FirstName = "Akika", HasPayedMembershipFee = false }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
