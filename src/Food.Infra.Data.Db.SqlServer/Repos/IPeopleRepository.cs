using UI_MVC.Models.Entities;

namespace UI_MVC.Services
{
    public interface IPeopleRepository
    {
        List<Person> GetAll();
        Person FindById(int id);
    }
}
