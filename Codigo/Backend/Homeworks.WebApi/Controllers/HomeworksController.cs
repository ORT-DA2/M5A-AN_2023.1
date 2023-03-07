using System;
using Microsoft.AspNetCore.Mvc;
using Homeworks.BusinessLogic.Interface;
using Homeworks.BusinessLogic.Extensions;
using Homeworks.WebApi.Models;
using Homeworks.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Homeworks.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworksController : ControllerBase
    {
        private readonly ILogic<Homework> _service;

        private readonly HomeworkModel[] _homeworks;

        public HomeworksController(ILogic<Homework> homeworks) : base()
        {
            this._service = homeworks;
            this._homeworks = new HomeworkModel[]
            {
                new HomeworkModel
                {
                    Description = "Facil",
                    DueDate = new DateTime(2021, 05, 25),
                    Exercises = new List<ExerciseModel>(),
                    Score = 5,
                    Id = new Guid("a608c051-a900-4d7a-9323-a93c39065288"),
                    Rating = 5
                },
                new HomeworkModel
                {
                    Description = "Normal",
                    DueDate = new DateTime(2021, 05, 24),
                    Score = 10,
                    Id = new Guid("c34e0940-3778-43ea-b4ef-8eea3bc305c9"),
                    Rating = 3,
                    Exercises = new List<ExerciseModel> 
                    { 
                        new ExerciseModel
                        {
                            Id = new Guid("366fb9d3-8d65-46e3-a3ef-cac485786cc7"),
                            Score = 10,
                            Problem = "10 + 10 = ?"
                        }
                    },
                },
                new HomeworkModel
                {
                    Description = "Dificil",
                    DueDate = new DateTime(2021, 05, 24),
                    Score = 20,
                    Id = new Guid("7746edae-a8bf-442e-80f2-c2b431c8c6b3"),
                    Rating = 1,
                    Exercises = new List<ExerciseModel>
                    {
                        new ExerciseModel
                        {
                            Id = new Guid("52309449-3bbb-40ff-9800-d2494f0a09ef"),
                            Score = 10,
                            Problem = "10 * 10 = ?"
                        },
                        new ExerciseModel
                        {
                            Id = new Guid("c352ae64-fe2c-4b7f-8a54-ba72344738ae"),
                            Score = 10,
                            Problem = "10 - 10 = ?"
                        }
                    },
                }
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_homeworks);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var homework = _homeworks.FirstOrDefault(x => x.Id == id);
            if (homework == null) {
                return NotFound();
            }
            return Ok(homework);
        }

        [HttpPost("{id}/Exercises", Name = "AddExercise")]
        public IActionResult PostExercise(Guid id, [FromBody]ExerciseModel exercise)
        {
            var newExercise = _service.AddExercise(id, ExerciseModel.ToEntity(exercise));
            if (newExercise == null) {
                return BadRequest();
            }
            return CreatedAtRoute("GetExercise", new { id = newExercise.Id }, ExerciseModel.ToModel(newExercise));
        }

        [HttpPost]
        public IActionResult Post([FromBody]HomeworkModel model)
        {
            try {
                var homework = _service.Create(HomeworkModel.ToEntity(model));
                return CreatedAtRoute("Get", new { id = homework.Id }, HomeworkModel.ToModel(homework));
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]HomeworkModel model)
        {
            try {
                var homework = _service.Update(id, HomeworkModel.ToEntity(model));
                return CreatedAtRoute("Get", new { id = homework.Id }, HomeworkModel.ToModel(homework));
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Remove(id);
            return NoContent();
        }

    }
}
