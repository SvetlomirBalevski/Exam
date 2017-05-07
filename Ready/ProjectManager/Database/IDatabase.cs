using ProjectManager.Models;
using System.Collections.Generic;

/// <summary>
/// Put Projects to Database
/// </summary>
/// 
namespace ProjectManager.Data
{
    // You are not allowed to modify this interface (except to add documentation)
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
