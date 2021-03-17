using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClaimAPI.Repository;
using ClaimAPI.Repository.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClaimsByDate(DateTime startDate, DateTime endDate)
        {
            // Declare Model
            List<MemberClaimModel> memberClaimModels = new List<MemberClaimModel>();
            //Getting Claims and Members list from repository
            List<Claim> claims = new SampleData().GetClaims();
            List<Member> members = new SampleData().GetMembers();
            // Getting filtered claims depend on provided start date and end date(between dates)
            List<Claim> filterClaims = (from row in claims
                                        where row.ClaimDate < endDate && row.ClaimDate > startDate
                                        select row).ToList();
            if (filterClaims.Count > 0)
            {
                var distinctMemberIds = filterClaims.Select(p => p.MemberID).Distinct().ToList();
                if (distinctMemberIds.Count > 0)
                {

                    for (var i = 0; i < distinctMemberIds.Count; i++)
                    {
                        // Adding multiple members with cliams if multiple members exists in filterClaims Object
                        memberClaimModels.Add(new MemberClaimModel()
                        {
                            Member = members.Where(p => p.MemberID == distinctMemberIds[i]).FirstOrDefault(),
                            ClaimDetails = filterClaims.Where(p => p.MemberID == distinctMemberIds[i]).ToList()
                        });
                    }
                }
            }
            return Ok(memberClaimModels);
        }
    }
}
