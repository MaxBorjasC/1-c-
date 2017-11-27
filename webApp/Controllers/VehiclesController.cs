using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using webApp.Core;
using webApp.Controllers.Resources;
using webApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace webApp.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {

        private readonly IMapper mapper;
        //private readonly VegaDbContext context;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            //this.context = context;
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            //if (true)
            //{
            //    ModelState.AddModelError("...", "error");
            //    return BadRequest(ModelState);
            //}
            //throw new Exception();
            Console.WriteLine("ingreso == ");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Console.WriteLine("ingreso == ", vehicleResource);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            //context.Vehicles.Add(vehicle);
            repository.Add(vehicle);

            //await context.SaveChangesAsync();
            await unitOfWork.CompleteAsync();

            //var vehicle = await context.Vehicles
            //                   .Include(v => v.Features)
            //                   .ThenInclude(vf => vf.Feature)
            //                   .Include(v => v.Model)
            //                   .ThenInclude(m => m.Make)
            //                   .SingleOrDefaultAsync(v => v.Id == id);

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            //var vehicle = await context.Vehicles.FindAsync(id);
            //var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            //var vehicle = await context.Vehicles
            //                   .Include(v => v.Features)
            //                   .ThenInclude(vf => vf.Feature)
            //                   .Include(v => v.Model)
            //                   .ThenInclude(m => m.Make)
            //                   .SingleOrDefaultAsync(v => v.Id == id);

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            //await context.SaveChangesAsync();
            await unitOfWork.CompleteAsync();

            //vehicle = await context.Vehicles
            //                  .Include(v => v.Features)
            //                  .ThenInclude(vf => vf.Feature)
            //                  .Include(v => v.Model)
            //                  .ThenInclude(m => m.Make)
            //                  .SingleOrDefaultAsync(v => v.Id == vehicle.Id);
            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //var vehicle = await context.Vehicles.FindAsync(id);
            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
                return NotFound();

            //context.Remove(vehicle);
            repository.Remove(vehicle);

            //await context.SaveChangesAsync();
            await unitOfWork.CompleteAsync();


            return Ok(id);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            //var vehicle = await context.Vehicles
            //                    .Include(v => v.Features)
            //                    .ThenInclude(vf=>vf.Feature)
            //                    .Include(v=>v.Model)
            //                    .ThenInclude(m=>m.Make)
            //                    .SingleOrDefaultAsync(v => v.Id == id);
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }


        //[HttpGet]
        //public async Task<IEnumerable<VehicleResource>> GetVehicles(VehicleQueryResource filterResource)
        //{
        //    var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
        //    var vehicles = await repository.GetVehicles(filter);
        //    return mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
        //}

        [HttpGet]
        public async Task<QueryResultResource<VehicleResource>> GetVehicles(VehicleQueryResource filterResource)
        {
            var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
            var queryResult = await repository.GetVehicles(filter);
            return mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
        }



    }
}
