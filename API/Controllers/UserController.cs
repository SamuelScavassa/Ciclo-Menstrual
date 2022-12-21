using Microsoft.AspNetCore.Mvc;

using API.Models;

namespace API.Controllers;

[ApiController]
[Route("user")]
public class UserController: ControllerBase
{

    private DBCiclo db;

    public UserController(DBCiclo db)
    {
        this.db = db;
    }

    

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Users.ToList());     
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        return Ok(db.Users.FirstOrDefault(x => x.UserId == id));     
    }

    [HttpPost]
    public ActionResult Create(User User)
    {
        db.Users.Add(User);
        db.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(User User)
    {
        User usr = db.Users.Find(User);
        usr = User;
        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int Id)
    {
        User usr = db.Users.Find(Id);
        db.Users.Remove(usr);
        db.SaveChanges();
        return Ok();
    }

    

}