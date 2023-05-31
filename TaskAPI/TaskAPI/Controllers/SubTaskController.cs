using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskAPI.Context;
using TaskAPI.Models;

[ApiController]
[Route("api/subtasks")]
public class SubTaskController : ControllerBase
{
    private readonly TaskApiDbContext _dbContext;

    public SubTaskController(TaskApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<SubTask> AddSubTask(SubTask subTask)
    {
        subTask.CreatedAt = DateTime.Now;
        _dbContext.SubTasks.Add(subTask);
        _dbContext.SaveChanges();
        return Ok(subTask);
    }

    [HttpGet("{taskId}")]
    public ActionResult<IEnumerable<SubTask>> GetSubTasksForTask(int taskId)
    {
        var subTasksForTask = _dbContext.SubTasks.Where(st => st.TaskId == taskId).ToList();
        return Ok(subTasksForTask);
    }
}
