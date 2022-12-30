namespace EmployeeManagementSystem.Controllers
{
    using Business;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> logger;
        private readonly DepartmentService departmentService;

        /// <summary>
        /// Department Controller - Exposed to Frontend
        /// </summary>
        public DepartmentController(ILogger<DepartmentController> logger, DepartmentService departmentService)
        {
            this.logger = logger;
            this.departmentService = departmentService;
        }

        /// <summary>
        /// Get all the Departments in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Department> Get()
        {
            var department = departmentService.GetAll();
            this.logger.LogInformation($"Get Departments : {department} on {nameof(this.Get)} in {nameof(DepartmentController)}");
            return department;
        }
    }
}