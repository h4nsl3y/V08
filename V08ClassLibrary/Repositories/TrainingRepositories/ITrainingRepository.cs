﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V08ClassLibrary.Entity;

namespace V08ClassLibrary.Repository.TrainingRepositories
{
    public interface ITrainingRepository
    {
        void Add(Training training);
        void Delete(int id);
        void Update(Training training);
        Training Get(int id);
        IEnumerable<Training> GetAll();
    }
}