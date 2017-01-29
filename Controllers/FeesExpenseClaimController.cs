using Data;
using FeesExpensesClaimForm.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FeesExpensesClaimForm.Controllers
{
    [Produces("application/json")]
    [Route("api/FeesExpenseClaim")]
    public class FeesExpenseClaimController : Controller
    {
        private readonly FormContext _context;

        public FeesExpenseClaimController(FormContext context){
            _context = context;
        }


        [HttpPost]
        public IActionResult Post([FromBody] FeesExpensesClaim feesExpensesClaim)
        {
            // feesExpensesClaim.PersonalInfo.Id = 2;
            _context.PersonalInfos.Add(feesExpensesClaim.PersonalInfo);
            _context.SaveChanges();

            string msg = string.Format("Dear {0} : The following values have been saved in the database : email - {1} , is first job - {2} ",
                feesExpensesClaim.PersonalInfo.Name, feesExpensesClaim.PersonalInfo.Email, feesExpensesClaim.TaxDeclaration.IsFirstJob);
            JObject jsJObject = new JObject { { "message", msg } };



            return Ok(jsJObject.ToString());
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json("");
        }
    }
}
