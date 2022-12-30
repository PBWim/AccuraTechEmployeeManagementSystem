namespace EmployeeManagementSystem.Controllers
{
    using Business;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly EmployeeService employeeService;

        /// <summary>
        /// Employee Controller - Exposed to Frontend
        /// </summary>
        public EmployeeController(ILogger<EmployeeController> logger, EmployeeService employeeService)
        {
            this.logger = logger;
            this.employeeService = employeeService;
        }

        /// <summary>
        /// Get all the Employees in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Employee> Get()
        {
            var employee = employeeService.GetAll();
            this.logger.LogInformation($"Get Employees : {employee} on {nameof(this.Get)} in {nameof(EmployeeController)}");
            return employee;
        }

        /// <summary>
        /// Get all the Employee by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<Employee> Get(Guid Id)
        {
            var employee = await employeeService.FindAsync(Id);
            this.logger.LogInformation($"Find Employee for Id : {Id} on {nameof(this.Get)} in {nameof(EmployeeController)}");
            return employee;
        }

        /// <summary>
        /// Create Employee in the system
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> Create([FromBody] Employee model)
        {
            if (model == null || !ModelState.IsValid)
            {
                this.logger.LogWarning($"Invalid Employee model on {nameof(this.Create)} in {nameof(EmployeeController)}");
                return BadRequest("Invalid Employee Model");
            }

            var result = await this.employeeService.CreateAsync(model);
            if (result == default)
            {
                this.logger.LogWarning($"Employee didn't create on {nameof(this.Create)} in {nameof(EmployeeController)}");
                return BadRequest("Employee didn't create.");
            }

            this.logger.LogInformation($"Employee : {model} created on {nameof(this.Create)} in {nameof(EmployeeController)}");
            return Ok(result);
        }

        /// <summary>
        /// Update Employee in the system
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Update([FromBody] Employee model)
        {
            if (model == null || !ModelState.IsValid || model.Id == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Employee model on {nameof(this.Update)} in {nameof(EmployeeController)}");
                return BadRequest("Invalid Employee Model");
            }

            var result = await this.employeeService.UpdateAsync(model);
            if (result == default)
            {
                this.logger.LogWarning($"Employee didn't update on {nameof(this.Update)} in {nameof(EmployeeController)}");
                return BadRequest("Employee didn't update.");
            }

            this.logger.LogInformation($"Employee : {model} updated on {nameof(this.Update)} in {nameof(EmployeeController)}");
            return Ok(result);
        }

        /// <summary>
        /// Delete Employee in the system
        /// </summary>
        /// <returns></returns>  [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> Delete([FromBody] Employee model)
        {
            if (model == null || !ModelState.IsValid || model.Id == Guid.Empty)
            {
                this.logger.LogWarning($"Invalid Employee model on {nameof(this.Delete)} in {nameof(EmployeeController)}");
                return BadRequest("Invalid Employee Model");
            }

            var result = await this.employeeService.DeleteAsync(model);
            if (result == default)
            {
                this.logger.LogWarning($"Employee didn't delete on {nameof(this.Delete)} in {nameof(EmployeeController)}");
                return BadRequest("Employee didn't delete.");
            }

            this.logger.LogInformation($"Employee : {model} deleted on {nameof(this.Delete)} in {nameof(EmployeeController)}");
            return Ok(result);
        }
    }
}