using EntityFrameWork.Data;
using EntityFrameWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWork.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDbContext dbContext;
        public EmployeeController(MVCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var employeeModel = new EmployeeModel(); // Create an instance of EmployeeModel
            return View(employeeModel);
        }

        [HttpPost]
        public IActionResult Add(EmployeeModel emp)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = emp.Name,
                Salary = emp.Salary,
                Email = emp.Email,
                DateOfBirth = emp.DateOfBirth,
            };

            dbContext.EmployeeTable.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Add");
        }

        public IActionResult View()
        {
            var employee = dbContext.EmployeeTable.ToList();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Update(Guid Id)
        {
            var employee= dbContext.EmployeeTable.FirstOrDefault(x => x.Id == Id);
            if(employee!=null)
            {
                var UpdateModel = new EmployeeUpdateModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                };
                return View(UpdateModel);
            }
          
            
            return RedirectToAction("View");
        }
        [HttpPost]
        public IActionResult Update(EmployeeUpdateModel emp) 
        { 
            var employee= dbContext.EmployeeTable.Find(emp.Id);
            if(employee!=null)
            {
                employee.Name = emp.Name;
                employee.Salary = emp.Salary;
                employee.Email = emp.Email;
                employee.DateOfBirth = emp.DateOfBirth;
                dbContext.SaveChanges();
                return RedirectToAction("View");
            }
            return Redirect("View");
        }

        [HttpPost]
        public IActionResult Delete(EmployeeUpdateModel emp)
        {
            var employee = dbContext.EmployeeTable.Find(emp.Id);
            if(employee!=null)
            {
                dbContext.EmployeeTable.Remove(employee);
                dbContext.SaveChanges();
                return RedirectToAction("View");
            }
            return RedirectToAction("View");

        }
    }
}
