using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers;

[ApiController]
[Route("mestruacao")]
public class MestruacaoController: ControllerBase
{

    private DBCiclo db;

    public MestruacaoController(DBCiclo db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Mestruacoes.ToList());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        List<Mestruacao> Mes = new List<Mestruacao>();
        foreach (var item in db.Mestruacoes)
        {
            if(item.UserId == id)
                Mes.Add(item);
        }
        
        return Ok(Mes.ToList());
    }

    [HttpPost]
    public ActionResult Create(Mestruacao mestruacao)
    {
        db.Mestruacoes.Add(mestruacao);
        db.SaveChanges();
        return Ok("Created");
    }

    [HttpPut]
    public ActionResult Update(Mestruacao mestruacao)
    {
        var mes = db.Mestruacoes.Find(mestruacao);
        mes = mestruacao;
        db.SaveChanges();
        return Ok("Updated");
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Remove(int id)
    {
        var Mes = db.Mestruacoes.FirstOrDefault(x => x.MestruacaoId == id);
        db.Mestruacoes.Remove(Mes);
        db.SaveChanges();
        return Ok("Removed");
    }
}