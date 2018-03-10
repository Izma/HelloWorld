using HelloWorld.Interfaces;
using HelloWorld.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPerson repository;
        public PersonController(IPerson _repository)
        {
            repository = _repository;
        }


        // GET: Person
        public async Task<ActionResult> Index(string message = "")
        {
            ViewBag.message = message;
            var personList = await repository.GetPersonList();
            return View(personList);
        }

        [HttpGet]
        public async Task<JsonResult> GetPersons()
        {
            var personList = await repository.GetPersonList();
            return Json(personList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> SavePerson(Person person)
        {
            var result = await repository.AddPerson(person);
            if (result == "success")
                return Json(result, JsonRequestBehavior.AllowGet);
            return Json("error", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int personID, string type = "details")
        {
            var person = await repository.GetPerson(personID);
            if (type == "delete")
                ViewBag.isDelete = true;
            ViewBag.personId = personID;
            return View(person);
        }

        public async Task<ActionResult> Delete(int personID)
        {
            var result = await repository.DeletePerson(personID);
            return RedirectToAction("Index", new { message = "The register was deleted success!" });
        }
    }
}