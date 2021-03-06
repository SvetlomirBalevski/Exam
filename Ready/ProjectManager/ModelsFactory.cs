﻿using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Contracts;
using System;

namespace ProjectManager.Models
{
    public class ModelsFactory : IModelFactory
    {
        private readonly Validator validator = new Validator();

        public ModelsFactory()
        {
        }

        public Project CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;
            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);
            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var project = new Project(name, starting, end, state);
            this.validator.Validate(project);

            return project;
        }

        public Task CreateTask(IUser owner, string name, string state)
        {
            var task = new Task(name, owner, state);
            this.validator.Validate(task);

            return task;
        }

        public User CreateUser(string username, string email)
        {
            var user = new User(username, email);
            this.validator.Validate(user);
            return user;
        }
    }
}
