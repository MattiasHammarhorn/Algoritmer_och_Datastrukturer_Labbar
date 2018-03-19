using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift3
{
    class Customer
    {
        public int PersonalIdentityNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool HasPayedMembershipFee { get; set; }

        // private int _personalIdentityNumber;
        // private int _age;
        // private string _lastName;
        // private string _firstName;
        // private bool _hasPayedMembershipFee;
        // 
        // public Customer(int personalIdentityNumber, int age, string lastName, string firstName, bool hasPayedmemberShipfee)
        // {
        //     this._personalIdentityNumber = personalIdentityNumber;
        //     this._age = age;
        //     this._lastName = lastName;
        //     this._firstName = firstName;
        //     this._hasPayedMembershipFee = hasPayedmemberShipfee;
        // }
        // 
        // public int PersonalIdentityNumber
        // {
        //     get { return this._personalIdentityNumber; }
        //     set { _personalIdentityNumber = value; }
        // }
        // 
        // public int Age
        // {
        //     get { return this._age; }
        //     set { _age = value; }
        // }
        // 
        // public string LastName
        // {
        //     get { return this._lastName; }
        //     set { _lastName = value; }
        // }
        // 
        // public string FirstName
        // {
        //     get { return this._firstName; }
        //     set { _firstName = value; }
        // }
        // 
        // public bool HasPayedMembershipFee
        // {
        //     get { return this._hasPayedMembershipFee; }
        //     set { HasPayedMembershipFee = value; }
        // }
    }
}
