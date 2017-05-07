using ProjectManager.Models;

/// <summary>
/// CreatesProject, User and Tasks for this Factory
/// </summary>
/// 
namespace ProjectManager.Contracts
{
    public interface IModelFactory
    {
        Project CreateProject(string name, string startingDate, string endingDate, string state);

        Task CreateTask(IUser owner, string name, string state);

        User CreateUser(string username, string email);
    }
}
