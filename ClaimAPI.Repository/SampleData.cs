using ClaimAPI.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClaimAPI.Repository
{
    public class SampleData
    {
        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            //Adding sample member data
            members.Add(new Member()
            {
                MemberID = 1123,
                FirstName = "John",
                LastName = "Doe",
                EnrollmentDate = Convert.ToDateTime("9/1/2020")
            });
            members.Add(new Member()
            {
                MemberID = 1245,
                FirstName = "Jane",
                LastName = "Doe",
                EnrollmentDate = Convert.ToDateTime("10/3/2020")
            });
            return members;
        }

        public List<Claim> GetClaims()
        {
            List<Claim> claims = new List<Claim>();
            //Adding sample Claim data
            claims.Add(new Claim()
            {
                MemberID = 1123,
                ClaimAmount = 1112.56M,
                ClaimDate = Convert.ToDateTime("10/6/2020")
            });
            claims.Add(new Claim()
            {
                MemberID = 1245,
                ClaimAmount = 67.54M,
                ClaimDate = Convert.ToDateTime("12/5/2020")
            });
            return claims;
        }
    }
}
