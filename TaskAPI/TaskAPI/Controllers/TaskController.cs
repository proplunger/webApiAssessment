using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskAPI.Context;
using TaskAPI.Models;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskApiDbContext _dbContext;

    public TasksController(TaskApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<Tasks> AddTask(Tasks task)
    {
        task.CreatedAt = DateTime.Now;
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChanges();
        return Ok(task);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tasks>> GetAllTasks()
    {
        var tasks = _dbContext.Tasks.ToList();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public ActionResult<Tasks> GetTaskById(int id)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPut("{id}")]
    public IActionResult EditTask(int id, Tasks updatedTask)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        task.Name = updatedTask.Name;
        task.CreatedBy = updatedTask.CreatedBy;
        task.Description = updatedTask.Description;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        _dbContext.Tasks.Remove(task);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
