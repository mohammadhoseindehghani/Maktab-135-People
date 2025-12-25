using Food.Infra.Data.Db.SqlServer.Database;
using UI_MVC.Models.Database;
using UI_MVC.Models.Entities;

namespace UI_MVC.Services;

public class PeopleRepository : IPeopleRepository
{
    private readonly AppPeopleDbContext _appDbContext;

    public PeopleRepository(AppPeopleDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Person> GetAll()
    {
        return _appDbContext.People.ToList();
    }

    public Person FindById(int id)
    {
        return _appDbContext.People.Find(id);
    }

    public int Add(Person model)
    {
        _appDbContext.People.Add(model);
        _appDbContext.SaveChanges();
        return model.Id;
    }
}