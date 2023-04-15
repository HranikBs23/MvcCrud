using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCrud.Data;
using MvcCrud.Models;
using MvcCrud.Models.Domain;

namespace MvcCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DemoDbContext demoDbContext;

        public EmployeesController(DemoDbContext demoDbContext) {
            this.demoDbContext = demoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees=await demoDbContext.Employee.ToListAsync();
            return View(employees);
        }

        //Get Employee
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Add Employee

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email =addEmployeeRequest.Email,
                Phone =addEmployeeRequest.Phone,
                Salary=addEmployeeRequest.Salary,
                Department =addEmployeeRequest.Department,
                DateTime =addEmployeeRequest.DateTime
                    
            };

            await demoDbContext.Employee.AddAsync(employee);
            await demoDbContext.SaveChangesAsync(); // to save changes to database
            return RedirectToAction("Add");
        }
        
    }
}
