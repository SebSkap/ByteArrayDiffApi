using DescartesDiffApi.Model.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DescartesDiffApi.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        private readonly ApiContext _context;

        public DiffController(ApiContext context)
        {
            this._context = context;
        }

        // Get diff info for valueId (GET /v1/Diff/{valueId})
        [HttpGet("{valueId}")]
        public async Task<ActionResult<DiffResponse>> Get(int valueId)
        {
            // search how many values already exist for current valueId
            var existingValueToDiff = await _context.ValueToDiffs.Where(x => x.ValueId == valueId).ToListAsync();

            // if atleast two values do not exist for current valueId, return 404
            if (existingValueToDiff.Count < 2)
            {
                return NotFound(existingValueToDiff);
            } 
            // if atleast two values exist for current valueId, find differences between two values
            else
            {
                DiffCalculation calculation = new DiffCalculation();
                return calculation.diffResponse(existingValueToDiff[0].Data, existingValueToDiff[1].Data);
            }
        }

        // Insert data for valueId and direction (PUT /v1/Diff/{valueId}/{direction})
        [HttpPut("{valueId}/{direction}")]
        public async Task<ActionResult<ValueToDiff>> Put(int valueId, string direction, ValueToDiff valueToDiff)
        {
            // direction always to upper so there's no direction confusion (example Right & RIGHT being two different IDs)
            direction = direction.ToUpper();

            // if direction is not either RIGHT or LEFT, return 400
            if (direction != "RIGHT" && direction != "LEFT")
            {
                return BadRequest(valueToDiff);
            }

            // if Data is null, return 400
            if (valueToDiff.Data == null)
            {
                return BadRequest(valueToDiff);
            }
            else
            {
                // look for existing data for value and direction
                var existingValueToDiff = await _context.ValueToDiffs.Where(x => x.ValueId == valueId && x.Direction == direction).ToListAsync();

                // create new ValueToDiff object with provided parameters
                ValueToDiff newValueToDiff = new ValueToDiff() { ValueId = valueId, Direction = direction, Data = valueToDiff.Data };

                // if no record exists for value and direction, insert a new one
                if (existingValueToDiff.Count == 0)
                {
                    _context.ValueToDiffs.Add(newValueToDiff);
                }
                else
                // if record already exists for value and direction, update an existing one
                {
                    // detach existing value to allow update
                    _context.Entry(existingValueToDiff[0]).State = EntityState.Detached;

                    newValueToDiff.Id = existingValueToDiff[0].Id;

                    // update existing record with new data
                    _context.ValueToDiffs.Update(newValueToDiff);
                }

                await _context.SaveChangesAsync();

                return CreatedAtAction("Put", newValueToDiff);
            }
        }
    }
}
