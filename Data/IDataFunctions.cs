﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebELearning.Entities;

namespace WebELearning.Data
{
    public interface IDataFunctions
    {
        Task UpdateUserCategoryEntityAsync(List<UserCategory> userCategoryItemsToDelete, List<UserCategory> userCategoryItemsToAdd);
    }
}
